using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class Sql_li_AreaProvider:DataAccessObject
{
	public Sql_li_AreaProvider()
    {
    }


    public List<li_Area> GetAll_Areas()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_Areas", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_AreasFromReader(reader);
        }
    }

    public DataSet   GetAll_AreasWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_AreasWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<li_Area> Get_AreasFromReader(IDataReader reader)
    {
        List<li_Area> li_Areas = new List<li_Area>();

        while (reader.Read())
        {
            li_Areas.Add(Get_AreaFromReader(reader));
        }
        return li_Areas;
    }

    public li_Area Get_AreaFromReader(IDataReader reader)
    {
        try
        {
            li_Area li_Area = new li_Area
                (

                    (int)reader["AreaID"],
                    reader["AreaName"].ToString()
                );
             return li_Area;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public li_Area Get_AreaByAreaID(int  areaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_AreaByAreaID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AreaID", SqlDbType.Int).Value = areaID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_AreaFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }
    public List<li_Area> Get_AreaByRegionID(int regionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_AreaByRegionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RegionID", SqlDbType.Int).Value = regionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_AreasFromReader(reader);
        }
    }

    public int Insert_Area(li_Area li_Area)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_Area", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AreaID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AreaName", SqlDbType.VarChar).Value = li_Area.AreaName;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = li_Area.RegionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AreaID"].Value;
        }
    }

    public bool Update_Area(li_Area li_Area)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_Area", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AreaID", SqlDbType.Int).Value = li_Area.AreaID;
            cmd.Parameters.Add("@AreaName", SqlDbType.VarChar).Value = li_Area.AreaName;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = li_Area.RegionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Delete_Area(int areaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_Area", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AreaID", SqlDbType.Int).Value = areaID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

