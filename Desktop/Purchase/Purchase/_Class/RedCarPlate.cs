using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoomLibrary;
using System.Data;
using System.Data.SqlClient;

namespace Purchase
{
    public class RedCarPlate
    {

        private CStatement _statement;

        public int ID { get; set; }
        public DateTime RedCarPlate_DATE { get; set; }
        public string RedCarPlate_NO { get; set; }
        public decimal RedCarPlate_PRICE { get; set; }
        public string RedCarPlate_NUM { get; set; }

        public RedCarPlate()
        {
            this.ID = 0;
            this.RedCarPlate_DATE = DateTime.MinValue;
            this.RedCarPlate_NO = string.Empty;
            this.RedCarPlate_PRICE = 0;
            this.RedCarPlate_NUM = string.Empty;
            this._statement = new CStatement("uspSelectRedCarPlate", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);         
        }
        public void SelectRedCarPlate(int num)
        {
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@POID", DbType.Int32, num, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    DataTable dt = (DataTable)cstate.Execute(adlist);
                    var row = dt.Rows[0];
                    RedCarPlate_DATE = DateTime.Parse(row["RedCarPlate_Date"].ToString());
                    RedCarPlate_NO = row["RedCarPlate_No"].ToString();
                    RedCarPlate_PRICE = Decimal.Parse(row["RedCarplate_Price"].ToString());
                    RedCarPlate_NUM = row["RedCarPlate_Num"].ToString();
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
                RedCarPlate_DATE = DateTime.MinValue;
                RedCarPlate_NO = string.Empty;
                RedCarPlate_PRICE = 0;
                RedCarPlate_NUM = string.Empty;
            }

        }

    }
}