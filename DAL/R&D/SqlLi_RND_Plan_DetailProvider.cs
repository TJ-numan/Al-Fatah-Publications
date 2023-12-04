using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_RND_Plan_DetailProvider:DataAccessObject
{
	public SqlLi_RND_Plan_DetailProvider()
    {
    }


    public bool DeleteLi_RND_Plan_Detail(int li_RND_Plan_DetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_RND_Plan_Detail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_RND_Plan_DetailID", SqlDbType.Int).Value = li_RND_Plan_DetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_RND_Plan_Detail> GetAllLi_RND_Plan_Details()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_RND_Plan_Details", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_RND_Plan_DetailsFromReader(reader);
        }
    }
    public List<Li_RND_Plan_Detail> GetLi_RND_Plan_DetailsFromReader(IDataReader reader)
    {
        List<Li_RND_Plan_Detail> li_RND_Plan_Details = new List<Li_RND_Plan_Detail>();

        while (reader.Read())
        {
            li_RND_Plan_Details.Add(GetLi_RND_Plan_DetailFromReader(reader));
        }
        return li_RND_Plan_Details;
    }

    public Li_RND_Plan_Detail GetLi_RND_Plan_DetailFromReader(IDataReader reader)
    {
        try
        {
            Li_RND_Plan_Detail li_RND_Plan_Detail = new Li_RND_Plan_Detail
                (
                    
                    (int)reader["PlanID"],
                    (int)reader["TaskID"],
                    (DateTime )reader["StartingDate"],
                    (DateTime)reader["EndingDate"],
                    (bool)reader["IsSelect"],
                    (char)reader["Status_D"] 
                );
             return li_RND_Plan_Detail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_RND_Plan_Detail GetLi_RND_Plan_DetailByID(int li_RND_Plan_DetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_RND_Plan_DetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_RND_Plan_DetailID", SqlDbType.Int).Value = li_RND_Plan_DetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_RND_Plan_DetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_RND_Plan_Detail(Li_RND_Plan_Detail li_RND_Plan_Detail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_RND_Plan_Detail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = li_RND_Plan_Detail.PlanID;
            cmd.Parameters.Add("@TaskID", SqlDbType.Int).Value = li_RND_Plan_Detail.TaskID;
            cmd.Parameters.Add("@StartingDate", SqlDbType.Date).Value = li_RND_Plan_Detail.StartingDate;
            cmd.Parameters.Add("@EndingDate", SqlDbType.Date ).Value = li_RND_Plan_Detail.EndingDate;
            cmd.Parameters.Add("@IsSelect", SqlDbType.Bit).Value = li_RND_Plan_Detail.IsSelect;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_RND_Plan_Detail.Status_D;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  1;
        }
    }

    public bool UpdateLi_RND_Plan_Detail(Li_RND_Plan_Detail li_RND_Plan_Detail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_RND_Plan_Detail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = li_RND_Plan_Detail.PlanID;
            cmd.Parameters.Add("@TaskID", SqlDbType.Int).Value = li_RND_Plan_Detail.TaskID;
            cmd.Parameters.Add("@StartingDate", SqlDbType.Date).Value = li_RND_Plan_Detail.StartingDate;
            cmd.Parameters.Add("@EndingDate", SqlDbType.Date).Value = li_RND_Plan_Detail.EndingDate;
            cmd.Parameters.Add("@IsSelect", SqlDbType.Bit).Value = li_RND_Plan_Detail.IsSelect;
            
     
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
