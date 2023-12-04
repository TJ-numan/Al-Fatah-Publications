using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlateSupplyProvider:DataAccessObject
{
	public SqlLi_PlateSupplyProvider()
    {
    }


    public bool DeleteLi_PlateSupply(int li_PlateSupplyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateSupply", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateSupplyID", SqlDbType.Int).Value = li_PlateSupplyID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateSupply> GetAllLi_PlateSupplies()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateSupplies", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateSuppliesFromReader(reader);
        }
    }
    public List<Li_PlateSupply> GetLi_PlateSuppliesFromReader(IDataReader reader)
    {
        List<Li_PlateSupply> li_PlateSupplies = new List<Li_PlateSupply>();

        while (reader.Read())
        {
            li_PlateSupplies.Add(GetLi_PlateSupplyFromReader(reader));
        }
        return li_PlateSupplies;
    }

    public Li_PlateSupply GetLi_PlateSupplyFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateSupply li_PlateSupply = new Li_PlateSupply
                (
                  
                    (int)reader["Sl"],
                    reader["PrintOrder"].ToString(),
                    reader["PressID"].ToString(),
                    reader["PlateTID"].ToString(),
                    reader["PlateSID"].ToString(),
                    (int)reader["GivenT"],
                    (int)reader["PlateQty"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] ,
                    (decimal)reader["PlateRate"]
                   
                );
             return li_PlateSupply;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateSupply GetLi_PlateSupplyByID(int li_PlateSupplyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateSupplyByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateSupplyID", SqlDbType.Int).Value = li_PlateSupplyID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateSupplyFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PlateSupply(Li_PlateSupply li_PlateSupply)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateSupply", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@Sl", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PrintOrder", SqlDbType.VarChar).Value = li_PlateSupply.PrintOrder;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PlateSupply.PressID;
            cmd.Parameters.Add("@PlateTID", SqlDbType.VarChar).Value = li_PlateSupply.PlateTID;
            cmd.Parameters.Add("@PlateSID", SqlDbType.VarChar).Value = li_PlateSupply.PlateSID;
            cmd.Parameters.Add("@GivenT", SqlDbType.Int).Value = li_PlateSupply.GivenT;
            cmd.Parameters.Add("@PlateQty", SqlDbType.Int).Value = li_PlateSupply.PlateQty;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateSupply.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateSupply.CreatedDate;
            cmd.Parameters.Add("@PlateRate", SqlDbType.Decimal).Value = li_PlateSupply.PlateRate;  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_PlateSupplyID"].Value;
        }
    }

    public bool UpdateLi_PlateSupply(Li_PlateSupply li_PlateSupply)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateSupply", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@Sl", SqlDbType.Int).Value = li_PlateSupply.Sl;
            cmd.Parameters.Add("@PrintOrder", SqlDbType.VarChar).Value = li_PlateSupply.PrintOrder;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PlateSupply.PressID;
            cmd.Parameters.Add("@PlateTID", SqlDbType.VarChar).Value = li_PlateSupply.PlateTID;
            cmd.Parameters.Add("@PlateSID", SqlDbType.VarChar).Value = li_PlateSupply.PlateSID;
            cmd.Parameters.Add("@GivenT", SqlDbType.Int).Value = li_PlateSupply.GivenT;
            cmd.Parameters.Add("@PlateQty", SqlDbType.Int).Value = li_PlateSupply.PlateQty;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateSupply.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateSupply.CreatedDate;
            cmd.Parameters.Add("@PlateRate", SqlDbType.Decimal).Value = li_PlateSupply.PlateRate;  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
