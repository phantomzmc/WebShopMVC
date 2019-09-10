using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Purchase._Class;
using NoomLibrary;

namespace Purchase._Class
{
    public class _BodyClass
    {
            private CStatement _statement;
            private CStatement _statement1;

            public int Body_Acc_ID { get; set; }
            public int Body_Company_ID { get; set; }
            public string Body_Acc_Name { get; set; }
            public int Body_Model_ID { get; set; }
            public decimal Body_Model_price { get; set; }
            public string Mcode { get; set; }
            public int Body_Option_ID { get; set; }
            public string Body_Option_Name { get; set; }
            public decimal Body_Option_price { get; set; }
            public string finance { get; set; }


            public _BodyClass()
            {
                this.Body_Acc_ID = 0;
                this.Body_Company_ID = 0;
                this.Body_Acc_Name = string.Empty;
                this.Body_Model_ID = 0;
                this.Body_Model_price = 0;
                this.Mcode = string.Empty;
                this.Body_Option_ID = 0;
                this.Body_Option_Name = string.Empty;
                this.Body_Option_price = 0;
                this.finance = string.Empty;
                this._statement = new CStatement("Body_Select_Accessories", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
                this._statement1 = new CStatement("Body_Select_Option_price", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            }

            public DataTable SelectChk(string MCode)
            {
                CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
                try
                {
                    try
                    {
                        CSQLParameterList plistChk = new CSQLParameterList();
                        plistChk.Add("@MCode", DbType.String, MCode, ParameterDirection.Input);
                        CSQLDataAdepterList adlistChk = new CSQLDataAdepterList();
                        CSQLStatementValue csvChk = new CSQLStatementValue(this._statement, plistChk, NoomLibrary.StatementType.Select);
                        adlistChk.Add(csvChk);
                        cstate.Open();
                        DataTable dt = (DataTable)cstate.Execute(adlistChk); ;

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
                return dt;
            }

    }
}