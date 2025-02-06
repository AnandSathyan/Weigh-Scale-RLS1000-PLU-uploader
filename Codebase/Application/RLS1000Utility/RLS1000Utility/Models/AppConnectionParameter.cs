using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.Models
{
    public class AppConnectionParameter
    {
        public int ID { get; }
        public int AppConnectionTypeID { get; }
        public string DataSource { get; }
        public string DBName { get; }
        public string LoginUserID { get; }
        public string LoginPassword { get; }
        
        public AppConnectionParameter(
            int _ID,
            int _AppConnectionTypeID, 
            string _DataSource, 
            string _DBName, 
            string _LoginUserID, 
            string _LoginPassword)
        {
            ID = _ID;
            AppConnectionTypeID = _AppConnectionTypeID;
            DataSource = _DataSource;
            DBName = _DBName;
            LoginUserID = _LoginUserID;
            LoginPassword = _LoginPassword;

        }

        public AppConnectionParameter()
        {
            ID = 0;
            AppConnectionTypeID = 0;
            DataSource = "";
            DBName = "";
            LoginUserID = "";
            LoginPassword = "";

        }
    }
}
