// cppDLL.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"


#include "cppDLL.h"
#include <cstdio>
#include <locale>
#include <iostream>
using namespace std;

int Add(int lhs, int rhs)
{
	return lhs + rhs;
}

void SetA(const char * psz)
{
	printf("%s Recieve: %s\n", __FUNCTION__, psz);
}

void SetW(const wchar_t * pwsz)
{

	wprintf(L"%ls Recieve(W): %ls\n", __FUNCTIONW__, pwsz);
	//locale ori = wcout.getloc();
	//wcout.flush(); wcout.clear();
	//wcout.imbue(locale(""));
	//wcout<<__FUNCTIONW__<<" Recieve(W): "<<pwsz<<endl;	
	//wcout.flush(); wcout.clear();
	//wcout.imbue(ori);
}