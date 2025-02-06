using RLS1000Utility.DeviceUtility;
using RLS1000Utility.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RLS1000Utility.DataAccess
{
    public class AppConfigurationDASqLite
    {
        private DACommonConfigSqLite daCommon;
        SQLiteCommand sqlCommand;
        SQLiteDataAdapter sqlDataAdapter;

        public AppConfigurationDASqLite()
        {
            daCommon = DACommonConfigSqLite.GetInstance(new SqLiteConnectionProperties());
            //InitDB();
        }

        public void InitDB()
        {

            try
            {

                if (!DBExist())
                {
                    SQLiteConnection.CreateFile(@"PegasusAppConfig.db");
                }

                //-----------------------
                if (!CreateAppConnectionType())
                    return;
                //-----------------------
                if (!CreateAppConnectionParameter())
                    return;

                //-----------------------
                if (!CreateAppDBObject())
                    return;

                //-----------------------
                if (!CreateAppDBObjectColumnMap())
                    return;

                //-----------------------
                if (!CreateAppDeviceMaster())
                    return;

                //-----------------------
                if (!CreatePegasusSettings())
                    return;

                //-----------------------
                if (!CreateAppLoginPararmeter())
                    return;

                //-----------------------
                if (!CreateClientDBSetup())
                    return;

                //-----------------------
                if (!CreateAppCompanySetup())
                    return;

                //-----------------------
                if (!CreateAppPLUData())
                    return;

                ////-----------------------
                //if (!Create())
                //    return;

                ////-----------------------


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //----------------------------

        public bool DBExist()
        {
            if (!File.Exists(@"PegasusAppConfig.db"))
            {
                //SQLiteConnection.CreateFile(@"PegasusAppConfig.db");
                return false;
            }
            return true;
        }

        private bool CreateAppConnectionType()
        {

            try
            {

                daCommon.OpenConnection();
                sqlCommand = new SQLiteCommand(
                @"SELECT name FROM sqlite_master WHERE name='AppConnectionType'",
                daCommon.ActiveConnection);
                var name = sqlCommand.ExecuteScalar();

                // if AppConnectionType exist do nothing 
                if (name != null && name.ToString() == "AppConnectionType")
                    return false;

                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"CREATE TABLE AppConnectionType(
	                ID int NOT NULL,
	                ConnectionName nvarchar2(2000) NOT NULL,
	                ConnectionType nvarchar2(2000) NOT NULL,
                PRIMARY KEY 
                (
	                ID
                ))",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                return false;
            }
        }

        private bool CreateAppConnectionParameter()
        {

            try
            {

                daCommon.OpenConnection();
                sqlCommand = new SQLiteCommand(
                @"SELECT name FROM sqlite_master WHERE name='AppConnectionParameter'",
                daCommon.ActiveConnection);
                var name = sqlCommand.ExecuteScalar();

                // if AppConnectionType exist do nothing 
                if (name != null && name.ToString() == "AppConnectionParameter")
                    return false;

                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"CREATE TABLE AppConnectionParameter(
	                ID int NOT NULL,
	                AppConnectionTypeID int NOT NULL,
	                DataSource nvarchar2(10000) NOT NULL,
	                DBName nvarchar2(2000) NOT NULL,
	                LoginUserID nvarchar2(2000) NOT NULL,
	                LoginPassword nvarchar2(2000) NOT NULL,
                PRIMARY KEY 
                (
	                ID
                ))",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                var r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                return false;
            }
        }

        private bool CreateAppDBObject()
        {

            try
            {

                daCommon.OpenConnection();
                sqlCommand = new SQLiteCommand(
                @"SELECT name FROM sqlite_master WHERE name='AppDBObject'",
                daCommon.ActiveConnection);
                var name = sqlCommand.ExecuteScalar();

                // if AppConnectionType exist do nothing 
                if (name != null && name.ToString() == "AppDBObject")
                    return false;

                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"CREATE TABLE AppDBObject(
	                ID int NOT NULL,
	                DBObjectName nvarchar2(2000) NOT NULL,
	                DBObjectType nvarchar2(2000) NOT NULL,
                PRIMARY KEY 
                (
	                ID
                ))",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                var r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                return false;
            }
        }

        private bool CreateAppDBObjectColumnMap()
        {

            try
            {

                daCommon.OpenConnection();
                sqlCommand = new SQLiteCommand(
                @"SELECT name FROM sqlite_master WHERE name='AppDBObjectColumnMap'",
                daCommon.ActiveConnection);
                var name = sqlCommand.ExecuteScalar();

                // if AppConnectionType exist do nothing 
                if (name != null && name.ToString() == "AppDBObjectColumnMap")
                    return false;

                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"CREATE TABLE AppDBObjectColumnMap(
	                ID int NOT NULL,
	                DBObjectID int NOT NULL,
	                LFCodeColumn nvarchar2(2000) NOT NULL,
	                BarcodeColumn nvarchar2(2000) NOT NULL,
	                PLUNameColumn nvarchar2(2000) NOT NULL,
	                UnitPriceColumn nvarchar2(2000) NOT NULL,
                PRIMARY KEY 
                (
	                ID
                ))",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                var r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                return false;
            }
        }

        private bool CreateAppDeviceMaster()
        {

            try
            {

                daCommon.OpenConnection();
                sqlCommand = new SQLiteCommand(
                @"SELECT name FROM sqlite_master WHERE name='AppDeviceMaster'",
                daCommon.ActiveConnection);
                var name = sqlCommand.ExecuteScalar();

                // if AppConnectionType exist do nothing 
                if (name != null && name.ToString() == "AppDeviceMaster")
                    return false;

                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"CREATE TABLE AppDeviceMaster(
	                DeviceID int NOT NULL,
	                DeviceIP nvarchar(15) NULL,
	                DeviceName nvarchar(250) NULL,
	                SourcePath nvarchar(10000) NULL,
	                DestinationPath nvarchar(10000) NULL,
	                FileType nvarchar(10) NULL,
	                ScrollText nvarchar(10000) NULL,
	                Lang int NULL,
	                IsUpdate int NULL,
	                regsitration_date nvarchar(10000) NULL,
	                expiry_date nvarchar(10000) NULL,
	                lic_customer_licesnse_Id nvarchar(250) NOT NULL,
	                lic_product_id nvarchar(10000) NULL,
	                lic_code nvarchar(10000) NULL,
	                license_key nvarchar(10000) NULL,
                 PRIMARY KEY 
                (
	                lic_customer_licesnse_Id
                )
                )",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                return false;
            }
        }

        private bool CreatePegasusSettings()
        {

            try
            {

                daCommon.OpenConnection();
                sqlCommand = new SQLiteCommand(
                @"SELECT name FROM sqlite_master WHERE name='PegasusSettings'",
                daCommon.ActiveConnection);
                var name = sqlCommand.ExecuteScalar();

                // if AppConnectionType exist do nothing 
                if (name != null && name.ToString() == "PegasusSettings")
                    return false;

                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"CREATE TABLE PegasusSettings(
	                ID int NULL,
	                registrationcode nvarchar(50) NULL,
	                email nvarchar(50) NULL,
	                name nvarchar(50) NULL,
	                companyname nvarchar(50) NULL,
	                PhoneNumber nvarchar(50) NULL,
	                versiontype nvarchar(20) NULL,
	                LicenseKey nvarchar(20) NULL
                )",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                return false;
            }
        }

        private bool CreateAppLoginPararmeter()
        {

            try
            {

                daCommon.OpenConnection();
                sqlCommand = new SQLiteCommand(
                @"SELECT name FROM sqlite_master WHERE name='AppLoginPararmeter'",
                daCommon.ActiveConnection);
                var name = sqlCommand.ExecuteScalar();

                // if AppConnectionType exist do nothing 
                if (name != null && name.ToString() == "AppLoginPararmeter")
                    return false;

                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"CREATE TABLE AppLoginPararmeter(
	                ID int NOT NULL,
	                AppMode int NULL,
	                UserID nvarchar(500) NOT NULL,
	                UserPassword nvarchar(500) NOT NULL,
                PRIMARY KEY 
                (
	                ID
                ))",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                return false;
            }
        }

        private bool CreateClientDBSetup()
        {

            try
            {

                daCommon.OpenConnection();
                sqlCommand = new SQLiteCommand(
                @"SELECT name FROM sqlite_master WHERE name='ClientDBSetup'",
                daCommon.ActiveConnection);
                var name = sqlCommand.ExecuteScalar();

                // if AppConnectionType exist do nothing 
                if (name != null && name.ToString() == "ClientDBSetup")
                    return false;

                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"CREATE TABLE ClientDBSetup(
	                ID int NOT NULL,
	                ConnectionTypeID int NULL,
	                ConnectionParameterID int NULL,
	                DBObjectID int NULL,
	                DBObjectColumnMapID int NULL,
	                ConnectionType int NULL,
	                ConnString nvarchar(10000) NULL,
	                DBObjectName nvarchar(10000) NULL,
	                LFCodeColumn nvarchar(10000) NULL,
	                BarcodeColumn nvarchar(10000) NULL,
	                PLUNameColumn nvarchar(10000) NULL,
	                UnitPriceColumn nvarchar(10000) NULL,
                PRIMARY KEY 
                (
	                ID
                ))",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                return false;
            }
        }

        private bool CreateAppCompanySetup()
        {
            try
            {
                daCommon.OpenConnection();
                sqlCommand = new SQLiteCommand(
                @"SELECT name FROM sqlite_master WHERE name='AppCompanySetup'",
                daCommon.ActiveConnection);
                var name = sqlCommand.ExecuteScalar();

                // if AppConnectionType exist do nothing 
                if (name != null && name.ToString() == "AppCompanySetup")
                    return false;

                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"CREATE TABLE AppCompanySetup(
	                ID int NOT NULL,
	                CompanyName nvarchar(500) NULL,
	                CompanyLogo nvarchar(10000) NULL,
	                CompanyPhone nvarchar(20) NULL,
	                CompanyEmail nvarchar(500) NULL,
	                CompanyAddress nvarchar(1000) NULL,
	                CompanyWebSite nvarchar(500) NULL,
	                CompanyImage BLOB NULL,
	                CompanyCurrency nvarchar(50) NULL,
	                CompanyDecimalPlace int NULL,
                PRIMARY KEY 
                (
	                ID
                ))",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                return false;
            }
        }

        private bool CreateAppPLUData()
        {

            try
            {

                daCommon.OpenConnection();
                sqlCommand = new SQLiteCommand(
                @"SELECT name FROM sqlite_master WHERE name='AppPLUData'",
                daCommon.ActiveConnection);
                var name = sqlCommand.ExecuteScalar();

                // if AppConnectionType exist do nothing 
                if (name != null && name.ToString() == "AppPLUData")
                    return false;

                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"CREATE TABLE AppPLUData(
	                LFCode numeric(12, 0) NOT NULL,
	                Barcode numeric(12, 0) NOT NULL,
	                HotKey int unique NOT NULL,
	                PLUName nvarchar2(2000) NOT NULL,
	                UnitPrice numeric(12, 3) NOT NULL,
	                BarcodeType int NOT NULL,
	                WeightUnit int NOT NULL,
	                QtyUnit int NOT NULL,
	                Department int NOT NULL,
	                Tare int NOT NULL,
	                ShelfTime int NOT NULL,
	                PackageType int NOT NULL,
	                PackageWeight int NOT NULL,
	                Tolerance int NOT NULL,
	                Message1 int NOT NULL,
	                Message2 int NOT NULL,
	                LabelID int NOT NULL,
	                Discount int NOT NULL,

                PRIMARY KEY 
                (
	                LFCode
                ))",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                return false;
            }
        }

        private bool Create()
        {

            try
            {

                daCommon.OpenConnection();
                sqlCommand = new SQLiteCommand(
                @"SELECT name FROM sqlite_master WHERE name='AppConnectionType'",
                daCommon.ActiveConnection);
                var name = sqlCommand.ExecuteScalar();

                // if AppConnectionType exist do nothing 
                if (name != null && name.ToString() == "AppConnectionType")
                    return false;

                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"CREATE TABLE AppConnectionType(
	                ID int NOT NULL,
	                ConnectionName nvarchar2(2000) NOT NULL,
	                ConnectionType nvarchar2(2000) NOT NULL,
                PRIMARY KEY 
                (
	                ID
                ))",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                return false;
            }
        }

        //----------------------------

        public AppConnectionType GetAppConnectionType()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT ID, ConnectionName, ConnectionType FROM AppConnectionType",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    return new AppConnectionType(
                        Convert.ToInt32(dt.Rows[0]["ID"]),
                        Convert.ToString(dt.Rows[0]["ConnectionName"]),
                        Convert.ToInt32(dt.Rows[0]["ConnectionType"]));
                }
                else
                    return new AppConnectionType();
            }
            catch (Exception ex)
            {
                return new AppConnectionType();
            }
        }

        public AppConnectionParameter GetAppConnectionParameter()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT ID, AppConnectionTypeID, DataSource, DBName, LoginUserID, LoginPassword FROM AppConnectionParameter",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    return new AppConnectionParameter(
                        Convert.ToInt32(dt.Rows[0]["ID"]),
                        Convert.ToInt32(dt.Rows[0]["AppConnectionTypeID"]),
                        Convert.ToString(dt.Rows[0]["DataSource"]),
                        Convert.ToString(dt.Rows[0]["DBName"]),
                        Convert.ToString(dt.Rows[0]["LoginUserID"]),
                        Convert.ToString(dt.Rows[0]["LoginPassword"]));
                }
                else
                    return new AppConnectionParameter();
            }
            catch (Exception ex)
            {
                return new AppConnectionParameter();
            }
        }

        public AppDBObject GetAppDBObject()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT ID, DBObjectName, DBObjectType FROM AppDBObject",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    return new AppDBObject(
                        Convert.ToInt32(dt.Rows[0]["ID"]),
                        Convert.ToString(dt.Rows[0]["DBObjectName"]),
                        Convert.ToString(dt.Rows[0]["DBObjectType"]));
                }
                else
                    return new AppDBObject();
            }
            catch (Exception ex)
            {
                return new AppDBObject();
            }
        }

        public AppDBObjectColumnMap GetAppDBObjectColumnMap()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT ID, DBObjectID, LFCodeColumn, BarcodeColumn, PLUNameColumn, UnitPriceColumn FROM AppDBObjectColumnMap",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    return new AppDBObjectColumnMap(
                        Convert.ToInt32(dt.Rows[0]["ID"]),
                        Convert.ToInt32(dt.Rows[0]["DBObjectID"]),
                        Convert.ToString(dt.Rows[0]["LFCodeColumn"]),
                        Convert.ToString(dt.Rows[0]["BarcodeColumn"]),
                        Convert.ToString(dt.Rows[0]["PLUNameColumn"]),
                        Convert.ToString(dt.Rows[0]["UnitPriceColumn"]));
                }
                else
                    return new AppDBObjectColumnMap();
            }
            catch (Exception ex)
            {
                return new AppDBObjectColumnMap();
            }
        }

        public List<AppDeviceMaster> GetAppDeviceMaster()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT 
                    DeviceID ,
                    DeviceIP ,
                    DeviceName ,
                    SourcePath ,
                    DestinationPath ,
                    FileType ,
                    ScrollText ,
                    Lang ,
                    IsUpdate ,
                    regsitration_date ,
                    expiry_date ,
                    lic_customer_licesnse_Id ,
                    lic_product_id ,
                    lic_code ,
                    license_key 
                    FROM AppDeviceMaster",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    List<AppDeviceMaster> list = new List<AppDeviceMaster>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        list.Add(
                        new AppDeviceMaster(
                            Convert.ToInt32(dt.Rows[i]["DeviceID"]),
                            Convert.ToString(dt.Rows[i]["DeviceIP"]),
                            Convert.ToString(dt.Rows[i]["DeviceName"]),
                            Convert.ToString(dt.Rows[i]["SourcePath"]),
                            Convert.ToString(dt.Rows[i]["DestinationPath"]),
                            Convert.ToString(dt.Rows[i]["FileType"]),
                            Convert.ToString(dt.Rows[i]["ScrollText"]),
                            Convert.ToInt32(dt.Rows[i]["Lang"]),
                            Convert.ToInt32(dt.Rows[i]["IsUpdate"]),
                            Convert.ToString(dt.Rows[i]["regsitration_date"]),
                            Convert.ToString(dt.Rows[i]["expiry_date"]),
                            Convert.ToString(dt.Rows[i]["lic_customer_licesnse_Id"]),
                            Convert.ToString(dt.Rows[i]["lic_product_id"]),
                            Convert.ToString(dt.Rows[i]["lic_code"]),
                            Convert.ToString(dt.Rows[i]["license_key"]))
                        );
                    }
                    return list;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PegasusSettings GetPegasusSettings()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT
                ID,
                registrationcode,
                email,
                name,
                companyname,
                PhoneNumber,
                versiontype,
                LicenseKey
                FROM PegasusSettings",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return new PegasusSettings(
                        Convert.ToInt32(dt.Rows[0]["ID"]),
                        Convert.ToString(dt.Rows[0]["registrationcode"]),
                        Convert.ToString(dt.Rows[0]["email"]),
                        Convert.ToString(dt.Rows[0]["name"]),
                        Convert.ToString(dt.Rows[0]["companyname"]),
                        Convert.ToString(dt.Rows[0]["PhoneNumber"]),
                        Convert.ToString(dt.Rows[0]["versiontype"]),
                        Convert.ToString(dt.Rows[0]["LicenseKey"]));
                }
                else
                    return new PegasusSettings();
            }
            catch (Exception ex)
            {
                return new PegasusSettings();
            }
        }

        public AppLoginPararmeter GetAppLoginPararmeter()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT
                ID,
                AppMode,
                UserID,
                UserPassword
                FROM AppLoginPararmeter",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    return new AppLoginPararmeter(
                        Convert.ToInt32(dt.Rows[0]["ID"]),
                        Convert.ToInt32(dt.Rows[0]["AppMode"]),
                        Convert.ToString(dt.Rows[0]["UserID"]),
                        Convert.ToString(dt.Rows[0]["UserPassword"]));
                }
                else
                    return new AppLoginPararmeter();
            }
            catch (Exception ex)
            {
                return new AppLoginPararmeter();
            }
        }

        public List<AppLoginPararmeter> GetAllAppLoginPararmeter()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT
                ID,
                AppMode,
                UserID,
                UserPassword
                FROM AppLoginPararmeter",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    List<AppLoginPararmeter> list = new List<AppLoginPararmeter>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        list.Add(new AppLoginPararmeter(
                            Convert.ToInt32(dt.Rows[0]["ID"]),
                            Convert.ToInt32(dt.Rows[0]["AppMode"]),
                            Convert.ToString(dt.Rows[0]["UserID"]),
                            Convert.ToString(dt.Rows[0]["UserPassword"])));

                    }
                    return list;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ClientDBSetup GetClientDBSetup()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT
                ID,
                ConnectionTypeID,
                ConnectionParameterID,
                DBObjectID,
                DBObjectColumnMapID,
                ConnectionType,
                ConnString,
                DBObjectName,
                LFCodeColumn,
                BarcodeColumn,
                PLUNameColumn,
                UnitPriceColumn
                FROM ClientDBSetup",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    return new ClientDBSetup(
                        Convert.ToInt32(dt.Rows[0]["ID"]),
                        Convert.ToInt32(dt.Rows[0]["ConnectionTypeID"]),
                        Convert.ToInt32(dt.Rows[0]["ConnectionParameterID"]),
                        Convert.ToInt32(dt.Rows[0]["DBObjectID"]),
                        Convert.ToInt32(dt.Rows[0]["DBObjectColumnMapID"]),
                        Convert.ToInt32(dt.Rows[0]["ConnectionType"]),
                        Convert.ToString(dt.Rows[0]["ConnString"]),
                        Convert.ToString(dt.Rows[0]["DBObjectName"]),
                        Convert.ToString(dt.Rows[0]["LFCodeColumn"]),
                        Convert.ToString(dt.Rows[0]["BarcodeColumn"]),
                        Convert.ToString(dt.Rows[0]["PLUNameColumn"]),
                        Convert.ToString(dt.Rows[0]["UnitPriceColumn"]));
                }
                else
                    return new ClientDBSetup();
            }
            catch (Exception ex)
            {
                return new ClientDBSetup();
            }
        }

        public ApplicationConfiguration GetApplicationConfiguration()
        {
            try
            {
                ApplicationConfiguration applicationConfiguration = new ApplicationConfiguration();

                applicationConfiguration.appConnectionType = GetAppConnectionType();
                if (applicationConfiguration.appConnectionType.ID == 0)
                    return new ApplicationConfiguration();

                applicationConfiguration.appConnectionParameter = GetAppConnectionParameter();
                if (applicationConfiguration.appConnectionParameter.ID == 0)
                    return new ApplicationConfiguration();

                applicationConfiguration.appDBObject = GetAppDBObject();
                if (applicationConfiguration.appDBObject.ID == 0)
                    return new ApplicationConfiguration();

                applicationConfiguration.appDBObjectColumnMap = GetAppDBObjectColumnMap();
                if (applicationConfiguration.appDBObjectColumnMap.ID == 0)
                    return new ApplicationConfiguration();

                return applicationConfiguration;
            }
            catch (Exception ex)
            {
                return new ApplicationConfiguration();
            }
        }

        public AppCompanySetup GetAppCompanySetup()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT ID,CompanyName,CompanyLogo,CompanyPhone,CompanyEmail,CompanyAddress,CompanyWebSite,CompanyImage,CompanyCurrency,CompanyDecimalPlace FROM AppCompanySetup",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    return new AppCompanySetup(
                        Convert.ToInt32(dt.Rows[0]["ID"]),
                        Convert.ToString(dt.Rows[0]["CompanyName"]),
                        Convert.ToString(dt.Rows[0]["CompanyLogo"]),
                        Convert.ToString(dt.Rows[0]["CompanyPhone"]),
                        Convert.ToString(dt.Rows[0]["CompanyEmail"]),
                        Convert.ToString(dt.Rows[0]["CompanyAddress"]),
                        Convert.ToString(dt.Rows[0]["CompanyWebSite"]),
                        //(byte[])(dt.Rows[0]["CompanyImage"]),
                        new byte[0],
                        Convert.ToString(dt.Rows[0]["CompanyCurrency"]),
                        Convert.ToInt32(dt.Rows[0]["CompanyDecimalPlace"]));
                }
                else
                    return new AppCompanySetup();
            }
            catch (Exception ex)
            {
                return new AppCompanySetup();
            }
        }

        public DataTable GetAppPLUData()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT LFCode,Barcode,HotKey,PLUName,UnitPrice,BarcodeType,WeightUnit,QtyUnit,Department,Tare,ShelfTime,PackageType,PackageWeight
                ,Tolerance,Message1,Message2,LabelID,Discount FROM AppPLUData",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        private AppDBObjectColumnMap Get()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT ID, DBObjectID, LFCodeColumn, BarcodeColumn, PLUNameColumn, UnitPriceColumn FROM AppDBObjectColumnMap",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    return new AppDBObjectColumnMap(
                        Convert.ToInt32(dt.Rows[0]["ID"]),
                        Convert.ToInt32(dt.Rows[0]["DBObjectID"]),
                        Convert.ToString(dt.Rows[0]["LFCodeColumn"]),
                        Convert.ToString(dt.Rows[0]["BarcodeColumn"]),
                        Convert.ToString(dt.Rows[0]["PLUNameColumn"]),
                        Convert.ToString(dt.Rows[0]["UnitPriceColumn"]));
                }
                else
                    return new AppDBObjectColumnMap();
            }
            catch (Exception ex)
            {
                return new AppDBObjectColumnMap();
            }
        }

        //----------------------------

        public bool InsertAppConnectionType(AppConnectionType _appConnectionType)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"INSERT INTO AppConnectionType (ID,ConnectionName,ConnectionType) VALUES(@ID,@ConnectionName,@ConnectionType)",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appConnectionType.ID);
                sqlCommand.Parameters.AddWithValue("@ConnectionName", _appConnectionType.ConnectionName);
                sqlCommand.Parameters.AddWithValue("@ConnectionType", _appConnectionType.ConnectionType);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool InsertAppConnectionParameter(AppConnectionParameter _appConnectionParameter)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"INSERT INTO AppConnectionParameter (ID,AppConnectionTypeID,DataSource,DBName,LoginUserID,LoginPassword) 
                VALUES(@ID,@AppConnectionTypeID,@DataSource,@DBName,@LoginUserID,@LoginPassword)",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appConnectionParameter.ID);
                sqlCommand.Parameters.AddWithValue("@AppConnectionTypeID", _appConnectionParameter.AppConnectionTypeID);
                sqlCommand.Parameters.AddWithValue("@DataSource", _appConnectionParameter.DataSource);
                sqlCommand.Parameters.AddWithValue("@DBName", _appConnectionParameter.DBName);
                sqlCommand.Parameters.AddWithValue("@LoginUserID", _appConnectionParameter.LoginUserID);
                sqlCommand.Parameters.AddWithValue("@LoginPassword", _appConnectionParameter.LoginPassword);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool InsertAppDBObject(AppDBObject _appDBObject)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"INSERT INTO AppDBObject (ID,DBObjectName,DBObjectType) VALUES(@ID,@DBObjectName,@DBObjectType)",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appDBObject.ID);
                sqlCommand.Parameters.AddWithValue("@DBObjectName", _appDBObject.DBObjectName);
                sqlCommand.Parameters.AddWithValue("@DBObjectType", _appDBObject.DBObjectType);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool InsertAppDBObjectColumnMap(AppDBObjectColumnMap _appDBObjectColumnMap)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"INSERT INTO AppDBObjectColumnMap (ID,DBObjectID,LFCodeColumn,BarcodeColumn,PLUNameColumn,UnitPriceColumn) 
                VALUES(@ID,@DBObjectID,@LFCodeColumn,@BarcodeColumn,@PLUNameColumn,@UnitPriceColumn)",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appDBObjectColumnMap.ID);
                sqlCommand.Parameters.AddWithValue("@DBObjectID", _appDBObjectColumnMap.DBObjectID);
                sqlCommand.Parameters.AddWithValue("@LFCodeColumn", _appDBObjectColumnMap.LFCodeColumn);
                sqlCommand.Parameters.AddWithValue("@BarcodeColumn", _appDBObjectColumnMap.BarcodeColumn);
                sqlCommand.Parameters.AddWithValue("@PLUNameColumn", _appDBObjectColumnMap.PLUNameColumn);
                sqlCommand.Parameters.AddWithValue("@UnitPriceColumn", _appDBObjectColumnMap.UnitPriceColumn);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool InsertAppDeviceMaster(AppDeviceMaster _appDeviceMaster)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"INSERT INTO AppDeviceMaster
                (DeviceID ,
                DeviceIP ,
                DeviceName ,
                SourcePath ,
                DestinationPath ,
                FileType ,
                ScrollText ,
                Lang ,
                IsUpdate ,
                regsitration_date ,
                expiry_date ,
                lic_customer_licesnse_Id ,
                lic_product_id ,
                lic_code ,
                license_key)
                VALUES
                (@DeviceID,
                @DeviceIP,
                @DeviceName,
                @SourcePath,
                @DestinationPath,
                @FileType,
                @ScrollText,
                @Lang,
                @IsUpdate,
                @regsitration_date,
                @expiry_date,
                @lic_customer_licesnse_Id,
                @lic_product_id,
                @lic_code,
                @license_key)",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@DeviceID", _appDeviceMaster.DeviceID);
                sqlCommand.Parameters.AddWithValue("@DeviceIP", _appDeviceMaster.DeviceIP);
                sqlCommand.Parameters.AddWithValue("@DeviceName", _appDeviceMaster.DeviceName);
                sqlCommand.Parameters.AddWithValue("@SourcePath", _appDeviceMaster.SourcePath);
                sqlCommand.Parameters.AddWithValue("@DestinationPath", _appDeviceMaster.DestinationPath);
                sqlCommand.Parameters.AddWithValue("@FileType", _appDeviceMaster.FileType);
                sqlCommand.Parameters.AddWithValue("@ScrollText", _appDeviceMaster.ScrollText);
                sqlCommand.Parameters.AddWithValue("@Lang", _appDeviceMaster.Lang);
                sqlCommand.Parameters.AddWithValue("@IsUpdate", _appDeviceMaster.IsUpdate);
                sqlCommand.Parameters.AddWithValue("@regsitration_date", _appDeviceMaster.Regsitration_Date);
                sqlCommand.Parameters.AddWithValue("@expiry_date", _appDeviceMaster.Expiry_Date);
                sqlCommand.Parameters.AddWithValue("@lic_customer_licesnse_Id", _appDeviceMaster.Lic_Customer_Licesnse_Id);
                sqlCommand.Parameters.AddWithValue("@lic_product_id", _appDeviceMaster.Lic_Product_Id);
                sqlCommand.Parameters.AddWithValue("@lic_code", _appDeviceMaster.Lic_Code);
                sqlCommand.Parameters.AddWithValue("@license_key", _appDeviceMaster.License_Key);


                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool InsertPegasusSettings(PegasusSettings _pegasusSettings)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"INSERT INTO PegasusSettings
                (ID,
                registrationcode,
                email,
                name,
                companyname,
                PhoneNumber,
                versiontype,
                LicenseKey)
                VALUES
                (@ID,
                @registrationcode,
                @email,
                @name,
                @companyname,
                @PhoneNumber,
                @versiontype,
                @LicenseKey)",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _pegasusSettings.ID);
                sqlCommand.Parameters.AddWithValue("@registrationcode", _pegasusSettings.RegisterationCode);
                sqlCommand.Parameters.AddWithValue("@email", _pegasusSettings.Email);
                sqlCommand.Parameters.AddWithValue("@name", _pegasusSettings.Name);
                sqlCommand.Parameters.AddWithValue("@companyname", _pegasusSettings.CompanyName);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", _pegasusSettings.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@versiontype", _pegasusSettings.VersionType);
                sqlCommand.Parameters.AddWithValue("@LicenseKey", _pegasusSettings.LicenseKey);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool InsertAppLoginPararmeter(AppLoginPararmeter _appLoginPararmeter)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"INSERT INTO AppLoginPararmeter
                (ID,
                AppMode,
                UserID,
                UserPassword)
                VALUES
                (@ID,
                @AppMode,
                @UserID,
                @UserPassword)",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appLoginPararmeter.ID);
                sqlCommand.Parameters.AddWithValue("@AppMode", _appLoginPararmeter.AppMode);
                sqlCommand.Parameters.AddWithValue("@UserID", _appLoginPararmeter.UserID);
                sqlCommand.Parameters.AddWithValue("@UserPassword", _appLoginPararmeter.UserPassword);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool InsertClientDBSetup(ClientDBSetup _clientDBSetup)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"INSERT INTO ClientDBSetup
                (ID,
                ConnectionTypeID,
                ConnectionParameterID,
                DBObjectID,
                DBObjectColumnMapID,
                ConnectionType,
                ConnString,
                DBObjectName,
                LFCodeColumn,
                BarcodeColumn,
                PLUNameColumn,
                UnitPriceColumn)
                VALUES
                (@ID,
                @ConnectionTypeID,
                @ConnectionParameterID,
                @DBObjectID,
                @DBObjectColumnMapID,
                @ConnectionType,
                @ConnString,
                @DBObjectName,
                @LFCodeColumn,
                @BarcodeColumn,
                @PLUNameColumn,
                @UnitPriceColumn)",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _clientDBSetup.ID);
                sqlCommand.Parameters.AddWithValue("@ConnectionTypeID", _clientDBSetup.ConnectionTypeID);
                sqlCommand.Parameters.AddWithValue("@ConnectionParameterID", _clientDBSetup.ConnectionParameterID);
                sqlCommand.Parameters.AddWithValue("@DBObjectID", _clientDBSetup.DBObjectID);
                sqlCommand.Parameters.AddWithValue("@DBObjectColumnMapID", _clientDBSetup.DBObjectColumnMapID);
                sqlCommand.Parameters.AddWithValue("@ConnectionType", _clientDBSetup.ConnectionType);
                sqlCommand.Parameters.AddWithValue("@ConnString", _clientDBSetup.ConnString);
                sqlCommand.Parameters.AddWithValue("@DBObjectName", _clientDBSetup.DBObjectName);
                sqlCommand.Parameters.AddWithValue("@LFCodeColumn", _clientDBSetup.LFCodeColumn);
                sqlCommand.Parameters.AddWithValue("@BarcodeColumn", _clientDBSetup.BarcodeColumn);
                sqlCommand.Parameters.AddWithValue("@PLUNameColumn", _clientDBSetup.PLUNameColumn);
                sqlCommand.Parameters.AddWithValue("@UnitPriceColumn", _clientDBSetup.UnitPriceColumn);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool InsertAppCompanySetup(AppCompanySetup _Param)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"INSERT INTO AppCompanySetup
                (ID,
                CompanyName,
                CompanyLogo,
                CompanyPhone,
                CompanyEmail,
                CompanyAddress,
                CompanyWebSite,
                CompanyCurrency,
                CompanyDecimalPlace)
                VALUES 
                (@ID,
                @CompanyName,
                @CompanyLogo,
                @CompanyPhone,
                @CompanyEmail,
                @CompanyAddress,
                @CompanyWebSite,
                @CompanyCurrency,
                @CompanyDecimalPlace)",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _Param.ID);
                sqlCommand.Parameters.AddWithValue("@CompanyName", _Param.CompanyName);
                sqlCommand.Parameters.AddWithValue("@CompanyLogo", _Param.CompanyLogo);
                sqlCommand.Parameters.AddWithValue("@CompanyPhone", _Param.CompanyPhone);
                sqlCommand.Parameters.AddWithValue("@CompanyEmail", _Param.CompanyEmail);
                sqlCommand.Parameters.AddWithValue("@CompanyAddress", _Param.CompanyAddress);
                sqlCommand.Parameters.AddWithValue("@CompanyWebSite", _Param.CompanyWebSite);
                sqlCommand.Parameters.AddWithValue("@CompanyCurrency", _Param.CompanyCurrency);
                sqlCommand.Parameters.AddWithValue("@CompanyDecimalPlace", _Param.CompanyDecimalPlace.ToString());


                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }
       
        public bool InsertAppPLUData(PLUDataDB _pludata)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"INSERT INTO AppPLUData
                (LFCode,Barcode,HotKey,PLUName,UnitPrice,BarcodeType,WeightUnit,QtyUnit,Department,Tare,ShelfTime,PackageType,PackageWeight,Tolerance,Message1,Message2,LabelID,Discount)
                VALUES(@LFCode,@Barcode,@HotKey,@PLUName,@UnitPrice,@BarcodeType,@WeightUnit,@QtyUnit,@Department,@Tare,@ShelfTime,@PackageType,@PackageWeight,@Tolerance,@Message1,@Message2,@LabelID,@Discount)",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@HotKey", _pludata.HotKey);
                sqlCommand.Parameters.AddWithValue("@PLUName", _pludata.PluName);
                sqlCommand.Parameters.AddWithValue("@LFCode", _pludata.LFCode);
                sqlCommand.Parameters.AddWithValue("@Barcode", _pludata.Code);
                sqlCommand.Parameters.AddWithValue("@UnitPrice", _pludata.UnitPrice);
                sqlCommand.Parameters.AddWithValue("@BarcodeType", 101);
                sqlCommand.Parameters.AddWithValue("@WeightUnit", _pludata.WeightUnit);
                sqlCommand.Parameters.AddWithValue("@QtyUnit", _pludata.QtyUnit);
                sqlCommand.Parameters.AddWithValue("@Department", _pludata.Deptment);
                sqlCommand.Parameters.AddWithValue("@Tare", _pludata.Tare);
                sqlCommand.Parameters.AddWithValue("@ShelfTime", _pludata.ShlefTime);
                sqlCommand.Parameters.AddWithValue("@PackageType", _pludata.PackageType);
                sqlCommand.Parameters.AddWithValue("@PackageWeight", _pludata.PackageWeight);
                sqlCommand.Parameters.AddWithValue("@Tolerance", _pludata.Tolerance);
                sqlCommand.Parameters.AddWithValue("@Message1", _pludata.Message1);
                sqlCommand.Parameters.AddWithValue("@Message2", _pludata.Message2);
                sqlCommand.Parameters.AddWithValue("@LabelID", _pludata.LabelId);
                sqlCommand.Parameters.AddWithValue("@Discount", _pludata.Rebate);



                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        private bool Insert(AppDBObjectColumnMap _appDBObjectColumnMap)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"INSERT INTO AppDBObjectColumnMap (ID,DBObjectID,LFCodeColumn,BarcodeColumn,PLUNameColumn,UnitPriceColumn) 
                VALUES(@ID,@DBObjectID,@LFCodeColumn,@BarcodeColumn,@PLUNameColumn,@UnitPriceColumn)",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appDBObjectColumnMap.ID);
                sqlCommand.Parameters.AddWithValue("@DBObjectID", _appDBObjectColumnMap.DBObjectID);
                sqlCommand.Parameters.AddWithValue("@LFCodeColumn", _appDBObjectColumnMap.LFCodeColumn);
                sqlCommand.Parameters.AddWithValue("@BarcodeColumn", _appDBObjectColumnMap.BarcodeColumn);
                sqlCommand.Parameters.AddWithValue("@PLUNameColumn", _appDBObjectColumnMap.PLUNameColumn);
                sqlCommand.Parameters.AddWithValue("@UnitPriceColumn", _appDBObjectColumnMap.UnitPriceColumn);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        //----------------------------

        public bool UpdateAppConnectionType(AppConnectionType _appConnectionType)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"UPDATE AppConnectionType SET ConnectionName=@ConnectionName,ConnectionType=@ConnectionType WHERE ID=@ID",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appConnectionType.ID);
                sqlCommand.Parameters.AddWithValue("@ConnectionName", _appConnectionType.ConnectionName);
                sqlCommand.Parameters.AddWithValue("@ConnectionType", _appConnectionType.ConnectionType);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool UpdateAppConnectionParameter(AppConnectionParameter _appConnectionParameter)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"UPDATE AppConnectionParameter SET DataSource=@DataSource,DBName=@DBName,LoginUserID=@LoginUserID,LoginPassword=@LoginPassword 
                WHERE ID=@ID AND AppConnectionTypeID=@AppConnectionTypeID",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appConnectionParameter.ID);
                sqlCommand.Parameters.AddWithValue("@AppConnectionTypeID", _appConnectionParameter.AppConnectionTypeID);
                sqlCommand.Parameters.AddWithValue("@DataSource", _appConnectionParameter.DataSource);
                sqlCommand.Parameters.AddWithValue("@DBName", _appConnectionParameter.DBName);
                sqlCommand.Parameters.AddWithValue("@LoginUserID", _appConnectionParameter.LoginUserID);
                sqlCommand.Parameters.AddWithValue("@LoginPassword", _appConnectionParameter.LoginPassword);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool UpdateAppDBObject(AppDBObject _appDBObject)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"UPDATE AppDBObject SET DBObjectName=@DBObjectName,DBObjectType=@DBObjectType WHERE ID=@ID",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appDBObject.ID);
                sqlCommand.Parameters.AddWithValue("@DBObjectName", _appDBObject.DBObjectName);
                sqlCommand.Parameters.AddWithValue("@DBObjectType", _appDBObject.DBObjectType);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool UpdateAppDBObjectColumnMap(AppDBObjectColumnMap _appDBObjectColumnMap)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"UPDATE AppDBObjectColumnMap SET LFCodeColumn=@LFCodeColumn,BarcodeColumn=@BarcodeColumn,PLUNameColumn=@PLUNameColumn,UnitPriceColumn=@UnitPriceColumn 
                WHERE ID=@ID AND DBObjectID=@DBObjectID",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appDBObjectColumnMap.ID);
                sqlCommand.Parameters.AddWithValue("@DBObjectID", _appDBObjectColumnMap.DBObjectID);
                sqlCommand.Parameters.AddWithValue("@LFCodeColumn", _appDBObjectColumnMap.LFCodeColumn);
                sqlCommand.Parameters.AddWithValue("@BarcodeColumn", _appDBObjectColumnMap.BarcodeColumn);
                sqlCommand.Parameters.AddWithValue("@PLUNameColumn", _appDBObjectColumnMap.PLUNameColumn);
                sqlCommand.Parameters.AddWithValue("@UnitPriceColumn", _appDBObjectColumnMap.UnitPriceColumn);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool UpdateAppDeviceMaster(AppDeviceMaster _appDeviceMaster)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"UPDATE AppDeviceMaster SET
                DeviceIP = @DeviceIP,
                DeviceName = @DeviceName,
                SourcePath = @SourcePath,
                DestinationPath = @DestinationPath,
                FileType = @FileType,
                ScrollText = @ScrollText,
                Lang = @Lang,
                IsUpdate = @IsUpdate,
                regsitration_date = @regsitration_date,
                expiry_date = @expiry_date,
                lic_product_id = @lic_product_id,
                lic_code = @lic_code,
                license_key = @license_key
                WHERE
                lic_customer_licesnse_Id = @lic_customer_licesnse_Id",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@DeviceID", _appDeviceMaster.DeviceID);
                sqlCommand.Parameters.AddWithValue("@DeviceIP", _appDeviceMaster.DeviceIP);
                sqlCommand.Parameters.AddWithValue("@DeviceName", _appDeviceMaster.DeviceName);
                sqlCommand.Parameters.AddWithValue("@SourcePath", _appDeviceMaster.SourcePath);
                sqlCommand.Parameters.AddWithValue("@DestinationPath", _appDeviceMaster.DestinationPath);
                sqlCommand.Parameters.AddWithValue("@FileType", _appDeviceMaster.FileType);
                sqlCommand.Parameters.AddWithValue("@ScrollText", _appDeviceMaster.ScrollText);
                sqlCommand.Parameters.AddWithValue("@Lang", _appDeviceMaster.Lang);
                sqlCommand.Parameters.AddWithValue("@IsUpdate", _appDeviceMaster.IsUpdate);
                sqlCommand.Parameters.AddWithValue("@regsitration_date", _appDeviceMaster.Regsitration_Date);
                sqlCommand.Parameters.AddWithValue("@expiry_date", _appDeviceMaster.Expiry_Date);
                sqlCommand.Parameters.AddWithValue("@lic_customer_licesnse_Id", _appDeviceMaster.Lic_Customer_Licesnse_Id);
                sqlCommand.Parameters.AddWithValue("@lic_product_id", _appDeviceMaster.Lic_Product_Id);
                sqlCommand.Parameters.AddWithValue("@lic_code", _appDeviceMaster.Lic_Code);
                sqlCommand.Parameters.AddWithValue("@license_key", _appDeviceMaster.License_Key);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool UpdatePegasusSettings(PegasusSettings _pegasusSettings)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"UPDATE PegasusSettings SET
                registrationcode = @registrationcode,
                email = @email,
                name = @name,
                companyname = @companyname,
                PhoneNumber = @PhoneNumber,
                versiontype = @versiontype,
                LicenseKey = @LicenseKey
                WHERE
                ID = @ID",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _pegasusSettings.ID);
                sqlCommand.Parameters.AddWithValue("@registrationcode", _pegasusSettings.RegisterationCode);
                sqlCommand.Parameters.AddWithValue("@email", _pegasusSettings.Email);
                sqlCommand.Parameters.AddWithValue("@name", _pegasusSettings.Name);
                sqlCommand.Parameters.AddWithValue("@companyname", _pegasusSettings.CompanyName);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", _pegasusSettings.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@versiontype", _pegasusSettings.VersionType);
                sqlCommand.Parameters.AddWithValue("@LicenseKey", _pegasusSettings.LicenseKey);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool UpdateAppLoginPararmeter(AppLoginPararmeter _appLoginPararmeter)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"UPDATE AppLoginPararmeter SET
                AppMode = @AppMode,
                UserID = @UserID,
                UserPassword = @UserPassword
                WHERE
                ID = @ID",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appLoginPararmeter.ID);
                sqlCommand.Parameters.AddWithValue("@AppMode", _appLoginPararmeter.AppMode);
                sqlCommand.Parameters.AddWithValue("@UserID", _appLoginPararmeter.UserID);
                sqlCommand.Parameters.AddWithValue("@UserPassword", _appLoginPararmeter.UserPassword);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool UpdateClientDBSetup(ClientDBSetup _clientDBSetup)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"UPDATE ClientDBSetup SET
                ConnectionTypeID = @ConnectionTypeID,
                ConnectionParameterID = @ConnectionParameterID,
                DBObjectID = @DBObjectID,
                DBObjectColumnMapID = @DBObjectColumnMapID,
                ConnectionType = @ConnectionType,
                ConnString = @ConnString,
                DBObjectName = @DBObjectName,
                LFCodeColumn = @LFCodeColumn,
                BarcodeColumn = @BarcodeColumn,
                PLUNameColumn = @PLUNameColumn,
                UnitPriceColumn = @UnitPriceColumn
                WHERE
                ID = @ID",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _clientDBSetup.ID);
                sqlCommand.Parameters.AddWithValue("@ConnectionTypeID", _clientDBSetup.ConnectionTypeID);
                sqlCommand.Parameters.AddWithValue("@ConnectionParameterID", _clientDBSetup.ConnectionParameterID);
                sqlCommand.Parameters.AddWithValue("@DBObjectID", _clientDBSetup.DBObjectID);
                sqlCommand.Parameters.AddWithValue("@DBObjectColumnMapID", _clientDBSetup.DBObjectColumnMapID);
                sqlCommand.Parameters.AddWithValue("@ConnectionType", _clientDBSetup.ConnectionType);
                sqlCommand.Parameters.AddWithValue("@ConnString", _clientDBSetup.ConnString);
                sqlCommand.Parameters.AddWithValue("@DBObjectName", _clientDBSetup.DBObjectName);
                sqlCommand.Parameters.AddWithValue("@LFCodeColumn", _clientDBSetup.LFCodeColumn);
                sqlCommand.Parameters.AddWithValue("@BarcodeColumn", _clientDBSetup.BarcodeColumn);
                sqlCommand.Parameters.AddWithValue("@PLUNameColumn", _clientDBSetup.PLUNameColumn);
                sqlCommand.Parameters.AddWithValue("@UnitPriceColumn", _clientDBSetup.UnitPriceColumn);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        public bool UpdateAppCompanySetup(AppCompanySetup _appDeviceMaster)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"UPDATE AppCompanySetup SET
                CompanyName=@CompanyName,
                CompanyLogo=@CompanyLogo,
                CompanyPhone=@CompanyPhone,
                CompanyEmail=@CompanyEmail,
                CompanyAddress=@CompanyAddress,
                CompanyWebSite=@CompanyWebSite,
                CompanyCurrency=@CompanyCurrency,
                CompanyDecimalPlace=@CompanyDecimalPlace
                WHERE
                ID = @ID",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appDeviceMaster.ID);
                sqlCommand.Parameters.AddWithValue("@CompanyName", _appDeviceMaster.CompanyName);
                sqlCommand.Parameters.AddWithValue("@CompanyLogo", _appDeviceMaster.CompanyLogo);
                sqlCommand.Parameters.AddWithValue("@CompanyPhone", _appDeviceMaster.CompanyPhone);
                sqlCommand.Parameters.AddWithValue("@CompanyEmail", _appDeviceMaster.CompanyEmail);
                sqlCommand.Parameters.AddWithValue("@CompanyAddress", _appDeviceMaster.CompanyAddress);
                sqlCommand.Parameters.AddWithValue("@CompanyWebSite", _appDeviceMaster.CompanyWebSite);
                sqlCommand.Parameters.AddWithValue("@CompanyCurrency", _appDeviceMaster.CompanyCurrency);
                sqlCommand.Parameters.AddWithValue("@CompanyDecimalPlace", _appDeviceMaster.CompanyDecimalPlace);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        private bool Update(AppDBObjectColumnMap _appDBObjectColumnMap)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"UPDATE AppDBObjectColumnMap SET LFCodeColumn=@LFCodeColumn,BarcodeColumn=@BarcodeColumn,PLUNameColumn=@PLUNameColumn,UnitPriceColumn=@UnitPriceColumn 
                WHERE ID=@ID AND DBObjectID=@DBObjectID",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                sqlCommand.Parameters.AddWithValue("@ID", _appDBObjectColumnMap.ID);
                sqlCommand.Parameters.AddWithValue("@DBObjectID", _appDBObjectColumnMap.DBObjectID);
                sqlCommand.Parameters.AddWithValue("@LFCodeColumn", _appDBObjectColumnMap.LFCodeColumn);
                sqlCommand.Parameters.AddWithValue("@BarcodeColumn", _appDBObjectColumnMap.BarcodeColumn);
                sqlCommand.Parameters.AddWithValue("@PLUNameColumn", _appDBObjectColumnMap.PLUNameColumn);
                sqlCommand.Parameters.AddWithValue("@UnitPriceColumn", _appDBObjectColumnMap.UnitPriceColumn);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        //----------------------------


        public bool DeleteAllAppDeviceMaster()
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"DELETE FROM AppDeviceMaster",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }
        public bool DeleteAllAppPLUData()
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"DELETE FROM AppPLUData",
                daCommon.ActiveConnection, daCommon.ActiveTransaction);

                int r = sqlCommand.ExecuteNonQuery();
                daCommon.CommitTrans();
                daCommon.CloseConnection();

                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }

        }

        //----------------------------


    }
}
