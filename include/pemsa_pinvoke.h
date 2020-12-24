#ifndef PEMSA_PINVOKE_H
#define PEMSA_PINVOKE_H

#include "pemsa_common.h"
#include "pinvoke_audio_backend.h"
#include "pinvoke_graphics_backend.h"
#include "pinvoke_input_backend.h"

#ifdef __linux__
#define PEMSA_API
#else
#define PEMSA_API __declspec(dllexport)
#endif

typedef void *pemsa_handle_t;

#ifdef __cplusplus
extern "C" {
#endif

PEMSA_API pemsa_handle_t AllocateEmulator(
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
	ManagedGetClipboardText getClipboardText
);

PEMSA_API void FreeEmulator(pemsa_handle_t emulator);
PEMSA_API void StopEmulator(pemsa_handle_t emulator);
PEMSA_API void ResetEmulator(pemsa_handle_t emulator);
PEMSA_API void *GetRam(pemsa_handle_t emulator);
PEMSA_API uint8_t GetScreenColor(pemsa_handle_t emulator, int i);
PEMSA_API void UpdateEmulator(pemsa_handle_t emulator, double delta);
PEMSA_API void LoadCart(pemsa_handle_t emulator, const char *cart);
PEMSA_API void CleanupAndLoadCart(pemsa_handle_t emulator, const char *cart);
PEMSA_API double SampleAudio(pemsa_handle_t emulator);
PEMSA_API double *SampleAudioMultiple(pemsa_handle_t emulator, double *samples, int nSamples);

#ifdef __cplusplus
}
#endif

#endif