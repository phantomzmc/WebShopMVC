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
    public partial class _PurchaseForm : System.Web.UI.Page
    {
        decimal SumAdAcc = 0 ,SumDc = 0;
        private _CareerList _CareerList;
        private _ProvinceList _ProvinceList;
        private _AmphurList _AmphurList;
        private _DistrictList _DistrictList;
        private BodyClassList _BodyClassList;
        private _Postel _Postel;
        private _AddressList _AddList;
        private _AddressList _SentAddList;
        private _Accessorieslist _SetAccList;
        private _AccessoriesSTDList _SetAccSTDList;
        private _AdAccessoriesList _AdAccList;
        private _DiscountList _DcList;
        private BodyOptionList _BodyOptionList;
        private BodyOptionList _ddlbodyoption;
        private BodyOptionExtraList _BodyOptionExtraList;
        private BodyOptionExtraList _ddlbodyoptionExtra;

        protected void Page_Load(object sender, EventArgs e)
        {            
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
                this._BodyOptionList = (BodyOptionList)Session["BodyOption"];
            }
            if (Session["BodyExtra"] != null)
            {
                this._BodyOptionExtraList = (BodyOptionExtraList)Session["BodyExtra"];
            }
            if (!IsPostBack)
            {
                Session["AddList"] = null;
                Session["SentAddList"] = null;
                Session["CheckAdd"] = null;
                Session["SetAccList"] = null;
                Session["SetACCSTD"] = null;
                Session["AdAccList"] = null;
                Session["DcList"] = null;
                Session["BodyOption"] = null;
                Session["BodyExtra"] = null;

                string _datenow = DateTime.Now.ToString("dd-MMM-yy");
                DateTime _Ndate = DateTime.MinValue;
                DateTime.TryParse(_datenow, out _Ndate);
                this.Txt_Date.Text = _Ndate.ToString("dd MMM yy");
                this.Txt_SDate.Text = this.Txt_Date.Text;

                this._CareerList = new _CareerList();
                _CareerList.Select(1);
                this.DD_Career.DataSource = _CareerList.Values;
                this.DD_Career.DataTextField = "Name";
                this.DD_Career.DataValueField = "ID";
                this.DD_Career.DataBind();
                this.DD_Career.Items.Insert(0, "-- เลือก --");
                this.DD_Career.SelectedIndex = 0;

                this.DD_SCareer.DataSource = _CareerList.Values;
                this.DD_SCareer.DataTextField = "Name";
                this.DD_SCareer.DataValueField = "ID";
                this.DD_SCareer.DataBind();

                this.AddEmptyData();

                _EducationList _Education = new _EducationList();
                _Education.Select(1);
                this.DD_Education.DataSource = _Education.Values;
                this.DD_Education.DataTextField = "Detail";
                this.DD_Education.DataValueField = "ID";
                this.DD_Education.DataBind();
                this.DD_Education.SelectedIndex = 0;

                this.DD_SEducation.DataSource = _Education.Values;
                this.DD_SEducation.DataTextField = "Detail";
                this.DD_SEducation.DataValueField = "ID";
                this.DD_SEducation.DataBind();

                _IncomeList _Income = new _IncomeList();
                _Income.Select(1);
                this.DD_InCome.DataSource = _Income.Values;
                this.DD_InCome.DataTextField = "Detail";
                this.DD_InCome.DataValueField = "ID";
                this.DD_InCome.DataBind();
                this.DD_InCome.SelectedIndex = 0;

                this.DD_SInCome.DataSource = _Income.Values;
                this.DD_SInCome.DataTextField = "Detail";
                this.DD_SInCome.DataValueField = "ID";
                this.DD_SInCome.DataBind();

                //this.Panel_CustomerData.Visible = false;
                this.Panel1.Visible = false;
                this.Btn_AddSendAddress.Visible = false;
                //this.Panel_CarData.Visible = false;

                #region ข้อมูลรถ

                #endregion

                #region อุปกรณ์ตกแต่ง
                _InsuranceList _InList = new _InsuranceList();
                _InList.Select(1);
                this.DD_Insurance.DataSource = _InList.Values;
                this.DD_Insurance.DataTextField = "Name";
                this.DD_Insurance.DataValueField = "ID";
                this.DD_Insurance.DataBind();
                this.DD_Insurance.Items.Insert(0, "-- เลือก --");
                this.DD_Insurance.SelectedIndex = 0;

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
                #endregion

                if (Request.QueryString["MCNumber"].ToString() != "0")
                {
                    string _MCNumber = Request.QueryString["MCNumber"];
                    Tb_UserList.Tb_User _u = new Tb_UserList.Tb_User();
                    string _id = Request.QueryString["UID"];
                    int UID = int.Parse(Request.QueryString["UID"].ToString());
                    _u.Select(2, string.Empty, string.Empty, UID);
                    if (_u.ID != 0)
                    {
                        Session["login"] = _u.ID;
                        Session["Emp_id"] = _u.EmpID;
                        Session["EmpName"] = "ยินดีต้อนรับ คุณ " + _u.FullName + " [" + _u.NickName + "] เข้าสู่ระบบ";
                        Session["UserType"] = _u.UserType;

                        DataTable _dtTeam = new DataTable();
                        _dtTeam.Columns.Add("Team", typeof(string));
                        _dtTeam.Columns.Add("Company", typeof(string));
                        _dtTeam.Columns.Add("Branch", typeof(string));

                        _dtTeam.Rows.Add(_u.Team, _u.Company, _u.Branch);
                        Session["TeamCB"] = _dtTeam;

                        //Response.Redirect("~/_Form/_MainForm.aspx");
                    }

                    

                    string[] spChar = { "+", "&", "%", "$" };
                    string[] replaceChar = { "_plus", "_amp", "_per", "_dol" };

                    for (int i = 0; i <= spChar.Length - 1; i++)
                    {
                        _MCNumber = _MCNumber.Replace(replaceChar[i],spChar[i]);
                    }

                    _MCNumber = _Encryption.Decrypt(_MCNumber);
                    this.Txt_SMCNumber.Text = _MCNumber.ToString();
                    this.GETDATA();

                }
            }

            if (Session["login"] == null)
            {
                Response.Redirect("~/Account/_LoginForm.aspx");
            }
        }

        protected void Txt_Birthday_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_Birthday.Text.Trim() != string.Empty)
            {
                bool complete = false;
                DateTime _Birthday = DateTime.MinValue;
                complete = DateTime.TryParse(this.Txt_Birthday.Text, out _Birthday);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันเกิด!');", true);
                }
                else
                {
                    this.Txt_Birthday.Text = _Birthday.ToString("dd MMM yy");
                }
            }
        }

        private void SetPopupAdd()
        {
            this.Txt_Add_Address.Text = string.Empty;
            this.Txt_Add_Moo.Text = string.Empty;
            this.Txt_Add_HomeName.Text = string.Empty;
            this.Txt_Add_Road.Text = string.Empty;
            this.Txt_Add_Soi.Text = string.Empty;
            this.Txt_Add_Postel.Text = string.Empty;

            this._ProvinceList = new _ProvinceList();
            _ProvinceList.Select(1);
            this.DD_Add_Province.DataSource = _ProvinceList.Values;
            this.DD_Add_Province.DataTextField = "PROVINCE_NAME";
            this.DD_Add_Province.DataValueField = "PROVINCE_ID";
            this.DD_Add_Province.DataBind();
            this.DD_Add_Province.Items.Insert(0, "-- เลือกจังหวัด --");
            this.DD_Add_Province.SelectedValue = "38";

            this._AmphurList = new _AmphurList();
            _AmphurList.Select(1, int.Parse(this.DD_Add_Province.SelectedValue));
            this.DD_Add_Amphur.DataSource = _AmphurList.Values;
            this.DD_Add_Amphur.DataTextField = "AMPHUR_NAME";
            this.DD_Add_Amphur.DataValueField = "AMPHUR_ID";
            this.DD_Add_Amphur.DataBind();
            this.DD_Add_Amphur.Items.Insert(0, "-- เลือกอำเภอ --");
            this.DD_Add_Amphur.SelectedIndex = 0;

            this.DD_Add_District.DataSource = null;
            this.DD_Add_District.DataBind();

            this.Panel1_AddAddress_Err.Visible = false;
        }

        protected void Btn_AddAddress_Click(object sender, EventArgs e)
        {
            this.SetPopupAdd();

            Session["CheckAdd"] = "Add";
            this.Lb_AddName.Text = "เพิ่มที่อยู่";
            this.ModalPopupExtender_Address.Show();
        }

        protected void Img_Close_Click(object sender, ImageClickEventArgs e)
        {
            this.ModalPopupExtender_Address.Hide();
        }

        protected void DD_Add_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DD_Add_Province.SelectedIndex != 0)
            {
                this._AmphurList = new _AmphurList();
                _AmphurList.Select(1, int.Parse(this.DD_Add_Province.SelectedValue));
                this.DD_Add_Amphur.DataSource = _AmphurList.Values;
                this.DD_Add_Amphur.DataTextField = "AMPHUR_NAME";
                this.DD_Add_Amphur.DataValueField = "AMPHUR_ID";
                this.DD_Add_Amphur.DataBind();
                this.DD_Add_Amphur.Items.Insert(0, "-- เลือกอำเภอ --");
                this.DD_Add_Amphur.SelectedIndex = 0;
            }
            this.ModalPopupExtender_Address.Show();
        }

        protected void DD_Add_Amphur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DD_Add_Amphur.SelectedIndex != 0)
            {
                this._DistrictList = new _DistrictList();
                _DistrictList.Select(1,int.Parse(this.DD_Add_Province.SelectedValue),int.Parse(this.DD_Add_Amphur.SelectedValue));
                this.DD_Add_District.DataSource = _DistrictList.Values;
                this.DD_Add_District.DataTextField = "DISTRICT_NAME";
                this.DD_Add_District.DataValueField = "DISTRICT_ID";
                this.DD_Add_District.DataBind();
                this.DD_Add_District.Items.Insert(0, "-- เลือกตำบล --");
                this.DD_Add_District.SelectedIndex = 0;
            }
            this.ModalPopupExtender_Address.Show();

        }

        protected void Btn_CancelAddAddress_Click(object sender, EventArgs e)
        {
            this.ModalPopupExtender_Address.Hide();
        }

        protected void DD_Add_District_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DD_Add_District.SelectedIndex != 0)
            {
                this._Postel = new _Postel();
                _Postel.Select(1, int.Parse(this.DD_Add_District.SelectedValue));
                if (_Postel != null)
                {
                    this.Txt_Add_Postel.Text = _Postel.Postel_Code;
                }
                else
                {
                    this.Txt_Add_Postel.Text = string.Empty;
                } 
            }
            this.ModalPopupExtender_Address.Show();
        }

        protected void Btn_SaveAddAddress_Click(object sender, EventArgs e)
        {
            if (this.Txt_Add_Address.Text.Trim() == string.Empty || this.Txt_Add_Address.Text.Trim() == "")
            {
                this.Lb_AddAddress_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขที่!";
                this.Panel1_AddAddress_Err.Visible = true;
                this.ModalPopupExtender_Address.Show();
                return;
            }
            else if (this.DD_Add_Province.SelectedIndex == 0)
            {
                this.Lb_AddAddress_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจังหวัด!";
                this.Panel1_AddAddress_Err.Visible = true;
                this.ModalPopupExtender_Address.Show();
                return;
            }
            else if (this.DD_Add_Amphur.SelectedIndex == 0)
            {
                this.Lb_AddAddress_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุอำเภอ!";
                this.Panel1_AddAddress_Err.Visible = true;
                this.ModalPopupExtender_Address.Show();
                return;
            }
            else if (this.DD_Add_District.SelectedIndex == 0)
            {
                this.Lb_AddAddress_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุตำบล!";
                this.Panel1_AddAddress_Err.Visible = true;
                this.ModalPopupExtender_Address.Show();
                return;
            }

            if ((string)Session["CheckAdd"] == "Add")
            {
                this._AddList = new _AddressList();
            }
            else if ((string)Session["CheckAdd"] == "Sent")
            {
                this._SentAddList = new _AddressList();
            }

            
            _AddressList._Address _Add = new _AddressList._Address();
            _Add.Address = this.Txt_Add_Address.Text.Trim();

            if (this.Txt_Add_Moo.Text.Trim() != string.Empty)
            {
                _Add.Add_Moo = int.Parse(this.Txt_Add_Moo.Text.Trim());
            }
            if (this.Txt_Add_HomeName.Text.Trim() != string.Empty)
            {
                _Add.Add_HomeName = this.Txt_Add_HomeName.Text.Trim();
            }
            if (this.Txt_Add_Road.Text.Trim() != string.Empty)
            {
                _Add.Add_Road = this.Txt_Add_Road.Text.Trim();
            }
            if (this.Txt_Add_Soi.Text.Trim() != string.Empty)
            {
                _Add.Add_Soi = this.Txt_Add_Soi.Text.Trim();
            }

            _Add._District.DISTRICT_ID = int.Parse(this.DD_Add_District.SelectedValue);
            _Add._District.DISTRICT_NAME = this.DD_Add_District.SelectedItem.Text;
            _Add._Amphur.AMPHUR_ID = int.Parse(this.DD_Add_Amphur.SelectedValue);
            _Add._Amphur.AMPHUR_NAME = this.DD_Add_Amphur.SelectedItem.Text;
            _Add._Province.PROVINCE_ID = int.Parse(this.DD_Add_Province.SelectedValue);
            _Add._Province.PROVINCE_NAME = this.DD_Add_Province.SelectedItem.Text;

            if (this.Txt_Add_Postel.Text.Trim() != string.Empty)
            {
                _Add._Postel.Postel_Code = this.Txt_Add_Postel.Text.Trim();
            }
            if ((string)Session["CheckAdd"] == "Add")
            {
                this._AddList.Add(1, _Add);
                Session.Add("AddList", this._AddList);
                this.gv_Address.DataSource = this._AddList.Values;
                this.gv_Address.DataBind();
                this.Btn_AddAddress.Visible = false;
            }
            else
            {
                this._SentAddList.Add(1, _Add);
                Session.Add("SentAddList", this._SentAddList);
                this.gv_SentAddress.DataSource = this._SentAddList.Values;
                this.gv_SentAddress.DataBind();
                this.Btn_AddSendAddress.Visible = false;
            }
            
            this.ModalPopupExtender_Address.Hide();
        }

        protected void LinkBtn_CarData_Click(object sender, EventArgs e)
        {
            this.CarData_Click();
            //this.LinkBtn_CarData.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6189df");
            //this.LinkBtn_CarData.BackColor = Color.White;

            //this.LinkBtn_CusData.ForeColor = Color.White;
            //this.LinkBtn_CusData.BackColor = System.Drawing.ColorTranslator.FromHtml("#6189df");

            //this.Panel_CustomerData.Visible = false;
            //this.Panel_CarData.Visible = true;
        }

        private void CarData_Click()
        {
                this.ColorLinkBtn_Click(this.LinkBtn_CarData);
                this.ColorLinkBtn_UnClick(this.LinkBtn_CusData);
                this.ColorLinkBtn_UnClick(this.LinkBtn_Accessories);
                this.ColorLinkBtn_UnClick(this.LinkButton_Finance);

                this.Panel_CarData.Visible = true;
                this.Panel_CustomerData.Visible = false;
                this.Panel_SCustomerData.Visible = false;
                this.Panel_Accessories.Visible = false;
                this.Panel_Finance.Visible = false;
        }

        protected void LinkBtn_CusData_Click(object sender, EventArgs e)
        {
            //this.LinkBtn_CusData.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6189df");
            //this.LinkBtn_CusData.BackColor = Color.White;
            this.CusData_Click();

            //this.Panel_CustomerData.Visible = true;
            //this.Panel_CarData.Visible = false;

            //this.LinkBtn_CarData.ForeColor = Color.White;
            //this.LinkBtn_CarData.BackColor = System.Drawing.ColorTranslator.FromHtml("#6189df");
        }

        private void CusData_Click()
        {
            if (this.Txt_CusID.Text == string.Empty)
            {
                this.ColorLinkBtn_Click(this.LinkBtn_CusData);
                this.ColorLinkBtn_UnClick(this.LinkBtn_CarData);
                this.ColorLinkBtn_UnClick(this.LinkBtn_Accessories);
                this.ColorLinkBtn_UnClick(this.LinkButton_Finance);

                this.Panel_CustomerData.Visible = true;
                this.Panel_SCustomerData.Visible = false;
                this.Panel_CarData.Visible = false;
                this.Panel_Accessories.Visible = false;
                this.Panel_Finance.Visible = false;
            }
            else
            {
                this.ColorLinkBtn_Click(this.LinkBtn_CusData);
                this.ColorLinkBtn_UnClick(this.LinkBtn_CarData);
                this.ColorLinkBtn_UnClick(this.LinkBtn_Accessories);
                this.ColorLinkBtn_UnClick(this.LinkButton_Finance);

                this.Panel_CustomerData.Visible = false;
                this.Panel_SCustomerData.Visible = true;
                this.Panel_CarData.Visible = false;
                this.Panel_Accessories.Visible = false;
                this.Panel_Finance.Visible = false;
            }
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


        private void AddEmptyData()
        {
            _AddressList _alist = new _AddressList();
            _AddressList._Address temp = new _AddressList._Address();
            _alist.Add(0, temp);
            this.gv_Address.DataSource = _alist.Values;
            this.gv_Address.DataBind();
        }

        protected void Img_Add_Del_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gv = (GridViewRow)((ImageButton)sender).NamingContainer;
            this._AddList.Remove(1);
            if (this._AddList.Count == 0)
            {
                this.AddEmptyData();
                this.Btn_AddAddress.Visible = true;
            }
            else
            {
                this.gv_Address.DataSource = this._AddList.Values;
                this.gv_Address.DataBind();     
            }
        }

        protected void Img_SentAdd_Del_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gv = (GridViewRow)((ImageButton)sender).NamingContainer;
            this._SentAddList.Remove(1);
            if (this._SentAddList.Count == 0)
            {
                _AddressList _alist = new _AddressList();
                _AddressList._Address temp = new _AddressList._Address();
                _alist.Add(0, temp);
                this.gv_SentAddress.DataSource = _alist.Values;
                this.gv_SentAddress.DataBind();
                this.Btn_AddSendAddress.Visible = true;
            }
            else
            {
                this.gv_Address.DataSource = this._SentAddList.Values;
                this.gv_Address.DataBind();
            }
        }

        protected void Cb_SendAddress_New_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Cb_SendAddress_New.Checked == true)
            {
                this.SentAdd_N();
            }
            else
            {
                this.SentAdd_Y();
            }
            
        }

        protected void Cb_SendAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Cb_SendAddress.Checked == true)
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
            this.Cb_SendAddress.Checked = true;
            this.Cb_SendAddress_New.Checked = false;
            this.Btn_AddSendAddress.Visible = false;
            this.gv_SentAddress.Visible = false;
        }

        private void SentAdd_N()
        {
            this.Cb_SendAddress_New.Checked = true;
            this.Cb_SendAddress.Checked = false;
            this.Btn_AddSendAddress.Visible = true;
            _AddressList _alist = new _AddressList();
            _AddressList._Address temp = new _AddressList._Address();
            _alist.Add(0, temp);
            this.gv_SentAddress.DataSource = _alist.Values;
            this.gv_SentAddress.DataBind();
            this.gv_SentAddress.Visible = true;
        }

        protected void Btn_AddSendAddress_Click(object sender, EventArgs e)
        {
            this.SetPopupAdd();

            Session["CheckAdd"] = "Sent";
            this.Lb_AddName.Text = "เพิ่มที่อยู่ส่งเอกสาร";
            this.ModalPopupExtender_Address.Show();
        }

        protected void Btn_SMCNumber_Click(object sender, EventArgs e)
        {
            this.Panel_SMCNumber_Err.Visible = false;
            if (this.Txt_SMCNumber.Text.Trim() == string.Empty || this.Txt_SMCNumber.Text.Trim() == "")
            {
                this.Lb_SMcNumber_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุหมายเลขเครื่อง!";
                this.Panel_SMCNumber_Err.Visible = true;
                this.Panel1.Visible = false;
                return;
            }

            SearchMCNumber _smChk = new SearchMCNumber();
            _smChk.SelectChk(1, this.Txt_SMCNumber.Text.Trim());
            if (_smChk._Purchase.ID != 0)
            {
                this.Lb_SMcNumber_Err.Text = "ไม่สามารถทำรายการได้ : หมายเลขเครื่องนี้ได้ลงระบบเรียบร้อยแล้ว กรุณาตรวจสอบหมายเลขเครื่อง!";
                this.Panel_SMCNumber_Err.Visible = true;
                this.Panel1.Visible = false;
                return;
            }

            this.GETDATA();
            
        }

        private void GETDATA()
        {
            
            _CompanyList _company = new _CompanyList();
            _company.Select(1);
            this.Rb_Company.DataSource = _company.Values;
            this.Rb_Company.DataTextField = "CompanyName";
            this.Rb_Company.DataValueField = "Companycode";
            this.Rb_Company.DataBind();

            SearchMCNumber _sm = new SearchMCNumber();
            _sm.Select(1, this.Txt_SMCNumber.Text.Trim(), (int)Session["Emp_id"]);
            
            if (_sm._Customer.Name != string.Empty)
            {
                #region ข้อมูลลูกค้า
                this.EmpData_Empty();

                this.GETDATA_CUS(_sm._Customer.CusType, _sm._Customer.IDCard, _sm._Customer.CorporationCode);
                if (this.Txt_CusID.Text == string.Empty)
                {
                    this.DD_CusType.SelectedValue = _sm._Customer.CusType;
                    if (_sm._Customer.CusType == "บุคคล")
                    {

                        this.Txt_Name.Text = _sm._Customer.Name;
                        this.Txt_Surname.Text = _sm._Customer.Surname;
                        DateTime _Bd = _sm._Customer.Birthday;
                        if (_Bd.ToString() != "1/1/0544 0:00:00")
                        {
                            this.Txt_Birthday.Text = _sm._Customer.Birthday.ToString("dd MMM yy");
                        }
                        else
                        {
                            this.Txt_Birthday.Text = string.Empty;
                        }

                        this.Txt_IDCard.Text = _sm._Customer.IDCard.Trim();
                        this.Panel_Person.Visible = true;
                        this.Panel_Company.Visible = false;
                    }
                    else
                    {
                        this.Txt_CorporationCode.Text = _sm._Customer.CorporationCode;
                        this.Txt_CompanyName.Text = _sm._Customer.Name;
                        this.Panel_Company.Visible = true;
                        this.Panel_Person.Visible = false;
                    }


                    this.Txt_TelMobile1.Text = _sm._Customer.Tel_Mobile1;
                    this.Txt_Career_Remark.Text = _sm._Customer.Career_Remark;


                    this._AddList = new _AddressList();
                    _AddressList._Address _Add = new _AddressList._Address();
                    _Add.Address = _sm._Address.Address;
                    _Add._District.DISTRICT_ID = _sm._Address._District.DISTRICT_ID;
                    _Add._District.DISTRICT_NAME = _sm._Address._District.DISTRICT_NAME;
                    _Add._Amphur.AMPHUR_ID = _sm._Address._Amphur.AMPHUR_ID;
                    _Add._Amphur.AMPHUR_NAME = _sm._Address._Amphur.AMPHUR_NAME;
                    _Add._Province.PROVINCE_ID = _sm._Address._Province.PROVINCE_ID;
                    _Add._Province.PROVINCE_NAME = _sm._Address._Province.PROVINCE_NAME;
                    _Add._Postel.Postel_Code = _sm._Address._Postel.Postel_Code;
                    this._AddList.Add(1, _Add);
                    Session.Add("AddList", this._AddList);
                    this.gv_Address.DataSource = this._AddList.Values;
                    this.gv_Address.DataBind();
                    this.Btn_AddAddress.Visible = false;
                    //this.Panel_CustomerData.Visible = true;    
                }
                else
                {
                }
                this.Txt_SaleName.Text = _sm._Purchase.SaleName.ToString();
                this.Txt_SSaleName.Text = _sm._Purchase.SaleName.ToString();
                #endregion

                #region ข้อมูลรถ
                this.CarData_Empty();
                this.Rb_Company.SelectedValue = _sm._Purchase._Company.Companycode.ToString();
                DateTime _PDate = _sm._Purchase.Purchase_Date;
                if (_PDate.ToString() != "1/1/0544 0:00:00")
                {
                    this.Txt_Date.Text = _sm._Purchase.Purchase_Date.ToString("dd MMM yy");
                    this.Txt_SDate.Text = this.Txt_Date.Text;
                }
                else
                {
                    this.Txt_Date.Text = string.Empty;
                    this.Txt_SDate.Text = string.Empty;
                }
                this.Txt_EmpID.Text = _sm._Purchase.EmpID.ToString();
                this.Txt_BookID.Text = _sm._Purchase.BookID.ToString();
                this.Txt_BookNo.Text = _sm._Purchase.BookNo;
                this.Txt_ProspectNo.Text = _sm._Purchase.ProspectNo;
                this.DD_BuyType.SelectedValue = _sm._Purchase.Buy_Type;
                this.Txt_MCNumber.Text = _sm._Purchase.MCNumber;
                this.Txt_TruckNumber.Text = _sm._Purchase.TruckNumber;
                this.Txt_MCode.Text = _sm._Purchase.MCode;
                this.Txt_MName.Text = _sm._Purchase.MName;
                this.Txt_MSaleCode.Text = _sm._Purchase.MSaleCode;
                this.Txt_CCode.Text = _sm._Purchase.CCode;
                this.Txt_CName.Text = _sm._Purchase.CName;
                decimal _CarPrice = decimal.Parse(_sm._Purchase.CarPrice.ToString());
                if (_CarPrice != 0)
                {
                    this.Txt_CarPrice.Text = string.Format("{0:#,###}", decimal.Parse(_CarPrice.ToString()));
                    this.Txt_CarPrice1.Text = this.Txt_CarPrice.Text;
                }
                this.Txt_StatusCE.Text = _sm._Purchase.StatusCE;
                this.CE_Empty();
                if (this.Txt_StatusCE.Text == "Y")
                {
                    this.CE_Y();
                    this.Txt_CEBrand.Text = _sm._Purchase.CE_Brand;
                    this.Txt_CEModel.Text = _sm._Purchase.CE_Model;
                    this.Txt_CEYear.Text = _sm._Purchase.CE_Year;
                    decimal _CEPrice = decimal.Parse(_sm._Purchase.CE_Price.ToString());
                    if (_CEPrice != 0)
                    {
                        this.Txt_CEPrice.Text = string.Format("{0:#,###}", _CEPrice.ToString());
                    }
                }
                else
                {
                    this.CE_N();
                }
                #endregion

                #region อุปกรณ์ตกแต่งเสริมบอดี้

                    this._BodyClassList = new BodyClassList();
                    _BodyClassList.Select(_sm._Purchase.MCode);
                    
                        this.DD_body.DataSource = _BodyClassList.Values;
                        this.DD_body.DataTextField = "Body_Acc_Name";
                        this.DD_body.DataValueField = "Body_Acc_ID";
                        this.DD_body.DataBind();
                        this.DD_body.Items.Insert(0, new ListItem("-- เลือก --", "0"));
                        this.DD_body.SelectedIndex = 0;

                        Session["BodyClassList"] = _BodyClassList;

                        this.lblsumfin.Text = "0.00";
                        this.Lb_Budgetpaybody.Text = "0.00";
                        this.Lb_sumAddfinance.Text = "0.00";

                        Panelbodystandard.Visible = false;
                        Panelbodyextra.Visible = false;
                        if (_BodyClassList.Count == 0)
                        {
                            Rb_bodystandard.Enabled = false;
                            Rb_bodyextra.Enabled = false;
                        }
                #endregion

                #region อุปกรณ์ตกแต่ง
                this.AccData_Empty();

                decimal _CP = decimal.Parse(this.Txt_CarPrice.Text);
                decimal _Percen = 80;
                decimal _Outlay = (_CP * _Percen) / 100;
                this.Txt_InOutlay.Text = String.Format("{0:#,###.##}", Math.Ceiling(_Outlay));

                _InregisList _In = new _InregisList();
                _In.Select(1, int.Parse(this.Txt_BookID.Text));
                if (_In.Count != 0)
                {
                    for (int i = 1; i <= _In.Count; i++)
                    {
                        if (_In[i].Name == "อุปกรณ์ตกแต่ง")
                        {
                            this.Cb_SetAcc.Checked = true;
                            this.Txt_SetAccPrice.Text = string.Format("{0:#,###}", decimal.Parse(_In[i].Budget.ToString()));
                            if (_In[i].Free == "Y")
                            {
                                this.Cb_SetAccFree.Checked = true;
                            }
                            else
                            {
                                this.Cb_SetAccFree.Checked = false;
                            }
                        }
                        else if (_In[i].Name == "อุปกรณ์มาตรฐาน")
                        {
                            this.Cb_AccSTD.Checked = true;
                            this.Txt_AccSTDPrice.Text = string.Format("{0:#,###}", decimal.Parse(_In[i].Budget.ToString()));
                            if (_In[i].Free == "Y")
                            {
                                this.Cb_AccSTDFree.Checked = true;
                            }
                            else
                            {
                                this.Cb_AccSTDFree.Checked = false;
                            }
                        }
                        else if (_In[i].Name == "ประกันภัยชั้น 1")
                        {
                            this.Cb_Insurance1.Checked = true;
                            this.DD_Insurance.SelectedValue = _In[i].InID.ToString();
                            this.Txt_InPrice.Text = string.Format("{0:#,###}", decimal.Parse(_In[i].Budget.ToString()));
                            if (_In[i].Free == "Y")
                            {
                                this.Cb_InFree.Checked = true;
                            }
                            else
                            {
                                this.Cb_InFree.Checked = false;
                            }
                        }
                        else if (_In[i].Name == "ค่าจดทะเบียน")
                        {
                            this.Cb_Regis.Checked = true;
                            this.DD_Regis.SelectedValue = _In[i].CarType;
                            this.Txt_RegisPrice.Text = string.Format("{0:#,###}", decimal.Parse(_In[i].Budget.ToString()));
                            if (_In[i].Free == "Y")
                            {
                                this.Cb_RegisFree.Checked = true;
                            }
                            else
                            {
                                this.Cb_RegisFree.Checked = false;
                            }
                        }
                    }
                }

                this._SetAccList = new _Accessorieslist();
                this._SetAccList.Select(1, int.Parse(this.Txt_BookID.Text));
                Session.Add("SetAccList", this._SetAccList);
                this.gv_SetAccessories.DataSource = this._SetAccList.Values;
                this.gv_SetAccessories.DataBind();

                this._SetAccSTDList = new _AccessoriesSTDList();
                this._SetAccSTDList.Select(1, int.Parse(this.Txt_BookID.Text));
                Session.Add("SetAccSTDList", this._SetAccSTDList);
                this.gv_AccSTD.DataSource = this._SetAccSTDList.Values;
                this.gv_AccSTD.DataBind();

                this.AddEmptyData_AdAcc();
                this.AddEmptyData_Dc();
               
                #endregion

                #region ไฟแนนซ์
                this.Finance_Empty();
                this.DD_Finance.SelectedValue = _sm._Purchase._Finance.ID.ToString();
                if (this.DD_Finance.SelectedValue != "1")
                {
                    decimal _Carprice = decimal.Parse(this.Txt_CarPrice1.Text);
                    decimal _PayDown = 0;
                    if (_sm._Purchase.PayDown != 0)
                    {
                        this.Txt_PayDown.Text = string.Format("{0:#,###}", decimal.Parse(_sm._Purchase.PayDown.ToString()));
                        _PayDown = decimal.Parse(this.Txt_PayDown.Text);
                    }
                    else
                    {
                        this.Txt_PayDown.Text = "0";
                    }
                    this.Txt_DPeak.Text = string.Format("{0:#,###}", ((_sm._Purchase.CarPrice) - (_sm._Purchase.PayDown)));
                    this.Txt_hpcost.Text = this.Txt_DPeak.Text;
                }
                this.Txt_DepositNo.Text = _sm._Purchase.DepositNo;
                DateTime _DeDate = _sm._Purchase.DepositDate;
                if (_DeDate.ToString() != "1/1/0544 0:00:00")
                {
                    this.Txt_DepositDate.Text = _sm._Purchase.DepositDate.ToString("dd MMM yy");
                }
                else
                {
                    this.Txt_DepositDate.Text = string.Empty;
                }
                this.Txt_DepositPrice.Text = string.Format("{0:#,###}", decimal.Parse(_sm._Purchase.DepositPrice.ToString()));

                #endregion

                this.Panel1.Visible = true;
                this.CusData_Click();
                Session["ChkInsert"] = "N";
            }
            else
            {
                this.Lb_SMcNumber_Err.Text = "ไม่พบข้อมูล : กรุณาตรวจสอบหมายเลขเครื่อง!";
                this.Panel_SMCNumber_Err.Visible = true;
            }
        }

        private void GETDATA_CUS(string CusType,string _IDCard, string CorporationCode)
        {
            _Customer _c = new _Customer();
            if (CusType == "บุคคล")
            {
                if (_IDCard.Trim() != string.Empty || _IDCard.Trim() != "")
                {
                    _c.Select(1, _IDCard);
                }               
            }
            else
            {
                if (CorporationCode.Trim() != string.Empty || CorporationCode.Trim() != "")
                {
                    _c.Select(2, CorporationCode);
                }               
            }
            if (_c.ID != 0)
            {
                this.Txt_CusID.Text = _c.ID.ToString();
                this.Txt_CusNo.Text = _c.CusNo;
                this.DD_SCusType.SelectedValue = _c.CusType;
                if (_c.CusType == "บุคคล")
                {
                    this.Txt_SPrefix.Text = _c.Prefix;
                    this.Txt_SName.Text = _c.Name;
                    this.Txt_SSurname.Text = _c.Surname;
                    this.Txt_SNickName.Text = _c.Nickname;

                    DateTime _Bd = _c.Birthday;
                    if (_Bd.ToString() != "1/1/0544 0:00:00")
                    {
                        this.Txt_SBirthDay.Text = _c.Birthday.ToString("dd MMM yy");
                    }
                    else
                    {
                        this.Txt_Birthday.Text = string.Empty;
                    }

                    this.DD_SPreson_Sex.SelectedValue = _c.Sex;
                    this.Txt_SIDCard.Text = _c.IDCard;
                    this.DD_SEducation.SelectedValue = _c._Education.id.ToString();
                    this.Txt_STotal_Member.Text = _c.Total_Member.ToString();

                    this.Panel_SPerson.Visible = true;
                    this.Panel_SCompany.Visible = false;
                }
                else
                {
                    this.Txt_SCorporationCode.Text = _c.CorporationCode;
                    this.Txt_SCompanyName.Text = _c.Name;
                    this.Panel_SCompany.Visible = true;
                    this.Panel_SPerson.Visible = false;
                }
                
                this.DD_SCareer.SelectedValue = _c._Career.ID.ToString();
                if (_c._Career.ID == 11)
                {
                    this.Panel_SCareer_Other.Visible = true;
                    this.Txt_Career_Other.Text = _c.Career_Other.ToString();
                }
                else
                {
                    this.Panel_SCareer_Other.Visible = false;
                }
                this.Txt_SCareer_Remark.Text = _c.Career_Remark;
                this.DD_InCome.SelectedValue = _c._Income.ID.ToString();

                Session.Add("AddList", _c._AddressList);
                this.gv_SAddress.DataSource = _c._AddressList.Values;
                this.gv_SAddress.DataBind();

                if (_c.SendAddress_IDCard == "Y")
                {
                    this.Cb_SSendAddress.Checked = true;
                    this.Cb_SSendAddress_New.Checked = false;
                    this.gv_SSendAddress.Visible = false;
                }
                else
                {
                    this.Cb_SSendAddress.Checked = false;
                    this.Cb_SSendAddress_New.Checked = true;
                    this.gv_SSendAddress.Visible = true;
                }

                
                Session.Add("SendAddList", _c._SentAddressList);
                this.gv_SSendAddress.DataSource = _c._SentAddressList.Values;
                this.gv_SSendAddress.DataBind();

                this.Btn_SAddSendAddress.Visible = false;
            }
            
            

        }

        private void EmpData_Empty()
        {
            this.Txt_CusID.Text = string.Empty;
            this.Txt_Name.Text = string.Empty;
            this.Txt_Surname.Text = string.Empty;
            this.Txt_Birthday.Text = string.Empty;
            this.Txt_Nickname.Text = string.Empty;
            this.DD_Person_Sex.SelectedIndex = 0;
            this.DD_Education.SelectedIndex = 0;
            this.Txt_Total_Member.Text = string.Empty;
            this.Txt_TelMobile2.Text = string.Empty;
            this.Txt_TelHome_Work.Text = string.Empty;
            this.Txt_Fax.Text = string.Empty;
            this.DD_Career.SelectedIndex = 0;
            this.Panel_Career_Other.Visible = false;
            this.DD_InCome.SelectedIndex = 0;
            this.Txt_CompanyName.Text = string.Empty;
            this.SentAdd_Y();
        }

        private void CarData_Empty()
        {
            this.Txt_CarPrice.Text = string.Empty;
            this.Txt_CarPlate.Text = string.Empty;
            //this.Txt_BuyType.Text = string.Empty;
        }

        private void CE_Empty()
        {
            this.Txt_CEMCNumber.Text = string.Empty;
            this.Txt_CETruckNumber.Text = string.Empty;
            this.Txt_CEBrand.Text = string.Empty;
            this.Txt_CEModel.Text = string.Empty;
            this.Txt_CEColor.Text = string.Empty;
            this.Txt_CEYear.Text = string.Empty;
            this.Txt_CECarPlate.Text = string.Empty;
            this.Txt_CEEmp.Text = string.Empty;
        }

        private void CE_Y()
        {
            this.Cb_CE_Y.Checked = true;
            this.Panel_CE_Y.Visible = true;
            this.Cb_CE_N.Checked = false;
            
        }

        private void CE_N()
        {
            this.Cb_CE_Y.Checked = false;
            this.Panel_CE_Y.Visible = false;
            this.Cb_CE_N.Checked = true;
        }

        private void AccData_Empty()
        {
            this.Cb_Insurance1.Checked = false;
            this.DD_Insurance.SelectedIndex = 0;
            this.Txt_InOutlay.Text = string.Empty;
            this.Txt_InPrice.Text = string.Empty;
            this.Cb_InFree.Checked = false;

            this.Cb_Regis.Checked = false;
            this.DD_Regis.SelectedIndex = 0;
            this.Txt_RegisPrice.Text = string.Empty;
            this.Cb_RegisFree.Checked = false;

            this.Cb_Act.Checked = false;
            this.Txt_ActNo.Text = string.Empty;
            this.Txt_ActPrice.Text = string.Empty;
            this.Cb_ActFree.Checked = false;

            this.Cb_Transpot.Checked = false;
            this.Txt_TranspotPrice.Text = string.Empty;
            this.Cb_TranspotFree.Checked = false;

            this.Lb_AdAccPrice.Text = "0";
            this.Lb_PriceDiscount.Text = "0";

        }

        private void Finance_Empty()
        {
            this.Txt_EmpFinance.Text = string.Empty;
            this.Txt_PayDown.Text = string.Empty;
            this.Txt_DPeak.Text = string.Empty;
            this.Txt_hpcost.Text = string.Empty;
            this.Txt_Interest.Text = string.Empty;
            this.Txt_RemarkInterest.Text = string.Empty;
            this.Txt_Price_Payment.Text = string.Empty;
            this.Txt_CampaignName.Text = string.Empty;
            this.Cb_Begin.Checked = false;
            this.Txt_RedCarPlate_No.Text = string.Empty;
            this.Txt_RedCarPlate_Date.Text = string.Empty;
            this.Txt_RedCarPlate_Price.Text = string.Empty;
            this.Txt_RedCarPlate_Num.Text = string.Empty;
            this.Txt_Remark.Text = string.Empty;
            this.Txt_CarPriceAd.Text = string.Empty;
            this.Txt_CarPriceAd_Price.Text = string.Empty;
            this.Txt_LoanProtection.Text = string.Empty;
            this.Txt_PriceSum.Text = string.Empty;
            this.Txt_PriceSumCar.Text = string.Empty;
            this.Txt_DepositAdNo.Text = string.Empty;
            this.Txt_DepositAdDate.Text = string.Empty;
            this.Txt_DepositAdPrice.Text = string.Empty;
        }

        protected void Btn_EditAddress_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((Button)sender).NamingContainer;
            this.SetPopupAdd();

            

            this.Txt_Add_Address.Text = this._AddList[1].Address.ToString();

            int _Moo = this._AddList[1].Add_Moo;
            if (_Moo != 0)
            {
                this.Txt_Add_Moo.Text = _Moo.ToString();
            }
            
            this.Txt_Add_HomeName.Text = this._AddList[1].Add_HomeName.ToString();
            this.Txt_Add_Road.Text = this._AddList[1].Add_Road.ToString();
            this.Txt_Add_Soi.Text = this._AddList[1].Add_Soi.ToString();
            
            this._ProvinceList = new _ProvinceList();
            _ProvinceList.Select(1);
            this.DD_Add_Province.DataSource = _ProvinceList.Values;
            this.DD_Add_Province.DataTextField = "PROVINCE_NAME";
            this.DD_Add_Province.DataValueField = "PROVINCE_ID";
            this.DD_Add_Province.DataBind();
            this.DD_Add_Province.Items.Insert(0, "-- เลือกจังหวัด --");
            this.DD_Add_Province.SelectedValue = this._AddList[1]._Province.PROVINCE_ID.ToString();

            this._AmphurList = new _AmphurList();
            _AmphurList.Select(1, int.Parse(this.DD_Add_Province.SelectedValue));
            this.DD_Add_Amphur.DataSource = _AmphurList.Values;
            this.DD_Add_Amphur.DataTextField = "AMPHUR_NAME";
            this.DD_Add_Amphur.DataValueField = "AMPHUR_ID";
            this.DD_Add_Amphur.DataBind();
            this.DD_Add_Amphur.Items.Insert(0, "-- เลือกอำเภอ --");
            this.DD_Add_Amphur.SelectedValue = this._AddList[1]._Amphur.AMPHUR_ID.ToString();

            this._DistrictList = new _DistrictList();
            _DistrictList.Select(1, int.Parse(this.DD_Add_Province.SelectedValue), int.Parse(this.DD_Add_Amphur.SelectedValue));
            this.DD_Add_District.DataSource = _DistrictList.Values;
            this.DD_Add_District.DataTextField = "DISTRICT_NAME";
            this.DD_Add_District.DataValueField = "DISTRICT_ID";
            this.DD_Add_District.DataBind();
            this.DD_Add_District.Items.Insert(0, "-- เลือกตำบล --");
            this.DD_Add_District.SelectedValue = this._AddList[1]._District.DISTRICT_ID.ToString();

            this.Txt_Add_Postel.Text = this._AddList[1]._Postel.Postel_Code;

            Session["CheckAdd"] = "Add";
            this.Lb_AddName.Text = "แก้ไขที่อยู่";
            this.ModalPopupExtender_Address.Show();
        }

        protected void Cb_CE_Y_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Cb_CE_Y.Checked == true)
            {
                this.CE_Y();
            }
            else
            {
                this.CE_N();
            }
            
        }

        protected void Cb_CE_N_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Cb_CE_N.Checked == true)
            {
                this.CE_N();
            }
            else
            {
                this.CE_Y();
            }
            
        }

        protected void LinkBtn_Accessories_Click(object sender, EventArgs e)
        {
            this.Accessories_Click();
        }

        private void Accessories_Click()
        {
            this.ColorLinkBtn_Click(this.LinkBtn_Accessories);
            this.ColorLinkBtn_UnClick(this.LinkBtn_CusData);
            this.ColorLinkBtn_UnClick(this.LinkBtn_CarData);
            this.ColorLinkBtn_UnClick(this.LinkButton_Finance);

            this.Panel_Accessories.Visible = true;
            this.Panel_CarData.Visible = false;
            this.Panel_CustomerData.Visible = false;
            this.Panel_SCustomerData.Visible = false;
            this.Panel_Finance.Visible = false;
            
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
            SumAdAcc = 0;
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

                if (_Lb_AdAccPrice.Text != "0")
                {
                    _Lb_AdAccPrice.Text = string.Format("{0:#,###}", decimal.Parse(_Lb_AdAccPrice.Text));
                    if (Lb_DAdAccFree.Text == "N")
                    {
                        SumAdAcc = SumAdAcc + decimal.Parse(_Lb_AdAccPrice.Text);
                        this.Lb_AdAccPrice.Text = string.Format("{0:#,###}", SumAdAcc);
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

        private void AddEmptyData_AdAcc()
        {
            _AdAccessoriesList _alist = new _AdAccessoriesList();
            _AdAccessoriesList._AdAccessories temp = new _AdAccessoriesList._AdAccessories();
            _alist.Add(0, temp);
            this.gv_AdAccessories.DataSource = _alist.Values;
            this.gv_AdAccessories.DataBind();
        }

        protected void Img_AdAccDel_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gv = (GridViewRow)((ImageButton)sender).NamingContainer;
            int id = int.Parse(gv_AdAccessories.DataKeys[gv.RowIndex].Value.ToString());
            this._AdAccList.Remove(id);
            if (this._AdAccList.Count == 0)
            {
                this.AddEmptyData_AdAcc();            
                this.Lb_AdAccPrice.Text = "0";
            }
            else
            {
                this.gv_AdAccessories.DataSource = this._AdAccList.Values;
                this.gv_AdAccessories.DataBind();
            }
            SumAdAcc = 0;
        }

        protected void LinkButton_Finance_Click(object sender, EventArgs e)
        {
            this.Finance_Click();
        }

        private void Finance_Click()
        {
            this.ColorLinkBtn_Click(this.LinkButton_Finance);
            this.ColorLinkBtn_UnClick(this.LinkBtn_CusData);
            this.ColorLinkBtn_UnClick(this.LinkBtn_CarData);
            this.ColorLinkBtn_UnClick(this.LinkBtn_Accessories);

            this.Panel_Finance.Visible = true;
            this.Panel_CustomerData.Visible = false;
            this.Panel_SCustomerData.Visible = false;
            this.Panel_CarData.Visible = false;
            this.Panel_Accessories.Visible = false;   
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

        protected void Img_Cal_Click(object sender, ImageClickEventArgs e)
        {
            this.Cal();
        }

        protected void Txt_PayDown_TextChanged(object sender, EventArgs e)
        {
            //if (this.Txt_PayDown.Text.Trim() != string.Empty)
            //{
            //    decimal _Down = decimal.Parse(this.Txt_PayDown.Text.Trim());
            //    decimal _PriceCar = decimal.Parse(this.Txt_CarPrice1.Text.Trim());
            //    decimal _Total = _PriceCar - _Down;
            //    this.Txt_DPeak.Text = String.Format("{0:#,###.##}", Math.Ceiling(_Total));
            //}
            //else
            //{
            //    this.Txt_PayDown.Text = "0";
            //    this.Txt_DPeak.Text = this.Txt_CarPrice1.Text.Trim();
            //}
            this.Cal_Payment();
        }

        private void Cal_Payment()
        {
            this.Txt_Price_Payment.Text = string.Empty;
            this.Txt_PriceSum.Text = string.Empty;
            decimal _PriceCar = decimal.Parse(this.Txt_CarPrice1.Text.Trim());
            decimal _lblsumfin = decimal.Parse(this.lblsumfin.Text.Trim());
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
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if ((string)Session["ChkInsert"] == "Y")
            {
                return;
            }
            _Purchase _p = new _Purchase();
            DataTable _dt = new DataTable();
            _dt = _p.Select_Purchase(4, this.Txt_MCNumber.Text.Trim());
            if (_dt.Rows.Count != 0)
            {
                return;
            }
            this.Panel_ConfirmErr.Visible = false;
            if (this.Cb_Confirm.Checked == false)
            {
                this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณายืนยันตรวจสอบความถูกต้องของข้อมูล!";
                this.Panel_ConfirmErr.Visible = true;
                return;
            }

            #region เช็คบริษัท
            if (this.Rb_Company.SelectedItem == null)
            {
                this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุบริษัทด้วย!";
                this.Panel_ConfirmErr.Visible = true;
                return;
            }
            #endregion

            if (this.Txt_CusID.Text == string.Empty)
            {
                #region เช็คข้อมูลลูกค้า
                if (this.Txt_Date.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันที่ออกรถ!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                if (this.DD_CusType.SelectedItem.Text == "บุคคล")
                {
                    #region เช็คข้อมูลลูกค้าบุคคล
                    if (this.Txt_Prefix.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุคำนำหน้า/ยศ!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }
                    if (this.Txt_Name.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุชื่อ!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }
                    if (this.Txt_Surname.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุนามสกุล!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }

                    if (this.Txt_Birthday.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันเกิด!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }
                    else
                    {
                        bool complete = false;
                        DateTime _Birthday = DateTime.MinValue;
                        complete = DateTime.TryParse(this.Txt_Birthday.Text, out _Birthday);
                        if (complete == false)
                        {
                            this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาตรวจสอบรูปแบบวันเกิด!";
                            this.Panel_ConfirmErr.Visible = true;
                            return;
                        }
                    }

                    if (this.Txt_IDCard.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขบัตรประชาชน!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }
                    else if (this.Txt_IDCard.Text.Trim().Length != 13)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขบัตรประจำตัวประชาชนเป็นตัวเลข 13 หลักเท่านั้น!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }
                    #endregion
                }
                else
                {
                    #region เช็คข้อมูลบริษัท
                    if (this.Txt_CorporationCode.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขนิติบุคคล!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }
                    else if (this.Txt_CorporationCode.Text.Trim().Length != 13)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขนิติบุคคลเป็นตัวเลข 13 หลักเท่านั้น!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }

                    if (this.Txt_CompanyName.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุชื่อบริษัท!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }
                    #endregion
                }

                if (this.Txt_TelMobile1.Text.Trim() == string.Empty && this.Txt_TelMobile2.Text.Trim() == string.Empty && this.Txt_TelHome_Work.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณากรอกเบอร์ มือถือ/บ้าน อย่างน้อย 1 เบอร์!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                else
                {
                    if (this.Txt_TelMobile1.Text.Trim() != string.Empty && this.Txt_TelMobile1.Text.Trim().Length != 10)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเบอร์โทรศัพท์มือถือ 1 เป็นตัวเลข 10 หลักเท่านั้น!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }

                    if (this.Txt_TelMobile2.Text.Trim() != string.Empty && this.Txt_TelMobile2.Text.Trim().Length != 10)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเบอร์โทรศัพท์มือถือ 2 เป็นตัวเลข 10 หลักเท่านั้น!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }
                }

                if (this.DD_Career.SelectedIndex == 0)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุอาชีพ!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                else if (this.DD_Career.SelectedValue == "11" && this.Txt_Career_Other.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุอาชีพอื่นๆ!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }

                if (this._AddList.Count == 0)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาที่อยู่!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                else
                {
                    if (this._AddList[1].Address.ToString() == string.Empty)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุบ้านเลขที่!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }
                }

                if (this.Cb_SendAddress_New.Checked == true)
                {
                    if (this._SentAddList.Count == 0)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาที่อยู่ส่งเอกสาร!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    }
                }
                #endregion
            }
            else
            {
                if (this.Txt_SDate.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันที่ออกรถ!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
            }


            #region เช็คข้อมูลรถ
            if (this.Cb_CE_Y.Checked == true)
            {
                if (this.Txt_CEBrand.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุยี่ห้อรถเก่า!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }

                if (this.Txt_CEYear.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุปีรถเก่า!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }

                if (this.Txt_CEPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุราคารถเก่า!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }

                if (this.Txt_CEEmp.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุผู้ประเมินราคารถเก่า!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
            }
            #endregion

            #region เช็คข้อมูลอุปกรณ์ตกแต่ง
            if (this.Cb_Insurance1.Checked == true)
            {
                if (this.DD_Insurance.SelectedIndex == 0)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุประกันภัยประเภท1!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }

                if (this.Txt_InOutlay.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุทุนประกันภัยประเภท1!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }

                if (this.Txt_InPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุราคาประกันภัยประเภท1!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
            }

            if (this.Cb_Regis.Checked == true && this.Txt_RegisPrice.Text.Trim() == string.Empty)
            {
               this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุราคาค่าจดทะเบียน!";
               this.Panel_ConfirmErr.Visible = true;
               return;
            }

            if (this.Txt_RegisPrice.Text == "0")
            {
                   this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุราคาค่าจดทะเบียนมากกว่า 0 บาท!";
                   this.Panel_ConfirmErr.Visible = true;
                   return;
            }

            if (this.Cb_Act.Checked == true && this.Txt_ActPrice.Text.Trim() == string.Empty)
            {
               this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุราคา พรบ.!";
               this.Panel_ConfirmErr.Visible = true;
               return;
            }

            if (this.Cb_Transpot.Checked == true && this.Txt_TranspotPrice.Text.Trim() == string.Empty)
            {
                this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคา ค่าขนส่ง!";
                this.Panel_ConfirmErr.Visible = true;
                return;
            }

            if (this.Cb_SetAcc.Checked == true && this.Txt_SetAccPrice.Text.Trim() == string.Empty)
            {
                this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคา ชุดอุปกรณ์ตกแต่ง!";
                this.Panel_ConfirmErr.Visible = true;
                return;
            }

            if (this.Cb_AccSTD.Checked == true && this.Txt_AccSTDPrice.Text.Trim() == string.Empty)
            {
                this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคา อุปกรณ์มาตรฐานSTD!";
                this.Panel_ConfirmErr.Visible = true;
                return;
            }

            #endregion

            #region เช็คข้อมูลไฟแนนซ์
            if (this.DD_Finance.SelectedValue != "1")
            {
                if (this.Txt_EmpFinance.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุชื่อเจ้าหน้าที่ไฟแนนซ์!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                if ((this.Txt_CarPriceAd_Price.Text.Trim() != string.Empty && this.Txt_CarPriceAd_Price.Text.Trim() != "0"))
                {
                    if (this.Txt_CarPriceAd.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุรายละเอียดราคารถยนต์เพิ่มเติม!";
                        this.Panel_ConfirmErr.Visible = true;
                        return;
                    } 
                }
                if (this.Txt_PayDown.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจำนวนเงินดาวน์!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }

                if (this.Txt_Interest.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุดอกเบี้ย!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }

                if (this.Txt_Price_Payment.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุค่าใช้จ่ายต่องวด!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }

                if (this.Cb_Begin.Checked == true && this.Txt_Pay_Begin.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจำนวนงวดชำระล่วงหน้า!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
            }
            else
            {

            }
            #endregion

            #region เช็คคำนวณยอดเงิน
            if (this.Txt_PriceSum.Text.Trim() == string.Empty)
            {
                this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาคำนวณยอดเงินที่ลูกค้าจะต้องชำระ!";
                this.Panel_ConfirmErr.Visible = true;
                return;
            }
            #endregion

            #region เช็คข้อมูลค่ามัดจำ
            if (this.Txt_DepositNo.Text.Trim() != string.Empty || this.Txt_DepositDate.Text.Trim() != string.Empty || this.Txt_DepositPrice.Text.Trim() != string.Empty)
            {
                if (this.Txt_DepositNo.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขที่ใบเสร็จค่ามัดจำ!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                if (this.Txt_DepositDate.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันที่มัดจำ!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                if (this.Txt_DepositPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจำนวนเงินค่ามัดจำ!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
            }

            if (this.Txt_DepositAdNo.Text.Trim() != string.Empty || this.Txt_DepositAdDate.Text.Trim() != string.Empty || this.Txt_DepositAdPrice.Text.Trim() != string.Empty)
            {
                if (this.Txt_DepositAdNo.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขที่ใบเสร็จค่ามัดจำเพิ่มเติม!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                if (this.Txt_DepositAdDate.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันที่มัดจำเพิ่มเติม!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                if (this.Txt_DepositAdPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจำนวนเงินค่ามัดจำเพิ่มเติม!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
            }
            #endregion

            #region เช็คข้อมูลมัดจำป้ายแดง
            //if (this.Txt_RedCarPlate_No.Text != string.Empty || this.Txt_RedCarPlate_Date.Text != string.Empty || this.Txt_RedCarPlate_Price.Text != string.Empty)
            //{
            //    if (this.Txt_RedCarPlate_No.Text == string.Empty)
            //    {
            //        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขที่ใบเสร็จค่ามัดจำป้ายแดง!";
            //        this.Panel_ConfirmErr.Visible = true;
            //        return;
            //    }
            //    if (this.Txt_RedCarPlate_Date.Text == string.Empty)
            //    {
            //        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุวันที่มัดจำป้ายแดง!";
            //        this.Panel_ConfirmErr.Visible = true;
            //        return;
            //    }
            //    if (this.Txt_RedCarPlate_Price.Text == string.Empty)
            //    {
            //        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุจำนวนเงินมัดจำป้ายแดง!";
            //        this.Panel_ConfirmErr.Visible = true;
            //        return;
            //    }
            //}
            #endregion

            this.Insert_CusNew();
            //if (this.Txt_CusID.Text == string.Empty)
            //{      
                
            //}
            //else
            //{
            //    this.Insert_CusOld();
            //}
            
        }

        private void Insert_CusNew()
        {
            Session["ChkInsert"] = "Y";
            _Purchase _p = new _Purchase();
            #region Customer
            if (this.Txt_CusID.Text != string.Empty)
            {
                _p._Customer.ID = int.Parse(this.Txt_CusID.Text);
                DateTime _PurchaseDate = DateTime.MinValue;
                DateTime.TryParse(this.Txt_SDate.Text, out _PurchaseDate);
                _p.Purchase_Date = _PurchaseDate;

            }
            else
            {
                DateTime _PurchaseDate = DateTime.MinValue;
                DateTime.TryParse(this.Txt_Date.Text, out _PurchaseDate);
                _p.Purchase_Date = _PurchaseDate;
                _p._Customer.CusNo = this.GetCUNo();
                _p._Customer.CusType = this.DD_CusType.SelectedItem.Text;
                if (this.DD_CusType.SelectedItem.Text == "บุคคล")
                {
                    _p._Customer.Prefix = this.Txt_Prefix.Text.Trim();
                    _p._Customer.Name = this.Txt_Name.Text.Trim();
                    _p._Customer.Surname = this.Txt_Surname.Text.Trim();
                    _p._Customer.Nickname = this.Txt_Nickname.Text.Trim();

                    if (this.Txt_Birthday.Text.Trim() != string.Empty)
                    {
                        DateTime _Birthday = DateTime.MinValue;
                        DateTime.TryParse(this.Txt_Birthday.Text, out _Birthday);
                        _p._Customer.Birthday = _Birthday;
                    }

                    _p._Customer.Sex = this.DD_Person_Sex.SelectedItem.Text;
                    _p._Customer.IDCard = this.Txt_IDCard.Text.Trim();
                    _p._Customer._Education.id = int.Parse(this.DD_Education.SelectedValue);
                    if (this.Txt_Total_Member.Text.Trim() != string.Empty)
                    {
                        _p._Customer.Total_Member = int.Parse(this.Txt_Total_Member.Text.Trim());
                    }
                }
                else
                {
                    _p._Customer.CorporationCode = this.Txt_CorporationCode.Text;
                    _p._Customer.Name = this.Txt_CompanyName.Text;
                }

                _p._Customer.Tel_Mobile1 = this.Txt_TelMobile1.Text.Trim();
                _p._Customer.Tel_Mobile2 = this.Txt_TelMobile2.Text.Trim();
                _p._Customer.Tel_Work = this.Txt_TelHome_Work.Text.Trim();
                _p._Customer.Tel_Fax = this.Txt_Fax.Text.Trim();
                _p._Customer.LineID = this.Txt_lineID.Text.Trim();
                //-----------------------------------
                _p._Customer._Career.ID = int.Parse(this.DD_Career.SelectedValue);
                _p._Customer.Career_Other = this.Txt_Career_Other.Text.Trim();
                _p._Customer.Career_Remark = this.Txt_Career_Remark.Text.Trim();
                _p._Customer._Income.ID = int.Parse(this.DD_InCome.SelectedValue);
                _p._Customer._AddressList = this._AddList;

                if (this.Cb_SendAddress_New.Checked == true)
                {
                    _p._Customer.SendAddress_IDCard = "N";
                    _p._Customer._SentAddressList = this._SentAddList;
                }
                else
                {
                    _p._Customer.SendAddress_IDCard = "Y";
                }
                
            }
            _p._Customer.User_Add = (int)Session["Emp_id"];
            #endregion

            #region Purchase
            _p._Company.Companycode = this.Rb_Company.SelectedValue;
            _p.PurchaseNo = this.GetPoNo();
            _p.ProspectNo = this.Txt_ProspectNo.Text.Trim();
            DataTable _dtCB = (DataTable)Session["TeamCB"];
            _p.Emp_Company = _dtCB.Rows[0]["Company"].ToString();
            _p.Emp_Branch = _dtCB.Rows[0]["Branch"].ToString();
            _p.Emp_Team = _dtCB.Rows[0]["Team"].ToString();
            _p.EmpID = int.Parse(this.Txt_EmpID.Text);
            _p.BookNo = this.Txt_BookNo.Text.Trim();
            _p.CarName = this.Txt_CarName.Text.Trim();
            _p.Buy_Type = this.DD_BuyType.SelectedItem.Text;
            _p.MCNumber = this.Txt_MCNumber.Text.Trim();
            _p.TruckNumber = this.Txt_TruckNumber.Text.Trim();
            _p.MName = this.Txt_MCode.Text.Trim();
            _p.MSaleCode = this.Txt_MSaleCode.Text.Trim();
            _p.CName = this.Txt_CCode.Text.Trim();
            if (this.Txt_CarPrice.Text != "0")
            {
                _p.CarPrice = decimal.Parse(this.Txt_CarPrice.Text.Trim());
            }           
            _p.CarPlate = this.Txt_CarPlate.Text.Trim();

            if (this.Cb_CE_Y.Checked == true)
            {
                _p.StatusCE = "Y";
                _p.CE_MCNumber = this.Txt_CEMCNumber.Text.Trim();
                _p.CE_TruckNumber = this.Txt_CETruckNumber.Text.Trim();
                _p.CE_Brand = this.Txt_CEBrand.Text.Trim();
                _p.CE_Model = this.Txt_CEModel.Text.Trim();
                _p.CE_Color = this.Txt_CEColor.Text.Trim();
                _p.CE_Year = this.Txt_CEYear.Text.Trim();
                _p.CE_CarPlate = this.Txt_CECarPlate.Text.Trim();
                if (this.Txt_CEPrice.Text != "0")
                {
                    _p.CE_Price = decimal.Parse(this.Txt_CEPrice.Text);
                }  
                _p.CE_Emp = this.Txt_CEEmp.Text.Trim();
            }
            else
            {
                _p.StatusCE = "N";
            }
            #endregion

            #region อุปกรณ์ตกแต่ง
            if (this.Cb_Insurance1.Checked == true)
            {
                _p.ChkIn1 = "Y";
                _p._Insurance1._Insurane.ID = int.Parse(this.DD_Insurance.SelectedValue);
                _p._Insurance1._Insurane.Name = this.DD_Insurance.SelectedItem.Text;
                if (this.Txt_InOutlay.Text != "0")
                {
                    _p._Insurance1.Outlay = decimal.Parse(this.Txt_InOutlay.Text.Trim());
                }
                if (this.Txt_InPrice.Text != "0")
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
                if (this.Txt_RegisPrice.Text != "0")
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
                if (this.Txt_ActPrice.Text != "0")
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
                if (this.Txt_TranspotPrice.Text != "0")
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
                if (this.Txt_SetAccPrice.Text != "0")
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

            if (this._AdAccList != null)
            {
                _p.ChkSetAddAcc = "Y";
                if (this.Lb_AdAccPrice.Text != "0")
                {
                    _p._AddAcc.Price = decimal.Parse(this.Lb_AdAccPrice.Text.Trim());
                }              
                _p._SetAddAccList = this._AdAccList;
            }

            if (this._BodyOptionList != null)
            {

                _p._SetBodyOptionList = this._BodyOptionList;
            }

            if (this._BodyOptionExtraList != null)
            {

                _p._SetBodyOptionExtraList = this._BodyOptionExtraList;
            }


            if (this._DcList != null)
            {
                _p.ChkDc = "Y";
                _p._DcList = this._DcList;
            }

            //if (this.Cb_Discount.Checked == true)
            //{
            //    _p.Acc_Discount = decimal.Parse(this.Txt_Discount.Text.Trim());
            //}
            #endregion

            #region ไฟแนนซ์
            if (this.DD_Finance.SelectedValue != "1")
            {
                _p._Finance.ID = int.Parse(this.DD_Finance.SelectedValue);
                _p.Emp_Finance = this.Txt_EmpFinance.Text.Trim();
                if (this.Txt_PayDown.Text != "0")
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
            //------------------------------------------
            if (this.DD_body.SelectedValue != "0" && this.DD_body.SelectedValue != string.Empty)
            {
                _p.Body_Acc_ID = int.Parse(this.DD_body.SelectedValue);
            }
            if(Rb_bodystandard.Checked == true)
            {
                 _p.Body_Type = "S";
            }
            else if(Rb_bodyextra.Checked == true){
                 _p.Body_Type = "E";
            }
            else{
                _p.Body_Type = "N";
            }

            if (this.ddl_Body_Company.SelectedValue != "0" && this.ddl_Body_Company.SelectedValue != string.Empty)
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
            //-------------------------------------------
            _p.CampaignName = this.Txt_CampaignName.Text.Trim();
            _p.DepositNo = this.Txt_DepositNo.Text.Trim();

            if (this.Txt_DepositDate.Text.Trim() != string.Empty)
            {
                DateTime _DepositDate = DateTime.MinValue;
                DateTime.TryParse(this.Txt_DepositDate.Text, out _DepositDate);
                _p.DepositDate = _DepositDate;
            }

            if (this.Txt_DepositPrice.Text != "0" && this.Txt_DepositPrice.Text != string.Empty)
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

            if (this.Txt_DepositAdPrice.Text != "0" && this.Txt_DepositAdPrice.Text.Trim() != string.Empty)
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
            _p.Remark = this.Txt_Remark.Text.Trim();
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

            
            #endregion
            try
            {
                _p.Insert(_p);
            }
            catch (Exception e)
            {
                this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ กรุณาติดต่อเจ้าหน้าที่ Error Message :" + e.Message;
                this.Panel_ConfirmErr.Visible = true;
                return;
            }

            string _MCNumber = _Encryption.Encrypt(this.Txt_MCNumber.Text.Trim());

            string[] spChar = { "+", "&", "%", "$" };
            string[] replaceChar = { "_plus", "_amp", "_per", "_dol" };

            for (int i = 0; i <= spChar.Length - 1; i++)
            {
                _MCNumber = _MCNumber.Replace(spChar[i], replaceChar[i]);
                //q = q.Replace(Lb_MCNumber, "+", "#plus");
            }

            string script = "alert(\"ระบบทำการบันทึกข้อมูลเรียบร้อยแล้ว!!!\"); window.location='" + Request.ApplicationPath + "../_ReportForm/Rpt_PurchaseForm.aspx?MC=" + _MCNumber + "'";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ระบบทำการบันทึกข้อมูลเรียบร้อยแล้ว!!!')", true);
           
        }

        private string GetPoNo()
        {
            string _PurchaseNo = string.Empty;
            DateTime _OutCarDate = DateTime.MinValue;
            DateTime.TryParse(this.Txt_Date.Text, out _OutCarDate);
            string _c = string.Empty;

                DataTable _dtCB = (DataTable)Session["TeamCB"];
                string _company = _dtCB.Rows[0]["Company"].ToString();
                string _branch = _dtCB.Rows[0]["Branch"].ToString();
                _PurchaseNo = _company + _branch + "/PO" + _OutCarDate.ToString("yy") + _OutCarDate.ToString("MM");
                _c = _company + _branch;

            _Purchase _Po = new _Purchase();
            string _Month = _OutCarDate.ToString("MM");
            string _Year = _OutCarDate.ToString("yy");
            _Po.Select(1, _c,_Month,_Year);

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
                //_dt = _Po.Select_MaxPurchaseNo(2, _c,_Month,_Year);
                //bool _chkNull = false;
                //for (int i = 1; i < Convert.ToInt32(_No); i++)
                //{
                //    _chkNull = false;
                //    for (int j = 0; j < _dt.Rows.Count; j++)
                //    {
                //        if (i == int.Parse(_dt.Rows[j]["PurchaseNo"].ToString().Substring(9,3)))
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

        private string GetCUNo()
        {
            string _CusNo = string.Empty;
            _CusNo = "CU" + DateTime.Today.ToString("yy") + DateTime.Today.ToString("MM");
            _Customer _CU = new _Customer();
            string _Month = DateTime.Today.ToString("MM");
            string _Year = DateTime.Today.ToString("yy");
            _CU.Select(1, _Month, _Year);
            if (_CU.CusNo == string.Empty)
            {
                _CusNo += "0001";
            }
            else
            {
                string _No = (_CU.CusNo).Substring(6, 4);
                _No += Convert.ToInt32("9" + _No) + 1;
                _CusNo += _No.Substring(5, 4);
            }
            return _CusNo;
        }

        protected void Cb_SSendAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Cb_SSendAddress.Checked == true)
            {
                this.SSentAdd_Y();
            }
            else
            {
                this.SSentAdd_N();
            }
        }

        protected void Cb_SSendAddress_New_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Cb_SSendAddress_New.Checked == true)
            {
                this.SSentAdd_N();
            }
            else
            {
                this.SSentAdd_Y();
            }
        }

        private void SSentAdd_Y()
        {
            this.Cb_SSendAddress.Checked = true;
            this.Cb_SSendAddress_New.Checked = false;
            this.Btn_SAddSendAddress.Visible = false;
            this.gv_SSendAddress.Visible = false;
        }

        private void SSentAdd_N()
        {
            this.Cb_SSendAddress_New.Checked = true;
            this.Cb_SSendAddress.Checked = false;
            this.Btn_SAddSendAddress.Visible = true;
            _AddressList _alist = new _AddressList();
            _AddressList._Address temp = new _AddressList._Address();
            _alist.Add(0, temp);
            this.gv_SSendAddress.DataSource = _alist.Values;
            this.gv_SSendAddress.DataBind();
            this.gv_SSendAddress.Visible = true;
        }

        protected void Txt_SBirthDay_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_SBirthDay.Text.Trim() != string.Empty)
            {
                bool complete = false;
                DateTime _Birthday = DateTime.MinValue;
                complete = DateTime.TryParse(this.Txt_SBirthDay.Text, out _Birthday);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันเกิด!');", true);
                }
                else
                {
                    this.Txt_SBirthDay.Text = _Birthday.ToString("dd MMM yy");
                }
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

        protected void gv_Discount_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                Label _Lb_DcPrice = (Label)e.Row.FindControl("Lb_DcPrice");

                if (_Lb_DcPrice.Text != "0")
                {
                    _Lb_DcPrice.Text = string.Format("{0:#,###}", decimal.Parse(_Lb_DcPrice.Text));
                    SumDc = SumDc + decimal.Parse(_Lb_DcPrice.Text);
                    this.Lb_PriceDiscount.Text = string.Format("{0:#,###}", SumDc);
                }
            }
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
        }

        protected void Img_DcDel_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gv = (GridViewRow)((ImageButton)sender).NamingContainer;
            int id = int.Parse(gv_Discount.DataKeys[gv.RowIndex].Value.ToString());
            this._DcList.Remove(id);
            if (this._DcList.Count == 0)
            {
                this.AddEmptyData_Dc();
                this.SumDc = 0;
                this.Lb_PriceDiscount.Text = "0";
            }
            else
            {
                this.gv_Discount.DataSource = this._DcList.Values;
                this.gv_Discount.DataBind();
            }
        }

        private void AddEmptyData_Dc()
        {
            _DiscountList _alist = new _DiscountList();
            _DiscountList._Discount temp = new _DiscountList._Discount();
            _alist.Add(0, temp);
            this.gv_Discount.DataSource = _alist.Values;
            this.gv_Discount.DataBind();
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
            if (this.DD_Finance.SelectedValue == "1") //เงินสด
            {
                if (Txt_CarPriceAd_Price.Text != "")
                {
                    _Txt_CarPriceAd_Price = decimal.Parse(this.Txt_CarPriceAd_Price.Text.Trim());
                }
                decimal _Lb_sumAddfinance = decimal.Parse(this.Lb_sumAddfinance.Text.Trim());
                _PriceSum = _Txt_CarPriceAd_Price + _Lb_sumAddfinance + decimal.Parse(this.Txt_CarPrice.Text.Trim());


            }
            else //ผ่อนชำระ
            {
                if (this.Txt_Price_Payment.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาคำนวณค่าใช้จ่ายต่องวด!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }

                if (this.Txt_PayDown.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาเงินดาวน์!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }

                //--------บวกBodyเสริม--------------------
                decimal _Budgetpaybody = decimal.Parse(this.Lb_Budgetpaybody.Text.Trim());
                _PriceSum = _Budgetpaybody + decimal.Parse(this.Txt_PayDown.Text.Trim());
               //-----------------------------------

                if (this.Cb_Begin.Checked == true )
                {
                    if (this.Cb_Begin.Checked == true && this.Txt_Pay_Begin.Text.Trim() == string.Empty)
                    {
                        this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาจำนวนงวดชำระล่วงหน้า!";
                        this.Panel_ConfirmErr.Visible = true;
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
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาประกันประเภท1!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_InPrice.Text.Trim());
            }

            if (this.Cb_Regis.Checked == true && this.Cb_RegisFree.Checked == false)
            {
                if (this.Txt_RegisPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาค่าจดทะเบียน!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_RegisPrice.Text.Trim());
            }

            if (this.Cb_Act.Checked == true && this.Cb_ActFree.Checked == false)
            {
                if (this.Txt_ActPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคา พ.ร.บ!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_ActPrice.Text.Trim());
            }

            if (this.Cb_Transpot.Checked == true && this.Cb_TranspotFree.Checked == false)
            {
                if (this.Txt_TranspotPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาค่าขนส่ง!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_TranspotPrice.Text.Trim());
            }

            if (this.Cb_SetAcc.Checked == true && this.Cb_SetAccFree.Checked == false)
            {
                if (this.Txt_SetAccPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาชุดอุปกรณ์ตกแต่ง!";
                    this.Panel_ConfirmErr.Visible = true;
                    return;
                }
                _PriceSum = _PriceSum + decimal.Parse(this.Txt_SetAccPrice.Text.Trim());
            }

            if (this.Cb_AccSTD.Checked == true && this.Cb_AccSTDFree.Checked == false)
            {
                if (this.Txt_AccSTDPrice.Text.Trim() == string.Empty)
                {
                    this.Lb_ConfirmErr.Text = "ไม่สามารถทำรายการได้ : กรุณาราคาอุปกรณ์มาตรฐานSTD!";
                    this.Panel_ConfirmErr.Visible = true;
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
            }
            else
            {
                this.Txt_PriceSumCar.Text = String.Format("{0:#,###.##}", Math.Ceiling(_PriceSum));
            }

            this.Txt_PriceSum.Text = String.Format("{0:#,###.##}", Math.Ceiling(_PriceSum));
        }

        protected void DD_Career_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DD_Career.SelectedValue == "11")
            {
                this.Panel_Career_Other.Visible = true;
                this.Txt_Career_Other.Text = string.Empty;
            }
            else
            {
                this.Panel_Career_Other.Visible = false;
            }
        }

        protected void DD_SCareer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DD_SCareer.SelectedValue == "11")
            {
                this.Panel_SCareer_Other.Visible = true;
                this.Txt_SCareer_Other.Text = string.Empty;
            }
        }

        protected void DD_CusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DD_CusType.SelectedValue == "บุคคล")
            {
                this.Panel_Person.Visible = true;
                this.Panel_Company.Visible = false;
            }
            else
            {
                this.Panel_Company.Visible = true;
                this.Panel_Person.Visible = false;
            }
        }

        protected void Txt_IDCard_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_IDCard.Text.Trim() == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ : กรุณาระบุเลขบัตรประชาชน!')", true);
                return;
            }
            else if (this.Txt_IDCard.Text.Trim().Length != 13)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('กรุณาระบุเลขบัตรประชาชนเป็นตัวเลข 13 หลักเท่านั้น!')", true);
                return;
            }
            this.EmpData_Empty(); 
            this.GETDATA_CUS("บุคคล", this.Txt_IDCard.Text.Trim(), string.Empty);
            this.CusData_Click();
        }

        protected void Txt_CorporationCode_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_CorporationCode.Text.Trim() == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ : กรุณาระบุเลขนิติบุคคล!')", true);
                return;
            }
            else if (this.Txt_CorporationCode.Text.Trim().Length != 13)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ไม่สามารถทำรายการได้ : กรุณาระบุเลขนิติบุคคลเป็นตัวเลข 13 หลักเท่านั้น!')", true);
                return;
            }

            this.EmpData_Empty();
            this.GETDATA_CUS("บริษัท", string.Empty, this.Txt_CorporationCode.Text.Trim());
            this.CusData_Click();
        }

        protected void DD_RF_CusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Panel_RF_Person.Visible = false;
            this.Panel_RF_Company.Visible = false;
            if (this.DD_RF_CusType.SelectedValue == "บุคคล")
            {
                this.Panel_RF_Person.Visible = true;
                this.Txt_RF_IDCard.Text = string.Empty;
            }
            else
            {
                this.Panel_RF_Company.Visible = true;
                this.Txt_RF_Company.Text = string.Empty;
            }
            this.ModalPopupExtender_RefreshCus.Show();
        }

        protected void Img_RF_Close_Click(object sender, ImageClickEventArgs e)
        {
            this.ModalPopupExtender_RefreshCus.Hide();
        }

        protected void Btn_RF_Cancel_Click(object sender, EventArgs e)
        {
            this.ModalPopupExtender_RefreshCus.Hide();
        }

        protected void Btn_RF_Save_Click(object sender, EventArgs e)
        {
            this.Panel_RF_Err.Visible = false;
            if (this.DD_RF_CusType.SelectedValue == "บุคคล")
            {
                if (this.Txt_RF_IDCard.Text.Trim() == string.Empty)
                {
                    this.Lb_RF_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขบัตรประชาชน";
                    this.Panel_RF_Err.Visible = true;
                    this.ModalPopupExtender_RefreshCus.Show();
                    return;
                }
                else if (this.Txt_RF_IDCard.Text.Trim().Length != 13)
                {
                    this.Lb_RF_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขบัตรประจำตัวประชาชนเป็นตัวเลข 13 หลักเท่านั้น!";
                    this.Panel_RF_Err.Visible = true;
                    this.ModalPopupExtender_RefreshCus.Show();
                    return;
                }

                this.EmpData_Empty();
                this.Txt_IDCard.Text = this.Txt_RF_IDCard.Text;
                this.GETDATA_CUS("บุคคล", this.Txt_RF_IDCard.Text.Trim(), string.Empty);     
                this.ModalPopupExtender_RefreshCus.Hide();
                this.CusData_Click();   
            }
            else
            {
                if (this.Txt_RF_Company.Text.Trim() == string.Empty)
                {
                    this.Lb_RF_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขนิติบุคคล";
                    this.Panel_RF_Err.Visible = true;
                    this.ModalPopupExtender_RefreshCus.Show();
                    return;
                }
                else if (this.Txt_RF_Company.Text.Trim().Length != 13)
                {
                    this.Lb_RF_Err.Text = "ไม่สามารถทำรายการได้ : กรุณาระบุเลขนิติบุคคลเป็นตัวเลข 13 หลักเท่านั้น!";
                    this.Panel_RF_Err.Visible = true;
                    this.ModalPopupExtender_RefreshCus.Show();
                    return;
                }
                this.EmpData_Empty();
                this.Txt_CorporationCode.Text = this.Txt_RF_Company.Text;
                this.GETDATA_CUS("บริษัท", string.Empty, this.Txt_RF_Company.Text.Trim());
                this.ModalPopupExtender_RefreshCus.Hide();
                this.CusData_Click();
            }
        }

        protected void Img_refresh_Click(object sender, ImageClickEventArgs e)
        {
            this.DD_RF_CusType.SelectedValue = "บุคคล";
            this.Panel_RF_Person.Visible = true;
            this.Txt_RF_IDCard.Text = string.Empty;
            this.Panel_RF_Company.Visible = false;
            this.ModalPopupExtender_RefreshCus.Show();
            this.Panel_RF_Err.Visible = false;
        }

        protected void Txt_LoanProtection_TextChanged(object sender, EventArgs e)
        {
            this.Cal_Payment();
        }

        protected void Txt_CarPriceDetail_Price_TextChanged(object sender, EventArgs e)
        {
            this.Cal_Payment();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.CarData_Click();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            this.Accessories_Click();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            this.Finance_Click();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            this.CarData_Click();
        }

        protected void Txt_SDate_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_SDate.Text.Trim() != string.Empty)
            {
                bool complete = false;
                DateTime _Birthday = DateTime.MinValue;
                complete = DateTime.TryParse(this.Txt_SDate.Text, out _Birthday);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันที่ออกรถ!');", true);
                }
                else
                {
                    this.Txt_SDate.Text = _Birthday.ToString("dd MMM yy");
                }
            }
        }

        protected void Txt_Date_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_Date.Text.Trim() != string.Empty)
            {
                bool complete = false;
                DateTime _Birthday = DateTime.MinValue;
                complete = DateTime.TryParse(this.Txt_Date.Text, out _Birthday);
                if (complete == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('กรุณาตรวจสอบรูปแบบวันที่ออกรถ!');", true);
                }
                else
                {
                    this.Txt_Date.Text = _Birthday.ToString("dd MMM yy");
                }
            }
        }

        protected void Txt_DepositAdDate_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_DepositAdDate.Text.Trim() != string.Empty)
            {
                this.Chk_KeyDate(this.Txt_DepositAdDate);
            }
        }

        protected void DD_body_SelectedIndexChanged1(object sender, EventArgs e)
        {
             int Body_Acc_ID = int.Parse(DD_body.SelectedValue);
             this._BodyOptionList = new BodyOptionList();
             _BodyOptionList.Body_Select_Option(Body_Acc_ID);


             if (_BodyOptionList.Values.Count > 0)
             {
                 this.AddEmptyData_BodyOption();
             }
             else
             {
                 Session.Remove("BodyOption");                 
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

                if (ID != 0)
                {
                    Txt_CarPriceAd.Text = xxx.Value.Acc_Name.ToString();
                    Txt_CarPriceAd_Price.Text = xxx.Value.Body_Model_price.ToString();
                    this.Cal_Payment();
                }
                else
                {
                    Txt_CarPriceAd.Text = "";
                    Txt_CarPriceAd_Price.Text = "0";
                    this.Cal_Payment();
                }
            }
        }

        protected void gv_bodyshow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                Label Lb_Addfinance = (Label)e.Row.FindControl("Lb_Addfinance");
                CheckBox lbl_finance = (CheckBox)e.Row.FindControl("lbl_finance");

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
                    //if (this.SelectIndex_Body == 0)
                    //{
                    //    ddl_bodyoption.SelectedIndex = 0;
                    //}
                    //else
                    //{
                    //    ddl_bodyoption.SelectedIndex = this.SelectIndex_Body;
                    //    this.SelectIndex_Body = 0;
                    //}
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
                this._BodyOptionList = new BodyOptionList();
            }
                       

            BodyOptionList.BodyOption _Option = new BodyOptionList.BodyOption();
            int _c;
            if (this._BodyOptionList.Count == 0)
            {
                _c = 1;
            }
            else
            {
                _c = this._BodyOptionList.Keys.Max();
                _c = _c + 1;
            }
            _Option.OptionIDrun = _c;
            _Option.Body_Option_ID = int.Parse(ddlbodyoption.SelectedValue);
            _Option.Body_Option_Name = ddlbodyoption.SelectedItem.Text;

            //----------------------
            this._ddlbodyoption = (BodyOptionList)Session["ddlbodyoption"];
            int ID = int.Parse(ddlbodyoption.SelectedValue);
            var option = this._ddlbodyoption.Where(x => x.Value.Body_Option_ID == ID).FirstOrDefault();
            decimal Option_price =  decimal.Parse(option.Value.Body_Option_price.ToString());
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


            this._BodyOptionList.Add(_c, _Option);
            Session["BodyOption"] = this._BodyOptionList;
            this.gv_bodyshow.DataSource = this._BodyOptionList.Values;
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
                this._BodyOptionList.Remove(id);
                if (this._BodyOptionList.Count == 0)
                {
                    this.AddEmptyData_BodyOption();
                }
                else
                {
                    this.gv_bodyshow.DataSource = this._BodyOptionList.Values;
                    this.gv_bodyshow.DataBind();
                }


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
                this._BodyOptionExtraList = new BodyOptionExtraList();
            }


            BodyOptionExtraList.BodyOptionExtra _OptionExtra = new BodyOptionExtraList.BodyOptionExtra();
            int _c;
            if (this._BodyOptionExtraList.Count == 0)
            {
                _c = 1;
            }
            else
            {
                _c = this._BodyOptionExtraList.Keys.Max();
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


            this._BodyOptionExtraList.Add(_c, _OptionExtra);
            Session["BodyExtra"] = this._BodyOptionExtraList;
            this.gv_bodyextra.DataSource = this._BodyOptionExtraList.Values;
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
                this._BodyOptionExtraList.Remove(id);
                if (this._BodyOptionExtraList.Count == 0)
                {
                    this.AddEmptyData_BodyOptionExtra();
                }
                else
                {
                    this.gv_bodyextra.DataSource = this._BodyOptionExtraList.Values;
                    this.gv_bodyextra.DataBind();
                }                
            }
            this.Cal_Payment();
        }

        protected void Txt_bodyextraPrice_TextChanged(object sender, EventArgs e)
        {
            if (this.Txt_bodyextraPrice.Text != "0" || this.Txt_bodyextraPrice.Text.Trim() != string.Empty)
            {
                decimal extraPrice = decimal.Parse(this.Txt_bodyextraPrice.Text);
                Txt_CarPriceAd.Text = txt_bodyextra.Text;
                Txt_CarPriceAd_Price.Text = String.Format("{0:#,###.##}", Convert.ToDecimal(extraPrice));
                this.Cal_Payment();
            }
            else
            {
                Txt_CarPriceAd.Text = "";
                Txt_CarPriceAd_Price.Text = "";

                this.Cal_Payment();
            }
        }





    }
}