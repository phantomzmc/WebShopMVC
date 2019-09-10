using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _Accessorieslist : IDictionary<int,_Accessorieslist._Accessories>
    {
        private CStatement _statement;

        private Dictionary<int, _Accessories> _list = new Dictionary<int, _Accessories>();

        public _Accessorieslist()
        {
            this._statement = new CStatement("SELECT_SetAcc", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _Accessorieslist._Accessories value)
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

        public bool TryGetValue(int key, out _Accessorieslist._Accessories value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_Accessorieslist._Accessories> Values
        {
            get
            {
                ICollection<_Accessories> values = new List<_Accessories>();
                foreach (_Accessories item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _Accessorieslist._Accessories this[int key]
        {
            get
            {
                _Accessories result;
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
                _Accessories result;
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

        public void Add(KeyValuePair<int, _Accessorieslist._Accessories> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _Accessorieslist._Accessories> item)
        {
            _Accessories value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Accessories>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _Accessorieslist._Accessories>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _Accessorieslist._Accessories> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _Accessorieslist._Accessories>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public object Select(int num,int @BookID)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@BookID", DbType.Int32, BookID, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    foreach (DataRow item in dt.Rows)
                    {
                        int id = int.Parse(item["ID"].ToString());
                        _Accessories _SetAcc = new _Accessories();
                        _SetAcc.ID = id;
                        _SetAcc.Name = item["Name"].ToString();

                        this.Add(id, _SetAcc);

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

        public class _Accessories
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public _Accessories()
            {
                this.ID = 0;
                this.Name = string.Empty;
            }
        }

        public class _SetAcc
        {
            public int ID { get; set; }
            public decimal Price { get; set; }
            public string Free { get; set; }

            public _SetAcc()
            {
                this.ID = 0;
                this.Price = 0;
                this.Free = "N";
            }
        }
    }

    public class _AccessoriesSTDList : IDictionary<int,_AccessoriesSTDList._AccessoriesSTD>
    {
        private CStatement _statement;

        private Dictionary<int, _AccessoriesSTD> _list = new Dictionary<int, _AccessoriesSTD>();

        public _AccessoriesSTDList()
        {
            this._statement = new CStatement("SELECT_AccessoriesSTD", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _AccessoriesSTDList._AccessoriesSTD value)
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

        public bool TryGetValue(int key, out _AccessoriesSTDList._AccessoriesSTD value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_AccessoriesSTDList._AccessoriesSTD> Values
        {
            get
            {
                ICollection<_AccessoriesSTD> values = new List<_AccessoriesSTD>();
                foreach (_AccessoriesSTD item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _AccessoriesSTDList._AccessoriesSTD this[int key]
        {
            get
            {
                _AccessoriesSTD result;
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
                _AccessoriesSTD result;
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

        public void Add(KeyValuePair<int, _AccessoriesSTDList._AccessoriesSTD> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _AccessoriesSTDList._AccessoriesSTD> item)
        {
            _AccessoriesSTD value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_AccessoriesSTD>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _AccessoriesSTDList._AccessoriesSTD>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _AccessoriesSTDList._AccessoriesSTD> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _AccessoriesSTDList._AccessoriesSTD>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public object Select(int num,int BookID)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@BookID", DbType.Int32, BookID, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    foreach (DataRow item in dt.Rows)
                    {
                        int id = int.Parse(item["ID"].ToString());
                        _AccessoriesSTD _AccSTD = new _AccessoriesSTD();
                        _AccSTD.ID = id;
                        _AccSTD.Name = item["Name"].ToString();

                        this.Add(id, _AccSTD);

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

        public class _AccessoriesSTD
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public _AccessoriesSTD()
            {
                this.ID = 0;
                this.Name = string.Empty;
            }
        }

        public class _SetAccSTD
        {
            public int ID { get; set; }
            public decimal Price { get; set; }
            public string Free { get; set; }

            public _SetAccSTD()
            {
                this.ID = 0;
                this.Price = 0;
                this.Free = "N";
            }

        }
    }

    public class _AdAccessoriesList : IDictionary<int,_AdAccessoriesList._AdAccessories>
    {
        private CStatement _statement;

        private Dictionary<int, _AdAccessories> _list = new Dictionary<int, _AdAccessories>();

        public _AdAccessoriesList()
        {
            this._statement = new CStatement("SELECT_AdAccessories", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _AdAccessoriesList._AdAccessories value)
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

        public bool TryGetValue(int key, out _AdAccessoriesList._AdAccessories value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_AdAccessoriesList._AdAccessories> Values
        {
            get
            {
                ICollection<_AdAccessories> values = new List<_AdAccessories>();
                foreach (_AdAccessories item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _AdAccessoriesList._AdAccessories this[int key]
        {
            get
            {
                _AdAccessories result;
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
                _AdAccessories result;
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

        public void Add(KeyValuePair<int, _AdAccessoriesList._AdAccessories> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _AdAccessoriesList._AdAccessories> item)
        {
            _AdAccessories value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_AdAccessories>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _AdAccessoriesList._AdAccessories>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _AdAccessoriesList._AdAccessories> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _AdAccessoriesList._AdAccessories>> GetEnumerator()
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
                        _AdAccessories _c = new _AdAccessories();
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

        public class _AdAccessories
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Free { get; set; }

            public _AdAccessories()
            {
                this.ID = 0;
                this.Name = string.Empty;
                this.Price = 0;
                this.Free = string.Empty;
            }
        }

        public class _AddAcc
        {
            public int ID { get; set; }
            public decimal Price { get; set; }

            public _AddAcc()
            {
                this.ID = 0;
                this.Price = 0;
            }
        }
    }

}