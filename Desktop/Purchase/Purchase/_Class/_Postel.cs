using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _Postel
    {
        private CStatement _statement;

        public int ID { get; set; }
        public _DistrictList._District _District { get; set; }
        public string Postel_Code { get; set; }

        public _Postel()
        {
            this.ID = 0;
            this._District = new _DistrictList._District();
            this.Postel_Code = string.Empty;
            this._statement = new CStatement("Select_Postel", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        public void Select(int num, int District_ID)
        {
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@District_ID", DbType.Int32, District_ID, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    DataTable dt = (DataTable)cstate.Execute(adlist); ;

                    if (dt.Rows.Count > 0)
                    {
                        this.Postel_Code = dt.Rows[0]["Postel_Code"].ToString();
                    }

                    cstate.Commit();
                }
                catch (SqlException)
                {
                    cstate.Rollback();
                    throw;

                }
                finally
                {
                    cstate.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}