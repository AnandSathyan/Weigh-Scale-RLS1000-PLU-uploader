using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.DataAccess
{
    public class DACommonOLEDB : IDACommon
    {
        #region Properties

        private static object mutex = new object();
        private static DACommonOLEDB instance = null;
        private bool isTransactionStart;
        private static string conString;

        public OleDbConnection ActiveConnection { get; set; }
        public OleDbTransaction ActiveTransaction { get; set; }

        #endregion

        #region Constructor

        private DACommonOLEDB(string _conString)
        {
            conString = _conString;
            //Initialize();

        }

        public static DACommonOLEDB GetInstance(string _conString)
        {
            if (instance == null)
            {
                lock (mutex) // now I can claim some form of thread safety...
                {
                    if (instance == null)
                    {
                        instance = new DACommonOLEDB(_conString);
                    }
                }
            }

            return instance;
        }

        #endregion

        #region Common Functions

        public void Initialize()
        {
            try
            {
                //conString = conString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BeginTrans()
        {
            OpenConnection();
            if (isTransactionStart == false)
            {
                ActiveTransaction = ActiveConnection.BeginTransaction();
            }
            isTransactionStart = true;
        }

        public void CloseConnection()
        {
            if (ActiveConnection != null)
            {
                if (ActiveConnection.State == ConnectionState.Open)
                {
                    ActiveConnection.Close();
                }
            }
        }

        public bool CloseConnection(int i)
        {
            try
            {

                if (ActiveConnection != null)
                {
                    if (ActiveConnection.State == ConnectionState.Open)
                    {
                        ActiveConnection.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void EndTrans()
        {
            throw new NotImplementedException();
        }

        public object GetActiveConnection()
        {
            return ActiveConnection;
        }

        public object GetActiveTranscation()
        {
            return ActiveTransaction;
        }

        public void OpenConnection()
        {
            if (ActiveConnection != null)
            {
                if (ActiveConnection.State == ConnectionState.Closed)
                {
                    ActiveConnection.Open();
                }
            }
            else
            {
                ActiveConnection = new OleDbConnection(conString);

                ActiveConnection.Open();
            }
        }

        public bool OpenConnection(int i)
        {
            try
            {

                if (ActiveConnection != null)
                {
                    if (ActiveConnection.State == ConnectionState.Closed)
                    {
                        ActiveConnection.Open();
                    }
                }
                else
                {
                    ActiveConnection = new OleDbConnection(conString);

                    ActiveConnection.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void CommitTrans()
        {
            if (isTransactionStart)
            {
                ActiveTransaction.Commit();
                isTransactionStart = false;
            }
        }

        public void RollBackTrans()
        {
            if (isTransactionStart)
            {
                ActiveTransaction.Rollback();
                isTransactionStart = false;
            }
        }

        public void Dispose()
        {
            instance = null;
        }

        //public static void Dispose(int i)
        //{
        //    instance = null;
        //}

        #endregion
    }
}
