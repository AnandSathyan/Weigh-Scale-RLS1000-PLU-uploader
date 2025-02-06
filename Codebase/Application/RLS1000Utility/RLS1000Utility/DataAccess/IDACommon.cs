using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.DataAccess
{
    internal interface IDACommon
    {
        void Initialize();
        void Dispose();
        void OpenConnection();
        void CloseConnection();
        void BeginTrans();
        void EndTrans();
        void CommitTrans();
        void RollBackTrans();
        object GetActiveConnection();
        object GetActiveTranscation();
    }
}
