using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesWeb1
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getproduct();
            }
        }
        void getproduct()
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {

        }

        protected void cancel_Click(object sender, EventArgs e)
        {

        }
    }
}