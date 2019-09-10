using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _CareerList : IDictionary<int, _CareerList._Career>
    {
        private CStatement _statement;

        private Dictionary<int, _Career> _list = new Dictionary<int, _Career>();

        public _CareerList()
        {
            this._statement = new CStatement("SELECT_Tb_Career", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _CareerList._Career value)
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

        public bool TryGetValue(int key, out _CareerList._Career value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_CareerList._Career> Values
        {
            get
            {
                ICollection<_Career> values = new List<_Career>();
                foreach (_Career item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _CareerList._Career this[int key]
        {
            get
            {
                _Career result;
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
                _Career result;
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

        public void Add(KeyValuePair<int, _CareerList._Career> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _CareerList._Career> item)
        {
            _Career value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Career>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _CareerList._Career>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _CareerList._Career> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _CareerList._Career>> GetEnumerator()
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
                        _Career _c = new _Career();
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

        //#region Field
        //private Connection c;
        //private SqlDataAdapter _da;
        //private DataTable _dt;
        //#endregion

        //#region property
        //public int ID { get; set; }
        //public string Name { get; set; }
        //#endregion

        //#region Constructer
        //public _CareerList()
        //{
        //    this.c = new Connection();
        //    this.ID = 0;
        //    this.Name = string.Empty;
        //    this._da = c.getAdapter(this._da, this.c, "SELECT_Tb_Career", "INSERT", "UPDATE", "DELETE");
        //}
        //#endregion

        //#region Method
        //public DataTable SELECT_Tb_Career(int num)
        //{
        //    DataTable dt = new DataTable();
        //    this._da.SelectCommand.Parameters.Clear();
        //    this.c.addSelectParameter(ref this._da, "@num", DbType.Int32, num);
        //    dt = this.c.Select(this._da);
        //    return dt;
        //}
        //#endregion

        public class _Career
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public _Career()
            {
                this.ID = 0;
                this.Name = string.Empty;
            }
        }
    }
}