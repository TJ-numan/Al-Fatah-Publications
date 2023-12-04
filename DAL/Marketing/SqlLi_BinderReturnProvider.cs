using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BinderReturnProvider:DataAccessObject
{
	public SqlLi_BinderReturnProvider()
    {
    }


    public bool DeleteLi_BinderReturn(int li_BinderReturnID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BinderReturn", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BinderReturnID", SqlDbType.Int).Value = li_BinderReturnID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BinderReturn> GetAllLi_BinderReturns()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BinderReturns", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BinderReturnsFromReader(reader);
        }
    }
    public List<Li_BinderReturn> GetLi_BinderReturnsFromReader(IDataReader reader)
    {
        List<Li_BinderReturn> li_BinderReturns = new List<Li_BinderReturn>();

        while (reader.Read())
        {
            li_BinderReturns.Add(GetLi_BinderReturnFromReader(reader));
        }
        return li_BinderReturns;
    }

    public Li_BinderReturn GetLi_BinderReturnFromReader(IDataReader reader)
    {
        try
        {
            Li_BinderReturn li_BinderReturn = new Li_BinderReturn
                (
                   
                    reader["ReceiveID"].ToString(),
                    reader["BinderID"].ToString(),
                    (DateTime)reader["ReceiveDate"],
                    (decimal)reader["TotalQty"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Statud_D"] 
                );
             return li_BinderReturn;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BinderReturn GetLi_BinderReturnByID(int li_BinderReturnID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BinderReturnByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BinderReturnID", SqlDbType.Int).Value = li_BinderReturnID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BinderReturnFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_BinderReturn(Li_BinderReturn li_BinderReturn)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BinderReturn", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = li_BinderReturn.BinderID;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = li_BinderReturn.ReceiveDate;
            cmd.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = li_BinderReturn.TotalQty;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BinderReturn.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BinderReturn.CreatedBy;
            cmd.Parameters.Add("@Statud_D", SqlDbType.Char).Value = li_BinderReturn.Statud_D;
       
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ReceiveID"].Value.ToString ();
        }
    }

    public bool UpdateLi_BinderReturn(Li_BinderReturn li_BinderReturn)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BinderReturn", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_BinderReturn.ReceiveID;
            cmd.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = li_BinderReturn.BinderID;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = li_BinderReturn.ReceiveDate;
            cmd.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = li_BinderReturn.TotalQty;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BinderReturn.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BinderReturn.CreatedBy;
            cmd.Parameters.Add("@Statud_D", SqlDbType.Char).Value = li_BinderReturn.Statud_D;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
