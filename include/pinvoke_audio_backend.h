#ifndef PINVOKE_AUDIO_BACKEND_H
#define PINVOKE_AUDIO_BACKEND_H

#include "pemsa/audio/pemsa_audio_backend.hpp"

class PInvokeAudioBackend : public PemsaAudioBackend {
	public:
		~PInvokeAudioBackend();
		void setupBuffer() override;
};

#endif