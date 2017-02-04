using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FTP
{
    [Serializable()]
    public class Dirs
    {
        public List<LocalRemoteDir> DirList = new List<LocalRemoteDir>();
        public bool is_changed = false;

        public bool Add(LocalRemoteDir lrDir)
        {
            if (lrDir.local != null && lrDir.remote != null)
            {
                if (lrDir.local.Length > 1)
                {
                    lrDir.local = Path.GetDirectoryName(lrDir.local + "/");
                }
                if (lrDir.remote.Length > 1)
                {
                    lrDir.remote = Path.GetDirectoryName(lrDir.remote + "/");
                }
                DirList.Add(lrDir);
                is_changed = true;
                return true;
            }
            return false;
        }

        public bool Update(int id, LocalRemoteDir lrDir)
        {
            if (id < DirList.Count && id >= 0)
            {
                if (lrDir.local != null && lrDir.remote != null)
                {
                    DirList[id] = lrDir;
                    is_changed = true;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(int id)
        {
            if (id < DirList.Count && id >= 0)
            {
                DirList.RemoveAt(id);
                is_changed = true;
                return true;
            }
            return false;
        }

    }
}
