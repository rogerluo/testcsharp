using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

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

    }
}
