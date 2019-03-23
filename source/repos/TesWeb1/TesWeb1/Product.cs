using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TesWeb1
{
    public class ProductList : IDictionary<int, ProductList.Product>
    {
        public Dictionary<int, ProductList.Product> productlist = new Dictionary<int, ProductList.Product>();

        SqlConnection con = new SqlConnection(Properties.Resources.ConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();

        public ProductList() { }
        public ProductList(string select, int typeid) { }

        public string Select { get; set; }
        public int TypeID { get; set; }

        #region Imprement
        public Product this[int key]
        {
            get
            {
                return (Product)productlist[key];
            }
            set
            {
                productlist[key] = value;
            }
        }

        public ICollection<int> Keys => this.productlist.Keys.OfType<int>().ToList();

        public ICollection<Product> Values => this.productlist.Values.OfType<Product>().ToList();

        public int Count => this.productlist.Count;

        public bool IsReadOnly { get; }

        public void Add(int key, Product value)
        {
            this.productlist.Add(key, value);
        }

        public void Add(KeyValuePair<int, Product> item)
        {
            this.productlist.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this.productlist.Clear();
        }

        public bool Contains(KeyValuePair<int, Product> item)
        {
            return this.productlist.Contains(item);
        }

        public bool ContainsKey(int key)
        {
            return this.productlist.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<int, Product>[] array, int arrayIndex)
        {

        }

        public IEnumerator<KeyValuePair<int, Product>> GetEnumerator()
        {
            return this.productlist.GetEnumerator();
        }

        public bool Remove(int key)
        {
            return this.productlist.Remove(key);
        }

        public bool Remove(KeyValuePair<int, Product> item)
        {
            return this.productlist.Remove(item.Key);
        }

        public bool TryGetValue(int key, out Product value)
        {
            return this.productlist.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.productlist.GetEnumerator();
        }

        #endregion

        public void selectProduct()
        {
            SqlCommand sql_com = new SqlCommand("uspGetProduct", con);
            DataTable dt = new DataTable();
            Product product = new Product();
            try
            {
                con.Open();
                adapter.SelectCommand = sql_com;
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    product = new Product()
                    {
                        ProductID = int.Parse(item["ProductID"].ToString()),
                        ProductName = item["ProductName"].ToString(),
                        ProductPrice = int.Parse(item["ProductPrice"].ToString()),
                        ProductDatail = item["ProductDatail"].ToString(),
                        TypeID = int.Parse(item["TypeID"].ToString())

                    };
                    productlist.Add(product.ProductID, product);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void selectType()
        {
            SqlCommand sql_com = new SqlCommand("uspGetTypeProduct", con);
            DataTable dt = new DataTable();
            try
            {
                adapter.SelectCommand = sql_com;
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                adapter.Fill(dt);

                foreach(DataRow items in dt.Rows)
                {
                    Product product = new Product()
                    {
                        TypeID = int.Parse(items["TypeID"].ToString()),
                        TypeName = items["TypeName"].ToString(),
                        TypeDetail = items["TypeDetail"].ToString()
                    };
                    productlist.Add(product.TypeID, product);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                con.Close();

            }

        }

        public void selectProductType()
        {
            SqlCommand sql_com = new SqlCommand("uspGetProductType", con);
            DataTable dt = new DataTable();
            Product product = new Product();
            try
            {
                con.Open();
                adapter.SelectCommand = sql_com;
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Select", "Type");
                adapter.SelectCommand.Parameters.AddWithValue("@TypeID", 3);

                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    product = new Product()
                    {
                        ProductID = int.Parse(item["ProductID"].ToString()),
                        ProductName = item["ProductName"].ToString(),
                        ProductPrice = int.Parse(item["ProductPrice"].ToString()),
                        ProductDatail = item["ProductDatail"].ToString(),
                        TypeID = int.Parse(item["TypeID"].ToString())

                    };
                    productlist.Add(product.ProductID, product);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public class Product
        {
            SqlConnection con = new SqlConnection(Properties.Resources.ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string ProductDatail { get; set; }
            public int ProductPrice { get; set; }
            public int TypeProduct { get; set; } // TypeID
            public int TypeID { get; set; }
            public string TypeName { get; set; }
            public string TypeDetail { get; set; }
            public string Select { get; set; }
            

            public Product() {}
            public Product(int proid) { }
            public Product(string name, int price, string detail, int type) { }
            public Product(int proid,string name, int price, string detail, int type) { }
            public Product(string typename, string typedetail) { }
            public Product(int typeid, string typename, string typedetail) { }


            //public DataSet selectProduct()
            //{
            //    SqlCommand sql_com = new SqlCommand("uspGetProduct", con);
            //    adapter.SelectCommand = sql_com;
            //    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    adapter.SelectCommand.Parameters.AddWithValue("@Select", Select);
            //    adapter.SelectCommand.Parameters.AddWithValue("@TypeID", TypeID);
            //    con.Open();
            //    DataSet dt = new DataSet();
            //    adapter.Fill(dt);
            //    con.Close();

            //    return dt;
            //}
            //public DataSet selectType()
            //{
            //    SqlCommand sql_com = new SqlCommand("uspGetTypeProduct", con);
            //    adapter.SelectCommand = sql_com;
            //    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            //    con.Open();
            //    DataSet dt = new DataSet();
            //    adapter.Fill(dt);
            //    con.Close();

            //    return dt;
            //}
            public int addProduct()
            {
                SqlCommand sql_com = new SqlCommand("uspAddProduct", con);
                adapter.InsertCommand = sql_com;
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.AddWithValue("@ProductName", ProductName);
                adapter.InsertCommand.Parameters.AddWithValue("@ProductDetail", ProductDatail);
                adapter.InsertCommand.Parameters.AddWithValue("@ProductPrice", ProductPrice);
                adapter.InsertCommand.Parameters.AddWithValue("@TypeProduct", TypeProduct);

                con.Open();
                int res = adapter.InsertCommand.ExecuteNonQuery();
                con.Close();

                return res;

            }
            public void addTypeProduct()
            {
                SqlCommand sql_com = new SqlCommand("uspAddProductType", con);
                adapter.InsertCommand = sql_com;
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.AddWithValue("@TypeName", TypeName);
                adapter.InsertCommand.Parameters.AddWithValue("@TypeDetail", TypeDetail);

                con.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                con.Close();
            }

            public int editProduct()
            {
                SqlCommand sql_com = new SqlCommand("uspUpdateProduct", con);
                adapter.UpdateCommand = sql_com;
                adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                adapter.UpdateCommand.Parameters.AddWithValue("@ProductID", ProductID);
                adapter.UpdateCommand.Parameters.AddWithValue("@ProductName", ProductName);
                adapter.UpdateCommand.Parameters.AddWithValue("@ProductPrice", ProductPrice);
                adapter.UpdateCommand.Parameters.AddWithValue("@ProductDetail", ProductDatail);
                adapter.UpdateCommand.Parameters.AddWithValue("@TypeProduct", TypeProduct);

                con.Open();
                int res = adapter.UpdateCommand.ExecuteNonQuery();
                con.Close();

                return res;
            }
            public void editTypeProduct()
            {
                SqlCommand sql_com = new SqlCommand("uspUpdateTypeProduct", con);
                adapter.UpdateCommand = sql_com;
                adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                adapter.UpdateCommand.Parameters.AddWithValue("@TypeID", TypeID);
                adapter.UpdateCommand.Parameters.AddWithValue("@TypeName", TypeName);
                adapter.UpdateCommand.Parameters.AddWithValue("@TypeDetail", TypeDetail);

                con.Open();
                adapter.UpdateCommand.ExecuteNonQuery();
                con.Close();

            }
            public int deleteProduct()
            {
                SqlCommand sql_com = new SqlCommand("uspDelProduct", con);
                adapter.DeleteCommand = sql_com;
                adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                adapter.DeleteCommand.Parameters.AddWithValue("@ProductID", ProductID);

                con.Open();
                int res = adapter.DeleteCommand.ExecuteNonQuery();
                con.Close();

                return res;
            }

            public void deleteTypeProduct()
            {
                SqlCommand sql_com = new SqlCommand("uspDelTypeProduct", con);
                adapter.DeleteCommand = sql_com;
                adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                adapter.DeleteCommand.Parameters.AddWithValue("@TypeID", TypeID);

                con.Open();
                adapter.DeleteCommand.ExecuteNonQuery();
                con.Close();
            }
            public DataTable getProduct()
            {
                SqlCommand sql_com = new SqlCommand("uspSelectProduct", con);
                adapter.SelectCommand = sql_com;
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@ProductID", ProductID);

                con.Open();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();

                return dt;
            }
        }
    }
}
