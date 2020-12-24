#include "pemsa/pemsa_emulator.hpp"
#include "pinvoke_graphics_backend.h"


PInvokeGraphicsBackend::PInvokeGraphicsBackend(ManagedFlip mFlip, ManagedCreateSurface mCreateSurface, ManagedGetFps mGetFps, ManagedRender mRender) : 
	managedFlip(mFlip), 
	managedCreateSurface(mCreateSurface), 
	managedGetFps(mGetFps),
	managedRender(mRender) {

}

int PInvokeGraphicsBackend::getFps() {
	return this->managedGetFps();
}

void PInvokeGraphicsBackend::createSurface() {
	this->managedCreateSurface();
}

void PInvokeGraphicsBackend::flip() {
	this->managedFlip();
}

void PInvokeGraphicsBackend::render() {
	this->managedRender();
}

PInvokeGraphicsBackend::~PInvokeGraphicsBackend() {

}