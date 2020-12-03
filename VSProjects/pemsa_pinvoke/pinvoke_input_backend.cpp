#include "pch.h"
#include "pinvoke_input_backend.h"

PInvokeInputBackend::PInvokeInputBackend()
{

}

PInvokeInputBackend::~PInvokeInputBackend()
{

}

bool PInvokeInputBackend::isButtonDown(int i, int p)
{
	return true;
}

bool PInvokeInputBackend::isButtonPressed(int i, int p)
{
	return true;
}

void PInvokeInputBackend::update()
{

}

int PInvokeInputBackend::getMouseX()
{
	return 0;
}

int PInvokeInputBackend::getMouseY()
{
	return 0;
}

int PInvokeInputBackend::getMouseMask()
{
	return 0;
}

const char* PInvokeInputBackend::readKey()
{
	return nullptr;
}

bool PInvokeInputBackend::hasKey()
{
	return true;
}

void PInvokeInputBackend::reset()
{

}