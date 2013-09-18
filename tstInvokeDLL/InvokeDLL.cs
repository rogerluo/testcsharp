using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace tstInvokeDLL
{
    class InvokeDLL
    {
        [DllImport("cppDLL")]
        public static extern int Add(int lhs, int rhs);

        static public void InvokeCPPDLL()
        {
            Console.WriteLine("Add(1, 1)={0}", Add(1, 1));
        }
    }
}
