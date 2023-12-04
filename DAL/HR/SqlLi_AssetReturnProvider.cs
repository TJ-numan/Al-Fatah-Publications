using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_AssetReturnProvider:DataAccessObject
{
	public SqlLi_AssetReturnProvider()
    {
    }


    public bool DeleteLi_AssetReturn(int li_AssetReturnID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_AssetReturn", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AssRelId", SqlDbType.Int).Value = li_AssetReturnID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_AssetReturn> GetAllLi_AssetReturns()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_AssetReturns", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_AssetReturnsFromReader(reader);
        }
    }
    public List<Li_AssetReturn> GetLi_AssetReturnsFromReader(IDataReader reader)
    {
        List<Li_AssetReturn> li_AssetReturns = new List<Li_AssetReturn>();

        while (reader.Read())
        {
            li_AssetReturns.Add(GetLi_AssetReturnFromReader(reader));
        }
        return li_AssetReturns;
    }

    public Li_AssetReturn GetLi_AssetReturnFromReader(IDataReader reader)
    {
        try
        {
            Li_AssetReturn li_AssetReturn = new Li_AssetReturn
                (
                    
                    (int)reader["AssRelId"],
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
             return li_AssetReturn;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_AssetReturn GetLi_AssetReturnByID(int li_AssetReturnID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_AssetReturnByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AssRelId", SqlDbType.Int).Value = li_AssetReturnID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_AssetReturnFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_AssetReturn(Li_AssetReturn li_AssetReturn)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_AssetReturn", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@AssRelId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_AssetReturn.EmpSl;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_AssetReturn.RefNo;
            cmd.Parameters.Add("@AssetId", SqlDbType.Int).Value = li_AssetReturn.AssetId;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_AssetReturn.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AssetReturn.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AssetReturn.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AssetReturn.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AssetReturn.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AssetReturn.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AssRelId"].Value;
        }
    }

    public bool UpdateLi_AssetReturn(Li_AssetReturn li_AssetReturn)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_AssetReturn", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@AssRelId", SqlDbType.Int).Value = li_AssetReturn.AssRelId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_AssetReturn.EmpSl;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_AssetReturn.RefNo;
            cmd.Parameters.Add("@AssetId", SqlDbType.Int).Value = li_AssetReturn.AssetId;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_AssetReturn.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AssetReturn.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AssetReturn.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AssetReturn.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AssetReturn.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AssetReturn.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
