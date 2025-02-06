using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.DataAccess
{
    public abstract class AbstractSystemDA
    {
        public abstract void Initialize(object obj);

        public abstract bool OpenConnection();

        public abstract void CloseConnection();

        public abstract void Dispose();

        public abstract Dictionary<string, string> DBObjectList();

        public abstract Dictionary<string, string> DBObjectColumnList(string obj);
    }
}
