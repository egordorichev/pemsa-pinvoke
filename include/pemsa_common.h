#ifndef PEMSA_COMMON_H
#define PEMSA_COMMON_H

#ifdef __linux__
#define PEMSA_CALL_CONV __attribute__((cdecl))
#define DECLARE_CALLBACK(return_type, name, ...) \
	typedef return_type (*name)(__VA_ARGS__) PEMSA_CALL_CONV;
#else
#define PEMSA_CALL_CONV __cdecl
#define DECLARE_CALLBACK(return_type, name, ...) \
	typedef return_type (PEMSA_CALL_CONV *name)(__VA_ARGS__);
#endif


#endif