using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

/// <summary>
/// Summary description for IProduct
/// </summary>
/// 
[ServiceContract]
public interface IProduct
{
    [OperationContract]
    [WebGet(UriTemplate = "Products", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    List<Product> GetProductList(int id);

    [OperationContract]
    int AddProduct(string typename, string typedetail);
}
    [DataContract]
    public class Product
    {
        [DataMember]

        public string ProductName
        {
            get;
            set;
        }
        [DataMember]
        public string ProductDetail
        {
            get;
            set;
        }
        [DataMember]
        public int ProductPrice
        {
            get;
            set;
        }
        [DataMember]
        public int ProductID
        {
            get;
            set;
        }
    }
