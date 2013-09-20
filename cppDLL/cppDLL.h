#ifndef CPPDLL_H_123
#define CPPDLL_H_123

#if defined _MSC_VER
#	if defined CPPDLL_EXPORTS
#		define CPPDLL_API __declspec( dllexport )
#	else
#		define CPPDLL_API 
#	endif
#endif

#if defined __cplusplus
extern "C" {
#endif

// all output function
	CPPDLL_API int Add(int lhs, int rhs);
	CPPDLL_API void SetA(const char * psz);
	CPPDLL_API void SetW(const wchar_t * pwsz); 
	// error, csdel calling convention, not support overload

#if defined __cplusplus
}
#endif

#endif