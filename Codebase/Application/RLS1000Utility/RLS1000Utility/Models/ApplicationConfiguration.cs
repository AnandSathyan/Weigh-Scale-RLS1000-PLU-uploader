using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.Models
{
    public class ApplicationConfiguration
    {
        private static AppConnectionType _appConnectionType;
        public AppConnectionType appConnectionType
        {
            get { return _appConnectionType; }
            set { _appConnectionType = value; }
        }

        private static AppConnectionParameter _appConnectionParameter;
        public AppConnectionParameter appConnectionParameter
        {
            get { return _appConnectionParameter; }
            set { _appConnectionParameter = value; }
        }

        private static AppDBObject _appDBObject;
        public AppDBObject appDBObject
        {
            get { return _appDBObject; }
            set { _appDBObject = value; }
        }

        private static AppDBObjectColumnMap _appDBObjectColumnMap;
        public AppDBObjectColumnMap appDBObjectColumnMap
        {
            get { return _appDBObjectColumnMap; }
            set { _appDBObjectColumnMap = value; }
        }

        private static string _DBConnectionString;
        public string DBConnectionString
        {
            get { return _DBConnectionString; }
            set { _DBConnectionString = value; }
        }

        private string _DBQuery;
        public string DBQuery
        {
            get { return _DBQuery; }
            set { _DBQuery = value; }
        }


        public ApplicationConfiguration(
            AppConnectionType _appConnectionType,
            AppConnectionParameter _appConnectionParameter,
            AppDBObject _appDBObject,
            AppDBObjectColumnMap _appDBObjectColumnMap)
        {
            appConnectionType = _appConnectionType;
            appConnectionParameter = _appConnectionParameter;
            appDBObject = _appDBObject;
            appDBObjectColumnMap = _appDBObjectColumnMap;

            if (_appConnectionType.ConnectionType == 1)
                DBConnectionString = ($"Data Source={_appConnectionParameter.DataSource};Initial Catalog={_appConnectionParameter.DBName};User ID={_appConnectionParameter.LoginUserID};password={_appConnectionParameter.LoginPassword};  pooling='true'; Max Pool Size=400");
            else if (_appConnectionType.ConnectionType == 2)
                DBConnectionString = ($"Data Source = {_appConnectionParameter.DataSource};User Id = {_appConnectionParameter.LoginUserID};Password = {_appConnectionParameter.LoginPassword};");
            else
                DBConnectionString = ("");

            DBQuery = ($"SELECT {_appDBObjectColumnMap.LFCodeColumn}, {_appDBObjectColumnMap.BarcodeColumn}, {_appDBObjectColumnMap.PLUNameColumn}, {_appDBObjectColumnMap.UnitPriceColumn} FROM {_appDBObject.DBObjectName}");
        }

        public ApplicationConfiguration()
        {
            appConnectionType = new AppConnectionType();
            appConnectionParameter = new AppConnectionParameter();
            appDBObject = new AppDBObject();
            appDBObjectColumnMap = new AppDBObjectColumnMap();
        }

        
    }
}
