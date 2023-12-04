using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlatePurchaseProvider:DataAccessObject
{
	public SqlLi_PlatePurchaseProvider()
    {
    }


    public bool DeleteLi_PlatePurchase(int li_PlatePurchaseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlatePurchase", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlatePurchaseID", SqlDbType.Int).Value = li_PlatePurchaseID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlatePurchase> GetAllLi_PlatePurchases()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlatePurchases", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlatePurchasesFromReader(reader);
        }
    }
    public List<Li_PlatePurchase> GetLi_PlatePurchasesFromReader(IDataReader reader)
    {
        List<Li_PlatePurchase> li_PlatePurchases = new List<Li_PlatePurchase>();

        while (reader.Read())
        {
            li_PlatePurchases.Add(GetLi_PlatePurchaseFromReader(reader));
        }
        return li_PlatePurchases;
    }

    public Li_PlatePurchase GetLi_PlatePurchaseFromReader(IDataReader reader)
    {
        try
        {
            Li_PlatePurchase li_PlatePurchase = new Li_PlatePurchase
                (
                    
                    reader["Pur_ID"].ToString(),
                    reader["Pur_PartyID"].ToString(),
                    (DateTime)reader["OrderDate"],
                    (int)reader["TotalPlateQty"],
                    (decimal)reader["TotalBill"],
                    reader["ReceiveID"].ToString(),
                    (bool)reader["IsPress"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                );
             return li_PlatePurchase;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlatePurchase GetLi_PlatePurchaseByID(int li_PlatePurchaseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlatePurchaseByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlatePurchaseID", SqlDbType.Int).Value = li_PlatePurchaseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlatePurchaseFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PlatePurchase(Li_PlatePurchase li_PlatePurchase)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlatePurchase", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@Pur_ID", SqlDbType.VarChar,50) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Pur_PartyID", SqlDbType.VarChar).Value = li_PlatePurchase.Pur_PartyID;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_PlatePurchase.OrderDate;
            cmd.Parameters.Add("@TotalPlateQty", SqlDbType.Int).Value = li_PlatePurchase.TotalPlateQty;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PlatePurchase.TotalBill;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_PlatePurchase.ReceiveID;
            cmd.Parameters.Add("@IsPress", SqlDbType.Bit).Value = li_PlatePurchase.IsPress;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlatePurchase.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlatePurchase.CreatedDate;
   
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@Pur_ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PlatePurchase(Li_PlatePurchase li_PlatePurchase)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlatePurchase", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@Pur_ID", SqlDbType.VarChar).Value = li_PlatePurchase.Pur_ID;
            cmd.Parameters.Add("@Pur_PartyID", SqlDbType.VarChar).Value = li_PlatePurchase.Pur_PartyID;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_PlatePurchase.OrderDate;
            cmd.Parameters.Add("@TotalPlateQty", SqlDbType.Int).Value = li_PlatePurchase.TotalPlateQty;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PlatePurchase.TotalBill;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_PlatePurchase.ReceiveID;
            cmd.Parameters.Add("@IsPress", SqlDbType.Bit).Value = li_PlatePurchase.IsPress;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlatePurchase.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlatePurchase.CreatedDate;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
