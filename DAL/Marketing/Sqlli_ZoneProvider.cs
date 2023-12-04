using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ZoneProvider:DataAccessObject
{
	public SqlLi_ZoneProvider()
    {
    }


    public bool DeleteLi_Zone(int li_ZoneID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Zone", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ZoneID", SqlDbType.Int).Value = li_ZoneID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Zone> GetAllLi_Zones()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Zones", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ZonesFromReader(reader);
        }
    }
    public List<Li_Zone> GetLi_ZonesFromReader(IDataReader reader)
    {
        List<Li_Zone> li_Zones = new List<Li_Zone>();

        while (reader.Read())
        {
            li_Zones.Add(GetLi_ZoneFromReader(reader));
        }
        return li_Zones;
    }

    public Li_Zone GetLi_ZoneFromReader(IDataReader reader)
    {
        try
        {
            Li_Zone li_Zone = new Li_Zone
                (
                     
                    (int)reader["ZonID"],
                    reader["ZonName"].ToString(),
                    (int)reader["DivID"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    reader["Zon_Bn"].ToString() ,
                      reader["DivName"].ToString() 
                );
             return li_Zone;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public List< Li_Zone >GetLi_ZoneByID(int li_ZoneID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ZoneByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DivID", SqlDbType.Int).Value = li_ZoneID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
 
            return GetLi_ZonesFromReader(reader);
        }
    }

    public int InsertLi_Zone(Li_Zone li_Zone)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Zone", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@ZonID", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ZonName", SqlDbType.VarChar).Value = li_Zone.ZonName;
            cmd.Parameters.Add("@DivID", SqlDbType.Int).Value = li_Zone.DivID;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Zone.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Zone.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Zone.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Zone.ModifiedDate;
            cmd.Parameters.Add("@Zon_Bn", SqlDbType.Text).Value = li_Zone.Zon_Bn;
             
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ZonID"].Value;
        }
    }

    public bool UpdateLi_Zone(Li_Zone li_Zone)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Zone", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ZonID", SqlDbType.Int).Value = li_Zone.ZonID;
            cmd.Parameters.Add("@ZonName", SqlDbType.VarChar).Value = li_Zone.ZonName;
            cmd.Parameters.Add("@DivID", SqlDbType.Int).Value = li_Zone.DivID;

            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Zone.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Zone.ModifiedDate;
            cmd.Parameters.Add("@Zon_Bn", SqlDbType.Text).Value = li_Zone.Zon_Bn;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet GetAll_ZoneWithZoneId(string ZonId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ZonesById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ZonID", SqlDbType.VarChar).Value = ZonId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }



}
