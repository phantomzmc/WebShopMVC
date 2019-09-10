using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _Customer
    {
        private CStatement _statement;
        private CStatement _statementMaxCusNo;

        public int ID { get; set; }
        public string CusNo { get; set; }
        public string CusType { get; set; }
        public string CorporationCode { get; set; }
        public string IDCard { get; set; }
        public string Prefix { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public _EducationList._Education _Education { get; set; }
        public int Total_Member { get; set; }
        public string Tel_Home { get; set; }
        public string Tel_Mobile1 { get; set; }
        public string Tel_Mobile2 { get; set; }
        public string Tel_Work { get; set; }
        public string Tel_Fax { get; set; }
        public string LineID { get; set; }
        public string SendAddress_IDCard { get; set; }
        public string SendAddress { get; set; }
        public int SendAdd_Moo { get; set; }
        public string SendAdd_HomeName { get; set; }
        public string SendAdd_Road { get; set; }
        public string SendAdd_Soi { get; set; }
        public int SendAdd_District { get; set; }
        public int SendAdd_Amphur { get; set; }
        public int SendAdd_Province { get; set; }
        public int SendAdd_Postel { get; set; }
        public _AddressList _AddressList { get; set; }
        public _AddressList _SentAddressList { get; set; }
        public _AddressList._Address _Address { get; set; }
        public _CareerList._Career _Career { get; set; }
        public string Career_Other { get; set; }
        public string Career_Remark { get; set; }
        public _IncomeList._Income _Income { get; set; }
        public int User_Add { get; set; }

        public _Customer()
        {
            this.ID = 0;
            this.CusNo = string.Empty;
            this.CusType = string.Empty;
            this.IDCard = string.Empty;
            this.CorporationCode = string.Empty;
            this.Prefix = string.Empty;
            this.Name = string.Empty;
            this.Surname = string.Empty;
            this.Nickname = string.Empty;
            this.Sex = string.Empty;
            this.Birthday = DateTime.MinValue;
            this._Education = new _EducationList._Education();
            this.Tel_Home = string.Empty;
            this.Tel_Mobile1 = string.Empty;
            this.Tel_Mobile2 = string.Empty;
            this.Tel_Work = string.Empty;
            this.Tel_Fax = string.Empty;
            this._AddressList = new _AddressList();
            this._SentAddressList = new _AddressList();
            this._Address = new _AddressList._Address();
            this._Career = new _CareerList._Career();
            this.Career_Other = string.Empty;
            this.Career_Remark = string.Empty;
            this._Income = new _IncomeList._Income();
            this.Total_Member = 0;
            this.User_Add = 0;
            this._statement = new CStatement("Select_Customer", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementMaxCusNo = new CStatement("Select_MaxCusNo", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        public void Select(int num, string _IDCard)
        {
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@IDCard", DbType.String, _IDCard, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    DataTable dt = (DataTable)cstate.Execute(adlist); ;

                    if (dt.Rows.Count > 0)
                    {
                        this.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                        this.CusNo = dt.Rows[0]["CusNo"].ToString();
                        this.CusType = dt.Rows[0]["CusType"].ToString();
                        this.CorporationCode = dt.Rows[0]["CorporationCode"].ToString();
                        this.IDCard = dt.Rows[0]["IDCard"].ToString();
                        this.Prefix = dt.Rows[0]["Prefix"].ToString();
                        this.Name = dt.Rows[0]["Name"].ToString();
                        this.Surname = dt.Rows[0]["Surname"].ToString();
                        this.Nickname = dt.Rows[0]["Nickname"].ToString();
                        this.Sex = dt.Rows[0]["Sex"].ToString();
                        if (dt.Rows[0]["Birthday"].ToString() != string.Empty && dt.Rows[0]["Birthday"].ToString() != null)
                        {
                            this.Birthday = DateTime.Parse(dt.Rows[0]["Birthday"].ToString());
                        }

                        string _Education = dt.Rows[0]["Education"].ToString();
                        if (_Education != string.Empty && _Education != null)
                        {
                            this._Education.id = int.Parse(dt.Rows[0]["Education"].ToString());
                        }
                        

                        string _Total_Member = dt.Rows[0]["Total_Member"].ToString();
                        if (_Total_Member != string.Empty && _Total_Member != null)
                        {
                            this.Total_Member = int.Parse(dt.Rows[0]["Total_Member"].ToString());
                        }
                        
                        this.Tel_Mobile1 = dt.Rows[0]["Tel_Mobile1"].ToString();
                        this.Tel_Mobile2 = dt.Rows[0]["Tel_Mobile2"].ToString();
                        this.Tel_Work = dt.Rows[0]["Tel_Work"].ToString();
                        this.Tel_Fax = dt.Rows[0]["Tel_Fax"].ToString();
                        this._Career.ID = int.Parse(dt.Rows[0]["CareerID"].ToString());
                        this.Career_Other = dt.Rows[0]["Career_Other"].ToString();
                        this.Career_Remark = dt.Rows[0]["Career_Remark"].ToString();
                        this._Income.ID = int.Parse(dt.Rows[0]["IncomeID"].ToString());
                        string _SendAdd = dt.Rows[0]["SendAddress_IDCard"].ToString();
                        this.SendAddress_IDCard = _SendAdd;

                        _AddressList._Address _add = new _AddressList._Address();
                        _add.Address = dt.Rows[0]["Address"].ToString();
                        if (dt.Rows[0]["Add_Moo"].ToString() != string.Empty)
                        {
                            _add.Add_Moo = int.Parse(dt.Rows[0]["Add_Moo"].ToString());
                        }
                        else
                        {
                            _add.Add_Moo = 0;
                        }
                        
                        _add.Add_HomeName = dt.Rows[0]["Add_HomeName"].ToString();
                        _add.Add_Road = dt.Rows[0]["Add_Road"].ToString();
                        _add.Add_Soi = dt.Rows[0]["Add_Soi"].ToString();
                        _add._District.DISTRICT_ID = int.Parse(dt.Rows[0]["Add_District"].ToString());
                        _add._District.DISTRICT_NAME = dt.Rows[0]["DISTRICT_NAME"].ToString();
                        _add._Amphur.AMPHUR_ID = int.Parse(dt.Rows[0]["Add_Amphur"].ToString());
                        _add._Amphur.AMPHUR_NAME = dt.Rows[0]["AMPHUR_NAME"].ToString();
                        _add._Province.PROVINCE_ID = int.Parse(dt.Rows[0]["Add_Province"].ToString());
                        _add._Province.PROVINCE_NAME = dt.Rows[0]["PROVINCE_NAME"].ToString();
                        _add._Postel.Postel_Code = dt.Rows[0]["Add_Postel"].ToString();
                        this._AddressList.Add(1, _add);

                        if (_SendAdd == "N")
                        {
                            _AddressList._Address _Send = new _AddressList._Address();
                            _Send.Address = dt.Rows[0]["SendAddress"].ToString();
                            if (dt.Rows[0]["SendAdd_Moo"].ToString() != string.Empty)
                            {
                                _Send.Add_Moo = int.Parse(dt.Rows[0]["SendAdd_Moo"].ToString());
                            }
                            else
                            {
                                _Send.Add_Moo = 0;
                            }

                            _Send.Add_HomeName = dt.Rows[0]["SendAdd_HomeName"].ToString();
                            _Send.Add_Road = dt.Rows[0]["SendAdd_Road"].ToString();
                            _Send.Add_Soi = dt.Rows[0]["SendAdd_Soi"].ToString();

                            _Send._District.DISTRICT_ID = int.Parse(dt.Rows[0]["SendAdd_District"].ToString());
                            _Send._District.DISTRICT_NAME = dt.Rows[0]["SendDISTRICT_NAME"].ToString();
                            _Send._Amphur.AMPHUR_ID = int.Parse(dt.Rows[0]["SendAdd_Amphur"].ToString());
                            _Send._Amphur.AMPHUR_NAME = dt.Rows[0]["SendAMPHUR_NAME"].ToString();
                            _Send._Province.PROVINCE_ID = int.Parse(dt.Rows[0]["SendAdd_Province"].ToString());
                            _Send._Province.PROVINCE_NAME = dt.Rows[0]["SendPROVINCE_NAME"].ToString();
                            _Send._Postel.Postel_Code = dt.Rows[0]["SendAdd_Postel"].ToString();
                            this._SentAddressList.Add(1, _Send);
                        }
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

        public void Select(int num, string _M, string _Y)
        {
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@_Month", DbType.String, _M, ParameterDirection.Input);
                    plist.Add("@_Year", DbType.String, _Y, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statementMaxCusNo, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    DataTable dt = (DataTable)cstate.Execute(adlist); ;

                    if (dt.Rows.Count > 0)
                    {

                        this.CusNo = dt.Rows[0]["CusNo"].ToString();
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


    public class _AddressList : IDictionary<int,_AddressList._Address>
    {
        private CStatement _statement;

        private Dictionary<int, _Address> _list = new Dictionary<int, _Address>();

        public _AddressList()
        {
            this._statement = new CStatement("SELECT", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _AddressList._Address value)
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

        public bool TryGetValue(int key, out _AddressList._Address value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_AddressList._Address> Values
        {
            get
            {
                ICollection<_Address> values = new List<_Address>();
                foreach (_Address item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _AddressList._Address this[int key]
        {
            get
            {
                _Address result;
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
                _Address result;
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

        public void Add(KeyValuePair<int, _AddressList._Address> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _AddressList._Address> item)
        {
            _Address value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Address>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _AddressList._Address>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _AddressList._Address> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _AddressList._Address>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public class _Address
        {
            public string Address { get; set; }
            public int Add_Moo { get; set; }
            public string Add_HomeName { get; set; }
            public string Add_Road { get; set; }
            public string Add_Soi { get; set; }
            public _DistrictList._District _District { get; set; }
            public _AmphurList._Amphur _Amphur { get; set; }
            public _ProvinceList._Province _Province { get; set; }
            public _Postel _Postel { get; set; }


            public _Address()
            {
                this.Address = string.Empty;
                this.Add_Moo = 0;
                this.Add_HomeName = string.Empty;
                this.Add_Road = string.Empty;
                this.Add_Soi = string.Empty;
                this._District = new _DistrictList._District();
                this._Amphur = new _AmphurList._Amphur();
                this._Province = new _ProvinceList._Province();
                this._Postel = new _Postel();
            }
        }
    }
    
}