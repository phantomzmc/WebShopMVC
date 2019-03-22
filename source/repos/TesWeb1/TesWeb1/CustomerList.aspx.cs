using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesWeb1
{
    public partial class CustomerList : System.Web.UI.Page
    {
        User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            if (!IsPostBack)
            {
                this.loadDataUser();

            }
        }

        public void loadDataUser()
        {
            user = new User();
            GridViewCustomer.DataSource = user.selectUser();
            GridViewCustomer.DataBind();
        }

        public void testModal()
        {
            string productname = "productname";
            string productprice = "productprice";
            string body = "ได้เพิ่มรายการ " + productname + " ราคา : " + productprice + " บาท ลงในระบบเรียบร้อย";
            lblModalTitle.Text = "เพิ่มรายการสินค้าเรียบร้อย";
            //lblModalBody.Text = body;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            //upModal.Update();
        }

        protected void GridViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //upModal.Visible = true;

            var btnEdit = (Button)sender;
            var row = (GridViewRow)btnEdit.NamingContainer;
            string userid = row.Cells[0].Text.ToString();

            Panel2.Visible = true;
            Panel1.Visible = false;
            this.selectUser(userid);

            //var data = user.selectCustomer();
        }
        public void selectUser(string userid)
        {
            user = new User(userid)
            {
                UserID = userid
            };
            var data = user.selectCustomer();
            var row = data.Rows[0];
            firstname_TextBox.Text = row["FirstName"].ToString();
            lastname_TextBox.Text = row["LastName"].ToString();
            email_TextBox.Text = row["Email"].ToString();
            username_TextBox.Text = row["Username"].ToString();
            userid_TextBox.Text = row["UserID"].ToString();
            tel_TextBox.Text = row["Tel"].ToString();
            gender_TextBox.Text = row["Gender"].ToString();
            //birthday_TextBox.Text = row["BirthDay"].ToString();
            numaddress_TextBox.Text = row["NumAddress"].ToString();
            tambon_TextBox.Text = row["Tambon"].ToString();
            amphoe_TextBox.Text = row["Amphoe"].ToString();
            city_TextBox.Text = row["City"].ToString();
            country_TextBox.Text = row["Country"].ToString();
            postnumber_TextBox.Text = row["PostNumber"].ToString();

        }

        protected void GridViewCustomer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //this.selectUser(userid);
            //this.testModal();
            Panel2.Visible = true;
            Panel1.Visible = false;
        }

        protected void btnEditSub_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
        }
    }
}