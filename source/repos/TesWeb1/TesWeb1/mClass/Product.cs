using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace TesWeb1
{
    public class ProductList : IDictionary<int, ProductList.Product>
    {
        private CStatement _statememet, _statememetType;

        public Dictionary<int, ProductList.Product> productlist = new Dictionary<int, ProductList.Product>();
        public ProductList()
        {
            this._statememet = new CStatement("uspGetProduct", "uspAddProduct", "uspUpdateProduct", "uspDelProduct", System.Data.CommandType.StoredProcedure);
            this._statememetType = new CStatement("uspGetTypeProduct", "uspAddTypeProduct", "uspUpdateTypeProduct", "uspDelTypeProduct", System.Data.CommandType.StoredProcedure);
        }

        SqlConnection con = new SqlConnection(Properties.Resources.ConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();

        public ProductList(string select, int typeid) { }

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
            object result = null;
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();

                result = cstate.Execute(adlist);
                DataTable dt = (DataTable)result;

                this.productlist = dt.ToDictionary<int, Product>("ProductID");
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
        public void addProduct(string productname,int productprice,string productdetail, int typeid)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@ProductName", DbType.String, productname, ParameterDirection.Input);
                plist.Add("@ProductPrice", DbType.Int32, productprice, ParameterDirection.Input);
                plist.Add("@ProductDetail", DbType.String, productdetail, ParameterDirection.Input);
                plist.Add("@TypeProduct", DbType.Int32, typeid, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Insert);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

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
        public void editProduct(int productid,string productname, int productprice, string productdetail, int typeid)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@ProductID", DbType.String, productid, ParameterDirection.Input);
                plist.Add("@ProductName", DbType.String, productname, ParameterDirection.Input);
                plist.Add("@ProductPrice", DbType.Int32, productprice, ParameterDirection.Input);
                plist.Add("@ProductDetail", DbType.String, productdetail, ParameterDirection.Input);
                plist.Add("@TypeProduct", DbType.Int32, typeid, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Update);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

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
        public void delProduct(int productid)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@ProductID", DbType.String, productid, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Delete);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

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
        public void selectType()
        {
            object result = null;
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememetType, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();

                result = cstate.Execute(adlist);
                DataTable dt = (DataTable)result;

                this.productlist = dt.ToDictionary<int, Product>("TypeID");
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
        public void addTypeProduct(string typename,string typedetail)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@TypeName", DbType.String, typename, ParameterDirection.Input);
                plist.Add("@TypeDetail", DbType.String, typedetail, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememetType, plist, NoomLibrary.StatementType.Insert);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

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
        public void editTypeProduct(int typeid, string typename, string typedetail)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@TypeID", DbType.Int32, typeid, ParameterDirection.Input);
                plist.Add("@TypeName", DbType.String, typename, ParameterDirection.Input);
                plist.Add("@TypeDetail", DbType.String, typedetail, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememetType, plist, NoomLibrary.StatementType.Update);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

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
        public void deleteTypeProduct(int typeid)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@TypeID", DbType.String, typeid, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememetType, plist, NoomLibrary.StatementType.Delete);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

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
        public void getProduct(int productid)
        {
            object result = null;
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@TypeID", DbType.String, productid, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememetType, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();
                
                result = cstate.Execute(adlist);
                DataTable dt = (DataTable)result;

                this.productlist = dt.ToDictionary<int, Product>("TypeID");

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

        }
    }
}
