using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using NoomLibrary;

namespace TesWeb1
{

    public class OrderList : IDictionary<int, OrderList.Order>
    {
        private CStatement _statememet;

        public Dictionary<int, OrderList.Order> _orderlist = new Dictionary<int, OrderList.Order>();

        public OrderList()
        {
            this._statememet = new CStatement("uspGetOrder", "uspAddOrder", "uspUpdateOrder", "uspDelOrder", System.Data.CommandType.StoredProcedure);
        }

        public void selectOrders()
        {
            object result = null;
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                //plist.Add("@OrderID", DbType.Int32, 24, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();

                result = cstate.Execute(adlist);
                DataTable dt = (DataTable)result;

                this._orderlist = dt.ToDictionary<int, Order>("OrderID");
                cstate.Commit();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                cstate.Rollback();
            }
            finally
            {
                cstate.Close();
            }
        }
        public void addOrder(int proid, int qty, int price, int userid, DateTime ordertime)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@ProductID", DbType.Int32, proid, ParameterDirection.Input);
                plist.Add("@OrderQty", DbType.Int32, qty, ParameterDirection.Input);
                plist.Add("@OrderPrice", DbType.Int32, price, ParameterDirection.Input);
                plist.Add("@UserID", DbType.Int32, userid, ParameterDirection.Input);
                plist.Add("@OrderTime", DbType.DateTime, ordertime, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Insert);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

                //DataTable dt = (DataTable)result;

                //this._orderlist = dt.ToDictionary<int, Order>("OrderID");
                cstate.Commit();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                cstate.Rollback();
            }
            finally
            {
                cstate.Close();
            }
        }
        public void editOrder(int proid, int qty, int price, int userid, DateTime ordertime)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();

                plist.Add("@ProductID", DbType.Int32, proid, ParameterDirection.Input);
                plist.Add("@OrderQty", DbType.Int32, qty, ParameterDirection.Input);
                plist.Add("@OrderPrice", DbType.Int32, price, ParameterDirection.Input);
                plist.Add("@UserID", DbType.Int32, userid, ParameterDirection.Input);
                plist.Add("@OrderTime", DbType.Int32, ordertime, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Insert);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

                //DataTable dt = (DataTable)result;

                //this._orderlist = dt.ToDictionary<int, Order>("OrderID");
                cstate.Commit();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                cstate.Rollback();
            }
            finally
            {
                cstate.Close();
            }
        }

        //public void selectOrders()
        //{
        //    SqlConnection con = new SqlConnection(Connection.CSQLConnection);
        //    SqlDataAdapter adapter = new SqlDataAdapter();
        //    SqlCommand sql_com = new SqlCommand("uspGetOrder", con);
        //    DataTable dt = new DataTable();
        //    try
        //    {

        //        con.Open();
        //        adapter.SelectCommand = sql_com;
        //        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        adapter.Fill(dt);

        //        foreach (DataRow item in dt.Rows)
        //        {
        //            Order orders = new Order()
        //            {
        //                OrderTime = Convert.ToDateTime(item["OrderTime"].ToString()),
        //                OrderID = int.Parse(item["OrderID"].ToString()),
        //                ProductName = item["ProductName"].ToString(),
        //                ProductPrice = int.Parse(item["ProductPrice"].ToString()),
        //                OrderPrice = int.Parse(item["OrderPrice"].ToString()),
        //                FirstName = item["FirstName"].ToString(),
        //                LastName = item["LastName"].ToString(),
        //                OrderQty = int.Parse(item["OrderQty"].ToString()),

        //            };
        //            _orderlist.Add(orders.OrderID, orders);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string error = ex.Message;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}


        #region Imprememt
        public Order this[int key] {
            get
            {
                return (Order)_orderlist[key];
            }
            set
            {
                _orderlist[key] = value;
            }

        }

        public ICollection<int> Keys => this._orderlist.Keys.OfType<int>().ToList();

        public ICollection<Order> Values => this._orderlist.Values.OfType<Order>().ToList();

        public int Count => this._orderlist.Count;

        public bool IsReadOnly { get; }

        public void Add(int key, Order value)
        {
            this._orderlist.Add(key, value);
        }

        public void Add(KeyValuePair<int, Order> item)
        {
            this._orderlist.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._orderlist.Clear();
        }

        public bool Contains(KeyValuePair<int, Order> item)
        {
            return this.Contains(item);
        }

        public bool ContainsKey(int key)
        {
            return this._orderlist.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<int, Order>[] array, int arrayIndex)
        {
            
        }

        public IEnumerator<KeyValuePair<int, Order>> GetEnumerator()
        {
            return this._orderlist.GetEnumerator();
        }

        public bool Remove(int key)
        {
            return this.Remove(key);
        }

        public bool Remove(KeyValuePair<int, Order> item)
        {
            return this._orderlist.Remove(item.Key);
        }

        public bool TryGetValue(int key, out Order value)
        {
            return this._orderlist.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._orderlist.GetEnumerator();
        }
        #endregion
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
            public Order(int orderid) { OrderID = orderid; }
            public Order(int proid, int orderqty, int orderprice, int userid, DateTime ordertime) { }
            public Order(int proid, string productname, int productprice, string firstname, string lastname, int orderqty, int orderprice, DateTime ordertime) { }

            //public DataSet selectOrder()
            //{
            //    SqlCommand sql_com = new SqlCommand("uspGetOrder", con);
            //    DataSet dt = new DataSet();
            //    try
            //    {
            //        adapter.SelectCommand = sql_com;
            //        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            //        con.Open();
            //        adapter.Fill(dt);
            //    }
            //    catch (Exception ex)
            //    {
            //        string error = ex.Message;
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }
            //    return dt;
            //}
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

            public int delOrder(int id)
            {
                SqlCommand sql_com = new SqlCommand("uspDelOrder", con);
                adapter.DeleteCommand = sql_com;
                adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                adapter.DeleteCommand.Parameters.AddWithValue("@OrderID", id);

                con.Open();
                int res = adapter.DeleteCommand.ExecuteNonQuery();
                con.Close();

                return res;
            }
            public void editOrder()
            {
                SqlCommand sql_com = new SqlCommand("uspUpdateOrder", con);
                adapter.UpdateCommand = sql_com;
                adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                adapter.UpdateCommand.Parameters.AddWithValue("@ProductName", ProductName);
            }
        }     
    }
}
