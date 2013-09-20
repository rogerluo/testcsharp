using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace tstInvokeDLL
{
    class InvokeDLL
    {
        /// <summary>
        /// test dllimport attribute usage in c#
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        // function 
        [DllImport("cppDLL")]
        public static extern int Add(int lhs, int rhs);
        [DllImport("cppDLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add_OtherName1(int lhs, int rhs);
        [DllImport("cppDLL", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Add")]
        public static extern int Add_OtherName2(int lhs, int rhs);
        [DllImport("cppDLL", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetA", CharSet = CharSet.Ansi)]
        public static extern int SetAsciString(string str);
        [DllImport("cppDLL", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetA", CharSet = CharSet.Unicode)]
        public static extern int SetUnicodeString(string str);
        [DllImport("cppDLL", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetW", CharSet = CharSet.Unicode, BestFitMapping=true)]
        public static extern int SetUnicodeString2(string str); 


        public void TestDllImportAttributeUsage()
        {
            try
            {
                Console.WriteLine("Add(1, 1)={0}", Add(1, 1));
                // Failed to access Add function in dll, it should need the entrypoint
                //Console.WriteLine("Add_OtherName1(1,1)={0}", Add_OtherName1(1, 1)); // error
                Console.WriteLine("Add2(1, 1)={0}", Add_OtherName2(1, 1));
                string str = "Hello World";
                string str2 = "你好 世界";
                SetAsciString(str);
                SetUnicodeString(str); // only recieved the first character H
                //SetUnicodeString2(str);
                SetUnicodeString2(str2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
