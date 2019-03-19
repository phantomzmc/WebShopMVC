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
        Order order = new Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){ 
                loadOrder();
            }
        }

        public void loadOrder()
        {
            
            GridView_Order.DataSource = order.selectOrder();
            GridView_Order.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var btnEdit = (Button)sender;
            var row = (GridViewRow)btnEdit.NamingContainer;
            int orderid = int.Parse(row.Cells[0].Text.ToString());
            order.delOrder(orderid);
            loadOrder(); 
        }
    }
}