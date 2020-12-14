#include "pemsa/pemsa_emulator.hpp"
#include "pemsa_pinvoke.h"

bool running = true;

pemsa_handle_t AllocateEmulator(ManagedFlip flip,
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
    ManagedGetClipboardText getClipboardText) {

	return (pemsa_handle_t) (new PemsaEmulator(
		new PInvokeGraphicsBackend(flip, createSurface, getfPS),
		new PInvokeAudioBackend(),
		new PInvokeInputBackend(isButtonDown, isButtonPressed, update, getMouseX, getMouseY, getMouseMask, readKey, hasKey, reset, getClipboardText),
			&running));
}

PEMSA_API void FreeEmulator(pemsa_handle_t emulator) {
	delete ((PemsaEmulator *) emulator);
}

PEMSA_API void StopEmulator(pemsa_handle_t emulator) {
	((PemsaEmulator *) emulator)->stop();
}

PEMSA_API void ResetEmulator(pemsa_handle_t emulator) {
	((PemsaEmulator *) emulator)->reset();
}

void *GetRam(pemsa_handle_t emulator) {
	return ((PemsaEmulator *) emulator)->getMemoryModule()->ram;
}

uint8_t GetScreenColor(pemsa_handle_t emulator, int i) {
	return ((PemsaEmulator *) emulator)->getDrawStateModule()->getScreenColor(i);
}

void UpdateEmulator(pemsa_handle_t emulator, double delta) {
	((PemsaEmulator *) emulator)->update(delta);
}

void LoadCart(pemsa_handle_t emulator, const char *cart) {
	((PemsaEmulator *) emulator)->getCartridgeModule()->load(cart);
}

double SampleAudio(pemsa_handle_t emulator) {
	return ((PemsaEmulator *) emulator)->getAudioModule()->sample();
}

double *SampleAudioMultiple(pemsa_handle_t emulator, double *samples, int nSamples) {
	PemsaAudioModule *audioModule = ((PemsaEmulator *) emulator)->getAudioModule();

	for (int i = 0; i < nSamples; ++i) {
		samples[i] = audioModule->sample();
	}

	return samples;
}
