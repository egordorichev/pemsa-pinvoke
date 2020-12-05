using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Threading;
using UnityEngine.UI;

public class Pemsa : MonoBehaviour
{
    delegate void ManagedFlip();
    delegate void ManagedCreateSurface();
    delegate int ManagedGetFps();
    delegate bool ManagedIsButtonDown(int i, int p);
    delegate bool ManagedIsButtonPressed(int i, int p);
    delegate void ManagedUpdateInput();
    delegate int ManagedGetMouseX();
    delegate int ManagedGetMouseY();
    delegate int ManagedGetMouseMask();
    delegate string ManagedReadKey();
    delegate bool ManagedHasKey();
    delegate void ManagedResetInput();
    delegate string ManagedGetClipboardText();

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.StdCall)]
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

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr GetRam(IntPtr emulator);

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern Byte GetScreenColor(IntPtr emulator, int i);

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern void UpdateEmulator(IntPtr emulator, double delta);

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern void LoadCart(IntPtr emulator, string cart);

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

    private static int fps;

    private static bool[,] buttonDown = new bool[7, 8];
    private static bool[,] buttonPressed = new bool[7, 8];
    private static float mouseX, mouseY;
    private Vector2 rectTranslation;
    private static int mouseMask = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        screenTexture = new Texture2D(128, 128, TextureFormat.RGBA32, false, true);
        screenTexture.filterMode = FilterMode.Point;

        rawImage.GetComponent<RawImage>().texture = screenTexture;



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
        LoadCart(emulator, "C:/Users/matdi/Documents/git/pemsa-carts/slipways.p8");
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

    #region GRAPHICS

    static void Flip()
    {
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

    static void CreateSurface()
    {

    }

    static int GetFps()
    {
        return fps;
    }

    #endregion

    #region INPUT

    static bool IsButtonDown(int i, int p)
    {
        lock (buttonPressed)
        {
            return buttonDown[i, p];
        }
    }

    static bool IsButtonPressed(int i, int p)
    {
        lock(buttonPressed)
        { 
            return buttonPressed[i, p];
        }
    }

    static void UpdateInput()
    {

    }

    static int GetMouseX()
    {
        return (int)mouseX;
    }

    static int GetMouseY()
    {
        return (int)mouseY;
    }

    static int GetMouseMask()
    {
        return mouseMask;
    }

    static string ReadKey()
    {
        return "";
    }

    static bool HasKey()
    {
        return false;
    }

    static void ResetInput()
    {

    }

    static string GetClipboardText()
    {
        return "";
    }

    #endregion
}
