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
    public class BodyClassList : IDictionary<int, BodyClassList.BodyClass> 
    {
        private CStatement _statement;

        private Dictionary<int, BodyClass> _list = new Dictionary<int, BodyClass>();


        public BodyClassList()
        {
            this._statement = new CStatement("Body_Select_Accessories", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }


        #region IDictionary Implement

        public void Add(int key, BodyClassList.BodyClass value)
        {
            this._list.Add(key, value);
        }

        public bool ContainsKey(int key)
        {
            return this._list.ContainsKey(key);
        }

        public ICollection<int> Keys
        {
            get
            {
                ICollection<int> keys = new List<int>();
                foreach (int item in this._list.Keys)
                {
                    keys.Add(item);
                }
                return keys;
            }
        }

        public bool Remove(int key)
        {
            return this._list.Remove(key);
        }

        public bool TryGetValue(int key, out BodyClassList.BodyClass value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<BodyClassList.BodyClass> Values
        {
            get
            {
                ICollection<BodyClass> values = new List<BodyClass>();
                foreach (BodyClass item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public BodyClassList.BodyClass this[int key]
        {
            get
            {
                BodyClass result;
                if (this._list.TryGetValue(key, out result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                BodyClass result;
                if (this._list.TryGetValue(key, out result))
                {
                    this._list[key] = value;
                }
                else
                {
                    this._list.Add(key, value);
                }
            }
        }

        public void Add(KeyValuePair<int, BodyClassList.BodyClass> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, BodyClassList.BodyClass> item)
        {
            BodyClass value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<BodyClass>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, BodyClassList.BodyClass>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return this._list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<int, BodyClassList.BodyClass> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, BodyClassList.BodyClass>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public object Select(string MCode)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@MCode", DbType.String, MCode, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    foreach (DataRow item in dt.Rows)
                    {
                        int Body_Acc_ID = int.Parse(item["Body_Acc_ID"].ToString());
                        BodyClass _SetAcc = new BodyClass();
                        _SetAcc.Body_Acc_ID = Body_Acc_ID;
                        _SetAcc.Body_Acc_Name = item["Body_Acc_Name"].ToString();
                        _SetAcc.Acc_Name = item["Acc_Name"].ToString();
                        _SetAcc.Body_Model_price = decimal.Parse(item["Body_Model_price"].ToString());

                        this.Add(Body_Acc_ID, _SetAcc);

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
            return result;
        }

        public class BodyClass
        {
            public int Body_Acc_ID { get; set; }
            public int Body_Company_ID { get; set; }
            public string Body_Acc_Name { get; set; }
            public string Acc_Name { get; set; }
            public int Body_Model_ID { get; set; }
            public decimal Body_Model_price { get; set; }
            public string Mcode { get; set; }
            public int Body_Option_ID { get; set; }
            public string Body_Option_Name { get; set; }
            public decimal Body_Option_price { get; set; }
            public string finance { get; set; }

            public BodyClass()
            {
                this.Body_Acc_ID = 0;
                this.Body_Company_ID = 0;
                this.Body_Acc_Name = string.Empty;
                this.Acc_Name = string.Empty;
                this.Body_Model_ID = 0;
                this.Body_Model_price = 0;
                this.Mcode = string.Empty;
                this.Body_Option_ID = 0;
                this.Body_Option_Name = string.Empty;
                this.Body_Option_price = 0;
                this.finance = string.Empty;
            }
        }
      
    }

    public class BodyCompany
    {
        #region Field
        private Connection _c;
        private SqlDataAdapter _da1;
        private SqlDataAdapter _da3;
        #endregion

        #region Properties
        public int Body_Company_ID { get; set; }
        public string Body_Company_Name { get; set; }
        #endregion

        #region Constructer

        public BodyCompany()
        {
            this.Body_Company_ID = 0;
            this.Body_Company_Name = string.Empty;
            this._c = new Connection();
            this._da1 = this._c.getAdapter(this._da1, this._c, "Body_Select_Company", "INSERT", "UPDATE", "DELETE");

        }
        #endregion

        public DataTable Body_Select_Company()
        {
            this._da1.SelectCommand.Parameters.Clear();
            DataTable dt = this._c.Select(this._da1);

            try
            {
            }
            catch (SqlException ex)
            {

            }
            return dt;
        }       
    }

}