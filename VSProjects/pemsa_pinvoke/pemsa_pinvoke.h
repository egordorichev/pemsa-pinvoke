#pragma once

#include "pinvoke_audio_backend.h"
#include "pinvoke_graphics_backend.h"
#include "pinvoke_input_backend.h"

#define PEMSA_API __declspec(dllexport) 

typedef void* PEMSA_HANDLE;

#ifdef __cplusplus
extern "C"
{
#endif

	PEMSA_API PEMSA_HANDLE AllocateEmulator(
		ManagedFlip flip, 
		ManagedCreateSurface createSurface, 
		ManagedGetFps getfPS,
		ManagedIsButtonDown isButtonDown,
		ManagedIsButtonPressed isButtonPressed,
		ManagedUpdate update,
		ManagedGetMouseX getMouseX,
		ManagedGetMouseY getMouseY,
		ManagedGetMouseMask getMouseMask,
		ManagedReadKey readKey,
		ManagedHasKey hasKey,
		ManagedReset reset,
		ManagedGetClipboardText getClipboardText);
	PEMSA_API void FreeEmulator(PEMSA_HANDLE emulator);
	PEMSA_API void StopEmulator(PEMSA_HANDLE emulator);
	PEMSA_API void ResetEmulator(PEMSA_HANDLE emulator);
	PEMSA_API void* GetRam(PEMSA_HANDLE emulator);
	PEMSA_API uint8_t GetScreenColor(PEMSA_HANDLE emulator, int i);
	PEMSA_API void UpdateEmulator(PEMSA_HANDLE emulator, double delta);
	PEMSA_API void LoadCart(PEMSA_HANDLE emulator, const char* cart);
	PEMSA_API double SampleAudio(PEMSA_HANDLE emulator);
	PEMSA_API double* SampleAudioMultiple(PEMSA_HANDLE emulator, double* samples, int nSamples);

#ifdef __cplusplus
}
#endif