using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.DataAccess
{
    public class SQLConnectionProperties
    {
        public string ServerInstance { get; set; }

        public string Database { get; set; }

        public string UserID { get; set; }

        public string Password { get; set; }
    }
}
