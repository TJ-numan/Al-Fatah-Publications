using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PrintReq_LastProvider:DataAccessObject
{
	public SqlLi_PrintReq_LastProvider()
    {
    }


    public bool DeleteLi_PrintReq_Last(int li_PrintReq_LastID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PrintReq_Last", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PrintReq_LastID", SqlDbType.Int).Value = li_PrintReq_LastID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PrintReq_Last> GetAllLi_PrintReq_Lasts()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PrintReq_Lasts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PrintReq_LastsFromReader(reader);
        }
    }
    public List<Li_PrintReq_Last> GetLi_PrintReq_LastsFromReader(IDataReader reader)
    {
        List<Li_PrintReq_Last> li_PrintReq_Lasts = new List<Li_PrintReq_Last>();

        while (reader.Read())
        {
            li_PrintReq_Lasts.Add(GetLi_PrintReq_LastFromReader(reader));
        }
        return li_PrintReq_Lasts;
    }

    public Li_PrintReq_Last GetLi_PrintReq_LastFromReader(IDataReader reader)
    {
        try
        {
            Li_PrintReq_Last li_PrintReq_Last = new Li_PrintReq_Last
                (
                    
                    (int)reader["LastSl"],
                    reader["ReqNo"].ToString(),
                    reader["BookCode"].ToString(),
                    (int)reader["Printed"],
                    (int)reader["Rec_Qty"],
                    (int)reader["Challan"],
                    (int)reader["Specimen"],
                    (int)reader["Rebinding"],
                    (int)reader["Damage"],
                    (int)reader["StockInHand"],
                    (DateTime)reader["StartDate"],
                    (DateTime)reader["EndDate"] 
                );
             return li_PrintReq_Last;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PrintReq_Last GetLi_PrintReq_LastByID(int li_PrintReq_LastID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PrintReq_LastByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PrintReq_LastID", SqlDbType.Int).Value = li_PrintReq_LastID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PrintReq_LastFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PrintReq_Last(Li_PrintReq_Last li_PrintReq_Last)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PrintReq_Last", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@LastSl", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = li_PrintReq_Last.ReqNo;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PrintReq_Last.BookCode;
            cmd.Parameters.Add("@Printed", SqlDbType.Int).Value = li_PrintReq_Last.Printed;
            cmd.Parameters.Add("@Rec_Qty", SqlDbType.Int).Value = li_PrintReq_Last.Rec_Qty;
            cmd.Parameters.Add("@Challan", SqlDbType.Int).Value = li_PrintReq_Last.Challan;
            cmd.Parameters.Add("@Specimen", SqlDbType.Int).Value = li_PrintReq_Last.Specimen;
            cmd.Parameters.Add("@Rebinding", SqlDbType.Int).Value = li_PrintReq_Last.Rebinding;
            cmd.Parameters.Add("@Damage", SqlDbType.Int).Value = li_PrintReq_Last.Damage;
            cmd.Parameters.Add("@StockInHand", SqlDbType.Int).Value = li_PrintReq_Last.StockInHand;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = li_PrintReq_Last.StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = li_PrintReq_Last.EndDate;
  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_PrintReq_Last(Li_PrintReq_Last li_PrintReq_Last)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PrintReq_Last", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@LastSl", SqlDbType.Int).Value = li_PrintReq_Last.LastSl;
            cmd.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = li_PrintReq_Last.ReqNo;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PrintReq_Last.BookCode;
            cmd.Parameters.Add("@Printed", SqlDbType.Int).Value = li_PrintReq_Last.Printed;
            cmd.Parameters.Add("@Rec_Qty", SqlDbType.Int).Value = li_PrintReq_Last.Rec_Qty;
            cmd.Parameters.Add("@Challan", SqlDbType.Int).Value = li_PrintReq_Last.Challan;
            cmd.Parameters.Add("@Specimen", SqlDbType.Int).Value = li_PrintReq_Last.Specimen;
            cmd.Parameters.Add("@Rebinding", SqlDbType.Int).Value = li_PrintReq_Last.Rebinding;
            cmd.Parameters.Add("@Damage", SqlDbType.Int).Value = li_PrintReq_Last.Damage;
            cmd.Parameters.Add("@StockInHand", SqlDbType.Int).Value = li_PrintReq_Last.StockInHand;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = li_PrintReq_Last.StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = li_PrintReq_Last.EndDate;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
