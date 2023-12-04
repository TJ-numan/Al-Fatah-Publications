using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ScriptBookProvider:DataAccessObject
{
	public SqlLi_ScriptBookProvider()
    {
    }


    public bool DeleteLi_ScriptBook(int li_ScriptBookID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_ScriptBook", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ScriptBookID", SqlDbType.Int).Value = li_ScriptBookID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ScriptBook> GetAllLi_ScriptBooks()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ScriptBooks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ScriptBooksFromReader(reader);
        }
    }
    public List<Li_ScriptBook> GetLi_ScriptBooksFromReader(IDataReader reader)
    {
        List<Li_ScriptBook> li_ScriptBooks = new List<Li_ScriptBook>();

        while (reader.Read())
        {
            li_ScriptBooks.Add(GetLi_ScriptBookFromReader(reader));
        }
        return li_ScriptBooks;
    }

    public Li_ScriptBook GetLi_ScriptBookFromReader(IDataReader reader)
    {
        try
        {
            Li_ScriptBook li_ScriptBook = new Li_ScriptBook
                (
                   
                    reader["BookCode"].ToString(),
                    reader["Edition"].ToString(),
                    (decimal)reader["App_Forma"],
                    (decimal)reader["Tot_Unit"],
                    reader["SizeID"].ToString(),
                    (DateTime)reader["Pos_Date"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Status_D"] 
                );
             return li_ScriptBook;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public Li_ScriptBook GetLi_ScriptBookByID(int li_ScriptBookID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ScriptBookByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ScriptBookID", SqlDbType.Int).Value = li_ScriptBookID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ScriptBookFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ScriptBook(Li_ScriptBook li_ScriptBook)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_ScriptBook", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Direction  = ParameterDirection.Output ;      
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_ScriptBook.BookCode;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_ScriptBook.Edition;
            cmd.Parameters.Add("@App_Forma", SqlDbType.Decimal).Value = li_ScriptBook.App_Forma;
            cmd.Parameters.Add("@Tot_Unit", SqlDbType.Decimal).Value = li_ScriptBook.Tot_Unit;
            cmd.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = li_ScriptBook.SizeID;
            cmd.Parameters.Add("@Pos_Date", SqlDbType.DateTime).Value = li_ScriptBook.Pos_Date;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ScriptBook.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ScriptBook.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_ScriptBook.Status_D;
       
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SerialNo"].Value;
        }
    }

    public bool UpdateLi_ScriptBook(Li_ScriptBook li_ScriptBook)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_ScriptBook", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_ScriptBook.BookCode;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_ScriptBook.Edition;
            cmd.Parameters.Add("@App_Forma", SqlDbType.Decimal).Value = li_ScriptBook.App_Forma;
            cmd.Parameters.Add("@Tot_Unit", SqlDbType.Decimal).Value = li_ScriptBook.Tot_Unit;
            cmd.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = li_ScriptBook.SizeID;
            cmd.Parameters.Add("@Pos_Date", SqlDbType.DateTime).Value = li_ScriptBook.Pos_Date;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ScriptBook.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ScriptBook.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_ScriptBook.Status_D;
       
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
