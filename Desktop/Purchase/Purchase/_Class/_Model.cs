using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _ModelList : IDictionary<int,_ModelList._Model>
    {
        private CStatement _statement;

        private Dictionary<int, _Model> _list = new Dictionary<int, _Model>();

        public _ModelList()
        {
            this._statement = new CStatement("SELECT_Model", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _ModelList._Model value)
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

        public bool TryGetValue(int key, out _ModelList._Model value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_ModelList._Model> Values
        {
            get
            {
                ICollection<_Model> values = new List<_Model>();
                foreach (_Model item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _ModelList._Model this[int key]
        {
            get
            {
                _Model result;
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
                _Model result;
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

        public void Add(KeyValuePair<int, _ModelList._Model> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _ModelList._Model> item)
        {
            _Model value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Model>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _ModelList._Model>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _ModelList._Model> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _ModelList._Model>> GetEnumerator()
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
                    CSQLStatementValue csv = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csv);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    foreach (DataRow item in dt.Rows)
                    {
                        int id = int.Parse(item["ID"].ToString());
                        _Model _md = new _Model();
                        _md.MCode = item["MCode"].ToString();
                        _md.MName = item["MName"].ToString();
                        this.Add(id, _md);

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

        public class _Model
        {
            public string MCode { get; set; }
            public string MName { get; set; }
            public decimal SalePrice { get; set; }

            public _Model()
            {
                this.MCode = string.Empty;
                this.MName = string.Empty;
                this.SalePrice = 0;
            }
        }
    }
}