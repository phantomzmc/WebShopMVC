using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesWeb1
{
    public partial class Orderlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadOrder();
        }

        public void loadOrder()
        {
            Order order = new Order();
            GridView_Order.DataSource = order.selectOrder();
            GridView_Order.DataBind();
        }
    }
}