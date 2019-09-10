using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Purchase.Account
{
    public partial class LoginForm : System.Web.UI.Page
    {
        private Tb_UserList _ulist;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.RemoveAll();
                Session.Clear();
            }
        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            string getusername = this.Txt_Username.Text.Trim();
            string getpassword = this.Txt_Password.Text.Trim();
            string pw = _Encryption.Encrypt(getpassword);
            //string pw2 = "7jJQ0RpScmfWV4St0BTJ2A==";
            //string c = _Encryption.Decrypt(pw2);

            //string c = _Encryption.Encrypt("NT5128");
            this.Lb_Err.Text = "Check your 'USERNAME' or 'PASSWORD";

            Tb_UserList.Tb_User _u = new Tb_UserList.Tb_User();
            _u.Select(1,getusername, pw,0);
            if (_u.ID != 0)
            {
                Session["login"] = _u.ID;
                Session["Emp_id"] = _u.EmpID;
                Session["EmpName"] = "ยินดีต้อนรับ คุณ " + _u.FullName + " [" + _u.NickName + "] เข้าสู่ระบบ";
                Session["UserType"] = _u.UserType;
                Session["Username"] = _u.Username;

                DataTable _dtTeam = new DataTable();
                _dtTeam.Columns.Add("Team", typeof(string));
                _dtTeam.Columns.Add("Company", typeof(string));
                _dtTeam.Columns.Add("Branch", typeof(string));

                _dtTeam.Rows.Add(_u.Team,_u.Company, _u.Branch);
                Session["TeamCB"] = _dtTeam;

                //if (_u.Company != "A" && _u.Company != "C")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('ระบบนี้ยังไม่เปิดใช้บริการ!')", true);
                //    return;
                //}
                //else
                //{
                //    Response.Redirect("~/_Form/_MainForm.aspx");
                //}

                Response.Redirect("~/_Form/_MainForm.aspx");
            }
            else
            {
                this.Lb_Err.Text = "ชื่อผู้ใช้ หรือ รหัสผ่าน ไม่ถูกต้อง!";
            }

        }
    }
}