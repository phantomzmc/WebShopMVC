using System;
using System.Collections.Generic;
using System.Data;
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
	string GetData(int value);

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);

    [OperationContract]
    [WebGet(UriTemplate = "Promotions", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<Promotion> GetPromotion(string value);

}


[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
    public DataTable ProductName
    {
        get;
        set;
    }
    
}


[DataContract]
public class Promotion
{
    [DataMember]
    public int PromotionID { get; set; }
    [DataMember]
    public string PromotionName { get; set; }
    [DataMember]
    public string PromotionDiscount { get; set; }
    [DataMember]
    public string PromotionType { get; set; }
}

