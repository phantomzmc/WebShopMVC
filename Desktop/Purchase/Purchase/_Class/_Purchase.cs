using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;
using Purchase._Class;


namespace Purchase
{
    public class _Purchase
    {
        private CStatement _statement;
        private CStatement _statementCus;
        private CStatement _statementCE;
        private CStatement _statementInsurance1;
        private CStatement _statementRegis;
        private CStatement _statementAct;
        private CStatement _statementTranspot;
        private CStatement _statementSetAcc;
        private CStatement _statementSetAccDetail;
        private CStatement _statementSetAccSTD;
        private CStatement _statementSetAccSTDDetail;
        private CStatement _statementSetAddAcc;
        private CStatement _statementSetAddAccDetail;
        private CStatement _statementPO;
        private CStatement _statementDc;
        private CStatement _statementLOGPRINT;
        private CStatement _statementBody;
        private CStatement _statementBodyExtra;

        public int ID { get; set; }
        public _CompanyList._Company _Company { get; set; }
        public DateTime Purchase_Date {get;set;}
        public DateTime OutCar_Date { get; set; }
        public int EmpID { get; set; }
        public string Emp_Company { get; set; }
        public string Emp_Branch { get; set; }
        public string Emp_Team { get; set; }
        public string SaleName { get; set; }
        public int BookID { get; set; }
        public string PurchaseNo { get; set; }
        public string BookNo { get; set; }
        public string ProspectNo { get; set; }
        public int CusID { get; set; }
        public string CarName { get; set; }
        public string MCNumber { get; set; }
        public string TruckNumber { get; set; }
        public string MCode { get; set; }
        public string MName { get; set; }
        public string MSaleCode { get; set; }
        public string CCode { get; set; }
        public string CName { get; set; }
        public decimal CarPrice { get; set; }
        public string CarPlate { get; set; }
        public DateTime Regis_Date { get; set; }
        public string CarTax { get; set; }
        public _CarTypeList._CarType _CarType { get; set; }
        public string StatusCE { get; set; }
        public string CarExchange { get; set; }
        public string CE_MCNumber { get; set; }
        public string CE_TruckNumber { get; set; }
        public string CE_Brand { get; set; }
        public string CE_Model { get; set; }
        public string CE_Color { get; set; }
        public string CE_Year { get; set; }
        public string CE_CarPlate { get; set; }
        public decimal CE_Price { get; set; }
        public string CE_Emp { get; set; }
        public _InsuranceList._Insurance _Insurance { get; set; }
        public string Check_In { get; set; }
        public string Check_Re { get; set; }
        public decimal Insurance_Budget { get; set; }
        public string Buy_Type { get; set; }
        public _FinanceList._Finance _Finance { get; set; }
        public string Emp_Finance { get; set; }
        public decimal PayDown { get; set; }
        public int Body_Acc_ID { get; set; }
        public string Body_Type { get; set; }
        public int Body_Extra_Company { get; set; }
        public string CarPriceAd { get; set; }
        public decimal CarPriceAd_Price { get; set; }
        public decimal Body_Price_finance { get; set; }
        public decimal Body_Price_Pay { get; set; }
        public decimal Body_Price_SumAddBody { get; set; }
        public decimal LoanProtection { get; set; }
        public decimal DPeak { get; set; }
        public decimal hpcost { get; set; }
        public decimal Interest { get; set; }
        public string Remark_Interest { get; set; }
        public int Pay_Begin { get; set; }
        public decimal Total_Payment { get; set; }
        public decimal Price_Payment { get; set; }
        public string CampaignName { get; set; }
        public string DepositNo { get; set; }
        public DateTime DepositDate { get; set; }
        public decimal DepositPrice { get; set; }
        public string DepositAdNo { get; set; }
        public DateTime DepositAdDate { get; set; }
        public decimal DepositAdPrice { get; set; }
        public string C_IDCard { get; set; }
        public string C_HouseRegistration { get; set; }
        public string C_Scrape { get; set; }
        public string C_ActInsurance { get; set; }
        public string C_Finance { get; set; }
        public string C_CVIP { get; set; }
        public decimal PriceSumCar { get; set; }
        public decimal PriceSum { get; set; }
        public string PayCash_No { get; set; }
        public DateTime PayCash_Date { get; set; }
        public decimal PayCase_Price { get; set; }
        public int PayTM { get; set; }
        public string PayTM_No { get; set; }
        public DateTime PayTM_Date { get; set; }
        public decimal PayTM_Price { get; set; }
        public int PayCheque { get; set; }
        public string PayCheque_No { get; set; }
        public DateTime PayCheque_Date { get; set; }
        public decimal PayCheque_Price { get; set; }
        public decimal RepayToCus { get; set; }
        public string RedCarPlate_No { get; set; }
        public DateTime RedCarPlate_Date { get; set; }
        public decimal RedCarPlate_Price { get; set; }
        public string RedCarPlate_Num { get; set; }
        public string Remark { get; set; }
        public string PoNum { get; set; }
        public int User_Edit { get; set; }
        public DateTime ToCustomerByDate { get; set; }
        public _Customer _Customer { get; set; }
        public _AddressList._Address _Address { get; set; }
        public _Accessorieslist._SetAcc _SetAcc { get; set; }
        public _AccessoriesSTDList._SetAccSTD _SetAccSTD { get; set; }
        public _AdAccessoriesList._AddAcc _AddAcc { get; set; }
        public _DiscountList._Discount _Dc { get; set; }
        //public decimal Acc_Discount { get; set; }
        public string ChkP { get; set; }
        public string ChkIn1 { get; set; }
        public string Chk_UpAcc { get; set; }
        public _Insurance1 _Insurance1 { get; set; }
        public string ChkRegis { get; set; }
        public _Regis _Regis { get; set; }
        public string ChkAct { get; set; }
        public _Act _Act { get; set; }
        public string ChkTranspot { get; set; }
        public _Transpot _Transpot { get; set; }
        public string ChkSetAcc { get; set; }
        public _Accessorieslist _SetAccList { get; set; }
        public string ChkSetAccSTD { get; set; }
        public _AccessoriesSTDList _SetAccSTDList { get; set; }
        public string ChkSetAddAcc { get; set; }
        public _AdAccessoriesList _SetAddAccList { get; set; }
        public string ChkDc { get; set; }
        public _DiscountList _DcList { get; set; }
        public BodyOptionList _SetBodyOptionList { get; set; }
        public BodyOptionList.BodyOption _BodyOptionAcc { get; set; }
        public BodyOptionExtraList _SetBodyOptionExtraList { get; set; }
        public BodyOptionExtraList.BodyOptionExtra _BodyOptionExtraAcc { get; set; }

        public _Purchase()
        {
            this.ID = 0;
            this._Company = new _CompanyList._Company();
            this.Purchase_Date = DateTime.MinValue;
            this.OutCar_Date = DateTime.MinValue;
            this.EmpID = 0;
            this.Emp_Company = string.Empty;
            this.Emp_Branch = string.Empty;
            this.Emp_Team = string.Empty;
            this.SaleName = string.Empty;
            this.PurchaseNo = string.Empty;
            this.BookNo = string.Empty;
            this.ProspectNo = string.Empty;
            this.CusID = 0;
            this.CarName = string.Empty;
            this.MCNumber = string.Empty;
            this.TruckNumber = string.Empty;
            this.MCode = string.Empty;
            this.MName = string.Empty;
            this.MSaleCode = string.Empty;
            this.CCode = string.Empty;
            this.CName = string.Empty;
            this.CarPrice = 0;
            this.CarPlate = string.Empty;
            this.Regis_Date = DateTime.MinValue;
            this.CarTax = string.Empty;
            this._CarType = new _CarTypeList._CarType();
            this.StatusCE = string.Empty;
            this.CarExchange = string.Empty;
            this.CE_MCNumber = string.Empty;
            this.CE_TruckNumber = string.Empty;
            this.CE_Brand = string.Empty;
            this.CE_Model = string.Empty;
            this.CE_Color = string.Empty;
            this.CE_Year = string.Empty;
            this.CE_CarPlate = string.Empty;
            this.CE_Price = 0;
            this.CE_Emp = string.Empty;
            this._Insurance = new _InsuranceList._Insurance();
            this.Check_In = string.Empty;
            this.Check_Re = string.Empty;
            this.Insurance_Budget = 0;
            this.Buy_Type = string.Empty;
            this._Finance = new _FinanceList._Finance();
            this.Emp_Finance = string.Empty;
            this.PayDown = 0;
            this.Body_Acc_ID = 0;
            this.Body_Type = string.Empty;
            this.Body_Extra_Company = 0;
            this.CarPriceAd = string.Empty;
            this.CarPriceAd_Price = 0;
            this.Body_Price_finance = 0;
            this.Body_Price_Pay = 0;
            this.CarPriceAd_Price = 0;
            this.Body_Price_SumAddBody = 0;
            this.DPeak = 0;
            this.hpcost = 0;
            this.Interest = 0;
            this.Remark_Interest = string.Empty;
            this.Pay_Begin = 0;
            this.Total_Payment = 0;
            this.Price_Payment = 0;
            this.CampaignName = string.Empty;
            this.DepositNo = string.Empty;
            this.DepositDate = DateTime.MinValue;
            this.DepositPrice = 0;
            this.DepositAdNo = string.Empty;
            this.DepositAdDate = DateTime.MinValue;
            this.DepositAdPrice = 0;
            this.C_IDCard = "N";
            this.C_HouseRegistration = "N";
            this.C_Scrape = "N";
            this.C_ActInsurance = "N";
            this.C_Finance = "N";
            this.C_CVIP = "N";
            this.PriceSumCar = 0;
            this.PriceSum = 0;
            this.PayCash_No = string.Empty;
            this.PayCash_Date = DateTime.MinValue;
            this.PayCase_Price = 0;
            this.PayTM = 0;
            this.PayTM_No = string.Empty;
            this.PayTM_Date = DateTime.MinValue;
            this.PayTM_Price = 0;
            this.PayCheque = 0;
            this.PayCheque_No = string.Empty;
            this.PayCheque_Date = DateTime.MinValue;
            this.PayCheque_Price = 0;
            this.RepayToCus = 0;
            this.RedCarPlate_No = string.Empty;
            this.RedCarPlate_Date = DateTime.MinValue;
            this.RedCarPlate_Price = 0;
            this.RedCarPlate_Num = string.Empty;
            this.Remark = string.Empty;
            this.PoNum = string.Empty;
            this.User_Edit = 0;
            this.ToCustomerByDate = DateTime.MinValue;
            this._Customer = new _Customer();
            this._Address = new _AddressList._Address();
            this._SetAcc = new _Accessorieslist._SetAcc();
            this._SetAccSTD = new _AccessoriesSTDList._SetAccSTD();
            this._AddAcc = new _AdAccessoriesList._AddAcc();
            this._Dc = new _DiscountList._Discount();
            //this.Acc_Discount = 0;
            this.ChkP = "N";
            this.ChkIn1 = "N";
            this.Chk_UpAcc = "N";
            this._Insurance1 = new _Insurance1();
            this.ChkRegis = "N";
            this._Regis = new _Regis();
            this.ChkAct = "N";
            this._Act = new _Act();
            this.ChkTranspot = "N";
            this._Transpot = new _Transpot();
            this.ChkSetAcc = "N";
            this._SetAccList = new _Accessorieslist();
            this.ChkSetAccSTD = "N";
            this._SetAccSTDList = new _AccessoriesSTDList();
            this.ChkSetAddAcc = "N";
            this._SetAddAccList = new _AdAccessoriesList();
            this._SetBodyOptionList = new BodyOptionList();
            this._BodyOptionAcc = new BodyOptionList.BodyOption();
            this._SetBodyOptionExtraList = new BodyOptionExtraList();
            this._BodyOptionExtraAcc = new BodyOptionExtraList.BodyOptionExtra();
            this.ChkDc = "N";
            this._DcList = new _DiscountList();
            this._statement = new CStatement("Select_MaxPurchaseNo", "INSERT_Purchase", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementCus = new CStatement("SELECT", "INSERT_Customer", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementCE = new CStatement("SELECT", "INSERT_CarExchange", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementInsurance1 = new CStatement("SELECT", "INSERT_Insurance1", "UPDATE_Insurance1", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementRegis = new CStatement("SELECT", "INSERT_Regis", "UPDATE_Regis", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementAct = new CStatement("SELECT", "INSERT_Act", "UPDATE_Act", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementTranspot = new CStatement("SELECT", "INSERT_Transpot", "UPDATE_Transpot", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementSetAcc = new CStatement("SELECT", "INSERT_SetAcc", "UPDATE_SetAcc", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementSetAccDetail = new CStatement("SELECT", "INSERT_SetAccDetail", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementSetAccSTD = new CStatement("SELECT", "INSERT_SetAccSTD", "UPDATE_SetAccSTD", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementSetAccSTDDetail = new CStatement("SELECT", "INSERT_SetAccSTDDetail", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementSetAddAcc = new CStatement("SELECT", "INSERT_SetAddAcc", "UPDATE_SetAddAcc", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementSetAddAccDetail = new CStatement("SELECT", "INSERT_SetAddAccDetail", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementPO = new CStatement("SELECT_Purchase", "INSER", "UPDATE_Purchase", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementDc = new CStatement("SELECT", "INSERT_AccDiscount", "UPDATE", "DELETE_AccDiscount", System.Data.CommandType.StoredProcedure);
            this._statementLOGPRINT = new CStatement("SELECT", "SELECT_LOGPRINTPurchase", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementBody = new CStatement("SELECT", "Body_Insert_Option", "UPDATE", "Body_Delect_Option", System.Data.CommandType.StoredProcedure);
            this._statementBodyExtra = new CStatement("SELECT", "Body_Insert_OptionExtra", "UPDATE", "Body_Delect_OptionExtra", System.Data.CommandType.StoredProcedure);
        }

        public DataTable Select_Purchase(int num, string _MCNumber)
        {
            DataTable _dt = new DataTable();
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@MCNumber", DbType.String, _MCNumber, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statementPO, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    _dt = (DataTable)cstate.Execute(adlist);
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
            return _dt;
        }


        public object InsertLOGPRINTPurchase(int IDCheck)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    cstate.Open();
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@ID", DbType.Int32, IDCheck, ParameterDirection.Input);
                    CSQLStatementValue csv = new CSQLStatementValue(this._statementLOGPRINT, plist, NoomLibrary.StatementType.Insert);
                    adlist.Add(csv);
                    cstate.Execute(adlist);
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

        public void Select(int num, string _Company, string _M, string _Y)
        {
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@_Company", DbType.String, _Company, ParameterDirection.Input);
                    plist.Add("@_Month", DbType.String, _M, ParameterDirection.Input);
                    plist.Add("@_Year", DbType.String, _Y, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    DataTable dt = (DataTable)cstate.Execute(adlist);

                    if (dt.Rows.Count > 0)
                    {

                        this.PurchaseNo = dt.Rows[0]["PurchaseNo"].ToString();
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

        public DataTable Select_MaxPurchaseNo(int num, string _Company, string _M, string _Y)
        {
            DataTable _dt = new DataTable();
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@_Company", DbType.String, _Company, ParameterDirection.Input);
                    plist.Add("@_Month", DbType.String, _M, ParameterDirection.Input);
                    plist.Add("@_Year", DbType.String, _Y, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    _dt = (DataTable)cstate.Execute(adlist);
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
            return _dt;
        }

        public object Insert(_Purchase _p)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    cstate.Open();
                    int _CusID = 0;
                    if (_p._Customer.ID == 0)
                    {

                        CSQLDataAdepterList adlistCus = new CSQLDataAdepterList();
                        CSQLParameterList plistCus = new CSQLParameterList();
                        plistCus.Add("@ID", DbType.Int32, ParameterDirection.Output);
                        plistCus.Add("@CusNo", DbType.String, _p._Customer.CusNo, ParameterDirection.Input);
                        plistCus.Add("@CusType", DbType.String, _p._Customer.CusType, ParameterDirection.Input);
                        plistCus.Add("@CorporationCode", DbType.String, _p._Customer.CorporationCode, ParameterDirection.Input);
                        plistCus.Add("@Prefix", DbType.String, _p._Customer.Prefix, ParameterDirection.Input);
                        plistCus.Add("@Name", DbType.String, _p._Customer.Name, ParameterDirection.Input);
                        plistCus.Add("@Surname", DbType.String, _p._Customer.Surname, ParameterDirection.Input);
                        plistCus.Add("@Nickname", DbType.String, _p._Customer.Nickname, ParameterDirection.Input);
                        plistCus.Add("@Sex", DbType.String, _p._Customer.Sex, ParameterDirection.Input);
                        plistCus.Add("@Birthday", DbType.Date, _p._Customer.Birthday, ParameterDirection.Input);
                        plistCus.Add("@IDCard", DbType.String, _p._Customer.IDCard, ParameterDirection.Input);
                        plistCus.Add("@Education", DbType.Int32, _p._Customer._Education.id, ParameterDirection.Input);
                        plistCus.Add("@Total_Member", DbType.Int32, _p._Customer.Total_Member, ParameterDirection.Input);
                        plistCus.Add("@Tel_Mobile1", DbType.String, _p._Customer.Tel_Mobile1, ParameterDirection.Input);
                        plistCus.Add("@Tel_Mobile2", DbType.String, _p._Customer.Tel_Mobile2, ParameterDirection.Input);
                        plistCus.Add("@Tel_Work", DbType.String, _p._Customer.Tel_Work, ParameterDirection.Input);
                        plistCus.Add("@Tel_Fax", DbType.String, _p._Customer.Tel_Fax, ParameterDirection.Input);
                        plistCus.Add("@LineID", DbType.String, _p._Customer.LineID, ParameterDirection.Input);
                        plistCus.Add("@Career", DbType.Int32, _p._Customer._Career.ID, ParameterDirection.Input);
                        plistCus.Add("@Career_Other", DbType.String, _p._Customer.Career_Other, ParameterDirection.Input);
                        plistCus.Add("@Career_Remark", DbType.String, _p._Customer.Career_Remark, ParameterDirection.Input);
                        plistCus.Add("@Income", DbType.Int32, _p._Customer._Income.ID, ParameterDirection.Input);
                        plistCus.Add("@SendAddress_IDCard", DbType.String, _p._Customer.SendAddress_IDCard, ParameterDirection.Input);

                        foreach (var item in this._Customer._AddressList.Values)
                        {
                            plistCus.Add("@Address", DbType.String, item.Address, ParameterDirection.Input);
                            plistCus.Add("@Add_Moo", DbType.Int32, item.Add_Moo, ParameterDirection.Input);
                            plistCus.Add("@Add_HomeName", DbType.String, item.Add_HomeName, ParameterDirection.Input);
                            plistCus.Add("@Add_Road", DbType.String, item.Add_Road, ParameterDirection.Input);
                            plistCus.Add("@Add_Soi", DbType.String, item.Add_Soi, ParameterDirection.Input);
                            plistCus.Add("@Add_District", DbType.Int32, item._District.DISTRICT_ID, ParameterDirection.Input);
                            plistCus.Add("@Add_Amphur", DbType.Int32, item._Amphur.AMPHUR_ID, ParameterDirection.Input);
                            plistCus.Add("@Add_Province", DbType.Int32, item._Province.PROVINCE_ID, ParameterDirection.Input);
                            plistCus.Add("@Add_Postel", DbType.String, item._Postel.Postel_Code, ParameterDirection.Input);
                        }

                        if (_p._Customer.SendAddress_IDCard.ToString() == "N")
                        {
                            foreach (var item in this._Customer._SentAddressList.Values)
                            {
                                plistCus.Add("@SendAddress", DbType.String, item.Address, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_Moo", DbType.Int32, item.Add_Moo, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_HomeName", DbType.String, item.Add_HomeName, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_Road", DbType.String, item.Add_Road, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_Soi", DbType.String, item.Add_Soi, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_District", DbType.Int32, item._District.DISTRICT_ID, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_Amphur", DbType.Int32, item._Amphur.AMPHUR_ID, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_Province", DbType.Int32, item._Province.PROVINCE_ID, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_Postel", DbType.String, item._Postel.Postel_Code, ParameterDirection.Input);
                            }
                        }
                        else
                        {
                            foreach (var item in this._Customer._AddressList.Values)
                            {
                                plistCus.Add("@SendAddress", DbType.String, item.Address, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_Moo", DbType.Int32, item.Add_Moo, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_HomeName", DbType.String, item.Add_HomeName, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_Road", DbType.String, item.Add_Road, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_Soi", DbType.String, item.Add_Soi, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_District", DbType.Int32, item._District.DISTRICT_ID, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_Amphur", DbType.Int32, item._Amphur.AMPHUR_ID, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_Province", DbType.Int32, item._Province.PROVINCE_ID, ParameterDirection.Input);
                                plistCus.Add("@SendAdd_Postel", DbType.String, item._Postel.Postel_Code, ParameterDirection.Input);
                            }
                        }
                        plistCus.Add("@User_Add", DbType.Int32, _p._Customer.User_Add, ParameterDirection.Input);
                        CSQLStatementValue csvMaster = new CSQLStatementValue(this._statementCus, plistCus, NoomLibrary.StatementType.Insert);
                        adlistCus.Add(csvMaster);
                        cstate.Execute(adlistCus);

                        _CusID = int.Parse(plistCus["@ID"].Value.ToString());
                    }
                    else
                    {
                        _CusID = _p._Customer.ID;
                    }

                    CSQLDataAdepterList adlistPurchase = new CSQLDataAdepterList();
                    CSQLParameterList plistPurchase = new CSQLParameterList();
                    plistPurchase.Add("@ID", DbType.Int32, ParameterDirection.Output);
                    plistPurchase.Add("@Company", DbType.String, _p._Company.Companycode, ParameterDirection.Input);
                    plistPurchase.Add("@Purchase_Date", DbType.Date, _p.Purchase_Date, ParameterDirection.Input);
                    plistPurchase.Add("@EmpID", DbType.Int32, _p.EmpID, ParameterDirection.Input);
                    plistPurchase.Add("@Emp_Company", DbType.String, _p.Emp_Company, ParameterDirection.Input);
                    plistPurchase.Add("@Emp_Branch", DbType.String, _p.Emp_Branch, ParameterDirection.Input);
                    plistPurchase.Add("@Emp_Team", DbType.String, _p.Emp_Team, ParameterDirection.Input);
                    plistPurchase.Add("@PurchaseNo", DbType.String, _p.PurchaseNo, ParameterDirection.Input);
                    plistPurchase.Add("@BookNo", DbType.String, _p.BookNo, ParameterDirection.Input);
                    plistPurchase.Add("@ProspectNo", DbType.String, _p.ProspectNo, ParameterDirection.Input);
                    plistPurchase.Add("@CusID", DbType.Int32, _CusID, ParameterDirection.Input);
                    plistPurchase.Add("@CarName", DbType.String, _p.CarName, ParameterDirection.Input);
                    plistPurchase.Add("@BuyType", DbType.String, _p.Buy_Type, ParameterDirection.Input);
                    plistPurchase.Add("@MCNumber", DbType.String, _p.MCNumber, ParameterDirection.Input);
                    plistPurchase.Add("@TruckNumber", DbType.String, _p.TruckNumber, ParameterDirection.Input);
                    plistPurchase.Add("@MName", DbType.String, _p.MName, ParameterDirection.Input);
                    plistPurchase.Add("@MSaleCode", DbType.String, _p.MSaleCode, ParameterDirection.Input);
                    plistPurchase.Add("@CName", DbType.String, _p.CName, ParameterDirection.Input);
                    plistPurchase.Add("@CarPrice", DbType.Decimal, _p.CarPrice, ParameterDirection.Input);
                    plistPurchase.Add("@CarPlate", DbType.String, _p.CarPlate, ParameterDirection.Input);
                    plistPurchase.Add("@StatusCE", DbType.String, _p.StatusCE, ParameterDirection.Input);
                    //plistPurchase.Add("@Acc_Discount", DbType.Decimal, _p.Acc_Discount, ParameterDirection.Input);
                    plistPurchase.Add("@Finance", DbType.Int32, _p._Finance.ID, ParameterDirection.Input);
                    plistPurchase.Add("@Finance_Au", DbType.String, _p.Emp_Finance, ParameterDirection.Input);
                    plistPurchase.Add("@PayDown", DbType.Decimal, _p.PayDown, ParameterDirection.Input);
                    plistPurchase.Add("@Body_Acc_ID", DbType.Int32, _p.Body_Acc_ID, ParameterDirection.Input);
                    plistPurchase.Add("@Body_Type", DbType.String, _p.Body_Type, ParameterDirection.Input);
                    plistPurchase.Add("@Body_Extra_Company", DbType.Int32, _p.Body_Extra_Company, ParameterDirection.Input);
                    plistPurchase.Add("@CarPriceAd", DbType.String, _p.CarPriceAd, ParameterDirection.Input);
                    plistPurchase.Add("@CarPriceAd_Price", DbType.Decimal, _p.CarPriceAd_Price, ParameterDirection.Input);
                    plistPurchase.Add("@Body_Price_finance", DbType.Decimal, _p.Body_Price_finance, ParameterDirection.Input);
                    plistPurchase.Add("@Body_Price_Pay", DbType.Decimal, _p.Body_Price_Pay, ParameterDirection.Input);
                    plistPurchase.Add("@Body_Price_SumAddBody", DbType.Decimal, _p.Body_Price_SumAddBody, ParameterDirection.Input);
                    plistPurchase.Add("@LoanProtection", DbType.Decimal, _p.LoanProtection, ParameterDirection.Input);
                    plistPurchase.Add("@DPeak", DbType.Decimal, _p.DPeak, ParameterDirection.Input);
                    plistPurchase.Add("@hpcost", DbType.Decimal, _p.hpcost, ParameterDirection.Input);
                    plistPurchase.Add("@Interest", DbType.Decimal, _p.Interest, ParameterDirection.Input);
                    plistPurchase.Add("@Interest_Remark", DbType.String, _p.Remark_Interest, ParameterDirection.Input);
                    plistPurchase.Add("@Pay_Begin", DbType.Int32, _p.Pay_Begin, ParameterDirection.Input);
                    plistPurchase.Add("@Total_Payment", DbType.Int32, _p.Total_Payment, ParameterDirection.Input);
                    plistPurchase.Add("@Price_Payment", DbType.Decimal, _p.Price_Payment, ParameterDirection.Input);
                    plistPurchase.Add("@PriceSumCar", DbType.Decimal, _p.PriceSumCar, ParameterDirection.Input);
                    plistPurchase.Add("@PriceSum", DbType.Decimal, _p.PriceSum, ParameterDirection.Input);
                    plistPurchase.Add("@CampaignName", DbType.String, _p.CampaignName, ParameterDirection.Input);
                    plistPurchase.Add("@DepositNo", DbType.String, _p.DepositNo, ParameterDirection.Input);
                    plistPurchase.Add("@DepositDate", DbType.Date, _p.DepositDate, ParameterDirection.Input);
                    plistPurchase.Add("@DepositPrice", DbType.Decimal, _p.DepositPrice, ParameterDirection.Input);
                    plistPurchase.Add("@DepositAdNo", DbType.String, _p.DepositAdNo, ParameterDirection.Input);
                    plistPurchase.Add("@DepositAdDate", DbType.Date, _p.DepositAdDate, ParameterDirection.Input);
                    plistPurchase.Add("@DepositAdPrice", DbType.Decimal, _p.DepositAdPrice, ParameterDirection.Input);
                    plistPurchase.Add("@RedCarPlate_No", DbType.String, _p.RedCarPlate_No, ParameterDirection.Input);
                    plistPurchase.Add("@RedCarPlate_Date", DbType.Date, _p.RedCarPlate_Date, ParameterDirection.Input);
                    plistPurchase.Add("@RedCarPlate_Price", DbType.Decimal, _p.RedCarPlate_Price, ParameterDirection.Input);
                    plistPurchase.Add("@RedCarPlate_Num", DbType.String, _p.RedCarPlate_Num, ParameterDirection.Input);
                    plistPurchase.Add("@Remark", DbType.String, _p.Remark, ParameterDirection.Input);
                    plistPurchase.Add("@C_IDCard", DbType.String, _p.C_IDCard, ParameterDirection.Input);
                    plistPurchase.Add("@C_HouseRegistration", DbType.String, _p.C_HouseRegistration, ParameterDirection.Input);
                    plistPurchase.Add("@C_Scrape", DbType.String, _p.C_Scrape, ParameterDirection.Input);
                    plistPurchase.Add("@C_ActInsurance", DbType.String, _p.C_ActInsurance, ParameterDirection.Input);
                    plistPurchase.Add("@C_Finance", DbType.String, _p.C_Finance, ParameterDirection.Input);
                    plistPurchase.Add("@C_CVIP", DbType.String, _p.C_CVIP, ParameterDirection.Input);
                    plistPurchase.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                    CSQLStatementValue csvPurchase = new CSQLStatementValue(this._statement, plistPurchase, NoomLibrary.StatementType.Insert);
                    adlistPurchase.Add(csvPurchase);
                    cstate.Execute(adlistPurchase);
                    if (_p.StatusCE == "Y")
                    {
                        CSQLDataAdepterList adlistCE = new CSQLDataAdepterList();
                        CSQLParameterList plistCE = new CSQLParameterList();
                        plistCE.Add("@PurchaseID", DbType.Int32, plistPurchase["@ID"].Value, ParameterDirection.Input);
                        plistCE.Add("@CE_MCNumber", DbType.String, _p.CE_MCNumber, ParameterDirection.Input);
                        plistCE.Add("@CE_TruckNumber", DbType.String, _p.CE_TruckNumber, ParameterDirection.Input);
                        plistCE.Add("@CE_Brand", DbType.String, _p.CE_Brand, ParameterDirection.Input);
                        plistCE.Add("@CE_Model", DbType.String, _p.CE_Model, ParameterDirection.Input);
                        plistCE.Add("@CE_Color", DbType.String, _p.CE_Color, ParameterDirection.Input);
                        plistCE.Add("@CE_Year", DbType.String, _p.CE_Year, ParameterDirection.Input);
                        plistCE.Add("@CE_CarPlate", DbType.String, _p.CE_CarPlate, ParameterDirection.Input);
                        plistCE.Add("@CE_Price", DbType.Decimal, _p.CE_Price, ParameterDirection.Input);
                        plistCE.Add("@CE_Emp", DbType.String, _p.CE_Emp, ParameterDirection.Input);
                        plistCE.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                        CSQLStatementValue csvCE = new CSQLStatementValue(this._statementCE, plistCE, NoomLibrary.StatementType.Insert);
                        adlistCE.Add(csvCE);
                        cstate.Execute(adlistCE);
                    }

                    if (_p.ChkIn1 == "Y")
                    {
                        CSQLDataAdepterList adlistInsurance1 = new CSQLDataAdepterList();
                        CSQLParameterList plistInsurance1 = new CSQLParameterList();
                        plistInsurance1.Add("@PurchaseID", DbType.Int32, plistPurchase["@ID"].Value, ParameterDirection.Input);
                        plistInsurance1.Add("@InsuranceID", DbType.Int32, _p._Insurance1._Insurane.ID, ParameterDirection.Input);
                        plistInsurance1.Add("@Name", DbType.String, _p._Insurance1._Insurane.Name, ParameterDirection.Input);
                        plistInsurance1.Add("@Outlay", DbType.Decimal, _p._Insurance1.Outlay, ParameterDirection.Input);
                        plistInsurance1.Add("@Price", DbType.String, _p._Insurance1.Price, ParameterDirection.Input);
                        plistInsurance1.Add("@Free", DbType.String, _p._Insurance1.Free, ParameterDirection.Input);
                        plistInsurance1.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                        CSQLStatementValue csvInsurance1 = new CSQLStatementValue(this._statementInsurance1, plistInsurance1, NoomLibrary.StatementType.Insert);
                        adlistInsurance1.Add(csvInsurance1);
                        cstate.Execute(adlistInsurance1);
                    }

                    if (_p.ChkRegis == "Y")
                    {
                        CSQLDataAdepterList adlistRegis = new CSQLDataAdepterList();
                        CSQLParameterList plistRegis = new CSQLParameterList();
                        plistRegis.Add("@PurchaseID", DbType.Int32, plistPurchase["@ID"].Value, ParameterDirection.Input);
                        plistRegis.Add("@Name", DbType.String, _p._Regis.Name, ParameterDirection.Input);
                        plistRegis.Add("@Price", DbType.String, _p._Regis.Price, ParameterDirection.Input);
                        plistRegis.Add("@Free", DbType.String, _p._Regis.Free, ParameterDirection.Input);
                        plistRegis.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                        CSQLStatementValue csvRegis = new CSQLStatementValue(this._statementRegis, plistRegis, NoomLibrary.StatementType.Insert);
                        adlistRegis.Add(csvRegis);
                        cstate.Execute(adlistRegis);
                    }

                    if (_p.ChkAct == "Y")
                    {
                        CSQLDataAdepterList adlistAct = new CSQLDataAdepterList();
                        CSQLParameterList plistAct = new CSQLParameterList();
                        plistAct.Add("@PurchaseID", DbType.Int32, plistPurchase["@ID"].Value, ParameterDirection.Input);
                        plistAct.Add("@ActNo", DbType.String, _p._Act.ActNo, ParameterDirection.Input);
                        plistAct.Add("@Price", DbType.Decimal, _p._Act.Price, ParameterDirection.Input);
                        plistAct.Add("@Free", DbType.String, _p._Act.Free, ParameterDirection.Input);
                        plistAct.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                        CSQLStatementValue csvAct = new CSQLStatementValue(this._statementAct, plistAct, NoomLibrary.StatementType.Insert);
                        adlistAct.Add(csvAct);
                        cstate.Execute(adlistAct);
                    }

                    if (_p.ChkTranspot == "Y")
                    {
                        CSQLDataAdepterList adlistTranspot = new CSQLDataAdepterList();
                        CSQLParameterList plistTranspot = new CSQLParameterList();
                        plistTranspot.Add("@PurchaseID", DbType.Int32, plistPurchase["@ID"].Value, ParameterDirection.Input);
                        plistTranspot.Add("@Price", DbType.Decimal, _p._Transpot.Price, ParameterDirection.Input);
                        plistTranspot.Add("@Free", DbType.String, _p._Transpot.Free, ParameterDirection.Input);
                        plistTranspot.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                        CSQLStatementValue csvTranspot = new CSQLStatementValue(this._statementTranspot, plistTranspot, NoomLibrary.StatementType.Insert);
                        adlistTranspot.Add(csvTranspot);
                        cstate.Execute(adlistTranspot);
                    }

                    if (_p.ChkSetAcc == "Y")
                    {
                        CSQLDataAdepterList adlistSetAcc = new CSQLDataAdepterList();
                        CSQLParameterList plistSetAcc = new CSQLParameterList();
                        plistSetAcc.Add("@ID", DbType.Int32, ParameterDirection.Output);
                        plistSetAcc.Add("@PurchaseID", DbType.Int32, plistPurchase["@ID"].Value, ParameterDirection.Input);
                        plistSetAcc.Add("@Price", DbType.Decimal, _p._SetAcc.Price, ParameterDirection.Input);
                        plistSetAcc.Add("@Free", DbType.String, _p._SetAcc.Free, ParameterDirection.Input);
                        plistSetAcc.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                        CSQLStatementValue csvSetAcc = new CSQLStatementValue(this._statementSetAcc, plistSetAcc, NoomLibrary.StatementType.Insert);
                        adlistSetAcc.Add(csvSetAcc);
                        cstate.Execute(adlistSetAcc);

                        foreach (var item in this._SetAccList.Values)
                        {
                            CSQLDataAdepterList adlistSetAccDetail = new CSQLDataAdepterList();
                            CSQLParameterList plistSetAccDetail = new CSQLParameterList();
                            plistSetAccDetail.Add("@SetAccID", DbType.Int32, plistSetAcc["@ID"].Value, ParameterDirection.Input);
                            plistSetAccDetail.Add("@Name", DbType.String, item.Name, ParameterDirection.Input);
                            plistSetAccDetail.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                            CSQLStatementValue csvSetAccDetail = new CSQLStatementValue(this._statementSetAccDetail, plistSetAccDetail, NoomLibrary.StatementType.Insert);
                            adlistSetAccDetail.Add(csvSetAccDetail);
                            cstate.Execute(adlistSetAccDetail);
                        }
                    }

                    if (_p.ChkSetAccSTD == "Y")
                    {
                        CSQLDataAdepterList adlistSetAccSTD = new CSQLDataAdepterList();
                        CSQLParameterList plistSetAccSTD = new CSQLParameterList();
                        plistSetAccSTD.Add("@ID", DbType.Int32, ParameterDirection.Output);
                        plistSetAccSTD.Add("@PurchaseID", DbType.Int32, plistPurchase["@ID"].Value, ParameterDirection.Input);
                        plistSetAccSTD.Add("@Price", DbType.Decimal, _p._SetAccSTD.Price, ParameterDirection.Input);
                        plistSetAccSTD.Add("@Free", DbType.String, _p._SetAccSTD.Free, ParameterDirection.Input);
                        plistSetAccSTD.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                        CSQLStatementValue csvSetAccSTD = new CSQLStatementValue(this._statementSetAccSTD, plistSetAccSTD, NoomLibrary.StatementType.Insert);
                        adlistSetAccSTD.Add(csvSetAccSTD);
                        cstate.Execute(adlistSetAccSTD);

                        foreach (var item in this._SetAccSTDList.Values)
                        {
                            CSQLDataAdepterList adlistSetAccSTDDetail = new CSQLDataAdepterList();
                            CSQLParameterList plistSetAccSTDDetail = new CSQLParameterList();
                            plistSetAccSTDDetail.Add("@SetAccSTDID", DbType.Int32, plistSetAccSTD["@ID"].Value, ParameterDirection.Input);
                            plistSetAccSTDDetail.Add("@Name", DbType.String, item.Name, ParameterDirection.Input);
                            plistSetAccSTDDetail.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                            CSQLStatementValue csvSetAccSTDDetail = new CSQLStatementValue(this._statementSetAccSTDDetail, plistSetAccSTDDetail, NoomLibrary.StatementType.Insert);
                            adlistSetAccSTDDetail.Add(csvSetAccSTDDetail);
                            cstate.Execute(adlistSetAccSTDDetail);
                        }
                    }

                    if (_p.ChkSetAddAcc == "Y")
                    {
                        CSQLDataAdepterList adlistAddAcc = new CSQLDataAdepterList();
                        CSQLParameterList plistAddAcc = new CSQLParameterList();
                        plistAddAcc.Add("@ID", DbType.Int32, ParameterDirection.Output);
                        plistAddAcc.Add("@PurchaseID", DbType.Int32, plistPurchase["@ID"].Value, ParameterDirection.Input);
                        plistAddAcc.Add("@Price", DbType.Decimal, _p._AddAcc.Price, ParameterDirection.Input);
                        plistAddAcc.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                        CSQLStatementValue csvAddAcc = new CSQLStatementValue(this._statementSetAddAcc, plistAddAcc, NoomLibrary.StatementType.Insert);
                        adlistAddAcc.Add(csvAddAcc);
                        cstate.Execute(adlistAddAcc);

                        foreach (var item in this._SetAddAccList.Values)
                        {
                            CSQLDataAdepterList adlistAddAccDetail = new CSQLDataAdepterList();
                            CSQLParameterList plistAddAccDetail = new CSQLParameterList();
                            plistAddAccDetail.Add("@AddAccID", DbType.Int32, plistAddAcc["@ID"].Value, ParameterDirection.Input);
                            plistAddAccDetail.Add("@Name", DbType.String, item.Name, ParameterDirection.Input);
                            plistAddAccDetail.Add("@Price", DbType.Decimal, item.Price, ParameterDirection.Input);
                            plistAddAccDetail.Add("@Free", DbType.String, item.Free, ParameterDirection.Input);
                            plistAddAccDetail.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                            CSQLStatementValue csvAddAccDetail = new CSQLStatementValue(this._statementSetAddAccDetail, plistAddAccDetail, NoomLibrary.StatementType.Insert);
                            adlistAddAccDetail.Add(csvAddAccDetail);
                            cstate.Execute(adlistAddAccDetail);
                        }
                    }

                    if (_p.ChkDc == "Y")
                    {
                        foreach (var item in this._DcList.Values)
                        {
                            CSQLDataAdepterList adlistDc = new CSQLDataAdepterList();
                            CSQLParameterList plistDc = new CSQLParameterList();
                            plistDc.Add("@PurchaseID", DbType.Int32, plistPurchase["@ID"].Value, ParameterDirection.Input);
                            plistDc.Add("@Name", DbType.String, item.Name, ParameterDirection.Input);
                            plistDc.Add("@Price", DbType.Decimal, item.Price, ParameterDirection.Input);
                            plistDc.Add("@User_Add", DbType.String, _p._Customer.User_Add, ParameterDirection.Input);
                            CSQLStatementValue csvDc = new CSQLStatementValue(this._statementDc, plistDc, NoomLibrary.StatementType.Insert);
                            adlistDc.Add(csvDc);
                            cstate.Execute(adlistDc);
                        }
                    }

                    if (this._SetBodyOptionList != null)
                    {
                        foreach (var item in this._SetBodyOptionList.Values)
                        {
                            CSQLDataAdepterList adlistBody = new CSQLDataAdepterList();
                            CSQLParameterList plistBody = new CSQLParameterList();
                            plistBody.Add("@PurchaseID", DbType.Int32, plistPurchase["@ID"].Value, ParameterDirection.Input);
                            plistBody.Add("@Body_Option_ID", DbType.Int32, item.Body_Option_ID, ParameterDirection.Input);
                            plistBody.Add("@Body_Option_Name", DbType.String, item.Body_Option_Name, ParameterDirection.Input);
                            plistBody.Add("@Body_Option_price", DbType.Decimal, item.Body_Option_price, ParameterDirection.Input);
                            plistBody.Add("@finance", DbType.String, item.finance, ParameterDirection.Input);
                            CSQLStatementValue csvDcBody = new CSQLStatementValue(this._statementBody, plistBody, NoomLibrary.StatementType.Insert);
                            adlistBody.Add(csvDcBody);
                            cstate.Execute(adlistBody);
                        }
                    }

                    if (this._SetBodyOptionExtraList != null)
                    {
                        foreach (var item in this._SetBodyOptionExtraList.Values)
                        {
                            CSQLDataAdepterList adlistBodyExtra = new CSQLDataAdepterList();
                            CSQLParameterList plistBodyExtra = new CSQLParameterList();
                            plistBodyExtra.Add("@PurchaseID", DbType.Int32, plistPurchase["@ID"].Value, ParameterDirection.Input);
                            plistBodyExtra.Add("@Body_Company_ID", DbType.Int32, item.Body_Company_ID, ParameterDirection.Input);
                            plistBodyExtra.Add("@Option_Name_extra", DbType.String, item.Option_Name_extra, ParameterDirection.Input);
                            plistBodyExtra.Add("@Option_price_extra", DbType.Decimal, item.Option_price_extra, ParameterDirection.Input);
                            plistBodyExtra.Add("@Option_finance_extra", DbType.String, item.Option_finance_extra, ParameterDirection.Input);
                            CSQLStatementValue csvDcBody = new CSQLStatementValue(this._statementBodyExtra, plistBodyExtra, NoomLibrary.StatementType.Insert);
                            adlistBodyExtra.Add(csvDcBody);
                            cstate.Execute(adlistBodyExtra);
                        }
                    }

                    //CSQLDataAdepterList adlistUser = new CSQLDataAdepterList();
                    //CSQLParameterList plistUser = new CSQLParameterList();
                    //plistUser.Add("@SeasonID", SqlDbType.Int, master.Season.ID, ParameterDirection.Input);
                    //plistUser.Add("@AssessorID", SqlDbType.Int, master.Assessor.ID, ParameterDirection.Input);
                    //plistUser.Add("@AssessID", SqlDbType.Int, plistM["@ID"].Value, ParameterDirection.Input);
                    //CSQLStatementValue csvUser = new CSQLStatementValue(this._statememetUser, plistUser, NoomLibrary.StatementType.Insert);
                    //adlistUser.Add(csvUser);
                    //cstate.Execute(adlistUser);

                    //foreach (var item in this._list.Values)
                    //{
                    //    CSQLParameterList plist = new CSQLParameterList();
                    //    plist.Add("@AssessID", SqlDbType.Int, plistM["@ID"].Value, ParameterDirection.Input);
                    //    plist.Add("@SeasonID", SqlDbType.Int, master.Season.ID, ParameterDirection.Input);
                    //    plist.Add("@AssessorID", SqlDbType.Int, master.Assessor.ID, ParameterDirection.Input);
                    //    plist.Add("@EmpID", SqlDbType.Int, item.Employee.ID, ParameterDirection.Input);
                    //    plist.Add("@TempleteID", SqlDbType.Int, item.Templete.ID, ParameterDirection.Input);
                    //    plist.Add("@EWeight", SqlDbType.Int, item.EWeigth, ParameterDirection.Input);

                    //    CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Insert);
                    //    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    //    adlist.Add(csv);

                    //    cstate.Execute(adlist);
                    //}
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

        public object UPDATE_Purchase(int num, _Purchase _p)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    cstate.Open();
                    if (_p.ChkP == "Y")
                    {
                        CSQLDataAdepterList adlistM = new CSQLDataAdepterList();
                        CSQLParameterList plistM = new CSQLParameterList();
                        plistM.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                        plistM.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        plistM.Add("@CusID", DbType.Int32, _p._Customer.ID, ParameterDirection.Input);
                        plistM.Add("@Company", DbType.String, _p._Company.Companycode, ParameterDirection.Input);
                        plistM.Add("@OutCar_Date", DbType.Date, _p.OutCar_Date, ParameterDirection.Input);
                        plistM.Add("@PurchaseNo", DbType.String, _p.PurchaseNo, ParameterDirection.Input);
                        //-----------
                        plistM.Add("@CorporationCode", DbType.String, _p._Customer.CorporationCode, ParameterDirection.Input);
                        plistM.Add("@IDCard", DbType.String, _p._Customer.IDCard, ParameterDirection.Input);
                        plistM.Add("@Prefix", DbType.String, _p._Customer.Prefix, ParameterDirection.Input);
                        plistM.Add("@Name", DbType.String, _p._Customer.Name, ParameterDirection.Input);
                        plistM.Add("@Surname", DbType.String, _p._Customer.Surname, ParameterDirection.Input);
                        //-----------
                        plistM.Add("@NickName", DbType.String, _p._Customer.Nickname, ParameterDirection.Input);
                        plistM.Add("@Birthday", DbType.Date, _p._Customer.Birthday, ParameterDirection.Input);
                        plistM.Add("@Sex", DbType.String, _p._Customer.Sex, ParameterDirection.Input);
                        plistM.Add("@Education", DbType.Int32, _p._Customer._Education.id, ParameterDirection.Input);
                        plistM.Add("@Total_Member", DbType.Int32, _p._Customer.Total_Member, ParameterDirection.Input);
                        plistM.Add("@Tel_Mobile1", DbType.String, _p._Customer.Tel_Mobile1, ParameterDirection.Input);
                        plistM.Add("@Tel_Mobile2", DbType.String, _p._Customer.Tel_Mobile2, ParameterDirection.Input);
                        plistM.Add("@Tel_Work", DbType.String, _p._Customer.Tel_Work, ParameterDirection.Input);
                        plistM.Add("@Tel_Fax", DbType.String, _p._Customer.Tel_Fax, ParameterDirection.Input);
                        plistM.Add("@LineID", DbType.String, _p._Customer.LineID, ParameterDirection.Input);
                        plistM.Add("@CareerID", DbType.Int32, _p._Customer._Career.ID, ParameterDirection.Input);
                        plistM.Add("@Career_Other", DbType.String, _p._Customer.Career_Other, ParameterDirection.Input);
                        plistM.Add("@Career_Remark", DbType.String, _p._Customer.Career_Remark, ParameterDirection.Input);
                        plistM.Add("@IncomeID", DbType.Int32, _p._Customer._Income.ID, ParameterDirection.Input);
                        plistM.Add("@Address", DbType.String, _p._Customer._Address.Address, ParameterDirection.Input);
                        plistM.Add("@Add_Moo", DbType.Int32, _p._Customer._Address.Add_Moo, ParameterDirection.Input);
                        plistM.Add("@Add_HomeName", DbType.String, _p._Customer._Address.Add_HomeName, ParameterDirection.Input);
                        plistM.Add("@Add_Road", DbType.String, _p._Customer._Address.Add_Road, ParameterDirection.Input);
                        plistM.Add("@Add_Soi", DbType.String, _p._Customer._Address.Add_Soi, ParameterDirection.Input);
                        plistM.Add("@Add_District", DbType.Int32, _p._Customer._Address._District.DISTRICT_ID, ParameterDirection.Input);
                        plistM.Add("@Add_Amphur", DbType.Int32, _p._Customer._Address._Amphur.AMPHUR_ID, ParameterDirection.Input);
                        plistM.Add("@Add_Province", DbType.Int32, _p._Customer._Address._Province.PROVINCE_ID, ParameterDirection.Input);
                        plistM.Add("@Add_Postel", DbType.String, _p._Customer._Address._Postel.Postel_Code, ParameterDirection.Input);
                        plistM.Add("@SendAddress_IDCard", DbType.String, _p._Customer.SendAddress_IDCard, ParameterDirection.Input);
                        plistM.Add("@BuyType", DbType.String, _p.Buy_Type, ParameterDirection.Input);
                        plistM.Add("@CarPlate", DbType.String, _p.CarPlate, ParameterDirection.Input);
                        plistM.Add("@Regis_Date", DbType.Date, _p.Regis_Date, ParameterDirection.Input);
                        plistM.Add("@CarTax", DbType.String, _p.CarTax, ParameterDirection.Input);
                        plistM.Add("@CarType", DbType.Int32, _p._CarType.ID, ParameterDirection.Input);
                        plistM.Add("@CE_MCNumber", DbType.String, _p.CE_MCNumber, ParameterDirection.Input);
                        plistM.Add("@CE_TruckNumber", DbType.String, _p.CE_TruckNumber, ParameterDirection.Input);
                        plistM.Add("@CE_Brand", DbType.String, _p.CE_Brand, ParameterDirection.Input);
                        plistM.Add("@CE_Model", DbType.String, _p.CE_Model, ParameterDirection.Input);
                        plistM.Add("@CE_Color", DbType.String, _p.CE_Color, ParameterDirection.Input);
                        plistM.Add("@CE_Year", DbType.String, _p.CE_Year, ParameterDirection.Input);
                        plistM.Add("@CE_CarPlate", DbType.String, _p.CE_CarPlate, ParameterDirection.Input);
                        plistM.Add("@CE_Price", DbType.Decimal, _p.CE_Price, ParameterDirection.Input);
                        plistM.Add("@CE_Emp", DbType.String, _p.CE_Emp, ParameterDirection.Input);
                        plistM.Add("@PriceSumCar", DbType.Decimal, _p.PriceSumCar, ParameterDirection.Input);
                        plistM.Add("@PriceSum", DbType.Decimal, _p.PriceSum, ParameterDirection.Input);
                        plistM.Add("@Finance_ID", DbType.Int32, _p._Finance.ID, ParameterDirection.Input);
                        plistM.Add("@Emp_Finance", DbType.String, _p.Emp_Finance, ParameterDirection.Input);
                        plistM.Add("@PayDown", DbType.Decimal, _p.PayDown, ParameterDirection.Input);
                        plistM.Add("@Body_Acc_ID", DbType.Int32, _p.Body_Acc_ID, ParameterDirection.Input);
                        plistM.Add("@Body_Type", DbType.String, _p.Body_Type, ParameterDirection.Input);
                        plistM.Add("@Body_Extra_Company", DbType.Int32, _p.Body_Extra_Company, ParameterDirection.Input);
                        plistM.Add("@CarPriceAd", DbType.String, _p.CarPriceAd, ParameterDirection.Input);
                        plistM.Add("@CarPriceAd_Price", DbType.Decimal, _p.CarPriceAd_Price, ParameterDirection.Input);
                        plistM.Add("@Body_Price_finance", DbType.Decimal, _p.Body_Price_finance, ParameterDirection.Input);
                        plistM.Add("@Body_Price_Pay", DbType.Decimal, _p.Body_Price_Pay, ParameterDirection.Input);
                        plistM.Add("@Body_Price_SumAddBody", DbType.Decimal, _p.Body_Price_SumAddBody, ParameterDirection.Input);
                        plistM.Add("@LoanProtection", DbType.Decimal, _p.LoanProtection, ParameterDirection.Input);
                        plistM.Add("@DPeak", DbType.Decimal, _p.DPeak, ParameterDirection.Input);
                        plistM.Add("@hpcost", DbType.Decimal, _p.hpcost, ParameterDirection.Input);
                        plistM.Add("@Interest", DbType.Decimal, _p.Interest, ParameterDirection.Input);
                        plistM.Add("@Remark_Interest", DbType.String, _p.Remark_Interest, ParameterDirection.Input);
                        plistM.Add("@Pay_Begin", DbType.Int32, _p.Pay_Begin, ParameterDirection.Input);
                        plistM.Add("@Total_Payment", DbType.Int32, _p.Total_Payment, ParameterDirection.Input);
                        plistM.Add("@Price_Payment", DbType.Decimal, _p.Price_Payment, ParameterDirection.Input);
                        plistM.Add("@CampaignName", DbType.String, _p.CampaignName, ParameterDirection.Input);
                        plistM.Add("@DepositNo", DbType.String, _p.DepositNo, ParameterDirection.Input);
                        plistM.Add("@DepositDate", DbType.Date, _p.DepositDate, ParameterDirection.Input);
                        plistM.Add("@DepositPrice", DbType.Decimal, _p.DepositPrice, ParameterDirection.Input);
                        plistM.Add("@DepositAdNo", DbType.String, _p.DepositAdNo, ParameterDirection.Input);
                        plistM.Add("@DepositAdDate", DbType.Date, _p.DepositAdDate, ParameterDirection.Input);
                        plistM.Add("@DepositAdPrice", DbType.Decimal, _p.DepositAdPrice, ParameterDirection.Input);
                        plistM.Add("@RedCarPlate_No", DbType.String, _p.RedCarPlate_No, ParameterDirection.Input);
                        plistM.Add("@RedCarPlate_Date", DbType.Date, _p.RedCarPlate_Date, ParameterDirection.Input);
                        plistM.Add("@RedCarPlate_Price", DbType.Decimal, _p.RedCarPlate_Price, ParameterDirection.Input);
                        plistM.Add("@RedCarPlate_Num", DbType.String, _p.RedCarPlate_Num, ParameterDirection.Input);
                        plistM.Add("@PayCash_No", DbType.String, _p.PayCash_No, ParameterDirection.Input);
                        plistM.Add("@PayCash_Date", DbType.Date, _p.PayCash_Date, ParameterDirection.Input);
                        plistM.Add("@PayCash_Price", DbType.Decimal, _p.PayCase_Price, ParameterDirection.Input);
                        plistM.Add("@PayTM", DbType.Int32, _p.PayTM, ParameterDirection.Input);
                        plistM.Add("@PayTM_No", DbType.String, _p.PayTM_No, ParameterDirection.Input);
                        plistM.Add("@PayTM_Date", DbType.Date, _p.PayTM_Date, ParameterDirection.Input);
                        plistM.Add("@PayTM_Price", DbType.Decimal, _p.PayTM_Price, ParameterDirection.Input);
                        plistM.Add("@PayCheque", DbType.Int32, _p.PayCheque, ParameterDirection.Input);
                        plistM.Add("@PayCheque_No", DbType.String, _p.PayCheque_No, ParameterDirection.Input);
                        plistM.Add("@PayCheque_Date", DbType.Date, _p.PayCheque_Date, ParameterDirection.Input);
                        plistM.Add("@PayCheque_Price", DbType.Decimal, _p.PayCheque_Price, ParameterDirection.Input);
                        plistM.Add("@RepayToCus", DbType.Decimal, _p.RepayToCus, ParameterDirection.Input);
                        plistM.Add("@Remark", DbType.String, _p.Remark, ParameterDirection.Input);
                        plistM.Add("@C_IDCard", DbType.String, _p.C_IDCard, ParameterDirection.Input);
                        plistM.Add("@C_HouseRegistration", DbType.String, _p.C_HouseRegistration, ParameterDirection.Input);
                        plistM.Add("@C_Scrape", DbType.String, _p.C_Scrape, ParameterDirection.Input);
                        plistM.Add("@C_ActInsurance", DbType.String, _p.C_ActInsurance, ParameterDirection.Input);
                        plistM.Add("@C_Finance", DbType.String, _p.C_Finance, ParameterDirection.Input);
                        plistM.Add("@C_CVIP", DbType.String, _p.C_CVIP, ParameterDirection.Input);
                        plistM.Add("@PoNum", DbType.String, _p.PoNum, ParameterDirection.Input);
                        plistM.Add("@User_Edit", DbType.Int32, _p.User_Edit, ParameterDirection.Input);
                        CSQLStatementValue csvMaster = new CSQLStatementValue(this._statementPO, plistM, NoomLibrary.StatementType.Update);
                        adlistM.Add(csvMaster);
                        cstate.Execute(adlistM);
                    }

                    if (_p.Chk_UpAcc == "Y")
                    {
                        CSQLDataAdepterList adlist_In1 = new CSQLDataAdepterList();
                        CSQLParameterList plist_In1 = new CSQLParameterList();
                        plist_In1.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                        plist_In1.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        plist_In1.Add("@ChkIn1", DbType.String, _p.ChkIn1, ParameterDirection.Input);
                        plist_In1.Add("@InID", DbType.Int32, _p._Insurance1._Insurane.ID, ParameterDirection.Input);
                        plist_In1.Add("@In_Name", DbType.String, _p._Insurance1._Insurane.Name, ParameterDirection.Input);
                        plist_In1.Add("@In_Outlay", DbType.Decimal, _p._Insurance1.Outlay, ParameterDirection.Input);
                        plist_In1.Add("@In_Price", DbType.Decimal, _p._Insurance1.Price, ParameterDirection.Input);
                        plist_In1.Add("@In_Free", DbType.String, _p._Insurance1.Free, ParameterDirection.Input);
                        plist_In1.Add("@User_Edit", DbType.Int32, _p.User_Edit, ParameterDirection.Input);
                        CSQLStatementValue csvMaster_In1 = new CSQLStatementValue(this._statementInsurance1, plist_In1, NoomLibrary.StatementType.Update);
                        adlist_In1.Add(csvMaster_In1);
                        cstate.Execute(adlist_In1);

                        CSQLDataAdepterList adlist_Regis = new CSQLDataAdepterList();
                        CSQLParameterList plist_Regis = new CSQLParameterList();
                        plist_Regis.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                        plist_Regis.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        plist_Regis.Add("@ChkRegis", DbType.String, _p.ChkRegis, ParameterDirection.Input);
                        plist_Regis.Add("@Regis_Name", DbType.String, _p._Regis.Name, ParameterDirection.Input);
                        plist_Regis.Add("@Regis_Price", DbType.Decimal, _p._Regis.Price, ParameterDirection.Input);
                        plist_Regis.Add("@Regis_Free", DbType.String, _p._Regis.Free, ParameterDirection.Input);
                        plist_Regis.Add("@User_Edit", DbType.Int32, _p.User_Edit, ParameterDirection.Input);
                        CSQLStatementValue csvMaster_Regis = new CSQLStatementValue(this._statementRegis, plist_Regis, NoomLibrary.StatementType.Update);
                        adlist_Regis.Add(csvMaster_Regis);
                        cstate.Execute(adlist_Regis);

                        CSQLDataAdepterList adlist_Act = new CSQLDataAdepterList();
                        CSQLParameterList plist_Act = new CSQLParameterList();
                        plist_Act.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                        plist_Act.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        plist_Act.Add("@ChkAct", DbType.String, _p.ChkAct, ParameterDirection.Input);
                        plist_Act.Add("@ActNo", DbType.String, _p._Act.ActNo, ParameterDirection.Input);
                        plist_Act.Add("@Price", DbType.Decimal, _p._Act.Price, ParameterDirection.Input);
                        plist_Act.Add("@Free", DbType.String, _p._Act.Free, ParameterDirection.Input);
                        plist_Act.Add("@User_Edit", DbType.Int32, _p.User_Edit, ParameterDirection.Input);
                        CSQLStatementValue csvMaster_Act = new CSQLStatementValue(this._statementAct, plist_Act, NoomLibrary.StatementType.Update);
                        adlist_Act.Add(csvMaster_Act);
                        cstate.Execute(adlist_Act);

                        CSQLDataAdepterList adlist_Transpot = new CSQLDataAdepterList();
                        CSQLParameterList plist_Transpot = new CSQLParameterList();
                        plist_Transpot.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                        plist_Transpot.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        plist_Transpot.Add("@ChkTranspot", DbType.String, _p.ChkTranspot, ParameterDirection.Input);
                        plist_Transpot.Add("@Price", DbType.Decimal, _p._Transpot.Price, ParameterDirection.Input);
                        plist_Transpot.Add("@Free", DbType.String, _p._Transpot.Free, ParameterDirection.Input);
                        plist_Transpot.Add("@User_Edit", DbType.Int32, _p.User_Edit, ParameterDirection.Input);
                        CSQLStatementValue csvMaster_Transpot = new CSQLStatementValue(this._statementTranspot, plist_Transpot, NoomLibrary.StatementType.Update);
                        adlist_Transpot.Add(csvMaster_Transpot);
                        cstate.Execute(adlist_Transpot);


                        CSQLDataAdepterList adlistSetAcc = new CSQLDataAdepterList();
                        CSQLParameterList plistSetAcc = new CSQLParameterList();
                        plistSetAcc.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                        plistSetAcc.Add("@SetAccID", DbType.Int32, ParameterDirection.Output);
                        plistSetAcc.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        plistSetAcc.Add("@ChkSetAcc", DbType.String, _p.ChkSetAcc, ParameterDirection.Input);
                        plistSetAcc.Add("@Price", DbType.Decimal, _p._SetAcc.Price, ParameterDirection.Input);
                        plistSetAcc.Add("@Free", DbType.String, _p._SetAcc.Free, ParameterDirection.Input);
                        plistSetAcc.Add("@User_Edit", DbType.Int32, _p.User_Edit, ParameterDirection.Input);
                        CSQLStatementValue csvSetAcc = new CSQLStatementValue(this._statementSetAcc, plistSetAcc, NoomLibrary.StatementType.Update);
                        adlistSetAcc.Add(csvSetAcc);
                        cstate.Execute(adlistSetAcc);

                        int _SetAcc_ID = int.Parse(plistSetAcc["@SetAccID"].Value.ToString());
                        if (_SetAcc_ID != 0)
                        {
                            foreach (var item in this._SetAccList.Values)
                            {
                                CSQLDataAdepterList adlistSetAccDetail = new CSQLDataAdepterList();
                                CSQLParameterList plistSetAccDetail = new CSQLParameterList();
                                plistSetAccDetail.Add("@SetAccID", DbType.Int32, _SetAcc_ID, ParameterDirection.Input);
                                plistSetAccDetail.Add("@Name", DbType.String, item.Name, ParameterDirection.Input);
                                plistSetAccDetail.Add("@User_Add", DbType.Int32, _p.User_Edit, ParameterDirection.Input);
                                CSQLStatementValue csvSetAccDetail = new CSQLStatementValue(this._statementSetAccDetail, plistSetAccDetail, NoomLibrary.StatementType.Insert);
                                adlistSetAccDetail.Add(csvSetAccDetail);
                                cstate.Execute(adlistSetAccDetail);
                            }
                        }


                        CSQLDataAdepterList adlistSetAccSTD = new CSQLDataAdepterList();
                        CSQLParameterList plistSetAccSTD = new CSQLParameterList();
                        plistSetAccSTD.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                        plistSetAccSTD.Add("@SetAccSTDID", DbType.Int32, ParameterDirection.Output);
                        plistSetAccSTD.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        plistSetAccSTD.Add("@ChkSetAccSTD", DbType.String, _p.ChkSetAccSTD, ParameterDirection.Input);
                        plistSetAccSTD.Add("@Price", DbType.Decimal, _p._SetAccSTD.Price, ParameterDirection.Input);
                        plistSetAccSTD.Add("@Free", DbType.String, _p._SetAccSTD.Free, ParameterDirection.Input);
                        plistSetAccSTD.Add("@User_Edit", DbType.Int32, _p.User_Edit, ParameterDirection.Input);
                        CSQLStatementValue csvSetAccSTD = new CSQLStatementValue(this._statementSetAccSTD, plistSetAccSTD, NoomLibrary.StatementType.Update);
                        adlistSetAccSTD.Add(csvSetAccSTD);
                        cstate.Execute(adlistSetAccSTD);

                        int _SetAccSTD_ID = int.Parse(plistSetAccSTD["@SetAccSTDID"].Value.ToString());
                        if (_SetAccSTD_ID != 0)
                        {
                            foreach (var item in this._SetAccSTDList.Values)
                            {
                                CSQLDataAdepterList adlistSetAccSTDDetail = new CSQLDataAdepterList();
                                CSQLParameterList plistSetAccSTDDetail = new CSQLParameterList();
                                plistSetAccSTDDetail.Add("@SetAccSTDID", DbType.Int32, _SetAccSTD_ID, ParameterDirection.Input);
                                plistSetAccSTDDetail.Add("@Name", DbType.String, item.Name, ParameterDirection.Input);
                                plistSetAccSTDDetail.Add("@User_Add", DbType.Int32, _p.User_Edit, ParameterDirection.Input);
                                CSQLStatementValue csvSetAccSTDDetail = new CSQLStatementValue(this._statementSetAccSTDDetail, plistSetAccSTDDetail, NoomLibrary.StatementType.Insert);
                                adlistSetAccSTDDetail.Add(csvSetAccSTDDetail);
                                cstate.Execute(adlistSetAccSTDDetail);
                            }
                        }

                        CSQLDataAdepterList adlistAddAcc = new CSQLDataAdepterList();
                        CSQLParameterList plistAddAcc = new CSQLParameterList();
                        plistAddAcc.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                        plistAddAcc.Add("@SetAdAccID", DbType.Int32, ParameterDirection.Output);
                        plistAddAcc.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        plistAddAcc.Add("@ChkSetAddAcc", DbType.String, _p.ChkSetAddAcc, ParameterDirection.Input);
                        plistAddAcc.Add("@Price", DbType.Decimal, _p._AddAcc.Price, ParameterDirection.Input);
                        plistAddAcc.Add("@User_Edit", DbType.Int32, _p.User_Edit, ParameterDirection.Input);
                        CSQLStatementValue csvAddAcc = new CSQLStatementValue(this._statementSetAddAcc, plistAddAcc, NoomLibrary.StatementType.Update);
                        adlistAddAcc.Add(csvAddAcc);
                        cstate.Execute(adlistAddAcc);

                        int _AddAcc_ID = int.Parse(plistAddAcc["@SetAdAccID"].Value.ToString());
                        if (_AddAcc_ID != 0)
                        {
                            foreach (var item in this._SetAddAccList.Values)
                            {
                                CSQLDataAdepterList adlistAddAccDetail = new CSQLDataAdepterList();
                                CSQLParameterList plistAddAccDetail = new CSQLParameterList();
                                plistAddAccDetail.Add("@AddAccID", DbType.Int32, _AddAcc_ID, ParameterDirection.Input);
                                plistAddAccDetail.Add("@Name", DbType.String, item.Name, ParameterDirection.Input);
                                plistAddAccDetail.Add("@Price", DbType.Decimal, item.Price, ParameterDirection.Input);
                                plistAddAccDetail.Add("@Free", DbType.String, item.Free, ParameterDirection.Input);
                                plistAddAccDetail.Add("@User_Add", DbType.Int32, _p.User_Edit, ParameterDirection.Input);
                                CSQLStatementValue csvAddAccDetail = new CSQLStatementValue(this._statementSetAddAccDetail, plistAddAccDetail, NoomLibrary.StatementType.Insert);
                                adlistAddAccDetail.Add(csvAddAccDetail);
                                cstate.Execute(adlistAddAccDetail);
                            }
                        }

                        CSQLDataAdepterList adlistDc_Del = new CSQLDataAdepterList();
                        CSQLParameterList plistDc_Del = new CSQLParameterList();
                        plistDc_Del.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                        plistDc_Del.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        CSQLStatementValue csvDc_Del = new CSQLStatementValue(this._statementDc, plistDc_Del, NoomLibrary.StatementType.Delete);
                        adlistDc_Del.Add(csvDc_Del);
                        cstate.Execute(adlistDc_Del);

                        foreach (var item in this._DcList.Values)
                        {
                            CSQLDataAdepterList adlistDc = new CSQLDataAdepterList();
                            CSQLParameterList plistDc = new CSQLParameterList();
                            plistDc.Add("@PurchaseID", DbType.Int32, _p.ID, ParameterDirection.Input);
                            plistDc.Add("@Name", DbType.String, item.Name, ParameterDirection.Input);
                            plistDc.Add("@Price", DbType.Decimal, item.Price, ParameterDirection.Input);
                            plistDc.Add("@User_Add", DbType.String, _p.User_Edit, ParameterDirection.Input);
                            CSQLStatementValue csvDc = new CSQLStatementValue(this._statementDc, plistDc, NoomLibrary.StatementType.Insert);
                            adlistDc.Add(csvDc);
                            cstate.Execute(adlistDc);
                        }                                             

                    }

                    //if (_p.Chk_UpAcc == "O")
                    //{
                    //    CSQLDataAdepterList adlistBody_Del = new CSQLDataAdepterList();
                    //    CSQLParameterList plistBody_Del = new CSQLParameterList();
                    //    plistBody_Del.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                    //    plistBody_Del.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                    //    CSQLStatementValue csvBody_Del = new CSQLStatementValue(this._statementBody, plistBody_Del, NoomLibrary.StatementType.Delete);
                    //    adlistBody_Del.Add(csvBody_Del);
                    //    cstate.Execute(adlistBody_Del);
                    //}

                    if (_p.Chk_UpAcc == "B")
                    {
                        CSQLDataAdepterList adlistBody_Del = new CSQLDataAdepterList();
                        CSQLParameterList plistBody_Del = new CSQLParameterList();
                        plistBody_Del.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                        plistBody_Del.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        CSQLStatementValue csvBody_Del = new CSQLStatementValue(this._statementBody, plistBody_Del, NoomLibrary.StatementType.Delete);
                        adlistBody_Del.Add(csvBody_Del);
                        cstate.Execute(adlistBody_Del);

                        foreach (var item in this._SetBodyOptionList.Values)
                        {
                            CSQLDataAdepterList adlistOption = new CSQLDataAdepterList();
                            CSQLParameterList plistOption = new CSQLParameterList();
                            plistOption.Add("@PurchaseID", DbType.Int32, _p.ID, ParameterDirection.Input);
                            plistOption.Add("@Body_Option_ID", DbType.Int32, item.Body_Option_ID, ParameterDirection.Input);
                            plistOption.Add("@Body_Option_Name", DbType.String, item.Body_Option_Name, ParameterDirection.Input);
                            plistOption.Add("@Body_Option_price", DbType.Decimal, item.Body_Option_price, ParameterDirection.Input);
                            plistOption.Add("@finance", DbType.String, item.finance, ParameterDirection.Input);
                            CSQLStatementValue csvOption = new CSQLStatementValue(this._statementBody, plistOption, NoomLibrary.StatementType.Insert);
                            adlistOption.Add(csvOption);
                            cstate.Execute(adlistOption);
                        }

                        CSQLDataAdepterList adlistBodyExtra_Del = new CSQLDataAdepterList();
                        CSQLParameterList plistBodyExtra_Del = new CSQLParameterList();
                        plistBodyExtra_Del.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                        plistBodyExtra_Del.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        CSQLStatementValue csvBodyExtra_Del = new CSQLStatementValue(this._statementBodyExtra, plistBodyExtra_Del, NoomLibrary.StatementType.Delete);
                        adlistBodyExtra_Del.Add(csvBodyExtra_Del);
                        cstate.Execute(adlistBodyExtra_Del);
                    }

                    //if (_p.Chk_UpAcc == "BD")
                    //{
                    //    CSQLDataAdepterList adlistBodyExtra_Del = new CSQLDataAdepterList();
                    //    CSQLParameterList plistBodyExtra_Del = new CSQLParameterList();
                    //    plistBodyExtra_Del.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                    //    plistBodyExtra_Del.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                    //    CSQLStatementValue csvBody_Del = new CSQLStatementValue(this._statementBodyExtra, plistBodyExtra_Del, NoomLibrary.StatementType.Delete);
                    //    adlistBodyExtra_Del.Add(csvBody_Del);
                    //    cstate.Execute(adlistBodyExtra_Del);
                    //}

                    if (_p.Chk_UpAcc == "BE")
                    {
                        CSQLDataAdepterList adlistBodyExtra_Del = new CSQLDataAdepterList();
                        CSQLParameterList plistBodyExtra_Del = new CSQLParameterList();
                        plistBodyExtra_Del.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                        plistBodyExtra_Del.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        CSQLStatementValue csvBodyExtra_Del = new CSQLStatementValue(this._statementBodyExtra, plistBodyExtra_Del, NoomLibrary.StatementType.Delete);
                        adlistBodyExtra_Del.Add(csvBodyExtra_Del);
                        cstate.Execute(adlistBodyExtra_Del);

                        foreach (var item in this._SetBodyOptionExtraList.Values)
                        {
                            CSQLDataAdepterList adlistOptionExtra = new CSQLDataAdepterList();
                            CSQLParameterList plistBodyExtra = new CSQLParameterList();
                            plistBodyExtra.Add("@PurchaseID", DbType.Int32, _p.ID, ParameterDirection.Input);
                            plistBodyExtra.Add("@Body_Company_ID", DbType.Int32, item.Body_Company_ID, ParameterDirection.Input);
                            plistBodyExtra.Add("@Option_Name_extra", DbType.String, item.Option_Name_extra, ParameterDirection.Input);
                            plistBodyExtra.Add("@Option_price_extra", DbType.Decimal, item.Option_price_extra, ParameterDirection.Input);
                            plistBodyExtra.Add("@Option_finance_extra", DbType.String, item.Option_finance_extra, ParameterDirection.Input);
                            CSQLStatementValue csvOptionExtra = new CSQLStatementValue(this._statementBodyExtra, plistBodyExtra, NoomLibrary.StatementType.Insert);
                            adlistOptionExtra.Add(csvOptionExtra);
                            cstate.Execute(adlistOptionExtra);
                        }

                        CSQLDataAdepterList adlistBody_Del = new CSQLDataAdepterList();
                        CSQLParameterList plistBody_Del = new CSQLParameterList();
                        plistBody_Del.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                        plistBody_Del.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                        CSQLStatementValue csvBody_Del = new CSQLStatementValue(this._statementBody, plistBody_Del, NoomLibrary.StatementType.Delete);
                        adlistBody_Del.Add(csvBody_Del);
                        cstate.Execute(adlistBody_Del);
                    }

                    //if (_p.Chk_UpAcc == "OE")
                    //{
                    //    CSQLDataAdepterList adlistBody_Del = new CSQLDataAdepterList();
                    //    CSQLParameterList plistBody_Del = new CSQLParameterList();
                    //    plistBody_Del.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                    //    plistBody_Del.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                    //    CSQLStatementValue csvBody_Del = new CSQLStatementValue(this._statementBody, plistBody_Del, NoomLibrary.StatementType.Delete);
                    //    adlistBody_Del.Add(csvBody_Del);
                    //    cstate.Execute(adlistBody_Del);

                    //    CSQLDataAdepterList adlistBodyExtra_Del = new CSQLDataAdepterList();
                    //    CSQLParameterList plistBodyExtra_Del = new CSQLParameterList();
                    //    plistBodyExtra_Del.Add("@num", DbType.Int32, 1, ParameterDirection.Input);
                    //    plistBodyExtra_Del.Add("@POID", DbType.Int32, _p.ID, ParameterDirection.Input);
                    //    CSQLStatementValue csvBodyExtra_Del = new CSQLStatementValue(this._statementBodyExtra, plistBodyExtra_Del, NoomLibrary.StatementType.Delete);
                    //    adlistBodyExtra_Del.Add(csvBodyExtra_Del);
                    //    cstate.Execute(adlistBodyExtra_Del);
                    //}

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
    }

    public class _SPurchaseList : IDictionary<int, _SPurchaseList._SPurchase>
    {
        private CStatement _statement;
        private CStatement _statementEdit;

        private Dictionary<int, _SPurchase> _list = new Dictionary<int, _SPurchase>();

        public _SPurchaseList()
        {
            this._statement = new CStatement("SELECT_SPurchase", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            //this._statement = new CStatement("SELECT_SPurchase2", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
            this._statementEdit = new CStatement("SELECT_EPurchase", "INSERT", "UPDATE", "DELETE", System.Data.CommandType.StoredProcedure);
        }

        #region IDictionary Implement

        public void Add(int key, _SPurchaseList._SPurchase value)
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

        public bool TryGetValue(int key, out _SPurchaseList._SPurchase value)
        {
            return this._list.TryGetValue(key, out value);
        }

        public ICollection<_SPurchaseList._SPurchase> Values
        {
            get
            {
                ICollection<_SPurchase> values = new List<_SPurchase>();
                foreach (_SPurchase item in this._list.Values)
                {
                    values.Add(item);
                }
                return values;
            }
        }

        public _SPurchaseList._SPurchase this[int key]
        {
            get
            {
                _SPurchase result;
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
                _SPurchase result;
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

        public void Add(KeyValuePair<int, _SPurchaseList._SPurchase> item)
        {
            this._list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(KeyValuePair<int, _SPurchaseList._SPurchase> item)
        {
            _SPurchase value;
            if (!this._list.TryGetValue(item.Key, out value))
                return false;

            return EqualityComparer<_SPurchase>.Default.Equals(value, item.Value);
        }

        public void CopyTo(KeyValuePair<int, _SPurchaseList._SPurchase>[] array, int arrayIndex)
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

        public bool Remove(KeyValuePair<int, _SPurchaseList._SPurchase> item)
        {
            return this._list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<int, _SPurchaseList._SPurchase>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        #endregion

        public object Select(int num, string _Company, string _Branch, int _EmpID, string _CusName, string _MCNumber, string _MCode, DateTime _Date1, DateTime _Date2, DateTime _OutDate1, DateTime _OutDate2, DateTime _RegisDate1, DateTime _RegisDate2,string _CarPlate,string _TruckNumber,string _Tel_Mobile, string _CarBranch)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@Company", DbType.String, _Company, ParameterDirection.Input);
                    plist.Add("@Branch", DbType.String, _Branch, ParameterDirection.Input);
                    plist.Add("@EmpID", DbType.Int32, _EmpID, ParameterDirection.Input);
                    plist.Add("@CusName", DbType.String, _CusName, ParameterDirection.Input);
                    plist.Add("@MCNumber", DbType.String, _MCNumber, ParameterDirection.Input);
                    plist.Add("@MCode", DbType.String, _MCode, ParameterDirection.Input);
                    plist.Add("@Date1", DbType.Date, _Date1, ParameterDirection.Input);
                    plist.Add("@Date2", DbType.Date, _Date2, ParameterDirection.Input);
                    plist.Add("@OutDate1", DbType.Date, _OutDate1, ParameterDirection.Input);
                    plist.Add("@OutDate2", DbType.Date, _OutDate2, ParameterDirection.Input);
                    plist.Add("@RegisDate1", DbType.Date, _RegisDate1, ParameterDirection.Input);
                    plist.Add("@RegisDate2", DbType.Date, _RegisDate2, ParameterDirection.Input);
                    plist.Add("@CarPlate", DbType.String, _CarPlate, ParameterDirection.Input);
                    plist.Add("@TruckNumber", DbType.String, _TruckNumber, ParameterDirection.Input);
                    plist.Add("@Tel_Mobile1", DbType.String, _Tel_Mobile, ParameterDirection.Input);
                    plist.Add("@CarBranch", DbType.String, _CarBranch, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statement, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    foreach (DataRow item in dt.Rows)
                    {
                        int id = int.Parse(item["ID"].ToString());
                        _SPurchase _c = new _SPurchase();
                        _c._Purchase.ID = id;
                        if (item["Purchase_Date"].ToString() != string.Empty)
                        {
                            _c._Purchase.Purchase_Date = DateTime.Parse(item["Purchase_Date"].ToString());
                        }
                        _c._Purchase.PurchaseNo = item["PurchaseNo"].ToString();
                        _c._Purchase.PoNum = item["PoNum"].ToString();
                        if (item["OutCar_Date"].ToString() != string.Empty)
                        {
                            _c._Purchase.OutCar_Date = DateTime.Parse(item["OutCar_Date"].ToString());
                        }
                        if (item["Regis_Date"].ToString() != string.Empty)
                        {
                            _c._Purchase.Regis_Date = DateTime.Parse(item["Regis_Date"].ToString());
                        }
                        _c._Purchase.PurchaseNo = item["PurchaseNo"].ToString();
                        _c._Customer.Name = item["CusName"].ToString();
                        _c._Purchase.MName = item["MName"].ToString();
                        _c._Purchase.CName = item["CName"].ToString();
                        _c._Purchase.MCNumber = item["MCNumber"].ToString();
                        _c._Purchase.CarPlate = item["CarPlate"].ToString();
                        _c._Purchase.TruckNumber = item["TruckNumber"].ToString();
                        _c._Customer.Tel_Mobile1 = item["Tel_Mobile1"].ToString();
                        _c.CarBranch = item["Company"].ToString();
                        _c.Tb_User.NickName = item["NickName"].ToString();
                        if (item["ToCustomerByDate"].ToString() != string.Empty)
                        {
                            _c._Purchase.ToCustomerByDate = DateTime.Parse(item["ToCustomerByDate"].ToString());
                        }
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

        public object SELECT_EPurchase(int num, int _POID)
        {
            object result = null;
            CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
            try
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                    plist.Add("@POID", DbType.Int32, _POID, ParameterDirection.Input);
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    CSQLStatementValue csvUser = new CSQLStatementValue(this._statementEdit, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csvUser);
                    cstate.Open();
                    result = cstate.Execute(adlist);
                    DataTable dt = (DataTable)result;

                    if (num == 1)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            int id = int.Parse(item["ID"].ToString());
                            _SPurchase _c = new _SPurchase();
                            _c._Purchase.ID = int.Parse(item["POID"].ToString());
                            _c._Purchase.PurchaseNo = item["PurchaseNo"].ToString();
                            _c._Purchase._Company.Companycode = item["Company"].ToString();
                            if (item["OutCar_Date"].ToString() != string.Empty)
                            {
                                _c._Purchase.OutCar_Date = DateTime.Parse(item["OutCar_Date"].ToString());
                            }
                            _c._Customer.ID = int.Parse(item["CusID"].ToString());
                            _c._Customer.CusNo = item["CusNo"].ToString();
                            _c._Customer.CusType = item["CusType"].ToString();
                            _c.Tb_User.FullName = item["SaleName"].ToString();
                            _c._Customer.IDCard = item["IDCard"].ToString();
                            _c._Customer.Prefix = item["Prefix"].ToString();
                            _c._Customer.Name = item["Name"].ToString();
                            _c._Customer.Surname = item["Surname"].ToString();
                            _c._Customer.Nickname = item["NickName"].ToString();
                            if (item["Birthday"].ToString() != string.Empty)
                            {
                                _c._Customer.Birthday = DateTime.Parse(item["Birthday"].ToString());
                            }
                            _c._Customer.Sex = item["Sex"].ToString();
                            if (item["Education"].ToString() != string.Empty)
                            {
                                _c._Customer._Education.id = int.Parse(item["Education"].ToString());
                            }
                            if (item["Total_Member"].ToString() != string.Empty)
                            {
                                _c._Customer.Total_Member = int.Parse(item["Total_Member"].ToString());
                            }

                            _c._Customer.CorporationCode = item["CorporationCode"].ToString();
                            _c._Customer.Tel_Mobile1 = item["Tel_Mobile1"].ToString();
                            _c._Customer.Tel_Mobile2 = item["Tel_Mobile2"].ToString();
                            _c._Customer.Tel_Work = item["Tel_Work"].ToString();
                            _c._Customer.Tel_Fax = item["Tel_Fax"].ToString();
                            _c._Customer.LineID = item["LineID"].ToString();
                            _c._Customer._Career.ID = int.Parse(item["CareerID"].ToString());
                            _c._Customer.Career_Other = item["Career_Other"].ToString();
                            _c._Customer.Career_Remark = item["Career_Remark"].ToString();
                            _c._Customer._Income.ID = int.Parse(item["IncomeID"].ToString());
                            _c._Customer.SendAddress_IDCard = item["SendAddress_IDCard"].ToString();

                            _AddressList._Address _add = new _AddressList._Address();
                            _add.Address = item["Address"].ToString();
                            if (item["Add_Moo"].ToString() != string.Empty)
                            {
                                _add.Add_Moo = int.Parse(item["Add_Moo"].ToString());
                            }
                            _add.Add_HomeName = item["Add_HomeName"].ToString();
                            _add.Add_Road = item["Add_Road"].ToString();
                            _add.Add_Soi = item["Add_Soi"].ToString();
                            _add._District.DISTRICT_ID = int.Parse(item["Add_District"].ToString());
                            _add._District.DISTRICT_NAME = item["DISTRICT_NAME"].ToString();
                            _add._Amphur.AMPHUR_ID = int.Parse(item["Add_Amphur"].ToString());
                            _add._Amphur.AMPHUR_NAME = item["AMPHUR_NAME"].ToString();
                            _add._Province.PROVINCE_ID = int.Parse(item["Add_Province"].ToString());
                            _add._Province.PROVINCE_NAME = item["PROVINCE_NAME"].ToString();
                            _add._Postel.Postel_Code = item["Add_Postel"].ToString();
                            _c._Customer._AddressList.Add(1, _add);

                            _AddressList._Address _sendadd = new _AddressList._Address();
                            _sendadd.Address = item["SendAddress"].ToString();
                            if (item["SendAdd_Moo"].ToString() != string.Empty)
                            {
                                _sendadd.Add_Moo = int.Parse(item["SendAdd_Moo"].ToString());
                            }
                            _sendadd.Add_HomeName = item["SendAdd_HomeName"].ToString();
                            _sendadd.Add_Road = item["SendAdd_Road"].ToString();
                            _sendadd.Add_Soi = item["SendAdd_Soi"].ToString();
                            _sendadd._District.DISTRICT_ID = int.Parse(item["SendAdd_District"].ToString());
                            _sendadd._District.DISTRICT_NAME = item["SendDISTRICT_NAME"].ToString();
                            _sendadd._Amphur.AMPHUR_ID = int.Parse(item["SendAdd_Amphur"].ToString());
                            _sendadd._Amphur.AMPHUR_NAME = item["SendAMPHUR_NAME"].ToString();
                            _sendadd._Province.PROVINCE_ID = int.Parse(item["SendAdd_Province"].ToString());
                            _sendadd._Province.PROVINCE_NAME = item["SendPROVINCE_NAME"].ToString();
                            _sendadd._Postel.Postel_Code = item["SendAdd_Postel"].ToString();
                            _c._Customer._SentAddressList.Add(1, _sendadd);

                            _c._Purchase.CarName = item["CarName"].ToString();
                            _c._Purchase.Buy_Type = item["Buy_Type"].ToString();
                            _c._Purchase.MCNumber = item["MCNumber"].ToString();
                            _c._Purchase.TruckNumber = item["TruckNumber"].ToString();
                            _c._Purchase.MCode = item["MCode"].ToString();
                            _c._Purchase.MName = item["MName"].ToString();
                            _c._Purchase.MSaleCode = item["MSaleCode"].ToString();
                            _c._Purchase.CName = item["CName"].ToString();
                            _c._Purchase.CarPrice = decimal.Parse(item["CarPrice"].ToString());
                            _c._Purchase.CarPlate = item["CarPlate"].ToString();
                            if (item["Regis_Date"].ToString() != string.Empty)
                            {
                                _c._Purchase.Regis_Date = DateTime.Parse(item["Regis_Date"].ToString());
                            }
                            _c._Purchase.CarTax = item["CarTax"].ToString();
                            if (item["CarType"].ToString() != string.Empty)
                            {
                                _c._Purchase._CarType.ID = int.Parse(item["CarType"].ToString());
                            }
                            _c._Purchase.CarExchange = item["CarExchange"].ToString();
                            _c._Purchase.CE_MCNumber = item["CE_MCNumber"].ToString();
                            _c._Purchase.CE_TruckNumber = item["CE_TruckNumber"].ToString();
                            _c._Purchase.CE_Brand = item["CE_Brand"].ToString();
                            _c._Purchase.CE_Model = item["CE_Model"].ToString();
                            _c._Purchase.CE_Color = item["CE_Color"].ToString();
                            _c._Purchase.CE_Year = item["CE_Year"].ToString();
                            _c._Purchase.CE_CarPlate = item["CE_Carplate"].ToString();
                            if (item["CE_Price"].ToString() != string.Empty)
                            {
                                _c._Purchase.CE_Price = decimal.Parse(item["CE_Price"].ToString());
                            }
                            _c._Purchase.CE_Emp = item["CE_PriceEmp"].ToString();
                            if (item["In_ID"].ToString() != string.Empty)
                            {
                                _c._Purchase._Insurance1.ID = int.Parse(item["In_ID"].ToString());
                                _c._Purchase._Insurance1._Insurane.ID = int.Parse(item["In_InsuranceID"].ToString());
                                _c._Purchase._Insurance1.Outlay = decimal.Parse(item["In_Outlay"].ToString());
                                _c._Purchase._Insurance1.Price = decimal.Parse(item["In_Price"].ToString());
                                _c._Purchase._Insurance1.Free = item["In_Free"].ToString();
                            }

                            if (item["Regis_ID"].ToString() != string.Empty)
                            {
                                _c._Purchase._Regis.ID = int.Parse(item["Regis_ID"].ToString());
                                _c._Purchase._Regis.Name = item["Regis_Name"].ToString();
                                _c._Purchase._Regis.Price = decimal.Parse(item["Regis_Price"].ToString());
                                _c._Purchase._Regis.Free = item["Regis_Free"].ToString();
                            }

                            if (item["Act_ID"].ToString() != string.Empty)
                            {
                                _c._Purchase._Act.ID = int.Parse(item["Act_ID"].ToString());
                                _c._Purchase._Act.ActNo = item["Act_ActNo"].ToString();
                                _c._Purchase._Act.Price = decimal.Parse(item["Act_Price"].ToString());
                                _c._Purchase._Act.Free = item["Act_Free"].ToString();
                            }

                            if (item["Transpot_ID"].ToString() != string.Empty)
                            {
                                _c._Purchase._Transpot.ID = int.Parse(item["Transpot_ID"].ToString());
                                _c._Purchase._Transpot.Price = decimal.Parse(item["Transpot_Price"].ToString());
                                _c._Purchase._Transpot.Free = item["Transpot_Free"].ToString();
                            }

                            if (item["SetAcc_ID"].ToString() != string.Empty)
                            {
                                _c._Purchase._SetAcc.ID = int.Parse(item["SetAcc_ID"].ToString());
                                _c._Purchase._SetAcc.Price = decimal.Parse(item["SetAcc_Price"].ToString());
                                _c._Purchase._SetAcc.Free = item["SetAcc_Free"].ToString();
                            }

                            if (item["SetAccSTD_ID"].ToString() != string.Empty)
                            {
                                _c._Purchase._SetAccSTD.ID = int.Parse(item["SetAccSTD_ID"].ToString());
                                _c._Purchase._SetAccSTD.Price = decimal.Parse(item["SetAccSTD_Price"].ToString());
                                _c._Purchase._SetAccSTD.Free = item["SetAccSTD_Free"].ToString();
                            }

                            if (item["AdAcc_ID"].ToString() != string.Empty)
                            {
                                _c._Purchase._AddAcc.ID = int.Parse(item["AdAcc_ID"].ToString());
                                _c._Purchase._AddAcc.Price = decimal.Parse(item["AdAcc_Price"].ToString());
                            }

                            _c._Purchase._Finance.ID = int.Parse(item["Finance"].ToString());
                            _c._Purchase.Emp_Finance = item["Finance_Au"].ToString();
                            _c._Purchase.CarPriceAd = item["CarPriceAd"].ToString();
                            _c._Purchase.Body_Acc_ID = int.Parse(item["Body_Acc_ID"].ToString());
                            _c._Purchase.Body_Type = item["Body_Type"].ToString();
                            _c._Purchase.Body_Extra_Company = int.Parse(item["Body_Extra_Company"].ToString());
                            _c._Purchase.CarPriceAd_Price = decimal.Parse(item["CarPriceAd_Price"].ToString());
                            _c._Purchase.Body_Price_finance = decimal.Parse(item["Body_Price_finance"].ToString());
                            _c._Purchase.Body_Price_Pay = decimal.Parse(item["Body_Price_Pay"].ToString());
                            _c._Purchase.Body_Price_SumAddBody = decimal.Parse(item["Body_Price_SumAddBody"].ToString());
                            _c._Purchase.PayDown = decimal.Parse(item["PayDown"].ToString());
                            _c._Purchase.DPeak = decimal.Parse(item["DPeak"].ToString());
                            _c._Purchase.LoanProtection = decimal.Parse(item["LoanProtection"].ToString());
                            if (item["hpcost"].ToString() != string.Empty)
                            {
                                _c._Purchase.hpcost = decimal.Parse(item["hpcost"].ToString()); 
                            }
                            
                            _c._Purchase.Interest = decimal.Parse(item["Interest"].ToString());
                            _c._Purchase.Remark_Interest = item["Interest_Remark"].ToString();
                            _c._Purchase.Total_Payment = int.Parse(item["Total_Payment"].ToString());
                            _c._Purchase.Price_Payment = decimal.Parse(item["Price_Payment"].ToString());
                            _c._Purchase.Pay_Begin = int.Parse(item["Pay_Begin"].ToString());
                            _c._Purchase.CampaignName = item["CampaignName"].ToString();
                            _c._Purchase.DepositNo = item["Deposit_No"].ToString();
                            if (item["Deposit_Date"].ToString() != string.Empty)
                            {
                                _c._Purchase.DepositDate = DateTime.Parse(item["Deposit_Date"].ToString());
                            }
                            _c._Purchase.DepositPrice = decimal.Parse(item["Deposit_Price"].ToString());
                            _c._Purchase.DepositAdNo = item["DepositAd_No"].ToString();
                            if (item["DepositAD_Date"].ToString() != string.Empty)
                            {
                                _c._Purchase.DepositAdDate = DateTime.Parse(item["DepositAd_Date"].ToString());
                            }
                            if (item["DepositAd_Price"].ToString() != string.Empty)
                            {
                                _c._Purchase.DepositAdPrice = decimal.Parse(item["DepositAd_Price"].ToString());
                            }
                            _c._Purchase.RedCarPlate_No = item["RedCarPlate_No"].ToString();
                            if (item["RedCarPlate_Date"].ToString() != string.Empty)
                            {
                                _c._Purchase.RedCarPlate_Date = DateTime.Parse(item["RedCarPlate_Date"].ToString());
                            }
                            if (item["RedCarPlate_Price"].ToString() != string.Empty)
                            {
                                _c._Purchase.RedCarPlate_Price = decimal.Parse(item["RedCarPlate_Price"].ToString());
                            }
                            
                            _c._Purchase.RedCarPlate_Num = item["RedCarPlate_Num"].ToString();
                            _c._Purchase.PriceSumCar = decimal.Parse(item["PriceSumCar"].ToString());
                            _c._Purchase.PriceSum = decimal.Parse(item["PriceSum"].ToString());
                            _c._Purchase.PayCash_No = item["PayCash_No"].ToString();
                            if (item["PayCash_Date"].ToString() != string.Empty)
                            {
                                _c._Purchase.PayCash_Date = DateTime.Parse(item["PayCash_Date"].ToString());
                            }
                            if (item["PayCash_Price"].ToString() != string.Empty)
                            {
                                _c._Purchase.PayCase_Price = decimal.Parse(item["PayCash_Price"].ToString());
                            }
                            if (item["PayTM"].ToString() != string.Empty)
                            {
                                _c._Purchase.PayTM = int.Parse(item["PayTM"].ToString());
                            }
                            _c._Purchase.PayTM_No = item["PayTM_No"].ToString();
                            if (item["PayTM_Date"].ToString() != string.Empty)
                            {
                                _c._Purchase.PayTM_Date = DateTime.Parse(item["PayTM_Date"].ToString());
                            }
                            if (item["PayTM_Price"].ToString() != string.Empty)
                            {
                                _c._Purchase.PayTM_Price = decimal.Parse(item["PayTM_Price"].ToString());
                            }
                            if (item["PayCheque"].ToString() != string.Empty)
                            {
                                _c._Purchase.PayCheque = int.Parse(item["PayCheque"].ToString());
                            }
                            _c._Purchase.PayCheque_No = item["PayCheque_No"].ToString();
                            if (item["PayCheque_Date"].ToString() != string.Empty)
                            {
                                _c._Purchase.PayCheque_Date = DateTime.Parse(item["PayCheque_Date"].ToString());
                            }
                            if (item["PayCheque_Price"].ToString() != string.Empty)
                            {
                                _c._Purchase.PayCheque_Price = decimal.Parse(item["PayCheque_Price"].ToString());
                            }
                            if (item["RepayToCus"].ToString() != string.Empty)
                            {
                                _c._Purchase.RepayToCus = decimal.Parse(item["RepayToCus"].ToString());
                            }
                            _c._Purchase.Remark = item["Remark"].ToString();
                            _c._Purchase.PoNum = item["PoNum"].ToString();
                            _c._Purchase.C_IDCard = item["C_IDCard"].ToString();
                            _c._Purchase.C_HouseRegistration = item["C_HouseRegistration"].ToString();
                            _c._Purchase.C_Scrape = item["C_Scrape"].ToString();
                            _c._Purchase.C_ActInsurance = item["C_ActInsurance"].ToString();
                            _c._Purchase.C_Finance = item["C_Finance"].ToString();
                            _c._Purchase.C_CVIP = item["C_CVIP"].ToString();

                            this.Add(id, _c);

                        }

                    }
                    else if (num == 2)
                    {
                        _SPurchase _p = new _SPurchase();
                        foreach (DataRow item in dt.Rows)
                        {
                            _Accessorieslist._Accessories _setacc = new _Accessorieslist._Accessories();
                            
                            int _id = int.Parse(item["ID"].ToString());
                            _setacc.ID = _id;
                            _setacc.Name = item["Name"].ToString();
                            _p._Purchase._SetAccList.Add(_id, _setacc);
                            this.Add(_id, _p);
                        }
                    }
                    else if (num == 3)
                    {
                        _SPurchase _p = new _SPurchase();
                        foreach (DataRow item in dt.Rows)
                        {
                            _AccessoriesSTDList._AccessoriesSTD _setaccSTD = new _AccessoriesSTDList._AccessoriesSTD();
                            
                            int _id = int.Parse(item["ID"].ToString());
                            _setaccSTD.ID = _id;
                            _setaccSTD.Name = item["Name"].ToString();
                            _p._Purchase._SetAccSTDList.Add(_id, _setaccSTD);
                            this.Add(_id, _p);
                        }
                    }
                    else if (num == 4)
                    {
                        _SPurchase _p = new _SPurchase();
                        if (dt.Rows[0]["AdAcc_ID"].ToString() != string.Empty)
                        {       
                        foreach (DataRow item in dt.Rows)
                        {
                            _AdAccessoriesList._AdAccessories _adacc = new _AdAccessoriesList._AdAccessories();
                            
                            int _id = int.Parse(item["ID"].ToString());
                            _adacc.ID = _id;
                            _adacc.Name = item["Name"].ToString();
                            if (item["Price"].ToString() != string.Empty)
                            {
                                _adacc.Price = decimal.Parse(item["Price"].ToString());
                            }
                            _adacc.Free = item["Free"].ToString();
                            _p._Purchase._SetAddAccList.Add(_id, _adacc);
                            this.Add(_id, _p);
                        }
                        }
                    }
                    else if (num == 5)
                    {
                        _SPurchase _p = new _SPurchase();
                        foreach (DataRow item in dt.Rows)
                        {
                            _DiscountList._Discount _dc = new _DiscountList._Discount();

                            int _id = int.Parse(item["ID"].ToString());
                            _dc.ID = _id;
                            _dc.Name = item["Name"].ToString();
                            if (item["Price"].ToString() != string.Empty)
                            {
                                _dc.Price = decimal.Parse(item["Price"].ToString());
                            }
                            _p._Purchase._DcList.Add(_id, _dc);
                            this.Add(_id, _p);
                        }
                    }

                    else if (num == 6)
                    {
                        _SPurchase _p = new _SPurchase();
                        foreach (DataRow item in dt.Rows)
                        {
                            BodyOptionList.BodyOption _Body = new BodyOptionList.BodyOption();

                            int _id = int.Parse(item["ID"].ToString());
                            _Body.Body_Option_ID = int.Parse(item["Body_Option_ID"].ToString());
                            _Body.Body_Option_Name = item["Body_Option_Name"].ToString();
                            _Body.finance = item["finance"].ToString();
                            if (item["Body_Option_price"].ToString() != string.Empty)
                            {
                                _Body.Body_Option_price = decimal.Parse(item["Body_Option_price"].ToString());
                            }
                            _p._Purchase._SetBodyOptionList.Add(_id, _Body);
                            this.Add(_id, _p);
                        }
                    }

                    else if (num == 7)
                    {
                        _SPurchase _p = new _SPurchase();
                        foreach (DataRow item in dt.Rows)
                        {
                            BodyOptionExtraList.BodyOptionExtra _BodyExtra = new BodyOptionExtraList.BodyOptionExtra();

                            int _id = int.Parse(item["ID"].ToString());
                            _BodyExtra.ID = _id;
                            _BodyExtra.Body_Company_ID = int.Parse(item["Body_Company_ID"].ToString());
                            _BodyExtra.Body_Company_Name = item["Body_Company_Name"].ToString();
                            _BodyExtra.Option_Name_extra = item["Option_Name_extra"].ToString();
                            _BodyExtra.Option_finance_extra = item["Option_finance_extra"].ToString();
                            if (item["Option_price_extra"].ToString() != string.Empty)
                            {
                                _BodyExtra.Option_price_extra = decimal.Parse(item["Option_price_extra"].ToString());
                            }
                            _p._Purchase._SetBodyOptionExtraList.Add(_id, _BodyExtra);
                            this.Add(_id, _p);
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
            return result;
        }

        public class _SPurchase
        {
            private CStatement _statementPO;

            public _Purchase _Purchase { get; set; }
            public _Customer _Customer { get; set; }
            public Tb_UserList.Tb_User Tb_User { get; set; }
            public string CarBranch { get; set; }


            public _SPurchase()
            {
                this._Purchase = new _Purchase();
                this._Customer = new _Customer();
                this.Tb_User = new Tb_UserList.Tb_User();
                this.CarBranch = string.Empty;
                this._statementPO = new CStatement("SELECT_SPurchase", "INSER", "UPDATE_Purchase", "DELETE", System.Data.CommandType.StoredProcedure);
                //this._statementPO = new CStatement("SELECT_SPurchase2", "INSER", "UPDATE_Purchase", "DELETE", System.Data.CommandType.StoredProcedure);
            }

            public DataTable Select_SPurchasetoExcel(int num, string _Company, string _Branch, int _EmpID, string _CusName, string _MCNumber, string _MCode, DateTime _Date1, DateTime _Date2, DateTime _OutDate1, DateTime _OutDate2, DateTime _RegisDate1, DateTime _RegisDate2,string _CarPlate,string _TruckNumber,string _Tel_Mobile, string _CarBranch)
            {
                DataTable _dt = new DataTable();
                CStatementList cstate = new CStatementList(_SQLConnection.CSQLConnection);
                try
                {
                    try
                    {
                        CSQLParameterList plist = new CSQLParameterList();
                        plist.Add("@num", DbType.Int32, num, ParameterDirection.Input);
                        plist.Add("@Company", DbType.String, _Company, ParameterDirection.Input);
                        plist.Add("@Branch", DbType.String, _Branch, ParameterDirection.Input);
                        plist.Add("@EmpID", DbType.Int32, _EmpID, ParameterDirection.Input);
                        plist.Add("@CusName", DbType.String, _CusName, ParameterDirection.Input);
                        plist.Add("@MCNumber", DbType.String, _MCNumber, ParameterDirection.Input);
                        plist.Add("@MCode", DbType.String, _MCode, ParameterDirection.Input);
                        plist.Add("@Date1", DbType.Date, _Date1, ParameterDirection.Input);
                        plist.Add("@Date2", DbType.Date, _Date2, ParameterDirection.Input);
                        plist.Add("@OutDate1", DbType.Date, _OutDate1, ParameterDirection.Input);
                        plist.Add("@OutDate2", DbType.Date, _OutDate2, ParameterDirection.Input);
                        plist.Add("@RegisDate1", DbType.Date, _RegisDate1, ParameterDirection.Input);
                        plist.Add("@RegisDate2", DbType.Date, _RegisDate2, ParameterDirection.Input);
                        plist.Add("@CarPlate", DbType.String, _CarPlate, ParameterDirection.Input);
                        plist.Add("@TruckNumber", DbType.String, _TruckNumber, ParameterDirection.Input);
                        plist.Add("@Tel_Mobile1", DbType.String, _Tel_Mobile, ParameterDirection.Input);
                        plist.Add("@CarBranch", DbType.String, _CarBranch, ParameterDirection.Input);
                        CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                        CSQLStatementValue csvUser = new CSQLStatementValue(this._statementPO, plist, NoomLibrary.StatementType.Select);
                        adlist.Add(csvUser);
                        cstate.Open();
                        _dt = (DataTable)cstate.Execute(adlist);
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
                return _dt;
            }
        }




    }
}