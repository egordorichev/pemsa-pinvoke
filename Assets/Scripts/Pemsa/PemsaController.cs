using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Threading;
using UnityEngine.UI;
using AOT;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(PemsaGraphics))]
[RequireComponent(typeof(PemsaInput))]
[RequireComponent(typeof(PemsaAudio))]
public class PemsaController : MonoBehaviour
{

    public GameObject rawImage;
    static Texture2D screenTexture;
    private static IntPtr emulator;
    private static object emuLock = new object();

    private PemsaAudio pemsaAudio;
    private PemsaGraphics pemsaGraphics;
    private PemsaInput pemsaInput;

    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60;
        screenTexture = new Texture2D(128, 128, TextureFormat.RGBA32, false, true);
        screenTexture.filterMode = FilterMode.Point;

        rawImage.GetComponent<RawImage>().texture = screenTexture;

        emulator = PemsaLibrary.AllocateEmulator(
            PemsaGraphics.Flip,
            PemsaGraphics.CreateSurface,
            PemsaGraphics.GetFps,
            PemsaInput.IsButtonDown,
            PemsaInput.IsButtonPressed,
            PemsaInput.UpdateInput,
            PemsaInput.GetMouseX,
            PemsaInput.GetMouseY,
            PemsaInput.GetMouseMask,
            PemsaInput.ReadKey,
            PemsaInput.HasKey,
            PemsaInput.ResetInput,
            PemsaInput.GetClipboardText);
        PemsaLibrary.LoadCart(emulator, "C:/Users/matdi/Documents/git/pemsa-carts/celeste.p8");

        //
        // Start every module.
        //

        pemsaAudio = GetComponent<PemsaAudio>();
        pemsaGraphics = GetComponent<PemsaGraphics>();
        pemsaInput = GetComponent<PemsaInput>();

        PemsaGraphics.emulator = emulator;
        PemsaAudio.emulator = emulator;
    }

    // Update is called once per frame
    void Update()
    {
        //
        // Update emulator.
        //

        PemsaLibrary.UpdateEmulator(emulator, Time.deltaTime);
        screenTexture.SetPixels(PemsaGraphics.screenColorData);

        screenTexture.Apply();
    }

    private void OnApplicationQuit()
    {
        // Stop audio from updating since it runs on a separate thread.
        GetComponent<AudioSource>().Stop();

        PemsaLibrary.FreeEmulator(emulator);
        emulator = IntPtr.Zero;
    }
}
