using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using ClosedXML.Excel;

namespace Purchase._ReportForm
{
    public partial class Rpt_SPurchasetoExcel : System.Web.UI.Page
    {
        //private _SPurchaseList _PurchaseList;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["SPurchasetoExcel"] != null)
            //{
            //    this._PurchaseList = (_SPurchaseList)Session["SPurchasetoExcel"];
            //}

            //DataTable _dt = new DataTable();
            //_dt.TableName = "DetailPurchase";
            //_dt.Columns.Add("ID").ColumnName = "ลำดับ";
            //_dt.Columns.Add("NickName").ColumnName = "ที่ปรึกษาการขาย";
            //_dt.Columns.Add("Emp_Company").ColumnName = "SC_สาขา";
            //_dt.Columns.Add("Emp_Team").ColumnName = "SC_ทีม";
            //foreach (var item in _PurchaseList)
            //{
            //    dt.Rows.Add(Convert.ToString(item.Value._Purchase.ID)
            //                , item.Value.Tb_User.NickName);
            //}

            DataTable _dt = (DataTable)Session["SPurchasetoExcel"];
            _dt.TableName = "Purchase";
            _dt.Columns["NickName"].ColumnName = "ที่ปรึกษาการขาย";
            _dt.Columns["Emp_Company"].ColumnName = "SC_สาขา";
            _dt.Columns["Emp_Team"].ColumnName = "SC_ทีม";
            _dt.Columns["Purchase_Date"].ColumnName = "วันที่เปิด";
            _dt.Columns["OutCar_Date"].ColumnName = "วันที่ออกรถ";
            _dt.Columns["PurchaseNo"].ColumnName = "เลขที่PO";
            _dt.Columns["PoNum"].ColumnName = "ลำดับใบสั่งซื้อ";
            _dt.Columns["BookNo"].ColumnName = "เลขที่PP";
            _dt.Columns["ProspectNo"].ColumnName = "เลขที่PS";
            _dt.Columns["PSNo_IOS"].ColumnName = "เลขที่PS_IOS";
            _dt.Columns["BKNo_IOS"].ColumnName = "เลขที่BK_IOS";
            _dt.Columns["CusNo"].ColumnName = "รหัสลูกค้า";
            _dt.Columns["IDCard"].ColumnName = "เลขบัตรประชาชน";
            _dt.Columns["CusName"].ColumnName = "ชื่อลูกค้า";
            _dt.Columns["Cus_NickName"].ColumnName = "ชื่อเล่น";
            _dt.Columns["Birthday"].ColumnName = "วันเกิด";
            _dt.Columns["Sex"].ColumnName = "เพศ";
            _dt.Columns["Education"].ColumnName = "วุฒิการศึกษา";
            _dt.Columns["Tel_Mobile1"].ColumnName = "เบอร์มือถือ1";
            _dt.Columns["Tel_Mobile2"].ColumnName = "เบอร์มือถือ2";
            _dt.Columns["Tel_Work"].ColumnName = "เบอร์บ้าน/ที่ทำงาน";
            _dt.Columns["Tel_Fax"].ColumnName = "เบอร์แฟกซ์";
            _dt.Columns["Career"].ColumnName = "อาชีพ";
            _dt.Columns["Career_Remark"].ColumnName = "รายละเอียดอาชีพ";
            _dt.Columns["Income"].ColumnName = "รายได้";
            _dt.Columns["Address"].ColumnName = "ที่อยู่";
            _dt.Columns["Add_Moo"].ColumnName = "หมู่ที่";
            _dt.Columns["Add_HomeName"].ColumnName = "หมู่บ้าน";
            _dt.Columns["Add_Road"].ColumnName = "ถนน";
            _dt.Columns["Add_Soi"].ColumnName = "ซอย";
            _dt.Columns["Add_District"].ColumnName = "ตำบล";
            _dt.Columns["Add_Amphur"].ColumnName = "อำเภอ";
            _dt.Columns["Add_Province"].ColumnName = "จังหวัด";
            _dt.Columns["SendAddress"].ColumnName = "ที่อยู่ส่งเอกสาร";
            _dt.Columns["SendAdd_Moo"].ColumnName = "S_หมู่ที่";
            _dt.Columns["SendAdd_HomeName"].ColumnName = "S_หมู่บ้าน";
            _dt.Columns["SendAdd_Road"].ColumnName = "S_ถนน";
            _dt.Columns["SendAdd_Soi"].ColumnName = "S_ซอย";
            _dt.Columns["SendAdd_District"].ColumnName = "S_ตำบล";
            _dt.Columns["SendAdd_Amphur"].ColumnName = "S_อำเภอ";
            _dt.Columns["SendAdd_Province"].ColumnName = "S_จังหวัด";
            _dt.Columns["CarName"].ColumnName = "สั่งซื้อรถยนต์";
            _dt.Columns["Buy_Type"].ColumnName = "ประเภทการซื้อ";
            _dt.Columns["MCNumber"].ColumnName = "หมายเลขเครื่อง";
            _dt.Columns["TruckNumber"].ColumnName = "หมายเลขตัวถัง";
            _dt.Columns["MSaleCode"].ColumnName = "แบบ";
            _dt.Columns["MCode"].ColumnName = "รุ่นรถ";
            _dt.Columns["MName"].ColumnName = "ชื่อรุ่น";
            _dt.Columns["CCode"].ColumnName = "สี";
            _dt.Columns["CName"].ColumnName = "ชื่อสี";
            _dt.Columns["CarPrice"].ColumnName = "ราคารถ";
            _dt.Columns["CarPlate"].ColumnName = "หมายเลขทะเบียน";
            _dt.Columns["Regis_Date"].ColumnName = "วันที่จดทะเบียน";
            _dt.Columns["CarTax"].ColumnName = "ภาษีรถ";
            _dt.Columns["CarType"].ColumnName = "ประเภทรถ";
            _dt.Columns["Car_Company"].ColumnName = "รถสาขา";
            _dt.Columns["CE_Brand"].ColumnName = "รถเก่า_ยี่ห้อ";
            _dt.Columns["CE_Model"].ColumnName = "รถเก่า_รุ่น";
            _dt.Columns["CE_Year"].ColumnName = "รถเก่า_ปี";
            _dt.Columns["CE_Color"].ColumnName = "รถเก่า_สี";
            _dt.Columns["CE_Carplate"].ColumnName = "รถเก่า_เลขทะเบียน";
            _dt.Columns["CE_MCNumber"].ColumnName = "รถเก่า_เลขเครื่อง";
            _dt.Columns["CE_TruckNumber"].ColumnName = "รถเก่า_เลขตัวถัง";
            _dt.Columns["CE_Price"].ColumnName = "รถเก่า_ราคา";
            _dt.Columns["CE_PriceEmp"].ColumnName = "รถเก่า_ผู้ประเมินราคา";
            _dt.Columns["InsuranceName"].ColumnName = "ประกันภัยประเภท1";
            _dt.Columns["Outlay"].ColumnName = "ทุนประกัน";
            _dt.Columns["RegisName"].ColumnName = "จดทะเบียน";
            _dt.Columns["ActNo"].ColumnName = "เลขที่ พ.ร.บ";
            _dt.Columns["FinanceName"].ColumnName = "ไฟแนนซ์";
            _dt.Columns["Finance_Au"].ColumnName = "เจ้าหน้าที่ไฟแนนซ์";
            _dt.Columns["CarPriceAd"].ColumnName = "ราคารถยนต์เพิ่มเติม";
            _dt.Columns["PayDown"].ColumnName = "เงินดาวน์";
            _dt.Columns["DPeak"].ColumnName = "ยอดจัด";
            _dt.Columns["LoanProtection"].ColumnName = "ประกันภัยสินเชื่อ";
            _dt.Columns["hpcost"].ColumnName = "ยอดเช่าซื้อ";
            _dt.Columns["Interest"].ColumnName = "ดอกเบี้ย";
            _dt.Columns["Interest_Remark"].ColumnName = "เงื่อนไขดอกเบี้ย";
            _dt.Columns["Total_Payment"].ColumnName = "จำนวนงวด";
            _dt.Columns["Price_Payment"].ColumnName = "ค่าใช้จ่ายต่องวด";
            _dt.Columns["Pay_Begin"].ColumnName = "ชำระค่างวดล่วงหน้า";
            _dt.Columns["CampaignName"].ColumnName = "แคมเพจน์งาน";
            _dt.Columns["Deposit_No"].ColumnName = "มัดจำ_เลขที่ใบเสร็จ";
            _dt.Columns["Deposit_Date"].ColumnName = "มัดจำ_วันที่ออกใบเสร็จ";
            _dt.Columns["Deposit_Price"].ColumnName = "มัดจำ_จำนวนเงิน";
            _dt.Columns["DepositAd_No"].ColumnName = "มัดจำเพิ่มเติม_เลขที่ใบเสร็จ";
            _dt.Columns["DepositAd_Date"].ColumnName = "มัดจำเพิ่มเติม_วันที่ออกใบเสร็จ";
            _dt.Columns["DepositAd_Price"].ColumnName = "มัดจำเพิ่มเติม_จำนวนเงิน";
            _dt.Columns["PayCash_No"].ColumnName = "เงินสด_เลขที่ใบเสร็จ";
            _dt.Columns["PayCash_Date"].ColumnName = "เงินสด_วันที่ออกใบเสร็จ";
            _dt.Columns["PayCash_Price"].ColumnName = "เงินสด_จำนวนเงิน";
            _dt.Columns["PayTM"].ColumnName = "เงินโอนธนาคาร";
            _dt.Columns["PayTM_No"].ColumnName = "เงินโอนธนาคาร_เลขที่ใบเสร็จ";
            _dt.Columns["PayTM_Date"].ColumnName = "เงินโอนธนาคาร_วันที่ออกใบเสร็จ";
            _dt.Columns["PayTM_Price"].ColumnName = "เงินโอนธนาคาร_จำนวนเงิน";
            _dt.Columns["PayCheque"].ColumnName = "เช็คธนาคาร";
            _dt.Columns["PayCheque_No"].ColumnName = "เช็คธนาคาร_เลขที่ใบเสร็จ";
            _dt.Columns["PayCheque_Date"].ColumnName = "เช็คธนาคาร_วันที่ออกใบเสร็จ";
            _dt.Columns["PayCheque_Price"].ColumnName = "เช็คธนาคาร_จำนวนเงิน";
            _dt.Columns["RedCarPlate_No"].ColumnName = "มัดจำป้ายแดง_เลขที่ใบเสร็จ";
            _dt.Columns["RedCarPlate_Date"].ColumnName = "มัดจำป้ายแดง_วันที่ออกใบเสร็จ";
            _dt.Columns["RedCarPlate_Price"].ColumnName = "มัดจำป้ายแดง_จำนวนเงิน";
            _dt.Columns["RedCarPlate_Num"].ColumnName = "ป้ายแดงเลขที่";  
            _dt.Columns["PriceSumCar"].ColumnName = "รวมยอดเงินค่ารถ";
            _dt.Columns["PriceSum"].ColumnName = "รวมยอดเงินที่ลูกค้าต้องชำระ";
            _dt.Columns["RepayToCus"].ColumnName = "ยอดเงินที่ต้องชำระคืนลูกค้า";
            _dt.Columns["Remark"].ColumnName = "รายละเอียดเพิ่มเติม";
            _dt.Columns["OriEmp"].ColumnName = "ที่มาของลูกค้า";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(_dt);
                Response.Clear();

                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=DetailPurchase.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
    }
}