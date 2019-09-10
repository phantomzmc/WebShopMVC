using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using Purchase._Class;

namespace Purchase._Form
{
    public partial class _SPurchaseForm : System.Web.UI.Page
    {
        decimal SumAdAcc = 0, SumDc = 0;
        private _AddressList _AddList;
        private _AddressList _SentAddList;
        private _Accessorieslist _SetAccList;
        private _AccessoriesSTDList _SetAccSTDList;
        private _AdAccessoriesList _AdAccList;
        private _DiscountList _DcList;
        private BodyOptionList _SetBodyOptionList;
        private BodyOptionList _BodyOptionList;
        private BodyOptionList _ddlbodyoption;
        private BodyClassList _BodyClassList;
        private BodyOptionExtraList _SetBodyOptionExtraList;
        private BodyOptionExtraList _BodyoptionListExtra;
        private BodyOptionExtraList _ddlbodyoptionExtra;
 


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["login"] == null)
            {
                Response.Redirect("~/Account/_LoginForm.aspx");
            }

            if (Session["AddList"] != null)
            {
                this._AddList = (_AddressList)Session["AddList"];   
            }
            if (Session["SentAddList"] != null)
            {
                this._SentAddList = (_AddressList)Session["SentAddList"];
            }
            if (Session["SetAccList"] != null)
            {
                this._SetAccList = (_Accessorieslist)Session["SetAccList"];
            }
            if (Session["SetAccSTDList"] != null)
            {
                this._SetAccSTDList = (_AccessoriesSTDList)Session["SetAccSTDList"];
            }
            if (Session["AdAccList"] != null)
            {
                this._AdAccList = (_AdAccessoriesList)Session["AdAccList"];
            }
            if (Session["DcList"] != null)
            {
                this._DcList = (_DiscountList)Session["DcList"];
            }
            if (Session["BodyOption"] != null)
            {
                this._SetBodyOptionList = (BodyOptionList)Session["BodyOption"];
            }
            if (Session["BodyExtra"] != null)
            {
                this._SetBodyOptionExtraList = (BodyOptionExtraList)Session["BodyExtra"];
            }

            if (!IsPostBack)
            {
                this.String_Empty();
                this.GET_CB();
                this.Panel_PopupEditPO.Visible = false;

                if ((string)Session["UserType"].ToString() == "2" || (string)Session["UserType"].ToString() == "8")
                {
                    if ((string)Session["UserType"].ToString() == "8")
                    {
                        this.Panel_BtnInvoice.Visible = true;
                    }
                    else
                    {
                        this.Panel_BtnInvoice.Visible = false;
                        this.Panel_SRegis_Date.Visible = true;
                    }

                }
                else
                {
                    this.Panel_BtnInvoice.Visible = false;
                    this.Panel_SRegis_Date.Visible = false;
                }

                if ((string)Session["UserType"].ToString() == "3")
                {
                    this.Panel_BtnInvoice.Visible = false;
                    this.Img_ExportExcel.Visible = false;
                }

                _BankList _bank = new _BankList();
                _bank.Select_Bank(1);
                this.DD_PayTM_Bank.DataSource = _bank.Values;
                this.DD_PayTM_Bank.DataTextField = "Name";
                this.DD_PayTM_Bank.DataValueField = "ID";
                this.DD_PayTM_Bank.DataBind();
                this.DD_PayTM_Bank.Items.Insert(0, "-- เลือก --");
                this.DD_PayTM_Bank.SelectedIndex = 0;

                this.DD_PayCheque_Bank.DataSource = _bank.Values;
                this.DD_PayCheque_Bank.DataTextField = "Name";
                this.DD_PayCheque_Bank.DataValueField = "ID";
                this.DD_PayCheque_Bank.DataBind();
                this.DD_PayCheque_Bank.Items.Insert(0, "-- เลือก --");
                this.DD_PayCheque_Bank.SelectedIndex = 0;

                _CarTypeList _ct = new _CarTypeList();
                _ct.Select_CarType(1);
                this.DD_ECarType.DataSource = _ct.Values;
                this.DD_ECarType.DataTextField = "Name";
                this.DD_ECarType.DataValueField = "ID";
                this.DD_ECarType.DataBind();
                this.DD_ECarType.Items.Insert(0, "-- เลือก --");
                this.DD_ECarType.SelectedIndex = 0;

            }
        }

        private void String_Empty()
        {
            this.Txt_SCusName.Text = string.Empty;
            this.Txt_SMCNumber.Text = string.Empty;
            this.Txt_Date1.Text = string.Empty;
            this.Txt_Date2.Text = string.Empty;
            this.Txt_OutDate1.Text = string.Empty;
            this.Txt_OutDate2.Text = string.Empty;
        }

        private void GET_CB()
        {
            DataTable _dtCB = (DataTable)Session["TeamCB"];

            if ((string)Session["UserType"].ToString() == "2" || (string)Session["UserType"].ToString() == "7" || (string)Session["UserType"].ToString() == "8")
            {
                _BranchList _Branch = new _BranchList();
                _Branch.Select(2);
                this.DD_SBranch.DataSource = _Branch.Values;
                this.DD_SBranch.DataTextField = "BranchName";
                this.DD_SBranch.DataValueField = "BranchName";
                this.DD_SBranch.DataBind();
                this.DD_SBranch.Items.Insert(0, "-- สาขาทั้งหมด --");
                this.DD_SBranch.SelectedIndex = 0;

                Tb_UserList _user = new Tb_UserList();
                _user.SelectEmpSale(1, string.Empty, string.Empty, 0);
                this.DD_SaleName.DataSource = _user.Values;
                this.DD_SaleName.DataTextField = "FullName";
                this.DD_SaleName.DataValueField = "EmpID";
                this.DD_SaleName.DataBind();
                this.DD_SaleName.Items.Insert(0, "-- Saleทั้งหมด --");
                this.DD_SaleName.SelectedIndex = 0;
            }
            else if ((string)Session["UserType"].ToString() == "4")
            {
                _BranchList _Branch = new _BranchList();
                string _b = _dtCB.Rows[0]["Branch"].ToString();
                _Branch.Select_Branch(1, _dtCB.Rows[0]["Company"].ToString(), _dtCB.Rows[0]["Branch"].ToString(), string.Empty);
                this.DD_SBranch.DataSource = _Branch.Values;
                this.DD_SBranch.DataTextField = "BranchName";
                this.DD_SBranch.DataValueField = "BranchName";
                this.DD_SBranch.DataBind();

                Tb_UserList _user = new Tb_UserList();
                _user.SelectEmpSale(1, _dtCB.Rows[0]["Company"].ToString(), _dtCB.Rows[0]["Branch"].ToString(), 0);
                this.DD_SaleName.DataSource = _user.Values;
                this.DD_SaleName.DataTextField = "FullName";
                this.DD_SaleName.DataValueField = "EmpID";
                this.DD_SaleName.DataBind();
                this.DD_SaleName.Items.Insert(0, "-- Saleทั้งหมด --");
                this.DD_SaleName.SelectedIndex = 0;
            }
            else if ((string)Session["UserType"].ToString() == "5" || (string)Session["UserType"].ToString() == "6")
            {
                if (_dtCB.Rows[0]["Company"].ToString() == "A")
                {
                    _BranchList _Branch = new _BranchList();
                    _Branch.Select(2);
                    this.DD_SBranch.DataSource = _Branch.Values;
                    this.DD_SBranch.DataTextField = "BranchName";
                    this.DD_SBranch.DataValueField = "BranchName";
                    this.DD_SBranch.DataBind();
                    this.DD_SBranch.Items.Insert(0, "-- สาขาทั้งหมด --");
                    this.DD_SBranch.SelectedIndex = 0;

                    Tb_UserList _user = new Tb_UserList();
                    _user.SelectEmpSale(1, string.Empty, string.Empty, 0);
                    this.DD_SaleName.DataSource = _user.Values;
                    this.DD_SaleName.DataTextField = "FullName";
                    this.DD_SaleName.DataValueField = "EmpID";
                    this.DD_SaleName.DataBind();
                    this.DD_SaleName.Items.Insert(0, "-- Saleทั้งหมด --");
                    this.DD_SaleName.SelectedIndex = 0;
                }
                else
                {
                    _BranchList _Branch = new _BranchList();
                    string _b = _dtCB.Rows[0]["Branch"].ToString();
                    _Branch.Select_Branch(1, _dtCB.Rows[0]["Company"].ToString(), _dtCB.Rows[0]["Branch"].ToString(), string.Empty);
                    this.DD_SBranch.DataSource = _Branch.Values;
                    this.DD_SBranch.DataTextField = "BranchName";
                    this.DD_SBranch.DataValueField = "BranchName";
                    this.DD_SBranch.DataBind();

                    Tb_UserList _user = new Tb_UserList();
                    _user.SelectEmpSale(1, _dtCB.Rows[0]["Company"].ToString(), _dtCB.Rows[0]["Branch"].ToString(), 0);
                    this.DD_SaleName.DataSource = _user.Values;
                    this.DD_SaleName.DataTextField = "FullName";
                    this.DD_SaleName.DataValueField = "EmpID";
                    this.DD_SaleName.DataBind();
                    this.DD_SaleName.Items.Insert(0, "-- Saleทั้งหมด --");
                    this.DD_SaleName.SelectedIndex = 0;
                }
            }
            else
            {
                _BranchList _Branch = new _BranchList();
                _Branch.Select_Branch(1, _dtCB.Rows[0]["Company"].ToString(), _dtCB.Rows[0]["Branch"].ToString(), string.Empty);
                this.DD_SBranch.DataSource = _Branch.Values;
                this.DD_SBranch.DataTextField = "BranchName";
                this.DD_SBranch.DataValueField = "BranchName";
                this.DD_SBranch.DataBind();

                Tb_UserList _user = new Tb_UserList();
                _user.SelectEmpSale(2, string.Empty, string.Empty, int.Parse((string)Session["Emp_id"].ToString()));
                this.DD_SaleName.DataSource = _user.Values;
                this.DD_SaleName.DataTextField = "FullName";
                this.DD_SaleName.DataValueField = "EmpID";
                this.DD_SaleName.DataBind();
            }

            //int _utype = (int)Session["UserType"];
            //string _ucompany = _dtCB.Rows[0]["Company"].ToString();
            //string _ubranch = _dtCB.Rows[0]["Branch"].ToString();
            //_BranchList _Branch = new _BranchList();
            //_Branch.Select_Branch(3,_ucompany,_ubranch,string.Empty,_utype);
            //this.DD_SBranch.DataSource = _Branch.Values;
            //this.DD_SBranch.DataTextField = "BranchName";
            //this.DD_SBranch.DataValueField = "BranchName";
            //this.DD_SBranch.DataBind();
            //this.DD_SBranch.Items.Insert(0, "-- สาขาทั้งหมด --");
            //this.DD_SBranch.SelectedIndex = 0;
            _ModelList _Model = new _ModelList();
            _Model.Select(1);
            this.DD_SModel.DataSource = _Model.Values;
            this.DD_SModel.DataTextField = "MName";
            this.DD_SModel.DataValueField = "MCode";
            this.DD_SModel.DataBind();
            this.DD_SModel.Items.Insert(0, "-- เลือกทั้งหมด --");
            this.DD_SModel.SelectedIndex = 0;

            _CompanyList _company = new _CompanyList();
            _company.Select(3);
            this.DD_SCarBranch.DataSource = _company.Values;
            this.DD_SCarBranch.DataTextField = "CompanyName";
            this.DD_SCarBranch.DataValueField = "Companycode";
            this.DD_SCarBranch.DataBind();
            this.DD_SCarBranch.Items.Insert(0, "-- เลือกทั้งหมด --");
            this.DD_SCarBranch.SelectedIndex = 0;
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            this.GETDATA();
        }

        private void GETDATA()
        {
            DataTable _dtCB = (DataTable)Session["TeamCB"];
            _SPurchaseList _s = new _SPurchaseList();
            string _Branch = string.Empty;
            string _Company = string.Empty;
            int _EmpID = 0;
            string _CusName = string.Empty;
            string _MCNumber = string.Empty;
            string _CarBranch = string.Empty;
            string _MCode = string.Empty;
            string _CarPlate = string.Empty;
            string _TruckNumber = string.Empty;
            string _Tel_Mobile = string.Empty;
            DateTime _Date1 = DateTime.MinValue;
            DateTime _Date2 = DateTime.MinValue;
            DateTime _OutDate1 = DateTime.MinValue;
            DateTime _OutDate2 = DateTime.MinValue;
            DateTime _RegisDate1 = DateTime.MinValue;
            DateTime _RegisDate2 = DateTime.MinValue;

            if ((string)Session["UserType"].ToString() == "2" || (string)Session["UserType"].ToString() == "7" || (string)Session["UserType"].ToString() == "8")
            {
                
                if (this.DD_SBranch.SelectedIndex != 0)
                {
                    _BranchList _b = new _BranchList();
                    _b.Select_Branch(2, string.Empty, string.Empty, this.DD_SBranch.SelectedValue);
                    _Company = _b[1]._Company.Companycode;
                    _Branch = _b[1].Branchcode;
                }

                if (this.DD_SaleName.SelectedIndex != 0)
                {
                    _EmpID = int.Parse(this.DD_SaleName.SelectedValue);
                }

                if (this.Txt_SCusName.Text.Trim() != string.Empty)
                {
                    _CusName = this.Txt_SCusName.Text.Trim();
                }

                if (this.Txt_SMCNumber.Text.Trim() != string.Empty)
                {
                    _MCNumber = this.Txt_SMCNumber.Text.Trim();   
                }
                if (this.Txt_CarPlate.Text.Trim() != string.Empty)
                {
                    _CarPlate = this.Txt_CarPlate.Text.Trim();
                }
                if (this.Txt_TruckNumber.Text.Trim() != string.Empty)
                {
                    _TruckNumber = this.Txt_TruckNumber.Text.Trim();
                }
                if (this.Txt_Tel_Mobile.Text.Trim() != string.Empty)
                {
                    _Tel_Mobile = this.Txt_Tel_Mobile.Text.Trim();
                }
                if (this.Txt_Date1.Text.Trim() != string.Empty && this.Txt_Date2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_Date1.Text.Trim(), out _Date1);
                    DateTime.TryParse(this.Txt_Date2.Text.Trim(), out _Date2);
                }

                if (this.Txt_OutDate1.Text.Trim() != string.Empty && this.Txt_OutDate2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_OutDate1.Text.Trim(), out _OutDate1);
                    DateTime.TryParse(this.Txt_OutDate2.Text.Trim(), out _OutDate2);
                }

                if (this.Txt_SRegisDate1.Text.Trim() != string.Empty && this.Txt_SRegisDate2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_SRegisDate1.Text.Trim(), out _RegisDate1);
                    DateTime.TryParse(this.Txt_SRegisDate2.Text.Trim(), out _RegisDate2);
                }

                if (this.DD_SCarBranch.SelectedIndex != 0)
                {
                    _CarBranch = this.DD_SCarBranch.SelectedValue;
                }

                if (this.DD_SModel.SelectedIndex != 0)
                {
                    _MCode = this.DD_SModel.SelectedValue;
                }
                
            }
            else if ((string)Session["UserType"].ToString() == "4")
            {
                _Company = _dtCB.Rows[0]["Company"].ToString();
                _Branch = _dtCB.Rows[0]["Branch"].ToString();

                if (this.DD_SaleName.SelectedIndex != 0)
                {
                    _EmpID = int.Parse(this.DD_SaleName.SelectedValue);
                }

                if (this.Txt_SCusName.Text.Trim() != string.Empty)
                {
                    _CusName = this.Txt_SCusName.Text.Trim();
                }

                if (this.Txt_SMCNumber.Text.Trim() != string.Empty)
                {
                    _MCNumber = this.Txt_SMCNumber.Text.Trim();
                }

                if (this.Txt_CarPlate.Text.Trim() != string.Empty)
                {
                    _CarPlate = this.Txt_CarPlate.Text.Trim();
                }
                if (this.Txt_TruckNumber.Text.Trim() != string.Empty)
                {
                    _TruckNumber = this.Txt_TruckNumber.Text.Trim();
                }
                if (this.Txt_Tel_Mobile.Text.Trim() != string.Empty)
                {
                    _Tel_Mobile = this.Txt_Tel_Mobile.Text.Trim();
                }
                if (this.Txt_Date1.Text.Trim() != string.Empty && this.Txt_Date2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_Date1.Text.Trim(), out _Date1);
                    DateTime.TryParse(this.Txt_Date2.Text.Trim(), out _Date2);
                }

                if (this.Txt_OutDate1.Text.Trim() != string.Empty && this.Txt_OutDate2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_OutDate1.Text.Trim(), out _OutDate1);
                    DateTime.TryParse(this.Txt_OutDate2.Text.Trim(), out _OutDate2);
                }

                if (this.DD_SCarBranch.SelectedIndex != 0)
                {
                    _CarBranch = this.DD_SCarBranch.SelectedValue;
                }

                if (this.DD_SModel.SelectedIndex != 0)
                {
                    _MCode = this.DD_SModel.SelectedValue;
                }

            }
            else if ((string)Session["UserType"].ToString() == "5" || (string)Session["UserType"].ToString() == "6")
            {
                if (_dtCB.Rows[0]["Company"].ToString() == "A")
                {
                    if (this.DD_SBranch.SelectedIndex != 0)
                    {
                        _BranchList _b = new _BranchList();
                        _b.Select_Branch(2, string.Empty, string.Empty, this.DD_SBranch.SelectedValue);
                        _Company = _b[1]._Company.Companycode;
                        _Branch = _b[1].Branchcode;
                    }

                    if (this.DD_SaleName.SelectedIndex != 0)
                    {
                        _EmpID = int.Parse(this.DD_SaleName.SelectedValue);
                    }

                    if (this.Txt_SCusName.Text.Trim() != string.Empty)
                    {
                        _CusName = this.Txt_SCusName.Text.Trim();
                    }

                    if (this.Txt_SMCNumber.Text.Trim() != string.Empty)
                    {
                        _MCNumber = this.Txt_SMCNumber.Text.Trim();
                    }
                    if (this.Txt_CarPlate.Text.Trim() != string.Empty)
                    {
                        _CarPlate = this.Txt_CarPlate.Text.Trim();
                    }
                    if (this.Txt_TruckNumber.Text.Trim() != string.Empty)
                    {
                        _TruckNumber = this.Txt_TruckNumber.Text.Trim();
                    }
                    if (this.Txt_Tel_Mobile.Text.Trim() != string.Empty)
                    {
                        _Tel_Mobile = this.Txt_Tel_Mobile.Text.Trim();
                    }
                    if (this.Txt_Date1.Text.Trim() != string.Empty && this.Txt_Date2.Text.Trim() != string.Empty)
                    {
                        DateTime.TryParse(this.Txt_Date1.Text.Trim(), out _Date1);
                        DateTime.TryParse(this.Txt_Date2.Text.Trim(), out _Date2);
                    }

                    if (this.Txt_OutDate1.Text.Trim() != string.Empty && this.Txt_OutDate2.Text.Trim() != string.Empty)
                    {
                        DateTime.TryParse(this.Txt_OutDate1.Text.Trim(), out _OutDate1);
                        DateTime.TryParse(this.Txt_OutDate2.Text.Trim(), out _OutDate2);
                    }

                    if (this.DD_SCarBranch.SelectedIndex != 0)
                    {
                        _CarBranch = this.DD_SCarBranch.SelectedValue;
                    }

                    if (this.DD_SModel.SelectedIndex != 0)
                    {
                        _MCode = this.DD_SModel.SelectedValue;
                    }
                }
                else
                {
                    _Company = _dtCB.Rows[0]["Company"].ToString();
                    _Branch = _dtCB.Rows[0]["Branch"].ToString();

                    if (this.DD_SaleName.SelectedIndex != 0)
                    {
                        _EmpID = int.Parse(this.DD_SaleName.SelectedValue);
                    }

                    if (this.Txt_SCusName.Text.Trim() != string.Empty)
                    {
                        _CusName = this.Txt_SCusName.Text.Trim();
                    }

                    if (this.Txt_SMCNumber.Text.Trim() != string.Empty)
                    {
                        _MCNumber = this.Txt_SMCNumber.Text.Trim();
                    }
                    if (this.Txt_CarPlate.Text.Trim() != string.Empty)
                    {
                        _CarPlate = this.Txt_CarPlate.Text.Trim();
                    }
                    if (this.Txt_TruckNumber.Text.Trim() != string.Empty)
                    {
                        _TruckNumber = this.Txt_TruckNumber.Text.Trim();
                    }
                    if (this.Txt_Tel_Mobile.Text.Trim() != string.Empty)
                    {
                        _Tel_Mobile = this.Txt_Tel_Mobile.Text.Trim();
                    }
                    if (this.Txt_Date1.Text.Trim() != string.Empty && this.Txt_Date2.Text.Trim() != string.Empty)
                    {
                        DateTime.TryParse(this.Txt_Date1.Text.Trim(), out _Date1);
                        DateTime.TryParse(this.Txt_Date2.Text.Trim(), out _Date2);
                    }

                    if (this.Txt_OutDate1.Text.Trim() != string.Empty && this.Txt_OutDate2.Text.Trim() != string.Empty)
                    {
                        DateTime.TryParse(this.Txt_OutDate1.Text.Trim(), out _OutDate1);
                        DateTime.TryParse(this.Txt_OutDate2.Text.Trim(), out _OutDate2);
                    }

                    if (this.Txt_SRegisDate1.Text.Trim() != string.Empty && this.Txt_SRegisDate2.Text.Trim() != string.Empty)
                    {
                        DateTime.TryParse(this.Txt_SRegisDate1.Text.Trim(), out _RegisDate1);
                        DateTime.TryParse(this.Txt_SRegisDate2.Text.Trim(), out _RegisDate2);
                    }

                    if (this.DD_SCarBranch.SelectedIndex != 0)
                    {
                        _CarBranch = this.DD_SCarBranch.SelectedValue;
                    }

                    if (this.DD_SModel.SelectedIndex != 0)
                    {
                        _MCode = this.DD_SModel.SelectedValue;
                    }
                }
            }
            else
            {
                _EmpID = (int)Session["Emp_id"];

                if (this.Txt_SCusName.Text.Trim() != string.Empty)
                {
                    _CusName = this.Txt_SCusName.Text.Trim();
                }

                if (this.Txt_SMCNumber.Text.Trim() != string.Empty)
                {
                    _MCNumber = this.Txt_SMCNumber.Text.Trim();
                }

                if (this.Txt_Date1.Text.Trim() != string.Empty && this.Txt_Date2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_Date1.Text.Trim(), out _Date1);
                    DateTime.TryParse(this.Txt_Date2.Text.Trim(), out _Date2);
                }

                if (this.Txt_OutDate1.Text.Trim() != string.Empty && this.Txt_OutDate2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_OutDate1.Text.Trim(), out _OutDate1);
                    DateTime.TryParse(this.Txt_OutDate2.Text.Trim(), out _OutDate2);
                }

                if (this.DD_SCarBranch.SelectedIndex != 0)
                {
                    _CarBranch = this.DD_SCarBranch.SelectedValue;
                }

                if (this.DD_SModel.SelectedIndex != 0)
                {
                    _MCode = this.DD_SModel.SelectedValue;
                }
            }


            _s.Select(1, _Company, _Branch, _EmpID, _CusName, _MCNumber, _MCode, _Date1, _Date2, _OutDate1, _OutDate2, _RegisDate1, _RegisDate2,_CarPlate,_TruckNumber,_Tel_Mobile, _CarBranch);
            this.Lb_CountData.Text = _s.Count.ToString();
            this.gv_PO.DataSource = _s.Values;
            this.gv_PO.DataBind();
            this.Panel1.Visible = true;
        }

        protected void DD_SBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DD_SBranch.SelectedIndex != 0)
            {
                string _Branch = string.Empty;
                string _Company = string.Empty;

                _BranchList _b = new _BranchList();
                _b.Select_Branch(2, string.Empty, string.Empty, this.DD_SBranch.SelectedValue);
                _Company = _b[1]._Company.Companycode;
                _Branch = _b[1].Branchcode;

                Tb_UserList _user = new Tb_UserList();
                _user.SelectEmpSale(1, _Company, _Branch, 0);
                this.DD_SaleName.DataSource = _user.Values;
                this.DD_SaleName.DataTextField = "FullName";
                this.DD_SaleName.DataValueField = "EmpID";
                this.DD_SaleName.DataBind();
                this.DD_SaleName.Items.Insert(0, "-- Saleทั้งหมด --");
                this.DD_SaleName.SelectedIndex = 0;
            }
            else
            {
                Tb_UserList _user = new Tb_UserList();
                _user.SelectEmpSale(1, string.Empty, string.Empty, 0);
                this.DD_SaleName.DataSource = _user.Values;
                this.DD_SaleName.DataTextField = "FullName";
                this.DD_SaleName.DataValueField = "EmpID";
                this.DD_SaleName.DataBind();
                this.DD_SaleName.Items.Insert(0, "-- Saleทั้งหมด --");
                this.DD_SaleName.SelectedIndex = 0;
            }
        }

        protected void Img_Print_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton bt = (ImageButton)sender;
            GridViewRow gv = (GridViewRow)bt.NamingContainer;
            string _MCNumber = ((Label)gv_PO.Rows[gv.RowIndex].FindControl("Lb_MCNumber")).Text;

            _Purchase _p = new _Purchase();
            int IDCheck = int.Parse(((Label)gv_PO.Rows[gv.RowIndex].FindControl("LBID")).Text);
            _p.InsertLOGPRINTPurchase(IDCheck);

            _MCNumber = _Encryption.Encrypt(_MCNumber);

            string[] spChar = { "+", "&", "%", "$" };
            string[] replaceChar = { "_plus", "_amp", "_per", "_dol" };

            for (int i = 0; i <= spChar.Length - 1; i++)
            {
                _MCNumber = _MCNumber.Replace(spChar[i], replaceChar[i]);
            }

            string script = "window.location='" + Request.ApplicationPath + "../_ReportForm/Rpt_PurchaseForm.aspx?MC=" + _MCNumber + "'";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }

        protected void gv_PO_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#E3D6D6';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                if ((string)Session["UserType"].ToString() == "3")
                {
                    Label Lb_ToCustomerByDate = (Label)e.Row.FindControl("Lb_ToCustomerByDate");
                    ImageButton Img_Edit = (ImageButton)e.Row.FindControl("Img_Edit");
                    if (Lb_ToCustomerByDate.Text == "01/00/0544")
                    {
                        Img_Edit.Visible = true;
                    }
                    else
                    {
                        Img_Edit.Visible = false;
                    }
                }
            }
        }

        protected void Img_Close_Click(object sender, ImageClickEventArgs e)
        {
            if (this._SetBodyOptionList != null)
            {
                Session.Remove("BodyOption");
                this._SetBodyOptionList.Clear();
            }
            if (this._SetBodyOptionExtraList != null)
            {
                Session.Remove("BodyExtra");
                this._SetBodyOptionExtraList.Clear();
            }
            this.Panel_PopupEditPO.Visible = false;
            this.Panel_SMCNumber.Visible = true;
            this.Panel1.Visible = true;
            this.GETDATA();
           
        }

        protected void Img_Edit_Click(object sender, ImageClickEventArgs e)
        {
            //this.ModalPopupExtender_EAddress.Show();
            

            ImageButton bt = (ImageButton)sender;
            GridViewRow gv = (GridViewRow)bt.NamingContainer;
            string _POID = ((Label)gv_PO.Rows[gv.RowIndex].FindControl("LBID")).Text;

            _SPurchaseList _s = new _SPurchaseList();
            _s.SELECT_EPurchase(1, int.Parse(_POID));

            _CompanyList _company = new _CompanyList();
            _company.Select(1);
            this.Rb_ECompany.DataSource = _company.Values;
            this.Rb_ECompany.DataTextField = "CompanyName";
            this.Rb_ECompany.DataValueField = "Companycode";
            this.Rb_ECompany.DataBind();

            _EducationList _Education = new _EducationList();
            _Education.Select(1);
            this.DD_EEducation.DataSource = _Education.Values;
            this.DD_EEducation.DataTextField = "Detail";
            this.DD_EEducation.DataValueField = "ID";
            this.DD_EEducation.DataBind();
            this.DD_EEducation.SelectedIndex = 0;

            _CareerList _CareerList = new _CareerList();
            _CareerList.Select(1);
            this.DD_ECareer.DataSource = _CareerList.Values;
            this.DD_ECareer.DataTextField = "Name";
            this.DD_ECareer.DataValueField = "ID";
            this.DD_ECareer.DataBind();
            this.DD_ECareer.Items.Insert(0, "-- เลือก --");
            this.DD_ECareer.SelectedIndex = 0;

            _IncomeList _Income = new _IncomeList();
            _Income.Select(1);
            this.DD_EInCome.DataSource = _Income.Values;
            this.DD_EInCome.DataTextField = "Detail";
            this.DD_EInCome.DataValueField = "ID";
            this.DD_EInCome.DataBind();
            this.DD_EInCome.SelectedIndex = 0;

            this.Edit_StringEmpty();

            #region หัว
            this.Txt_PoNum.Text = _s[1]._Purchase.PoNum.ToString();
            this.Rb_ECompany.SelectedValue = _s[1]._Purchase._Company.Companycode;
            this.Lb_EPOID.Text = _s[1]._Purchase.ID.ToString();
            this.Lb_PurchaseNo.Text = _s[1]._Purchase.PurchaseNo.ToString();
            #endregion

            #region ข้อมูลลูกค้า
            DateTime _Ed = _s[1]._Purchase.OutCar_Date;
            if (_Ed.ToString() != "1/1/0544 0:00:00")
            {
                this.Txt_EDate.Text = _s[1]._Purchase.OutCar_Date.ToString("dd MMM yy");
            }
            else
            {
                this.Txt_EDate.Text = string.Empty;
            }
            this.Txt_ECusID.Text = _s[1]._Customer.ID.ToString();
            this.Txt_ECusNo.Text = _s[1]._Customer.CusNo.ToString();
            this.DD_ECusType.SelectedValue = _s[1]._Customer.CusType.ToString();
            this.Txt_ESaleName.Text = _s[1].Tb_User.FullName.ToString();

            if (_s[1]._Customer.CusType.ToString() == "บุคคล")
            {
                this.Panel_EPerson.Visible = true;
                this.Panel_ECompany.Visible = false;
                this.Panel_EditCompanyName.Visible = false;
                this.Txt_EIDCard.Text = _s[1]._Customer.IDCard.ToString();
                this.Txt_EPrefix.Text = _s[1]._Customer.Prefix.ToString();
                this.Txt_EName.Text = _s[1]._Customer.Name.ToString();
                this.Txt_ESurname.Text = _s[1]._Customer.Surname.ToString();
                this.Txt_ENickname.Text = _s[1]._Customer.Nickname.ToString();
                DateTime _Bd = _s[1]._Customer.Birthday;
                if (_Bd.ToString() != "1/1/0544 0:00:00")
                {
                    this.Txt_EBirthday.Text = _s[1]._Customer.Birthday.ToString("dd MMM yy");
                }
                else
                {
                    this.Txt_EBirthday.Text = string.Empty;
                }
                this.DD_EPerson_Sex.SelectedValue = _s[1]._Customer.Sex.ToString();
                this.DD_EEducation.SelectedValue = _s[1]._Customer._Education.id.ToString();
                if (_s[1]._Customer.Total_Member.ToString() != "0")
                {
                    this.Txt_ETotal_Member.Text = _s[1]._Customer.Total_Member.ToString();
                }
     
            }
            else
            {
                this.Panel_EPerson.Visible = false;
                this.Panel_ECompany.Visible = true;
                this.Txt_ECorporationCode.Text = _s[1]._Customer.CorporationCode.ToString();
                this.Txt_ECompanyName.Text = _s[1]._Customer.Name.ToString();
    
            }

            this.Txt_ETelMobile1.Text = _s[1]._Customer.Tel_Mobile1.ToString();
            this.Txt_ETelMobile2.Text = _s[1]._Customer.Tel_Mobile2.ToString();
            this.Txt_ETelHome_Work.Text = _s[1]._Customer.Tel_Work.ToString();
            this.Txt_EFax.Text = _s[1]._Customer.Tel_Fax.ToString();
            this.Txt_ElineID.Text = _s[1]._Customer.LineID.ToString();
            this.DD_ECareer.SelectedValue = _s[1]._Customer._Career.ID.ToString();
            if (_s[1]._Customer._Career.ID.ToString() == "11")
            {
                this.Txt_ECareer_Other.Text = _s[1]._Customer.Career_Other.ToString();
                this.Panel_ECareer_Other.Visible = true;
            }
            else
            {
                this.Panel_ECareer_Other.Visible = false;
            }
            this.Txt_ECareer_Remark.Text = _s[1]._Customer.Career_Remark.ToString();
            this.DD_EInCome.SelectedValue = _s[1]._Customer._Income.ID.ToString();

            Session.Add("AddList", _s[1]._Customer._AddressList);
            this.gv_EAddress.DataSource = _s[1]._Customer._AddressList.Values;
            this.gv_EAddress.DataBind();

            if (_s[1]._Customer.SendAddress_IDCard.ToString() == "Y")
            {
                this.Cb_ESendAddress.Checked = true;
                this.Cb_ESendAddress_New.Checked = false;
                this.gv_ESentAddress.Visible = false;
                this.Btn_EAddSendAddress.Visible = false;
            }
            else
            {
                this.Cb_ESendAddress.Checked = false;
                this.Cb_ESendAddress_New.Checked = true;
                this.gv_ESentAddress.Visible = true;
                this.Btn_EAddSendAddress.Visible = false;
                Session.Add("SentAddList", _s[1]._Customer._SentAddressList);
                this.gv_ESentAddress.DataSource = _s[1]._Customer._SentAddressList.Values;
                this.gv_ESentAddress.DataBind();
            }
            #endregion

            #region ข้อมูลรถ
            this.Txt_ECarName.Text = _s[1]._Purchase.CarName.ToString();
            this.DD_EBuyType.SelectedValue = _s[1]._Purchase.Buy_Type.ToString();
            this.Txt_EMCNumber.Text = _s[1]._Purchase.MCNumber.ToString();
            this.Txt_ETruckNumber.Text = _s[1]._Purchase.TruckNumber.ToString();
            this.Txt_EMName.Text = _s[1]._Purchase.MName.ToString();
            this.Txt_EMSaleCode.Text = _s[1]._Purchase.MSaleCode.ToString();
            this.Txt_ECName.Text = _s[1]._Purchase.CName.ToString();
            this.Txt_ECarPrice.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.CarPrice.ToString()));
            this.Txt_CarTax.Text = _s[1]._Purchase.CarTax.ToString() == string.Empty || _s[1]._Purchase.CarTax.ToString() == "" ? "-" : string.Format("{0:#,###}", Convert.ToDecimal(_s[1]._Purchase.CarTax.ToString()));
            this.Txt_ECarPlate.Text = _s[1]._Purchase.CarPlate.ToString();
            DateTime _Regis_Date = _s[1]._Purchase.Regis_Date;
            if (_Regis_Date.ToString() != "1/1/0544 0:00:00")
            {
                this.Txt_RegisDate.Text = _s[1]._Purchase.Regis_Date.ToString("dd MMM yy");
            }
            else
            {
                this.Txt_RegisDate.Text = string.Empty;
            }
            this.Txt_CarTax.Text = _s[1]._Purchase.CarTax.ToString();
            if (_s[1]._Purchase._CarType.ID.ToString() != "0" && _s[1]._Purchase._CarType.ID.ToString() != string.Empty)
            {
                this.DD_ECarType.SelectedValue = _s[1]._Purchase._CarType.ID.ToString();
            }
            else
            {
                this.DD_ECarType.SelectedIndex = 0;
            }

            if (_s[1]._Purchase.CarExchange.ToString() == "N")
            {
                this.Cb_ECE_N.Checked = true;
                this.Cb_ECE_Y.Checked = false;
                this.Panel_ECE_Y.Visible = false;
            }
            else
            {
                this.Cb_ECE_Y.Checked = true;
                this.Cb_ECE_N.Checked = false;
                this.Panel_ECE_Y.Visible = true;
                this.Txt_ECEMCNumber.Text = _s[1]._Purchase.CE_MCNumber.ToString();
                this.Txt_ECETruckNumber.Text = _s[1]._Purchase.CE_TruckNumber.ToString();
                this.Txt_ECEBrand.Text = _s[1]._Purchase.CE_Brand.ToString();
                this.Txt_ECEModel.Text = _s[1]._Purchase.CE_Model.ToString();
                this.Txt_ECEColor.Text = _s[1]._Purchase.CE_Color.ToString();
                this.Txt_ECEYear.Text = _s[1]._Purchase.CE_Year.ToString();
                this.Txt_ECECarPlate.Text = _s[1]._Purchase.CE_CarPlate.ToString();
                if (_s[1]._Purchase.CE_Price.ToString() != string.Empty && _s[1]._Purchase.CE_Price.ToString() != "0")
                {
                    this.Txt_ECEPrice.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.CE_Price.ToString()));
                }
                this.Txt_ECEEmp.Text = _s[1]._Purchase.CE_Emp.ToString();
            }
            
            #endregion

            #region  อุปกรณ์ตกแต่ง
            _InsuranceList _InList = new _InsuranceList();
            _InList.Select(1);
            this.DD_Insurance.DataSource = _InList.Values;
            this.DD_Insurance.DataTextField = "Name";
            this.DD_Insurance.DataValueField = "ID";
            this.DD_Insurance.DataBind();
            this.DD_Insurance.Items.Insert(0, "-- เลือก --");
            this.DD_Insurance.SelectedIndex = 0;


            BodyClassList _BodyClassList = new BodyClassList();
            _BodyClassList.Select(_s[1]._Purchase.MCode.ToString());
            this.DD_body.DataSource = _BodyClassList.Values;
            this.DD_body.DataTextField = "Body_Acc_Name";
            this.DD_body.DataValueField = "Body_Acc_ID";
            this.DD_body.DataBind();
            this.DD_body.Items.Insert(0, new ListItem("-- เลือก --", "0"));
            //this.DD_body.SelectedIndex = 0;
            if (_s[1]._Purchase.Body_Acc_ID.ToString() != string.Empty || _s[1]._Purchase.Body_Acc_ID.ToString() != "0")
            {
                this.DD_body.Items.FindByValue(_s[1]._Purchase.Body_Acc_ID.ToString()).Selected = true;
            }
            Session["BodyClassList"] = _BodyClassList;


            BodyCompany _bodycom = new BodyCompany();
            DataTable _bodyextra = _bodycom.Body_Select_Company();
            this.ddl_Body_Company.DataSource = _bodyextra;
            this.ddl_Body_Company.DataTextField = "Body_Company_Name";
            this.ddl_Body_Company.DataValueField = "Body_Company_ID";
            this.ddl_Body_Company.DataBind();
            this.ddl_Body_Company.Items.Insert(0, new ListItem("-- เลือก --", "0"));
            if (_s[1]._Purchase.Body_Extra_Company.ToString() != string.Empty || _s[1]._Purchase.Body_Extra_Company.ToString() != "0")
            {
                this.ddl_Body_Company.Items.FindByValue(_s[1]._Purchase.Body_Extra_Company.ToString()).Selected = true;
            }
            //Session["BodyClassList"] = _BodyClassList;



            if (_s[1]._Purchase._Insurance1._Insurane.ID.ToString() != "0" && _s[1]._Purchase._Insurance1._Insurane.ID.ToString() != string.Empty)
            {
                this.Cb_Insurance1.Checked = true;
                this.DD_Insurance.SelectedValue = _s[1]._Purchase._Insurance1._Insurane.ID.ToString();
                if (_s[1]._Purchase._Insurance1.Outlay != 0)
                {
                    this.Txt_InOutlay.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase._Insurance1.Outlay.ToString()));
                }
                else
                {
                    this.Txt_InOutlay.Text = "0";
                }
                
                if (_s[1]._Purchase._Insurance1.Price != 0)
                {
                    this.Txt_InPrice.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase._Insurance1.Price.ToString()));
                }
                else
                {
                    this.Txt_InPrice.Text = "0";
                }
                
                if (_s[1]._Purchase._Insurance1.Free.ToString() == "Y")
                {
                    this.Cb_InFree.Checked = true;
                }
            }

            if (_s[1]._Purchase._Regis.ID.ToString() != "0" && _s[1]._Purchase._Regis.ID.ToString() != string.Empty)
            {
                this.Cb_Regis.Checked = true;
                this.DD_Regis.SelectedValue = _s[1]._Purchase._Regis.Name.ToString();
                if (_s[1]._Purchase._Regis.Price != 0)
                {
                    this.Txt_RegisPrice.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase._Regis.Price.ToString()));
                }
                else
                {
                    this.Txt_RegisPrice.Text = "0";
                }
                
                if (_s[1]._Purchase._Regis.Free.ToString() == "Y")
                {
                    this.Cb_RegisFree.Checked = true;
                }
            }

            if (_s[1]._Purchase._Act.ID.ToString() != "0" && _s[1]._Purchase._Act.ID.ToString() != string.Empty)
            {
                this.Cb_Act.Checked = true;
                this.Txt_ActNo.Text = _s[1]._Purchase._Act.ActNo.ToString();
                if (_s[1]._Purchase._Act.Price != 0)
                {
                    this.Txt_ActPrice.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase._Act.Price.ToString()));
                }
                else
                {
                    this.Txt_ActPrice.Text = "0";
                }
                
                if (_s[1]._Purchase._Act.Free.ToString() == "Y")
                {
                    this.Cb_ActFree.Checked = true;
                }
            }

            if (_s[1]._Purchase._Transpot.ID.ToString() != "0" && _s[1]._Purchase._Transpot.ID.ToString() != string.Empty)
            {
                this.Cb_Transpot.Checked = true;
                if (_s[1]._Purchase._Transpot.Price != 0)
                {
                    this.Txt_TranspotPrice.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase._Transpot.Price.ToString()));
                }
                else
                {
                    this.Txt_TranspotPrice.Text = "0";
                }
                
                if (_s[1]._Purchase._Transpot.Free.ToString() == "Y")
                {
                    this.Cb_TranspotFree.Checked = true;
                }
            }

            if (_s[1]._Purchase._SetAcc.ID.ToString() != "0" && _s[1]._Purchase._SetAcc.ID.ToString() != string.Empty)
            {
                this.Cb_SetAcc.Checked = true;
                if (_s[1]._Purchase._SetAcc.Price != 0)
                {
                    this.Txt_SetAccPrice.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase._SetAcc.Price.ToString()));
                } 
                if (_s[1]._Purchase._SetAcc.Free.ToString() == "Y")
                {
                    this.Cb_SetAccFree.Checked = true;
                }

                _SPurchaseList _SSetAcc = new _SPurchaseList();
                _SSetAcc.SELECT_EPurchase(2, int.Parse(_POID));
                if (_SSetAcc.Count > 0)
                {
                    Session.Add("SetAccList", _SSetAcc[1]._Purchase._SetAccList);
                    this.gv_SetAccessories.DataSource = _SSetAcc[1]._Purchase._SetAccList.Values;
                    this.gv_SetAccessories.DataBind(); 
                }
                
            }

            if (_s[1]._Purchase._SetAccSTD.ID.ToString() != "0" && _s[1]._Purchase._SetAccSTD.ID.ToString() != string.Empty)
            {
                this.Cb_AccSTD.Checked = true;
                if (_s[1]._Purchase._SetAccSTD.Price != 0)
                {
                    this.Txt_AccSTDPrice.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase._SetAccSTD.Price.ToString()));
                }
                if (_s[1]._Purchase._SetAccSTD.Free.ToString() == "Y")
                {
                    this.Cb_AccSTDFree.Checked = true;
                }

                _SPurchaseList _SSetAccSTD = new _SPurchaseList();
                _SSetAccSTD.SELECT_EPurchase(3, int.Parse(_POID));
                if (_SSetAccSTD.Count > 0)
                {
                    Session.Add("SetAccSTDList", _SSetAccSTD[1]._Purchase._SetAccSTDList);
                    this.gv_AccSTD.DataSource = _SSetAccSTD[1]._Purchase._SetAccSTDList.Values;
                    this.gv_AccSTD.DataBind();
                }
                
            }

            if (_s[1]._Purchase._AddAcc.ID.ToString() != "0" && _s[1]._Purchase._AddAcc.ID.ToString() != string.Empty)
            {
                if (_s[1]._Purchase._AddAcc.Price != 0)
                {
                    this.Lb_AdAccPrice.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase._AddAcc.Price.ToString()));
                }
                _SPurchaseList _SAdAcc = new _SPurchaseList();
                _SAdAcc.SELECT_EPurchase(4, int.Parse(_POID));
                if (_SAdAcc.Count > 0)
                {
                    Session.Add("AdAccList", _SAdAcc[1]._Purchase._SetAddAccList);
                    this.gv_AdAccessories.DataSource = _SAdAcc[1]._Purchase._SetAddAccList.Values;
                    this.gv_AdAccessories.DataBind();
                }
                
            }

            _SPurchaseList _SDc = new _SPurchaseList();
            _SDc.SELECT_EPurchase(5, int.Parse(_POID));
            if (_SDc.Count > 0)
            {
                Session.Add("DcList", _SDc[1]._Purchase._DcList);
                this.gv_Discount.DataSource = _SDc[1]._Purchase._DcList.Values;
                this.gv_Discount.DataBind();
            }
            

           
            _SPurchaseList _BodyOption = new _SPurchaseList();
            _BodyOption.SELECT_EPurchase(6, int.Parse(_POID));
            if (_BodyOption.Count > 0)
            {
                Session.Add("BodyOption", _BodyOption[1]._Purchase._SetBodyOptionList);
                this.gv_bodyshow.DataSource = _BodyOption[1]._Purchase._SetBodyOptionList.Values;
                this.gv_bodyshow.DataBind();                
            }
            else
            {
                this.AddEmptyData_BodyOption();
            }

            _SPurchaseList _BodyOptionExtra = new _SPurchaseList();
            _BodyOptionExtra.SELECT_EPurchase(7, int.Parse(_POID));
            if (_BodyOptionExtra.Count > 0)
            {
                Session.Add("BodyExtra", _BodyOptionExtra[1]._Purchase._SetBodyOptionExtraList);
                this.gv_bodyextra.DataSource = _BodyOptionExtra[1]._Purchase._SetBodyOptionExtraList.Values;
                this.gv_bodyextra.DataBind();
            }
            else
            {
                this.AddEmptyData_BodyOptionExtra();
            }
            //---------------------------------
            if (_s[1]._Purchase.Body_Type == "S")
            {
                this.Rb_bodystandard.Checked = true;
                Panelbodystandard.Visible = true;
                Panelbodyextra.Visible = false;
                Panelgvbodystandard.Visible = true;
                Panelgvbodyextra.Visible = false;
            }
            else if (_s[1]._Purchase.Body_Type == "E")
            {
                this.Rb_bodyextra.Checked = true;
                Panelbodystandard.Visible = false;
                Panelbodyextra.Visible = true;
                Panelgvbodystandard.Visible = false;
                Panelgvbodyextra.Visible = true;

                this.txt_bodyextra.Text = _s[1]._Purchase.CarPriceAd.ToString();

                if (_s[1]._Purchase.CarPriceAd_Price != 0)
                {
                    this.Txt_bodyextraPrice.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.CarPriceAd_Price.ToString()));
                }
                else
                {
                    this.Txt_bodyextraPrice.Text = "0";
                }

                //-------------------
                if (_s[1]._Purchase.Body_Price_finance != 0)
                {
                    this.lblsumfin.Text = string.Format("{0:#,###.##}", decimal.Parse(_s[1]._Purchase.Body_Price_finance.ToString()));
                }
                else
                {
                    this.lblsumfin.Text = "0";
                }
            }
            else
            {
                Panelbodystandard.Visible = false;
                Panelbodyextra.Visible = false;
                Panelgvbodystandard.Visible = false;
                Panelgvbodyextra.Visible = false;
            }

            

            if (_s[1]._Purchase.Body_Price_Pay != 0)
            {
                this.Lb_Budgetpaybody.Text = string.Format("{0:#,###.##}", decimal.Parse(_s[1]._Purchase.Body_Price_Pay.ToString()));
            }
            else
            {
                this.Lb_Budgetpaybody.Text = "0";
            }

            if (_s[1]._Purchase.Body_Price_SumAddBody != 0)
            {
                this.Lb_sumAddfinance.Text = string.Format("{0:#,###.##}", decimal.Parse(_s[1]._Purchase.Body_Price_SumAddBody.ToString()));
            }
            else
            {
                this.Lb_sumAddfinance.Text = "0";
            }



            //-----------------------------------------------------------

            if (_s[1]._Purchase.PriceSumCar != 0)
            {
                this.Txt_EditAcc_PriceSumCar.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.PriceSumCar.ToString()));
            }
            else
            {
                this.Txt_EditAcc_PriceSumCar.Text = "0";
            }

            if (_s[1]._Purchase.PriceSum != 0)
            {
                this.Txt_EditAcc_PriceSum.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.PriceSum.ToString()));
            }
            else
            {
                this.Txt_EditAcc_PriceSum.Text = "0";
            }
            

            #endregion

            #region ไฟแนนซ์
            _FinanceList _Fn = new _FinanceList();
            _Fn.Select(1);
            this.DD_Finance.DataSource = _Fn.Values;
            this.DD_Finance.DataTextField = "Name";
            this.DD_Finance.DataValueField = "ID";
            this.DD_Finance.DataBind();
            this.DD_Finance.Items.Insert(0, "-- เลือก --");
            this.DD_Finance.SelectedIndex = 0;

            this.DD_Finance.SelectedValue = _s[1]._Purchase._Finance.ID.ToString();
            this.Txt_EmpFinance.Text = _s[1]._Purchase.Emp_Finance.ToString().Trim();
            this.Txt_CarPrice1.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.CarPrice.ToString()));
            this.Txt_CarPriceAd.Text = _s[1]._Purchase.CarPriceAd.ToString().Trim();
            if (_s[1]._Purchase.CarPriceAd_Price != 0)
            {
                this.Txt_CarPriceAd_Price.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.CarPriceAd_Price.ToString()));
            }
            else
            {
                this.Txt_CarPriceAd_Price.Text = "0";
            }
            if (_s[1]._Purchase.PayDown != 0)
            {
                this.Txt_PayDown.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.PayDown.ToString()));
            }
            else
            {
                this.Txt_PayDown.Text = "0";
            }
            if (_s[1]._Purchase.DPeak != 0)
            {
                this.Txt_DPeak.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.DPeak.ToString()));
            }
            else
            {
                this.Txt_DPeak.Text = "0";
            }
            if (_s[1]._Purchase.LoanProtection != 0)
            {
                this.Txt_LoanProtection.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.LoanProtection.ToString()));
            }
            else
            {
                this.Txt_LoanProtection.Text = "0";
            }
            if (_s[1]._Purchase.hpcost != 0)
            {
                this.Txt_hpcost.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.hpcost.ToString()));
            }
            else
            {
                this.Txt_hpcost.Text = "0";
            }
            if (_s[1]._Purchase.Interest != 0)
            {
                this.Txt_Interest.Text = decimal.Parse(_s[1]._Purchase.Interest.ToString()).ToString();
            }
            else
            {
                this.Txt_Interest.Text = "0";
            }
            this.Txt_RemarkInterest.Text = _s[1]._Purchase.Remark_Interest.ToString().Trim();
            if (_s[1]._Purchase.Total_Payment.ToString() != "0")
            {
                this.DD_Total_Payment.SelectedValue = _s[1]._Purchase.Total_Payment.ToString();
            }
            else
            {
                this.DD_Total_Payment.SelectedIndex = 0;
            }
            if (_s[1]._Purchase.Price_Payment != 0)
            {
                this.Txt_Price_Payment.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.Price_Payment.ToString()));
            }
            else
            {
                this.Txt_Price_Payment.Text = "0";
            }
            if (_s[1]._Purchase.Pay_Begin != 0)
            {
                this.Cb_Begin.Checked = true;
                this.Txt_Pay_Begin.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.Pay_Begin.ToString()));
            }
            else
            {
                this.Cb_Begin.Checked = false;
                this.Txt_Pay_Begin.Text = "1";
            }
            this.Txt_DepositNo.Text = _s[1]._Purchase.DepositNo.ToString().Trim();
            DateTime _DepositDate = _s[1]._Purchase.DepositDate;
            if (_DepositDate.ToString() != "1/1/0544 0:00:00")
            {
                this.Txt_DepositDate.Text = _s[1]._Purchase.DepositDate.ToString("dd MMM yy");
            }
            else
            {
                this.Txt_DepositDate.Text = string.Empty;
            }
            if (_s[1]._Purchase.DepositPrice != 0)
            {
                this.Txt_DepositPrice.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.DepositPrice.ToString()));
            }
            else
            {
                this.Txt_DepositPrice.Text = "0";
            }

            this.Txt_DepositAdNo.Text = _s[1]._Purchase.DepositAdNo.ToString().Trim();
            DateTime _DepositAdDate = _s[1]._Purchase.DepositAdDate;
            if (_DepositAdDate.ToString() != "1/1/0544 0:00:00")
            {
                this.Txt_DepositAdDate.Text = _s[1]._Purchase.DepositAdDate.ToString("dd MMM yy");
            }
            else
            {
                this.Txt_DepositAdDate.Text = string.Empty;
            }
            if (_s[1]._Purchase.DepositAdPrice != 0)
            {
                this.Txt_DepositAdPrice.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.DepositAdPrice.ToString()));
            }
            else
            {
                this.Txt_DepositAdPrice.Text = string.Empty;
            }

            this.Txt_RedCarPlate_No.Text = _s[1]._Purchase.RedCarPlate_No.ToString().Trim();
            DateTime _RedCarPlate_Date = _s[1]._Purchase.RedCarPlate_Date;
            if (_RedCarPlate_Date.ToString() != "1/1/0544 0:00:00")
            {
                this.Txt_RedCarPlate_Date.Text = _s[1]._Purchase.RedCarPlate_Date.ToString("dd MMM yy");
            }
            else
            {
                this.Txt_RedCarPlate_Date.Text = string.Empty;
            }
            if (_s[1]._Purchase.RedCarPlate_Price != 0)
            {
                this.Txt_RedCarPlate_Price.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.RedCarPlate_Price.ToString()));
            }
            else
            {
                this.Txt_RedCarPlate_Price.Text = "0";
            }
            this.Txt_RedCarPlate_Num.Text = _s[1]._Purchase.RedCarPlate_Num.ToString().Trim();
            if (_s[1]._Purchase.PriceSumCar != 0)
            {
                this.Txt_PriceSumCar.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.PriceSumCar.ToString()));
            }
            else
            {
                this.Txt_PriceSumCar.Text = "0";
            }
            if (_s[1]._Purchase.PriceSum != 0)
            {
                this.Txt_PriceSum.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.PriceSum.ToString()));
            }
            else
            {
                this.Txt_PriceSum.Text = "0";
            }

            this.Txt_PayCash_No.Text = _s[1]._Purchase.PayCash_No.ToString();
            DateTime _PayCash_Date = _s[1]._Purchase.PayCash_Date;
            if (_PayCash_Date.ToString() != "1/1/0544 0:00:00")
            {
                this.Txt_PayCash_Date.Text = _s[1]._Purchase.PayCash_Date.ToString("dd MMM yy");
            }
            else
            {
                this.Txt_PayCash_Date.Text = string.Empty;
            }
            if (_s[1]._Purchase.PayCase_Price != 0)
            {
                this.Txt_PayCash_Price.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.PayCase_Price.ToString()));
            }
            else
            {
                this.Txt_PayCash_Price.Text = string.Empty;
            }

            if (_s[1]._Purchase.PayTM != 0)
            {
                this.DD_PayTM_Bank.SelectedValue = _s[1]._Purchase.PayTM.ToString();
            }
            else
            {
                this.DD_PayTM_Bank.SelectedIndex = 0;
            }
            this.Txt_PayTM_No.Text = _s[1]._Purchase.PayTM_No.ToString();
            DateTime _PayTM_Date = _s[1]._Purchase.PayTM_Date;
            if (_PayTM_Date.ToString() != "1/1/0544 0:00:00")
            {
                this.Txt_PayTM_Date.Text = _s[1]._Purchase.PayTM_Date.ToString("dd MMM yy");
            }
            else
            {
                this.Txt_PayTM_Date.Text = string.Empty;
            }
            if (_s[1]._Purchase.PayTM_Price != 0)
            {
                this.Txt_PayTM_Price.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.PayTM_Price.ToString()));
            }
            else
            {
                this.Txt_PayTM_Price.Text = string.Empty;
            }


            if (_s[1]._Purchase.PayCheque != 0)
            {
                this.DD_PayCheque_Bank.SelectedValue = _s[1]._Purchase.PayCheque.ToString();
            }
            else
            {
                this.DD_PayCheque_Bank.SelectedIndex = 0;
            }
            this.Txt_PayCheque_No.Text = _s[1]._Purchase.PayCheque_No.ToString();
            DateTime _PayCheque_Date = _s[1]._Purchase.PayCheque_Date;
            if (_PayCheque_Date.ToString() != "1/1/0544 0:00:00")
            {
                this.Txt_PayCheque_Date.Text = _s[1]._Purchase.PayCheque_Date.ToString("dd MMM yy");
            }
            else
            {
                this.Txt_PayCheque_Date.Text = string.Empty;
            }
            if (_s[1]._Purchase.PayCheque_Price != 0)
            {
                this.Txt_PayCheque_Price.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.PayCheque_Price.ToString()));
            }
            else
            {
                this.Txt_PayCheque_Price.Text = string.Empty;
            }
            if (_s[1]._Purchase.RepayToCus != 0)
            {
                this.Txt_RepayToCus.Text = string.Format("{0:#,###}", decimal.Parse(_s[1]._Purchase.RepayToCus.ToString()));
            }
            else
            {
                this.Txt_RepayToCus.Text = "0";
            }

            this.Txt_Remark.Text = _s[1]._Purchase.Remark.ToString().Trim();
            if (_s[1]._Purchase.C_IDCard.ToString() == "Y")
            {
                this.Cb_C_IDCard.Checked = true;
            }
            if (_s[1]._Purchase.C_HouseRegistration.ToString() == "Y")
            {
                this.Cb_C_HouseRegistration.Checked = true;
            }
            if (_s[1]._Purchase.C_Scrape.ToString() == "Y")
            {
                this.Cb_C_Scrape.Checked = true;
            }
            if (_s[1]._Purchase.C_Finance.ToString() == "Y")
            {
                this.Cb_C_Finance.Checked = true;
            }
            if (_s[1]._Purchase.C_ActInsurance.ToString() == "Y")
            {
                this.Cb_C_ActInsurance.Checked = true;
            }
            if (_s[1]._Purchase.C_CVIP.ToString() == "Y")
            {
                this.Cb_C_CVIP.Checked = true;
            }

            
            #endregion

            _Purchase _ChkCVIP = new _Purchase();
            DataTable _dtCVIP = new DataTable();
            _dtCVIP = _ChkCVIP.Select_Purchase(5, _s[1]._Purchase.MCNumber.ToString());
            if (_dtCVIP.Rows.Count == 0)
            {
                this.Lbtn_CVIP.Visible = true;
            }
            else
            {
                this.Lbtn_CVIP.Visible = false;
            }

            this.Panel_SMCNumber.Visible = false;
            this.Panel1.Visible = false;
            this.Panel_PopupEditPO.Visible = true; 
        }

        protected void Img_ViewStatus_Click(object sender, ImageClickEventArgs e)
        {
            this.ModalPopupExtender1.Show();
            
            _SPurchaseList _s = new _SPurchaseList();
            _InvoiceList _invoice = new _InvoiceList();
            _InvoiceList._Invoice invoices = new _InvoiceList._Invoice();
            _AddressList _AddList = new _AddressList();
            RedCarPlate _redcarplate = new RedCarPlate();
            _CarTypeList carlist = new _CarTypeList();
            _CarTypeList._CarType cartype = new _CarTypeList._CarType();
           
            ImageButton bt = (ImageButton)sender;
            GridViewRow gv = (GridViewRow)bt.NamingContainer;
            string _POID = ((Label)gv_PO.Rows[gv.RowIndex].FindControl("LBID")).Text;

            
            _s.SELECT_EPurchase(1, int.Parse(_POID));
            //_invoice.selectInvoice(int.Parse(_POID));
            invoices.selectInvoice(int.Parse(_POID));
            _redcarplate.SelectRedCarPlate(int.Parse(_POID));

            this.outcardate_Txt.Text = _s[1]._Purchase.OutCar_Date.ToString("dd MMM yy");
            this.usernumber_Txt.Text = _s[1]._Customer.IDCard.ToString();
            this.sales_Txt.Text = _s[1].Tb_User.FullName.ToString();
            this.name_Txt.Text = _s[1]._Customer.Name.ToString();
            this.lastname_Txt.Text = _s[1]._Customer.Surname.ToString();
            this.tel_Txt.Text = _s[1]._Customer.Tel_Mobile1.ToString();
            this.linrid_Txt.Text = _s[1]._Customer.LineID.ToString();
            this.jobs_Txt.Text = _s[1]._Customer.Career_Remark.ToString();
            //this.address_Txt.Text = _s[1]._Purchase._Customer.SendAddress.ToString();

            this.carname_Txt.Text = _s[1]._Purchase.CarName.ToString();
            this.buytype_Txt.Text = _s[1]._Purchase.Buy_Type.ToString();
            this.mcnumber_Txt.Text = _s[1]._Purchase.MCNumber.ToString();
            this.trucknumber_Txt.Text = _s[1]._Purchase.TruckNumber.ToString();
            this.mcode_Txt.Text = _s[1]._Purchase.MCode.ToString();
            this.mname_Txt.Text = _s[1]._Purchase.MName.ToString();
            this.carprice_Txt.Text = string.Format("{0:#,###.00}", decimal.Parse(_s[1]._Purchase.CarPrice.ToString()));
            this.carplate_Txt.Text = _s[1]._Purchase.CarPlate.ToString() == string.Empty || _s[1]._Purchase.CarPlate.ToString() == "" ? "-" : _s[1]._Purchase.CarPlate.ToString();
            this.regisdate_Txt.Text = _s[1]._Purchase.Regis_Date.ToString("dd MMM yy") == "01 ม.ค. 44" ? "-" : _s[1]._Purchase.Regis_Date.ToString("dd MMM yy");
            this.carcolor_Txt.Text = _s[1]._Purchase.CName.ToString();
            this.cartax_Txt.Text = _s[1]._Purchase.CarTax.ToString() == string.Empty || _s[1]._Purchase.CarTax.ToString() == "" ? "-" : string.Format("{0:#,###}", Convert.ToDecimal(_s[1]._Purchase.CarTax.ToString()));

            int type = int.Parse(_s[1]._Purchase._CarType.ID.ToString());
            carlist.Select_CarType2(type);
            try
            {
                var item = carlist.TypeCar.Rows[0];
                this.cartype_Txt.Text = item["Name"].ToString();
                this.cartype_Txt.ForeColor = Color.Green;
            }
            catch
            {
                this.cartype_Txt.Text = "-";
                this.cartype_Txt.ForeColor = Color.Orange;
            }

       
            this.remark_Txt.Text = _s[1]._Purchase.Remark.ToString();
            this.redplateDate_Txt.Text =  _redcarplate.RedCarPlate_DATE.ToString("dd MMM yy") == "01 ม.ค. 44" ? "-" : _redcarplate.RedCarPlate_DATE.ToString("dd MMM yy");
            this.redplateNo_Txt.Text = _redcarplate.RedCarPlate_NO.ToString() == string.Empty ? "-" : _redcarplate.RedCarPlate_NO.ToString();
            this.redplatePrice_Txt.Text = _redcarplate.RedCarPlate_PRICE == 0 ? "-" : string.Format("{0:#,###.00}", decimal.Parse(_redcarplate.RedCarPlate_PRICE.ToString()));
            this.redplateNum_Txt.Text = _redcarplate.RedCarPlate_NUM.ToString() == string.Empty ? "-" : _redcarplate.RedCarPlate_NUM.ToString();

            try
            {
                    if (invoices._GetBadge_Date != DateTime.MinValue)
                    {
                        this.invoice_Txt.ForeColor = invoices._Invoice_Date == DateTime.MinValue ? Color.Orange : Color.Green;
                        this.getinvoice_Txt.ForeColor = invoices._GetInvoice_Date == DateTime.MinValue ? Color.Orange : Color.Green;
                        this.transport_Txt.ForeColor = invoices._Transport_Date == DateTime.MinValue ? Color.Orange : Color.Green;
                        this.guide_Txt.ForeColor = invoices._GetGuide == DateTime.MinValue ? Color.Orange :Color.Green;
                        this.badge_Txt.ForeColor = invoices._GetBadge_Date == DateTime.MinValue ? Color.Orange :Color.Green;
                        this.noteset_Txt.ForeColor = invoices._NoteSet_Date == DateTime.MinValue ? Color.Orange :Color.Green;
                        this.sendnoteset_Txt.ForeColor = invoices._GetNotSet_Date == DateTime.MinValue ? Color.Orange :Color.Green;
                        this.remarkinvoice_Txt.ForeColor = invoices._RemarkInvoice.ToString() == string.Empty ? Color.Orange : Color.Green;
                    }
                    this.invoice_Txt.Text = invoices._Invoice_Date == DateTime.MinValue ? "-" : invoices._Invoice_Date.ToString("dd MMM yy");
                    this.getinvoice_Txt.Text = invoices._GetInvoice_Date == DateTime.MinValue ? "-" : invoices._GetInvoice_Date.ToString("dd MMM yy");
                    this.transport_Txt.Text = invoices._Transport_Date == DateTime.MinValue ? "-" : invoices._Transport_Date.ToString("dd MMM yy");
                    this.guide_Txt.Text = invoices._GetGuide == DateTime.MinValue ? "-" : invoices._GetGuide.ToString("dd MMM yy");
                    this.badge_Txt.Text = invoices._GetBadge_Date == DateTime.MinValue ? "-" : invoices._GetBadge_Date.ToString("dd MMM yy");
                    this.noteset_Txt.Text = invoices._NoteSet_Date == DateTime.MinValue ? "-" : invoices._NoteSet_Date.ToString("dd MMM yy");
                    this.sendnoteset_Txt.Text = invoices._GetNotSet_Date == DateTime.MinValue ? "-" : invoices._GetNotSet_Date.ToString("dd MMM yy");
                    this.remarkinvoice_Txt.Text = invoices._RemarkInvoice.ToString() == string.Empty || invoices._RemarkInvoice.ToString() == "1900-01-01" ? "-" : invoices._RemarkInvoice.ToString();

                    this.regisdate_Txt.ForeColor = _s[1]._Purchase.Regis_Date.ToString("dd MMM yy") == "01 ม.ค. 44" ? Color.Orange : Color.Green;
                    this.carplate_Txt.ForeColor = _s[1]._Purchase.CarPlate.ToString() == string.Empty ? Color.Orange : Color.Green;
                    this.cartax_Txt.ForeColor = _s[1]._Purchase.CarTax.ToString() == string.Empty ? Color.Orange : Color.Green;

            }
            catch
            {
                this.invoiceTxtNull();
            }           
        }

        private void invoiceTxtNull()
        {
            this.invoice_Txt.Text = "-";
            this.getinvoice_Txt.Text = "-";
            this.transport_Txt.Text = "-";
            this.guide_Txt.Text = "-";
            this.badge_Txt.Text = "-";
            this.noteset_Txt.Text = "-";
            this.sendnoteset_Txt.Text = "-";
            this.remarkinvoice_Txt.Text = "-";

            this.invoice_Txt.ForeColor = Color.Red;
            this.getinvoice_Txt.ForeColor = Color.Red;
            this.transport_Txt.ForeColor = Color.Red;
            this.guide_Txt.ForeColor = Color.Red;
            this.badge_Txt.ForeColor = Color.Red;
            this.noteset_Txt.ForeColor = Color.Red;
            this.sendnoteset_Txt.ForeColor = Color.Red;
            this.remarkinvoice_Txt.ForeColor = Color.Red;
        }

        private void Edit_StringEmpty()
        {
            this.CusData_Click();
            this.Panel_CarData.Visible = false;
            #region หัว
            this.Lb_EPOID.Text = string.Empty;
            this.Lb_PurchaseNo.Text = string.Empty;
            this.Txt_PoNum.Text = string.Empty;
            this.Txt_PoNum.Enabled = false;
            this.Panel_EditPoNum.Visible = true;
            this.Panel_SavePoNum.Visible = false;
            this.Rb_ECompany.Enabled = false;
            this.Panel_EditCompany.Visible = true;
            this.Panel_SaveCompany.Visible = false;
            #endregion

            #region ข้อมูลลูกค้า
            this.Txt_EDate.Text = string.Empty;
            this.Txt_EDate.Enabled = false;
            this.Panel_EditOutCar_Date.Visible = true;
            this.Panel_SaveOutCar_Date.Visible = false;
            this.Img_EDate.Visible = false;

            this.Txt_ECusID.Text = string.Empty;
            this.Txt_ECusNo.Text = string.Empty;
            this.Txt_ESaleName.Text = string.Empty;
            this.Txt_EIDCard.Text = string.Empty;
            this.Txt_EPrefix.Text = string.Empty;
            this.Txt_EName.Text = string.Empty;
            this.Txt_ESurname.Text = string.Empty;
            this.Txt_ENickname.Text = string.Empty;
            this.Txt_ENickname.Enabled = false;
            this.Txt_EBirthday.Text = string.Empty;
            this.Txt_EBirthday.Enabled = false;
            this.Img_EBirthday.Visible = false;
            this.DD_EEducation.SelectedIndex = 0;
            this.DD_EEducation.Enabled = false;
            this.Txt_ETotal_Member.Text = string.Empty;
            this.Txt_ETotal_Member.Enabled = false;
            this.Panel_EditName.Visible = true;
            this.Panel_SaveName.Visible = false;

            this.Txt_ECorporationCode.Text = string.Empty;
            this.Txt_ECompanyName.Text = string.Empty;

            this.Txt_ETelMobile1.Text = string.Empty;
            this.Txt_ETelMobile1.Enabled = false;
            this.Txt_ETelMobile2.Text = string.Empty;
            this.Txt_ETelMobile2.Enabled = false;
            this.Txt_ETelHome_Work.Text = string.Empty;
            this.Txt_ETelHome_Work.Enabled = false;
            this.Txt_EFax.Text = string.Empty;
            this.Txt_EFax.Enabled = false;
            this.Txt_ElineID.Text = string.Empty;
            this.Txt_ElineID.Enabled = false;
            this.Panel_EditTel.Visible = true;
            this.Panel_SaveTel.Visible = false;
            this.Panel_ConfirmTelErr.Visible = false;

            this.DD_ECareer.SelectedIndex = 0;
            this.DD_ECareer.Enabled = false;
            this.Txt_ECareer_Other.Text = string.Empty;
            this.DD_ECareer.Enabled = false;
            this.Txt_ECareer_Remark.Text = string.Empty;
            this.Txt_ECareer_Remark.Enabled = false;
            this.DD_EInCome.SelectedIndex = 0;
            this.DD_EInCome.Enabled = false;
            this.Panel_EditCareer.Visible = true;
            this.Panel_SaveCareer.Visible = false;
            this.Panel_ConfirmCareerErr.Visible = false;

            this.gv_EAddress.DataSource = null;
            this.gv_EAddress.DataBind();
            Session["AddList"] = null;

            this.Cb_ESendAddress.Enabled = false;
            this.Cb_ESendAddress_New.Enabled = false;
            this.gv_ESentAddress.DataSource = null;
            this.gv_ESentAddress.DataBind();
            this.gv_ESentAddress.Columns[9].Visible = false;
            Session["SentAddList"] = null;
            this.Panel_EditSendAdd.Visible = true;
            this.Panel_SaveSendAdd.Visible = false;
            this.Panel_ConfirmSendAddErr.Visible = false;
            #endregion

            #region ข้อมูลรถ
            this.Txt_ECarName.Text = string.Empty;
            this.Txt_EMCNumber.Text = string.Empty;
            this.Txt_ETruckNumber.Text = string.Empty;
            this.Txt_EMName.Text = string.Empty;
            this.Txt_EMSaleCode.Text = string.Empty;
            this.Txt_ECName.Text = string.Empty;
            this.Txt_ECarPrice.Text = string.Empty;
            this.Txt_ECarPlate.Text = string.Empty;
            this.Txt_ECarPlate.Enabled = false;
            this.Txt_RegisDate.Text = string.Empty;
            this.Txt_RegisDate.Enabled = false;
            this.Img_RegisDate.Visible = false;
            this.Txt_CarTax.Text = string.Empty;
            this.Txt_CarTax.Enabled = false;
            this.DD_EBuyType.Enabled = false;
            this.DD_ECarType.Enabled = false;
            this.Panel_EditBuyType.Visible = true;
            this.Panel_SaveBuyType.Visible = false;

            this.Cb_ECE_N.Enabled = false;
            this.Cb_ECE_Y.Enabled = false;
            this.Txt_ECEMCNumber.Text = string.Empty;
            this.Txt_ECETruckNumber.Text = string.Empty;
            this.Txt_ECEBrand.Text = string.Empty;
            this.Txt_ECEModel.Text = string.Empty;
            this.Txt_ECEColor.Text = string.Empty;
            this.Txt_ECEYear.Text = string.Empty;
            this.Txt_ECECarPlate.Text = string.Empty;
            this.Txt_ECEPrice.Text = string.Empty;
            this.Txt_ECEEmp.Text = string.Empty;
            this.Txt_ECEMCNumber.Enabled = false;
            this.Txt_ECETruckNumber.Enabled = false;
            this.Txt_ECEBrand.Enabled = false;
            this.Txt_ECEModel.Enabled = false;
            this.Txt_ECEColor.Enabled = false;
            this.Txt_ECEYear.Enabled = false;
            this.Txt_ECECarPlate.Enabled = false;
            this.Txt_ECEPrice.Enabled = false;
            this.Txt_ECEEmp.Enabled = false;
            this.Panel_EditCE.Visible = true;
            this.Panel_SaveCE.Visible = false;
            this.Panel_ConfirmCEErr.Visible = false;
            #endregion

            #region อุปกรณ์ตกแต่ง
            Session["SetAccList"] = null;
            Session["SetAccSTDList"] = null;
            Session["AdAccList"] = null;
            Session["DcList"] = null;
            foreach (Control item in this.Panel_Accessories.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)(item)).Text = string.Empty;
                    ((TextBox)(item)).Enabled = false; 
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)(item)).Enabled = false;
                    ((CheckBox)(item)).Checked = false;
                }
                else if (item is DropDownList)
                {
                    ((DropDownList)(item)).Enabled = false;
                }
            }
            this.Lb_AdAccPrice.Text = "0";
            this.Lb_PriceDiscount.Text = "0";
            this.Panel_SetAccErr.Visible = false;
            this.Panel_SetAccSTDErr.Visible = false;
            this.Panel_AdAccErr.Visible = false;
            this.Panel_DiscountErr.Visible = false;
            this.AddEmptyData_SetAcc();
            this._SetAccList = new _Accessorieslist();
            this.AddEmptyData_SetAccSTD();
            this.AddEmptyData_AdAcc();
            this.AddEmptyData_Dc();
            this.gv_SetAccessories.Columns[2].Visible = false;
            this.gv_SetAccessories.ShowFooter = false;
            this.gv_AccSTD.Columns[2].Visible = false;
            this.gv_AccSTD.ShowFooter = false;
            this.gv_AdAccessories.Columns[4].Visible = false;
            this.gv_AdAccessories.ShowFooter = false;
            this.gv_Discount.Columns[3].Visible = false;
            this.gv_Discount.ShowFooter = false;
            this.Panel_EditAcc.Visible = true;
            this.Panel_SaveAcc.Visible = false;
            this.Panel_ConfirmAccErr.Visible = false;
            this.gv_bodyshow.Columns[3].Visible = false;
            this.gv_bodyshow.ShowFooter = false;
            this.gv_bodyextra.Columns[3].Visible = false;
            this.gv_bodyextra.ShowFooter = false;
            #endregion

            #region ไฟแนนซ์
            foreach (Control item in this.Panel_Finance.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)(item)).Text = string.Empty;
                    ((TextBox)(item)).Enabled = false;
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)(item)).Enabled = false;
                    ((CheckBox)(item)).Checked = false;
                }
                else if (item is DropDownList)
                {
                    ((DropDownList)(item)).Enabled = false;
                }
            }
            
            this.Img_DepositDate.Visible = false;
            this.Img_DepositAdDate.Visible = false;
            this.Img_RedCarPlate_Date.Visible = false;
            this.Img_CalSum.Visible = false;
            this.Img_Cal.Visible = false;
            this.Panel_EditFinance.Visible = true;
            this.Panel_SaveFinance.Visible = false;
            this.Panel_ConfirmFinanceErr.Visible = false;

            this.Panel_EditRemark.Visible = true;
            this.Panel_SaveRemark.Visible = false;
            this.Panel_confirmRemarkErr.Visible = false;

            this.Panel_EditC.Visible = true;
            this.Panel_SaveC.Visible = false;
            this.Panel_ConfirmCErr.Visible = false;

            this.Panel_EditPayCus.Visible = true;
            this.Panel_SavePayCus.Visible = false;
            this.Panel_confirmPayCusErr.Visible = false;
            #endregion
        }

        public void ShowNoResultFound(DataTable source, GridView gv)
        {
            source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable
            // Bind the DataTable which contain a blank row to the GridView
            gv.DataSource = source;
            gv.DataBind();
            // Get the total number of columns in the GridView to know what the Column Span should be
            int columnsCount = gv.Columns.Count;
            gv.Rows[0].Cells.Clear();// clear all the cells in the row
            gv.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
            gv.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

            //You can set the styles here
            gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            gv.Rows[0].Cells[0].Font.Bold = true;
            //set No Results found to the new added cell
            gv.Rows[0].Cells[0].Text = "ไม่มีข้อมูลในรายการ!";
        }

        protected void Img_EditCompany_Click(object sender, ImageClickEventArgs e)
        {
            this.Rb_ECompany.Enabled = true;
            this.Panel_EditCompany.Visible = false;
            this.Panel_SaveCompany.Visible = true;
             
        }

        protected void Img_CancelCompany_Click(object sender, ImageClickEventArgs e)
        {
            this.Rb_ECompany.Enabled = false;
            this.Panel_EditCompany.Visible = true;
            this.Panel_SaveCompany.Visible = false;
             
        }

        protected void Img_SaveCompany_Click(object sender, ImageClickEventArgs e)
        {
            _Purchase _p = new _Purchase();
            _p.ID = int.Parse(this.Lb_EPOID.Text);
            _p.ChkP = "Y";
            _p._Company.Companycode = this.Rb_ECompany.SelectedValue;
            _p.User_Edit = (int)Session["Emp_id"];
            try
            {
                _p.UPDATE_Purchase(1, _p);
            }
            catch (Exception err)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :')"+err.Message+";", true);
                //string script = "alert(\"ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :\");"+err.Message;
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                return;
            }
            this.Rb_ECompany.Enabled = false;
            this.Panel_EditCompany.Visible = true;
            this.Panel_SaveCompany.Visible = false;
             
        }

        protected void DD_ECusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DD_ECusType.SelectedValue == "บุคคล")
            {
                this.Panel_EPerson.Visible = true;
                this.Panel_ECompany.Visible = false;
            }
            else
            {
                this.Panel_EPerson.Visible = false;
                this.Panel_ECompany.Visible = true;
            }
             
        }

        protected void Txt_EIDCard_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_EIDCard.Text.Trim() == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ : กรุณาระบุเลขบัตรประชาชน!')", true);
                return;
            }
            else if (this.Txt_EIDCard.Text.Trim().Length != 13)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ : กรุณาระบุเลขบัตรประชาชนเป็นตัวเลข 13 หลักเท่านั้น!')", true);
                return;
            }
             
        }

        protected void Txt_EBirthday_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_EBirthday.Text.Trim() != string.Empty)
            {
                bool complete = false;
                DateTime _Birthday = DateTime.MinValue;
                complete = DateTime.TryParse(this.Txt_EBirthday.Text, out _Birthday);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันเกิด!');", true);
                }
                else
                {
                    this.Txt_EBirthday.Text = _Birthday.ToString("dd MMM yy");
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true); 
        }

        protected void Txt_ECorporationCode_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_ECorporationCode.Text.Trim() == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ : กรุณาระบุเลขนิติบุคคล!')", true);
                return;
            }
            else if (this.Txt_ECorporationCode.Text.Trim().Length != 13)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ : กรุณาระบุเลขนิติบุคคลเป็นตัวเลข 13 หลักเท่านั้น!')", true);
                return;
            }
             
        }

        protected void DD_ECareer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DD_ECareer.SelectedValue == "11")
            {
                this.Panel_ECareer_Other.Visible = true;
                this.Txt_ECareer_Other.Text = string.Empty;
            }
            else
            {
                this.Panel_ECareer_Other.Visible = false;
            }
             
        }

        protected void Img_EditOutCar_Date_Click(object sender, ImageClickEventArgs e)
        {
            this.Txt_EDate.Enabled = true;
            this.Img_EDate.Visible = true;
            this.Panel_EditOutCar_Date.Visible = false;
            this.Panel_SaveOutCar_Date.Visible = true;
             
        }

        protected void Img_CancelOutCar_Date_Click(object sender, ImageClickEventArgs e)
        {
            this.Txt_EDate.Enabled = false;
            this.Img_EDate.Visible = false;
            this.Panel_EditOutCar_Date.Visible = true;
            this.Panel_SaveOutCar_Date.Visible = false;
             
        }

        protected void Img_SaveOutCar_Date_Click(object sender, ImageClickEventArgs e)
        {
            _Purchase _p = new _Purchase();
            _p.ID = int.Parse(this.Lb_EPOID.Text);
            _p.ChkP = "Y";
            DateTime _EDate = DateTime.MinValue;
            DateTime.TryParse(this.Txt_EDate.Text, out _EDate);
            _p.OutCar_Date = _EDate;
            _p.PurchaseNo = this.GetPoNo();
            _p.User_Edit = (int)Session["Emp_id"];
            try
            {
                _p.UPDATE_Purchase(2, _p);
            }
            catch (Exception err)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :') "+err.Message+"", true);
                return;
            }
            this.Txt_EDate.Enabled = false;
            this.Img_EDate.Visible = false;
            this.Panel_EditOutCar_Date.Visible = true;
            this.Panel_SaveOutCar_Date.Visible = false;
             
        }

        private string GetPoNo()
        {
            string _PurchaseNo = string.Empty;
            DateTime _OutCarDate = DateTime.MinValue;
            DateTime.TryParse(this.Txt_EDate.Text, out _OutCarDate);
            string _c = string.Empty;
                DataTable _dtCB = (DataTable)Session["TeamCB"];
                string _company = _dtCB.Rows[0]["Company"].ToString();
                string _branch = _dtCB.Rows[0]["Branch"].ToString();
                _PurchaseNo = _company + _branch + "/PO" + _OutCarDate.ToString("yy") + _OutCarDate.ToString("MM");
                _c = _company + _branch;
            _Purchase _Po = new _Purchase();
            string _Month = _OutCarDate.ToString("MM");
            string _Year = _OutCarDate.ToString("yy");
            _Po.Select(1, _c, _Month, _Year);

            if (_Po.PurchaseNo == string.Empty)
            {
                _PurchaseNo += "001";
            }
            else
            {
                string _No = (_Po.PurchaseNo).Substring(9, 3);
                _No += Convert.ToInt32("9" + _No) + 1;
                _PurchaseNo += _No.Substring(4, 3);
                //DataTable _dt = new DataTable();
                //_dt = _Po.Select_MaxPurchaseNo(2, _c, _Month, _Year);
                //bool _chkNull = false;
                //for (int i = 1; i < Convert.ToInt32(_No); i++)
                //{
                //    _chkNull = false;
                //    for (int j = 0; j < _dt.Rows.Count; j++)
                //    {
                //        if (i == int.Parse(_dt.Rows[j]["PurchaseNo"].ToString().Substring(9, 3)))
                //        {
                //            _chkNull = true;
                //        }
                //    }

                //    if (_chkNull == false)
                //    {
                //        _PurchaseNo += string.Format("{0:000}", i);
                //        break;
                //    }
                //}

                //if (_chkNull == true)
                //{
                //    _No += Convert.ToInt32("9" + _No) + 1;
                //    _PurchaseNo += _No.Substring(4, 3);
                //}

            }
            return _PurchaseNo;
        }

        protected void Img_EditName_Click(object sender, ImageClickEventArgs e)
        {
            this.Txt_ENickname.Enabled = true;
            this.Txt_EBirthday.Enabled = true;
            this.Img_EBirthday.Visible = true;
            this.DD_EPerson_Sex.Enabled = true;
            this.DD_EEducation.Enabled = true;
            this.Txt_ETotal_Member.Enabled = true;
            this.Panel_EditName.Visible = false;
            this.Panel_SaveName.Visible = true;


            this.Txt_EIDCard.Enabled = true;
            this.Txt_EPrefix.Enabled = true;
            this.Txt_EName.Enabled = true;
            this.Txt_ESurname.Enabled = true;

             
        }

        protected void Img_CancelName_Click(object sender, ImageClickEventArgs e)
        {
            this.Txt_ENickname.Enabled = false;
            this.Txt_EBirthday.Enabled = false;
            this.Img_EBirthday.Visible = false;
            this.DD_EPerson_Sex.Enabled = false;
            this.DD_EEducation.Enabled = false;
            this.Txt_ETotal_Member.Enabled = false;
            this.Panel_EditName.Visible = true;
            this.Panel_SaveName.Visible = false;

           
            this.Txt_EIDCard.Enabled = false;
            this.Txt_EPrefix.Enabled = false;
            this.Txt_EName.Enabled = false;
            this.Txt_ESurname.Enabled = false;
             
        }

        protected void Img_SaveName_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel_ConfirmNameErr.Visible = false;
            if (this.Txt_EBirthday.Text.Trim() == string.Empty)
            {
                this.Lb_ConfirmNameErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันเกิด!";
                this.Panel_ConfirmNameErr.Visible = true;
                 
                return;
            }
            else
            {
                bool complete = false;
                DateTime _Birthday = DateTime.MinValue;
                complete = DateTime.TryParse(this.Txt_EBirthday.Text, out _Birthday);
                if (complete == false)
                {
                    this.Lb_ConfirmNameErr.Text = "ไม่สามารถทำรายการได้ : กรุณาตรวจสอบรูปแบบวันเกิด!";
                    this.Panel_ConfirmNameErr.Visible = true;
                     
                    return;
                }
            }

            _Purchase _p = new _Purchase();
            _p._Customer.ID = int.Parse(this.Txt_ECusID.Text);
            _p.ChkP = "Y";
            //----------------------------------------------------
            _p._Customer.IDCard = this.Txt_EIDCard.Text.Trim();
            _p._Customer.Prefix = this.Txt_EPrefix.Text.Trim();
            _p._Customer.Name = this.Txt_EName.Text.Trim();
            _p._Customer.Surname = this.Txt_ESurname.Text.Trim();

            //----------------------------------------------------
            _p._Customer.Nickname = this.Txt_ENickname.Text.Trim();
            DateTime _BirthDay = DateTime.MinValue;
            DateTime.TryParse(this.Txt_EBirthday.Text, out _BirthDay);
            _p._Customer.Birthday = _BirthDay;
            _p._Customer.Sex = this.DD_EPerson_Sex.SelectedValue;
            _p._Customer._Education.id = int.Parse(this.DD_EEducation.SelectedValue);
            if (this.Txt_ETotal_Member.Text.Trim() != string.Empty)
            {
                _p._Customer.Total_Member = int.Parse(this.Txt_ETotal_Member.Text);
            }
            _p.User_Edit = (int)Session["Emp_id"];
            try
            {
                _p.UPDATE_Purchase(3, _p);
            }
            catch (Exception err)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :') " + err.Message + "", true);
                return;
            }
            this.Txt_ENickname.Enabled = false;
            this.Txt_EBirthday.Enabled = false;
            this.Img_EBirthday.Visible = false;
            this.DD_EPerson_Sex.Enabled = false;
            this.DD_EEducation.Enabled = false;
            this.Txt_ETotal_Member.Enabled = false;
            this.Panel_EditName.Visible = true;
            this.Panel_SaveName.Visible = false;

            this.Txt_EIDCard.Enabled = false;
            this.Txt_EPrefix.Enabled = false;
            this.Txt_EName.Enabled = false;
            this.Txt_ESurname.Enabled = false;
             
        }

        protected void Img_EditTel_Click(object sender, ImageClickEventArgs e)
        {
            this.Txt_ETelMobile1.Enabled = true;
            this.Txt_ETelMobile2.Enabled = true;
            this.Txt_ETelHome_Work.Enabled = true;
            this.Txt_EFax.Enabled = true;
            this.Txt_ElineID.Enabled = true;
            this.Panel_EditTel.Visible = false;
            this.Panel_SaveTel.Visible = true;

             
        }

        protected void Img_CancelTel_Click(object sender, ImageClickEventArgs e)
        {
            this.Txt_ETelMobile1.Enabled = false;
            this.Txt_ETelMobile2.Enabled = false;
            this.Txt_ETelHome_Work.Enabled = false;
            this.Txt_EFax.Enabled = false;
            this.Txt_ElineID.Enabled = false;
            this.Panel_EditTel.Visible = true;
            this.Panel_SaveTel.Visible = false;

             
        }

        protected void Img_SaveTel_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel_ConfirmTelErr.Visible = false;
            if (this.Txt_ETelMobile1.Text.Trim() == string.Empty && this.Txt_ETelMobile2.Text.Trim() == string.Empty && this.Txt_ETelHome_Work.Text.Trim() == string.Empty)
            {
                this.Lb_ConfirmTelErr.Text = "ไม่สามารถทำรายการได้ : กรุณากรอกเบอร์ มือถือ/บ้าน อย่างน้อย 1 เบอร์!";
                this.Panel_ConfirmTelErr.Visible = true;
                 
                return;
            }
            else
            {
                if (this.Txt_ETelMobile1.Text.Trim() != string.Empty && this.Txt_ETelMobile1.Text.Trim().Length != 10)
                {
                    this.Lb_ConfirmTelErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเบอร์โทรศัพท์มือถือ 1 เป็นตัวเลข 10 หลักเท่านั้น!";
                    this.Panel_ConfirmTelErr.Visible = true;
                     
                    return;
                }

                if (this.Txt_ETelMobile2.Text.Trim() != string.Empty && this.Txt_ETelMobile2.Text.Trim().Length != 10)
                {
                    this.Lb_ConfirmTelErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเบอร์โทรศัพท์มือถือ 2 เป็นตัวเลข 10 หลักเท่านั้น!";
                    this.Panel_ConfirmTelErr.Visible = true;
                     
                    return;
                }
            }

            _Purchase _p = new _Purchase();
            _p._Customer.ID = int.Parse(this.Txt_ECusID.Text);
            _p.ChkP = "Y";
            //-------------------------------------------------
            _p._Customer.CorporationCode = this.Txt_ECorporationCode.Text.Trim();
            _p._Customer.Name = this.Txt_ECompanyName.Text.Trim();
            //-------------------------------------------------

            _p._Customer.Tel_Mobile1 = this.Txt_ETelMobile1.Text.Trim();
            _p._Customer.Tel_Mobile2 = this.Txt_ETelMobile2.Text.Trim();
            _p._Customer.Tel_Work = this.Txt_ETelHome_Work.Text.Trim();
            _p._Customer.Tel_Fax = this.Txt_EFax.Text.Trim();
            _p._Customer.LineID = this.Txt_ElineID.Text.Trim();
            _p.User_Edit = (int)Session["Emp_id"];
            try
            {
                _p.UPDATE_Purchase(4, _p);
            }
            catch (Exception err)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :') " + err.Message + "", true);
                return;
            }
            this.Txt_ETelMobile1.Enabled = false;
            this.Txt_ETelMobile2.Enabled = false;
            this.Txt_ETelHome_Work.Enabled = false;
            this.Txt_EFax.Enabled = false;
            this.Txt_ElineID.Enabled = false;
            this.Panel_EditTel.Visible = true;
            this.Panel_SaveTel.Visible = false;
             
        }

        protected void Img_EditCareer_Click(object sender, ImageClickEventArgs e)
        {
            this.DD_ECareer.Enabled = true;
            this.Txt_ECareer_Other.Enabled = true;
            this.Txt_ECareer_Remark.Enabled = true;
            this.DD_EInCome.Enabled = true;
            this.Panel_EditCareer.Visible = false;
            this.Panel_SaveCareer.Visible = true;
             
        }

        protected void Img_CancelCareer_Click(object sender, ImageClickEventArgs e)
        {
            this.DD_ECareer.Enabled = false;
            this.Txt_ECareer_Other.Enabled = false;
            this.Txt_ECareer_Remark.Enabled = false;
            this.DD_EInCome.Enabled = false;
            this.Panel_EditCareer.Visible = true;
            this.Panel_SaveCareer.Visible = false;
             
        }

        protected void Img_SaveCareer_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel_ConfirmCareerErr.Visible = false;
            if (this.DD_ECareer.SelectedValue == "11" && this.Txt_ECareer_Other.Text.Trim() == string.Empty)
            {
                    this.Lb_ConfirmCareerErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุอาชีพอื่นๆ!";
                    this.Panel_ConfirmCareerErr.Visible = true;
                     
                    return;
            }
            _Purchase _p = new _Purchase();
            _p._Customer.ID = int.Parse(this.Txt_ECusID.Text);
            _p.ChkP = "Y";
            _p._Customer._Career.ID = int.Parse(this.DD_ECareer.SelectedValue);
            if (this.DD_ECareer.SelectedValue == "11")
            {
                _p._Customer.Career_Other = this.Txt_ECareer_Other.Text.Trim();
            }
            _p._Customer.Career_Remark = this.Txt_ECareer_Remark.Text.Trim();
            _p._Customer._Income.ID = int.Parse(this.DD_EInCome.SelectedValue);
            _p.User_Edit = (int)Session["Emp_id"];
            try
            {
                _p.UPDATE_Purchase(5, _p);
            }
            catch (Exception err)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :') " + err.Message + "", true);
                return;
            }
            this.DD_ECareer.Enabled = false;
            this.Txt_ECareer_Other.Enabled = false;
            this.Txt_ECareer_Remark.Enabled = false;
            this.DD_EInCome.Enabled = false;
            this.Panel_EditCareer.Visible = true;
            this.Panel_SaveCareer.Visible = false;
             
        }

        protected void Btn_EditAddress_Click(object sender, EventArgs e)
        {
            this.StringEmpty_EAdd();

            this.Txt_EAdd_Address.Text = this._AddList[1].Address.ToString();
            if (this._AddList[1].Add_Moo.ToString() != "0")
            {
                this.Txt_EAdd_Moo.Text = this._AddList[1].Add_Moo.ToString();
            }
            this.Txt_EAdd_HomeName.Text = this._AddList[1].Add_HomeName.ToString();
            this.Txt_EAdd_Road.Text = this._AddList[1].Add_Road.ToString();
            if (this._AddList[1].Add_Soi.ToString() != "0")
            {
                this.Txt_EAdd_Soi.Text = this._AddList[1].Add_Soi.ToString();
            }
            
            _ProvinceList _Province = new _ProvinceList();
            _Province.Select(1);
            this.DD_EAdd_Province.DataSource = _Province.Values;
            this.DD_EAdd_Province.DataTextField = "PROVINCE_NAME";
            this.DD_EAdd_Province.DataValueField = "PROVINCE_ID";
            this.DD_EAdd_Province.DataBind();
            this.DD_EAdd_Province.Items.Insert(0, "-- เลือกจังหวัด --");
            this.DD_EAdd_Province.SelectedValue = this._AddList[1]._Province.PROVINCE_ID.ToString();

            _AmphurList _Amphur = new _AmphurList();
            _Amphur.Select(1, int.Parse(this.DD_EAdd_Province.SelectedValue));
            this.DD_EAdd_Amphur.DataSource = _Amphur.Values;
            this.DD_EAdd_Amphur.DataTextField = "AMPHUR_NAME";
            this.DD_EAdd_Amphur.DataValueField = "AMPHUR_ID";
            this.DD_EAdd_Amphur.DataBind();
            this.DD_EAdd_Amphur.Items.Insert(0, "-- เลือกอำเภอ --");
            this.DD_EAdd_Amphur.SelectedValue = this._AddList[1]._Amphur.AMPHUR_ID.ToString();

            _DistrictList _District = new _DistrictList();
            _District.Select(1, int.Parse(this.DD_EAdd_Province.SelectedValue), int.Parse(this.DD_EAdd_Amphur.SelectedValue));
            this.DD_EAdd_District.DataSource = _District.Values;
            this.DD_EAdd_District.DataTextField = "DISTRICT_NAME";
            this.DD_EAdd_District.DataValueField = "DISTRICT_ID";
            this.DD_EAdd_District.DataBind();
            this.DD_EAdd_District.Items.Insert(0, "-- เลือกตำบล --");
            this.DD_EAdd_District.SelectedValue = this._AddList[1]._District.DISTRICT_ID.ToString();

            this.Txt_EAdd_Postel.Text = this._AddList[1]._Postel.Postel_Code.ToString();
            Session["CheckAdd"] = "Add";
            this.ModalPopupExtender_EAddress.Show();
        }

        private void StringEmpty_EAdd()
        {
            this.Txt_EAdd_Address.Text = string.Empty;
            this.Txt_EAdd_Moo.Text = string.Empty;
            this.Txt_EAdd_HomeName.Text = string.Empty;
            this.Txt_EAdd_Road.Text = string.Empty;
            this.Txt_EAdd_Soi.Text = string.Empty;

            this.Panel_EAddAddress_Err.Visible = false;
        }

        protected void Img_CloseEAddress_Click(object sender, ImageClickEventArgs e)
        {
            this.ModalPopupExtender_EAddress.Hide();
             
        }

        protected void DD_EAdd_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DD_EAdd_Province.SelectedIndex != 0)
            {
                _AmphurList _Amphur = new _AmphurList();
                _Amphur.Select(1, int.Parse(this.DD_EAdd_Province.SelectedValue));
                this.DD_EAdd_Amphur.DataSource = _Amphur.Values;
                this.DD_EAdd_Amphur.DataTextField = "AMPHUR_NAME";
                this.DD_EAdd_Amphur.DataValueField = "AMPHUR_ID";
                this.DD_EAdd_Amphur.DataBind();
                this.DD_EAdd_Amphur.Items.Insert(0, "-- เลือกอำเภอ --");
                this.DD_EAdd_Amphur.SelectedIndex = 0;
            }
            this.ModalPopupExtender_EAddress.Show();
        }

        protected void DD_EAdd_Amphur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DD_EAdd_Amphur.SelectedIndex != 0)
            {
                _DistrictList _District = new _DistrictList();
                _District.Select(1, int.Parse(this.DD_EAdd_Province.SelectedValue), int.Parse(this.DD_EAdd_Amphur.SelectedValue));
                this.DD_EAdd_District.DataSource = _District.Values;
                this.DD_EAdd_District.DataTextField = "DISTRICT_NAME";
                this.DD_EAdd_District.DataValueField = "DISTRICT_ID";
                this.DD_EAdd_District.DataBind();
                this.DD_EAdd_District.Items.Insert(0, "-- เลือกตำบล --");
                this.DD_EAdd_District.SelectedIndex = 0;
            }
            this.ModalPopupExtender_EAddress.Show();
        }

        protected void DD_EAdd_District_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DD_EAdd_District.SelectedIndex != 0)
            {
                _Postel _Postel = new _Postel();
                _Postel.Select(1, int.Parse(this.DD_EAdd_District.SelectedValue));
                if (_Postel != null)
                {
                    this.Txt_EAdd_Postel.Text = _Postel.Postel_Code;
                }
                else
                {
                    this.Txt_EAdd_Postel.Text = string.Empty;
                }
            }
            this.ModalPopupExtender_EAddress.Show();
        }

        protected void Btn_SaveEAddAddress_Click(object sender, EventArgs e)
        {
            if (this.Txt_EAdd_Address.Text.Trim() == string.Empty || this.Txt_EAdd_Address.Text.Trim() == "")
            {
                this.Lb_EAddAddress_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขที่!";
                this.Panel_EAddAddress_Err.Visible = true;
                this.ModalPopupExtender_EAddress.Show();
                return;
            }
            else if (this.DD_EAdd_Province.SelectedIndex == 0)
            {
                this.Lb_EAddAddress_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจังหวัด!";
                this.Panel_EAddAddress_Err.Visible = true;
                this.ModalPopupExtender_EAddress.Show();
                return;
            }
            else if (this.DD_EAdd_Amphur.SelectedIndex == 0)
            {
                this.Lb_EAddAddress_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุอำเภอ!";
                this.Panel_EAddAddress_Err.Visible = true;
                this.ModalPopupExtender_EAddress.Show();
                return;
            }
            else if (this.DD_EAdd_District.SelectedIndex == 0)
            {
                this.Lb_EAddAddress_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุตำบล!";
                this.Panel_EAddAddress_Err.Visible = true;
                this.ModalPopupExtender_EAddress.Show();
                return;
            }
            _Purchase _p = new _Purchase();
            _p._Customer.ID = int.Parse(this.Txt_ECusID.Text);
            _p.ChkP = "Y";
            if ((string)Session["CheckAdd"] == "Add")
            {
                this._AddList.Remove(1);
                this._AddList = new _AddressList();
            }
            else if ((string)Session["CheckAdd"] == "AddSend")
            {
                this._SentAddList = new _AddressList();
                if (this._SentAddList.Count != 0)
                {
                    this._SentAddList.Remove(1);
                }
            }
            
            _AddressList._Address _Add = new _AddressList._Address();
            _Add.Address = this.Txt_EAdd_Address.Text.Trim();
            _p._Customer._Address.Address = this.Txt_EAdd_Address.Text.Trim();
            if (this.Txt_EAdd_Moo.Text.Trim() != string.Empty)
            {
                _Add.Add_Moo = int.Parse(this.Txt_EAdd_Moo.Text.Trim());
                _p._Customer._Address.Add_Moo = int.Parse(this.Txt_EAdd_Moo.Text.Trim());
            }
            if (this.Txt_EAdd_HomeName.Text.Trim() != string.Empty)
            {
                _Add.Add_HomeName = this.Txt_EAdd_HomeName.Text.Trim();
                _p._Customer._Address.Add_HomeName = this.Txt_EAdd_HomeName.Text.Trim();
            }
            if (this.Txt_EAdd_Road.Text.Trim() != string.Empty)
            {
                _Add.Add_Road = this.Txt_EAdd_Road.Text.Trim();
                _p._Customer._Address.Add_Road = this.Txt_EAdd_Road.Text.Trim();
            }
            if (this.Txt_EAdd_Soi.Text.Trim() != string.Empty)
            {
                _Add.Add_Soi = this.Txt_EAdd_Soi.Text.Trim();
                _p._Customer._Address.Add_Soi = this.Txt_EAdd_Soi.Text.Trim();
            }

            _Add._District.DISTRICT_ID = int.Parse(this.DD_EAdd_District.SelectedValue);
            _p._Customer._Address._District.DISTRICT_ID = int.Parse(this.DD_EAdd_District.SelectedValue);
            _Add._District.DISTRICT_NAME = this.DD_EAdd_District.SelectedItem.Text;
            _Add._Amphur.AMPHUR_ID = int.Parse(this.DD_EAdd_Amphur.SelectedValue);
            _p._Customer._Address._Amphur.AMPHUR_ID = int.Parse(this.DD_EAdd_Amphur.SelectedValue);
            _Add._Amphur.AMPHUR_NAME = this.DD_EAdd_Amphur.SelectedItem.Text;
            _Add._Province.PROVINCE_ID = int.Parse(this.DD_EAdd_Province.SelectedValue);
            _p._Customer._Address._Province.PROVINCE_ID = int.Parse(this.DD_EAdd_Province.SelectedValue);
            _Add._Province.PROVINCE_NAME = this.DD_EAdd_Province.SelectedItem.Text;

            if (this.Txt_EAdd_Postel.Text.Trim() != string.Empty)
            {
                _Add._Postel.Postel_Code = this.Txt_EAdd_Postel.Text.Trim();
                _p._Customer._Address._Postel.Postel_Code = this.Txt_EAdd_Postel.Text.Trim();
            }

            if ((string)Session["CheckAdd"] == "Add")
            {
                this._AddList.Add(1, _Add);
                Session.Add("AddList", this._AddList);
                this.gv_EAddress.DataSource = this._AddList.Values;
                this.gv_EAddress.DataBind();

                _p.User_Edit = (int)Session["Emp_id"];
                try
                {
                    _p.UPDATE_Purchase(6, _p);
                }
                catch (Exception err)
                {
                    this.Lb_EAddAddress_Err.Text = "ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :" + err.Message;
                    this.Panel_EAddAddress_Err.Visible = true;
                    this.ModalPopupExtender_EAddress.Show();
                    return;
                }
            }
            else
            {
                this._SentAddList.Add(1, _Add);
                Session.Add("SentAddList",this._SentAddList);
                this.Btn_EAddSendAddress.Visible = false;
                this.gv_ESentAddress.DataSource = this._SentAddList.Values;
                this.gv_ESentAddress.DataBind();
            }

            this.ModalPopupExtender_EAddress.Hide();
             
        }

        protected void Cb_ESendAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Cb_ESendAddress.Checked == true)
            {
                this.SentAdd_Y();
            }
            else
            {
                this.SentAdd_N();
            }
             
        }

        private void SentAdd_Y()
        {
            this.Cb_ESendAddress.Checked = true;
            this.Cb_ESendAddress_New.Checked = false;
            this.Btn_EAddSendAddress.Visible = false;
            this.gv_ESentAddress.Visible = false;
        }

        private void SentAdd_N()
        {
            this.Cb_ESendAddress_New.Checked = true;
            this.Cb_ESendAddress.Checked = false;
            this.Btn_EAddSendAddress.Visible = true;
            _AddressList _alist = new _AddressList();
            _AddressList._Address temp = new _AddressList._Address();
            _alist.Add(0, temp);
            this.gv_ESentAddress.DataSource = _alist.Values;
            this.gv_ESentAddress.DataBind();
            this.gv_ESentAddress.Visible = true;
        }

        protected void Cb_ESendAddress_New_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Cb_ESendAddress_New.Checked == true)
            {
                this.SentAdd_N();
            }
            else
            {
                this.SentAdd_Y();
            }
             
        }

        protected void Img_EditSendAdd_Click(object sender, ImageClickEventArgs e)
        {
            this.Cb_ESendAddress.Enabled = true;
            this.Cb_ESendAddress_New.Enabled = true;
            this.gv_ESentAddress.Columns[9].Visible = true;
            this.Panel_EditSendAdd.Visible = false;
            this.Panel_SaveSendAdd.Visible = true;
             
        }

        protected void Img_CancelSendAdd_Click(object sender, ImageClickEventArgs e)
        {
            this.Cb_ESendAddress.Enabled = false;
            this.Cb_ESendAddress_New.Enabled = false;
            this.gv_ESentAddress.Columns[9].Visible = false;
            this.Panel_EditSendAdd.Visible = true;
            this.Panel_SaveSendAdd.Visible = false;
             
        }

        protected void Img_SaveSendAdd_Click(object sender, ImageClickEventArgs e)
        {

            _Purchase _p = new _Purchase();
            _p._Customer.ID = int.Parse(this.Txt_ECusID.Text);
            _p.ChkP = "Y";
            if (this.Cb_ESendAddress.Checked == true)
            {
                _p._Customer.SendAddress_IDCard = "Y";
                _p._Customer._Address.Address = this._AddList[1].Address.ToString();
                _p._Customer._Address.Add_Moo = int.Parse(this._AddList[1].Add_Moo.ToString());
                _p._Customer._Address.Add_HomeName = this._AddList[1].Add_HomeName.ToString();
                _p._Customer._Address.Add_Road = this._AddList[1].Add_Road.ToString();
                _p._Customer._Address.Add_Soi = this._AddList[1].Add_Soi.ToString();
                _p._Customer._Address._District.DISTRICT_ID = this._AddList[1]._District.DISTRICT_ID;
                _p._Customer._Address._Amphur.AMPHUR_ID = this._AddList[1]._Amphur.AMPHUR_ID;
                _p._Customer._Address._Province.PROVINCE_ID = this._AddList[1]._Province.PROVINCE_ID;
                _p._Customer._Address._Postel.Postel_Code = this._AddList[1]._Postel.Postel_Code;
            }
            else
            {
                if (this._SentAddList.Count == 0)
                {
                    this.Lb_ConfirmSendAddErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุที่อยู่ส่งเอกสาร!";
                    this.Panel_ConfirmSendAddErr.Visible = true;
                    
                    return;
                }

                _p._Customer.SendAddress_IDCard = "N";
                _p._Customer._Address.Address = this._SentAddList[1].Address.ToString();
                _p._Customer._Address.Add_Moo = int.Parse(this._SentAddList[1].Add_Moo.ToString());
                _p._Customer._Address.Add_HomeName = this._SentAddList[1].Add_HomeName.ToString();
                _p._Customer._Address.Add_Road = this._SentAddList[1].Add_Road.ToString();
                _p._Customer._Address.Add_Soi = this._SentAddList[1].Add_Soi.ToString();
                _p._Customer._Address._District.DISTRICT_ID = this._SentAddList[1]._District.DISTRICT_ID;
                _p._Customer._Address._Amphur.AMPHUR_ID = this._SentAddList[1]._Amphur.AMPHUR_ID;
                _p._Customer._Address._Province.PROVINCE_ID = this._SentAddList[1]._Province.PROVINCE_ID;
                _p._Customer._Address._Postel.Postel_Code = this._SentAddList[1]._Postel.Postel_Code;              
            }

                _p.User_Edit = (int)Session["Emp_id"];
                try
                {
                    _p.UPDATE_Purchase(7, _p);
                }
                catch (Exception err)
                {
                    this.Lb_ConfirmSendAddErr.Text = "ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :" + err.Message;
                    this.Panel_ConfirmSendAddErr.Visible = true;
                     
                    return;
                }

                this.Cb_ESendAddress.Enabled = false;
                this.Cb_ESendAddress_New.Enabled = false;
                this.gv_ESentAddress.Columns[9].Visible = false;
                this.Panel_EditSendAdd.Visible = true;
                this.Panel_SaveSendAdd.Visible = false;
        }

        protected void Btn_EditSendAddress_Click(object sender, EventArgs e)
        {
            Session["CheckAdd"] = "AddSend";
            this.Lb_NameAddress.Text = "เพิ่มที่อยู่ส่งเอกสาร";
            this.StringEmpty_EAdd();

            if (Session["SentAddList"] != null)
            {
                this.Txt_EAdd_Address.Text = this._SentAddList[1].Address.ToString();
                if (this._SentAddList[1].Add_Moo.ToString() != "0")
                {
                    this.Txt_EAdd_Moo.Text = this._SentAddList[1].Add_Moo.ToString();
                }
                this.Txt_EAdd_HomeName.Text = this._SentAddList[1].Add_HomeName.ToString();
                this.Txt_EAdd_Road.Text = this._SentAddList[1].Add_Road.ToString();
                if (this._SentAddList[1].Add_Soi.ToString() != "0")
                {
                    this.Txt_EAdd_Soi.Text = this._SentAddList[1].Add_Soi.ToString();
                }

                _ProvinceList _Province = new _ProvinceList();
                _Province.Select(1);
                this.DD_EAdd_Province.DataSource = _Province.Values;
                this.DD_EAdd_Province.DataTextField = "PROVINCE_NAME";
                this.DD_EAdd_Province.DataValueField = "PROVINCE_ID";
                this.DD_EAdd_Province.DataBind();
                this.DD_EAdd_Province.Items.Insert(0, "-- เลือกจังหวัด --");
                this.DD_EAdd_Province.SelectedValue = this._SentAddList[1]._Province.PROVINCE_ID.ToString();

                _AmphurList _Amphur = new _AmphurList();
                _Amphur.Select(1, int.Parse(this.DD_EAdd_Province.SelectedValue));
                this.DD_EAdd_Amphur.DataSource = _Amphur.Values;
                this.DD_EAdd_Amphur.DataTextField = "AMPHUR_NAME";
                this.DD_EAdd_Amphur.DataValueField = "AMPHUR_ID";
                this.DD_EAdd_Amphur.DataBind();
                this.DD_EAdd_Amphur.Items.Insert(0, "-- เลือกอำเภอ --");
                this.DD_EAdd_Amphur.SelectedValue = this._SentAddList[1]._Amphur.AMPHUR_ID.ToString();

                _DistrictList _District = new _DistrictList();
                _District.Select(1, int.Parse(this.DD_EAdd_Province.SelectedValue), int.Parse(this.DD_EAdd_Amphur.SelectedValue));
                this.DD_EAdd_District.DataSource = _District.Values;
                this.DD_EAdd_District.DataTextField = "DISTRICT_NAME";
                this.DD_EAdd_District.DataValueField = "DISTRICT_ID";
                this.DD_EAdd_District.DataBind();
                this.DD_EAdd_District.Items.Insert(0, "-- เลือกตำบล --");
                this.DD_EAdd_District.SelectedValue = this._SentAddList[1]._District.DISTRICT_ID.ToString();
            }
            else
            {
                _ProvinceList _Province = new _ProvinceList();
                _Province.Select(1);
                this.DD_EAdd_Province.DataSource = _Province.Values;
                this.DD_EAdd_Province.DataTextField = "PROVINCE_NAME";
                this.DD_EAdd_Province.DataValueField = "PROVINCE_ID";
                this.DD_EAdd_Province.DataBind();
                this.DD_EAdd_Province.Items.Insert(0, "-- เลือกจังหวัด --");
                this.DD_EAdd_Province.SelectedValue = "38";

                _AmphurList _Amphur = new _AmphurList();
                _Amphur.Select(1, int.Parse(this.DD_EAdd_Province.SelectedValue));
                this.DD_EAdd_Amphur.DataSource = _Amphur.Values;
                this.DD_EAdd_Amphur.DataTextField = "AMPHUR_NAME";
                this.DD_EAdd_Amphur.DataValueField = "AMPHUR_ID";
                this.DD_EAdd_Amphur.DataBind();
                this.DD_EAdd_Amphur.Items.Insert(0, "-- เลือกอำเภอ --");
                this.DD_EAdd_Amphur.SelectedIndex = 0;

                this.DD_EAdd_District.DataSource = null;
                this.DD_EAdd_District.DataBind();

            }
            this.ModalPopupExtender_EAddress.Show();
        }

        protected void Btn_EAddSendAddress_Click(object sender, EventArgs e)
        {
            Session["CheckAdd"] = "AddSend";
            this.Lb_NameAddress.Text = "เพิ่มที่อยู่ส่งเอกสาร";
            this.StringEmpty_EAdd();

            _ProvinceList _Province = new _ProvinceList();
            _Province.Select(1);
            this.DD_EAdd_Province.DataSource = _Province.Values;
            this.DD_EAdd_Province.DataTextField = "PROVINCE_NAME";
            this.DD_EAdd_Province.DataValueField = "PROVINCE_ID";
            this.DD_EAdd_Province.DataBind();
            this.DD_EAdd_Province.Items.Insert(0, "-- เลือกจังหวัด --");
            this.DD_EAdd_Province.SelectedValue = "38";

            _AmphurList _Amphur = new _AmphurList();
            _Amphur.Select(1, int.Parse(this.DD_EAdd_Province.SelectedValue));
            this.DD_EAdd_Amphur.DataSource = _Amphur.Values;
            this.DD_EAdd_Amphur.DataTextField = "AMPHUR_NAME";
            this.DD_EAdd_Amphur.DataValueField = "AMPHUR_ID";
            this.DD_EAdd_Amphur.DataBind();
            this.DD_EAdd_Amphur.Items.Insert(0, "-- เลือกอำเภอ --");
            this.DD_EAdd_Amphur.SelectedIndex = 0;

            this.DD_EAdd_District.DataSource = null;
            this.DD_EAdd_District.DataBind();

            this.ModalPopupExtender_EAddress.Show();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.CarData_Click();
        }

        private void CarData_Click()
        {
            this.ColorLinkBtn_Click(this.LinkBtn_CarData);
            this.ColorLinkBtn_UnClick(this.LinkBtn_CusData);
            this.ColorLinkBtn_UnClick(this.LinkBtn_Accessories);
            this.ColorLinkBtn_UnClick(this.LinkButton_Finance);
            this.ColorLinkBtn_UnClick(this.LinkButton_Invoice);

            this.Panel_Invoice.Visible = false;
            this.Panel_CarData.Visible = true;
            this.Panel_CustomerData.Visible = false;
            this.Panel_Accessories.Visible = false;
            this.Panel_Finance.Visible = false;
        }

        public void ColorLinkBtn_Click(LinkButton btn)
        {
            btn.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6189df");
            btn.BackColor = Color.White;
        }

        public void ColorLinkBtn_UnClick(LinkButton btn)
        {
            btn.ForeColor = Color.White;
            btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#6189df");
        }

        protected void LinkBtn_CarData_Click(object sender, EventArgs e)
        {
            this.CarData_Click();
        }

        protected void Img_EdiBuyType_Click(object sender, ImageClickEventArgs e)
        {
            this.DD_EBuyType.Enabled = true;
            //this.Txt_ECarPlate.Enabled = true;
            //this.Txt_RegisDate.Enabled = true;
            //this.Img_RegisDate.Visible = true;
            //this.Txt_CarTax.Enabled = true;
            //this.DD_ECarType.Enabled = true;
            this.Panel_EditBuyType.Visible = false;
            this.Panel_SaveBuyType.Visible = true;
        }

        protected void Img_CancelBuyType_Click(object sender, ImageClickEventArgs e)
        {
            this.DD_EBuyType.Enabled = false;
            //this.Txt_ECarPlate.Enabled = false;
            //this.Txt_RegisDate.Enabled = false;
            //this.Img_RegisDate.Visible = false;
            //this.Txt_CarTax.Enabled = false;
            //this.DD_ECarType.Enabled = false;
            this.Panel_EditBuyType.Visible = true;
            this.Panel_SaveBuyType.Visible = false;
        }

        protected void Img_SaveBuyType_Click(object sender, ImageClickEventArgs e)
        {
            _Purchase _p = new _Purchase();
            _p.ID = int.Parse(this.Lb_EPOID.Text);
            _p.ChkP = "Y";
            _p.Buy_Type = this.DD_EBuyType.SelectedItem.Text;
            _p.CarPlate = this.Txt_ECarPlate.Text.Trim();
            DateTime _RegisDate = DateTime.MinValue;
            DateTime.TryParse(this.Txt_RegisDate.Text, out _RegisDate);
            _p.Regis_Date = _RegisDate;
            _p.CarTax = this.Txt_CarTax.Text.Trim();
            if (this.DD_ECarType.SelectedIndex != 0)
            {
                _p._CarType.ID = int.Parse(this.DD_ECarType.SelectedValue);
            }
            _p.User_Edit = (int)Session["Emp_id"];
            try
            {
                _p.UPDATE_Purchase(8, _p);
            }
            catch (Exception err)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :') " + err.Message + "", true);
                return;
            }

            this.DD_EBuyType.Enabled = false;
            this.Txt_ECarPlate.Enabled = false;
            this.Txt_RegisDate.Enabled = false;
            this.Img_RegisDate.Visible = false;
            this.Txt_CarTax.Enabled = false;
            this.DD_ECarType.Enabled = false;
            this.Panel_EditBuyType.Visible = true;
            this.Panel_SaveBuyType.Visible = false;
        }

        protected void LinkBtn_CusData_Click(object sender, EventArgs e)
        {
            this.CusData_Click();
        }

        private void CusData_Click()
        {
                this.ColorLinkBtn_Click(this.LinkBtn_CusData);
                this.ColorLinkBtn_UnClick(this.LinkBtn_CarData);
                this.ColorLinkBtn_UnClick(this.LinkBtn_Accessories);
                this.ColorLinkBtn_UnClick(this.LinkButton_Finance);
                this.ColorLinkBtn_UnClick(this.LinkButton_Invoice);

                this.Panel_Invoice.Visible = false;
                this.Panel_CustomerData.Visible = true;
                this.Panel_CarData.Visible = false;
                this.Panel_Accessories.Visible = false;
                this.Panel_Finance.Visible = false;

        }

        protected void Img_EditCE_Click(object sender, ImageClickEventArgs e)
        {
            this.Cb_ECE_N.Enabled = true;
            this.Cb_ECE_Y.Enabled = true;
            this.Txt_ECEMCNumber.Enabled = true;
            this.Txt_ECEMCNumber.Enabled = true;
            this.Txt_ECETruckNumber.Enabled = true;
            this.Txt_ECEBrand.Enabled = true;
            this.Txt_ECEModel.Enabled = true;
            this.Txt_ECEColor.Enabled = true;
            this.Txt_ECEYear.Enabled = true;
            this.Txt_ECECarPlate.Enabled = true;
            this.Txt_ECEPrice.Enabled = true;
            this.Txt_ECEEmp.Enabled = true;
            this.Panel_EditCE.Visible = false;
            this.Panel_SaveCE.Visible = true;
        }

        protected void Img_CancelCE_Click(object sender, ImageClickEventArgs e)
        {
            this.Cb_ECE_N.Enabled = false;
            this.Cb_ECE_Y.Enabled = false;
            this.Txt_ECEMCNumber.Enabled = false;
            this.Txt_ECEMCNumber.Enabled = false;
            this.Txt_ECETruckNumber.Enabled = false;
            this.Txt_ECEBrand.Enabled = false;
            this.Txt_ECEModel.Enabled = false;
            this.Txt_ECEColor.Enabled = false;
            this.Txt_ECEYear.Enabled = false;
            this.Txt_ECECarPlate.Enabled = false;
            this.Txt_ECEPrice.Enabled = false;
            this.Txt_ECEEmp.Enabled = false;
            this.Panel_EditCE.Visible = true;
            this.Panel_SaveCE.Visible = false;
        }

        protected void Img_SaveCE_Click(object sender, ImageClickEventArgs e)
        {
            if (this.Cb_ECE_Y.Checked == true)
            {

                this.Panel_ConfirmCEErr.Visible = false;
                #region เช็คข้อมูลรถ
                if (this.Cb_ECE_Y.Checked == true)
                {
                    if (this.Txt_ECEBrand.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmCEErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุยี่ห้อรถเก่า!";
                        this.Panel_ConfirmCEErr.Visible = true;
                        return;
                    }

                    if (this.Txt_ECEYear.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmCEErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุปีรถเก่า!";
                        this.Panel_ConfirmCEErr.Visible = true;
                        return;
                    }

                    if (this.Txt_ECEPrice.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmCEErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุราคารถเก่า!";
                        this.Panel_ConfirmCEErr.Visible = true;
                        return;
                    }

                    if (this.Txt_ECEEmp.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmCEErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุผู้ประเมินราคารถเก่า!";
                        this.Panel_ConfirmCEErr.Visible = true;
                        return;
                    }
                }
                #endregion

                _Purchase _p = new _Purchase();
                _p.ID = int.Parse(this.Lb_EPOID.Text);
                _p.CE_MCNumber = this.Txt_ECEMCNumber.Text.Trim();
                _p.CE_TruckNumber = this.Txt_ECETruckNumber.Text.Trim();
                _p.CE_Brand = this.Txt_ECEBrand.Text.Trim();
                _p.CE_Model = this.Txt_ECEModel.Text.Trim();
                _p.CE_Color = this.Txt_ECEColor.Text.Trim();
                _p.CE_Year = this.Txt_ECEYear.Text.Trim();
                _p.CE_CarPlate = this.Txt_ECECarPlate.Text.Trim();
                if (this.Txt_ECEPrice.Text.Trim() != string.Empty)
                {
                    _p.CE_Price = decimal.Parse(this.Txt_ECEPrice.Text.Trim());
                }
                _p.CE_Emp = this.Txt_ECEEmp.Text.Trim();
                _p.ChkP = "Y";
                _p.User_Edit = (int)Session["Emp_id"];
                try
                {
                    _p.UPDATE_Purchase(9, _p);
                }
                catch (Exception err)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :') " + err.Message + "", true);
                    return;
                }
            }
            else
            {
                _Purchase _p = new _Purchase();
                _p.ID = int.Parse(this.Lb_EPOID.Text);
                _p.ChkP = "Y";
                _p.User_Edit = (int)Session["Emp_id"];
                try
                {
                    _p.UPDATE_Purchase(10, _p);
                }
                catch (Exception err)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :') " + err.Message + "", true);
                    return;
                }
            }

            this.Cb_ECE_N.Enabled = false;
            this.Cb_ECE_Y.Enabled = false;
            this.Txt_ECEMCNumber.Enabled = false;
            this.Txt_ECEMCNumber.Enabled = false;
            this.Txt_ECETruckNumber.Enabled = false;
            this.Txt_ECEBrand.Enabled = false;
            this.Txt_ECEModel.Enabled = false;
            this.Txt_ECEColor.Enabled = false;
            this.Txt_ECEYear.Enabled = false;
            this.Txt_ECECarPlate.Enabled = false;
            this.Txt_ECEPrice.Enabled = false;
            this.Txt_ECEEmp.Enabled = false;
            this.Panel_EditCE.Visible = true;
            this.Panel_SaveCE.Visible = false;
        }

        private void CE_Y()
        {
            this.Cb_ECE_Y.Checked = true;
            this.Panel_ECE_Y.Visible = true;
            this.Cb_ECE_N.Checked = false;

        }

        private void CE_N()
        {
            this.Cb_ECE_Y.Checked = false;
            this.Panel_ECE_Y.Visible = false;
            this.Cb_ECE_N.Checked = true;
        }

        protected void Cb_ECE_Y_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Cb_ECE_Y.Checked == true)
            {
                this.CE_Y();
            }
            else
            {
                this.CE_N();
            }
        }

        protected void Cb_ECE_N_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Cb_ECE_N.Checked == true)
            {
                this.CE_N();
            }
            else
            {
                this.CE_Y();
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            this.Accessories_Click();
        }

        private void Accessories_Click()
        {
            this.ColorLinkBtn_Click(this.LinkBtn_Accessories);
            this.ColorLinkBtn_UnClick(this.LinkBtn_CusData);
            this.ColorLinkBtn_UnClick(this.LinkBtn_CarData);
            this.ColorLinkBtn_UnClick(this.LinkButton_Finance);
            this.ColorLinkBtn_UnClick(this.LinkButton_Invoice);

            this.Panel_Invoice.Visible = false;
            this.Panel_Accessories.Visible = true;
            this.Panel_CarData.Visible = false;
            this.Panel_CustomerData.Visible = false;
            this.Panel_Finance.Visible = false;

        }

        protected void LinkBtn_Accessories_Click(object sender, EventArgs e)
        {
            this.Accessories_Click();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            this.Finance_Click();
        }

        private void Finance_Click()
        {
            this.ColorLinkBtn_Click(this.LinkButton_Finance);
            this.ColorLinkBtn_UnClick(this.LinkBtn_CusData);
            this.ColorLinkBtn_UnClick(this.LinkBtn_CarData);
            this.ColorLinkBtn_UnClick(this.LinkBtn_Accessories);
            this.ColorLinkBtn_UnClick(this.LinkButton_Invoice);

            this.Panel_Invoice.Visible = false;
            this.Panel_Finance.Visible = true;
            this.Panel_CustomerData.Visible = false;
            this.Panel_CarData.Visible = false;
            this.Panel_Accessories.Visible = false;
            
        }


        protected void LinkButton_Finance_Click(object sender, EventArgs e)
        {
            this.Finance_Click();
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            this.getDataInvoice();
            this.Invoice_Click();
        }
        private void Invoice_Click()
        {
            this.ColorLinkBtn_Click(this.LinkButton_Invoice);
            this.ColorLinkBtn_UnClick(this.LinkButton_Finance);
            this.ColorLinkBtn_UnClick(this.LinkBtn_CusData);
            this.ColorLinkBtn_UnClick(this.LinkBtn_CarData);
            this.ColorLinkBtn_UnClick(this.LinkBtn_Accessories);

            this.Panel_Invoice.Visible = true;
            this.Panel_Finance.Visible = false;
            this.Panel_CustomerData.Visible = false;
            this.Panel_CarData.Visible = false;
            this.Panel_Accessories.Visible = false;
        }

        protected void LinkButton_Invoice_Click(object sender, EventArgs e)
        {
            this.getDataInvoice();
            this.Invoice_Click();
        }

        protected void gv_AdAccessories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                Label Lb_DAdAccFree = (Label)e.Row.FindControl("Lb_DAdAccFree");
                CheckBox Cb_DAdAccFree = (CheckBox)e.Row.FindControl("Cb_DAdAccFree");
                Label _Lb_AdAccPrice = (Label)e.Row.FindControl("Lb_AdAccPrice");

                if (Lb_DAdAccFree.Text == "Y")
                {
                    Cb_DAdAccFree.Checked = true;
                }
                else if (Lb_DAdAccFree.Text == "N")
                {
                    Cb_DAdAccFree.Checked = false;
                }


                if (_Lb_AdAccPrice.Text != "0.00")
                {
                    _Lb_AdAccPrice.Text = string.Format("{0:#,###}", decimal.Parse(_Lb_AdAccPrice.Text));

                    if (Lb_DAdAccFree.Text == "N")
                    {
                        SumAdAcc = SumAdAcc + decimal.Parse(_Lb_AdAccPrice.Text); 
                    }
                }

                if (SumAdAcc == 0)
                {
                    this.Lb_AdAccPrice.Text = "0";
                }
                else
                {
                    this.Lb_AdAccPrice.Text = string.Format("{0:#,###}", SumAdAcc);
                }

            }
        }

        protected void gv_Discount_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                Label _Lb_DcPrice = (Label)e.Row.FindControl("Lb_DcPrice");

                if (_Lb_DcPrice.Text != "0.00" && _Lb_DcPrice.Text != "0")
                {
                    _Lb_DcPrice.Text = string.Format("{0:#,###}", decimal.Parse(_Lb_DcPrice.Text));
                    SumDc = SumDc + decimal.Parse(_Lb_DcPrice.Text);
                    this.Lb_PriceDiscount.Text = string.Format("{0:#,###}", SumDc);
                }
            }
        }

        protected void Img_SetAccDel_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gv = (GridViewRow)((ImageButton)sender).NamingContainer;
            int id = int.Parse(gv_SetAccessories.DataKeys[gv.RowIndex].Value.ToString());
            this._SetAccList.Remove(id);
            if (this._SetAccList.Count == 0)
            {
                this.AddEmptyData_SetAcc();
            }
            else
            {
                this.gv_SetAccessories.DataSource = this._SetAccList.Values;
                this.gv_SetAccessories.DataBind();
            }
            this.Empty_PriceSum();
        }

        private void AddEmptyData_SetAcc()
        {
            _Accessorieslist _alist = new _Accessorieslist();
            _Accessorieslist._Accessories temp = new _Accessorieslist._Accessories();
            _alist.Add(0, temp);
            this.gv_SetAccessories.DataSource = _alist.Values;
            this.gv_SetAccessories.DataBind();
        }

        protected void Img_AddSetAcc_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel_SetAccErr.Visible = false;
            TextBox Txt_SetAccName = (TextBox)gv_SetAccessories.FooterRow.FindControl("Txt_SetAccName");
            if (Txt_SetAccName.Text.Trim() == string.Empty || Txt_SetAccName.Text.Trim() == "")
            {
                this.Lb_SetAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุชื่ออุปกรณ์!";
                this.Panel_SetAccErr.Visible = true;
                return;
            }

            if (Session["SetAccList"] == null)
            {
                this._SetAccList = new _Accessorieslist();
            }

            _Accessorieslist._Accessories _acc = new _Accessorieslist._Accessories();
            int _c;
            if (this._SetAccList.Count == 0)
            {
                _c = 1;
            }
            else
            {
                _c = this._SetAccList.Keys.Max();
                _c = _c + 1;
            }
            _acc.ID = _c;
            _acc.Name = Txt_SetAccName.Text.Trim();
            this._SetAccList.Add(_c, _acc);
            Session["SetAccList"] = this._SetAccList;
            this.gv_SetAccessories.DataSource = this._SetAccList.Values;
            this.gv_SetAccessories.DataBind();
            this.Empty_PriceSum();
        }

        protected void Img_AccSTDDel_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gv = (GridViewRow)((ImageButton)sender).NamingContainer;
            int id = int.Parse(gv_AccSTD.DataKeys[gv.RowIndex].Value.ToString());
            this._SetAccSTDList.Remove(id);
            if (this._SetAccSTDList.Count == 0)
            {
                this.AddEmptyData_SetAccSTD();
            }
            else
            {
                this.gv_AccSTD.DataSource = this._SetAccSTDList.Values;
                this.gv_AccSTD.DataBind();
            }
            this.Empty_PriceSum();
        }

        private void AddEmptyData_SetAccSTD()
        {
            _AccessoriesSTDList _alist = new _AccessoriesSTDList();
            _AccessoriesSTDList._AccessoriesSTD temp = new _AccessoriesSTDList._AccessoriesSTD();
            _alist.Add(0, temp);
            this.gv_AccSTD.DataSource = _alist.Values;
            this.gv_AccSTD.DataBind();
        }

        protected void Img_AddAccSTD_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel_SetAccSTDErr.Visible = false;
            TextBox Txt_SetAccSTDName = (TextBox)gv_AccSTD.FooterRow.FindControl("Txt_SetAccSTDName");
            if (Txt_SetAccSTDName.Text.Trim() == string.Empty || Txt_SetAccSTDName.Text.Trim() == "")
            {
                this.Lb_SetAccSTDErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุชื่ออุปกรณ์!";
                this.Panel_SetAccSTDErr.Visible = true;
                return;
            }

            if (Session["SetAccSTDList"] == null)
            {
                this._SetAccSTDList = new _AccessoriesSTDList();
            }

            _AccessoriesSTDList._AccessoriesSTD _acc = new _AccessoriesSTDList._AccessoriesSTD();
            int _c;
            if (this._SetAccSTDList.Count == 0)
            {
                _c = 1;
            }
            else
            {
                _c = this._SetAccSTDList.Keys.Max();
                _c = _c + 1;
            }
            _acc.ID = _c;
            _acc.Name = Txt_SetAccSTDName.Text.Trim();
            this._SetAccSTDList.Add(_c, _acc);
            Session["SetAccSTDList"] = this._SetAccSTDList;
            this.gv_AccSTD.DataSource = this._SetAccSTDList.Values;
            this.gv_AccSTD.DataBind();
            this.Empty_PriceSum();
        }

        protected void Img_AdAccDel_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gv = (GridViewRow)((ImageButton)sender).NamingContainer;
            int id = int.Parse(gv_AdAccessories.DataKeys[gv.RowIndex].Value.ToString());
            this._AdAccList.Remove(id);
            if (this._AdAccList.Count == 0)
            {
                this.AddEmptyData_AdAcc();
                this.SumAdAcc = 0;
                this.Lb_AdAccPrice.Text = "0";
            }
            else
            {
                this.gv_AdAccessories.DataSource = this._AdAccList.Values;
                this.gv_AdAccessories.DataBind();
                SumAdAcc = 0;
            }
            this.Empty_PriceSum();
            
        }

        private void AddEmptyData_AdAcc()
        {
            _AdAccessoriesList _alist = new _AdAccessoriesList();
            _AdAccessoriesList._AdAccessories temp = new _AdAccessoriesList._AdAccessories();
            _alist.Add(0, temp);
            this.gv_AdAccessories.DataSource = _alist.Values;
            this.gv_AdAccessories.DataBind();
        }

        protected void Img_AddAdAcc_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel_AdAccErr.Visible = false;
            TextBox Txt_AdAccName = (TextBox)gv_AdAccessories.FooterRow.FindControl("Txt_AdAccName");
            TextBox Txt_AdAccPrice = (TextBox)gv_AdAccessories.FooterRow.FindControl("Txt_AdAccPrice");
            CheckBox Cb_AdAccFree = (CheckBox)gv_AdAccessories.FooterRow.FindControl("Cb_AdAccFree");
            if (Txt_AdAccName.Text.Trim() == string.Empty || Txt_AdAccName.Text.Trim() == "")
            {
                this.Lb_AdAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุชื่ออุปกรณ์!";
                this.Panel_AdAccErr.Visible = true;
                return;
            }
            else if (Txt_AdAccPrice.Text.Trim() == string.Empty || Txt_AdAccPrice.Text.Trim() == "")
            {
                this.Lb_AdAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุราคา!";
                this.Panel_AdAccErr.Visible = true;
                return;
            }

            if (Session["AdAccList"] == null)
            {
                this._AdAccList = new _AdAccessoriesList();
            }

            _AdAccessoriesList._AdAccessories _Acc = new _AdAccessoriesList._AdAccessories();
            int _c;
            if (this._AdAccList.Count == 0)
            {
                _c = 1;
            }
            else
            {
                _c = this._AdAccList.Keys.Max();
                _c = _c + 1;
            }
            _Acc.ID = _c;
            _Acc.Name = Txt_AdAccName.Text.Trim();
            _Acc.Price = decimal.Parse(Txt_AdAccPrice.Text.Trim());
            if (Cb_AdAccFree.Checked == true)
            {
                _Acc.Free = "Y";
            }
            else
            {
                _Acc.Free = "N";
            }
            this._AdAccList.Add(_c, _Acc);
            Session["AdAccList"] = this._AdAccList;
            this.gv_AdAccessories.DataSource = this._AdAccList.Values;
            this.gv_AdAccessories.DataBind();
            this.Empty_PriceSum();
            SumAdAcc = 0;
        }

        protected void Img_DcDel_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gv = (GridViewRow)((ImageButton)sender).NamingContainer;
            int id = int.Parse(gv_Discount.DataKeys[gv.RowIndex].Value.ToString());
            this._DcList.Remove(id);
            if (this._DcList.Count == 0)
            {
                this.AddEmptyData_Dc();              
                this.Lb_PriceDiscount.Text = "0";
            }
            else
            {
                this.gv_Discount.DataSource = this._DcList.Values;
                this.gv_Discount.DataBind();
            }
            this.SumDc = 0;
            this.Empty_PriceSum();
        }

        private void AddEmptyData_Dc()
        {
            _DiscountList _alist = new _DiscountList();
            _DiscountList._Discount temp = new _DiscountList._Discount();
            _alist.Add(0, temp);
            this.gv_Discount.DataSource = _alist.Values;
            this.gv_Discount.DataBind();
        }

        protected void Img_DcAdd_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel_DiscountErr.Visible = false;
            TextBox Txt_DcName = (TextBox)gv_Discount.FooterRow.FindControl("Txt_DcName");
            TextBox Txt_DcPrice = (TextBox)gv_Discount.FooterRow.FindControl("Txt_DcPrice");
            if (Txt_DcName.Text.Trim() == string.Empty || Txt_DcName.Text.Trim() == "")
            {
                this.Lb_DiscountErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุรายการส่วนลด!";
                this.Panel_DiscountErr.Visible = true;
                return;
            }
            else if (Txt_DcPrice.Text.Trim() == string.Empty || Txt_DcPrice.Text.Trim() == "")
            {
                this.Lb_DiscountErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุราคา!";
                this.Panel_DiscountErr.Visible = true;
                return;
            }

            if (Session["DcList"] == null)
            {
                this._DcList = new _DiscountList();
            }

            _DiscountList._Discount _Dc = new _DiscountList._Discount();
            int _c;
            if (this._DcList.Count == 0)
            {
                _c = 1;
            }
            else
            {
                _c = this._DcList.Keys.Max();
                _c = _c + 1;
            }
            _Dc.ID = _c;
            _Dc.Name = "ส่วนลด " + Txt_DcName.Text.Trim();
            _Dc.Price = decimal.Parse(Txt_DcPrice.Text.Trim());
            this._DcList.Add(_c, _Dc);
            Session["DcList"] = this._DcList;
            this.gv_Discount.DataSource = this._DcList.Values;
            this.gv_Discount.DataBind();
            this.Empty_PriceSum();
        }

        protected void Img_EditAcc_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Control item in this.Panel_Accessories.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)(item)).Enabled = true;
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)(item)).Enabled = true;
                }
                else if (item is DropDownList)
                {
                    ((DropDownList)(item)).Enabled = true;
                }
            }
            this.gv_SetAccessories.Columns[2].Visible = true;
            this.gv_SetAccessories.ShowFooter = true;
            this.gv_SetAccessories.FooterRow.Visible = true;
            this.gv_AccSTD.Columns[2].Visible = true;
            this.gv_AccSTD.ShowFooter = true;
            this.gv_AccSTD.FooterRow.Visible = true;
            this.gv_AdAccessories.Columns[4].Visible = true;
            this.gv_AdAccessories.ShowFooter = true;
            this.gv_AdAccessories.FooterRow.Visible = true;
            this.gv_Discount.Columns[3].Visible = true;
            this.gv_Discount.ShowFooter = true;
            this.gv_Discount.FooterRow.Visible = true;
            this.Panel_EditAcc.Visible = false;
            this.Panel_SaveAcc.Visible = true;
            this.Panel_EditAccPsumPrice.Visible = true;
        }

        protected void Img_CancelAcc_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Control item in this.Panel_Accessories.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)(item)).Enabled = false;
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)(item)).Enabled = false;
                }
                else if (item is DropDownList)
                {
                    ((DropDownList)(item)).Enabled = false;
                }
            }
            this.gv_SetAccessories.Columns[2].Visible = false;
            this.gv_SetAccessories.ShowFooter = false;
            this.gv_SetAccessories.FooterRow.Visible = false;
            this.gv_AccSTD.Columns[2].Visible = false;
            this.gv_AccSTD.ShowFooter = false;
            this.gv_AccSTD.FooterRow.Visible = false;
            this.gv_AdAccessories.Columns[4].Visible = false;
            this.gv_AdAccessories.ShowFooter = false;
            this.gv_AdAccessories.FooterRow.Visible = false;
            this.gv_Discount.Columns[3].Visible = false;
            this.gv_Discount.ShowFooter = false;
            this.gv_Discount.FooterRow.Visible = false;
            this.Panel_EditAcc.Visible = true;
            this.Panel_SaveAcc.Visible = false;
            this.Panel_EditAccPsumPrice.Visible = false;
        }

        private void Cal_Payment()
        {
            this.Txt_Price_Payment.Text = string.Empty;
            this.Empty_PriceSum();
            decimal _lblsumfin = decimal.Parse(this.lblsumfin.Text.Trim());
            decimal _PriceCar = decimal.Parse(this.Txt_CarPrice1.Text.Trim());
            decimal _Total = 0;
            if (this.Txt_CarPriceAd_Price.Text.Trim() != string.Empty)
            {
                _PriceCar = _PriceCar + _lblsumfin + decimal.Parse(this.Txt_CarPriceAd_Price.Text.Trim());
            }
            else
            {
                this.Txt_CarPriceAd_Price.Text = "0";
            }

            if (this.Txt_PayDown.Text.Trim() != string.Empty)
            {
                decimal _Down = decimal.Parse(this.Txt_PayDown.Text.Trim());
                _Total = _PriceCar - _Down;
            }
            else
            {
                this.Txt_PayDown.Text = "0";
            }

            this.Txt_DPeak.Text = String.Format("{0:#,###.##}", Math.Ceiling(_Total));

            if (this.Txt_LoanProtection.Text.Trim() != string.Empty)
            {
                decimal _LP = decimal.Parse(this.Txt_LoanProtection.Text.Trim());
                _Total = _Total + _LP;
            }
            else
            {
                this.Txt_LoanProtection.Text = "0";
            }

            this.Txt_hpcost.Text = String.Format("{0:#,###.##}", Math.Ceiling(_Total));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);

            //this.Txt_Price_Payment.Text = string.Empty;
            //this.Txt_PriceSum.Text = string.Empty;
            //decimal _PriceCar = decimal.Parse(this.Txt_CarPrice1.Text.Trim());
            //decimal _lblsumfin = decimal.Parse(this.lblsumfin.Text.Trim());
            //decimal _Total = 0;
            //if (this.Txt_CarPriceAd_Price.Text.Trim() != string.Empty)
            //{
            //    _PriceCar = _PriceCar + _lblsumfin + decimal.Parse(this.Txt_CarPriceAd_Price.Text.Trim());
            //}
            //else
            //{
            //    this.Txt_CarPriceAd_Price.Text = "0";
            //}

            //if (this.Txt_PayDown.Text.Trim() != string.Empty)
            //{
            //    decimal _Down = decimal.Parse(this.Txt_PayDown.Text.Trim());
            //    _Total = _PriceCar - _Down;
            //}
            //else
            //{
            //    this.Txt_PayDown.Text = "0";
            //}

            //this.Txt_DPeak.Text = String.Format("{0:#,###.##}", Math.Ceiling(_Total));

            //if (this.Txt_LoanProtection.Text.Trim() != string.Empty)
            //{
            //    decimal _LP = decimal.Parse(this.Txt_LoanProtection.Text.Trim());
            //    _Total = _Total + _LP;
            //}
            //else
            //{
            //    this.Txt_LoanProtection.Text = "0";
            //}

            //this.Txt_hpcost.Text = String.Format("{0:#,###.##}", Math.Ceiling(_Total));
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }

        protected void Txt_CarPriceDetail_Price_TextChanged(object sender, EventArgs e)
        {
            this.Cal_Payment();
        }

        protected void Txt_PayDown_TextChanged(object sender, EventArgs e)
        {
            this.Cal_Payment();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "document.getElementById('" + ((TextBox)sender).ClientID + "').focus();", true);
            
        }

        protected void Txt_LoanProtection_TextChanged(object sender, EventArgs e)
        {
            this.Cal_Payment();
        }

        protected void Img_Cal_Click(object sender, ImageClickEventArgs e)
        {
            this.Cal();
        }

        private void Cal()
        {
            if (this.DD_Finance.SelectedItem.Text != "เงินสด")
            {
                decimal _Interest = 0;
                if (this.Txt_Interest.Text != string.Empty)
                {
                    _Interest = decimal.Parse(this.Txt_Interest.Text);
                }
                else
                {
                    this.Txt_Interest.Text = "0";
                }

                decimal _SumPeak = decimal.Parse(this.Txt_hpcost.Text);
                int _NumYear = (int.Parse(this.DD_Total_Payment.SelectedValue) / 12);
                decimal OneYear = (_SumPeak * _Interest) / 100;
                decimal _Year = OneYear * _NumYear;
                decimal Amount = _SumPeak + _Year;
                decimal _Sum = decimal.Parse((Amount / int.Parse(this.DD_Total_Payment.SelectedValue)).ToString());
                this.Txt_Price_Payment.Text = String.Format("{0:#,###.##}", Math.Ceiling(_Sum));
            }
        }

        protected void Txt_DepositDate_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_DepositDate.Text.Trim() != string.Empty)
            {
                this.Chk_KeyDate(this.Txt_DepositDate);
            }
        }

        public void Chk_KeyDate(TextBox Txt)
        {
            bool complete = false;
            DateTime _Chkdate = DateTime.MinValue;
            complete = DateTime.TryParse(Txt.Text, out _Chkdate);
            if (complete == false)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('รูปแบบวันที่ไม่ถูกต้อง กรุณาตรวจสอบ!');", true);
            }
            else
            {
                Txt.Text = _Chkdate.ToString("dd MMM yy");
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }

        protected void Txt_RedCarPlate_Date_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_RedCarPlate_Date.Text.Trim() != string.Empty)
            {
                this.Chk_KeyDate(this.Txt_RedCarPlate_Date);
            }
        }

        protected void Img_CalSum_Click(object sender, ImageClickEventArgs e)
        {
            decimal _PriceSum = 0;
            decimal _Txt_CarPriceAd_Price = 0;
            decimal _sumAddfinance = 0;
            this.Panel_ConfirmAccErr.Visible = false;
            if (this.DD_Finance.SelectedValue == "1") //เงินสด
            {
                
                _Txt_CarPriceAd_Price = decimal.Parse(this.Txt_CarPriceAd_Price.Text.Trim());
                _sumAddfinance = decimal.Parse(this.Lb_sumAddfinance.Text.Trim());
                _PriceSum = _Txt_CarPriceAd_Price + _sumAddfinance + decimal.Parse(this.Txt_ECarPrice.Text.Trim());
            }
            else //ผ่อนชำระ
            {
                if (this.Txt_Price_Payment.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาค่าใช้จ่ายต่องวด!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }

                if (this.Txt_PayDown.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาเงินดาวน์!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }

                //--------บวกBodyเสริม--------------------
                decimal _Budgetpaybody = decimal.Parse(this.Lb_Budgetpaybody.Text.Trim());
                _PriceSum = _Budgetpaybody + decimal.Parse(this.Txt_PayDown.Text.Trim());
                //-----------------------------------

                if (this.Cb_Begin.Checked == true)
                {
                    if (this.Cb_Begin.Checked == true && this.Txt_Pay_Begin.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาจำนวนงวดชำระล่วงหน้า!";
                        this.Panel_ConfirmAccErr.Visible = true;
                        return;
                    }
                    else
                    {
                        _PriceSum = _PriceSum + (decimal.Parse(this.Txt_Price_Payment.Text.Trim()) * decimal.Parse(this.Txt_Pay_Begin.Text.Trim()));
                    }
                }
            }

            if (this.Txt_DepositPrice.Text.Trim() != string.Empty)
            {
                _PriceSum = _PriceSum - decimal.Parse(this.Txt_DepositPrice.Text.Trim());
            }
            if (this.Txt_DepositAdPrice.Text.Trim() != string.Empty)
            {
                _PriceSum = _PriceSum - decimal.Parse(this.Txt_DepositAdPrice.Text.Trim());
            }
            if (this.Txt_RedCarPlate_Price.Text.Trim() != string.Empty)
            {
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_RedCarPlate_Price.Text.Trim());
            }

            if (this.Cb_Insurance1.Checked == true && this.Cb_InFree.Checked == false)
            {
                if (this.Txt_InPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาประกันประเภท1!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_InPrice.Text.Trim());
            }

            if (this.Cb_Regis.Checked == true && this.Cb_RegisFree.Checked == false)
            {
                if (this.Txt_RegisPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาค่าจดทะเบียน!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_RegisPrice.Text.Trim());
            }

            if (this.Cb_Act.Checked == true && this.Cb_ActFree.Checked == false)
            {
                if (this.Txt_ActPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคา พ.ร.บ!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_ActPrice.Text.Trim());
            }

            if (this.Cb_Transpot.Checked == true && this.Cb_TranspotFree.Checked == false)
            {
                if (this.Txt_TranspotPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาค่าขนส่ง!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_TranspotPrice.Text.Trim());
            }

            if (this.Cb_SetAcc.Checked == true && this.Cb_SetAccFree.Checked == false)
            {
                if (this.Txt_SetAccPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาชุดอุปกรณ์ตกแต่ง!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_SetAccPrice.Text.Trim());
            }

            if (this.Cb_AccSTD.Checked == true && this.Cb_AccSTDFree.Checked == false)
            {
                if (this.Txt_AccSTDPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาอุปกรณ์มาตรฐานSTD!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_AccSTDPrice.Text.Trim());
            }

            _PriceSum = _PriceSum + decimal.Parse(this.Lb_AdAccPrice.Text);
            _PriceSum = _PriceSum - decimal.Parse(this.Lb_PriceDiscount.Text);

            if (this.Txt_RedCarPlate_Price.Text.Trim() != string.Empty)
            {
                decimal _PriceSumCar = _PriceSum - decimal.Parse(this.Txt_RedCarPlate_Price.Text.Trim());
                this.Txt_PriceSumCar.Text = String.Format("{0:#,###.##}", Math.Ceiling(_PriceSumCar));
                this.Txt_EditAcc_PriceSumCar.Text = this.Txt_PriceSumCar.Text;
            }
            else
            {
                this.Txt_PriceSumCar.Text = String.Format("{0:#,###.##}", Math.Ceiling(_PriceSum));
                this.Txt_EditAcc_PriceSumCar.Text = this.Txt_PriceSumCar.Text;
            }

            this.Txt_PriceSum.Text = String.Format("{0:#,###.##}", Math.Ceiling(_PriceSum));
            this.Txt_EditAcc_PriceSum.Text = this.Txt_PriceSum.Text;
        }

        protected void Cb_Insurance1_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        private void Empty_PriceSum()
        {
            this.Txt_EditAcc_PriceSumCar.Text = string.Empty;
            this.Txt_EditAcc_PriceSum.Text = string.Empty;
            this.Txt_PriceSumCar.Text = string.Empty;
            this.Txt_PriceSum.Text = string.Empty;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }

        protected void Img_EditAcc_CalSum_Click(object sender, ImageClickEventArgs e)
        {
            decimal _PriceSum = 0;
            this.Panel_ConfirmAccErr.Visible = false;
            if (this.DD_Finance.SelectedValue == "1") //เงินสด
            {


                _PriceSum = decimal.Parse(this.Txt_ECarPrice.Text.Trim());


            }
            else //ผ่อนชำระ
            {
                if (this.Txt_Price_Payment.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาค่าใช้จ่ายต่องวด!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }

                if (this.Txt_PayDown.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาเงินดาวน์!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = decimal.Parse(this.Txt_PayDown.Text.Trim());

                if (this.Cb_Begin.Checked == true)
                {
                    if (this.Cb_Begin.Checked == true && this.Txt_Pay_Begin.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาจำนวนงวดชำระล่วงหน้า!";
                        this.Panel_ConfirmAccErr.Visible = true;
                        return;
                    }
                    else
                    {
                        _PriceSum = _PriceSum + (decimal.Parse(this.Txt_Price_Payment.Text.Trim()) * decimal.Parse(this.Txt_Pay_Begin.Text.Trim()));
                    }
                }
            }

            if (this.Txt_DepositPrice.Text.Trim() != string.Empty)
            {
                _PriceSum = _PriceSum - decimal.Parse(this.Txt_DepositPrice.Text.Trim());
            }
            if (this.Txt_DepositAdPrice.Text.Trim() != string.Empty)
            {
                _PriceSum = _PriceSum - decimal.Parse(this.Txt_DepositAdPrice.Text.Trim());
            }
            if (this.Txt_RedCarPlate_Price.Text.Trim() != string.Empty)
            {
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_RedCarPlate_Price.Text.Trim());
            }

            if (this.Cb_Insurance1.Checked == true && this.Cb_InFree.Checked == false)
            {
                if (this.Txt_InPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาประกันประเภท1!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_InPrice.Text.Trim());
            }

            if (this.Cb_Regis.Checked == true && this.Cb_RegisFree.Checked == false)
            {
                if (this.Txt_RegisPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาค่าจดทะเบียน!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_RegisPrice.Text.Trim());
            }

            if (this.Cb_Act.Checked == true && this.Cb_ActFree.Checked == false)
            {
                if (this.Txt_ActPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคา พ.ร.บ!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_ActPrice.Text.Trim());
            }

            if (this.Cb_Transpot.Checked == true && this.Cb_TranspotFree.Checked == false)
            {
                if (this.Txt_TranspotPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาค่าขนส่ง!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_TranspotPrice.Text.Trim());
            }

            if (this.Cb_SetAcc.Checked == true && this.Cb_SetAccFree.Checked == false)
            {
                if (this.Txt_SetAccPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาชุดอุปกรณ์ตกแต่ง!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_SetAccPrice.Text.Trim());
            }

            if (this.Cb_AccSTD.Checked == true && this.Cb_AccSTDFree.Checked == false)
            {
                if (this.Txt_AccSTDPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาอุปกรณ์มาตรฐานSTD!";
                    this.Panel_ConfirmAccErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_AccSTDPrice.Text.Trim());
            }
            //------------------------------------------Body
            decimal _Budgetpaybody = decimal.Parse(this.Lb_Budgetpaybody.Text.Trim());

            _PriceSum = _PriceSum + _Budgetpaybody + decimal.Parse(this.Lb_AdAccPrice.Text);
            _PriceSum = _PriceSum - decimal.Parse(this.Lb_PriceDiscount.Text);

            if (this.Txt_RedCarPlate_Price.Text.Trim() != string.Empty)
            {
                decimal _PriceSumCar = _PriceSum - decimal.Parse(this.Txt_RedCarPlate_Price.Text.Trim());
                this.Txt_PriceSumCar.Text = String.Format("{0:#,###.##}", Math.Ceiling(_PriceSumCar));
                this.Txt_EditAcc_PriceSumCar.Text = this.Txt_PriceSumCar.Text;
            }
            else
            {
                this.Txt_PriceSumCar.Text = String.Format("{0:#,###.##}", Math.Ceiling(_PriceSum));
                this.Txt_EditAcc_PriceSumCar.Text = this.Txt_PriceSumCar.Text;
            }

            this.Txt_PriceSum.Text = String.Format("{0:#,###.##}", Math.Ceiling(_PriceSum));
            this.Txt_EditAcc_PriceSum.Text = this.Txt_PriceSum.Text;
        }

        protected void DD_Insurance_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Txt_InPrice_TextChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Cb_InFree_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Cb_Regis_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void DD_Regis_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Txt_RegisPrice_TextChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Cb_RegisFree_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Cb_Act_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Txt_ActPrice_TextChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Cb_ActFree_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Cb_Transpot_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Txt_TranspotPrice_TextChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Cb_TranspotFree_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Cb_SetAcc_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Txt_SetAccPrice_TextChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Cb_SetAccFree_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Cb_AccSTD_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Txt_AccSTDPrice_TextChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Cb_AccSTDFree_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Img_SaveAcc_Click(object sender, ImageClickEventArgs e)
        {
            if (this.Txt_EditAcc_PriceSum.Text.Trim() == string.Empty)
            {
                this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ : กรุณารวมยอดเงินที่ลูกค้าจะต้องชำระ!";
                this.Panel_ConfirmAccErr.Visible = true;
                return;
            }

            _Purchase _p = new _Purchase();
            _p.ID = int.Parse(this.Lb_EPOID.Text);
            _p.Chk_UpAcc = "Y";
            if (this.Cb_Insurance1.Checked == true)
            {
                _p.ChkIn1 = "Y";
                _p._Insurance1._Insurane.ID = int.Parse(this.DD_Insurance.SelectedValue);
                _p._Insurance1._Insurane.Name = this.DD_Insurance.SelectedItem.Text;
                if (this.Txt_InOutlay.Text != "0" && this.Txt_InOutlay.Text.Trim() != string.Empty)
                {
                    _p._Insurance1.Outlay = decimal.Parse(this.Txt_InOutlay.Text.Trim());
                }
                if (this.Txt_InPrice.Text != "0" && this.Txt_InPrice.Text.Trim() != string.Empty)
                {
                    _p._Insurance1.Price = decimal.Parse(this.Txt_InPrice.Text.Trim());
                }
                if (this.Cb_InFree.Checked == true)
                {
                    _p._Insurance1.Free = "Y";
                }
            }

            if (this.Cb_Regis.Checked == true)
            {
                _p.ChkRegis = "Y";
                _p._Regis.Name = this.DD_Regis.SelectedValue;
                if (this.Txt_RegisPrice.Text != "0" && this.Txt_RegisPrice.Text.Trim() != string.Empty)
                {
                    _p._Regis.Price = decimal.Parse(this.Txt_RegisPrice.Text.Trim());
                }
                if (this.Cb_RegisFree.Checked == true)
                {
                    _p._Regis.Free = "Y";
                }
            }

            if (this.Cb_Act.Checked == true)
            {
                _p.ChkAct = "Y";
                _p._Act.ActNo = this.Txt_ActNo.Text.Trim();
                if (this.Txt_ActPrice.Text != "0" && this.Txt_ActPrice.Text.Trim() != string.Empty)
                {
                    _p._Act.Price = decimal.Parse(this.Txt_ActPrice.Text.Trim());
                }
                if (this.Cb_ActFree.Checked == true)
                {
                    _p._Act.Free = "Y";
                }
            }

            if (this.Cb_Transpot.Checked == true)
            {
                _p.ChkTranspot = "Y";
                if (this.Txt_TranspotPrice.Text != "0" && this.Txt_TranspotPrice.Text.Trim() != string.Empty)
                {
                    _p._Transpot.Price = decimal.Parse(this.Txt_TranspotPrice.Text.Trim());
                }
                if (this.Cb_TranspotFree.Checked == true)
                {
                    _p._Transpot.Free = "Y";
                }
            }

            if (this.Cb_SetAcc.Checked == true)
            {
                _p.ChkSetAcc = "Y";
                if (this.Txt_SetAccPrice.Text != "0" && this.Txt_SetAccPrice.Text.Trim() != string.Empty)
                {
                    _p._SetAcc.Price = decimal.Parse(this.Txt_SetAccPrice.Text.Trim());
                }
                if (this.Cb_SetAccFree.Checked == true)
                {
                    _p._SetAcc.Free = "Y";
                }
                _p._SetAccList = this._SetAccList;
            }

            if (this.Cb_AccSTD.Checked == true)
            {
                _p.ChkSetAccSTD = "Y";
                if (this.Txt_AccSTDPrice.Text != "0")
                {
                    _p._SetAccSTD.Price = decimal.Parse(this.Txt_AccSTDPrice.Text.Trim());
                }       
                if (this.Cb_AccSTDFree.Checked == true)
                {
                    _p._SetAccSTD.Free = "Y";
                }
                _p._SetAccSTDList = this._SetAccSTDList;
            }

            if (Session["AdAccList"] == null)
            {
                this._AdAccList = new _AdAccessoriesList();
            }

            if (this._AdAccList.Count != 0)
            {
                _p.ChkSetAddAcc = "Y";
                if (this.Lb_AdAccPrice.Text != "0")
                {
                    _p._AddAcc.Price = decimal.Parse(this.Lb_AdAccPrice.Text.Trim());
                }
                _p._SetAddAccList = this._AdAccList;
            }

            if (Session["DcList"] == null)
            {
                this._DcList = new _DiscountList();
            }

            if (this._DcList.Count != 0)
            {
                _p.ChkDc = "Y";
                _p._DcList = this._DcList;
            }

            _p.ChkP = "Y";
            if (this.Txt_EditAcc_PriceSumCar.Text.Trim() != "0" && this.Txt_EditAcc_PriceSumCar.Text.Trim() != string.Empty)
            {
                _p.PriceSumCar = decimal.Parse(this.Txt_EditAcc_PriceSumCar.Text.Trim());
            }

            if (this.Txt_EditAcc_PriceSum.Text.Trim() != "0" && this.Txt_EditAcc_PriceSum.Text.Trim() != string.Empty)
            {
                _p.PriceSum = decimal.Parse(this.Txt_EditAcc_PriceSum.Text.Trim());
            }

            _p.User_Edit = (int)Session["Emp_id"];
            try
            {
                _p.UPDATE_Purchase(11, _p);
            }
            catch (Exception err)
            {
                this.Lb_ConfirmAccErr.Text = "ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :" + err.Message;
                this.Panel_ConfirmAccErr.Visible = true;
                return;
            }

            foreach (Control item in this.Panel_Accessories.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)(item)).Enabled = false;
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)(item)).Enabled = false;
                }
                else if (item is DropDownList)
                {
                    ((DropDownList)(item)).Enabled = false;
                }
            }
            this.gv_SetAccessories.Columns[2].Visible = false;
            this.gv_SetAccessories.ShowFooter = false;
            this.gv_SetAccessories.FooterRow.Visible = false;
            this.gv_AccSTD.Columns[2].Visible = false;
            this.gv_AccSTD.ShowFooter = false;
            this.gv_AccSTD.FooterRow.Visible = false;
            this.gv_AdAccessories.Columns[4].Visible = false;
            this.gv_AdAccessories.ShowFooter = false;
            this.gv_AdAccessories.FooterRow.Visible = false;
            this.gv_Discount.Columns[3].Visible = false;
            this.gv_Discount.ShowFooter = false;
            this.gv_Discount.FooterRow.Visible = false;
            this.Panel_EditAcc.Visible = true;
            this.Panel_SaveAcc.Visible = false;
            this.Panel_EditAccPsumPrice.Visible = false;
        }

        protected void Img_EditFinance_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Control item in this.Panel_Finance.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)(item)).Enabled = true;
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)(item)).Enabled = true;
                }
                else if (item is DropDownList)
                {
                    ((DropDownList)(item)).Enabled = true;
                }
            }

            this.Img_DepositDate.Visible = true;
            this.Img_DepositAdDate.Visible = true;
            this.Img_RedCarPlate_Date.Visible = true;
            this.Img_CalSum.Visible = true;
            this.Img_Cal.Visible = true;
            this.Panel_EditFinance.Visible = false;
            this.Panel_SaveFinance.Visible = true;
            this.Txt_Remark.Enabled = false;
            this.Cb_C_IDCard.Enabled = false;
            this.Cb_C_HouseRegistration.Enabled = false;
            this.Cb_C_Scrape.Enabled = false;
            this.Cb_C_ActInsurance.Enabled = false;
            this.Cb_C_Finance.Enabled = false;
            this.Cb_C_CVIP.Enabled = false;
        }

        protected void Image_editbody_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Control item in this.Panel_Finance.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)(item)).Enabled = true;
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)(item)).Enabled = true;
                }
                else if (item is DropDownList)
                {
                    ((DropDownList)(item)).Enabled = true;
                }
            }
            this.Rb_bodystandard.Enabled = true;
            this.Rb_bodyextra.Enabled = true;


                this.gv_bodyshow.Columns[3].Visible = true;
                this.gv_bodyshow.ShowFooter = true;
                this.gv_bodyshow.FooterRow.Visible = true;
                this.DD_body.Enabled = true;


                this.ddl_Body_Company.Enabled = true;
                this.txt_bodyextra.Enabled = true;
                this.Txt_bodyextraPrice.Enabled = true;
                this.gv_bodyextra.Columns[3].Visible = true;
                this.gv_bodyextra.ShowFooter = true;
                this.gv_bodyextra.FooterRow.Visible = true;


            this.Img_DepositDate.Visible = true;
            this.Img_DepositAdDate.Visible = true;
            this.Img_RedCarPlate_Date.Visible = true;
            this.Img_CalSum.Visible = true;
            this.Img_Cal.Visible = true;
            this.Panel_EditFinance.Visible = false;
            this.Panel_SaveFinance.Visible = true;
            this.Txt_Remark.Enabled = false;
            this.Cb_C_IDCard.Enabled = false;
            this.Cb_C_HouseRegistration.Enabled = false;
            this.Cb_C_Scrape.Enabled = false;
            this.Cb_C_ActInsurance.Enabled = false;
            this.Cb_C_Finance.Enabled = false;
            this.Cb_C_CVIP.Enabled = false;
            


        }

        protected void Img_CancelFinance_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Control item in this.Panel_Finance.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)(item)).Enabled = false;
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)(item)).Enabled = false;
                }
                else if (item is DropDownList)
                {
                    ((DropDownList)(item)).Enabled = false;
                }
            }

            this.Img_DepositDate.Visible = false;
            this.Img_DepositAdDate.Visible = false;
            this.Img_RedCarPlate_Date.Visible = false;
            this.Img_CalSum.Visible = false;
            this.Img_Cal.Visible = false;
            this.Panel_EditFinance.Visible = true;
            this.Panel_SaveFinance.Visible = false;
        }

        protected void DD_Finance_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Txt_Interest_TextChanged(object sender, EventArgs e)
        {
            this.Txt_Price_Payment.Text = string.Empty;
            this.Empty_PriceSum();
        }

        protected void DD_Total_Payment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Txt_Price_Payment.Text = string.Empty;
            this.Empty_PriceSum();
        }

        protected void Img_SaveFinance_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel_ConfirmFinanceErr.Visible = false;
            if (this.DD_Finance.SelectedValue != "1")
            {
                if (this.Txt_Price_Payment.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณาคำนวณค่าใช้จ่ายต่องวด!";
                    this.Panel_ConfirmFinanceErr.Visible = true;
                    return;
                }
            }
            if (this.Txt_PriceSum.Text.Trim() == string.Empty)
            {
                this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณารวมยอดเงินที่ลูกค้าจะต้องชำระ!";
                this.Panel_ConfirmFinanceErr.Visible = true;
                return;
            }

            #region เช็คข้อมูลไฟแนนซ์
            if (this.DD_Finance.SelectedValue != "1")
            {
                if (this.Txt_EmpFinance.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุชื่อเจ้าหน้าที่ไฟแนนซ์!";
                    this.Panel_ConfirmFinanceErr.Visible = true;
                    return;
                }
                if ((this.Txt_CarPriceAd_Price.Text.Trim() != string.Empty && this.Txt_CarPriceAd_Price.Text.Trim() != "0"))
                {
                    if (this.Txt_CarPriceAd.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุรายละเอียดราคารถยนต์เพิ่มเติม!";
                        this.Panel_ConfirmFinanceErr.Visible = true;
                        return;
                    }
                }
                if (this.Txt_PayDown.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจำนวนเงินดาวน์!";
                    this.Panel_ConfirmFinanceErr.Visible = true;
                    return;
                }

                if (this.Txt_Interest.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุดอกเบี้ย!";
                    this.Panel_ConfirmFinanceErr.Visible = true;
                    return;
                }

                if (this.Cb_Begin.Checked == true && this.Txt_Pay_Begin.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจำนวนงวดชำระล่วงหน้า!";
                    this.Panel_ConfirmFinanceErr.Visible = true;
                    return;
                }
            }
            else
            {

            }
            #endregion

            #region เช็คข้อมูลค่ามัดจำ
            if (this.Txt_DepositNo.Text.Trim() != string.Empty || this.Txt_DepositDate.Text.Trim() != string.Empty || this.Txt_DepositPrice.Text.Trim() != string.Empty)
            {
                if (this.Txt_DepositNo.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขที่ใบเสร็จค่ามัดจำ!";
                    this.Panel_ConfirmFinanceErr.Visible = true;
                    return;
                }
                if (this.Txt_DepositDate.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันที่มัดจำ!";
                    this.Panel_ConfirmFinanceErr.Visible = true;
                    return;
                }
                if (this.Txt_DepositPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจำนวนเงินค่ามัดจำ!";
                    this.Panel_ConfirmFinanceErr.Visible = true;
                    return;
                }
            }
            #endregion

            #region เช็คข้อมูลค่ามัดจำ
            if (this.Txt_DepositAdNo.Text.Trim() != string.Empty || this.Txt_DepositAdDate.Text.Trim() != string.Empty || this.Txt_DepositAdPrice.Text.Trim() != string.Empty)
            {
                if (this.Txt_DepositAdNo.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขที่ใบเสร็จค่ามัดจำเพิ่มเติม!";
                    this.Panel_ConfirmFinanceErr.Visible = true;
                    return;
                }
                if (this.Txt_DepositAdDate.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันที่มัดจำเพิ่มเติม!";
                    this.Panel_ConfirmFinanceErr.Visible = true;
                    return;
                }
                if (this.Txt_DepositAdPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจำนวนเงินค่ามัดจำเพิ่มเติม!";
                    this.Panel_ConfirmFinanceErr.Visible = true;
                    return;
                }
            }
            #endregion

            _Purchase _p = new _Purchase();
            _p.ID = int.Parse(this.Lb_EPOID.Text);
            _p.ChkP = "Y";
            if (this.DD_Finance.SelectedValue != "1")
            {
                _p._Finance.ID = int.Parse(this.DD_Finance.SelectedValue);
                _p.Emp_Finance = this.Txt_EmpFinance.Text.Trim();

                if (this.Txt_PayDown.Text != "0" && this.Txt_PayDown.Text.Trim() != string.Empty)
                {
                    _p.PayDown = decimal.Parse(this.Txt_PayDown.Text.Trim());
                }


                if (this.Txt_LoanProtection.Text != "0" && this.Txt_LoanProtection.Text != string.Empty)
                {
                    _p.LoanProtection = decimal.Parse(this.Txt_LoanProtection.Text.Trim());
                }
                if (this.Txt_DPeak.Text != "0")
                {
                    _p.DPeak = decimal.Parse(this.Txt_DPeak.Text.Trim());
                }
                if (this.Txt_hpcost.Text != "0")
                {
                    _p.hpcost = decimal.Parse(this.Txt_hpcost.Text.Trim());
                }
                if (this.Txt_Interest.Text != "0")
                {
                    _p.Interest = decimal.Parse(this.Txt_Interest.Text.Trim());
                }

                _p.Remark_Interest = this.Txt_RemarkInterest.Text.Trim();
                if (this.Cb_Begin.Checked == true)
                {
                    _p.Pay_Begin = int.Parse(this.Txt_Pay_Begin.Text.Trim());
                }
                _p.Total_Payment = int.Parse(this.DD_Total_Payment.SelectedValue);
                if (this.Txt_Price_Payment.Text != "0")
                {
                    _p.Price_Payment = decimal.Parse(this.Txt_Price_Payment.Text.Trim());
                }

            }
            else
            {
                _p._Finance.ID = int.Parse(this.DD_Finance.SelectedValue);
            }
            _p.CampaignName = this.Txt_CampaignName.Text.Trim();
            _p.DepositNo = this.Txt_DepositNo.Text.Trim();
            //------------------------------------------------
            if (this.DD_body.SelectedValue != "0" || this.DD_body.SelectedValue == string.Empty)
            {
                _p.Body_Acc_ID = int.Parse(this.DD_body.SelectedValue);
            }

            if (Rb_bodystandard.Checked == true)
            {
                _p.Body_Type = "S";
            }
            else if (Rb_bodyextra.Checked == true)
            {
                _p.Body_Type = "E";
            }
            else
            {
                _p.Body_Type = "N";
            }
            if (this.ddl_Body_Company.SelectedValue != "0" || this.ddl_Body_Company.SelectedValue == string.Empty)
            {
                _p.Body_Extra_Company = int.Parse(this.ddl_Body_Company.SelectedValue);
            }

            _p.CarPriceAd = this.Txt_CarPriceAd.Text.Trim();
            if (this.Txt_CarPriceAd_Price.Text != "0" && this.Txt_CarPriceAd_Price.Text != string.Empty)
            {
                _p.CarPriceAd_Price = decimal.Parse(this.Txt_CarPriceAd_Price.Text.Trim());
            }
           
            if (this.lblsumfin.Text != "0" && this.lblsumfin.Text != string.Empty)
            {
                _p.Body_Price_finance = decimal.Parse(this.lblsumfin.Text.Trim());
            }
            if (this.Lb_Budgetpaybody.Text != "0" && this.Lb_Budgetpaybody.Text != string.Empty)
            {
                _p.Body_Price_Pay = decimal.Parse(this.Lb_Budgetpaybody.Text.Trim());
            }
            if (this.Lb_sumAddfinance.Text != "0" && this.Lb_sumAddfinance.Text != string.Empty)
            {
                _p.Body_Price_SumAddBody = decimal.Parse(this.Lb_sumAddfinance.Text.Trim());
            }
            //----------------------

            if (this.Txt_DepositDate.Text.Trim() != string.Empty)
            {
                DateTime _DepositDate = DateTime.MinValue;
                DateTime.TryParse(this.Txt_DepositDate.Text, out _DepositDate);
                _p.DepositDate = _DepositDate;
            }

            if (this.Txt_DepositPrice.Text != "0")
            {
                _p.DepositPrice = decimal.Parse(this.Txt_DepositPrice.Text.Trim());
            }

            _p.DepositAdNo = this.Txt_DepositAdNo.Text.Trim();

            if (this.Txt_DepositAdDate.Text.Trim() != string.Empty)
            {
                DateTime _DepositAdDate = DateTime.MinValue;
                DateTime.TryParse(this.Txt_DepositAdDate.Text, out _DepositAdDate);
                _p.DepositAdDate = _DepositAdDate;
            }

            if (this.Txt_DepositAdPrice.Text != "0" && this.Txt_DepositAdPrice.Text != string.Empty)
            {
                _p.DepositAdPrice = decimal.Parse(this.Txt_DepositAdPrice.Text.Trim());
            }

            if (this.Txt_PriceSumCar.Text.Trim() != "0")
            {
                _p.PriceSumCar = decimal.Parse(this.Txt_PriceSumCar.Text.Trim());
            }

            if (this.Txt_PriceSum.Text.Trim() != "0")
            {
                _p.PriceSum = decimal.Parse(this.Txt_PriceSum.Text.Trim());
            }

            _p.RedCarPlate_No = this.Txt_RedCarPlate_No.Text.Trim();
            if (this.Txt_RedCarPlate_Date.Text.Trim() != string.Empty)
            {
                DateTime _RedCarPlateDate = DateTime.MinValue;
                DateTime.TryParse(this.Txt_RedCarPlate_Date.Text, out _RedCarPlateDate);
                _p.RedCarPlate_Date = _RedCarPlateDate;
            }
            if (this.Txt_RedCarPlate_Price.Text.Trim() != string.Empty && this.Txt_RedCarPlate_Price.Text.Trim() != "0")
            {
                _p.RedCarPlate_Price = decimal.Parse(this.Txt_RedCarPlate_Price.Text.Trim());
            }
            _p.RedCarPlate_Num = this.Txt_RedCarPlate_Num.Text.Trim();


            //if (Session["AdAccList"] == null)
            //{
            //    this._AdAccList = new _AdAccessoriesList();
            //}

            //if (this._AdAccList.Count != 0)
            //{
            //    _p.ChkSetAddAcc = "Y";
            //    if (this.Lb_AdAccPrice.Text != "0")
            //    {
            //        _p._AddAcc.Price = decimal.Parse(this.Lb_AdAccPrice.Text.Trim());
            //    }
            //    _p._SetAddAccList = this._AdAccList;
            //}

            if (Session["BodyOption"] == null)
            {
                this._SetBodyOptionList = new BodyOptionList();
            }

            if (Session["BodyExtra"] == null)
            {
                this._SetBodyOptionExtraList = new BodyOptionExtraList();
            }
            

            if (this._SetBodyOptionList.Count != 0)
            {
                _p.Chk_UpAcc = "B";
                _p._SetBodyOptionList = this._SetBodyOptionList;
            }
    
            if (this._SetBodyOptionExtraList.Count != 0)
            {
                _p.Chk_UpAcc = "BE";
                _p._SetBodyOptionExtraList = this._SetBodyOptionExtraList;
            }


            _p.User_Edit = (int)Session["Emp_id"];
            
            try
            {
                _p.UPDATE_Purchase(12, _p);
            }
            catch (Exception err)
            {
                this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :" + err.Message;
                this.Panel_ConfirmFinanceErr.Visible = true;
                return;
            }

            foreach (Control item in this.Panel_Finance.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)(item)).Enabled = false;
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)(item)).Enabled = false;
                }
                else if (item is DropDownList)
                {
                    ((DropDownList)(item)).Enabled = false;
                }
            }

            this.Img_DepositDate.Visible = false;
            this.Img_DepositAdDate.Visible = false;
            this.Img_RedCarPlate_Date.Visible = false;
            this.Img_CalSum.Visible = false;
            this.Img_Cal.Visible = false;
            this.Panel_EditFinance.Visible = true;
            this.Panel_SaveFinance.Visible = false;

            this.DD_body.Enabled = false;
            this.gv_bodyshow.Columns[3].Visible = false;
            this.gv_bodyshow.ShowFooter = false;

        }

        protected void Cb_Begin_CheckedChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Img_EditRemark_Click(object sender, ImageClickEventArgs e)
        {
            this.Txt_Remark.Enabled = true;
            this.Panel_EditRemark.Visible = false;
            this.Panel_SaveRemark.Visible = true;
        }

        protected void Img_CancelRemark_Click(object sender, ImageClickEventArgs e)
        {
            this.Txt_Remark.Enabled = false;
            this.Panel_EditRemark.Visible = true;
            this.Panel_SaveRemark.Visible = false;
        }

        protected void Img_SaveRemark_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel_confirmRemarkErr.Visible = false;
            _Purchase _p = new _Purchase();
            _p.ID = int.Parse(this.Lb_EPOID.Text);
            _p.ChkP = "Y";
            _p.Remark = this.Txt_Remark.Text.Trim();
            _p.User_Edit = (int)Session["Emp_id"];
            try
            {
                _p.UPDATE_Purchase(14, _p);
            }
            catch (Exception err)
            {
                this.Lb_ConfirmFinanceErr.Text = "ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :" + err.Message;
                this.Panel_ConfirmFinanceErr.Visible = true;
                return;
            }

            this.Txt_Remark.Enabled = false;
            this.Panel_EditRemark.Visible = true;
            this.Panel_SaveRemark.Visible = false;
        }

        protected void Img_EditC_Click(object sender, ImageClickEventArgs e)
        {
            this.Cb_C_IDCard.Enabled = true;
            this.Cb_C_HouseRegistration.Enabled = true;
            this.Cb_C_Scrape.Enabled = true;
            this.Cb_C_ActInsurance.Enabled = true;
            this.Cb_C_Finance.Enabled = true;
            this.Cb_C_CVIP.Enabled = true;
            this.Panel_EditC.Visible = false;
            this.Panel_SaveC.Visible = true;
        }

        protected void Img_CancelC_Click(object sender, ImageClickEventArgs e)
        {
            this.Cb_C_IDCard.Enabled = false;
            this.Cb_C_HouseRegistration.Enabled = false;
            this.Cb_C_Scrape.Enabled = false;
            this.Cb_C_ActInsurance.Enabled = false;
            this.Cb_C_Finance.Enabled = false;
            this.Cb_C_CVIP.Enabled = false;
            this.Panel_EditC.Visible = true;
            this.Panel_SaveC.Visible = false;
        }

        protected void Img_SaveC_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel_ConfirmCErr.Visible = false;
            _Purchase _p = new _Purchase();
            _p.ID = int.Parse(this.Lb_EPOID.Text);
            _p.ChkP = "Y";
            if (this.Cb_C_IDCard.Checked == true)
            {
                _p.C_IDCard = "Y";
            }
            if (this.Cb_C_HouseRegistration.Checked == true)
            {
                _p.C_HouseRegistration = "Y";
            }
            if (this.Cb_C_Scrape.Checked == true)
            {
                _p.C_Scrape = "Y";
            }
            if (this.Cb_C_ActInsurance.Checked == true)
            {
                _p.C_ActInsurance = "Y";
            }
            if (this.Cb_C_Finance.Checked == true)
            {
                _p.C_Finance = "Y";
            }
            if (this.Cb_C_CVIP.Checked == true)
            {
                _p.C_CVIP = "Y";
            }
            _p.User_Edit = (int)Session["Emp_id"];
            try
            {
                _p.UPDATE_Purchase(15, _p);
            }
            catch (Exception err)
            {
                this.Lb_ConfirmCErr.Text = "ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :" + err.Message;
                this.Panel_ConfirmCErr.Visible = true;
                return;
            }

            this.Cb_C_IDCard.Enabled = false;
            this.Cb_C_HouseRegistration.Enabled = false;
            this.Cb_C_Scrape.Enabled = false;
            this.Cb_C_ActInsurance.Enabled = false;
            this.Cb_C_Finance.Enabled = false;
            this.Cb_C_CVIP.Enabled = false;
            this.Panel_EditC.Visible = true;
            this.Panel_SaveC.Visible = false;
        }

        protected void Txt_DepositPrice_TextChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Txt_RedCarPlate_Price_TextChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void gv_PO_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gv_PO.PageIndex = e.NewPageIndex;
            this.GETDATA();
        }

        protected void Img_ExportExcel_Click(object sender, ImageClickEventArgs e)
        {
            DataTable _dtCB = (DataTable)Session["TeamCB"];
            _SPurchaseList._SPurchase _s = new _SPurchaseList._SPurchase();
            string _Branch = string.Empty;
            string _Company = string.Empty;
            int _EmpID = 0;
            string _CusName = string.Empty;
            string _MCNumber = string.Empty;
            string _CarBranch = string.Empty;
            string _MCode = string.Empty;
            string _CarPlate = string.Empty;
            string _TruckNumber = string.Empty;
            string _Tel_Mobile = string.Empty;
            DateTime _Date1 = DateTime.MinValue;
            DateTime _Date2 = DateTime.MinValue;
            DateTime _OutDate1 = DateTime.MinValue;
            DateTime _OutDate2 = DateTime.MinValue;
            DateTime _RegisDate1 = DateTime.MinValue;
            DateTime _RegisDate2 = DateTime.MinValue;

            if ((string)Session["UserType"].ToString() == "2" || (string)Session["UserType"].ToString() == "7" || (string)Session["UserType"].ToString() == "8")
            {

                if (this.DD_SBranch.SelectedIndex != 0)
                {
                    _BranchList _b = new _BranchList();
                    _b.Select_Branch(2, string.Empty, string.Empty, this.DD_SBranch.SelectedValue);
                    _Company = _b[1]._Company.Companycode;
                    _Branch = _b[1].Branchcode;
                }

                if (this.DD_SaleName.SelectedIndex != 0)
                {
                    _EmpID = int.Parse(this.DD_SaleName.SelectedValue);
                }

                if (this.Txt_SCusName.Text.Trim() != string.Empty)
                {
                    _CusName = this.Txt_SCusName.Text.Trim();
                }

                if (this.Txt_SMCNumber.Text.Trim() != string.Empty)
                {
                    _MCNumber = this.Txt_SMCNumber.Text.Trim();
                }
                if (this.Txt_CarPlate.Text.Trim() != string.Empty)
                {
                    _CarPlate = this.Txt_CarPlate.Text.Trim();
                }
                if (this.Txt_TruckNumber.Text.Trim() != string.Empty)
                {
                    _TruckNumber = this.Txt_TruckNumber.Text.Trim();
                }
                if (this.Txt_Tel_Mobile.Text.Trim() != string.Empty)
                {
                    _Tel_Mobile = this.Txt_Tel_Mobile.Text.Trim();
                }
                if (this.Txt_Date1.Text.Trim() != string.Empty && this.Txt_Date2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_Date1.Text.Trim(), out _Date1);
                    DateTime.TryParse(this.Txt_Date2.Text.Trim(), out _Date2);
                }

                if (this.Txt_OutDate1.Text.Trim() != string.Empty && this.Txt_OutDate2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_OutDate1.Text.Trim(), out _OutDate1);
                    DateTime.TryParse(this.Txt_OutDate2.Text.Trim(), out _OutDate2);
                }

                if (this.Txt_SRegisDate1.Text.Trim() != string.Empty && this.Txt_SRegisDate2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_SRegisDate1.Text.Trim(), out _RegisDate1);
                    DateTime.TryParse(this.Txt_SRegisDate2.Text.Trim(), out _RegisDate2);
                }

                if (this.DD_SCarBranch.SelectedIndex != 0)
                {
                    _CarBranch = this.DD_SCarBranch.SelectedValue;
                }

                if (this.DD_SModel.SelectedIndex != 0)
                {
                    _MCode = this.DD_SModel.SelectedValue;
                }
            }
            else if ((string)Session["UserType"].ToString() == "4")
            {
                _Company = _dtCB.Rows[0]["Company"].ToString();
                _Branch = _dtCB.Rows[0]["Branch"].ToString();

                if (this.DD_SaleName.SelectedIndex != 0)
                {
                    _EmpID = int.Parse(this.DD_SaleName.SelectedValue);
                }

                if (this.Txt_SCusName.Text.Trim() != string.Empty)
                {
                    _CusName = this.Txt_SCusName.Text.Trim();
                }

                if (this.Txt_SMCNumber.Text.Trim() != string.Empty)
                {
                    _MCNumber = this.Txt_SMCNumber.Text.Trim();
                }
                if (this.Txt_CarPlate.Text.Trim() != string.Empty)
                {
                    _CarPlate = this.Txt_CarPlate.Text.Trim();
                }
                if (this.Txt_TruckNumber.Text.Trim() != string.Empty)
                {
                    _TruckNumber = this.Txt_TruckNumber.Text.Trim();
                }
                if (this.Txt_Tel_Mobile.Text.Trim() != string.Empty)
                {
                    _Tel_Mobile = this.Txt_Tel_Mobile.Text.Trim();
                }
                if (this.Txt_Date1.Text.Trim() != string.Empty && this.Txt_Date2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_Date1.Text.Trim(), out _Date1);
                    DateTime.TryParse(this.Txt_Date2.Text.Trim(), out _Date2);
                }

                if (this.Txt_OutDate1.Text.Trim() != string.Empty && this.Txt_OutDate2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_OutDate1.Text.Trim(), out _OutDate1);
                    DateTime.TryParse(this.Txt_OutDate2.Text.Trim(), out _OutDate2);
                }

                if (this.DD_SCarBranch.SelectedIndex != 0)
                {
                    _CarBranch = this.DD_SCarBranch.SelectedValue;
                }

                if (this.DD_SModel.SelectedIndex != 0)
                {
                    _MCode = this.DD_SModel.SelectedValue;
                }

            }
            else if ((string)Session["UserType"].ToString() == "5" || (string)Session["UserType"].ToString() == "6")
            {
                if (_dtCB.Rows[0]["Company"].ToString() == "A")
                {
                    if (this.DD_SBranch.SelectedIndex != 0)
                    {
                        _BranchList _b = new _BranchList();
                        _b.Select_Branch(2, string.Empty, string.Empty, this.DD_SBranch.SelectedValue);
                        _Company = _b[1]._Company.Companycode;
                        _Branch = _b[1].Branchcode;
                    }

                    if (this.DD_SaleName.SelectedIndex != 0)
                    {
                        _EmpID = int.Parse(this.DD_SaleName.SelectedValue);
                    }

                    if (this.Txt_SCusName.Text.Trim() != string.Empty)
                    {
                        _CusName = this.Txt_SCusName.Text.Trim();
                    }

                    if (this.Txt_SMCNumber.Text.Trim() != string.Empty)
                    {
                        _MCNumber = this.Txt_SMCNumber.Text.Trim();
                    }
                    if (this.Txt_CarPlate.Text.Trim() != string.Empty)
                    {
                        _CarPlate = this.Txt_CarPlate.Text.Trim();
                    }
                    if (this.Txt_TruckNumber.Text.Trim() != string.Empty)
                    {
                        _TruckNumber = this.Txt_TruckNumber.Text.Trim();
                    }
                    if (this.Txt_Tel_Mobile.Text.Trim() != string.Empty)
                    {
                        _Tel_Mobile = this.Txt_Tel_Mobile.Text.Trim();
                    }
                    if (this.Txt_Date1.Text.Trim() != string.Empty && this.Txt_Date2.Text.Trim() != string.Empty)
                    {
                        DateTime.TryParse(this.Txt_Date1.Text.Trim(), out _Date1);
                        DateTime.TryParse(this.Txt_Date2.Text.Trim(), out _Date2);
                    }

                    if (this.Txt_OutDate1.Text.Trim() != string.Empty && this.Txt_OutDate2.Text.Trim() != string.Empty)
                    {
                        DateTime.TryParse(this.Txt_OutDate1.Text.Trim(), out _OutDate1);
                        DateTime.TryParse(this.Txt_OutDate2.Text.Trim(), out _OutDate2);
                    }

                    if (this.DD_SCarBranch.SelectedIndex != 0)
                    {
                        _CarBranch = this.DD_SCarBranch.SelectedValue;
                    }

                    if (this.DD_SModel.SelectedIndex != 0)
                    {
                        _MCode = this.DD_SModel.SelectedValue;
                    }
                }
                else
                {
                    _Company = _dtCB.Rows[0]["Company"].ToString();
                    _Branch = _dtCB.Rows[0]["Branch"].ToString();

                    if (this.DD_SaleName.SelectedIndex != 0)
                    {
                        _EmpID = int.Parse(this.DD_SaleName.SelectedValue);
                    }

                    if (this.Txt_SCusName.Text.Trim() != string.Empty)
                    {
                        _CusName = this.Txt_SCusName.Text.Trim();
                    }

                    if (this.Txt_SMCNumber.Text.Trim() != string.Empty)
                    {
                        _MCNumber = this.Txt_SMCNumber.Text.Trim();
                    }
                    if (this.Txt_CarPlate.Text.Trim() != string.Empty)
                    {
                        _CarPlate = this.Txt_CarPlate.Text.Trim();
                    }
                    if (this.Txt_TruckNumber.Text.Trim() != string.Empty)
                    {
                        _TruckNumber = this.Txt_TruckNumber.Text.Trim();
                    }
                    if (this.Txt_Tel_Mobile.Text.Trim() != string.Empty)
                    {
                        _Tel_Mobile = this.Txt_Tel_Mobile.Text.Trim();
                    }
                    if (this.Txt_Date1.Text.Trim() != string.Empty && this.Txt_Date2.Text.Trim() != string.Empty)
                    {
                        DateTime.TryParse(this.Txt_Date1.Text.Trim(), out _Date1);
                        DateTime.TryParse(this.Txt_Date2.Text.Trim(), out _Date2);
                    }

                    if (this.Txt_OutDate1.Text.Trim() != string.Empty && this.Txt_OutDate2.Text.Trim() != string.Empty)
                    {
                        DateTime.TryParse(this.Txt_OutDate1.Text.Trim(), out _OutDate1);
                        DateTime.TryParse(this.Txt_OutDate2.Text.Trim(), out _OutDate2);
                    }

                    if (this.DD_SCarBranch.SelectedIndex != 0)
                    {
                        _CarBranch = this.DD_SCarBranch.SelectedValue;
                    }

                    if (this.DD_SModel.SelectedIndex != 0)
                    {
                        _MCode = this.DD_SModel.SelectedValue;
                    }
                }
            }
            else
            {
                _EmpID = (int)Session["Emp_id"];

                if (this.Txt_SCusName.Text.Trim() != string.Empty)
                {
                    _CusName = this.Txt_SCusName.Text.Trim();
                }

                if (this.Txt_SMCNumber.Text.Trim() != string.Empty)
                {
                    _MCNumber = this.Txt_SMCNumber.Text.Trim();
                }
                if (this.Txt_CarPlate.Text.Trim() != string.Empty)
                {
                    _CarPlate = this.Txt_CarPlate.Text.Trim();
                }
                if (this.Txt_TruckNumber.Text.Trim() != string.Empty)
                {
                    _TruckNumber = this.Txt_TruckNumber.Text.Trim();
                }
                if (this.Txt_Tel_Mobile.Text.Trim() != string.Empty)
                {
                    _Tel_Mobile = this.Txt_Tel_Mobile.Text.Trim();
                }
                if (this.Txt_Date1.Text.Trim() != string.Empty && this.Txt_Date2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_Date1.Text.Trim(), out _Date1);
                    DateTime.TryParse(this.Txt_Date2.Text.Trim(), out _Date2);
                }

                if (this.Txt_OutDate1.Text.Trim() != string.Empty && this.Txt_OutDate2.Text.Trim() != string.Empty)
                {
                    DateTime.TryParse(this.Txt_OutDate1.Text.Trim(), out _OutDate1);
                    DateTime.TryParse(this.Txt_OutDate2.Text.Trim(), out _OutDate2);
                }

                if (this.DD_SCarBranch.SelectedIndex != 0)
                {
                    _CarBranch = this.DD_SCarBranch.SelectedValue;
                }

                if (this.DD_SModel.SelectedIndex != 0)
                {
                    _MCode = this.DD_SModel.SelectedValue;
                }
            }
            DataTable _dt = new DataTable();

            _dt = _s.Select_SPurchasetoExcel(2, _Company, _Branch, _EmpID, _CusName, _MCNumber, _MCode, _Date1, _Date2, _OutDate1, _OutDate2, _RegisDate1, _RegisDate2,_CarPlate,_TruckNumber,_Tel_Mobile, _CarBranch);
            Session["SPurchasetoExcel"] = _dt;
            if (_dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), null, "window.open('../_ReportForm/Rpt_SPurchasetoExcel.aspx', '_self');", true);
            }
            
        }

        protected void Txt_PayCash_Date_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_PayCash_Date.Text.Trim() != string.Empty)
            {
                this.Chk_KeyDate(this.Txt_PayCash_Date);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }

        protected void Txt_PayTM_Date_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_PayTM_Date.Text.Trim() != string.Empty)
            {
                this.Chk_KeyDate(this.Txt_PayTM_Date);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }

        protected void Txt_PayCheque_Date_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_PayCheque_Date.Text.Trim() != string.Empty)
            {
                this.Chk_KeyDate(this.Txt_PayCheque_Date);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }

        private void Cal_RepayToCus()
        {
            if (this.Txt_PayCash_Price.Text.Trim() == string.Empty && this.Txt_PayTM_Price.Text.Trim() == string.Empty && this.Txt_PayCheque_Price.Text.Trim() == string.Empty)
            {
                this.Txt_RepayToCus.Text = "0";
            }
            else
            {
                decimal _RepayToCus = 0;
                decimal _PriceSum = 0;
                _PriceSum = decimal.Parse(this.Txt_PriceSumCar.Text.Trim());


                if (this.Txt_PayCash_Price.Text.Trim() != string.Empty)
                {
                    _RepayToCus = _RepayToCus + decimal.Parse(this.Txt_PayCash_Price.Text.Trim());
                }

                if (this.Txt_PayTM_Price.Text.Trim() != string.Empty)
                {
                    _RepayToCus = _RepayToCus + decimal.Parse(this.Txt_PayTM_Price.Text.Trim());
                }

                if (this.Txt_PayCheque_Price.Text.Trim() != string.Empty)
                {
                    _RepayToCus = _RepayToCus + decimal.Parse(this.Txt_PayCheque_Price.Text.Trim());
                }

                this.Txt_RepayToCus.Text = (_RepayToCus - _PriceSum).ToString();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }

        protected void Txt_PayCash_Price_TextChanged(object sender, EventArgs e)
        {
            this.Cal_RepayToCus();
        }

        protected void Txt_PayTM_Price_TextChanged(object sender, EventArgs e)
        {
            this.Cal_RepayToCus();
        }

        protected void Txt_PayCheque_Price_TextChanged(object sender, EventArgs e)
        {
            this.Cal_RepayToCus();
        }

        protected void Img_EditPayCus_Click(object sender, ImageClickEventArgs e)
        {
            this.Txt_PayCash_No.Enabled = true;
            this.Txt_PayCash_Date.Enabled = true;
            this.Txt_PayCash_Price.Enabled = true;
            this.DD_PayTM_Bank.Enabled = true;
            this.Txt_PayTM_No.Enabled = true;
            this.Txt_PayTM_Date.Enabled = true;
            this.Txt_PayTM_Price.Enabled = true;
            this.DD_PayCheque_Bank.Enabled = true;
            this.Txt_PayCheque_No.Enabled = true;
            this.Txt_PayCheque_Date.Enabled = true;
            this.Txt_PayCheque_Price.Enabled = true;
            this.Panel_EditPayCus.Visible = false;
            this.Panel_SavePayCus.Visible = true;
        }

        protected void Img_CancelPayCus_Click(object sender, ImageClickEventArgs e)
        {
            this.Txt_PayCash_No.Enabled = false;
            this.Txt_PayCash_Date.Enabled = false;
            this.Txt_PayCash_Price.Enabled = false;
            this.DD_PayTM_Bank.Enabled = false;
            this.Txt_PayTM_No.Enabled = false;
            this.Txt_PayTM_Date.Enabled = false;
            this.Txt_PayTM_Price.Enabled = false;
            this.DD_PayCheque_Bank.Enabled = false;
            this.Txt_PayCheque_No.Enabled = false;
            this.Txt_PayCheque_Date.Enabled = false;
            this.Txt_PayCheque_Price.Enabled = false;
            this.Panel_EditPayCus.Visible = true;
            this.Panel_SavePayCus.Visible = false;
        }

        protected void Img_SavePayCus_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel_confirmPayCusErr.Visible = false;
            if (this.Txt_PayCash_No.Text != string.Empty || this.Txt_PayCash_Date.Text != string.Empty || this.Txt_PayCash_Price.Text != string.Empty)
            {
                if (this.Txt_PayCash_No.Text == string.Empty)
                {
                    this.Lb_ConfirmPayCusErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขที่ใบเสร็จเงินสด!";
                    this.Panel_confirmPayCusErr.Visible = true;
                    return;
                }
                else if (this.Txt_PayCash_Date.Text == string.Empty)
                {
                    this.Lb_ConfirmPayCusErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันที่ออกใบเสร็จเงินสด!";
                    this.Panel_confirmPayCusErr.Visible = true;
                    return;
                }
                else if (this.Txt_PayCash_Price.Text == string.Empty)
                {
                    this.Lb_ConfirmPayCusErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจำนวนเงินสด!";
                    this.Panel_confirmPayCusErr.Visible = true;
                    return;
                }
            }

            if (this.DD_PayTM_Bank.SelectedIndex != 0 || this.Txt_PayTM_No.Text != string.Empty || this.Txt_PayTM_Date.Text != string.Empty || this.Txt_PayTM_Price.Text != string.Empty)
            {
                if (this.DD_PayTM_Bank.SelectedIndex == 0)
                {
                    this.Lb_ConfirmPayCusErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเงินโอนธนาคาร!";
                    this.Panel_confirmPayCusErr.Visible = true;
                    return;
                }
                else if (this.Txt_PayTM_No.Text == string.Empty)
                {
                    this.Lb_ConfirmPayCusErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขที่ใบเสร็จเงินโอน!";
                    this.Panel_confirmPayCusErr.Visible = true;
                    return;
                }
                else if (this.Txt_PayTM_Date.Text == string.Empty)
                {
                    this.Lb_ConfirmPayCusErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันที่ออกใบเสร็จเงินโอน!";
                    this.Panel_confirmPayCusErr.Visible = true;
                    return;
                }
                else if (this.Txt_PayTM_Price.Text == string.Empty)
                {
                    this.Lb_ConfirmPayCusErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจำนวนเงินโอน!";
                    this.Panel_confirmPayCusErr.Visible = true;
                    return;
                }
            }

            if (this.DD_PayCheque_Bank.SelectedIndex != 0 || this.Txt_PayCheque_No.Text != string.Empty || this.Txt_PayCheque_Date.Text != string.Empty || this.Txt_PayCheque_Price.Text != string.Empty)
            {
                if (this.DD_PayCheque_Bank.SelectedIndex == 0)
                {
                    this.Lb_ConfirmPayCusErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเช็คธนาคาร!";
                    this.Panel_confirmPayCusErr.Visible = true;
                    return;
                }
                else if (this.Txt_PayCheque_No.Text == string.Empty)
                {
                    this.Lb_ConfirmPayCusErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขที่ใบเสร็จเช็คธนาคาร!";
                    this.Panel_confirmPayCusErr.Visible = true;
                    return;
                }
                else if (this.Txt_PayCheque_Date.Text == string.Empty)
                {
                    this.Lb_ConfirmPayCusErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันที่ออกใบเสร็จเช็คธนาคาร!";
                    this.Panel_confirmPayCusErr.Visible = true;
                    return;
                }
                else if (this.Txt_PayCheque_Price.Text == string.Empty)
                {
                    this.Lb_ConfirmPayCusErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจำนวนเงินเข็คธนาคาร!";
                    this.Panel_confirmPayCusErr.Visible = true;
                    return;
                }
            }

            if (this.Txt_RepayToCus.Text != string.Empty)
            {
                _Purchase _p = new _Purchase();
                _p.ID = int.Parse(this.Lb_EPOID.Text);
                _p.ChkP = "Y";
                if (this.Txt_PayCash_No.Text != string.Empty)
                {
                    _p.PayCash_No = this.Txt_PayCash_No.Text.Trim();
                    if (this.Txt_PayCash_Date.Text.Trim() != string.Empty)
                    {
                        DateTime _PayCash_Date = DateTime.MinValue;
                        DateTime.TryParse(this.Txt_PayCash_Date.Text, out _PayCash_Date);
                        _p.PayCash_Date = _PayCash_Date;
                    }
                    if (this.Txt_PayCash_Price.Text != "0")
                    {
                        _p.PayCase_Price = decimal.Parse(this.Txt_PayCash_Price.Text.Trim());
                    }
                }
                if (this.Txt_PayTM_No.Text != string.Empty)
                {
                    _p.PayTM = int.Parse(this.DD_PayTM_Bank.SelectedValue);
                    _p.PayTM_No = this.Txt_PayTM_No.Text.Trim();
                    if (this.Txt_PayTM_Date.Text.Trim() != string.Empty)
                    {
                        DateTime _PayTM_Date = DateTime.MinValue;
                        DateTime.TryParse(this.Txt_PayTM_Date.Text, out _PayTM_Date);
                        _p.PayTM_Date = _PayTM_Date;
                    }
                    if (this.Txt_PayTM_Price.Text != "0")
                    {
                        _p.PayTM_Price = decimal.Parse(this.Txt_PayTM_Price.Text.Trim());
                    }
                }
                if (this.Txt_PayCheque_No.Text != string.Empty)
                {
                    _p.PayCheque = int.Parse(this.DD_PayCheque_Bank.SelectedValue);
                    _p.PayCheque_No = this.Txt_PayCheque_No.Text.Trim();
                    if (this.Txt_PayCheque_Date.Text.Trim() != string.Empty)
                    {
                        DateTime _PayCheque_Date = DateTime.MinValue;
                        DateTime.TryParse(this.Txt_PayCheque_Date.Text, out _PayCheque_Date);
                        _p.PayCheque_Date = _PayCheque_Date;
                    }
                    if (this.Txt_PayCheque_Price.Text != "0")
                    {
                        _p.PayCheque_Price = decimal.Parse(this.Txt_PayCheque_Price.Text.Trim());
                    }
                }
                if (this.Txt_RepayToCus.Text != "0")
                {
                        _p.RepayToCus = decimal.Parse(this.Txt_RepayToCus.Text.Trim());
                }
                _p.User_Edit = (int)Session["Emp_id"];
                try
                {
                    _p.UPDATE_Purchase(16, _p);
                }
                catch (Exception err)
                {
                    this.Lb_ConfirmPayCusErr.Text = "ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :" + err.Message;
                    this.Panel_confirmPayCusErr.Visible = true;
                    return;
                }
            }
            

            this.Txt_PayCash_No.Enabled = false;
            this.Txt_PayCash_Date.Enabled = false;
            this.Txt_PayCash_Price.Enabled = false;
            this.DD_PayTM_Bank.Enabled = false;
            this.Txt_PayTM_No.Enabled = false;
            this.Txt_PayTM_Date.Enabled = false;
            this.Txt_PayTM_Price.Enabled = false;
            this.DD_PayCheque_Bank.Enabled = false;
            this.Txt_PayCheque_No.Enabled = false;
            this.Txt_PayCheque_Date.Enabled = false;
            this.Txt_PayCheque_Price.Enabled = false;
            this.Panel_EditPayCus.Visible = true;
            this.Panel_SavePayCus.Visible = false;
        }

        protected void Lbtn_CVIP_Click(object sender, EventArgs e)
        {
            string Lb_MCNumber = this.Txt_EMCNumber.Text;
            //Lb_MCNumber = _Encryption.Encrypt(Lb_MCNumber);

            //string[] spChar = { "+", "&", "%", "$" };
            //string[] replaceChar = { "_plus", "_amp", "_per", "_dol" };

            //for (int i = 0; i <= spChar.Length - 1; i++)
            //{
            //    Lb_MCNumber = Lb_MCNumber.Replace(spChar[i], replaceChar[i]);
            //}

            string UID = (string)Session["login"].ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), null, "window.open('http://192.168.1.198:8099/Default.aspx?MCNumber=" + Lb_MCNumber + "&UID=" + UID + "', '_blank');", true);
        }

        //protected void Txt_RegisDate_TextChanged(object sender, EventArgs e)
        //{
        //    if (this.Txt_RegisDate.Text.Trim() != string.Empty)
        //    {
        //        bool complete = false;
        //        DateTime _RegisDate = DateTime.MinValue;
        //        complete = DateTime.TryParse(this.Txt_RegisDate.Text, out _RegisDate);
        //        if (complete == false)
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันเกิด!');", true);
        //        }
        //        else
        //        {
        //            this.Txt_RegisDate.Text = _RegisDate.ToString("dd MMM yy");
        //        }
        //    }
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        //}

        protected void Txt_DepositAdDate_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_DepositAdDate.Text.Trim() != string.Empty)
            {
                this.Chk_KeyDate(this.Txt_DepositAdDate);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }

        protected void Txt_DepositAdPrice_TextChanged(object sender, EventArgs e)
        {
            this.Empty_PriceSum();
        }

        protected void Img_EditPoNum_Click(object sender, ImageClickEventArgs e)
        {
            this.Txt_PoNum.Enabled = true;
            this.Panel_EditPoNum.Visible = false;
            this.Panel_SavePoNum.Visible = true;
        }

        protected void Img_CancelPoNum_Click(object sender, ImageClickEventArgs e)
        {
            this.Txt_PoNum.Enabled = false;
            this.Panel_EditPoNum.Visible = true;
            this.Panel_SavePoNum.Visible = false;
        }

        protected void Img_SavePoNum_Click(object sender, ImageClickEventArgs e)
        {
            _Purchase _p = new _Purchase();
            _p.ID = int.Parse(this.Lb_EPOID.Text);
            _p.ChkP = "Y";
            _p.PoNum = this.Txt_PoNum.Text.Trim();
            _p.User_Edit = (int)Session["Emp_id"];
            try
            {
                _p.UPDATE_Purchase(17, _p);
            }
            catch (Exception err)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :')" + err.Message + ";", true);
                //string script = "alert(\"ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :\");"+err.Message;
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                return;
            }
            this.Txt_PoNum.Enabled = false;
            this.Panel_EditPoNum.Visible = true;
            this.Panel_SavePoNum.Visible = false;

        }





        protected void Img_EditCompanyName_Click(object sender, ImageClickEventArgs e)
        {

            this.Txt_ECorporationCode.Enabled = true;
            this.Txt_ECompanyName.Enabled = true;

            this.Panel_EditCompanyName.Visible = false;
            this.Panel_SaveCompanyName.Visible = true;


        }






        protected void Img_SaveCompanyName_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel_ConfirmNameErr.Visible = false;
            //if (this.Txt_EBirthday.Text.Trim() == string.Empty)
            //{
            //    this.Lb_ConfirmNameErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันเกิด!";
            //    this.Panel_ConfirmNameErr.Visible = true;

            //    return;
            //}
            //else
            //{
            //    bool complete = false;
            //    DateTime _Birthday = DateTime.MinValue;
            //    complete = DateTime.TryParse(this.Txt_EBirthday.Text, out _Birthday);
            //    if (complete == false)
            //    {
            //        this.Lb_ConfirmNameErr.Text = "ไม่สามารถทำรายการได้ : กรุณาตรวจสอบรูปแบบวันเกิด!";
            //        this.Panel_ConfirmNameErr.Visible = true;

            //        return;
            //    }
            //}

            _Purchase _p = new _Purchase();
            _p._Customer.ID = int.Parse(this.Txt_ECusID.Text);
            _p.ChkP = "Y";
            //----------------------------------------------------

            _p._Customer.CorporationCode = this.Txt_ECorporationCode.Text.Trim();
            _p._Customer.Name = this.Txt_ECompanyName.Text.Trim();


            //----------------------------------------------------
            _p._Customer.Nickname = this.Txt_ENickname.Text.Trim();
            DateTime _BirthDay = DateTime.MinValue;
            DateTime.TryParse(this.Txt_EBirthday.Text, out _BirthDay);
            _p._Customer.Birthday = _BirthDay;
            _p._Customer.Sex = this.DD_EPerson_Sex.SelectedValue;
            _p._Customer._Education.id = int.Parse(this.DD_EEducation.SelectedValue);
            if (this.Txt_ETotal_Member.Text.Trim() != string.Empty)
            {
                _p._Customer.Total_Member = int.Parse(this.Txt_ETotal_Member.Text);
            }
            _p.User_Edit = (int)Session["Emp_id"];
            try
            {
                _p.UPDATE_Purchase(18, _p);
            }
            catch (Exception err)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :') " + err.Message + "", true);
                return;
            }


            this.Panel_EditCompanyName.Visible = true;
            this.Panel_SaveCompanyName.Visible = false;

            this.Txt_ECorporationCode.Enabled = false;
            this.Txt_ECompanyName.Enabled = false;
   

        }

        protected void Img_CancelCompanyName_Click(object sender, ImageClickEventArgs e)
        {

            this.Txt_ECorporationCode.Enabled = false;
            this.Txt_ECompanyName.Enabled = false;

            this.Panel_EditCompanyName.Visible = true;
            this.Panel_SaveCompanyName.Visible = false;


        }

        protected void gv_bodyshow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                Label Lb_Addfinance = (Label)e.Row.FindControl("Lb_Addfinance");
                CheckBox lbl_finance = (CheckBox)e.Row.FindControl("lbl_finance");
                Label lbl_Body_Option_price = (Label)e.Row.FindControl("lbl_Body_Option_price");
                decimal Option_price = decimal.Parse(lbl_Body_Option_price.Text);
                if (Lb_Addfinance.Text == "Y")
                {
                    lbl_finance.Checked = true;

                }
                else if (Lb_Addfinance.Text == "N")
                {
                    lbl_finance.Checked = false;
                }
            }

            if ((e.Row.RowType == DataControlRowType.Footer))
            {
                int Body_Acc_ID = int.Parse(DD_body.SelectedValue);
                this._BodyOptionList = new BodyOptionList();
                _BodyOptionList.Body_Select_Option(Body_Acc_ID);

                if (_BodyOptionList.Values.Count > 0)
                {
                    DropDownList ddl_bodyoption = (DropDownList)e.Row.FindControl("ddl_bodyoption");
                    ddl_bodyoption.DataSource = _BodyOptionList.Values;
                    ddl_bodyoption.DataTextField = "Body_Option_Name";
                    ddl_bodyoption.DataValueField = "Body_Option_ID";
                    ddl_bodyoption.DataBind();
                    ddl_bodyoption.Items.Insert(0, new ListItem("-- เลือก --", "0"));
                    ddl_bodyoption.SelectedIndex = 0;

                    Session["ddlbodyoption"] = _BodyOptionList;
                }
            }
        }


        protected void Img_Addbody_Click(object sender, ImageClickEventArgs e)
        {
            this.Panelbody.Visible = false;
            DropDownList ddlbodyoption = (DropDownList)gv_bodyshow.FooterRow.FindControl("ddl_bodyoption");
            CheckBox chkfinance = (CheckBox)gv_bodyshow.FooterRow.FindControl("chk_finance");



            if (ddlbodyoption.SelectedValue == "0")
            {
                this.lblerrorbody.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุอุปกรณ์!";
                this.Panelbody.Visible = true;
                return;
            }


            if (Session["BodyOption"] == null)
            {
                this._SetBodyOptionList = new BodyOptionList();
            }


            BodyOptionList.BodyOption _Option = new BodyOptionList.BodyOption();
            int _c;
            if (this._SetBodyOptionList.Count == 0)
            {
                _c = 1;
            }
            else
            {
                _c = this._SetBodyOptionList.Keys.Max();
                _c = _c + 1;
            }
            _Option.OptionIDrun = _c;
            _Option.Body_Option_ID = int.Parse(ddlbodyoption.SelectedValue);
           

            //----------------------
            this._ddlbodyoption = (BodyOptionList)Session["ddlbodyoption"];
            int ID = int.Parse(ddlbodyoption.SelectedValue);
            var option = this._ddlbodyoption.Where(x => x.Value.Body_Option_ID == ID).FirstOrDefault();
            _Option.Body_Option_Name = option.Value.Option_Name.ToString();
            decimal Option_price = decimal.Parse(option.Value.Body_Option_price.ToString());
            _Option.Body_Option_price = Option_price;
            //--------------------------

            if (chkfinance.Checked == true)
            {
                _Option.finance = "Y";

                decimal STDBudgetfinance = decimal.Parse(this.lblsumfin.Text);
                STDBudgetfinance = STDBudgetfinance + Option_price;
                this.lblsumfin.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(STDBudgetfinance));

                //decimal PriceCar = decimal.Parse(this.Txt_PriceCar.Text);
                //PriceCar = PriceCar + Option_price;
                //this.Txt_PriceCar.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(PriceCar));
            }
            else
            {
                _Option.finance = "N";

                decimal Budgetpaybody = decimal.Parse(this.Lb_Budgetpaybody.Text);
                Budgetpaybody = Budgetpaybody + Option_price;
                this.Lb_Budgetpaybody.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(Budgetpaybody));

            }

            decimal sumAddfinance = decimal.Parse(this.Lb_sumAddfinance.Text);
            sumAddfinance = sumAddfinance + Option_price;
            this.Lb_sumAddfinance.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(sumAddfinance));


            this._SetBodyOptionList.Add(_c, _Option);
            Session["BodyOption"] = this._SetBodyOptionList;
            this.gv_bodyshow.DataSource = this._SetBodyOptionList.Values;
            this.gv_bodyshow.DataBind();

            this.Cal_Payment();
        }

        protected void Img_Delbody_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gv = (GridViewRow)((ImageButton)sender).NamingContainer;
            Label lblOptionID = (Label)gv.FindControl("lbl_Body_Option_ID");
            Label Lb_Addfinance = (Label)gv.FindControl("Lb_Addfinance");
            Label lblOptionprice = (Label)gv.FindControl("lbl_Body_Option_price");
            if (lblOptionID.Text != "0")
            {
                decimal Optionprice = decimal.Parse(lblOptionprice.Text);
                string check = Lb_Addfinance.Text;
                if (check == "Y")
                {
                    decimal STDBudgetfinance = decimal.Parse(this.lblsumfin.Text);
                    STDBudgetfinance = STDBudgetfinance - Optionprice;
                    this.lblsumfin.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(STDBudgetfinance));

                    //decimal PriceCar = decimal.Parse(this.Txt_PriceCar.Text);
                    //PriceCar = PriceCar - this._BodyOptionList[gv.RowIndex].Body_Option_price;
                    //this.Txt_PriceCar.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(PriceCar));
                    if (this.lblsumfin.Text == "")
                    {
                        this.lblsumfin.Text = "0.00";
                    }
                }
                else
                {
                    decimal Budgetpaybody = decimal.Parse(this.Lb_Budgetpaybody.Text);
                    Budgetpaybody = Budgetpaybody - Optionprice;
                    this.Lb_Budgetpaybody.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(Budgetpaybody));

                    if (this.Lb_Budgetpaybody.Text == "")
                    {
                        this.Lb_Budgetpaybody.Text = "0.00";
                    }
                }
                decimal sumAddfinance = decimal.Parse(this.Lb_sumAddfinance.Text);
                sumAddfinance = sumAddfinance - Optionprice;
                this.Lb_sumAddfinance.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(sumAddfinance));




                int id = int.Parse(gv_bodyshow.DataKeys[gv.RowIndex].Value.ToString());
                //this._SetBodyOptionList.Remove(id);
                //this._SetBodyOptionList.Remove(_SetBodyOptionList.Single(s => s.Value.Body_Option_ID == id));

                var optionBodydel = this._SetBodyOptionList.Where(w => w.Value.Body_Option_ID == id).FirstOrDefault();
                this._SetBodyOptionList.Remove(optionBodydel);

                //this._SetBodyOptionList.Remove(_SetBodyOptionList.s => x.Value.Body_Option_ID == ID).FirstOrDefault();

                if (this._SetBodyOptionList.Count == 0)
                {
                    this.AddEmptyData_BodyOption();
                }
                else
                {
                    this.gv_bodyshow.DataSource = this._SetBodyOptionList.Values;
                    this.gv_bodyshow.DataBind();
                }


                this.Cal_Payment();
            }
        }

        private void AddEmptyData_BodyOption()
        {
            BodyOptionList _Optionlist = new BodyOptionList();
            BodyOptionList.BodyOption _Option = new BodyOptionList.BodyOption();
            _Optionlist.Add(0, _Option);
            this.gv_bodyshow.DataSource = _Optionlist.Values;
            this.gv_bodyshow.DataBind();

            this.lblsumfin.Text = "0.00";
            this.Lb_Budgetpaybody.Text = "0.00";
            this.Lb_sumAddfinance.Text = "0.00";
        }

        protected void DD_body_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Body_Acc_ID = int.Parse(DD_body.SelectedValue);
            this._SetBodyOptionList = new BodyOptionList();
            _SetBodyOptionList.Body_Select_Option(Body_Acc_ID);


            if (_SetBodyOptionList.Values.Count > 0)
            {
                this.AddEmptyData_BodyOption();
                this._SetBodyOptionList.Clear();
                Session.Remove("BodyOption");
            }
            else
            {
                Session.Remove("BodyOption");
                this._SetBodyOptionList.Clear();
                this.gv_bodyshow.DataSource = string.Empty;
                this.gv_bodyshow.DataBind();
                this.lblsumfin.Text = "0.00";
                this.Lb_Budgetpaybody.Text = "0.00";
                this.Lb_sumAddfinance.Text = "0.00";
                this.Cal_Payment();
            }

            if ((BodyClassList)Session["BodyClassList"] != null)
            {
                this._BodyClassList = (BodyClassList)Session["BodyClassList"];
                int ID = int.Parse(DD_body.SelectedValue);
                var xxx = this._BodyClassList.Where(x => x.Value.Body_Acc_ID == ID).FirstOrDefault();

                Txt_CarPriceAd.Text = xxx.Value.Acc_Name.ToString();
                Txt_CarPriceAd_Price.Text = xxx.Value.Body_Model_price.ToString();
                this.Cal_Payment();
            }
        }

        protected void Rb_bodyextra_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_bodyextra.Checked == true)
            {
                Session["BodyOption"] = null;
                Session["BodyExtra"] = null;
                //---------------------------lสั่งพิเศษ-----------------------
                BodyCompany body = new BodyCompany();
                DataTable _bodyextra = body.Body_Select_Company();
                this.ddl_Body_Company.DataSource = _bodyextra;
                this.ddl_Body_Company.DataValueField = "Body_Company_ID";
                this.ddl_Body_Company.DataTextField = "Body_Company_Name";
                this.ddl_Body_Company.DataBind();
                this.ddl_Body_Company.Items.Insert(0, new ListItem("-- เลือก --", "0"));
                this.ddl_Body_Company.SelectedIndex = 0;
                //----------------------------------
                ddl_Body_Company.Enabled = true;
                Panelbodyextra.Visible = true;
                Panelbodystandard.Visible = false;

                this.DD_body.SelectedIndex = -1;
                this.lblsumfin.Text = "0.00";
                this.Lb_Budgetpaybody.Text = "0.00";
                this.Lb_sumAddfinance.Text = "0.00";
                this.Txt_bodyextraPrice.Text = "0.00";

                this.AddEmptyData_BodyOption();
                this.AddEmptyData_BodyOptionExtra();
                Panelgvbodyextra.Visible = true;
                Panelgvbodystandard.Visible = false;

                this.Txt_CarPriceAd.Text = "";
                this.Txt_CarPriceAd_Price.Text = "0.00";

                this.Cal_Payment();

            }
        }

        protected void Rb_bodystandard_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_bodystandard.Checked == true)
            {
                Session["BodyExtra"] = null;
                Session["BodyOption"] = null;
                Panelbodystandard.Visible = true;
                Panelbodyextra.Visible = false;

                this.ddl_Body_Company.SelectedIndex = -1;
                this.lblsumfin.Text = "0.00";
                this.Lb_Budgetpaybody.Text = "0.00";
                this.Lb_sumAddfinance.Text = "0.00";
                this.txt_bodyextra.Text = "";
                this.Txt_bodyextraPrice.Text = "0.00";

                this.AddEmptyData_BodyOption();
                this.AddEmptyData_BodyOptionExtra();

                Panelgvbodyextra.Visible = false;
                Panelgvbodystandard.Visible = true;

                this.Txt_CarPriceAd.Text = "";
                this.Txt_CarPriceAd_Price.Text = "0.00";

                this.Cal_Payment();
            }
        }

        private void AddEmptyData_BodyOptionExtra()
        {
            BodyOptionExtraList _OptionlistExtra = new BodyOptionExtraList();
            BodyOptionExtraList.BodyOptionExtra _OptionExtra = new BodyOptionExtraList.BodyOptionExtra();
            _OptionlistExtra.Add(0, _OptionExtra);
            this.gv_bodyextra.DataSource = _OptionlistExtra.Values;
            this.gv_bodyextra.DataBind();

            this.lblsumfin.Text = "0.00";
            this.Lb_Budgetpaybody.Text = "0.00";
            this.Lb_sumAddfinance.Text = "0.00";
        }

        protected void Txt_bodyextraPrice_TextChanged(object sender, EventArgs e)
        {
            if (Txt_bodyextraPrice.Text != "0" || Txt_bodyextraPrice.Text.Trim() != string.Empty || Txt_bodyextraPrice.Text != "")
            {
                decimal extraPrice = decimal.Parse(Txt_bodyextraPrice.Text);
                Txt_CarPriceAd.Text = txt_bodyextra.Text;
                Txt_CarPriceAd_Price.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(extraPrice));
                this.Cal_Payment();
            }
            else
            {
                Txt_CarPriceAd.Text = "";
                Txt_CarPriceAd_Price.Text = "0.00";

                this.Cal_Payment();
            }
        }

        protected void gv_bodyextra_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                Label Option_finance_extra = (Label)e.Row.FindControl("Lb_Option_finance_extra");
                CheckBox financeExtra = (CheckBox)e.Row.FindControl("lbl_financeExtra");

                if (Option_finance_extra.Text == "Y")
                {
                    financeExtra.Checked = true;
                }
                else if (Option_finance_extra.Text == "N")
                {
                    financeExtra.Checked = false;
                }
            }

            if ((e.Row.RowType == DataControlRowType.Footer))
            {
                DropDownList ddl_gvbodyextra = (DropDownList)e.Row.FindControl("ddl_gvbodyextracom");
                BodyCompany body = new BodyCompany();
                //---------------------------lสั่งพิเศษ-----------------------
                DataTable _bodyextra = body.Body_Select_Company();
                ddl_gvbodyextra.DataSource = _bodyextra;
                ddl_gvbodyextra.DataValueField = "Body_Company_ID";
                ddl_gvbodyextra.DataTextField = "Body_Company_Name";
                ddl_gvbodyextra.DataBind();
                ddl_gvbodyextra.Items.Insert(0, new ListItem("-- เลือก --", "0"));
                ddl_gvbodyextra.SelectedIndex = 0;
                //----------------------------------
            }
        }


        protected void Img_AddbodyExtra_Click(object sender, ImageClickEventArgs e)
        {
            this.Panelgvbodystandard.Visible = false;

            DropDownList ddlbodyoptionextra = (DropDownList)gv_bodyextra.FooterRow.FindControl("ddl_gvbodyextracom");
            TextBox TxtbodyextraOption = (TextBox)gv_bodyextra.FooterRow.FindControl("Txt_gvbodyextraOption");
            TextBox TxtbodyextraPrice = (TextBox)gv_bodyextra.FooterRow.FindControl("Txt_gvbodyextraPrice");
            CheckBox chkfinanceextra = (CheckBox)gv_bodyextra.FooterRow.FindControl("chk_financeExtra");

            if (((DropDownList)gv_bodyextra.FooterRow.FindControl("ddl_gvbodyextracom")).SelectedIndex == 0)
            {
                this.lbl_ErrorExtra.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุบริษัทอุปกรณ์!";
                this.lbl_ErrorExtra.Visible = true;
                return;
            }
            if (((TextBox)gv_bodyextra.FooterRow.FindControl("Txt_gvbodyextraOption")).Text == string.Empty)
            {
                this.lbl_ErrorExtra.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุชื่ออุปกรณ์!";
                this.lbl_ErrorExtra.Visible = true;
                return;
            }
            if (((TextBox)gv_bodyextra.FooterRow.FindControl("Txt_gvbodyextraPrice")).Text == string.Empty)
            {
                this.lbl_ErrorExtra.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุราคาอุปกรณ์!";
                this.lbl_ErrorExtra.Visible = true;
                return;
            }


            if (Session["BodyExtra"] == null)
            {
                this._SetBodyOptionExtraList = new BodyOptionExtraList();
            }



            BodyOptionExtraList.BodyOptionExtra _OptionExtra = new BodyOptionExtraList.BodyOptionExtra();
            int _c;
            if (this._SetBodyOptionExtraList.Count == 0)
            {
                _c = 1;
            }
            else
            {
                _c = this._SetBodyOptionExtraList.Keys.Max();
                _c = _c + 1;
            }

            _OptionExtra.ID = _c;
            _OptionExtra.Body_Company_ID = int.Parse(ddlbodyoptionextra.SelectedValue);
            _OptionExtra.Body_Company_Name = ddlbodyoptionextra.SelectedItem.Text;
            _OptionExtra.Option_Name_extra = TxtbodyextraOption.Text;
            _OptionExtra.Option_price_extra = decimal.Parse(TxtbodyextraPrice.Text);
            //--------------------------


            decimal price_extra = decimal.Parse(TxtbodyextraPrice.Text);

            if (chkfinanceextra.Checked == true)
            {
                _OptionExtra.Option_finance_extra = "Y";

                decimal STDBudgetfinance = decimal.Parse(this.lblsumfin.Text);
                STDBudgetfinance = STDBudgetfinance + price_extra;
                this.lblsumfin.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(STDBudgetfinance));

            }
            else
            {
                _OptionExtra.Option_finance_extra = "N";

                decimal Budgetpaybody = decimal.Parse(this.Lb_Budgetpaybody.Text);
                Budgetpaybody = Budgetpaybody + price_extra;
                this.Lb_Budgetpaybody.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(Budgetpaybody));

            }

            decimal sumAddfinance = decimal.Parse(this.Lb_sumAddfinance.Text);
            sumAddfinance = sumAddfinance + price_extra;
            this.Lb_sumAddfinance.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(sumAddfinance));


            this._SetBodyOptionExtraList.Add(_c, _OptionExtra);
            Session["BodyExtra"] = this._SetBodyOptionExtraList;
            this.gv_bodyextra.DataSource = this._SetBodyOptionExtraList.Values;
            this.gv_bodyextra.DataBind();

            this.Panelgvbodyextra.Visible = true;

            this.Cal_Payment();


        }

        protected void Img_Delbodyextra_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gv = (GridViewRow)((ImageButton)sender).NamingContainer;
            Label lblbodyextraID = (Label)gv.FindControl("runbodyextraID");
            Label Lb_Addfinanceextra = (Label)gv.FindControl("Lb_Option_finance_extra");
            Label lblOptionpriceextra = (Label)gv.FindControl("lbl_Option_price_extra");
            if (lblbodyextraID.Text != "0")
            {
                decimal Optionprice = decimal.Parse(lblOptionpriceextra.Text);
                string check = Lb_Addfinanceextra.Text;
                if (check == "Y")
                {
                    decimal STDBudgetfinance = decimal.Parse(this.lblsumfin.Text);
                    STDBudgetfinance = STDBudgetfinance - Optionprice;
                    this.lblsumfin.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(STDBudgetfinance));

                    //decimal PriceCar = decimal.Parse(this.Txt_PriceCar.Text);
                    //PriceCar = PriceCar - this._BodyOptionList[gv.RowIndex].Body_Option_price;
                    //this.Txt_PriceCar.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(PriceCar));
                    if (this.lblsumfin.Text == "")
                    {
                        this.lblsumfin.Text = "0.00";
                    }
                }
                else
                {
                    decimal Budgetpaybody = decimal.Parse(this.Lb_Budgetpaybody.Text);
                    Budgetpaybody = Budgetpaybody - Optionprice;
                    this.Lb_Budgetpaybody.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(Budgetpaybody));

                    if (this.Lb_Budgetpaybody.Text == "")
                    {
                        this.Lb_Budgetpaybody.Text = "0.00";
                    }
                }
                decimal sumAddfinance = decimal.Parse(this.Lb_sumAddfinance.Text);
                sumAddfinance = sumAddfinance - Optionprice;
                this.Lb_sumAddfinance.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(sumAddfinance));


                int id = int.Parse(gv_bodyextra.DataKeys[gv.RowIndex].Value.ToString());
                this._SetBodyOptionExtraList.Remove(id);
                if (this._SetBodyOptionExtraList.Count == 0)
                {
                    this.AddEmptyData_BodyOptionExtra();
                }
                else
                {
                    this.gv_bodyextra.DataSource = this._SetBodyOptionExtraList.Values;
                    this.gv_bodyextra.DataBind();
                }
            }
            this.Cal_Payment();
        }

        protected void Img_EditInvoice_Click(object sender, ImageClickEventArgs e)
        {
            //this.getDataInvoice();
            this.Txt_ECarPlate.Enabled = true;
            this.Txt_RegisDate.Enabled = true;
            this.Img_RegisDate.Visible = true;
            this.Txt_CarTax.Enabled = true;
            this.DD_ECarType.Enabled = true;


            this.Txt_InvoiceDate.Enabled = true;
            this.Txt_GetInvoiceDate.Enabled = true;
            this.Txt_NoteSetDate.Enabled = true;
            this.Txt_SendNoteSetDate.Enabled = true;
            this.Txt_SendTranSportDate.Enabled = true;
            this.Txt_GetGuideDate.Enabled = true;
            this.Txt_GetBadgeDate.Enabled = true;
            this.remarkInvoice_TextBox.Enabled = true;

            this.Img_InvoiceDate.Enabled = true;
            this.Img_GetInvoiceDate.Enabled = true;
            this.Img_NoteSetDate.Enabled = true;
            this.Img_SendNoteSetDate.Enabled = true;
            this.Img_SendTranSportDate.Enabled = true;
            this.Img_GetGuideDate.Enabled = true;
            this.Img_GetBadgeDate.Enabled = true;

            
            this.Panel_EditInvoice.Visible = false;
            this.Panel_SaveInvoice.Visible = true;

            
        }
        protected void Img_SaveInvoice_Click(object sender, ImageClickEventArgs e)
        {
            _InvoiceList._Invoice invoice = new _InvoiceList._Invoice();
            _Purchase _p = new _Purchase();
            int poid = Int32.Parse(Lb_EPOID.Text.ToString());

            string carplate = this.Txt_ECarPlate.Text.Trim();
            DateTime _RegisDate = DateTime.MinValue;
            DateTime.TryParse(this.Txt_RegisDate.Text, out _RegisDate);
            _p.Regis_Date = _RegisDate;
            string cartax = this.Txt_CarTax.Text.Trim();
            _p.CarTax = this.Txt_CarTax.Text.Trim();
            int cartype = 0;
            if (this.DD_ECarType.SelectedIndex != 0)
            {
                
                _p._CarType.ID = int.Parse(this.DD_ECarType.SelectedValue);
                cartype = int.Parse(this.DD_ECarType.SelectedValue);
            }

            string invoice_date = Txt_InvoiceDate.Text.ToString();
            string getinvoice_date = Txt_GetInvoiceDate.Text.ToString();
            string tran_date = Txt_SendTranSportDate.Text.ToString();
            string getguide_date = Txt_GetGuideDate.Text.ToString();
            string getbadge_date = Txt_GetBadgeDate.Text.ToString();
            string noteset_date = Txt_NoteSetDate.Text.ToString();
            string getnoteset_date = Txt_SendNoteSetDate.Text.ToString();
            string remarkInvoice = remarkInvoice_TextBox.Text.ToString(); 
            
            _InvoiceList invoicelist = new _InvoiceList();
            try
            {
                invoicelist.selectInvoice(poid);
                var dt = invoicelist.InvoiceAll;
                //var row = dt.Rows;
                if (dt.Rows[0] != null)
                {
                    invoicelist.updateCarInfo(poid,carplate,_RegisDate,cartax,cartype);
                    invoicelist.editInvoice(poid, invoice_date, getinvoice_date, tran_date, getguide_date, getbadge_date, noteset_date, getnoteset_date,remarkInvoice); 

                }   
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                invoicelist.updateCarInfo(poid, carplate, _RegisDate, cartax, cartype);
                invoicelist.insertInvoice(poid, invoice_date, getinvoice_date, tran_date, getguide_date, getbadge_date, noteset_date, getnoteset_date,remarkInvoice);
            }
            finally
            {
                this.cancelEditInvoice();
            }
            
        }

        protected void Img_CancelInvoice_Click(object sender, ImageClickEventArgs e)
        {
            this.cancelEditInvoice();
        }

        public void cancelEditInvoice()
        {
            this.Txt_ECarPlate.Enabled = false;
            this.Txt_RegisDate.Enabled = false;
            this.Img_RegisDate.Visible = false;
            this.Txt_CarTax.Enabled = false;
            this.DD_ECarType.Enabled = false;

            this.Txt_InvoiceDate.Enabled = false;
            this.Img_InvoiceDate.Enabled = false;
            this.Txt_GetInvoiceDate.Enabled = false;
            this.Txt_NoteSetDate.Enabled = false;
            this.Txt_SendNoteSetDate.Enabled = false;
            this.Txt_SendTranSportDate.Enabled = false;
            this.Txt_GetGuideDate.Enabled = false;
            this.Txt_GetBadgeDate.Enabled = false;
            this.remarkInvoice_TextBox.Enabled = false;

            this.Panel_EditInvoice.Visible = true;
            this.Panel_SaveInvoice.Visible = false;
        }

        _InvoiceList invoicelist = new _InvoiceList();
        _InvoiceList._Invoice invoices = new _InvoiceList._Invoice();
        
        public void getDataInvoice()
        {
            int poid = Int32.Parse(Lb_EPOID.Text.ToString());
            invoices.selectInvoice(poid);
            try
            {

                this.Txt_InvoiceDate.Text = invoices._Invoice_Date == DateTime.MinValue ? "ไม่ระบุ" : invoices._Invoice_Date.ToString("dd MMM yy");
                this.Txt_GetInvoiceDate.Text = invoices._GetInvoice_Date == DateTime.MinValue ? "ไม่ระบุ" : invoices._GetInvoice_Date.ToString("dd MMM yy");
                this.Txt_NoteSetDate.Text = invoices._NoteSet_Date == DateTime.MinValue ? "ไม่ระบุ" : invoices._NoteSet_Date.ToString("dd MMM yy");
                this.Txt_SendNoteSetDate.Text = invoices._GetNotSet_Date == DateTime.MinValue ? "ไม่ระบุ" : invoices._GetNotSet_Date.ToString("dd MMM yy");
                this.Txt_SendTranSportDate.Text = invoices._Transport_Date == DateTime.MinValue ? "ไม่ระบุ" : invoices._Transport_Date.ToString("dd MMM yy");
                this.Txt_GetGuideDate.Text = invoices._GetGuide == DateTime.MinValue ? "ไม่ระบุ" : invoices._GetGuide.ToString("dd MMM yy");
                this.Txt_GetBadgeDate.Text = invoices._GetBadge_Date == DateTime.MinValue ? "ไม่ระบุ" : invoices._GetBadge_Date.ToString("dd MMM yy");
                this.remarkInvoice_TextBox.Text = invoices._RemarkInvoice.ToString() == string.Empty || invoices._RemarkInvoice.ToString() == "-" || invoices._RemarkInvoice.ToString() == "1900-01-01" ? "-" : invoices._RemarkInvoice.ToString();

            }
            catch (Exception ex)
            {
                this.Txt_InvoiceDate.Text = "ไม่ระบุ";
                this.Txt_GetInvoiceDate.Text = "ไม่ระบุ";
                this.Txt_NoteSetDate.Text = "ไม่ระบุ";
                this.Txt_SendNoteSetDate.Text = "ไม่ระบุ";
                this.Txt_SendTranSportDate.Text = "ไม่ระบุ";
                this.Txt_GetGuideDate.Text = "ไม่ระบุ";
                this.Txt_GetBadgeDate.Text = "ไม่ระบุ";
                string error = ex.Message;
            }
        }
        protected void Txt_RegisDate_TextChanged(object sender, EventArgs e)
        {
            DateTime _RegisDate = DateTime.MinValue;
            if (this.Txt_InvoiceDate.Text.Trim() != string.Empty)
            {
                bool complete = false;

                complete = DateTime.TryParse(this.Txt_RegisDate.Text, out _RegisDate);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันออกใบกำกับ!');", true);
                }
                else
                {
                    this.Txt_RegisDate.Text = _RegisDate.ToString("dd MMM yy");
                }
            }
            else if (this.Txt_InvoiceDate.Text.Trim() == string.Empty)
            {
                this.Txt_InvoiceDate.Text = "ไม่ระบุ";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }

        protected void Txt_InvoiceDate_TextChanged(object sender, EventArgs e)
        {
            DateTime _Invoice = DateTime.MinValue;
            if (this.Txt_InvoiceDate.Text.Trim() != string.Empty)
            {
                bool complete = false;
                
                complete = DateTime.TryParse(this.Txt_InvoiceDate.Text, out _Invoice);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันออกใบกำกับ!');", true);
                }
                else
                {
                    this.Txt_InvoiceDate.Text = _Invoice.ToString("dd MMM yy");
                }
            }
            else if (this.Txt_InvoiceDate.Text.Trim() == string.Empty)
            {
                this.Txt_InvoiceDate.Text = "ไม่ระบุ";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }
        protected void Txt_GetInvoiceDate_TextChanged(object sender, EventArgs e)
        {
            DateTime _GetInvoice = DateTime.MinValue;
            if (this.Txt_GetInvoiceDate.Text.Trim() != string.Empty)
            {
                bool complete = false;
                complete = DateTime.TryParse(this.Txt_GetInvoiceDate.Text, out _GetInvoice);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันรับใบกำกับ!');", true);
                }
                else
                {
                    this.Txt_GetInvoiceDate.Text = _GetInvoice.ToString("dd MMM yy");
                }
            }
            else if (this.Txt_GetInvoiceDate.Text.Trim() == string.Empty)
            {
                this.Txt_GetInvoiceDate.Text = "ไม่ระบุ";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }
        protected void Txt_NoteSetDate_TextChanged(object sender, EventArgs e)
        {
            DateTime _NoteSet = DateTime.MinValue;
            if (this.Txt_NoteSetDate.Text.Trim() != string.Empty)
            {
                bool complete = false;
                complete = DateTime.TryParse(this.Txt_NoteSetDate.Text, out _NoteSet);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันรับชุดจดทะเบียน!');", true);
                }
                else
                {
                    this.Txt_NoteSetDate.Text = _NoteSet.ToString("dd MMM yy");
                }
            }
            else if (this.Txt_NoteSetDate.Text.Trim() == string.Empty)
            {
                this.Txt_NoteSetDate.Text = "ไม่ระบุ";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }
        protected void Txt_SendNoteSetDate_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_SendNoteSetDate.Text.Trim() != string.Empty)
            {
                bool complete = false;
                DateTime _SendNoteSet = DateTime.MinValue;
                complete = DateTime.TryParse(this.Txt_SendNoteSetDate.Text, out _SendNoteSet);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันส่งชุดจดทะเบียน!');", true);
                }
                else
                {
                    this.Txt_SendNoteSetDate.Text = _SendNoteSet.ToString("dd MMM yy");
                }
            }
            else if (this.Txt_SendNoteSetDate.Text.Trim() == string.Empty)
            {
                this.Txt_SendNoteSetDate.Text = "ไม่ระบุ";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }
        protected void Txt_SendTranSportDate_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_SendTranSportDate.Text.Trim() != string.Empty)
            {
                bool complete = false;
                DateTime _SendTranSportDate = DateTime.MinValue;
                complete = DateTime.TryParse(this.Txt_SendTranSportDate.Text, out _SendTranSportDate);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันส่งขนส่ง!');", true);
                }
                else
                {
                    this.Txt_SendTranSportDate.Text = _SendTranSportDate.ToString("dd MMM yy");
                }
            }
            else if (this.Txt_SendTranSportDate.Text.Trim() == string.Empty)
            {
                this.Txt_SendTranSportDate.Text = "ไม่ระบุ";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }
        protected void Txt_GetGuideDate_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_GetGuideDate.Text.Trim() != string.Empty)
            {
                bool complete = false;
                DateTime _GetGuideDate = DateTime.MinValue;
                complete = DateTime.TryParse(this.Txt_GetGuideDate.Text, out _GetGuideDate);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันรับคู่มือ!');", true);
                }
                else
                {
                    this.Txt_GetGuideDate.Text = _GetGuideDate.ToString("dd MMM yy");
                }
            }
            else if (this.Txt_GetGuideDate.Text.Trim() == string.Empty)
            {
                this.Txt_GetGuideDate.Text = "ไม่ระบุ";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }
        protected void Txt_GetBadgeDate_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_GetBadgeDate.Text.Trim() != string.Empty)
            {
                bool complete = false;
                DateTime _GetBadgeDate = DateTime.MinValue;
                complete = DateTime.TryParse(this.Txt_GetBadgeDate.Text, out _GetBadgeDate);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันรับป้าย!');", true);
                }
                else
                {
                    this.Txt_GetBadgeDate.Text = _GetBadgeDate.ToString("dd MMM yy");
                }
            }
            else if (this.Txt_GetBadgeDate.Text.Trim() == string.Empty)
            {
                this.Txt_GetBadgeDate.Text = "ไม่ระบุ";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "formInUse = false;", true);
        }
    }
}