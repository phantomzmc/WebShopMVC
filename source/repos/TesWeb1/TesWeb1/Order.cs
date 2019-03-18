using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TesWeb1
{
    public class Order
    {

        SqlConnection con = new SqlConnection(Properties.Resources.ConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();

        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrderQty { get; set; }
        public int OrderPrice { get; set; }
        public DateTime OrderTime { get; set; }

        public Order() { }
        public Order(string proid, int orderqty, int orderprice, int userid, DateTime ordertime) { }

        public DataTable selectOrder()
        {
            SqlCommand sql_com = new SqlCommand("uspGetOrder", con);
            DataTable dt = new DataTable();
            try
            {
                adapter.SelectCommand = sql_com;
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                con.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                con.Close();               
            }
            return dt;
        }
        public int addOrder()
        {
            SqlCommand sql_com = new SqlCommand("uspAddOrder", con);
            adapter.InsertCommand = sql_com;
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter.InsertCommand.Parameters.AddWithValue("@ProductID", ProductID);
            adapter.InsertCommand.Parameters.AddWithValue("@OrderQty", OrderQty);
            adapter.InsertCommand.Parameters.AddWithValue("@OrderPrice", OrderPrice);
            adapter.InsertCommand.Parameters.AddWithValue("@UserID", UserID);
            adapter.InsertCommand.Parameters.AddWithValue("@OrderTime", OrderTime);

            con.Open();
            int res = adapter.InsertCommand.ExecuteNonQuery();
            con.Close();

            return res;
        }
    }
}
