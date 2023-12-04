using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using DAL;

public class SqlLi_PestingProvider:DataAccessObject
{
	public SqlLi_PestingProvider()
    {
    }


    public bool DeleteLi_Pesting(int li_PestingID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Pesting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PestingID", SqlDbType.Int).Value = li_PestingID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Pesting> GetAllLi_Pestings()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Pestings", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PestingsFromReader(reader);
        }
    }
    public List<Li_Pesting> GetLi_PestingsFromReader(IDataReader reader)
    {
        List<Li_Pesting> li_Pestings = new List<Li_Pesting>();

        while (reader.Read())
        {
            li_Pestings.Add(GetLi_PestingFromReader(reader));
        }
        return li_Pestings;
    }

    public Li_Pesting GetLi_PestingFromReader(IDataReader reader)
    {
        try
        {
            Li_Pesting li_Pesting = new Li_Pesting
                (
                   
                    reader["Pest_OrderNo"].ToString(),
                    (DateTime)reader["W_Date"],
                    reader["PartyID"].ToString(),
                    reader["BookID"].ToString(),
                    reader["Edition"].ToString(),
                    reader["BookSizeID"].ToString(),
                    reader["Exam"].ToString(),
                    (int)reader["PageTotal"],
                    (decimal)reader["FormaTotal"],
                    (decimal)reader["Pest_Bill_Forma"],
                    (decimal)reader["Rate"],
                    (decimal)reader["Amount"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"] ,
                    reader["PestingType"].ToString()

                     
                );
             return li_Pesting;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Pesting GetLi_PestingByID(int li_PestingID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PestingByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PestingID", SqlDbType.Int).Value = li_PestingID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PestingFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public  string  InsertLi_Pesting(Li_Pesting li_Pesting)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_Pesting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@Pest_OrderNo", SqlDbType.VarChar).Value  =  li_Pesting.Pest_OrderNo ; 
            cmd.Parameters.Add("@W_Date", SqlDbType.DateTime).Value = li_Pesting.W_Date;
            cmd.Parameters.Add("@PartyID", SqlDbType.VarChar).Value = li_Pesting.PartyID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_Pesting.BookID;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_Pesting.Edition;
            cmd.Parameters.Add("@BookSizeID", SqlDbType.VarChar).Value = li_Pesting.BookSizeID;
            cmd.Parameters.Add("@Exam", SqlDbType.VarChar).Value = li_Pesting.Exam;
            cmd.Parameters.Add("@PageTotal", SqlDbType.Int).Value = li_Pesting.PageTotal;
            cmd.Parameters.Add("@FormaTotal", SqlDbType.Decimal).Value = li_Pesting.FormaTotal;
            cmd.Parameters.Add("@Pest_Bill_Forma", SqlDbType.Decimal).Value = li_Pesting.Pest_Bill_Forma;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = li_Pesting.Rate;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_Pesting.Amount;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Pesting.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Pesting.CreatedBy;

            cmd.Parameters.Add("@PestingType", SqlDbType.VarChar).Value = li_Pesting. PestingType ;
    
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@Pest_OrderNo"].Value.ToString ();
        }
    }

    public bool UpdateLi_Pesting(Li_Pesting li_Pesting)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Pesting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@Pest_OrderNo", SqlDbType.VarChar).Value = li_Pesting.Pest_OrderNo;
            cmd.Parameters.Add("@W_Date", SqlDbType.DateTime).Value = li_Pesting.W_Date;
            cmd.Parameters.Add("@PartyID", SqlDbType.VarChar).Value = li_Pesting.PartyID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_Pesting.BookID;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_Pesting.Edition;
            cmd.Parameters.Add("@BookSizeID", SqlDbType.VarChar).Value = li_Pesting.BookSizeID;
            cmd.Parameters.Add("@Exam", SqlDbType.VarChar).Value = li_Pesting.Exam;
            cmd.Parameters.Add("@PageTotal", SqlDbType.Int).Value = li_Pesting.PageTotal;
            cmd.Parameters.Add("@FormaTotal", SqlDbType.Decimal).Value = li_Pesting.FormaTotal;
            cmd.Parameters.Add("@Pest_Bill_Forma", SqlDbType.Decimal).Value = li_Pesting.Pest_Bill_Forma;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = li_Pesting.Rate;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_Pesting.Amount;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Pesting.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Pesting.CreatedBy;
 
    
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet getPestingOrderInfoByBookID( string BookID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_getPestingOrderInfoByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value =BookID  ;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet getPestingOrderInfoByBookIDEditionOrder(string BookID,string Edition,string OrderNo, char PrintFor)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_getPestingOrderInfoByBookIDEditionOrder", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
            command.Parameters.Add("@Edition", SqlDbType.VarChar).Value = Edition ;
            command.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = OrderNo;
            command.Parameters.Add("@PrintFor", SqlDbType.VarChar ).Value = PrintFor;
          
            
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

}
