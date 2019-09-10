using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _BranchList : IDictionary<int, _BranchList._Branch>
    {
        private CStatement _statement;
        private CStatement _statementB;
        

        private Dictionary<int, _Branch> _list = new Dictionary<int, _Branch>();

        public _BranchList()
        {
            this._statement = new CStatement("SELECT_Company", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementB = new CStatement("SELECT_Branch", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _BranchList._Branch value)
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

        public bool TryGetValue(int key, out _BranchList._Branch value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_BranchList._Branch> Values
        {
            get
            {
                ICollection<_Branch> values = new List<_Branch>();
                foreach (_Branch item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _BranchList._Branch this[int key]
        {
            get
            {
                _Branch result;
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
                _Branch result;
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

        public void Add(KeyValuePair<int, _BranchList._Branch> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _BranchList._Branch> item)
        {
            _Branch value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Branch>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _BranchList._Branch>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _BranchList._Branch> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _BranchList._Branch>> GetEnumerator()
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
                        _Branch _b = new _Branch();
                        _b.BranchName = item["BranchName"].ToString();
                        this.Add(id, _b);

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

        public object Select_Branch(int num,string Company,string BranchCode,string BranchName)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@Company", DbType.String, Company, ParameterDirection.Input);
                    plist.Add("@BranchCode", DbType.String, BranchCode, ParameterDirection.Input);
                    plist.Add("@BranchName", DbType.String, BranchName, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csv = new CSQLStatementValue(this._statementB, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csv);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    foreach (DataRow item in dt.Rows)
                    {
                        int id = int.Parse(item["ID"].ToString());
                        _Branch _b = new _Branch();
                        _b._Company.Companycode = item["Company"].ToString();
                        _b.Branchcode = item["Branch"].ToString();
                        _b.BranchName = item["BranchName"].ToString();
                        this.Add(id, _b);

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

        public class _Branch
        {
            public _CompanyList._Company _Company { get; set; }
            public string Branchcode { get; set; }
            public string BranchName { get; set; }

            public _Branch()
            {
                this._Company = new _CompanyList._Company();
                this.Branchcode = string.Empty;
                this.BranchName = string.Empty;
            }
        }
    }
}