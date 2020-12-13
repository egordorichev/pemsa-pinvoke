using AOT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PemsaGraphics : MonoBehaviour
{
    public static Color[] screenColorData { get; } = new Color[128 * 128];

    public static Color[] standardPalette { get; } = {
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

    public static IntPtr emulator;
    public static int fps;

    private void Update()
    {
        fps = (int)(1f / Time.deltaTime);
    }

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedFlip))]
    public static void Flip()
    {
        if (emulator == IntPtr.Zero)
        {
            return;
        }

        IntPtr ram = PemsaLibrary.GetRam(emulator);
        int[] screenColor = new int[16];

        for (int i = 0; i < 16; i++)
        {
            screenColor[i] = PemsaLibrary.GetScreenColor(emulator, i);
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

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedCreateSurface))]
    public static void CreateSurface()
    {

    }

    [MonoPInvokeCallback(typeof(PemsaLibrary.ManagedGetFps))]
    public static int GetFps()
    {
        return fps;
    }
}
