#ifndef PEMSA_COMMON_H
#define PEMSA_COMMON_H

#ifdef __linux__
#define PEMSA_API __attribute__((cdecl))
#else
#define PEMSA_API __cdecl
#endif

#endif