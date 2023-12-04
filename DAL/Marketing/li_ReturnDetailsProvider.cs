using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class Sql_li_ReturnDetailsProvider:DataAccessObject
{
	public Sql_li_ReturnDetailsProvider()
    {
    }


    public List<li_ReturnDetails> GetAll_ReturnDetailss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ReturnDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_ReturnDetailssFromReader(reader);
        }
    }

    public DataSet   GetAll_ReturnDetailssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ReturnDetailssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<li_ReturnDetails> Get_ReturnDetailssFromReader(IDataReader reader)
    {
        List<li_ReturnDetails> li_ReturnDetailss = new List<li_ReturnDetails>();

        while (reader.Read())
        {
            li_ReturnDetailss.Add(Get_ReturnDetailsFromReader(reader));
        }
        return li_ReturnDetailss;
    }

    public li_ReturnDetails Get_ReturnDetailsFromReader(IDataReader reader)
    {
        try
        {
            li_ReturnDetails li_ReturnDetails = new li_ReturnDetails
                (

                    (int)reader["ReturnDetailsID"],
                  
                     reader["BookAcCode"].ToString(),
                    (string )reader["ReturnID"],
                    (int)reader["Qty"],
                    (decimal)reader["UnitPrice"],
                    (decimal)reader["TotalPrice"],
                 
                    (decimal)reader["DamageQuentity"],
                    (int)reader["SpecimenQty"],
                    (decimal)reader["discountPercentage"],
                      reader["Edition"].ToString() 
                );
             return li_ReturnDetails;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public li_ReturnDetails Get_ReturnDetailsByReturnDetailsID(int  returnDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ReturnDetailsByReturnDetailsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReturnDetailsID", SqlDbType.Int).Value = returnDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_ReturnDetailsFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int Insert_ReturnDetails(li_ReturnDetails li_ReturnDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_ReturnDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReturnDetailsID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value =  li_ReturnDetails.BookAcCode;
            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar).Value = li_ReturnDetails.ReturnID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_ReturnDetails.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = li_ReturnDetails.UnitPrice;
            cmd.Parameters.Add("@TotalPrice", SqlDbType.Money).Value = li_ReturnDetails.TotalPrice;
            cmd.Parameters.Add("@damageqty", SqlDbType.Money).Value = li_ReturnDetails.DamageQuentity;
            cmd.Parameters.Add("@Specimen", SqlDbType.Int).Value = li_ReturnDetails.SpecimenQty ;
            cmd.Parameters.Add("@DiscountPercentage", SqlDbType.Int).Value = li_ReturnDetails.DiscountPercentage;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_ReturnDetails.Edition;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ReturnDetailsID"].Value;
        }
    }

    public bool Update_ReturnDetails(li_ReturnDetails li_ReturnDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_ReturnDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReturnDetailsID", SqlDbType.Int).Value = li_ReturnDetails.ReturnDetailsID;

            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar).Value = li_ReturnDetails.ReturnID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_ReturnDetails.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = li_ReturnDetails.UnitPrice;
            cmd.Parameters.Add("@damageqty", SqlDbType.Money).Value = li_ReturnDetails.DamageQuentity;
            cmd.Parameters.Add("@Specimen", SqlDbType.Int).Value = li_ReturnDetails.Qty;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Delete_ReturnDetails(int returnDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_ReturnDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReturnDetailsID", SqlDbType.Int).Value = returnDetailsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

