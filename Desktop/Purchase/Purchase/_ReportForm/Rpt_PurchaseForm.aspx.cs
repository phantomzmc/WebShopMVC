using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Purchase._ReportForm;
using Purchase._Form;

namespace Purchase._ReportForm
{
    public partial class Rpt_PurchaseForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _MCNumber = Request.QueryString["MC"].ToString();
            //string _MCNumber = "PD7530";

            string[] spChar = { "+", "&", "%", "$" };
            string[] replaceChar = { "_plus", "_amp", "_per", "_dol" };

            for (int i = 0; i <= spChar.Length - 1; i++)
            {
                _MCNumber = _MCNumber.Replace(replaceChar[i], spChar[i]);
            }

                DataSet _ds = new DataSet();
                _ds.DataSetName = "DataSet_Report";
                DataTable _dt = new DataTable();
                DataTable _dt2 = new DataTable();
                _Purchase _p = new _Purchase();
                _InvoiceList invoicelist = new _InvoiceList();
                _MCNumber = _Encryption.Decrypt(_MCNumber);

                 _dt = _p.Select_Purchase(1, _MCNumber);
                int IDCheck = int.Parse(_dt.Rows[0]["ID"].ToString());
                _dt.TableName = "Purchase";
                _ds.Tables.Add(_dt);

                int poid = IDCheck;
                _dt2 = new DataTable();
                _dt2 = invoicelist.selectInvoiceReport(poid);
                _dt2.TableName = "Invoice";
                _ds.Tables.Add(_dt2);

                string _Company = _dt.Rows[0]["CompanyName"].ToString();

                _dt = new DataTable();
                _dt = _p.Select_Purchase(2, _MCNumber);
                _dt.TableName = "Accessories1";
                _ds.Tables.Add(_dt);

                _dt = new DataTable();
                _dt = _p.Select_Purchase(3, _MCNumber);
                _dt.TableName = "Accessories2";
                _ds.Tables.Add(_dt);

                
                ReportDocument rpt = new ReportDocument();
                //DataSet ds = new DataSet("DataSet_Report");
                //CRpt_PurchaseNew rptPurchase = new CRpt_PurchaseNew();
                //rptPurchase.SetDataSource(ds);
                string strRpt = Server.MapPath("../_Form/CRpt_PurchaseNew.rpt");
                rpt.Load(strRpt);


                rpt.SetDataSource(_ds);
                rpt.SetParameterValue("Header", _Company);
                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "ใบสั่งซื้อ");
                Response.End();

                //DataSet _ds = (DataSet)Session["Rpt_SumPSBK_CR"];

                //DateTime SumPSBKDate1 = DateTime.MinValue;
                //DateTime.TryParse(Session["SumPSBK_CRDate1"].ToString(), out SumPSBKDate1);

                //DateTime SumPSBKDate2 = DateTime.MinValue;
                //DateTime.TryParse(Session["SumPSBK_CRDate2"].ToString(), out SumPSBKDate2);

        }
    }
}