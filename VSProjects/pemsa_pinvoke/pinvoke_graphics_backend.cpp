#include "pch.h"
#include "pemsa/pemsa_emulator.hpp"
#include "pinvoke_graphics_backend.h"


PInvokeGraphicsBackend::PInvokeGraphicsBackend(ManagedFlip mFlip, ManagedCreateSurface mCreateSurface, ManagedGetFps mGetFps) :
	managedFlip(mFlip), managedCreateSurface(mCreateSurface), managedGetFps(mGetFps)
{

}

int PInvokeGraphicsBackend::getFps()
{
	return this->managedGetFps();
}

void PInvokeGraphicsBackend::createSurface()
{
	this->managedCreateSurface();
}

void PInvokeGraphicsBackend::flip()
{
	this->managedFlip();
}

PInvokeGraphicsBackend::~PInvokeGraphicsBackend()
{

}