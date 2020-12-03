using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class Pemsa : MonoBehaviour
{
    delegate void ManagedFlip();
    delegate void ManagedCreateSurface();
    delegate Int64 ManagedGetFps();

    [DllImport("pemsa_pinvoke.dll")]
    private static extern IntPtr AllocateEmulator(ManagedFlip flip, ManagedCreateSurface createSurface, ManagedGetFps getFps);

    [DllImport("pemsa_pinvoke.dll")]
    private static extern IntPtr GetRam(IntPtr emulator);

    [DllImport("pemsa_pinvoke.dll")]
    private static extern Byte GetScreenColor(IntPtr emulator, int i);

    [DllImport("pemsa_pinvoke.dll")]
    private static extern void UpdateEmulator(IntPtr emulator, double delta);

    [DllImport("pemsa_pinvoke.dll")]
    private static extern void LoadCart(IntPtr emulator, string cart);

    public static Color[] standardPalette = {
            new Color( 0, 0, 0 ),
            new Color(29, 43, 83),
            new Color(126, 37, 83),
            new Color(0, 135, 81),
            new Color(171, 82, 54),
            new Color(95, 87, 79),
            new Color(194, 195, 199),
            new Color(255, 241, 232),
            new Color(255, 0, 77),
            new Color(255, 163, 0),
            new Color(255, 236, 39),
            new Color(0, 228, 54),
            new Color(41, 173, 255),
            new Color(131, 118, 156),
            new Color(255, 119, 168),
            new Color(255, 204, 170)
        };

    private static Color[] screenColorData = new Color[128 * 128];
    static Texture2D screenTexture;
    private static IntPtr emulator;

    // Start is called before the first frame update
    void Start()
    {
        screenTexture = new Texture2D(128, 128, TextureFormat.RGBA32, false, true);

        GetComponent<Renderer>().material.mainTexture = screenTexture;

        emulator = AllocateEmulator(Flip, CreateSurface, GetFps);
        LoadCart(emulator, "C:/Users/matdi/Documents/git/pemsa-carts/celeste");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEmulator(emulator, Time.deltaTime);
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

            screenColorData[i * 2] = standardPalette[screenColor[val & 0x0f]];
            screenColorData[i * 2 + 1] = standardPalette[screenColor[val >> 4]];
        }

        screenTexture.SetPixels(screenColorData);
        screenTexture.Apply();
    }

    static void CreateSurface()
    {

    }

    static Int64 GetFps()
    {
        return 60;
    }
}
