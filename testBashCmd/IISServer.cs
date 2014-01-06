using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace NetworkUtility
{
    public class Website
    {
        public Int32 Identity
        {
            get;
            set;
        }
 
        public String Name
        {
            get;
            set;
        }
 
        public String PhysicalPath
        {
            get;
            set;
        }
 
        public ServerState Status
        {
            get;
            set;
        }
    }

    public enum ServerState
    {
        Starting = 1,
        Started = 2,
        Stopping = 3,
        Stopped = 4,
        Pausing = 5,
        Paused = 6,
        Continuing = 7
    }

    public partial class NetworkUtility
    {
        public static IEnumerable<Website> GetSites(string Path)
        {
            DirectoryEntry IIsEntities = new DirectoryEntry(Path, "reutadmin", "Tin.netSA");

            foreach (DirectoryEntry IIsEntity in IIsEntities.Children)
            {
                if (IIsEntity.SchemaClassName == "IIsWebServer")
                {
                    yield return new Website {
                        Identity = Convert.ToInt32(IIsEntity.Name),
                        Name = IIsEntity.Properties["ServerComment"].Value.ToString(),
                        PhysicalPath = GetPath(IIsEntity),
                        Status = (ServerState)IIsEntity.Properties["ServerState"].Value
                    };
                }
            }
        }

        private static String GetPath(DirectoryEntry IIsWebServer)
        {
            foreach (DirectoryEntry IIsEntity in IIsWebServer.Children)
            {
                if (IIsEntity.SchemaClassName == "IIsWebVirtualDir")
                    return IIsEntity.Properties["Path"].Value.ToString();
            }
            return null;
        }
    }
}
