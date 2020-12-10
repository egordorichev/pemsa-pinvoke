#include "pinvoke_input_backend.h"

PInvokeInputBackend::PInvokeInputBackend(
	ManagedIsButtonDown isButtonDown,
	ManagedIsButtonPressed isButtonPressed,
	ManagedUpdate update,
	ManagedGetMouseX getMouseX,
	ManagedGetMouseY getMouseY,
	ManagedGetMouseMask getMouseMask,
	ManagedReadKey readKey,
	ManagedHasKey hasKey,
	ManagedReset reset,
	ManagedGetClipboardText getClipboardText) :
	managedIsButtonDown(isButtonDown),
	managedIsButtonPressed(isButtonPressed),
	managedUpdate(update),
	managedGetMouseX(getMouseX),
	managedGetMouseY(getMouseY),
	managedGetMouseMask(getMouseMask),
	managedReadKey(readKey),
	managedHasKey(hasKey),
	managedReset(reset),
	managedGetClipboardText(getClipboardText)
{

}

PInvokeInputBackend::~PInvokeInputBackend()
{

}

bool PInvokeInputBackend::isButtonDown(int i, int p)
{
	return managedIsButtonDown ? managedIsButtonDown(i, p) : false;
}

bool PInvokeInputBackend::isButtonPressed(int i, int p)
{
	return managedIsButtonPressed ? managedIsButtonPressed(i, p) : false;
}

void PInvokeInputBackend::update()
{
	if (managedUpdate)
	{
		managedUpdate();
	}
}

int PInvokeInputBackend::getMouseX()
{
	return managedGetMouseX ? managedGetMouseX() : -1;
}

int PInvokeInputBackend::getMouseY()
{
	return managedGetMouseY ? managedGetMouseY() : -1;
}

int PInvokeInputBackend::getMouseMask()
{
	return managedGetMouseMask ? managedGetMouseMask() : 0;
}

const char* PInvokeInputBackend::readKey()
{
	return managedReadKey ? managedReadKey() : nullptr;
}

bool PInvokeInputBackend::hasKey()
{
	return managedHasKey ? managedHasKey() : false;
}

void PInvokeInputBackend::reset()
{
	if (managedReset)
	{
		managedReset();
	}
}

const char* PInvokeInputBackend::getClipboardText()
{
	return managedGetClipboardText ? managedGetClipboardText() : nullptr;
}