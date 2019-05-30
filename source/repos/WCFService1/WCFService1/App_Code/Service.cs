using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService,IProduct
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString);
    Product product;
    Promotion promotion;
    public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

    public List<Product> GetProductList(int id)
    {
        List<Product> productlist = new List<Product>();
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspSelectProduct", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@ProductID", id);

            DataTable ds = new DataTable();
            adapter.Fill(ds);
            sql_com.ExecuteNonQuery();
            foreach (DataRow item in ds.Rows)
            {
                product = new Product()
                {
                    ProductID = Convert.ToInt16(item["ProductID"]),
                    ProductName = item["ProductName"].ToString(),
                    ProductPrice = Convert.ToInt16(item["ProductPrice"]),
                    ProductDetail = item["ProductDatail"].ToString(),
                };
                productlist.Add(product);

            }
        }
        catch (Exception)
        {
            productlist = null;
        }
        finally
        {
            con.Close();
        }
        return productlist;
    }
    public List<Promotion> GetPromotion(string value)
    {
        List<Promotion> promotionlist = new List<Promotion>();
        con.Open();
        
        try
        {
            SqlCommand sql_com = new SqlCommand("uspSearchPromotion", con);
            SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@KeyName", value);

            DataTable ds = new DataTable();
            adapter.Fill(ds);
            sql_com.ExecuteNonQuery();
            foreach (DataRow item in ds.Rows)
            {
                promotion = new Promotion()
                {
                    PromotionID = Convert.ToInt16(item["PromotionID"]),
                    PromotionName = item["PromotionName"].ToString(),
                    PromotionDiscount = item["PromotionDiscount"].ToString(),
                    PromotionType = item["PromotionType"].ToString()
                };
                promotionlist.Add(promotion);

            }
        }
        catch (Exception)
        {
            promotionlist = null;
        }
        finally
        {
            con.Close();
        }
        return promotionlist;
    }


    public int AddProduct(string typename,string typedetail)
    {
        int status = 0;
        con.Open();
        //SqlCommand sql_com = new SqlCommand("Select * from Product", con);
        try
        {
            SqlCommand sql_com = new SqlCommand("uspAddTypeProduct", con);
            SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
            adapter.InsertCommand = sql_com;
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter.InsertCommand.Parameters.AddWithValue("@TypeName", typename);
            adapter.InsertCommand.Parameters.AddWithValue("@TypeDetail", typedetail);
            sql_com.ExecuteNonQuery();
            status = 1;
        }
        catch(Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }

        return status;
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

    


}
