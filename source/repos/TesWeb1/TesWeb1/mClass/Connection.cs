using NoomLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TesWeb1
{
    public class Connection
    {
        private SqlConnection _conn;
        private string _constr;

        public SqlConnection SqlConnectioN
        {
            get { return _conn; }
            set { _conn = value; }
        }
        public Connection()
        {
            this._constr = "Data Source=" + Properties.Settings.Default.HOST + ","
                + Properties.Settings.Default.PORT + ";Network Library=DBMSSOCN;User ID="
                + Properties.Settings.Default.USERNAME + ";Password ="
                + Properties.Settings.Default.PASSWORD
                + ";Initial Catalog=" + Properties.Settings.Default.DB;
            _conn = new SqlConnection(this._constr);
        }

        public static CSQLConnection CSQLConnection
        {
            get
            {
                return new CSQLConnection(Properties.Settings.Default.HOST
                , Properties.Settings.Default.PORT
                , Properties.Settings.Default.USERNAME
                , Properties.Settings.Default.PASSWORD
                , Properties.Settings.Default.DB);
            }
        }
    }
}