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
    delegate Int64 ManagedGetFps();

    [DllImport("pemsa_pinvoke.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr AllocateEmulator(ManagedFlip flip, ManagedCreateSurface createSurface, ManagedGetFps getFps);

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

    public RawImage rawImage;
    private static Color[] screenColorData = new Color[128 * 128];
    static Texture2D screenTexture;
    private static IntPtr emulator;

    private static Int64 fps;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        screenTexture = new Texture2D(128, 128, TextureFormat.RGBA32, false, true);
        screenTexture.filterMode = FilterMode.Point;

        rawImage.texture = screenTexture;

        emulator = AllocateEmulator(Flip, CreateSurface, GetFps);
        LoadCart(emulator, "C:/Users/matdi/Documents/git/pemsa-carts/celeste.p8");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEmulator(emulator, Time.deltaTime);
        screenTexture.SetPixels(screenColorData);

        screenTexture.Apply();

        fps = (long)(1f / Time.deltaTime);
    }

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

    static Int64 GetFps()
    {
        return fps;
    }
}
