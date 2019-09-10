using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class SearchMCNumber
    {
        private CStatement _statement;
        private CStatement _statementChk;

        public _Customer _Customer { get; set; }
        public _AddressList._Address _Address { get; set; }
        public _Purchase _Purchase { get; set; }

        public SearchMCNumber()
        {
            this._Customer = new _Customer();
            this._Address = new _AddressList._Address();
            this._Purchase = new _Purchase();
            this._statement = new CStatement("Select_MCNumber", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementChk = new CStatement("Select_CheckMCNumber", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        public void Select(int num, string MCNumber,int empid)
        {
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@MC_Number", DbType.String, MCNumber, ParameterDirection.Input);
                    plist.Add("@empid", DbType.Int32, empid, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    DataTable dt = (DataTable)cstate.Execute(adlist); ;

                    if (dt.Rows.Count > 0)
                    {
                        this._Customer.Name = dt.Rows[0]["Name"].ToString();
                        this._Customer.Surname = dt.Rows[0]["SurName"].ToString();
                        if (dt.Rows[0]["Birthday"].ToString() != string.Empty)
                        {
                            this._Customer.Birthday = DateTime.Parse(dt.Rows[0]["Birthday"].ToString());
                        }
                        this._Customer.IDCard = dt.Rows[0]["IDCard"].ToString();
                        this._Customer.Tel_Mobile1 = dt.Rows[0]["CusTel"].ToString();
                        this._Customer.Career_Remark = dt.Rows[0]["Career"].ToString();
                        this._Customer.CusType = dt.Rows[0]["CustomerType"].ToString();
                        this._Customer.CorporationCode = dt.Rows[0]["CorporationCode"].ToString();

                        this._Address.Address = dt.Rows[0]["Address"].ToString();
                        this._Address._District.DISTRICT_ID = int.Parse(dt.Rows[0]["District"].ToString());
                        this._Address._District.DISTRICT_NAME = dt.Rows[0]["DISTRICT_NAME"].ToString();
                        this._Address._Amphur.AMPHUR_ID = int.Parse(dt.Rows[0]["Amphur"].ToString());
                        this._Address._Amphur.AMPHUR_NAME = dt.Rows[0]["AMPHUR_NAME"].ToString();
                        this._Address._Province.PROVINCE_ID = int.Parse(dt.Rows[0]["Province"].ToString());
                        this._Address._Province.PROVINCE_NAME = dt.Rows[0]["PROVINCE_NAME"].ToString();
                        this._Address._Postel.Postel_Code = dt.Rows[0]["Postel"].ToString();

                        this._Purchase.EmpID = int.Parse(dt.Rows[0]["EmpID"].ToString());
                        if (dt.Rows[0]["OutCar_Date"].ToString() != string.Empty)
                        {
                            this._Purchase.Purchase_Date = DateTime.Parse(dt.Rows[0]["OutCar_Date"].ToString());
                        }
                        this._Purchase.SaleName = dt.Rows[0]["SaleName"].ToString();
                        this._Purchase.BookID = int.Parse(dt.Rows[0]["BookID"].ToString());
                        this._Purchase.BookNo = dt.Rows[0]["BookNo"].ToString();
                        this._Purchase.ProspectNo = dt.Rows[0]["ProspectNo"].ToString();
                        this._Purchase._Company.Companycode = dt.Rows[0]["BCode_Name"].ToString();
                        this._Purchase.MCNumber = dt.Rows[0]["MCNumber"].ToString();
                        this._Purchase.TruckNumber = dt.Rows[0]["TruckNumber"].ToString();
                        this._Purchase.MCode = dt.Rows[0]["MCode"].ToString();
                        this._Purchase.MName = dt.Rows[0]["MName"].ToString();
                        this._Purchase.MSaleCode = dt.Rows[0]["MSaleCode"].ToString();
                        this._Purchase.CCode = dt.Rows[0]["CCode"].ToString();
                        this._Purchase.CName = dt.Rows[0]["CName"].ToString();
                        this._Purchase.CarPrice = decimal.Parse(dt.Rows[0]["CarPrice"].ToString());
                        this._Purchase.StatusCE = dt.Rows[0]["StatusCE"].ToString();
                        this._Purchase.CE_Brand = dt.Rows[0]["CE_Brand"].ToString();
                        this._Purchase.CE_Model = dt.Rows[0]["CE_Model"].ToString();
                        this._Purchase.CE_Year = dt.Rows[0]["CE_Year"].ToString();
                        this._Purchase.CE_Price = decimal.Parse(dt.Rows[0]["CE_Price"].ToString());
                        this._Purchase.Buy_Type = dt.Rows[0]["Buy_Type"].ToString();
                        this._Purchase._Finance.ID = int.Parse(dt.Rows[0]["Finance"].ToString());
                        this._Purchase.PayDown = decimal.Parse(dt.Rows[0]["PayDown"].ToString());
                        this._Purchase.DepositNo = dt.Rows[0]["DepositNo"].ToString();
                        if (dt.Rows[0]["DepositDate"].ToString() != string.Empty)
                        {
                            this._Purchase.DepositDate = DateTime.Parse(dt.Rows[0]["DepositDate"].ToString());
                        }
                        this._Purchase.DepositPrice = decimal.Parse(dt.Rows[0]["DepositPrice"].ToString());
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

        public void SelectChk(int num, string MCNumber)
        {
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plistChk = new CSQLParameterList();
                    plistChk.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plistChk.Add("@MC_Number", DbType.String, MCNumber, ParameterDirection.Input);
                    CSQLDataAdepterList adlistChk = new CSQLDataAdepterList();
                    CSQLStatementValue csvChk = new CSQLStatementValue(this._statementChk, plistChk, NoomLibrary.StatementType.Select);
                    adlistChk.Add(csvChk);
                    cstate.Open();
                    DataTable dt = (DataTable)cstate.Execute(adlistChk); ;

                    if (dt.Rows.Count > 0)
                    {
                        this._Purchase.ID = int.Parse(dt.Rows[0]["ID"].ToString());
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


    public class _InregisList : IDictionary<int, _InregisList._Inregis>
    {
        private CStatement _statement;

        private Dictionary<int, _Inregis> _list = new Dictionary<int, _Inregis>();

        public _InregisList()
        {
            this._statement = new CStatement("SELECT_InRegis", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _InregisList._Inregis value)
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

        public bool TryGetValue(int key, out _InregisList._Inregis value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_InregisList._Inregis> Values
        {
            get
            {
                ICollection<_Inregis> values = new List<_Inregis>();
                foreach (_Inregis item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _InregisList._Inregis this[int key]
        {
            get
            {
                _Inregis result;
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
                _Inregis result;
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

        public void Add(KeyValuePair<int, _InregisList._Inregis> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _InregisList._Inregis> item)
        {
            _Inregis value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_Inregis>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _InregisList._Inregis>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _InregisList._Inregis> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _InregisList._Inregis>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public object Select(int num, int BookID)
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
                        _Inregis _c = new _Inregis();
                        _c.ID = id;
                        _c.Name = item["Name"].ToString();
                        _c.InName = item["InName"].ToString();
                        if (item["InID"].ToString() != string.Empty)
                        {
                            _c.InID = int.Parse(item["InID"].ToString());
                        }
                        _c.Budget = decimal.Parse(item["Budget"].ToString());
                        _c.Free = item["Free"].ToString();
                        _c.CarType = item["CarType"].ToString();
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


        public class _Inregis
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string InName { get; set; }
            public int InID { get; set; }
            public decimal Budget { get; set; }
            public string Free { get; set; }
            public string CarType { get; set; }

            public _Inregis()
            {
                this.ID = 0;
                this.Name = string.Empty;
                this.InName = string.Empty;
                this.InID = 0;
                this.Budget = 0;
                this.Free = string.Empty;
                this.CarType = string.Empty;
            }
        }
    }
}