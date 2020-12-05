// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"

#include "pemsa/pemsa_emulator.hpp"
#include "pemsa_pinvoke.h"

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

bool running = true;

PEMSA_HANDLE* AllocateEmulator(ManagedFlip flip,
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
    return (PEMSA_HANDLE*)(new PemsaEmulator(
        new PInvokeGraphicsBackend(flip, createSurface, getfPS), 
        new PInvokeAudioBackend(), 
        new PInvokeInputBackend(isButtonDown, isButtonPressed, update, getMouseX, getMouseY, getMouseMask, readKey, hasKey, reset, getClipboardText), 
        &running));
}

void* GetRam(PEMSA_HANDLE* emulator)
{
    return ((PemsaEmulator*)emulator)->getMemoryModule()->ram;
}

uint8_t GetScreenColor(PEMSA_HANDLE* emulator, int i)
{
    return ((PemsaEmulator*)emulator)->getDrawStateModule()->getScreenColor(i);
}

void UpdateEmulator(PEMSA_HANDLE* emulator, double delta)
{
    ((PemsaEmulator*)emulator)->update(delta);
}

void LoadCart(PEMSA_HANDLE* emulator, const char* cart)
{
    ((PemsaEmulator*)emulator)->getCartridgeModule()->load(cart);
}