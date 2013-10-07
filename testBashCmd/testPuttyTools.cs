using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using testBashCmd.Properties;

namespace testBashCmd
{
    class testPuttyTools : IDisposable
    {
        enum EPSCPToolType
        { 
            PSFTP,
            PLINK,
            PSCP,
        }

        private string BIN_PATH_PSFTP;
        private string BIN_PATH_PLINK;
        private string BIN_PATH_PSCP;
        private string BIN_PATH_7Z;

        private string _host;

        public string Host
        {
            get { return _host; }
            set { _host = value;
            ResetCmdPrefix();
            }
        }

        private string _hostPort;

        public string HostPort
        {
            get { return _hostPort; }
            set { _hostPort = value; }
        }
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value;
            ResetCmdPrefix();
            }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value;
            ResetCmdPrefix();
            }
        }

        private string _ppk;

        public string PPK
        {
            get { return _ppk; }
            set
            {
                _ppk = value;
                ResetCmdPrefix();
            }
        }

        private bool _usdPwd = true;

        public bool UsePWD
        { 
            get { return _usdPwd; }
            set { _usdPwd = value;
            ResetCmdPrefix();
            }
        }

        private string _externalDir;

        public string ExternalDir
        {
            get { return _externalDir; }
            set { 
                _externalDir = value;
                BIN_PATH_PSFTP = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _externalDir, "PSFTP.EXE");
                BIN_PATH_PLINK = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _externalDir, "PLINK.EXE");
                BIN_PATH_PSCP = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _externalDir, "PSCP.EXE");
                BIN_PATH_7Z = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _externalDir, "7z.EXE");

                if (!System.IO.File.Exists(BIN_PATH_PSFTP) ||
                !System.IO.File.Exists(BIN_PATH_PLINK) ||
                !System.IO.File.Exists(BIN_PATH_PSCP) ||
                !System.IO.File.Exists(BIN_PATH_7Z))
                    throw new ArgumentException();
            }
        }
        private string _cmdPrefix;

        private void ResetCmdPrefix()
        {
            if (!_usdPwd && System.IO.File.Exists(_ppk))
                _cmdPrefix = string.Format("-l {0} -i {1} {2}", _username, _ppk, _host);
            else if (!string.IsNullOrEmpty(_password))
                _cmdPrefix = string.Format("-l {0} -pw {1} {2}", _username, _password, _host);
            else
                _cmdPrefix = string.Format("-l {0} {1}", _username, _host);
        }

        private string _errmsg;

        public string LastError()
        {
            return _errmsg;
        }

        private Process _bash = new Process();

        public testPuttyTools()
        {
        }
        
        public bool NetStartService(string srvname)
        {
            return WindowsServiceOperation(srvname, true);
        }

        public bool NetStopService(string srvname)
        {
            return WindowsServiceOperation(srvname, false);
        }

        public bool SendFile(string src, string dst)
        {
            if (!File.Exists(src))
            {
                _errmsg = "Not Found " + src;
                return false;
            }

            string args = GenerateCmdArguments(EPSCPToolType.PSFTP, src, dst);

            if (string.IsNullOrEmpty(args))
            {
                _errmsg = Resources.ErrorGenerateCommand;
                return false;
            }

            Console.WriteLine(args);
            _bash.StartInfo.FileName = BIN_PATH_PSFTP;
            _bash.StartInfo.Arguments = args;
            _bash.Start();
            _bash.WaitForExit();

            return true;
        } 

        public bool Send(byte[] src, string dst)
        {
            return true;
        }

        private bool WindowsServiceOperation(string srvname, bool bToStart)
        {
            //string args = bToStart ? GenerateCmdArguments(EPSCPToolType.PLINK, string.Format("net start {0}", srvname)) :
            //                        GenerateCmdArguments(EPSCPToolType.PLINK, string.Format("net stop {0}", srvname));
            string args = GenerateCmdArguments(EPSCPToolType.PLINK, "ls");
            if (string.IsNullOrEmpty(args))
            {
                _errmsg = Resources.ErrorGenerateCommand;
                return false;
            }

            _bash.StartInfo.FileName = BIN_PATH_PLINK;
            _bash.StartInfo.Arguments = args;
            _bash.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            _bash.StartInfo.UseShellExecute = false;
            _bash.StartInfo.RedirectStandardOutput = true;

            Console.WriteLine(args);
            _bash.Start();

            StreamReader sr = _bash.StandardOutput;
            string line = sr.ReadLine();
            _bash.StartInfo.RedirectStandardOutput = false;


            while (!string.IsNullOrEmpty(line))
            {
                line = sr.ReadLine();
            }
            _bash.WaitForExit();
            return true;
        }


        private string GenerateCmdArguments(EPSCPToolType type, params string[] args)
        {
            StringBuilder tmp = new StringBuilder();
            switch (type)
            { 
                case EPSCPToolType.PLINK:
                    tmp.Append(string.Format(" -C {0}", _cmdPrefix));
                    foreach (string arg in args)
                    {
                        tmp.Append(' ');
                        tmp.Append(arg);
                    }
                   
                    break;
                case EPSCPToolType.PSFTP:
                    break;
                case EPSCPToolType.PSCP:
                    break;
                default:
                    break;
            }
            return tmp.ToString();
        }

        public void Dispose()
        {
            if (_bash != null)
                _bash.Dispose();
        }

    }
}
