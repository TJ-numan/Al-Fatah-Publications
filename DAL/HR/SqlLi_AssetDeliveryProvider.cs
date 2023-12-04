using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_AssetDeliveryProvider:DataAccessObject
{
	public SqlLi_AssetDeliveryProvider()
    {
    }


    public bool DeleteLi_AssetDelivery(int li_AssetDeliveryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_AssetDelivery", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AssDelId", SqlDbType.Int).Value = li_AssetDeliveryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_AssetDelivery> GetAllLi_AssetDeliveries()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_AssetDeliveries", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_AssetDeliveriesFromReader(reader);
        }
    }
    public List<Li_AssetDelivery> GetLi_AssetDeliveriesFromReader(IDataReader reader)
    {
        List<Li_AssetDelivery> li_AssetDeliveries = new List<Li_AssetDelivery>();

        while (reader.Read())
        {
            li_AssetDeliveries.Add(GetLi_AssetDeliveryFromReader(reader));
        }
        return li_AssetDeliveries;
    }

    public Li_AssetDelivery GetLi_AssetDeliveryFromReader(IDataReader reader)
    {
        try
        {
            Li_AssetDelivery li_AssetDelivery = new Li_AssetDelivery
                (
                
                    (int)reader["AssDelId"],
                    (int)reader["EmpSl"],
                    reader["RefNo"].ToString(),
                    (int)reader["AssetId"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_AssetDelivery;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_AssetDelivery GetLi_AssetDeliveryByID(int li_AssetDeliveryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_AssetDeliveryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AssDelId", SqlDbType.Int).Value = li_AssetDeliveryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_AssetDeliveryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_AssetDelivery(Li_AssetDelivery li_AssetDelivery)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_AssetDelivery", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@AssDelId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_AssetDelivery.EmpSl;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_AssetDelivery.RefNo;
            cmd.Parameters.Add("@AssetId", SqlDbType.Int).Value = li_AssetDelivery.AssetId;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_AssetDelivery.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AssetDelivery.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AssetDelivery.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AssetDelivery.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AssetDelivery.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AssetDelivery.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AssDelId"].Value;
        }
    }

    public bool UpdateLi_AssetDelivery(Li_AssetDelivery li_AssetDelivery)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_AssetDelivery", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@AssDelId", SqlDbType.Int).Value = li_AssetDelivery.AssDelId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_AssetDelivery.EmpSl;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_AssetDelivery.RefNo;
            cmd.Parameters.Add("@AssetId", SqlDbType.Int).Value = li_AssetDelivery.AssetId;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_AssetDelivery.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AssetDelivery.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AssetDelivery.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AssetDelivery.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AssetDelivery.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AssetDelivery.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
