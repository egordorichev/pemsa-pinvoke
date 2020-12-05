#pragma once

#include "pemsa/input/pemsa_input_backend.hpp"
#include "pemsa/input/pemsa_input_module.hpp"

typedef bool (*ManagedIsButtonDown)(int i, int p);
typedef bool (*ManagedIsButtonPressed)(int i, int p);
typedef void (*ManagedUpdate)();
typedef int (*ManagedGetMouseX)();
typedef int (*ManagedGetMouseY)();
typedef int (*ManagedGetMouseMask)();
typedef const char * (*ManagedReadKey)();
typedef bool (*ManagedHasKey)();
typedef void (*ManagedReset)();
typedef const char* (*ManagedGetClipboardText)();

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
		ManagedGetClipboardText getClipboardText);
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
