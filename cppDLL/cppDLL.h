#ifndef CPPDLL_H_123
#define CPPDLL_H_123

#if defined _MSC_VER
#	if defined CPPDLL_EXPORTS
#		define CPPDLL_API __declspec( dllexport )
#	endif
#endif

#if defined __cplusplus
extern "C" {
#endif

// all output function
	int CPPDLL_API Add(int lhs, int rhs);

#if defined __cplusplus
}
#endif

#endif