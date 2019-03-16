using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesWeb1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ProductList productlist = new ProductList();
            //productlist.selectProduct();

            ProductList.Product product = new ProductList.Product();
            GridView1.DataSource = product.selectProduct();
            GridView1.DataBind();
        }
    }
}