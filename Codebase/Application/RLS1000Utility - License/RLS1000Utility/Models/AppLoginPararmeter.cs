using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.Models
{
    public class AppLoginPararmeter
    {
        public int ID { get; }
        public int AppMode { get; }
        public string UserID { get; }
        public string UserPassword { get; }

        public AppLoginPararmeter(
            int _ID,
            int _AppMode,
            string _UserID,
            string _UserPassword)
        {
            ID = _ID;
            AppMode = _AppMode;
            UserID = _UserID;
            UserPassword = _UserPassword;
        }
        public AppLoginPararmeter()
        {
            ID = 0;
            AppMode = 0;
            UserID = "";
            UserPassword = "";
        }

    }
}
