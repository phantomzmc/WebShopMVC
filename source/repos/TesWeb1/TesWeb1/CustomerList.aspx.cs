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
            this.loadDataUser();
        }

        public void loadDataUser()
        {
            user = new User();
            GridViewCustomer.DataSource = user.selectUser();
            GridViewCustomer.DataBind();
        }
    }
}