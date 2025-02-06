using RLS1000Utility.DeviceUtility;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace RLS1000Utility.DataAccess
{
    public class PLUDASqLite
    {
        private DACommonSqLite daCommon;
        SQLiteCommand sqlCommand;
        SQLiteDataAdapter sqlDataAdapter;
        public PLUDASqLite()
        {
            daCommon = DACommonSqLite.GetInstance(new SqLiteConnectionProperties());
            InitDB();
        }

        private void InitDB()
        {

            try
            {
                if (!File.Exists(@"RLWScale.db"))
                {
                    SQLiteConnection.CreateFile(@"RLWScale.db");
                }

                daCommon.OpenConnection();
                sqlCommand = new SQLiteCommand(
                @"SELECT name FROM sqlite_master WHERE name='tb_RLWPLUData'",
                daCommon.ActiveConnection);
                var name = sqlCommand.ExecuteScalar();

                // check account table exist or not 
                // if exist do nothing 
                if (name != null && name.ToString() == "tb_RLWPLUData")
                    return;

                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"CREATE TABLE tb_RLWPLUData(
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

            }
            catch (Exception ex)
            {
                daCommon.RollBackTrans();
                throw ex;
            }
        }


        public DataTable GetAllPLUData()
        {
            try
            {
                daCommon.OpenConnection();

                sqlCommand = new SQLiteCommand(
                @"SELECT LFCode,Barcode,HotKey,PLUName,UnitPrice,BarcodeType,WeightUnit,QtyUnit,Department,Tare,ShelfTime,PackageType,PackageWeight
                ,Tolerance,Message1,Message2,LabelID,Discount FROM tb_RLWPLUData",
                daCommon.ActiveConnection);
                sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool InsertPLUData(Pludata _pludata)
        {
            try
            {

                daCommon.OpenConnection();
                daCommon.BeginTrans();

                sqlCommand = new SQLiteCommand(
                @"INSERT INTO tb_RLWPLUData
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
    }
}
