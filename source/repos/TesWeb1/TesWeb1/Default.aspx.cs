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
        ProductList products;
        UserDic users;
        PromotionList promotions;
        PromotionList.Promotion promo;

        int qty = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            if (!IsPostBack)
            {
                loadOrder();
                fetchUser();
                fetchSelect();

                fetchProduct();
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
            PromotionList promotions = new PromotionList();
            promotions.selectPromotion();
            DropDownList2.DataSource = promotions.Values;
            DropDownList2.DataTextField = "PromotionName";
            DropDownList2.DataValueField = "PromotionID";
            DropDownList2.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int proid = int.Parse(DropDownList1.SelectedValue.ToString());

            ProductList.Product product = new ProductList.Product()
            {
                ProductID = proid
            };
            ProductList products = new ProductList();
            products.getProduct(proid);
            DataTable dt = products.ProductAll;
            this.sumOrder(dt);

        }
        public void sumOrder(DataTable productall)
        {
            promotions = new PromotionList();
            DataTable dt = productall;

            qty = int.Parse(qty_TextBox.Text.ToString());
            int price = Convert.ToInt32(dt.Rows[0]["ProductPrice"]);
            int total = price * qty;
            string type = Label10.Text.ToString();
            int discount = int.Parse(Label9.Text.ToString());

            if (type == "Bath")
            {
                    total = (total - discount);
            }
            else if(type == "Percent")
            {
                    total = ((total * 100) / 100 + discount);
            }
                //int qty = int.Parse(DropDownList2.SelectedValue.ToString());


            Label2.Text = dt.Rows[0]["ProductName"].ToString();
            Label4.Text = qty_TextBox.Text.ToString();
            Label6.Text = total.ToString();
        }
        public void addOrders()
        {
            int proid = int.Parse(DropDownList1.SelectedValue.ToString());
            qty = int.Parse(qty_TextBox.Text.ToString());
            int price = int.Parse(Label6.Text.ToString());
            int userid = int.Parse(DropDownList3.SelectedValue.ToString());
            DateTime ordertime = DateTime.Now;

            OrderList orders = new OrderList();
            orders.addOrder(proid, qty, price, userid, ordertime);

            this.testModal();
            this.loadOrder();
        }

        protected void addOrder_Click(object sender, EventArgs e)
        {
            this.addOrders();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            promotions = new PromotionList();
            int promotionid = int.Parse(DropDownList2.SelectedValue.ToString());
            promotions.getPromotion(promotionid);
            var dt = promotions.PromotionAll;
            var row = dt.Rows[0];
            string distype = row["PromotionType"].ToString();
            if(distype == "1")
            {
                Label10.Text = "Bath";
            }
            else if(distype == "2")
            {
                Label10.Text = "Percent";
            }
            Label9.Text = row["PromotionDiscount"].ToString();

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
            Panel2.Visible = true;
        }
    }
}