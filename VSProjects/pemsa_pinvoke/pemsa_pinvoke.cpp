#include "pemsa/pemsa_emulator.hpp"
#include "pemsa_pinvoke.h"

bool running = true;

PEMSA_HANDLE AllocateEmulator(ManagedFlip flip,
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
    ManagedGetClipboardText getClipboardText)
{
    return (PEMSA_HANDLE)(new PemsaEmulator(
        new PInvokeGraphicsBackend(flip, createSurface, getfPS), 
        new PInvokeAudioBackend(), 
        new PInvokeInputBackend(isButtonDown, isButtonPressed, update, getMouseX, getMouseY, getMouseMask, readKey, hasKey, reset, getClipboardText), 
        &running));
}

PEMSA_API void FreeEmulator(PEMSA_HANDLE emulator)
{
    delete ((PemsaEmulator*)emulator);
}

PEMSA_API void StopEmulator(PEMSA_HANDLE emulator)
{
    ((PemsaEmulator*)emulator)->stop();
}

PEMSA_API void ResetEmulator(PEMSA_HANDLE emulator)
{
    ((PemsaEmulator*)emulator)->reset();
}

void* GetRam(PEMSA_HANDLE emulator)
{
    return ((PemsaEmulator*)emulator)->getMemoryModule()->ram;
}

uint8_t GetScreenColor(PEMSA_HANDLE emulator, int i)
{
    return ((PemsaEmulator*)emulator)->getDrawStateModule()->getScreenColor(i);
}

void UpdateEmulator(PEMSA_HANDLE emulator, double delta)
{
    ((PemsaEmulator*)emulator)->update(delta);
}

void LoadCart(PEMSA_HANDLE emulator, const char* cart)
{
    ((PemsaEmulator*)emulator)->getCartridgeModule()->load(cart);
}

double SampleAudio(PEMSA_HANDLE emulator)
{
    return ((PemsaEmulator*)emulator)->getAudioModule()->sample();
}
