using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
    public class SqlLi_CompanyProvider : DataAccessObject
    {
        public SqlLi_CompanyProvider()
        {
        }


        public bool DeleteLi_Company(int CompanyID)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Company", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return (result == 1);
            }
        }

        public List<Li_Company> GetAllLi_Companies()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_GetAllLi_Companies", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

                return GetLi_CompaniesFromReader(reader);
            }
        }
        public List<Li_Company> GetLi_CompaniesFromReader(IDataReader reader)
        {
            List<Li_Company> li_Companies = new List<Li_Company>();

            while (reader.Read())
            {
                li_Companies.Add(GetLi_CompanyFromReader(reader));
            }
            return li_Companies;
        }

        public Li_Company GetLi_CompanyFromReader(IDataReader reader)
        {
            try
            {
                Li_Company li_Company = new Li_Company
                    (
                        (int)reader["CompanyID"],
                        reader["CompanyName"].ToString()
                    );
                return li_Company;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Li_Company GetLi_CompanyByID(int CompanyID)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_GetLi_CompanyByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("CompanyID", SqlDbType.Int).Value = CompanyID;
                connection.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    return GetLi_CompanyFromReader(reader);
                }
                else
                {
                    return null;
                }
            }
        }

        public int InsertLi_Company(Li_Company li_Company)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Company", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = li_Company.CompanyName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["CompanyID"].Value;
        }
    }

        public bool UpdateLi_Company(Li_Company li_Company)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Company", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = li_Company.CompanyID;
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = li_Company.CompanyName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    }

}
