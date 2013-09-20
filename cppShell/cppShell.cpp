// cppShell.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#pragma comment (lib, "cppDLL.lib")

#include "../cppDLL/cppDLL.h"
#include <iostream>
#include <string>
#include <locale>
using namespace std;

std::wstring string2wstring(const std::string& in)
{
	std::wstring tmp(in.begin(), in.end());
	return tmp;
}

int _tmain(int argc, _TCHAR* argv[])
{
	//wcout<<"Add(1,1)="<<Add(1, 1)<<endl;
	//const char * psz = "Hello World";
	//const wchar_t * pwsz = L"你好 世界";
	//wstring wstr(pwsz);
	//if (!wcout.good()) 
	//{
	//	wcout<<L"bad wcout"<<endl;
	//	wcout.flush();
	//	wcout.clear();
	//}
	//SetA(psz);
	////SetW(pwsz);
	//if (!wcout.good()) 
	//{
	//	wcout<<L"bad wcout"<<endl;
	//	wcout.flush();
	//	wcout.clear();
	//}
	//wcout<<wstr<<endl;
	
	// ASCI: c4 e3 ba c3 20 ca c0 bd e7
	const char * psz = "你好 世界";			
	// UCS2 little endian: 60 4f 7d 59 20 00 16 4e 4c 75
	const wchar_t * pwsz = L"你好 世界";	

	wcout<<"[Locale:"<<string2wstring(wcout.getloc().name())<<"]"<<endl;
	
	printf("printf(%%s):%s\n", psz);
	printf("printf(%%ls):%s\n", pwsz);
	cout<<"cout:"<<psz<<endl;

	wprintf(L"wprintf(%%s):%s\n", pwsz);
	wprintf(L"wprintf(%%ls):%ls\n", pwsz);
	wcout<<L"wcout:"<<pwsz<<endl;
	
	cout.clear(); cout.flush();
	wcout.clear(); wcout.flush(); // "<<endl" trigger the flush function

	
	wcout.imbue(locale("chs"));
	setlocale(LC_CTYPE, "chs");
	wcout<<"[Locale:"<<string2wstring(wcout.getloc().name())<<"]"<<endl;
	printf("printf(%%s):%s\n", psz);
	printf("printf(%%ls):%s\n", pwsz);
	cout<<"cout:"<<psz<<endl;

	wprintf(L"wprintf(%%s):%s\n", pwsz);
	wprintf(L"wprintf(%%ls):%ls\n", pwsz);
	wcout<<L"wcout:"<<pwsz<<endl;
	cout.clear(); cout.flush();
	wcout.clear(); wcout.flush(); // "<<endl" trigger the flush function
	
	
	wcout.imbue(locale("cht"));
	setlocale(LC_CTYPE, "cht");
	wcout<<"[Locale:"<<string2wstring(wcout.getloc().name())<<"]"<<endl;
	printf("printf(%%s):%s\n", psz);
	printf("printf(%%ls):%s\n", pwsz);
	cout<<"cout:"<<psz<<endl;

	wprintf(L"wprintf(%%s):%s\n", pwsz);
	wprintf(L"wprintf(%%ls):%ls\n", pwsz);
	wcout<<L"wcout:"<<pwsz<<endl;
	cout.clear(); cout.flush();
	wcout.clear(); wcout.flush(); // "<<endl" trigger the flush function

	return 0;
}

