http://msdn.microsoft.com/en-us/library/e8w969hb.aspx
http://msdn.microsoft.com/en-us/library/ac7ay120.aspx
http://msdn.microsoft.com/en-us/magazine/cc164123.aspx#S5

printf/cout and wprintf/wcout for chinese character
printf/cout could display chinese character directly using the default locale

1.	����cout��wcout��clear��Ա������Ϊ���������״̬��ʹ���������������
	�С�
2.	ʹ�á�cout<<endl����wcout<<endl��ʱ��������ʹ����ı����У����һ���
	ִ��flush��Ա�������ύ�������е����ݡ�ʹ��cout��wcout������ı�����
	������ͻ��

vs�����ĵı�����char��wchar_t֮��ı���ֱ�����
	// ASCI: c4 e3 ba c3 20 ca c0 bd e7
	const char * psz = "��� ����";			
	// UCS2 little endian: 60 4f 7d 59 20 00 16 4e 4c 75
	const wchar_t * pwsz = L"��� ����";

%ls��%s
%ls��ζ�Ž���Ӧ�Ĳ����ᱻ�������ڿ��ַ����ַ���(wide chraracter string )������
%s��ζ�Ŷ�Ӧ�Ĳ����ᱻ������ͨ�ַ���(multi-byte string)������
��Ҫ��Ϊ%sֻ����printf����%lsֻ����wprintf ��ʵ���ϣ�(printf, wprintf) ��
(%s,%ls)������Ԫ��֮�����໥�����ġ�

Source Insight
ALT+F12ʹsource insight����ȿ�
ALT+T��ʾDocument Option���ڣ�ѡ��sreen fonts�޸��������ͻ��ߴ�С


Foobar2000
֧��ape/cue��ʽ�ļ�����Ҫ�������ز��ac3����ȥ�ٷ������վ
http://www.foobar2000.org/components�����ض�Ӧ�Ĳ��
Monkey's Audio decoding support
��ѹ������foo_input_monkey.dll��������װĿ¼�µ�components�ļ�����

cue�ļ�����ʧ��
ʹ���ı���������cue�ļ������FILE��ǩ�е��ļ����Ƿ��Ӧ��ape���ļ���
���£�
FILE "�ɽ�������98�����ԭ����.ape" WAVE
