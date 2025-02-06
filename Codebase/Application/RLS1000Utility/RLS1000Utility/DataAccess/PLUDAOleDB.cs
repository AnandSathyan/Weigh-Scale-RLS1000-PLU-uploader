using System;
using System.Data;
using System.Data.OleDb;

namespace RLS1000Utility.DataAccess
{
    public class PLUDAOleDB
    {
        private DACommonOLEDB daCommonSQL;
        OleDbCommand sqlCommand;
        OleDbDataAdapter sqlDataAdapter;
        public PLUDAOleDB(string _connString)
        {
            daCommonSQL = DACommonOLEDB.GetInstance(_connString);
        }

        public bool OpenConnection()
        {
            return daCommonSQL.OpenConnection(1);
        }

        public void CloseConnection()
        {
            daCommonSQL.CloseConnection();
        }


        public DataTable GetAllPLUData(string _command)
        {
            try
            {
                daCommonSQL.OpenConnection();

                sqlCommand = new OleDbCommand(_command,
                daCommonSQL.ActiveConnection);
                sqlDataAdapter = new OleDbDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }

        }

    }
}
