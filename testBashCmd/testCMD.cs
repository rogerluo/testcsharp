using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace testBashCmd
{
    class testCMD
    {
        static public void InvodeSimpleCMD()
        {
            Process _bash = new Process();
            _bash.StartInfo.FileName = "notepad";
            _bash.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            _bash.Start();
            _bash.WaitForExit();
        }

        static public void GetRemoteScriptResult()
        {
            _bash.StartInfo.FileName = @"C:\open\putty\plink.exe";
            _bash.StartInfo.Arguments = "-C -l reutadmin -i C:/open/putty/putty_id_rsa.ppk 10.35.21.200 -P 22 /cygdrive/d/thomsonreuters/vah/data/restoretemp/remote.bat";
            _bash.StartInfo.UseShellExecute = false;
            //_bash.StartInfo.CreateNoWindow = true;
            _bash.StartInfo.RedirectStandardOutput = true;
            //_bash.StartInfo.RedirectStandardError = true;
            
            _bash.Start();
            _bash.WaitForExit();

            _out = _bash.StandardOutput;
            _err = _bash.StandardError;
            string _outmsg = _out.ReadToEnd();
            string _errmsg = _err.ReadToEnd();
            
            _bash.StartInfo.RedirectStandardOutput = false;
            _bash.StartInfo.RedirectStandardError = false;

            Console.WriteLine("Output:"+_outmsg);
            Console.WriteLine("Error:" +_errmsg);
        }
        static Process _bash = new Process();
        static StreamReader _out = null;
        static StreamReader _err = null;
    }
}
