#ifndef PINVOKE_GRAPHICS_BACKEND_H
#define PINVOKE_GRAPHICS_BACKEND_H

#include "pemsa_common.h"
#include "pemsa/graphics/pemsa_graphics_backend.hpp"

typedef void (*ManagedFlip)() PEMSA_API;
typedef void (*ManagedCreateSurface)() PEMSA_API;
typedef int (*ManagedGetFps)() PEMSA_API;

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

#endif