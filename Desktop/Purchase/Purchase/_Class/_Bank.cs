using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _BankList : IDictionary<int,_BankList._Bank>
    {
        private CStatement _statement;

        private Dictionary<int, _Bank> _list = new Dictionary<int, _Bank>();

        public _BankList()
        {
            this._statement = new CStatement("SELECT_Bank", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _BankList._Bank value)
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

        public bool TryGetValue(int key, out _BankList._Bank value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_BankList._Bank> Values
        {
            get
            {
                ICollection<_Bank> values = new List<_Bank>();
                foreach (_Bank item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _BankList._Bank this[int key]
        {
            get
            {
                _Bank result;
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
                _Bank result;
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

        public void Add(KeyValuePair<int, _BankList._Bank> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _BankList._Bank> item)
        {
            _Bank value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Bank>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _BankList._Bank>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _BankList._Bank> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _BankList._Bank>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public object Select_Bank(int num)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    foreach (DataRow item in dt.Rows)
                    {
                        int id = int.Parse(item["ID"].ToString());
                        _Bank _c = new _Bank();
                        _c.ID = id;
                        _c.Name = item["Name"].ToString();

                        this.Add(id, _c);

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

        public class _Bank
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public _Bank()
            {
                this.ID = 0;
                this.Name = string.Empty;

            }
        }
    }
}