using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Tamir.SharpSsh;
using Tamir.SharpSsh.jsch;
using Tamir.SharpSsh.java.io;
using testSharpSSH.Properties;

namespace testSharpSSH
{
    class TestShell : IDisposable
    {
       
        public void testConnectWithPWD()
        {
            InitVAHInfo();
            try
            {
                JSch jsch = new JSch();
                Session ssn = jsch.getSession(_usr, _hip, _hp);
                System.Collections.Hashtable hashConfig = new Hashtable();
                hashConfig.Add("StrictHostKeyChecking", "No");
                ssn.setConfig(hashConfig);
                ssn.setPassword(_pwd);
                ssn.connect();
                if (ssn.isConnected())
                {
                    Console.WriteLine("Log Successfully.");
                    ssn.disconnect();
                }
                else
                    Console.WriteLine("Log failed.");
            }
            catch (Tamir.SharpSsh.jsch.JSchException jschex)
            {
                Console.WriteLine(jschex.Message);
            }
            catch (Exception anyex)
            {
                Console.WriteLine(anyex.Message);
            }

            Console.WriteLine("Bye");
        }

        public void testConnectWithPPK()
        {
            InitVAHInfo();
            try
            {
                JSch jsch = new JSch();
                Session ssn = jsch.getSession(_usr, _hip, _hp);
                System.Collections.Hashtable hashConfig = new Hashtable();
                hashConfig.Add("StrictHostKeyChecking", "No");
                ssn.setConfig(hashConfig);
                jsch.addIdentity(_ppk);
                ssn.connect();
                if (ssn.isConnected())
                {
                    Console.WriteLine("Log Successfully.");
                    ssn.disconnect();
                }
                else
                    Console.WriteLine("Log failed.");
            }
            catch (Tamir.SharpSsh.jsch.JSchException jschex)
            {
                Console.WriteLine(jschex.Message);
            }
            catch (Exception anyex)
            {
                Console.WriteLine(anyex.Message);
            }

            Console.WriteLine("Bye");
        }

        public void Connect()
        {
            InitVAHInfo();
            try
            {
                JSch jsch = new JSch();
                _ssn = jsch.getSession(_usr, _hip, _hp);
                System.Collections.Hashtable hashConfig = new Hashtable();
                hashConfig.Add("StrictHostKeyChecking", "No");
                _ssn.setConfig(hashConfig);
                jsch.addIdentity(_ppk);
                _ssn.connect();
                if (_ssn.isConnected())
                {
                    Console.WriteLine("Log Successfully.");
                }
                else
                {
                    Console.WriteLine("Log failed.");
                }
            }
            catch (Tamir.SharpSsh.jsch.JSchException jschex)
            {
                Console.WriteLine(jschex.Message);
            }
            catch (Exception anyex)
            {
                Console.WriteLine(anyex.Message);
            }

            
        }

        public void GetCurFileList()
        {
            if (!_ssn.isConnected()) return;
            try
            {
                    Channel chnnl = _ssn.openChannel("sftp");
                    chnnl.connect();
                    if (chnnl.isConnected())
                    {
                        Console.WriteLine("sftp channel opened.");
                        if (!string.IsNullOrEmpty(Resources.InitListDirectory))
                        {
                            _initdir = (string)Resources.InitListDirectory.Replace(":", "").Replace("\\", "/");
                            //if (!_initdir.Contains("cygdrive"))
                            //    _initdir = "/cygdrive" + _initdir;
                            ChannelSftp sftp = (ChannelSftp)chnnl;
                            try
                            {
                                Console.WriteLine("List {0}:", Resources.InitListDirectory);
                                ArrayList lst = sftp.ls(_initdir);
                                foreach (ChannelSftp.LsEntry fstat in lst)
                                {
                                    Console.WriteLine("{0} {1:D5} {2:D5} {3} {4}",
                                        fstat.getAttrs().getPermissionsString(),
                                        fstat.getAttrs().getUId(),
                                        fstat.getAttrs().getGId(),
                                        Tamir.SharpSsh.jsch.Util.Time_T2DateTime((uint)fstat.getAttrs().getMTime()).ToString("yyyy-MM-dd HH:mm:ss"),
                                        fstat.getFilename());
                                }
                            }
                            catch (Tamir.SharpSsh.jsch.SftpException sftpex)
                            {
                                Console.WriteLine(sftpex.message);
                            }
                            catch (Exception anyex)
                            {
                                Console.WriteLine(anyex.Message);
                            }
                        }
                        chnnl.disconnect();
                    }
            }
            catch (Tamir.SharpSsh.jsch.JSchException jschex)
            {
                Console.WriteLine(jschex.Message);
            }
            catch (Exception anyex)
            {
                Console.WriteLine(anyex.Message);
            }

            Console.WriteLine("Bye");
        }

        public bool Unzip(string fpath)
        {
            if (!fpath.ToLower().EndsWith(".zip"))
            {
                Console.WriteLine("Invalid file type: {0}", fpath);
                return false;
            }
            fpath = Util.ToRemotePath(fpath);
            
            SftpATTRS attr = GetSpecifiedFile(fpath);
            if (attr == null)
            {
                Console.WriteLine("Invalid file path: {0}", fpath);
                return false;
            }
            
            

            return true;
        }

        private SftpATTRS GetSpecifiedFile(string fpath)
        {
            if (!_ssn.isConnected()) return null;
            SftpATTRS attr = null;
            ChannelSftp sftp = null;
            try
            {
                sftp = (ChannelSftp)_ssn.openChannel("sftp");
                sftp.connect();
                if (sftp.isConnected())
                {
                    attr = sftp.lstat(Util.ToRemotePath(fpath));
                }
            }
            catch (Tamir.SharpSsh.jsch.SftpException sftpex)
            {
                Console.WriteLine(sftpex.Message);
            }
            catch (Tamir.SharpSsh.jsch.JSchException jschex)
            {
                Console.WriteLine(jschex.Message);
            }
            catch (Exception anyex)
            {
                Console.WriteLine(anyex.Message);
            }
            finally
            {
                if (sftp.isConnected())
                    sftp.disconnect();
            }

            return attr;
        }

        private void InitVAHInfo(bool bInPPK = false)
        {
            _hip = Resources.HostIP;
            _hp = Int32.Parse(Resources.HostPort);
            _usr = "reutadmin";
            _bInPPK = bInPPK;
            _pwd = "Tin.netSA";
            _ppk = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, 
                @"config\id_rsa");
        }

        private string  _hip;
        private int _hp;
        private string _usr;
        private string _pwd;
        private string _ppk;
        private string _initdir;
        private Session _ssn;
        private bool _bInPPK = false;
    
        public void DisConnect()
        {
            this.Dispose();
        }

        public void Dispose()
        {
 	        if (_ssn != null && _ssn.isConnected())
            {
                _ssn.disconnect();
                Console.WriteLine("Bye");
            }
        }
    }
}
