using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLS1000Utility.DataAccess
{
    public class SQLSystemDA : AbstractSystemDA
    {
        private DACommonSQL daCommon;
        SqlCommand command;
        SqlDataAdapter dataAdapter;

        public SQLSystemDA(SQLConnectionProperties _connectionProperties)
        {
            daCommon = DACommonSQL.GetInstance(_connectionProperties);
        }

        public override void Initialize(object _connectionProperties)
        {
            daCommon = DACommonSQL.GetInstance((SQLConnectionProperties)_connectionProperties);
        }

        public override bool OpenConnection()
        {
            return daCommon.OpenConnection(1);
        }

        public override void CloseConnection()
        {
            daCommon.CloseConnection();
        }

        public override void Dispose()
        {
            daCommon.Dispose();
        }

        public override Dictionary<string, string> DBObjectList()
        {
            try
            {
                daCommon.OpenConnection();

                command = new SqlCommand(
                @"SELECT TABLE_NAME,TABLE_TYPE FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME ",
                daCommon.ActiveConnection);
                dataAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dict.Add(Convert.ToString(dt.Rows[i][0]), Convert.ToString(dt.Rows[i][1]));
                    }
                    return dict;
                }
                else
                    return null;

                //return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override Dictionary<string, string> DBObjectColumnList(string Obj)
        {
            try
            {
                daCommon.OpenConnection();

                command = new SqlCommand(
                $"SELECT TABLE_NAME,COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='{Obj}' ORDER BY TABLE_NAME,COLUMN_NAME",
                daCommon.ActiveConnection);
                dataAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dict.Add(Convert.ToString(dt.Rows[i][1]), Convert.ToString(dt.Rows[i][0]));
                    }
                    return dict;
                }
                else
                    return null;

                //return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
