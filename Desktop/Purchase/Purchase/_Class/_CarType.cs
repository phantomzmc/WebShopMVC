using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _CarTypeList : IDictionary<int,_CarTypeList._CarType>
    {
        private CStatement _statement,_statement2;

        private Dictionary<int, _CarType> _list = new Dictionary<int, _CarType>();

        public _CarTypeList()
        {
            this._statement = new CStatement("SELECT_CarType", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statement2 = new CStatement("uspSelectTypeCar", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            
        }
        public DataTable TypeCar { get; set; }

        #region IDictionary Implement

        public void Add(int key, _CarTypeList._CarType value)
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

        public bool TryGetValue(int key, out _CarTypeList._CarType value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_CarTypeList._CarType> Values
        {
            get
            {
                ICollection<_CarType> values = new List<_CarType>();
                foreach (_CarType item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _CarTypeList._CarType this[int key]
        {
            get
            {
                _CarType result;
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
                _CarType result;
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

        public void Add(KeyValuePair<int, _CarTypeList._CarType> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _CarTypeList._CarType> item)
        {
            _CarType value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_CarType>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _CarTypeList._CarType>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _CarTypeList._CarType> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _CarTypeList._CarType>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public object Select_CarType(int num)
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
                    TypeCar = dt;

                    foreach (DataRow item in dt.Rows)
                    {
                        int id = int.Parse(item["ID"].ToString());
                        _CarType _c = new _CarType();
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
        public DataTable Select_CarType2(int num)
        {
            DataTable dt = new DataTable();
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@ID", DbType.Int32, num, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement2, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    dt = (DataTable)result;
                    TypeCar = dt;

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
            return dt;
        }


        public class _CarType
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public _CarType()
            {
                this.ID = 0;
                this.Name = string.Empty;

            }
            
        }
    }
}