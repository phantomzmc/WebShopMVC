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
        UserDic users;
        UserDic.User user;

        int Userid;
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
            //user = new User();
            //GridViewCustomer.DataSource = user.selectUser();
            users = new UserDic();
            users.selectUsers();
            GridViewCustomer.DataSource = users.Values;
            GridViewCustomer.DataBind();
        }

        public void testModal()
        {
            string body = "แก้ไขข้อมูลของ" +user.FirstName+"เรียบร้อย";
            lblModalTitle.Text = "แก้ไขข้อมูลเรียบร้อย";
            lblModalBody.Text = body;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }

        protected void GridViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var btnEdit = (Button)sender;
            var row = (GridViewRow)btnEdit.NamingContainer;
            int userid = int.Parse(row.Cells[0].Text.ToString());

            int Userid = userid;
            Panel2.Visible = true;
            Panel1.Visible = false;
            this.selectUser(userid);
        }
        public void selectUser(int userid)
        {
            CustomerDic customerlist = new CustomerDic();
            customerlist.selectCustomer(userid);

            user = new UserDic.User()
            {
                //UserID = Userid,
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
            birthday_TextBox.Text = row["BrithDay"].ToString();
            numaddress_TextBox.Text = row["NumAddress"].ToString();
            tambon_TextBox.Text = row["Tambon"].ToString();
            amphoe_TextBox.Text = row["Amphoe"].ToString();
            city_TextBox.Text = row["City"].ToString();
            country_TextBox.Text = row["Country"].ToString();
            postnumber_TextBox.Text = row["PostNumber"].ToString();

        }
        public void updateUser()
        {
            string firstname = firstname_TextBox.Text.ToString();
            string lastname = lastname_TextBox.Text.ToString();
            string email = email_TextBox.Text.ToString();
            string username = username_TextBox.Text.ToString();
            int userid = int.Parse(userid_TextBox.Text.ToString());
            string tel = tel_TextBox.Text.ToString();
            string gender = gender_TextBox.Text.ToString();
            string brithday = birthday_TextBox.Text.ToString();
            string numaddress = numaddress_TextBox.Text.ToString();
            string tambon = tambon_TextBox.Text.ToString();
            string amphoe = amphoe_TextBox.Text.ToString();
            string city = city_TextBox.Text.ToString();
            string country = country_TextBox.Text.ToString();
            string postnumber = postnumber_TextBox.Text.ToString();

            //user = new UserDic.User(firstname, lastname, email, username, userid, tel, gender, brithday, numaddress, tambon, amphoe, city, country, postnumber)
            //{
            //    FirstName = firstname,
            //    LastName = lastname,
            //    Email = email,
            //    Username = username,
            //    UserID = userid,
            //    Tel = tel,
            //    Gender = gender,
            //    BrithDay = brithday,
            //    NumAddress = numaddress,
            //    Tambon = tambon,
            //    Amphoe = amphoe,
            //    City = city,
            //    Country = country,
            //    PostNumber = postnumber
            //};
            users.editUsers(firstname, lastname, email, username, userid, tel, gender, brithday, numaddress, tambon, amphoe, city, country, postnumber);
            //user.editCustomer(firstname, lastname, email, username, userid, tel, gender, brithday, numaddress, tambon, amphoe, city, country, postnumber);
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
            this.updateUser();
            testModal();
            Panel2.Visible = false;
            Panel1.Visible = true;
            this.loadDataUser();
        }

    }
}