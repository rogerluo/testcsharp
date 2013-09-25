using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testSharpSSH
{
    class Util
    {
        public static string ToRemotePath(string path)
        {
            string tmp = path.Replace(":", "").Replace("\\", "/");
            if (!tmp.Contains("cygdrive"))
                return "/cygdrive/" + tmp;
            else
                return tmp;
        }
    }
}
