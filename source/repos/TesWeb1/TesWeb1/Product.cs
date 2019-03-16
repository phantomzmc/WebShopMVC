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
            try
            {
                SqlCommand sql_com = new SqlCommand("uspGetProduct", con);
                adapter.SelectCommand = sql_com;
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                con.Open();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach(DataRow items in dt.Rows)
                {
                    Product product = new Product()
                    {
                        ProductName = items["ProductName"].ToString()
                    };
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

        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string ProductDetail { get; set; }
            public int TypeID { get; set; }

            public Product() {}


        }
    }
}
    