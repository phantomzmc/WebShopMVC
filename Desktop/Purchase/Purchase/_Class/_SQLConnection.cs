using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoomLibrary;

namespace Purchase
{
    public class _SQLConnection
    {
        public static CSQLConnection CSQLConnection
        {
            get { return new CSQLConnection(Properties.Settings.Default.HOST, Properties.Settings.Default.Port, Properties.Settings.Default.USERNAME, Properties.Settings.Default.PASSWORD, Properties.Settings.Default.DBSOURCE); }

        }
    }
}