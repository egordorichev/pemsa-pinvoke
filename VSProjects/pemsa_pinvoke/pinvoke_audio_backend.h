#pragma once

#include "pemsa/audio/pemsa_audio_backend.hpp"

class PInvokeAudioBackend : public PemsaAudioBackend {
public:
	~PInvokeAudioBackend();

	void setupBuffer() override;
};