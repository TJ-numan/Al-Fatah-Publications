using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
    public class SqlLi_RoutePlanDetailsProvider : DataAccessObject
    {
        public SqlLi_RoutePlanDetailsProvider()
        {
        }


        public bool DeleteLi_RoutePlanDetails(int li_RoutePlanDetailsID)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_RoutePlanDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Li_RoutePlanDetailsID", SqlDbType.Int).Value = li_RoutePlanDetailsID;
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return (result == 1);
            }
        }

        public List<Li_RoutePlanDetails> GetAllLi_RoutePlanDetailss()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_GetAllLi_RoutePlanDetailss", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

                return GetLi_RoutePlanDetailssFromReader(reader);
            }
        }
        public List<Li_RoutePlanDetails> GetLi_RoutePlanDetailssFromReader(IDataReader reader)
        {
            List<Li_RoutePlanDetails> li_RoutePlanDetailss = new List<Li_RoutePlanDetails>();

            while (reader.Read())
            {
                li_RoutePlanDetailss.Add(GetLi_RoutePlanDetailsFromReader(reader));
            }
            return li_RoutePlanDetailss;
        }

        public Li_RoutePlanDetails GetLi_RoutePlanDetailsFromReader(IDataReader reader)
    {
        try
        {
            Li_RoutePlanDetails li_RoutePlanDetails = new Li_RoutePlanDetails
                (             
                    (int)reader["RouteID"],
                    (int)reader["PlanID"],
                    reader["RouteName"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (bool)reader["IsActive"]
                    
                );
             return li_RoutePlanDetails;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

        public Li_RoutePlanDetails GetLi_RoutePlanDetailsByID(int li_RoutePlanDetailsID)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_GetLi_RoutePlanDetailsByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Li_RoutePlanDetailsID", SqlDbType.Int).Value = li_RoutePlanDetailsID;
                connection.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    return GetLi_RoutePlanDetailsFromReader(reader);
                }
                else
                {
                    return null;
                }
            }
        }

        public int InsertLi_RoutePlanDetails(Li_RoutePlanDetails li_RoutePlanDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_RoutePlanDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RouteID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = li_RoutePlanDetails.PlanID;
            cmd.Parameters.Add("@RouteName", SqlDbType.VarChar).Value = li_RoutePlanDetails.RouteName;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RoutePlanDetails.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RoutePlanDetails.CreatedBy;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = li_RoutePlanDetails.IsActive;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RouteID"].Value;
        }
    }

        public bool UpdateLi_RoutePlanDetails(Li_RoutePlanDetails li_RoutePlanDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_RoutePlanDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@Li_RoutePlanDetailsID", SqlDbType.Int).Value = li_RoutePlanDetails.Li_RoutePlanDetailsID;
            cmd.Parameters.Add("@RouteID", SqlDbType.Int).Value = li_RoutePlanDetails.RouteID;
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = li_RoutePlanDetails.PlanID;
            cmd.Parameters.Add("@RouteName", SqlDbType.VarChar).Value = li_RoutePlanDetails.RouteName;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RoutePlanDetails.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RoutePlanDetails.CreatedBy;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = li_RoutePlanDetails.IsActive;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    }

}
