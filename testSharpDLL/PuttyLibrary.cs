using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace testSharpDLL
{
    public class PuttyLibrary
    {
        static public void Run()
        {
            _bash = new Process();

            _bash.StartInfo.FileName = @"c:\open\putty\plink";
            _bash.StartInfo.Arguments = "-C -l reutadmin -i \"c:\\open\\putty\\putty_id_rsa.ppk\" 10.35.21.200 rm -r /cygdrive/d/temp1";
            Execute();

            _bash.StartInfo.FileName = "cmd.exe";
            _bash.StartInfo.Arguments = "/C c:\\open\\putty\\plink -C -l reutadmin -i \"c:\\open\\putty\\putty_id_rsa.ppk\" 10.35.21.200 rm -r /cygdrive/d/temp1 > c:\\temp\\out.txt 2>c:\\temp\\err.txt";
            Execute();
        }

        static void Execute()
        {
            _bash.StartInfo.UseShellExecute = false;
            _bash.StartInfo.RedirectStandardError = true;
            _bash.StartInfo.RedirectStandardOutput = true;

            _bash.Start();
            _bash.WaitForExit();

            _out = _bash.StandardOutput;
            _outmsg = _out.ReadToEnd();
            _err = _bash.StandardError;
            _errmsg = _err.ReadToEnd();

            _bash.StartInfo.RedirectStandardOutput = false;
            _bash.StartInfo.RedirectStandardError = false;
            Console.WriteLine("{0} {1}", _bash.StartInfo.FileName, _bash.StartInfo.Arguments);
            Console.WriteLine(string.Format("Output:{0}\r\nError:{1}", _outmsg, _errmsg));
        }

        static Process _bash = null;
        static StreamReader _out = null;
        static string _outmsg = null;
        static StreamReader _err = null;
        static string _errmsg = null;
    }
}
