﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesWeb1
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        UserDic.User users;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void addUser()
        {
            string userid = userid_TextBox.Text.ToString();
            string firstname = firstname_TextBox.Text.ToString();
            string lastname = lastname_TextBox.Text.ToString();
            string username = username_TextBox.Text.ToString();
            string tel = tel_TextBox.Text.ToString();
            string email = email_TextBox.Text.ToString();
            string gen = gender_TextBox.Text.ToString();
            string numaddress = numAddress_TextBox.Text.ToString();
            string tambon = tambon_TextBox.Text.ToString();
            string amphoe = amphoe_TextBox.Text.ToString();
            string city = city_TextBox.Text.ToString();
            string country = country_TextBox.Text.ToString();
            string postnumber = postnumber_TextBox.Text.ToString();
            string birthday = Convert.ToString(brithday_TextBox.Text);

            users = new UserDic.User (userid,firstname, lastname, username, tel, email, gen,numaddress, tambon, amphoe, city, country, postnumber, birthday)
            {
                UserID = userid,
                FirstName = firstname,
                LastName = lastname,
                Username =username,
                Tel = tel,
                Email = email,
                Gender = gen,
                NumAddress = numaddress,
                Tambon = tambon,
                Amphoe = amphoe,
                City = city,
                Country = country,
                PostNumber = postnumber,
                BrithDay = birthday
            };
            users.addCustomer();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.addUser();
        }
    }
}