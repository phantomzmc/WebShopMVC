using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;

namespace Purchase
{
    public class Connection
    {
        #region Field
        private SqlConnection _conn;
        private string _connString;
        private string _dbsource;
        private string _username;
        private string _password;
        private string _port;
        private string _host;

        #endregion

        #region Properties
        public string ConnString
        {
            get { return _connString; }
            set { _connString = value; }
        }

        public SqlConnection SqlConnectionN
        {
            get { return _conn; }
            set { _conn = value; }
        }

        public string DataSource
        {
            get { return _dbsource; }
            set { _dbsource = value; }
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }
        #endregion

        public Connection()
        {
            this._dbsource = Properties.Settings.Default.DBSOURCE;
            this._username = Properties.Settings.Default.USERNAME;
            //Properties.Settings.Default.PASSWORD = DataSecurity.EncryptData("sukanun", "chadchai");
            //Properties.Settings.Default.Save();
            ////this._password = DataSecurity.DecryptData(Properties.Settings.Default.PASSWORD, this._username);
            this._password = Properties.Settings.Default.PASSWORD;
            this._host = Properties.Settings.Default.HOST;
            this._port = Properties.Settings.Default.Port;
            this._connString = "Data Source=" + this._host + "," + this._port + ";Network Library=DBMSSOCN;User ID=" + this._username + ";Password =" + this._password + ";Initial Catalog=" + this._dbsource;
            _conn = new SqlConnection(this._connString);
        }

        public void addInsertParameter(ref SqlDataAdapter adepter, string ParamName, DbType ParamDbtype, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParamName;
            param.DbType = ParamDbtype;
            if (value == null) { param.Value = DBNull.Value; }
            else if (value.ToString() == DateTime.MinValue.ToString())
            {
                param.Value = DBNull.Value;
            }
            else { param.Value = value; }
            adepter.InsertCommand.Parameters.Add(param);
        }

        public void addInsertParameter(ref SqlDataAdapter adepter, string ParamName, SqlDbType ParamDbtype, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParamName;
            param.SqlDbType = ParamDbtype;
            if (value == null) { param.Value = DBNull.Value; }
            else if (value.ToString() == DateTime.MinValue.ToString())
            {
                param.Value = DBNull.Value;
            }
            else { param.Value = value; }
            adepter.InsertCommand.Parameters.Add(param);
        }

        public void addUpdateParameter(ref SqlDataAdapter adepter, string ParamName, DbType ParamDbtype, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParamName;
            param.DbType = ParamDbtype;
            if (value == null) { param.Value = DBNull.Value; }
            else if (value.ToString() == DateTime.MinValue.ToString())
            {
                param.Value = DBNull.Value;
            }
            else { param.Value = value; }
            adepter.UpdateCommand.Parameters.Add(param);
        }

        public void addUpdateParameter(ref SqlDataAdapter adepter, string ParamName, SqlDbType ParamDbtype, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParamName;
            param.SqlDbType = ParamDbtype;
            if (value == null) { param.Value = DBNull.Value; }
            else if (value.ToString() == DateTime.MinValue.ToString())
            {
                param.Value = DBNull.Value;
            }
            else { param.Value = value; }
            adepter.UpdateCommand.Parameters.Add(param);
        }

        public void addDeleteParameter(ref SqlDataAdapter adepter, string ParamName, DbType ParamDbtype, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParamName;
            param.DbType = ParamDbtype;
            if (value == null) { param.Value = DBNull.Value; }

            else if (value.ToString() == DateTime.MinValue.ToString())
            {
                param.Value = DBNull.Value;
            }
            else { param.Value = value; }
            adepter.DeleteCommand.Parameters.Add(param);
        }

        public void addDeleteParameter(ref SqlDataAdapter adepter, string ParamName, SqlDbType ParamDbtype, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParamName;
            param.SqlDbType = ParamDbtype;
            if (value == null) { param.Value = DBNull.Value; }
            else if (value.ToString() == DateTime.MinValue.ToString())
            {
                param.Value = DBNull.Value;
            }
            else { param.Value = value; }
            adepter.DeleteCommand.Parameters.Add(param);
        }

        public SqlDataAdapter getAdapter(SqlDataAdapter da, Connection con, string SelectName, string InsertName, string UpdateName, string DeleteName)
        {
            da = new SqlDataAdapter(SelectName, con.SqlConnectionN);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.InsertCommand = new SqlCommand(InsertName, con.SqlConnectionN);
            da.UpdateCommand = new SqlCommand(UpdateName, con.SqlConnectionN);
            da.DeleteCommand = new SqlCommand(DeleteName, con.SqlConnectionN);
            da.InsertCommand.CommandType = CommandType.StoredProcedure;
            da.UpdateCommand.CommandType = CommandType.StoredProcedure;
            da.DeleteCommand.CommandType = CommandType.StoredProcedure;
            return da;
        }

        public void addSelectParameter(ref SqlDataAdapter adepter, string ParamName, DbType ParamDbtype, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParamName;
            param.DbType = ParamDbtype;
            if (value == null) { param.Value = DBNull.Value; }
            else if (value.ToString() == DateTime.MinValue.ToString())
            {
                param.Value = DBNull.Value;
            }
            else { param.Value = value; }
            adepter.SelectCommand.Parameters.Add(param);
        }

        public DataTable Select(SqlDataAdapter da)
        {
            da.SelectCommand.CommandTimeout = 0;
            DataTable dt = new DataTable();
            try
            {
                this.SqlConnectionN.Open();
                int result = da.SelectCommand.ExecuteNonQuery();
                da.Fill(dt);
            }
            catch (Exception)
            {
                //throw;
            }
            finally
            {
                this.SqlConnectionN.Close();
            }
            return dt;
        }

        public bool Insert(SqlDataAdapter da)
        {
            bool complete = false;
            DataTable dt = new DataTable();
            try
            {
                this.SqlConnectionN.Open();
                int result = da.InsertCommand.ExecuteNonQuery();
                if (result == -1)
                {
                    complete = true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                this.SqlConnectionN.Close();
            }
            return complete;
        }

        public bool update(SqlDataAdapter da)
        {
            bool complete = false;
            DataTable dt = new DataTable();
            try
            {
                this.SqlConnectionN.Open();
                int result = da.UpdateCommand.ExecuteNonQuery();
                if (result == -1)
                {
                    complete = true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                this.SqlConnectionN.Close();
            }
            return complete;
        }

        public bool delete(SqlDataAdapter da)
        {
            bool complete = false;
            DataTable dt = new DataTable();
            try
            {
                this.SqlConnectionN.Open();
                int result = da.DeleteCommand.ExecuteNonQuery();
                if (result == -1)
                {
                    complete = true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                this.SqlConnectionN.Close();
            }
            return complete;
        }
    }
}