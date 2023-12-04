using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookReplacementProvider:DataAccessObject
{
	public SqlLi_BookReplacementProvider()
    {
    }


    public bool DeleteLi_BookReplacement(int li_BookReplacementID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookReplacement", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookReplacementID", SqlDbType.Int).Value = li_BookReplacementID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookReplacement> GetAllLi_BookReplacements()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookReplacements", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookReplacementsFromReader(reader);
        }
    }
    public List<Li_BookReplacement> GetLi_BookReplacementsFromReader(IDataReader reader)
    {
        List<Li_BookReplacement> li_BookReplacements = new List<Li_BookReplacement>();

        while (reader.Read())
        {
            li_BookReplacements.Add(GetLi_BookReplacementFromReader(reader));
        }
        return li_BookReplacements;
    }

    public Li_BookReplacement GetLi_BookReplacementFromReader(IDataReader reader)
    {
        try
        {
            Li_BookReplacement li_BookReplacement = new Li_BookReplacement
                (
                     
                    reader["ID"].ToString(),
                    (int)reader["MemoNo"],
                    reader["LibraryID"].ToString(),
                    (decimal)reader["AmountTotal"],
                    (int)reader["Createdby"],
                    (DateTime)reader["TransferDate"],
                    (DateTime)reader["CreatedDate"],
                    (char)reader["Status_D"],
                    reader["Delete_Cause"].ToString(),
                    (int)reader["DeleteBy"],
                    (DateTime)reader["DateOfDelete"] 
                );
             return li_BookReplacement;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookReplacement GetLi_BookReplacementByID(int li_BookReplacementID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookReplacementByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookReplacementID", SqlDbType.Int).Value = li_BookReplacementID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookReplacementFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_BookReplacement(Li_BookReplacement li_BookReplacement)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookReplacement", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50).Direction  = ParameterDirection .Output ;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_BookReplacement.MemoNo;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_BookReplacement.LibraryID;
            cmd.Parameters.Add("@AmountTotal", SqlDbType.Decimal).Value = li_BookReplacement.AmountTotal;
            cmd.Parameters.Add("@Createdby", SqlDbType.Int).Value = li_BookReplacement.Createdby;
            cmd.Parameters.Add("@TransferDate", SqlDbType.DateTime).Value = li_BookReplacement.TransferDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookReplacement.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_BookReplacement.Status_D;
            //cmd.Parameters.Add("@Delete_Cause", SqlDbType.VarChar).Value = DBNull .Value;
            //cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value =  DBNull .Value ;
            //cmd.Parameters.Add("@DateOfDelete", SqlDbType.DateTime).Value = DBNull .Value ;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_BookReplacement(Li_BookReplacement li_BookReplacement)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookReplacement", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_BookReplacement.ID;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_BookReplacement.MemoNo;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_BookReplacement.LibraryID;
            cmd.Parameters.Add("@AmountTotal", SqlDbType.Decimal).Value = li_BookReplacement.AmountTotal;
            cmd.Parameters.Add("@Createdby", SqlDbType.Int).Value = li_BookReplacement.Createdby;
            cmd.Parameters.Add("@TransferDate", SqlDbType.DateTime).Value = li_BookReplacement.TransferDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookReplacement.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_BookReplacement.Status_D;
            cmd.Parameters.Add("@Delete_Cause", SqlDbType.VarChar).Value = li_BookReplacement.Delete_Cause;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = li_BookReplacement.DeleteBy;
            cmd.Parameters.Add("@DateOfDelete", SqlDbType.DateTime).Value = li_BookReplacement.DateOfDelete;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
