#ifndef PINVOKE_GRAPHICS_BACKEND_H
#define PINVOKE_GRAPHICS_BACKEND_H

#include "pemsa_common.h"
#include "pemsa/graphics/pemsa_graphics_backend.hpp"

DECLARE_CALLBACK(void, ManagedFlip, void);
DECLARE_CALLBACK(void, ManagedCreateSurface, void);
DECLARE_CALLBACK(int, ManagedGetFps, void);
DECLARE_CALLBACK(int, ManagedRender, void);

class PInvokeGraphicsBackend : public PemsaGraphicsBackend {
	public:
		PInvokeGraphicsBackend(ManagedFlip managedFlip, ManagedCreateSurface managedCreateSurface, ManagedGetFps managedGetFps, ManagedRender managedRender);
		~PInvokeGraphicsBackend();

		void createSurface() override;
		void flip() override;
		int getFps() override;
		void render() override;

	private:
		ManagedFlip managedFlip;
		ManagedCreateSurface managedCreateSurface;
		ManagedGetFps managedGetFps;
		ManagedRender managedRender;
};

#endif