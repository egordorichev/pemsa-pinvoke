using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PemsaAudio : MonoBehaviour
{
    public static IntPtr emulator;

    private static int PEMSA_SAMPLE_SIZE = 2048;
    private static int PEMSA_SAMPLE_RATE = 44100;
    private static int PEMSA_CHANNEL_COUNT = 4;

    double[] audioSamples;

    // Update is called once per frame
    void Start()
    {
        AudioConfiguration audioConfig = AudioSettings.GetConfiguration();
        audioConfig.sampleRate = PEMSA_SAMPLE_RATE;
        audioConfig.dspBufferSize = PEMSA_SAMPLE_SIZE;
        AudioSettings.Reset(audioConfig);

        GetComponent<AudioSource>().Play();

        audioSamples = new double[PEMSA_SAMPLE_SIZE];
    }


    void OnAudioFilterRead(float[] data, int channels)
    {
        PemsaLibrary.SampleAudioMultiple(emulator, audioSamples, PEMSA_SAMPLE_SIZE);
        for (int i = 0; i < PEMSA_SAMPLE_SIZE; i += 1)
        {
            for (int j = 0; j < channels; j += 1)
            {
                data[i * channels + j] = (float)audioSamples[i];
            }
        }
    }
}
