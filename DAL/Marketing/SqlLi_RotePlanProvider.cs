using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Common;

namespace DAL
{
    public class SqlLi_RotePlanProvider : DataAccessObject
    {
        public SqlLi_RotePlanProvider()
        {
        }


        public bool DeleteLi_RotePlan(int RotePlanID)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_RotePlan", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RotePlanID", SqlDbType.Int).Value = RotePlanID;
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return (result == 1);
            }
        }

        public List<Li_RotePlan> GetAllLi_RotePlans()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_GetAllLi_RotePlans", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

                return GetLi_RotePlansFromReader(reader);
            }
        }
        public List<Li_RotePlan> GetLi_RotePlansFromReader(IDataReader reader)
        {
            List<Li_RotePlan> li_RotePlans = new List<Li_RotePlan>();

            while (reader.Read())
            {
                li_RotePlans.Add(GetLi_RotePlanFromReader(reader));
            }
            return li_RotePlans;
        }

        public Li_RotePlan GetLi_RotePlanFromReader(IDataReader reader)
    {
        try
        {
            Li_RotePlan li_RotePlan = new Li_RotePlan
                (
                 
                    (int)reader["PlanID"],
                    (int)reader["CompanyID"],
                    (int)reader["DemarcationID"],
                    reader["LocationID"].ToString(),
                    reader["MadeBy"].ToString(),
                    reader["VerifiedBy"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                    
                );
             return li_RotePlan;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

        public Li_RotePlan GetLi_RotePlanByID(int RotePlanID)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_GetLi_RotePlanByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@RotePlanID", SqlDbType.Int).Value = RotePlanID;
                connection.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    return GetLi_RotePlanFromReader(reader);
                }
                else
                {
                    return null;
                }
            }
        }

        public int InsertLi_RotePlan(Li_RotePlan li_RotePlan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_RotePlan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = li_RotePlan.CompanyID;
            cmd.Parameters.Add("@DemarcationID", SqlDbType.Int).Value = li_RotePlan.DemarcationID;
            cmd.Parameters.Add("@LocationID", SqlDbType.VarChar).Value = li_RotePlan.LocationID;
            cmd.Parameters.Add("@MadeBy", SqlDbType.VarChar).Value = li_RotePlan.MadeBy;
            cmd.Parameters.Add("@VerifiedBy", SqlDbType.VarChar).Value = li_RotePlan.VerifiedBy;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_RotePlan.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RotePlan.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PlanID"].Value;
        }
    }

        public bool UpdateLi_RotePlan(Li_RotePlan li_RotePlan)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_RotePlan", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = li_RotePlan.@PlanID;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = li_RotePlan.CompanyID;
                cmd.Parameters.Add("@DemarcationID", SqlDbType.Int).Value = li_RotePlan.DemarcationID;
                cmd.Parameters.Add("@LocationID", SqlDbType.VarChar).Value = li_RotePlan.LocationID;
                cmd.Parameters.Add("@MadeBy", SqlDbType.VarChar).Value = li_RotePlan.MadeBy;
                cmd.Parameters.Add("@VerifiedBy", SqlDbType.VarChar).Value = li_RotePlan.VerifiedBy;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_RotePlan.CreatedBy;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RotePlan.CreatedDate;
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result == 1;
            }
        }

        public DataSet getRouteMappings(int ComID, int DemID, string LocationId)
        {
            DataSet ds = new DataSet();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_li_getAllRouteMappings", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Companyid", SqlDbType.Int).Value = ComID;
                cmd.Parameters.Add("@DemID", SqlDbType.Int).Value = DemID;
                cmd.Parameters.Add("@LocationId", SqlDbType. VarChar).Value = LocationId;
                connection.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                sda.Dispose();
                
            return ds;  
            }


        }

    }

}
