using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using testSharpSSH.Properties;

namespace testSharpSSH
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assembly assembly = Assembly.LoadFrom(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tamir.SharpSSH.dll"));
            TestShell sh = new TestShell();
            //sh.testConnectWithPWD();
            //sh.testConnectWithPPK();
            sh.Connect();
            sh.GetCurFileList();
            //sh.Unzip(Resources.SpecifiedFilePath);
            sh.DisConnect();
            
            Console.WriteLine("Done");
        }
    }
}
