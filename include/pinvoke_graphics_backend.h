#ifndef PINVOKE_GRAPHICS_BACKEND_H
#define PINVOKE_GRAPHICS_BACKEND_H

#include "pemsa/graphics/pemsa_graphics_backend.hpp"

typedef void (__cdecl *ManagedFlip)();
typedef void (__cdecl *ManagedCreateSurface)();
typedef int (__cdecl *ManagedGetFps)();

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