using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TesWeb1
{
    public partial class _Default : Page
    {
        //ProductList.Product product;
        Product product;

        User user;

        Array items = new[] {
                        new { Text = "1", Value = "1" },
                        new { Text = "2", Value = "2" },
                        new { Text = "3", Value = "3" },
                        new { Text = "4", Value = "4" },
                        new { Text = "5", Value = "5" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fetchUser();
                fetchProduct();
                fetchQty();
            }

        }

        void fetchUser()
        {
            user = new User();
            DropDownList3.DataSource = user.selectUser();
            DropDownList3.DataTextField = "FirstName";
            DropDownList3.DataValueField = "UserID";
            DropDownList3.DataBind();

        }
        void fetchProduct()
        {
            //product = new ProductList.Product();
            product = new Product();
            DropDownList1.DataSource = product.selectProduct();
            DropDownList1.DataTextField = "ProductName";
            DropDownList1.DataValueField = "ProductID";
            DropDownList1.DataBind();
        }
        void fetchQty()
        {
            DropDownList2.DataSource = items;
            DropDownList2.DataTextField = "Text";
            DropDownList2.DataValueField = "Value";
            DropDownList2.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int proid = int.Parse(DropDownList1.SelectedValue.ToString());

            product = new Product(proid)
            {
                ProductID = proid
            };
            product.getProduct();
            this.sumOrder();

        }
        public void sumOrder()
        {
            if (IsPostBack)
            {
                DataTable dt = product.getProduct();
                int qty = int.Parse(DropDownList2.SelectedValue.ToString());
                int price = Convert.ToInt32(dt.Rows[0]["ProductPrice"]);
                int total = price * qty;
                Label2.Text = dt.Rows[0]["ProductName"].ToString();
                Label4.Text = DropDownList2.SelectedValue.ToString();
                Label6.Text = total.ToString();
            }


        }
        public void addOrders()
        {
            int proid = int.Parse(DropDownList1.SelectedValue.ToString());
            int qty = int.Parse(DropDownList2.SelectedValue.ToString());
            int price = int.Parse(Label6.Text.ToString());
            int userid = int.Parse(DropDownList3.SelectedValue.ToString());
            DateTime ordertime = DateTime.Now;

            Order order = new Order(proid, qty, price, userid, ordertime)
            {
                ProductID = proid,
                OrderQty = qty,
                OrderPrice =price,
                UserID = userid,
                OrderTime = ordertime
            };
            order.addOrder();
        }

        protected void addOrder_Click(object sender, EventArgs e)
        {
            this.addOrders();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sumOrder();

        }
    }
}