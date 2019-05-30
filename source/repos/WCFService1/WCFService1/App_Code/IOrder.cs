using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Summary description for IOrder
/// </summary>

[ServiceContract]
public interface IOrder
{
    [OperationContract]
    List<Order> GetOrder(int orderid);

    [OperationContract]
    List<Order> GetOrderList();

    [OperationContract]
    List<Order> SearchOrderList(string keyword);

    [OperationContract]
    int AddOrder(int pro_id, int qty, int price, int userid, DateTime ordertime);

    [OperationContract]
    int DeleteOder(int orderid);

}

[DataContract]
public class Order
{
    [DataMember]
    public int OrderID { get; set; }
    [DataMember]
    public string ProductName { get; set; }
    [DataMember]
    public int ProductPrice { get; set; }
    [DataMember]
    public string FirstName { get; set; }
    [DataMember]
    public string LastName { get; set; }
    [DataMember]
    public int OrderQty { get; set; }
    [DataMember]
    public int OrderPrice { get; set; }
    [DataMember]
    public DateTime OrderTime { get; set; }

}