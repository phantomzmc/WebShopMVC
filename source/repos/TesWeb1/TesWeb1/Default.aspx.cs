using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesWeb1
{
    public partial class _Default : Page
    {
        ProductList.Product product;
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
            product = new ProductList.Product();
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

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DropDownList1.SelectedValue = DropDownList1.SelectedItem.Value;

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {

        }
    }
}