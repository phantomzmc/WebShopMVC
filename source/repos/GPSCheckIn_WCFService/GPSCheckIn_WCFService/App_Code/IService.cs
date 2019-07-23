using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
    [OperationContract]
    List<User> UserLogin(string username, string password);
    [OperationContract]
    List<Booth> GetBoothData(int empid);
    [OperationContract]
    List<EventCalendar> GetEventCalendarData(int empid);

    [OperationContract]
    List<VisitCustomer> GetVisitCustomerData(int empid);

    [OperationContract]
    void tesUploadImg(int ds, byte[] dataimg);
    [OperationContract]
    int UpdateDetailBoothIn(string worktime, string latitudeIn, string longtitudeIn, byte[] dataimg, int id_sc, int id_ds, string cancelwork, string detail_checkin_etc);
    [OperationContract]
    int UpdateDetailBoothOut(string outtime, string latitudeOut, string longtitudeOut, byte[] dataimg, int id_sc, int ps, int bk, int interview, int id,int id_ds, string detail_checkin_etc);
    [OperationContract]
    int UpdateDetailEventIn(int event_detail_id, string starttime, byte[] dataimg, int id_sc, string latitudeIn, string longitudeIn);
    [OperationContract]
    int UpdateDetailEventOut(int event_detail_id, string outtime, byte[] dataimg, int id_sc, string latitudeOut, string longitudeOut);

    [OperationContract]
    int UpdateDetailVip(string latitudeIn, string longitudeIn, string statusFind, byte[] dataimg, string id_ccv, string id_scw, int id_dvip);
    [OperationContract]
    int UpdateDetailBoothInXray(string worktime, string latitudeIn, string longtitudeIn, byte[] dataimg, int id_sc, int id_ds, string cancelwork, string detail_checkin_etc);
    [OperationContract]
    int UpdateDetailBoothOutXray(string outtime, string latitudeOut, string longtitudeOut, byte[] dataimg, int id_sc, int ps, int bk, int interview, int id, int id_ds, string detail_checkin_etc);
    [OperationContract]
    int CancelBooth(int id_show, int id_ccw);
    [OperationContract]
    int CancelVip(int id_vip, int id_ccv);
    // TODO: Add your service operations here

    [OperationContract]
    List<StatusConfirm> SelectStatusConfirmWork(int id_scw);
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class User
{
    [DataMember]
    public String Username { get; set; }
    [DataMember]
    public String Password { get; set; }
    [DataMember]
    public int Emp_id { get; set; }
    [DataMember]
    public String EmpName { get; set; }
    [DataMember]
    public String Tel { get; set; }
    [DataMember]
    public int UserType { get; set; }
    [DataMember]
    public String Company { get; set; }
    [DataMember]
    public int Branch { get; set; }
    [DataMember]
    public String NickName { get; set; }
    [DataMember]
    public String Team { get; set; }
    [DataMember]
    public String IOSUser { get; set; }
    [DataMember]
    public int StatusSale { get; set; }
    [DataMember]
    public String User_EditTeam { get; set; }
    [DataMember]
    public DateTime Date_EditTeam { get; set; }
    [DataMember]
    public String ComapanyName { get; set; }
    [DataMember]
    public String ComapanyBranch { get; set; }
}

[DataContract]
public class Booth
{
    [DataMember]
    public String ID { get; set; }
    [DataMember]
    public DateTime ToDate { get; set; }
    [DataMember]
    public int Type { get; set; }
    [DataMember]
    public String Type_Name { get; set; }
    [DataMember]
    public String Place_Name { get; set; }
    [DataMember]
    public int Province { get; set; }
    [DataMember]
    public String PROVINCE_NAME { get; set; }
    [DataMember]
    public int Amphur { get; set; }
    [DataMember]
    public String AMPHUR_NAME { get; set; }
    [DataMember]
    public String District { get; set; }
    [DataMember]
    public String DISTRICT_NAME { get; set; }
    [DataMember]
    public DateTime SetWorkTime { get; set; }
    [DataMember]
    public DateTime SetOutTime { get; set; }
    [DataMember]
    public int ID_CCW { get; set; }
    [DataMember]
    public int ID_SCW { get; set; }
    [DataMember]
    public int ID_Show { get; set; }
    [DataMember]
    public int ID_DS { get; set; }
    [DataMember]
    public int Emp_id { get; set; }
    [DataMember]
    public String EmpName { get; set; }
    [DataMember]
    public String Team { get; set; }
    [DataMember]
    public int branchid { get; set; }
    [DataMember]
    public String companybranchname { get; set; }
    [DataMember]
    public int ID_SC { get; set; }
    [DataMember]
    public String PictureWorkTime { get; set; }
    [DataMember]
    public String PictureOutTime { get; set; }
    [DataMember]
    public String LatitudeIn { get; set; }
    [DataMember]
    public String LatitudeOut { get; set; }
    [DataMember]
    public String LongitudeIn { get; set; }
    [DataMember]
    public String LongitudeOut { get; set; }
    [DataMember]
    public DateTime WorkTime { get; set; }
    [DataMember]
    public DateTime OutTime { get; set; }
    [DataMember]
    public String CancelWork { get; set; }

}

[DataContract]
public class EventCalendar
{
    [DataMember]
    public String Detail_Event_No { get; set; }
    [DataMember]
    public String Event_No { get; set; }
    [DataMember]
    public int Emp_id { get; set; }
    [DataMember]
    public String Event_Place { get; set; }
    [DataMember]
    public DateTime Event_TimeStart { get; set; }
    [DataMember]
    public DateTime Event_TimeEnd { get; set; }
    [DataMember]
    public DateTime TimeStart { get; set; }
    [DataMember]
    public DateTime TimeEnd { get; set; }
    [DataMember]
    public DateTime Event_Date { get; set; }
    [DataMember]
    public String EmpName { get; set; }
    [DataMember]
    public String NickName { get; set; }
    [DataMember]
    public String Tel { get; set; }
    [DataMember]
    public String Team { get; set; }
    [DataMember]
    public String companybranchname { get; set; }
    [DataMember]
    public int ID_SC { get; set; }
    [DataMember]
    public String PictureStart { get; set; }
    [DataMember]
    public String PictureEnd { get; set; }
    [DataMember]
    public String LatitudeIn { get; set; }
    [DataMember]
    public String LongitudeIn { get; set; }
    [DataMember]
    public String LatitudeOut { get; set; }
    [DataMember]
    public String LongitudeOut { get; set; }
    [DataMember]
    public String ID_CCW { get; set; }
}
[DataContract]
public class VisitCustomer
{
    [DataMember]
    public String ID_VIP { get; set; }
    [DataMember]
    public String ID_DVIP { get; set; }
    [DataMember]
    public int Emp_id { get; set; }
    [DataMember]
    public String EmpName { get; set; }
    [DataMember]
    public String Nickname { get; set; }
    [DataMember]
    public String Tel { get; set; }
    [DataMember]
    public String Team { get; set; }
    [DataMember]
    public String companybranchname { get; set; }
    [DataMember]
    public DateTime ToDate { get; set; }
    [DataMember]
    public String CusNo { get; set; }
    [DataMember]
    public String IDCard { get; set; }
    [DataMember]
    public String Name { get; set; }
    [DataMember]
    public String Surname { get; set; }
    [DataMember]
    public String NickName { get; set; }
    [DataMember]
    public String Tel_Mobile1 { get; set; }
    [DataMember]
    public String Address { get; set; }
    [DataMember]
    public String Add_Moo { get; set; }
    [DataMember]
    public String DISTRICT_NAME { get; set; }
    [DataMember]
    public String AMPHUR_NAME { get; set; }
    [DataMember]
    public String PROVINCE_NAME { get; set; }
    [DataMember]
    public String ID_CCV1 { get; set; }
    [DataMember]
    public int MCNumber { get; set; }
    [DataMember]
    public int ID_SCW { get; set; }
    [DataMember]
    public String Status_ConfirmWork { get; set; }
    [DataMember]
    public String PictureHome { get; set; }
    [DataMember]
    public int StatusFind { get; set; }
    [DataMember]
    public String LatitudeIn { get; set; }
    [DataMember]
    public String LongitudeIn { get; set; }
    [DataMember]
    public int UserType { get; set; }
}

[DataContract]
public class StatusConfirm
{
    [DataMember]
    public int ID_SCW { get; set; }
    [DataMember]
    public String Status_ConfirmWork { get; set; }
} 
