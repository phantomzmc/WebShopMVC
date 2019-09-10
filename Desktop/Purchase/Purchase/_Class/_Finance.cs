using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _FinanceList : IDictionary<int,_FinanceList._Finance>
    {
        private CStatement _statement;

        private Dictionary<int, _Finance> _list = new Dictionary<int, _Finance>();

        public _FinanceList()
        {
            this._statement = new CStatement("SELECT_Finance", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _FinanceList._Finance value)
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

        public bool TryGetValue(int key, out _FinanceList._Finance value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_FinanceList._Finance> Values
        {
            get
            {
                ICollection<_Finance> values = new List<_Finance>();
                foreach (_Finance item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _FinanceList._Finance this[int key]
        {
            get
            {
                _Finance result;
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
                _Finance result;
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

        public void Add(KeyValuePair<int, _FinanceList._Finance> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _FinanceList._Finance> item)
        {
            _Finance value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Finance>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _FinanceList._Finance>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _FinanceList._Finance> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _FinanceList._Finance>> GetEnumerator()
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
                        _Finance _c = new _Finance();
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

        public class _Finance
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public _Finance()
            {
                this.ID = 0;
                this.Name = string.Empty;
            }
        }
    }

}