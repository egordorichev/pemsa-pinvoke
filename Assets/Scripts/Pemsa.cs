using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Threading;
using UnityEngine.UI;
using AOT;

[RequireComponent(typeof(AudioSource))]
public class Pemsa : MonoBehaviour
{

    #region PEMSA_PINVOKE
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void ManagedFlip();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void ManagedCreateSurface();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int ManagedGetFps();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate bool ManagedIsButtonDown(int i, int p);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate bool ManagedIsButtonPressed(int i, int p);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void ManagedUpdateInput();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int ManagedGetMouseX();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int ManagedGetMouseY();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int ManagedGetMouseMask();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate string ManagedReadKey();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate bool ManagedHasKey();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void ManagedResetInput();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate string ManagedGetClipboardText();

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr AllocateEmulator(
        ManagedFlip flip, 
        ManagedCreateSurface createSurface, 
        ManagedGetFps getFps,
        ManagedIsButtonDown isButtonDown,
        ManagedIsButtonPressed isButtonPressed,
        ManagedUpdateInput updateInput,
        ManagedGetMouseX getMouseX,
        ManagedGetMouseY getMouseY,
        ManagedGetMouseMask getMouseMask,
        ManagedReadKey readKey,
        ManagedHasKey hasKey,
        ManagedResetInput resetInput,
        ManagedGetClipboardText getClipboardText);

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void FreeEmulator(IntPtr emulator);

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void StopEmulator(IntPtr emulator);

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void ResetEmulator(IntPtr emulator);

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr GetRam(IntPtr emulator);

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern Byte GetScreenColor(IntPtr emulator, int i);

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void UpdateEmulator(IntPtr emulator, double delta);

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void LoadCart(IntPtr emulator, string cart);

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern double SampleAudio(IntPtr emulator);


    #endregion

    public static Color[] standardPalette = {
            new Color( 0, 0, 0 ),
            new Color(29f/255f, 43f/255f, 83f/255f),
            new Color(126f/255f, 37f/255f, 83f/255f),
            new Color(0f/255f, 135f/255f, 81f/255f),
            new Color(171f/255f, 82f/255f, 54f/255f),
            new Color(95f/255f, 87f/255f, 79f/255f),
            new Color(194f/255f, 195f/255f, 199f/255f),
            new Color(255f/255f, 241f/255f, 232f/255f),
            new Color(255f/255f, 0f/255f, 77f/255f),
            new Color(255f/255f, 163f/255f, 0f/255f),
            new Color(255f/255f, 236f/255f, 39f/255f),
            new Color(0f/255f, 228f/255f, 54f/255f),
            new Color(41f/255f, 173f/255f, 255f/255f),
            new Color(131f/255f, 118f/255f, 156f/255f),
            new Color(255f/255f, 119f/255f, 168f/255f),
            new Color(255f/255f, 204f/255f, 170f/255f)
        };

    public GameObject rawImage;
    private static Color[] screenColorData = new Color[128 * 128];
    static Texture2D screenTexture;
    private static IntPtr emulator;
    private static object emuLock = new object();

    private static int fps;

    private static int PEMSA_BUTTON_COUNT = 7;
    private static int PEMSA_PLAYER_COUNT = 8;

    private static bool[,] buttonDown = new bool[PEMSA_BUTTON_COUNT, PEMSA_PLAYER_COUNT];
    private static bool[,] buttonPressed = new bool[PEMSA_BUTTON_COUNT, PEMSA_PLAYER_COUNT];
    private static float mouseX, mouseY;
    private static int mouseMask = 0;
    private static bool anyKeyDown = false;
    private static string lastKeyDown = "";

    // Used to translate rawImage rect transform coordinates to 0 - height instead of -height/2 - height/2
    private Vector2 rectTranslation;

    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60;
        screenTexture = new Texture2D(128, 128, TextureFormat.RGBA32, false, true);
        screenTexture.filterMode = FilterMode.Point;

        rawImage.GetComponent<RawImage>().texture = screenTexture;

        AudioConfiguration audioConfig = AudioSettings.GetConfiguration();
        audioConfig.sampleRate = PEMSA_SAMPLE_RATE / 2;
        audioConfig.dspBufferSize = PEMSA_SAMPLE_SIZE;
        AudioSettings.Reset(audioConfig);

        GetComponent<AudioSource>().Play();

        emulator = AllocateEmulator(
            Flip, 
            CreateSurface, 
            GetFps,
            IsButtonDown,
            IsButtonPressed,
            UpdateInput,
            GetMouseX,
            GetMouseY,
            GetMouseMask,
            ReadKey,
            HasKey,
            ResetInput,
            GetClipboardText);
        //LoadCart(emulator, "C:/Users/matdi/Documents/git/pemsa-carts/celeste.p8");
    }

    // Update is called once per frame
    void Update()
    {
        //
        // Update imput.
        //

        lock(buttonDown)
        {
            buttonDown[0, 0] = Input.GetKey(KeyCode.LeftArrow);
            buttonDown[1, 0] = Input.GetKey(KeyCode.RightArrow);
            buttonDown[2, 0] = Input.GetKey(KeyCode.UpArrow);
            buttonDown[3, 0] = Input.GetKey(KeyCode.DownArrow);
            buttonDown[4, 0] = Input.GetKey(KeyCode.Z);
            buttonDown[5, 0] = Input.GetKey(KeyCode.X);
            buttonDown[6, 0] = Input.GetKey(KeyCode.P);
        }

        lock(buttonPressed)
        {
            buttonPressed[0, 0] = Input.GetKeyDown(KeyCode.LeftArrow);
            buttonPressed[1, 0] = Input.GetKeyDown(KeyCode.RightArrow);
            buttonPressed[2, 0] = Input.GetKeyDown(KeyCode.UpArrow);
            buttonPressed[3, 0] = Input.GetKeyDown(KeyCode.DownArrow);
            buttonPressed[4, 0] = Input.GetKeyDown(KeyCode.Z);
            buttonPressed[5, 0] = Input.GetKeyDown(KeyCode.X);
            buttonPressed[6, 0] = Input.GetKeyDown(KeyCode.P);
        }

        lock(lastKeyDown)
        {
            lastKeyDown = Input.inputString;
        }

        anyKeyDown = Input.anyKeyDown;


        mouseMask = 0;
        mouseMask |= Input.GetKey(KeyCode.Mouse0) ? 1 : 0;
        mouseMask |= Input.GetKey(KeyCode.Mouse1) ? 2 : 0;
        mouseMask |= Input.GetKey(KeyCode.Mouse2) ? 3 : 0;

        Vector2 point;
        RectTransform rectTransform = rawImage.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, Camera.main, out point);

        mouseX = point.x;
        mouseY = point.y;

        rectTranslation = new Vector2(rectTransform.rect.width / 2, rectTransform.rect.height / 2);
        mouseX += rectTranslation.x;
        mouseY += rectTranslation.y;

        mouseX = (mouseX / rectTransform.rect.width) * 128;
        mouseY = (mouseY / rectTransform.rect.height) * 128;

        //
        // Update emulator.
        //

        UpdateEmulator(emulator, Time.deltaTime);
        screenTexture.SetPixels(screenColorData);

        screenTexture.Apply();

        fps = (int)(1f / Time.deltaTime);

    }

    private void OnApplicationQuit()
    {
        lock(emuLock)
        {
            FreeEmulator(emulator);
            emulator = IntPtr.Zero;
        }
    }

    #region GRAPHICS

    [MonoPInvokeCallback(typeof(ManagedFlip))]
    static void Flip()
    {
        if (emulator == IntPtr.Zero)
        {
            return;
        }

        IntPtr ram = GetRam(emulator);
        int[] screenColor = new int[16];

        for(int i = 0; i < 16; i++)
        {
            screenColor[i] = GetScreenColor(emulator, i);
        }

        for (int i = 0; i < 0x2000; i++)
        {
            Byte val = Marshal.ReadByte(ram + i + 0x6000);
            int rv = screenColor[val & 0x0f];
            int lv = screenColor[val >> 4];

            screenColorData[i * 2] = standardPalette[rv];
            screenColorData[i * 2 + 1] = standardPalette[lv];
        }
    }

    [MonoPInvokeCallback(typeof(ManagedCreateSurface))]
    static void CreateSurface()
    {

    }

    [MonoPInvokeCallback(typeof(ManagedGetFps))]
    static int GetFps()
    {
        return fps;
    }

    #endregion

    #region INPUT

    [MonoPInvokeCallback(typeof(ManagedIsButtonDown))]
    static bool IsButtonDown(int i, int p)
    {
        lock (buttonPressed)
        {
            return buttonDown[i, p];
        }
    }

    [MonoPInvokeCallback(typeof(ManagedIsButtonPressed))]
    static bool IsButtonPressed(int i, int p)
    {
        lock(buttonPressed)
        { 
            return buttonPressed[i, p];
        }
    }

    [MonoPInvokeCallback(typeof(ManagedUpdateInput))]
    static void UpdateInput()
    {

    }

    [MonoPInvokeCallback(typeof(ManagedGetMouseX))]
    static int GetMouseX()
    {
        return (int)mouseX;
    }

    [MonoPInvokeCallback(typeof(ManagedGetMouseY))]
    static int GetMouseY()
    {
        return (int)mouseY;
    }

    [MonoPInvokeCallback(typeof(ManagedGetMouseMask))]
    static int GetMouseMask()
    {
        return mouseMask;
    }

    [MonoPInvokeCallback(typeof(ManagedReadKey))]
    static string ReadKey()
    {
        lock (lastKeyDown)
        {
            return lastKeyDown;
        }
    }

    [MonoPInvokeCallback(typeof(ManagedHasKey))]
    static bool HasKey()
    {
        return anyKeyDown;
    }

    [MonoPInvokeCallback(typeof(ManagedResetInput))]
    static void ResetInput()
    {
        lock (buttonPressed)
        {
            for(int i = 0; i < PEMSA_BUTTON_COUNT; ++i)
            {
                for (int j = 0; j < PEMSA_PLAYER_COUNT; ++j)
                {
                    buttonDown[i, j] = false;
                }
            }
        }
    }

    [MonoPInvokeCallback(typeof(ManagedGetClipboardText))]
    static string GetClipboardText()
    {
        return GUIUtility.systemCopyBuffer;
    }

    #endregion

    #region AUDIO

    private static int PEMSA_SAMPLE_SIZE = 2048;
    private static int PEMSA_SAMPLE_RATE = 44100;
    //private static int PEMSA_CHANNEL_COUNT = 4;

    void OnAudioFilterRead(float[] data, int channels)
    {
        lock(emuLock)
        {
            if (emulator == IntPtr.Zero)
            {
                return;
            }

            int dataLen = data.Length / channels;
            for (int i = 0; i < dataLen; i += 1)
            {
                for (int j = 0; j < channels; j += 1)
                {
                    data[i * channels + j] = (float)SampleAudio(emulator);
                }
            }
        }
    }

    #endregion
}
