using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class Sql_li_RegionProvider:DataAccessObject
{
	public Sql_li_RegionProvider()
    {
    }


    public List<li_Region> GetAll_Regions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_Regions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_RegionsFromReader(reader);
        }
    }
    public List<li_Region> GetComboSourceData_Regions(int UserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetDemarcationByUser", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@userID",SqlDbType.Int).Value = UserID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_RegionsFromReader(reader);
        }
    }
    public List<li_Region> Get_RegionsFromReader(IDataReader reader)
    {
        List<li_Region> li_Regions = new List<li_Region>();

        while (reader.Read())
        {

            li_Region li_Region = new li_Region
               (
                    (int)reader["RegionID"],
                    reader["RegionName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    reader["Region_Bn"].ToString()
               );

            li_Regions.Add(li_Region);
           
        }
        return li_Regions;
    }

    public li_Region Get_RegionFromReader(IDataReader reader)
    {
        try
        {


            li_Region li_Region = new li_Region
               (
                    (int)reader["RegionID"],
                    reader["RegionName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    reader["Region_Bn"].ToString() 
               );
             return li_Region;
        }
        catch(Exception  )
        {
            return null;
        }
    }

    public li_Region Get_RegionByRegionID(int  regionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_RegionByRegionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RegionID", SqlDbType.Int).Value = regionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_RegionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int Insert_Region(li_Region li_Region)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_Insertli_Region", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RegionName", SqlDbType.VarChar).Value = li_Region.RegionName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Region.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Region.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Region.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Region.ModifiedDate;
            cmd.Parameters.Add("@Region_Bn", SqlDbType.Text).Value = li_Region.Region_Bn;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RegionID"].Value;
        }
    }

    public bool Update_Region(li_Region li_Region)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_Region", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = li_Region.RegionID;
            cmd.Parameters.Add("@RegionName", SqlDbType.VarChar).Value = li_Region.RegionName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Region.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Region.ModifiedDate;
            cmd.Parameters.Add("@Region_Bn", SqlDbType.Text).Value = li_Region.Region_Bn;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Delete_Region(int regionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_Region", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = regionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet GetRegionByUser(int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("web_SMPM_li_GetDemarcationByUser", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@userID", SqlDbType.Int).Value = UserID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetRegion()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_AllRegions", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetRegionbyId(string regionID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_AllRegionsById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RegionID", SqlDbType.Int).Value = regionID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetRegionbyRegionMainId(string regionMainID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_RegionByRegionMainID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RegionMainID", SqlDbType.Int).Value = regionMainID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet Getddl_Region()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetComboSourceData_Regions", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            connection.Close();
            return ds;
        }
    }
    public List<li_Region> Get_AllRegion()
    {
        List<li_Region> li_Regions = new List<li_Region>();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_Regions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                li_Region aRegionInformation = new li_Region();
                aRegionInformation.RegionName = (string)reader["RegionName"];
                aRegionInformation.RegionID = (int)reader["RegionID"];
                li_Regions.Add(aRegionInformation);
            }
        }
        return li_Regions;
    }
}

