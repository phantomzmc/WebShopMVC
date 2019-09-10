using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _DistrictList : IDictionary<int , _DistrictList._District>
    {
        private CStatement _statement;

        private Dictionary<int, _District> _list = new Dictionary<int, _District>();

        public _DistrictList()
        {
            this._statement = new CStatement("SELECT_District", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _DistrictList._District value)
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

        public bool TryGetValue(int key, out _DistrictList._District value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_DistrictList._District> Values
        {
            get
            {
                ICollection<_District> values = new List<_District>();
                foreach (_District item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _DistrictList._District this[int key]
        {
            get
            {
                _District result;
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
                _District result;
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

        public void Add(KeyValuePair<int, _DistrictList._District> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _DistrictList._District> item)
        {
            _District value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_District>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _DistrictList._District>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _DistrictList._District> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _DistrictList._District>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public object Select(int num,int Province_ID, int Amphur_ID)
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
                    plist.Add("@Amphur_ID", DbType.Int32, Amphur_ID, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    foreach (DataRow item in dt.Rows)
                    {
                        int id = int.Parse(item["DISTRICT_ID"].ToString());
                        _District _c = new _District();
                        _c.DISTRICT_ID = id;
                        _c.DISTRICT_NAME = item["DISTRICT_NAME"].ToString();

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

        public class _District
        {
            public int DISTRICT_ID { get; set; }
            public string DISTRICT_CODE { get; set; }
            public string DISTRICT_NAME { get; set; }
            public int AMPHUR_ID { get; set; }
            public _ProvinceList._Province _Province { get; set; }
            public int GEO_ID { get; set; }

            public _District()
            {
                this.DISTRICT_ID = 0;
                this.DISTRICT_CODE = string.Empty;
                this.DISTRICT_NAME = string.Empty;
                this.AMPHUR_ID = 0;
                this._Province = new _ProvinceList._Province();
            }
        }
    }
}