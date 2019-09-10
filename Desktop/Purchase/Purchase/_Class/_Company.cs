using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _CompanyList : IDictionary<int,_CompanyList._Company>
    {
        private CStatement _statement;

        private Dictionary<int, _Company> _list = new Dictionary<int, _Company>();

        public _CompanyList()
        {
            this._statement = new CStatement("SELECT_Company", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _CompanyList._Company value)
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

        public bool TryGetValue(int key, out _CompanyList._Company value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_CompanyList._Company> Values
        {
            get
            {
                ICollection<_Company> values = new List<_Company>();
                foreach (_Company item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _CompanyList._Company this[int key]
        {
            get
            {
                _Company result;
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
                _Company result;
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

        public void Add(KeyValuePair<int, _CompanyList._Company> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _CompanyList._Company> item)
        {
            _Company value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Company>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _CompanyList._Company>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _CompanyList._Company> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _CompanyList._Company>> GetEnumerator()
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
                        _Company _c = new _Company();
                        _c.Companycode = item["companycode"].ToString();
                        _c.CompanyName = item["companyname"].ToString();
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

        public class _Company
        {
            public string Companycode { get; set; }
            public string CompanyName { get; set; }

            public _Company()
            {
                this.Companycode = string.Empty;
                this.CompanyName = string.Empty;
            }
        }
    }
}