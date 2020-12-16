#ifndef PINVOKE_INPUT_BACKEND_H
#define PINVOKE_INPUT_BACKEND_H

#include "pemsa_common.h"

#include "pemsa/input/pemsa_input_backend.hpp"
#include "pemsa/input/pemsa_input_module.hpp"

DECLARE_CALLBACK(bool, ManagedIsButtonDown, int i, int p);
DECLARE_CALLBACK(bool, ManagedIsButtonPressed, int i, int p);
DECLARE_CALLBACK(void, ManagedUpdate, void);
DECLARE_CALLBACK(int, ManagedGetMouseX, void);
DECLARE_CALLBACK(int, ManagedGetMouseY, void);
DECLARE_CALLBACK(int, ManagedGetMouseMask, void);
DECLARE_CALLBACK(const char*, ManagedReadKey, void);
DECLARE_CALLBACK(bool, ManagedHasKey, void);
DECLARE_CALLBACK(void, ManagedReset, void);
DECLARE_CALLBACK(const char*, ManagedGetClipboardText, void);

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