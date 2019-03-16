using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesWeb1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductList productlist = new ProductList();
            productlist.selectProduct();

            GridView1.DataSource = productlist.Values;
        }
    }
}