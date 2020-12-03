#pragma once

#include "pemsa/input/pemsa_input_backend.hpp"
#include "pemsa/input/pemsa_input_module.hpp"

class PInvokeInputBackend : public PemsaInputBackend {
public:
	PInvokeInputBackend();
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
};
