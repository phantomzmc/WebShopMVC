using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _AmphurList : IDictionary<int, _AmphurList._Amphur>
    {
        private CStatement _statement;

        private Dictionary<int, _Amphur> _list = new Dictionary<int, _Amphur>();

        public _AmphurList()
        {
            this._statement = new CStatement("SELECT_Amphur", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _AmphurList._Amphur value)
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

        public bool TryGetValue(int key, out _AmphurList._Amphur value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_AmphurList._Amphur> Values
        {
            get
            {
                ICollection<_Amphur> values = new List<_Amphur>();
                foreach (_Amphur item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _AmphurList._Amphur this[int key]
        {
            get
            {
                _Amphur result;
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
                _Amphur result;
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

        public void Add(KeyValuePair<int, _AmphurList._Amphur> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _AmphurList._Amphur> item)
        {
            _Amphur value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Amphur>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _AmphurList._Amphur>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _AmphurList._Amphur> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _AmphurList._Amphur>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public object Select(int num, int Province_ID)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@Province_ID", DbType.Int32, Province_ID, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    foreach (DataRow item in dt.Rows)
                    {
                        int id = int.Parse(item["AMPHUR_ID"].ToString());
                        _Amphur _c = new _Amphur();
                        _c.AMPHUR_ID = id;
                        _c.AMPHUR_NAME = item["AMPHUR_NAME"].ToString();

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

        public class _Amphur
        {
            public int AMPHUR_ID { get; set; }
            public string AMPHUR_CODE { get; set; }
            public string AMPHUR_NAME { get; set; }
            public int GEO_ID { get; set; }
            public _ProvinceList._Province _Province { get; set; }
            public _ProvinceList _provincelist { get; set; }

            public _Amphur()
            {
                this.AMPHUR_ID = 0;
                this.AMPHUR_CODE = string.Empty;
                this.AMPHUR_NAME = string.Empty;
                this.GEO_ID = 0;
                this._Province = new _ProvinceList._Province();
                this._provincelist = new _ProvinceList();
            }
        }
    }
}