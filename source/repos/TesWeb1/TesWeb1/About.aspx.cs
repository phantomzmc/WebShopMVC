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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                loadType();
            }
        }
        void loadData()
        {
            //ProductList productlist = new ProductList();
            //productlist.selectProduct();
            //product.selectProduct();
            product = new ProductList.Product();
            GridView1.DataSource = product.selectProduct();
            GridView1.DataBind();
        }
        void loadType()
        {
            User user = new User();
            DropDownList_TypeProduct.DataSource = product.selectType();
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

            product = new ProductList.Product(name, price, detail, type)
            {
                ProductName = name,
                ProductPrice = price,
                ProductDatail = detail,
                TypeProduct = type
            };

            int res = product.addProduct();
            loadData();
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var btnDel = (Button)sender;
            var row = (GridViewRow)btnDel.NamingContainer;
            int proid = int.Parse(row.Cells[0].Text.ToString());

            product = new ProductList.Product(proid)
            {
                ProductID = proid
            };
            product.deleteProduct();
            loadData();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}