using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _InsuranceList : IDictionary<int, _InsuranceList._Insurance>
    {
        private CStatement _statement;

        private Dictionary<int, _Insurance> _list = new Dictionary<int, _Insurance>();

        public _InsuranceList()
        {
            this._statement = new CStatement("SELECT_Insurance", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _InsuranceList._Insurance value)
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

        public bool TryGetValue(int key, out _InsuranceList._Insurance value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_InsuranceList._Insurance> Values
        {
            get
            {
                ICollection<_Insurance> values = new List<_Insurance>();
                foreach (_Insurance item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _InsuranceList._Insurance this[int key]
        {
            get
            {
                _Insurance result;
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
                _Insurance result;
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

        public void Add(KeyValuePair<int, _InsuranceList._Insurance> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _InsuranceList._Insurance> item)
        {
            _Insurance value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Insurance>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _InsuranceList._Insurance>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _InsuranceList._Insurance> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _InsuranceList._Insurance>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public object Select(int num)
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
                        _Insurance _In = new _Insurance();
                        _In.ID = id;
                        _In.Name = item["Name"].ToString();

                        this.Add(id, _In);

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

        public class _Insurance
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public _Insurance()
            {
                this.ID = 0;
                this.Name = string.Empty;
            }

        }
    }
}