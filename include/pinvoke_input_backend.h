#ifndef PINVOKE_INPUT_BACKEND_H
#define PINVOKE_INPUT_BACKEND_H

#include "pemsa/input/pemsa_input_backend.hpp"
#include "pemsa/input/pemsa_input_module.hpp"

typedef bool (__cdecl *ManagedIsButtonDown)(int i, int p);
typedef bool (__cdecl *ManagedIsButtonPressed)(int i, int p);
typedef void (__cdecl *ManagedUpdate)();
typedef int (__cdecl *ManagedGetMouseX)();
typedef int (__cdecl *ManagedGetMouseY)();
typedef int (__cdecl *ManagedGetMouseMask)();
typedef const char *(__cdecl *ManagedReadKey)();
typedef bool (__cdecl *ManagedHasKey)();
typedef void (__cdecl *ManagedReset)();
typedef const char *(__cdecl *ManagedGetClipboardText)();

class PInvokeInputBackend : public PemsaInputBackend {
	public:
		PInvokeInputBackend(
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

		~PInvokeInputBackend();

		bool isButtonDown(int i, int p) override;
		bool isButtonPressed(int i, int p) override;
		void update() override;

		int getMouseX() override;
		int getMouseY() override;
		int getMouseMask() override;

		const char* readKey() override;
		bool hasKey() override;
		void reset() override;

		const char* getClipboardText() override;

	private:
		ManagedIsButtonDown managedIsButtonDown;
		ManagedIsButtonPressed managedIsButtonPressed;
		ManagedUpdate managedUpdate;
		ManagedGetMouseX managedGetMouseX;
		ManagedGetMouseY managedGetMouseY;
		ManagedGetMouseMask managedGetMouseMask;
		ManagedReadKey managedReadKey;
		ManagedHasKey managedHasKey;
		ManagedReset managedReset;
		ManagedGetClipboardText managedGetClipboardText;
};

#endif