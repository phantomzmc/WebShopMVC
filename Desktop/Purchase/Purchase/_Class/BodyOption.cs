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
    public class BodyOptionList : IDictionary<int, BodyOptionList.BodyOption> 
    {
        private CStatement _statement;

        private Dictionary<int, BodyOption> _list = new Dictionary<int, BodyOption>();


        public BodyOptionList()
        {
            this._statement = new CStatement("Body_Select_Option_price", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }
        
        #region IDictionary Implement

        public void Add(int key, BodyOptionList.BodyOption value)
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

        public bool TryGetValue(int key, out BodyOptionList.BodyOption value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<BodyOptionList.BodyOption> Values
        {
            get
            {
                ICollection<BodyOption> values = new List<BodyOption>();
                foreach (BodyOption item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public BodyOptionList.BodyOption this[int key]
        {
            get
            {
                BodyOption result;
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
                BodyOption result;
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

        public void Add(KeyValuePair<int, BodyOptionList.BodyOption> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, BodyOptionList.BodyOption> item)
        {
            BodyOption value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<BodyOption>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, BodyOptionList.BodyOption>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, BodyOptionList.BodyOption> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, BodyOptionList.BodyOption>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public object Body_Select_Option(int Body_Acc_ID)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@Body_Acc_ID", DbType.Int32, Body_Acc_ID, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    foreach (DataRow item in dt.Rows)
                    {
                        int Option_ID = int.Parse(item["Body_Option_ID"].ToString());
                        BodyOption _SetAcc = new BodyOption();
                        _SetAcc.Body_Option_ID = Option_ID;
                        _SetAcc.Body_Option_Name = item["Body_Option_Name"].ToString();
                        _SetAcc.Option_Name = item["Option_Name"].ToString();
                        _SetAcc.Body_Option_price = decimal.Parse(item["Body_Option_price"].ToString());
                        //_SetAcc.finance = item["finance"].ToString();

                        this.Add(Option_ID, _SetAcc);

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

        public class BodyOption
        {
            public int OptionIDrun { get; set; }
            public int Body_Option_ID { get; set; }
            public string Body_Option_Name { get; set; }
            public string Option_Name { get; set; }
            public decimal Body_Option_price { get; set; }
            public string finance { get; set; }

            public BodyOption()
            {
                this.OptionIDrun = 0;
                this.Body_Option_ID = 0;
                this.Body_Option_Name = string.Empty;
                this.Option_Name = string.Empty;
                this.Body_Option_price = 0;
                this.finance = string.Empty;
            }
        }
        
    }


    public class BodyOptionExtraList : IDictionary<int, BodyOptionExtraList.BodyOptionExtra> 
    {
        private CStatement _statement;

        private Dictionary<int, BodyOptionExtra> _list = new Dictionary<int, BodyOptionExtra>();


        public BodyOptionExtraList()
        {
            this._statement = new CStatement("Body_Select_Option_price", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, BodyOptionExtraList.BodyOptionExtra value)
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

        public bool TryGetValue(int key, out BodyOptionExtraList.BodyOptionExtra value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<BodyOptionExtraList.BodyOptionExtra> Values
        {
            get
            {
                ICollection<BodyOptionExtra> values = new List<BodyOptionExtra>();
                foreach (BodyOptionExtra item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public BodyOptionExtraList.BodyOptionExtra this[int key]
        {
            get
            {
                BodyOptionExtra result;
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
                BodyOptionExtra result;
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

        public void Add(KeyValuePair<int, BodyOptionExtraList.BodyOptionExtra> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, BodyOptionExtraList.BodyOptionExtra> item)
        {
            BodyOptionExtra value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<BodyOptionExtra>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, BodyOptionExtraList.BodyOptionExtra>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, BodyOptionExtraList.BodyOptionExtra> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, BodyOptionExtraList.BodyOptionExtra>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public class BodyOptionExtra
        {
            public int ID { get; set; }
            public string Option_Name_extra { get; set; }
            public int Body_Company_ID { get; set; }
            public string Body_Company_Name { get; set; }
            public decimal Option_price_extra { get; set; }
            public string Option_finance_extra { get; set; }

            public BodyOptionExtra()
            {
                this.ID = 0;
                this.Option_Name_extra = string.Empty;
                this.Body_Company_ID = 0;
                this.Body_Company_Name = string.Empty;
                this.Option_price_extra = 0;
                this.Option_finance_extra = "N";
            }
         }

    
    }
}