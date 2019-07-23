using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString);
    User user;
    Booth booth;
    VisitCustomer visitCustomer;
    EventCalendar eventcalender;

    StatusConfirm statusWork;

    public object Upload { get; private set; }

    public List<Booth> GetBoothData(int empid)
    {
        List<Booth> boothlist = new List<Booth>();
        con.Open();
        SqlCommand sql_com = new SqlCommand("Select_Detail_Booth_EmpID", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@EmpID", empid);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            sql_com.ExecuteNonQuery();

            foreach (DataRow item in ds.Rows)
            {
                booth = new Booth()
                {
                    ID = item["ID"].ToString(),
                    ToDate = Convert.ToDateTime(item["ToDate"].ToString()),
                    Type = Convert.ToInt32(item["Type"].ToString()),
                    Type_Name = item["Type_Name"].ToString(),
                    Place_Name = item["Place_Name"].ToString(),
                    Province = Convert.ToInt32(item["Province"].ToString()),
                    PROVINCE_NAME = item["PROVINCE_NAME"].ToString(),
                    Amphur = Convert.ToInt32(item["Amphur"].ToString()),
                    AMPHUR_NAME = item["AMPHUR_NAME"].ToString(),
                    District = item["District"].ToString(),
                    DISTRICT_NAME = item["DISTRICT_NAME"].ToString(),
                    SetWorkTime = Convert.ToDateTime(item["SetWorkTime"].ToString()),
                    SetOutTime = Convert.ToDateTime(item["SetOutTime"].ToString()),
                    ID_CCW = item["ID_CCW"].ToString() == string.Empty ? 0 : Convert.ToInt32(item["ID_CCW"].ToString()),
                    ID_SCW = Convert.ToInt32(item["ID_SCW"].ToString()),
                    ID_Show = item["ID_Show"].ToString() == string.Empty ? 0 : Convert.ToInt32(item["ID_Show"].ToString()),
                    ID_DS = Convert.ToInt32(item["ID_DS"].ToString()),
                    Emp_id = Convert.ToInt32(item["Emp_id"].ToString()),
                    EmpName = item["EmpName"].ToString(),
                    Team = item["Team"].ToString(),
                    branchid = Convert.ToInt32(item["branchid"].ToString()),
                    ID_SC = Convert.ToInt32(item["ID_SC"].ToString()),
                    PictureWorkTime = item["PictureWorkTime"].ToString(),
                    PictureOutTime = item["PictureOutTime"].ToString(),
                    LatitudeIn = item["LatitudeIn"].ToString(),
                    LatitudeOut = item["LatitudeOut"].ToString(),
                    LongitudeIn = item["LongitudeIn"].ToString(),
                    LongitudeOut = item["LongitudeOut"].ToString(),
                    WorkTime = item["WorkTime"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(item["WorkTime"].ToString()),
                    OutTime = item["OutTime"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(item["OutTime"].ToString()),
                    CancelWork = item["CancelWork"].ToString(),
                };
                boothlist.Add(booth);
            }
        }
        catch (Exception)
        {
            boothlist = new List<Booth>();
        }
        finally
        {
            con.Close();
        }
        return boothlist;
    }

    public List<EventCalendar> GetEventCalendarData(int empid)
    {
        List<EventCalendar> eventlist = new List<EventCalendar>();
        con.Open();
        SqlCommand sql_com = new SqlCommand("Select_Detail_EvenCalendar_EmpID", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@EmpID", empid);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            sql_com.ExecuteNonQuery();

            foreach (DataRow item in ds.Rows)
            {
                eventcalender = new EventCalendar()
                {
                    Detail_Event_No = item["Detail_Event_No"].ToString(),
                    Event_No = item["Event_No"].ToString(),
                    Emp_id = Convert.ToInt32(item["Emp_id"].ToString()),
                    Event_Place = item["Event_Place"].ToString(),
                    Event_TimeStart = item["Event_TimeStart"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(item["Event_TimeStart"].ToString()),
                    Event_TimeEnd = item["Event_TimeEnd"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(item["Event_TimeEnd"].ToString()),
                    TimeStart = item["TimeStart"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(item["TimeStart"].ToString()),
                    TimeEnd = item["TimeEnd"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(item["TimeEnd"].ToString()),
                    Event_Date = item["Event_Date"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(item["Event_Date"].ToString()),
                    EmpName = item["EmpName"].ToString(),
                    NickName = item["NickName"].ToString(),
                    Tel = item["Tel"].ToString(),
                    Team = item["Team"].ToString(),
                    companybranchname = item["companybranchname"].ToString(),
                    ID_SC = item["ID_SC"].ToString() == string.Empty ? 0 : Convert.ToInt32(item["ID_SC"]),
                    PictureStart = item["PictureStart"].ToString(),
                    PictureEnd = item["PictureEnd"].ToString(),
                    LatitudeIn = item["LatitudeIn"].ToString(),
                    LongitudeIn = item["LongitudeIn"].ToString(),
                    LatitudeOut = item["LatitudeOut"].ToString(),
                    LongitudeOut = item["LongitudeOut"].ToString(),
                    ID_CCW  = item["ID_CCW"].ToString() == string.Empty ? null : item["ID_CCW"].ToString(),
                };
                eventlist.Add(eventcalender);
            }
        }
        catch (Exception)
        {
            eventlist = new List<EventCalendar>();
        }
        finally
        {
            con.Close();
        }
        return eventlist;
    }

    public List<VisitCustomer> GetVisitCustomerData(int empid)
    {
        List<VisitCustomer> visitlist = new List<VisitCustomer>();
        con.Open();
        SqlCommand sql_com = new SqlCommand("Select_Detail_VisitCustomer_EmpID", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@EmpID", empid);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            sql_com.ExecuteNonQuery();

            foreach (DataRow item in ds.Rows)
            {
                visitCustomer = new VisitCustomer()
                {
                    ID_VIP = item["ID_VIP"].ToString(),
                    ID_DVIP = item["ID_DVIP"].ToString(),
                    Emp_id = Convert.ToInt32(item["Emp_id"].ToString()),
                    EmpName = item["EmpName"].ToString(),
                    Nickname = item["Nickname"].ToString(),
                    Tel = item["Tel"].ToString(),
                    Team = item["Team"].ToString(),
                    companybranchname = item["companybranchname"].ToString(),
                    ToDate = item["ToDate"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(item["ToDate"].ToString()),
                    CusNo = item["CusNo"].ToString(),
                    IDCard = item["IDCard"].ToString(),
                    Name = item["Name"].ToString(),
                    Surname = item["Surname"].ToString(),
                    NickName = item["Nickname1"].ToString(),
                    Tel_Mobile1 = item["Tel_Mobile1"].ToString(),
                    Address = item["Address"].ToString(),
                    Add_Moo = item["Add_Moo"].ToString(),
                    DISTRICT_NAME = item["DISTRICT_NAME"].ToString(),
                    AMPHUR_NAME = item["AMPHUR_NAME"].ToString(),
                    PROVINCE_NAME = item["PROVINCE_NAME"].ToString(),
                    ID_CCV1 = item["ID_CCV1"].ToString(),
                    MCNumber = item["MCNumber"].ToString() == string.Empty ? 0 : Convert.ToInt32(item["MCNumber"].ToString()),
                    ID_SCW = item["ID_SCW"].ToString() == string.Empty ? 0 : Convert.ToInt32(item["ID_SCW"].ToString()),
                    Status_ConfirmWork = item["Status_ConfirmWork"].ToString(),
                    PictureHome = item["PictureHome"].ToString(),
                    StatusFind = item["StatusFind"].ToString() == string.Empty ? 0 : Convert.ToInt32(item["StatusFind"].ToString()),
                    LatitudeIn = item["LatitudeIn"].ToString(),
                    LongitudeIn = item["LongitudeIn"].ToString(),
                    UserType = item["UserType"].ToString() == string.Empty ? 0 : Convert.ToInt32(item["UserType"].ToString())

                };
                visitlist.Add(visitCustomer);
            }
        }
        catch (Exception)
        {
            visitlist = new List<VisitCustomer>();
        }
        finally
        {
            con.Close();
        }
        return visitlist;
    }

    public List<StatusConfirm> SelectStatusConfirmWork(int id_scw)
    {
        List<StatusConfirm> id_scw_list = new List<StatusConfirm>();
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspSelectStatusConfirmWork", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@ID_SCW", id_scw);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            sql_com.ExecuteNonQuery();

            foreach (DataRow item in ds.Rows)
            {
                statusWork = new StatusConfirm()
                {
                    ID_SCW = Convert.ToInt32(item["ID_SCW"].ToString()),
                    Status_ConfirmWork = item["Status_ConfirmWork"].ToString()
                };
                id_scw_list.Add(statusWork);
            }
        }
        catch (Exception)
        {
            id_scw_list = new List<StatusConfirm>();
        }
        finally
        {
            con.Close();
        }
        return id_scw_list;
    }

    public void tesUploadImg(int ds, byte[] dataimg)
    {
        con.Open();

        SqlCommand sql_com = new SqlCommand("uspUpdateImgBooth", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        string result = BitConverter.ToString(dataimg);
        try
        {
            adapter.UpdateCommand = sql_com;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.AddWithValue("@Detail_Event_No", ds);
            adapter.UpdateCommand.Parameters.AddWithValue("@PictureWorkTime", dataimg);
            sql_com.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            string mg = ex.Message;
            string mg2 = ex.Data.ToString();
        }
        finally
        {
            con.Close();
        }

    }

    public int UpdateDetailBoothIn(string worktime, string latitudeIn, string longtitudeIn,byte[] dataimg, int id_sc, int id_ds, string cancelwork,string detail_checkin_etc)
    {
        int status = 0;
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspUpdateDetailBoothShow_Moblie", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        TimeSpan time = TimeSpan.Parse(worktime);

        try
        {
            adapter.UpdateCommand = sql_com;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.AddWithValue("@WorkTime", worktime);
            adapter.UpdateCommand.Parameters.AddWithValue("@LatitudeIn", latitudeIn);
            adapter.UpdateCommand.Parameters.AddWithValue("@LongitudeIn", longtitudeIn);
            adapter.UpdateCommand.Parameters.AddWithValue("@PictureWorkTime", dataimg);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_SC", id_sc);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_DS", id_ds);
            adapter.UpdateCommand.Parameters.AddWithValue("@CancelWork", cancelwork);
            adapter.UpdateCommand.Parameters.AddWithValue("@Detail_CheckInEtc", detail_checkin_etc);
            sql_com.ExecuteNonQuery();

            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }
     
    public int UpdateDetailBoothOut(string outtime, string latitudeOut, string longtitudeOut,byte[] dataimg,int id_sc,int ps,int bk, int interview , int id , int id_ds, string detail_checkin_etc)
    {
        int status = 0;
        con.Open();
        //SqlCommand sql_com = new SqlCommand("uspUpdate_DetailBoothShow_MoblieV2", con);
        SqlCommand sql_com = new SqlCommand("uspUpdateDetailBoothShow_Moblie2", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);

        try
        {
            adapter.UpdateCommand = sql_com;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.AddWithValue("@OutTime", outtime);
            adapter.UpdateCommand.Parameters.AddWithValue("@LatitudeOut", latitudeOut);
            adapter.UpdateCommand.Parameters.AddWithValue("@LongitudeOut", longtitudeOut);
            adapter.UpdateCommand.Parameters.AddWithValue("@PictureOutTime", dataimg);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_SC", id_sc);
            adapter.UpdateCommand.Parameters.AddWithValue("@PS", ps);
            adapter.UpdateCommand.Parameters.AddWithValue("@BK", bk);
            adapter.UpdateCommand.Parameters.AddWithValue("@InterView", interview);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID", id);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_DS", id_ds);
            adapter.UpdateCommand.Parameters.AddWithValue("@Detail_CheckInEtc", detail_checkin_etc);
            sql_com.ExecuteNonQuery();

            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public int UpdateDetailEventIn(int event_detail_id, string starttime, byte[] dataimg, int id_sc, string latitudeIn, string longitudeIn)
    {
        int status = 0;
        con.Open();
        SqlCommand sql_com = new SqlCommand("Update_DetailEvent_Mobile", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        TimeSpan time = TimeSpan.Parse(starttime);

        try
        {
            adapter.UpdateCommand = sql_com;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.AddWithValue("@Detail_Event_No", event_detail_id);
            adapter.UpdateCommand.Parameters.AddWithValue("@Event_TimeStart", time);
            adapter.UpdateCommand.Parameters.AddWithValue("@PictureStart", dataimg);
            //adapter.UpdateCommand.Parameters.AddWithValue("@PictureEnd", SqlDbType.Image).Value = imageBytes;
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_SC", id_sc);
            //adapter.UpdateCommand.Parameters.AddWithValue("@ID_CCW", id_cw);
            adapter.UpdateCommand.Parameters.AddWithValue("@LatitudeIn", latitudeIn);
            adapter.UpdateCommand.Parameters.AddWithValue("@LongitudeIn", longitudeIn);
            sql_com.ExecuteNonQuery();

            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public int UpdateDetailEventOut(int event_detail_id, string outtime,byte[] dataimg, int id_sc, string latitudeOut, string longitudeOut)
    {
        int status = 0;
        con.Open();
        SqlCommand sql_com = new SqlCommand("Update_DetailEvent_Mobile2", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        TimeSpan time = TimeSpan.Parse(outtime);

        try
        {
            adapter.UpdateCommand = sql_com;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.AddWithValue("@Detail_Event_No", event_detail_id);
            adapter.UpdateCommand.Parameters.AddWithValue("@Event_TimeEnd", time);
            adapter.UpdateCommand.Parameters.AddWithValue("@PictureEnd", dataimg);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_SC", id_sc);
            //adapter.UpdateCommand.Parameters.AddWithValue("@ID_CCW", id_cw);
            adapter.UpdateCommand.Parameters.AddWithValue("@LatitudeOut", latitudeOut);
            adapter.UpdateCommand.Parameters.AddWithValue("@LongitudeOut", longitudeOut);
            sql_com.ExecuteNonQuery();

            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public int UpdateDetailVip(string latitudeIn, string longitudeIn, string statusFind,byte[] dataimg, string id_ccv, string id_scw, int id_dvip)
    {
        int status = 0;
        con.Open();
        SqlCommand sql_com = new SqlCommand("Update_DetailVisit_Mobile", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        //FileStream fs = new FileStream(picturehome, FileMode.Open, FileAccess.ReadWrite);
        //byte[] imageBytes = new byte[fs.Length];
        //fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
        //fs.Dispose();

        try
        {
            adapter.UpdateCommand = sql_com;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.AddWithValue("@LatitudeIn", latitudeIn);
            adapter.UpdateCommand.Parameters.AddWithValue("@LongitudeIn", longitudeIn);
            adapter.UpdateCommand.Parameters.AddWithValue("@PictureHome", dataimg);
            adapter.UpdateCommand.Parameters.AddWithValue("@StatusFind", statusFind);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_CCV", id_ccv);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_SCW", id_scw);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_DVIP", id_dvip);
            sql_com.ExecuteNonQuery();

            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public int UpdateDetailBoothInXray(string worktime, string latitudeIn, string longtitudeIn, byte[] dataimg, int id_sc, int id_ds, string cancelwork, string detail_checkin_etc)
    {
        int status = 0;
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspUpdateDetailBoothShow_Moblie", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        TimeSpan time = TimeSpan.Parse(worktime);

        try
        {
            adapter.UpdateCommand = sql_com;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.AddWithValue("@WorkTime", worktime);
            adapter.UpdateCommand.Parameters.AddWithValue("@LatitudeIn", latitudeIn);
            adapter.UpdateCommand.Parameters.AddWithValue("@LongitudeIn", longtitudeIn);
            adapter.UpdateCommand.Parameters.AddWithValue("@PictureWorkTime", dataimg);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_SC", id_sc);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_DS", id_ds);
            adapter.UpdateCommand.Parameters.AddWithValue("@CancelWork", cancelwork);
            adapter.UpdateCommand.Parameters.AddWithValue("@Detail_CheckInEtc", detail_checkin_etc);
            sql_com.ExecuteNonQuery();

            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public int UpdateDetailBoothOutXray(string outtime, string latitudeOut, string longtitudeOut, byte[] dataimg, int id_sc, int ps, int bk, int interview, int id, int id_ds, string detail_checkin_etc)
    {
        int status = 0;
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspUpdateDetailBoothShow_Moblie2", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);

        try
        {
            adapter.UpdateCommand = sql_com;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.AddWithValue("@OutTime", outtime);
            adapter.UpdateCommand.Parameters.AddWithValue("@LatitudeOut", latitudeOut);
            adapter.UpdateCommand.Parameters.AddWithValue("@LongitudeOut", longtitudeOut);
            adapter.UpdateCommand.Parameters.AddWithValue("@PictureOutTime", dataimg);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_SC", id_sc);
            adapter.UpdateCommand.Parameters.AddWithValue("@PS", ps);
            adapter.UpdateCommand.Parameters.AddWithValue("@BK", bk);
            adapter.UpdateCommand.Parameters.AddWithValue("@InterView", interview);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID", id);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_DS", id_ds);
            adapter.UpdateCommand.Parameters.AddWithValue("@Detail_CheckInEtc", detail_checkin_etc);
            sql_com.ExecuteNonQuery();

            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public int CancelBooth(int id_show,int id_ccw)
    {
        int status = 0;
        con.Open();
        SqlCommand sql_com = new SqlCommand("Mobile_Cancel_Master_BoothShow", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);


        try
        {
            adapter.UpdateCommand = sql_com;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_Show", id_show);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_CCW", id_ccw);
            sql_com.ExecuteNonQuery();

            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }
    public int CancelVip(int id_vip, int id_ccv)
    {
        int status = 0;
        con.Open();
        SqlCommand sql_com = new SqlCommand("Mobile_Cancel_Master_VisitCustomer", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);


        try
        {
            adapter.UpdateCommand = sql_com;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_VIP", id_vip);
            adapter.UpdateCommand.Parameters.AddWithValue("@ID_CCV", id_ccv);
            sql_com.ExecuteNonQuery();

            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public List<User> UserLogin(string username, string password)
    {
        List<User> userlist = new List<User>();
        con.Open();
        SqlCommand sql_com = new SqlCommand("Moblie_Select_Login", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Username", username);
            adapter.SelectCommand.Parameters.AddWithValue("@Password", password);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            sql_com.ExecuteNonQuery();

            user = new User();

            foreach (DataRow item in ds.Rows)
            {
                user.Username = item["Username"].ToString();
                user.Password = item["Password"].ToString();
                user.Emp_id = Convert.ToInt32(item["Emp_id"].ToString());
                user.EmpName = item["EmpName"].ToString();
                user.Tel = item["Tel"].ToString();
                user.UserType = Convert.ToInt32(item["UserType"].ToString());
                user.Company = item["Company"].ToString();
                user.Branch = Convert.ToInt32(item["Branch"].ToString());
                user.NickName = item["NickName"].ToString();
                user.Team = item["Team"].ToString();
                user.IOSUser = item["IOSUser"].ToString();
                user.StatusSale = Convert.ToInt32(item["StatusSale"].ToString());
                user.User_EditTeam = item["User_EditTeam"].ToString();
                user.Date_EditTeam = item["Date_EditTeam"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(item["Date_EditTeam"].ToString());
                user.ComapanyName = item["companyname"].ToString();
                user.ComapanyBranch = item["companybranchname"].ToString();
                userlist.Add(user);
            }
        }
        catch (Exception)
        {
            userlist = new List<User>();
        }
        finally
        {
            con.Close();
        }
        return userlist;
    }


}
