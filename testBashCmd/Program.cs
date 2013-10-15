using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using testBashCmd.Properties;
using testSharpDLL;

namespace testBashCmd
{
    class Program
    {
        static void TestPuttyToolsWithPWD()
        {
            try
            {
                using (testPuttyTools putty = new testPuttyTools(){
                        Host = Resources.RmtHost,
                        HostPort = Resources.RmtHostPort,
                        Username = Resources.RmtUsername,
                        Password = Resources.RmtPassword,
                        ExternalDir = Resources.ExternalDirectory,
                    })
                {
                    Stopwatch sw1 = new Stopwatch();
                    sw1.Start();

                    string srcname = Resources.ServiceName;

                    if (!putty.NetStartService(srcname))
                    {
                        Console.WriteLine("Failed at NetStartService({0}): {1}.", srcname, putty.LastError());
                        return;
                    }

                    //if (!putty.NetStopService(srcname))
                    //{
                    //    Console.WriteLine("Failed at NetStopService({0}): {1}.", srcname, putty.LastError());
                    //    return;
                    //}

                    sw1.Stop();
                    Console.WriteLine("using {0} miniseconds.", sw1.ElapsedMilliseconds);

                    Console.WriteLine("Done!");
                }
            }
            catch (Exception argex)
            {
                Console.WriteLine(argex.Message);
            }
        }

        static void TestPuttyToolsWithPPK()
        {
            try
            {
                using (testPuttyTools putty = new testPuttyTools()
                {
                    Host = Resources.RmtHost,
                    HostPort = Resources.RmtHostPort,
                    Username = Resources.RmtUsername,
                    UsePWD = false,
                    PPK = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                            Resources.PrivateKey),
                    ExternalDir = Resources.ExternalDirectory,
                })
                {
                    Stopwatch sw1 = new Stopwatch();
                    sw1.Start();

                    string srcname = "smf";//Resources.ServiceName;

                    if (!putty.NetStartService(srcname))
                    {
                        Console.WriteLine("Failed at NetStartService({0}): {1}.", srcname, putty.LastError());
                        return;
                    }

                    //if (!putty.NetStopService(srcname))
                    //{
                    //    Console.WriteLine("Failed at NetStopService({0}): {1}.", srcname, putty.LastError());
                    //    return;
                    //}

                    sw1.Stop();
                    Console.WriteLine("using {0} miniseconds.", sw1.ElapsedMilliseconds);

                    Console.WriteLine("Done!");
                }
            }
            catch (Exception argex)
            {
                Console.WriteLine(argex.Message);
            }
        }

        static void Main(string[] args)
        {
            //TestPuttyToolsWithPWD();
            //TestPuttyToolsWithPPK();
            //testCMD.InvodeSimpleCMD();
            //testCMD.GetRemoteScriptResult();
            //testCMD.GetRemoteScriptResult();
            PuttyLibrary.Run();
        }
    }
}
