http://msdn.microsoft.com/en-us/library/e8w969hb.aspx
http://msdn.microsoft.com/en-us/library/ac7ay120.aspx
http://msdn.microsoft.com/en-us/magazine/cc164123.aspx#S5

printf/cout and wprintf/wcout for chinese character
printf/cout could display chinese character directly using the default locale

1.	调用cout、wcout的clear成员函数是为了清除错误状态，使后续输出能正常运
	行。
2.	使用“cout<<endl”或“wcout<<endl”时，不仅会使输出文本换行，而且还会
	执行flush成员函数，提交缓冲区中的数据。使得cout、wcout的输出文本不会
	发生冲突。

vs中中文的编码在char与wchar_t之间的编码分别如下
	// ASCI: c4 e3 ba c3 20 ca c0 bd e7
	const char * psz = "你好 世界";			
	// UCS2 little endian: 60 4f 7d 59 20 00 16 4e 4c 75
	const wchar_t * pwsz = L"你好 世界";

%ls与%s
%ls意味着将对应的参数会被当作基于宽字符的字符串(wide chraracter string )看待，
%s意味着对应的参数会被当作普通字符串(multi-byte string)看待。
不要以为%s只用于printf，而%ls只用于wprintf 。实际上，(printf, wprintf) 和
(%s,%ls)这两个元组之间是相互独立的。

Source Insight
ALT+F12使source insight字体等宽
ALT+T显示Document Option窗口，选择sreen fonts修改字体类型或者大小


Foobar2000
支持ape/cue格式文件，需要单独下载插件ac3，进去官方插件网站
http://www.foobar2000.org/components，下载对应的插件
Monkey's Audio decoding support
解压出来的foo_input_monkey.dll拷贝到安装目录下的components文件夹下

cue文件解析失败
使用文本解析器打开cue文件，检查FILE标签中的文件名是否对应的ape的文件名
如下：
FILE "仙剑奇侠传98柔情版原声碟.ape" WAVE
