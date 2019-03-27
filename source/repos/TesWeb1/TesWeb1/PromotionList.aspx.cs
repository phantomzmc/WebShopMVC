using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesWeb1
{
    public partial class Promotion : System.Web.UI.Page
    {
        PromotionList promotions;
        
        Array PromotionType = new[] {
                        new { Text = "Discount Bath", Value = "2" },
                        new { Text = "Discount Percent", Value = "1" }
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.typePromotion();
                this.selectPromotion();
            }
        }

        void selectPromotion()
        {
            promotions = new PromotionList();
            promotions.selectPromotion();
            GridView1.DataSource = promotions.Values;
            GridView1.DataBind();
        }
        void typePromotion()
        {
            DropDownList1.DataSource = PromotionType;
            DropDownList1.DataTextField = "Text";
            DropDownList1.DataValueField = "Value";
            DropDownList1.DataBind();
        }
        void addPromotion()
        {
            try
            {
                string name = promotionname_TextBox.Text.ToString();
                int type = int.Parse(DropDownList1.SelectedValue.ToString());
                string discount = promotiondiscount_TextBox.Text.ToString();

                promotions = new PromotionList();
                promotions.addPromotion(name, discount, type);

            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                this.selectPromotion();
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int promoid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            promotions = new PromotionList();
            promotions.deletePromotion(promoid);
            this.selectPromotion();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int promotionid = int.Parse((row.FindControl("editid_TextBox") as TextBox).Text);
                string promotionname = (row.FindControl("editname_TextBox") as TextBox).Text;
                string promotiondiscount = (row.FindControl("editdiscount_TextBox") as TextBox).Text;
                int typepromotion = int.Parse((row.FindControl("edittype_TextBox") as TextBox).Text);

                if(promotionname == "" || promotionname == null)
                {
                    this.testModal("PromotionName", "");
                }
                else if(promotiondiscount == "" || promotiondiscount == null)
                {
                    this.testModal("PromotionDiscount", "");
                }
                else
                {
                    promotions = new PromotionList();
                    promotions.editPromotion(promotionid, promotionname, promotiondiscount, typepromotion);

                    GridView1.EditIndex = -1;
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                this.testModal("Error", error);
            }
            finally
            {
                this.selectPromotion();
            }
        }

        protected void submit_Button_Click(object sender, EventArgs e)
        {
            string name = promotionname_TextBox.Text.ToString();
            int type = int.Parse(DropDownList1.SelectedValue.ToString());
            string discount = promotiondiscount_TextBox.Text.ToString();

            try
            {
                if (name == "" || name == null)
                {
                    this.testModal("PromotionName", "");
                }
                else if (discount == "" || discount == null) 
                {
                    this.testModal("PromotionDiscount", "");
                }
                else
                {
                    this.addPromotion();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                this.testModal("Error", error);
            }
        }

        public void testModal(string text1 ,string text2)
        {
            string body = "place input"+ text1 + " or  " + text2 + " is legth ";
            lblModalTitle.Text = "error input";
            lblModalBody.Text = body;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }

        protected void btnProSearch_Click1(object sender, EventArgs e)
        {
            string keyname = TextBox1.Text.ToString();
            promotions = new PromotionList();
            try
            {
                promotions.searchPromotion(keyname);
                GridView1.DataSource = promotions.Values;
                GridView1.DataBind();
            }
            catch (Exception)
            {
                this.selectPromotion();
            }
        }
    }
}