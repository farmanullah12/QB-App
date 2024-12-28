using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace QBranchApp.DAL
{
    class DatabaseAccess
    {
        public static SqlConnection conn;

        private static SqlConnection ConnOpen()
        {
            if (conn == null)
            {
                conn = new SqlConnection("data source=.; database=QBranch; user id=sa; password=123");
            }
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }


        public static bool Insert(string query)
        {
            try
            {
                int noofrows = 0;
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                noofrows = cmd.ExecuteNonQuery();
                if (noofrows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public static bool Update(string query)
        {
            try
            {
                int noofrows = 0;
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                noofrows = cmd.ExecuteNonQuery();
                if (noofrows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(string query)
        {
            try
            {
                int noofrows = 0;
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                noofrows = cmd.ExecuteNonQuery();
                if (noofrows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public static DataTable Retrieve(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                //int noofrows = 0;
                SqlDataAdapter da = new SqlDataAdapter(query, ConnOpen());
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        private SqlConnection connector;
        private string connn;
        private SqlCommand command;
        private SqlDataReader dr;
        private SqlDataAdapter da;
        private DataTable data;
        public static string u;
        public static string p;

        public DatabaseAccess()
        {
            string setting = ConfigurationManager.AppSettings["setting1"];
            connn = ConfigurationManager.ConnectionStrings["HitachiConf"].ConnectionString;
            connector = new SqlConnection(connn);
        }

        public DataTable Select_SP_Executer(string spname)
        {
            command = new SqlCommand(spname, connector);
            command.CommandType = CommandType.StoredProcedure;
            if (connector.State == ConnectionState.Closed)
                connector.Open();
            dr = command.ExecuteReader();
            data = new DataTable();
            data.Load(dr);
            dr.Close();
            connector.Close();
            return data;
        }

        public DataTable LoadData(string procName)
        {

            SqlDataAdapter da = new SqlDataAdapter(procName, conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable tabl = new DataTable();
            da.Fill(tabl);
            return tabl;
        }

        public DataSet GetDataFillCombo(string spname, SqlParameter SPParameter)
        {
            SqlDataAdapter da = new SqlDataAdapter(spname, conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (SPParameter != null)
            {
                da.SelectCommand.Parameters.Add(SPParameter);
            }

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataTable getData(string procedureName, List<object> parameters, List<object> values)
        {
            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procedureName;
            command.Connection = connector;
            data = null;
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    command.Parameters.Add(new SqlParameter(parameters[i].ToString(), values[i]));
                }
            }
            if (connector.State == ConnectionState.Closed)
                connector.Open();
            data = new DataTable();
            data.Load(command.ExecuteReader());
            connector.Close();
            return data;
        }

        public void dmloperation(string procedureName, List<object> parameters, List<object> values)
        {

            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procedureName;
            command.Connection = connector;
            for (int i = 0; i < parameters.Count; i++)
            {
                command.Parameters.Add(new SqlParameter(parameters[i].ToString(), values[i]));
            }
            if (connector.State == ConnectionState.Closed)
                connector.Open();

            command.ExecuteNonQuery();
            connector.Close();

        }

        public void checkConnection()
        {
            if (connector.State == ConnectionState.Closed)
            {
                connector.Open();
            }
        }

        public bool existorNot(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, connector);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
                return true;
            else
                return false;
        }

        public void dmlquery(string query)
        {
            command = new SqlCommand(query, connector);
            connector.Open();
            command.ExecuteNonQuery();
            connector.Close();
        }

        //Load MAX number
        public int LOADID(string qry)
        {
            try
            {
                command = new SqlCommand(qry, connector);
                connector.Close();
                connector.Open();
                int x = (int)command.ExecuteScalar();
                return x;
            }
            finally
            {
                connector.Close();

            }

        }

        public DataTable fillcombo(string q)
        {
            DataTable dt = new DataTable();
            //try
            //{
            da = new SqlDataAdapter(q, connector);
            da.Fill(dt);
            //}
            //catch (Exception b)
            //{
            //    MessageBox.Show("Something Goes Wrong!");
            //}
            return dt;
        }
    }
}
