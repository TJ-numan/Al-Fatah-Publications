using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_PayHeadProvider:DataAccessObject
{
	public SqlLi_PayHeadProvider()
    {
    }


    public bool DeleteLi_PayHead(int li_PayHeadID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PayHead", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaHId", SqlDbType.Int).Value = li_PayHeadID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PayHead> GetAllLi_PayHeads()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PayHeads", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PayHeadsFromReader(reader);
        }
    }
    public List<Li_PayHead> GetLi_PayHeadsFromReader(IDataReader reader)
    {
        List<Li_PayHead> li_PayHeads = new List<Li_PayHead>();

        while (reader.Read())
        {
            li_PayHeads.Add(GetLi_PayHeadFromReader(reader));
        }
        return li_PayHeads;
    }

    public Li_PayHead GetLi_PayHeadFromReader(IDataReader reader)
    {
        try
        {
            Li_PayHead li_PayHead = new Li_PayHead
                (
                  
                    (int)reader["PaHId"],
                    reader["PaHName"].ToString(),
                    (bool)reader["IsExcluedGross"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_PayHead;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PayHead GetLi_PayHeadByID(int li_PayHeadID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PayHeadByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PaHId", SqlDbType.Int).Value = li_PayHeadID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PayHeadFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PayHead(Li_PayHead li_PayHead)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PayHead", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@PaHId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PaHName", SqlDbType.VarChar).Value = li_PayHead.PaHName;
            cmd.Parameters.Add("@IsExcluedGross", SqlDbType.Bit).Value = li_PayHead.IsExcluedGross;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PayHead.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PayHead.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PayHead.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PayHead.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PayHead.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PaHId"].Value;
        }
    }

    public bool UpdateLi_PayHead(Li_PayHead li_PayHead)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PayHead", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@PaHId", SqlDbType.Int).Value = li_PayHead.PaHId;
            cmd.Parameters.Add("@PaHName", SqlDbType.VarChar).Value = li_PayHead.PaHName;
            cmd.Parameters.Add("@IsExcluedGross", SqlDbType.Bit).Value = li_PayHead.IsExcluedGross; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PayHead.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PayHead.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PayHead.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
