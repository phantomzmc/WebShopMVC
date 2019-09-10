using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _ProvinceList : IDictionary<int, _ProvinceList._Province>
    {
        private CStatement _statement;

        private Dictionary<int, _Province> _list = new Dictionary<int, _Province>();

        public _ProvinceList()
        {
            this._statement = new CStatement("SELECT_Province", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _ProvinceList._Province value)
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

        public bool TryGetValue(int key, out _ProvinceList._Province value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_ProvinceList._Province> Values
        {
            get
            {
                ICollection<_Province> values = new List<_Province>();
                foreach (_Province item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _ProvinceList._Province this[int key]
        {
            get
            {
                _Province result;
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
                _Province result;
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

        public void Add(KeyValuePair<int, _ProvinceList._Province> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _ProvinceList._Province> item)
        {
            _Province value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Province>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _ProvinceList._Province>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _ProvinceList._Province> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _ProvinceList._Province>> GetEnumerator()
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
                        int id = int.Parse(item["PROVINCE_ID"].ToString());
                        _Province _c = new _Province();
                        _c.PROVINCE_ID = id;
                        _c.PROVINCE_NAME = item["PROVINCE_NAME"].ToString();

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

        public class _Province
        {
            public int PROVINCE_ID { get; set; }
            public string PROVINCE_CODE { get; set; }
            public string PROVINCE_NAME { get; set; }
            public int GEO_ID { get; set; }

            public _Province()
            {
                this.PROVINCE_ID = 0;
                this.PROVINCE_CODE = string.Empty;
                this.PROVINCE_NAME = string.Empty;
                this.GEO_ID = 0;
            }
        }
    }
}