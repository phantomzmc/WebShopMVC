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
        ProductList.Product product;
        ProductList products;
        UserDic.User user;
        UserDic users;

        Array items = new[] {
                        new { Text = "ProductName", Value = "" },
                        new { Text = "Typename", Value = "Type" }                      
        };

        int qty = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            if (!IsPostBack)
            {
                loadOrder();
                fetchUser();
                fetchSelect();
                this.fetchType();

                //fetchProduct();
                //fetchQty();
            }

        }
        public void loadOrder()
        {
            //OrderList.Order order = new OrderList.Order();
            OrderList orderlist = new OrderList();
            orderlist.selectOrders();
            GridView_Order.DataSource = orderlist.Values;
            GridView_Order.DataBind();
        }
        void fetchUser()
        {
            //user = new UserDic.User();
            users = new UserDic();
            users.selectUsers();
            DropDownList3.DataSource = users.Values;
            DropDownList3.DataTextField = "FirstName";
            DropDownList3.DataValueField = "UserID";
            DropDownList3.DataBind();

        }
        void fetchProduct()
        {
            //product = new ProductList.Product();
            products = new ProductList();
            products.selectProduct();
            DropDownList1.DataSource = products.Values;
            DropDownList1.DataTextField = "ProductName";
            DropDownList1.DataValueField = "ProductID";
            DropDownList1.DataBind();
        }
        void fetchSelect()
        {
            DropDownList2.DataSource = items;
            DropDownList2.DataTextField = "Text";
            DropDownList2.DataValueField = "Value";
            DropDownList2.DataBind();
        }
        void fetchType()
        {
            //product = new ProductList.Product();
            products = new ProductList();
            products.selectType();
            DropDownList4.DataSource = products.Values;
            DropDownList4.DataTextField = "TypeName";
            DropDownList4.DataValueField = "TypeID";
            DropDownList4.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int proid = int.Parse(DropDownList1.SelectedValue.ToString());

            ProductList.Product product = new ProductList.Product()
            {
                ProductID = proid
            };
            products.getProduct(proid);
            this.sumOrder();

        }
        public void sumOrder()
        {
            if (IsPostBack)
            {
                //products.getProduct(int proid);
                //DataTable dt = products.getProduct();
                //int qty = int.Parse(DropDownList2.SelectedValue.ToString());
                //qty = int.Parse(qty_TextBox.Text.ToString());
                //int price = Convert.ToInt32(dt.Rows[0]["ProductPrice"]);
                //int total = price * qty;
                //Label2.Text = dt.Rows[0]["ProductName"].ToString();
                //Label4.Text = qty_TextBox.Text.ToString();
                //Label6.Text = total.ToString();
            }


        }
        public void addOrders()
        {
            //int proid = int.Parse(DropDownList1.SelectedValue.ToString());
            //qty = int.Parse(qty_TextBox.Text.ToString());
            //int price = int.Parse(Label6.Text.ToString());
            //string userid = DropDownList3.SelectedValue.ToString();
            //DateTime ordertime = DateTime.Now;
            int proid = 33;
            int qty = 1;
            int price = 50;
            int userid = 1;
            DateTime ordertime = DateTime.Now;

            //OrderList orders = new OrderList();
            //orders.addOrder(proid, qty, price, userid, ordertime);

            OrderList.Order order = new OrderList.Order(proid, qty, price, userid, ordertime)
            {
                ProductID = proid,
                OrderQty = qty,
                OrderPrice = price,
                UserID = userid,
                OrderTime = ordertime
            };
            order.addOrder();
            this.testModal();
            this.loadOrder();
        }

        protected void addOrder_Click(object sender, EventArgs e)
        {
            this.addOrders();
            Panel2.Visible = true;

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = DropDownList2.SelectedValue.ToString();
            if(select == "Type")
            {
                Panel3.Visible = true;
                Panel4.Visible = false;
                //this.fetchType();

            }
            else
            {
                Panel3.Visible = false;
                Panel4.Visible = true;
                //this.fetchProduct();

            }
        }
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.getSelectType();
        }
        public void getSelectType()
        {

            string select = DropDownList2.SelectedValue.ToString();
            int type = int.Parse(DropDownList4.SelectedValue.ToString());
            //products = new ProductList(select, type)
            //{
            //    Select = select,
            //    TypeID = type
            //};
            //products.selectProductType(select,type);
            this.fetchProduct();

        }
        public void testModal()
        {
            string productname = "productname";
            string productprice = "productprice";
            string body = "ได้เพิ่มรายการ " + productname + " ราคา : " + productprice + " บาท ลงในระบบเรียบร้อย";
            lblModalTitle.Text = "เพิ่มรายการสินค้าเรียบร้อย";
            lblModalBody.Text = body;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
    }
}