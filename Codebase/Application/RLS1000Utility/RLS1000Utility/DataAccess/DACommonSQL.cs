using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace RLS1000Utility.DataAccess
{
    public class DACommonSQL : IDACommon
    {
        #region Properties

        private static object mutex = new object();
        private static DACommonSQL instance = null;
        private bool isTransactionStart;
        private static string conString;
        private static SQLConnectionProperties sQLConnectionProperties;

        public SqlConnection ActiveConnection { get; set; }
        public SqlTransaction ActiveTransaction { get; set; }

        #endregion

        #region Constructor

        private DACommonSQL(SQLConnectionProperties _sQLConnectionProperties)
        {
            conString = ConfigurationManager.ConnectionStrings["ConnectSQL"].ConnectionString;
            sQLConnectionProperties = _sQLConnectionProperties;
            //Initialize();

        }

        public static DACommonSQL GetInstance(SQLConnectionProperties _sQLConnectionProperties)
        {
            if (instance == null)
            {
                lock (mutex) // now I can claim some form of thread safety...
                {
                    if (instance == null)
                    {
                        instance = new DACommonSQL(_sQLConnectionProperties);
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
                var connectionStringBuilder = new SqlConnectionStringBuilder(conString);
                connectionStringBuilder.DataSource = sQLConnectionProperties.ServerInstance;
                connectionStringBuilder.InitialCatalog = sQLConnectionProperties.Database;
                connectionStringBuilder.UserID = sQLConnectionProperties.UserID;
                connectionStringBuilder.Password = sQLConnectionProperties.Password;
                conString = connectionStringBuilder.ToString();

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
                ActiveConnection = new SqlConnection(conString);

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
                    ActiveConnection = new SqlConnection(conString);

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
