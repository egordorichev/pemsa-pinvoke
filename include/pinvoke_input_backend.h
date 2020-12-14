#ifndef PINVOKE_INPUT_BACKEND_H
#define PINVOKE_INPUT_BACKEND_H

#include "pemsa_common.h"

#include "pemsa/input/pemsa_input_backend.hpp"
#include "pemsa/input/pemsa_input_module.hpp"

typedef bool (*ManagedIsButtonDown)(int i, int p) PEMSA_API;
typedef bool (*ManagedIsButtonPressed)(int i, int p) PEMSA_API;
typedef void (*ManagedUpdate)() PEMSA_API;
typedef int (*ManagedGetMouseX)() PEMSA_API;
typedef int (*ManagedGetMouseY)() PEMSA_API;
typedef int (*ManagedGetMouseMask)()PEMSA_API;
typedef const char *(*ManagedReadKey)()PEMSA_API;
typedef bool (*ManagedHasKey)()PEMSA_API;
typedef void (*ManagedReset)()PEMSA_API;
typedef const char *(*ManagedGetClipboardText)()PEMSA_API;

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