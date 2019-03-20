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

        protected void GridView_Order_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView_Order.EditIndex = e.NewEditIndex;
            this.loadOrder();
        }

        protected void GridView_Order_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //edit data row
            GridViewRow row = GridView_Order.Rows[e.RowIndex];
            string productname = (row.FindControl("TextBox_EditName") as TextBox).Text;

            GridView_Order.EditIndex = -1;
            this.loadOrder();
        }

        protected void GridView_Order_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView_Order.EditIndex = -1;
            this.loadOrder();
        }

        protected void GridView_Order_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int orderid = Convert.ToInt32(GridView_Order.DataKeys[e.RowIndex].Values[0]);
            //this.loadOrder();
        }

        protected void GridView_Order_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}