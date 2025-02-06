using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLS1000Utility.DataAccess
{
    public class DACommonConfigSqLite : IDACommon
    {
        #region Properties

        private static object mutex = new object();
        private static DACommonConfigSqLite instance = null;
        private bool isTransactionStart;
        private static string conString;
        private static SqLiteConnectionProperties sqLiteConnectionProperties;

        public SQLiteConnection ActiveConnection { get; set; }
        public SQLiteTransaction ActiveTransaction { get; set; }

        #endregion

        #region Constructor

        private DACommonConfigSqLite(SqLiteConnectionProperties _sqLiteConnectionProperties)
        {
            conString = ConfigurationManager.ConnectionStrings["ConnectConfig"].ConnectionString;
            sqLiteConnectionProperties = _sqLiteConnectionProperties;
        }

        public static DACommonConfigSqLite GetInstance(SqLiteConnectionProperties _sqLiteConnectionProperties)
        {
            if (instance == null)
            {
                lock (mutex) // now I can claim some form of thread safety...
                {
                    if (instance == null)
                    {
                        instance = new DACommonConfigSqLite(_sqLiteConnectionProperties);
                    }
                }
            }

            return instance;
        }

        #endregion

        #region Common Functions

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

        public void Initialize()
        {
            try
            {
                var connectionStringBuilder = new SQLiteConnectionStringBuilder(conString);
                connectionStringBuilder.DataSource = sqLiteConnectionProperties.DataSource;
                connectionStringBuilder.Password = sqLiteConnectionProperties.Password;
                conString = connectionStringBuilder.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                ActiveConnection = new SQLiteConnection(conString);

                ActiveConnection.Open();
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

        #endregion
    }
}
