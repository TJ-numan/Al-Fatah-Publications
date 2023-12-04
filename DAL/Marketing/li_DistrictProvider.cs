using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class Sql_li_DistrictProvider : DataAccessObject
{
    public Sql_li_DistrictProvider()
    {
    }


    public List<li_District> GetAll_Districts()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_Districts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_DistrictsInfoFromReader(reader);
        }
    }

    public DataTable GetAll_DistrictsByTerritory(string territoryCode)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetDistrictByTerritory", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TerritoryCode", SqlDbType.VarChar).Value = territoryCode;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill( dt);
            myadapter.Dispose();
            connection.Close();

            return dt;
        }
    }
    public DataSet GetAll_DistrictsWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_DistrictsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<li_District> Get_DistrictsInfoFromReader(IDataReader reader)
    {
        List<li_District> li_Districts = new List<li_District>();

        while (reader.Read())
        {
            li_Districts.Add(Get_DistrictInfoFromReader(reader));
        }
        return li_Districts;
    }

    public li_District Get_DistrictInfoFromReader(IDataReader reader)
    {
        try
        {
            li_District li_District = new li_District
                (

                    (int)reader["DistrictID"],
                    reader["DistrictName"].ToString(),                   
                    (DateTime)reader["CreatedDate"],
                    reader["CreatedBy"].ToString(),
                    reader["ModifiedBy"].ToString(),
                    (DateTime)reader["ModefiedDate"],
                    reader["District_Bn"].ToString()
                );
            return li_District;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public li_District Get_DistrictByDistrictID(int districtID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_DistrictByDistrictID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DistrictID", SqlDbType.Int).Value = districtID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_DistrictInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }






    public int Insert_District(li_District li_District)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_District", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DistrictName", SqlDbType.VarChar).Value = li_District.DistrictName;

            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_District.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_District.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = li_District.ModifiedBy;
            cmd.Parameters.Add("@ModefiedDate", SqlDbType.DateTime).Value = li_District.ModefiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DistrictID"].Value;
        }
    }

    public bool Update_District(li_District li_District)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_District", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = li_District.DistrictID;
            cmd.Parameters.Add("@DistrictName", SqlDbType.VarChar).Value = li_District.DistrictName;
 
            cmd.Parameters.Add("@District_Bn", SqlDbType.VarChar).Value = li_District.District_Bn;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Delete_District(int districtID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_District", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = districtID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<li_District> Get_DistrictByTeritoryID(string TeritoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_DistrictBy_TeritoryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TeritoryID", SqlDbType.VarChar).Value = TeritoryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_DistrictsFromReader(reader);
        }
    }
    public List<li_District> Get_DistrictsFromReader(IDataReader reader)
    {
        List<li_District> li_district = new List<li_District>();

        while (reader.Read())
        {
            li_district.Add(Get_DistrictFromReader(reader));
        }
        return li_district;
    }

    public li_District Get_DistrictFromReader(IDataReader reader)
    {
        try
        {
            li_District li_district = new li_District
                (

                    (int)reader["DistrictID"],
                    reader["DistrictName"].ToString()
                );
            return li_district;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}

