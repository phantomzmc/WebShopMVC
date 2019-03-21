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
            //int orderid = int.Parse(row.Cells[0].Text.ToString());
            int orderid = Convert.ToInt32(GridView_Order.DataKeys[e.RowIndex].Values[0]);
            string productname = (row.FindControl("orderProductName_TextBox") as TextBox).Text;
            int productprice = int.Parse((row.FindControl("orderProductPrice_TextBox") as TextBox).Text);
            string firstname = (row.FindControl("orderFirstName_TextBox") as TextBox).Text;
            string lastname = (row.FindControl("orderLastName_TextBox") as TextBox).Text;
            int orderqty = int.Parse((row.FindControl("orderQty_TextBox") as TextBox).Text);
            int orderprice = int.Parse((row.FindControl("orderPrice_TextBox") as TextBox).Text);
            DateTime ordertime = Convert.ToDateTime(row.FindControl("orderPrice_TextBox") as TextBox);

            order = new Order(orderid, productname, productprice, firstname, lastname, orderqty, orderprice, ordertime)
            {
                OrderID = orderid,
                ProductName = productname,
                ProductPrice = productprice,
                FirstName = firstname,
                LastName = lastname,
                OrderQty = orderqty,
                OrderPrice = orderprice,
                OrderTime = ordertime
            };
            order.editOrder();

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