using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Summary description for IUser
/// </summary>

[ServiceContract]
public interface IUser
{
    [OperationContract]
    List<User> GetUserList();
    [OperationContract]
    List<User> GetUser(int userid);
    [OperationContract]
    int AddUser(int userid, string firstname, string lastname, string tel, string username, string email, DateTime brithday, string gender, string numaddress, string tumbun, string amphoe, string city, string country, string postnumber);
    [OperationContract]
    int UpdateUser(int userid, string firstname, string lastname, string tel, string username, string email, DateTime brithday, string gender, string numaddress, string tumbun, string amphoe, string city, string country, string postnumber);
    [OperationContract]
    int DeleteUser(int userid);
}

[DataContract]
public class User
{
    [DataMember]
    public string FirstName { get; set; }
    [DataMember]
    public string LastName { get; set; }
    [DataMember]
    public string Email { get; set; }
    [DataMember]
    public string Tel { get; set; }
    [DataMember]
    public string Gender { get; set; }
    [DataMember]
    public string UserName { get; set; }
    [DataMember]
    public DateTime BrithDay { get; set; }
    [DataMember]
    public string NumAddress { get; set; }
    [DataMember]
    public string Tambon { get; set; }
    [DataMember]
    public string Amphoe { get; set; }
    [DataMember]
    public string City { get; set; }
    [DataMember]
    public string Country { get; set; }
    [DataMember]
    public string PostNumber { get; set; }
    [DataMember]
    public int UserID { get; set; }
}

[DataContract]
public class Address
{
    User users = new User();
    string numAddress, tambon, amphoe, city, country, postnumber;

    [DataMember]
    public string NumAddress { get { return numAddress; } set { numAddress = users.NumAddress; } }
    [DataMember]
    public string Tambon { get { return tambon; } set { tambon = users.Tambon; } }
    [DataMember]
    public string Amphoe { get { return amphoe; } set { amphoe = users.Amphoe; } }
    [DataMember]
    public string City { get { return city; } set { city = users.City; } }
    [DataMember]
    public string Country { get { return country; } set { country = users.Country; } }
    [DataMember]
    public string PostNumber { get { return postnumber; } set { postnumber = users.PostNumber; } }
    [DataMember]
    public int UserID { get; set; }

}