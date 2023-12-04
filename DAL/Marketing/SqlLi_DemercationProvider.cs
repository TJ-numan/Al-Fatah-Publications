using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
    public class SqlLi_DemercationProvider : DataAccessObject
    {
        public SqlLi_DemercationProvider()
        {
        }


        public bool DeleteLi_Demercation(int li_DemercationID)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Demercation", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DemID", SqlDbType.Int).Value = li_DemercationID;
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return (result == 1);
            }
        }

        public List<Li_Demercation> GetAllLi_Demercations()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_GetAllLi_Demercations", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

                return GetLi_DemercationsFromReader(reader);
            }
        }
        public List<Li_Demercation> GetLi_DemercationsFromReader(IDataReader reader)
        {
            List<Li_Demercation> li_Demercations = new List<Li_Demercation>();

            while (reader.Read())
            {
                li_Demercations.Add(GetLi_DemercationFromReader(reader));
            }
            return li_Demercations;
        }

        public Li_Demercation GetLi_DemercationFromReader(IDataReader reader)
    {
        try
        {
            Li_Demercation li_Demercation = new Li_Demercation
                (
                    (int)reader["DemID"],
                    reader["DemName"].ToString() 
                );
             return li_Demercation;
        }
        catch(Exception)
        {
            return null;
        }
    }

        public Li_Demercation GetLi_DemercationByID(int DemID)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("Route_GetLi_DemercationByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@DemID", SqlDbType.Int).Value = DemID;
                connection.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    return GetLi_DemercationFromReader(reader);
                }
                else
                {
                    return null;
                }
            }
        }

        public int InsertLi_Demercation(Li_Demercation li_Demercation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Route_InsertLi_Demercation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DemID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DemName", SqlDbType.VarChar).Value = li_Demercation.DemName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DemID"].Value;
        }
    }

        public bool UpdateLi_Demercation(Li_Demercation li_Demercation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Route_UpdateLi_Demercation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DemID", SqlDbType.Int).Value = li_Demercation.@DemID;
            cmd.Parameters.Add("@DemName", SqlDbType.VarChar).Value = li_Demercation.DemName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    }

}
