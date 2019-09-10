using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class Tb_UserList : IDictionary<int,Tb_UserList.Tb_User>
    {
        private CStatement _statement;
        private CStatement _statementEmpSale;

        private Dictionary<int, Tb_User> _list = new Dictionary<int,Tb_User>();

        public Tb_UserList()
        {
            this._statement = new CStatement("Select_User", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementEmpSale = new CStatement("Select_EmpSale", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, Tb_UserList.Tb_User value)
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

        public bool TryGetValue(int key, out Tb_UserList.Tb_User value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<Tb_UserList.Tb_User> Values
        {
            get
            {
                ICollection<Tb_User> values = new List<Tb_User>();
                foreach (Tb_User item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public Tb_UserList.Tb_User this[int key]
        {
            get
            {
                Tb_User result;
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
                Tb_User result;
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

        public void Add(KeyValuePair<int, Tb_UserList.Tb_User> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, Tb_UserList.Tb_User> item)
        {
            Tb_User value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<Tb_User>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, Tb_UserList.Tb_User>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, Tb_UserList.Tb_User> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, Tb_UserList.Tb_User>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public object Select(string Username,string Password)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@Username", DbType.String, Username, ParameterDirection.Input);
                    plist.Add("@Password", DbType.String, Password, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    foreach (DataRow item in dt.Rows)
                    {
                        int ID = int.Parse(item["ID"].ToString());
                        string _Username = item["Username"].ToString();
                        string Pasword = item["Password"].ToString();
                        string FullName = item["FullName"].ToString();
                        int EmpID = int.Parse(item["EmpID"].ToString());
                        int UserType = int.Parse(item["UserType"].ToString());
                        string TypeName = item["TypeName"].ToString();
                        string NickName = item["NickName"].ToString();
                        string Company = item["Company"].ToString();
                        string Branch = item["Branch"].ToString();

                        Tb_User _u = new Tb_User();
                        _u.ID = ID;
                        _u.Username = _Username;
                        _u.Password = Password;
                        _u.FullName = FullName;
                        _u.EmpID = EmpID;
                        _u.UserType = UserType;
                        _u.TypeName = TypeName;
                        _u.NickName = NickName;
                        _u.Company = Company;
                        _u.Branch = Branch;

                        this.Add(1, _u);
                        
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

        public object SelectEmpSale(int num,string Company, string Branch, int EmpID)
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
                    plist.Add("@Branch", DbType.String, Branch, ParameterDirection.Input);
                    plist.Add("@EmpID", DbType.Int32, EmpID, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statementEmpSale, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    foreach (DataRow item in dt.Rows)
                    {
                        string FullName = item["FullName"].ToString();
                        int Emp_ID = int.Parse(item["Emp_id"].ToString());

                        Tb_User _u = new Tb_User();
                        _u.FullName = FullName;
                        _u.EmpID = Emp_ID;

                        this.Add(Emp_ID, _u);

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

        public class Tb_User
        {
            private CStatement _statement;

            public int EmpID { get; set; }
            public int ID { get; set; }
            public int UserType { get; set; }
            public string TypeName { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string FullName { get; set; }
            public string NickName { get; set; }
            public string Company { get; set; }
            public string Branch { get; set; }
            public string Team { get; set; }

            public Tb_User()
            {
                this.EmpID = 0;
                this.ID = 0;
                this.UserType = 0;
                this.TypeName = string.Empty;
                this.Username = string.Empty;
                this.Password = string.Empty;
                this.FullName = string.Empty;
                this.NickName = string.Empty;
                this.Company = string.Empty;
                this.Branch = string.Empty;
                this.Team = string.Empty;
                this._statement = new CStatement("Select_User", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            }

            public void Select(int num,string Username, string Password,int ID)
            {
                CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
                try
                {
                    try
                    {
                        CSQLParameterList plist = new CSQLParameterList();
                        plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                        plist.Add("@ID", DbType.Int32, ID, ParameterDirection.Input);
                        plist.Add("@Username", DbType.String, Username, ParameterDirection.Input);
                        plist.Add("@Password", DbType.String, Password, ParameterDirection.Input);
                        CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                        CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                        adlist.Add(csvUser);
                        cstate.Open();
                        DataTable dt = (DataTable)cstate.Execute(adlist);;

                        if (dt.Rows.Count > 0)
                        {
                            
                            this.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                            this.Username = dt.Rows[0]["Username"].ToString();
                            this.Password = dt.Rows[0]["Password"].ToString();
                            this.FullName = dt.Rows[0]["SaleName"].ToString();
                            this.EmpID = int.Parse(dt.Rows[0]["Emp_id"].ToString());
                            this.UserType = int.Parse(dt.Rows[0]["UserType"].ToString());
                            this.NickName = dt.Rows[0]["NickName"].ToString();
                            this.Company = dt.Rows[0]["Company"].ToString();
                            this.Branch = dt.Rows[0]["Branch"].ToString();
                            this.Team = dt.Rows[0]["Team"].ToString();
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
                
            }
        }
        
    }
}