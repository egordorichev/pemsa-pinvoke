#pragma once

#include "pemsa/graphics/pemsa_graphics_backend.hpp"

typedef void (*ManagedFlip)();
typedef void (*ManagedCreateSurface)();
typedef int (*ManagedGetFps)();

class PInvokeGraphicsBackend : public PemsaGraphicsBackend {
public:
	PInvokeGraphicsBackend(ManagedFlip managedFlip, ManagedCreateSurface managedCreateSurface, ManagedGetFps managedGetFps);
	~PInvokeGraphicsBackend();

	void createSurface() override;
	void flip() override;
	int getFps() override;

private:
	ManagedFlip managedFlip;
	ManagedCreateSurface managedCreateSurface;
	ManagedGetFps managedGetFps;
};