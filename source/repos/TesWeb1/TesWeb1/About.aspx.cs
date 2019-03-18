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
            loadData();   
        }
        void loadData()
        {
            ProductList.Product product = new ProductList.Product();
            //product.selectProduct();
            GridView1.DataSource = product.selectProduct();
            GridView1.DataBind();
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            string name = productname_textbox.Text.ToString();
            int price = int.Parse(productprice_textbox.Text.ToString());
            string detail = productdetail_textbox.Text.ToString();
            int type = int.Parse(typeproduct_textbox.Text.ToString());

            ProductList.Product product = new ProductList.Product(name, price, detail, type)
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
        }
    }
}