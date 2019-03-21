using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesWeb1
{
    public partial class TypeProduct : System.Web.UI.Page
    {
        Product product;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.loadTypeProduct();
            }
        }

        public void loadTypeProduct()
        {
            product = new Product();
            GridView2.DataSource = product.selectType();
            GridView2.DataBind();
        }
        protected void submitType_Click(object sender, EventArgs e)
        {
            string typename = typename_TextBox.Text.ToString();
            string typedetail = typedetail_TextBox.Text.ToString();

            product = new Product(typename, typedetail)
            {
                TypeName = typename,
                TypeDetail = typedetail
            };
            product.addTypeProduct();
            this.loadTypeProduct();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            this.loadTypeProduct();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView2.Rows[e.RowIndex];
            int typeid = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);

            product = new Product(typeid)
            {
                TypeID = typeid
            };
            product.deleteTypeProduct();
            this.loadTypeProduct();
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView2.Rows[e.RowIndex];
            int typeid = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
            string typename = (row.FindControl("typename_TextBox") as TextBox).Text;
            string typedetail = (row.FindControl("typedetail_TextBox") as TextBox).Text;

            product = new Product(typeid, typename, typedetail)
            {
                TypeID = typeid,
                TypeName = typename,
                TypeDetail = typedetail
            };
            product.editTypeProduct();
            GridView2.EditIndex = -1;
            loadTypeProduct();
        }
    }
}