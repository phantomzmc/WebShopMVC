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
        ProductList.Product product;
        ProductList products;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getProduct();
                loadType();
            }
        }
        public void getProduct()
        {
            //product = new Product();
            //GridView1.DataSource = product.selectProduct();
            products = new ProductList();
            products.selectProduct();
            GridView1.DataSource = products.Values;
            GridView1.DataBind();
        }
        void loadType()
        {
            //UserDic.User user = new UserDic.User();0
            ProductList products = new ProductList();
            products.selectType();
            DropDownList_TypeProduct.DataSource = products.Values;
            DropDownList_TypeProduct.DataTextField = "TypeName";
            DropDownList_TypeProduct.DataValueField = "TypeID";
            DropDownList_TypeProduct.DataBind();
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            string name = productname_textbox.Text.ToString();
            int price = int.Parse(productprice_textbox.Text.ToString());
            string detail = productdetail_textbox.Text.ToString();
            int type = int.Parse(DropDownList_TypeProduct.SelectedValue.ToString());

            //product = new ProductList.Product(name, price, detail, type)
            //product = new Product(name, price, detail, type)

            //{
            //    ProductName = name,
            //    ProductPrice = price,
            //    ProductDatail = detail,
            //    TypeProduct = type
            //};
            products = new ProductList();
            products.addProduct(name,price,detail,type);
            //int res = product.addProduct();
            testModal();
            getProduct();
        }

        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var btnEdit = (Button)sender;
            var row = (GridViewRow)btnEdit.NamingContainer;
            int id = int.Parse(row.Cells[0].Text);


            //text1.Text = id.ToString();
        }

        

        protected void cancel_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getProduct();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int productid = int.Parse((row.FindControl("editProductID_TextBox") as TextBox).Text);
            string productname = (row.FindControl("editProductName_TextBox") as TextBox).Text;
            int productprice = int.Parse((row.FindControl("editProductPrice_TextBox") as TextBox).Text);
            string productdetail = (row.FindControl("editProductDetail_TextBox") as TextBox).Text;
            int type_product = 1;

            //product = new ProductList.Product(productid, productname, productprice, productdetail, type_product)
            //product = new Product(productid,productname, productprice, productdetail, type_product)
            //{
            //    ProductID = productid,
            //    ProductName = productname,
            //    ProductPrice = productprice,
            //    ProductDatail = productdetail,
            //    TypeProduct = type_product

            //};
            products = new ProductList();
            products.editProduct(productid,productname,productprice,productdetail,type_product);
            GridView1.EditIndex = -1;
            this.getProduct();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            products = new ProductList();
            products.delProduct(productid);

            //product = new ProductList.Product(productid)
            //{
            //    ProductID = productid
            //};
            //product.deleteProduct();
            this.getProduct();
        }

        public void testModal()
        {
            string productname = productname_textbox.Text.ToString();
            string productprice = productprice_textbox.Text.ToString();
            string body = "ได้เพิ่มรายการ " + productname + " ราคา : " + productprice + " บาท ลงในระบบเรียบร้อย";
            lblModalTitle.Text = "เพิ่มรายการสินค้าเรียบร้อย";
            lblModalBody.Text = body;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
    }
}