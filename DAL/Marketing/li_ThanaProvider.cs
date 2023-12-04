using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class Sql_li_ThanaProvider:DataAccessObject
{
	public Sql_li_ThanaProvider()
    {
    }


    public List<li_Thana> GetAll_Thanas()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAllThanas", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_li_ThanasInfoFromReader(reader);
        }
    }

    public List<li_Thana> Get_ThanaByDistrictID(int DistrictID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ThanaBy_DistrictID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DistrictID", SqlDbType.Int).Value = DistrictID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            return Get_ThanasFromReader(reader);
        }
    }

    public DataTable    GetThanasByDistrictAndTerritory(int districtId , string territoryCode)
    {
       DataTable   dt = new  DataTable ();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetThanaByTerritoryAndDistrict", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DistrictId", SqlDbType. Int).Value = districtId;
             command.Parameters.Add("@TerritoryCode", SqlDbType. VarChar).Value =territoryCode  ;  
 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill( dt);
            myadapter.Dispose();
            connection.Close();
            return dt ;
        }
    }
    public DataSet   GetAll_ThanasInfoWithRelation(string thananame)
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ThanasWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@thanaName", SqlDbType.VarChar).Value = thananame ;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet SMPM_li_GetAll_ThanasWithRelationByThana(string ThanaID)
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ThanasWithRelationBy_DonationDetId", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ThanaId", SqlDbType.VarChar).Value = ThanaID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetOne_ThanasWithRelationByThana(string ThanaID)
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ThanasWithRelationByThana", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ThanaId", SqlDbType.VarChar).Value = ThanaID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public List<li_Thana> Get_li_ThanasInfoFromReader(IDataReader reader)
    {
        List<li_Thana> li_Thanas = new List<li_Thana>();

        while (reader.Read())
        {
            li_Thanas.Add(Get_ThanaInfoFromReader(reader));
        }
        return li_Thanas;
    }

    public li_Thana Get_ThanaInfoFromReader(IDataReader reader)
    {
        try
        {
            li_Thana li_Thana = new li_Thana
                (
                    (int)reader["ThanaID"],
                    reader["ThanaName"].ToString(),
                    (int)reader["DistrictID"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["ModefiedBy"],
                    reader["Thana_Bn"].ToString() 

                );
             return li_Thana;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public li_Thana Get_ThanaByThanaID(int  thanaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ThanaByThanaID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ThanaID", SqlDbType.Int).Value = thanaID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_ThanaInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public List<li_Thana> Get_ThanaByDistrictID(string TerritoryCode, int DistrictID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ThanaBy_DistrictID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TeritoryID", SqlDbType.VarChar).Value = TerritoryCode;
            command.Parameters.Add("@DistrictID", SqlDbType.Int).Value = DistrictID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            return Get_ThanasFromReader(reader);
        }
    }


    public int Insert_Thana(li_Thana li_Thana)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_li_Insert_Thana", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ThanaName", SqlDbType.VarChar).Value = li_Thana.ThanaName;
                cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = li_Thana.DistrictID;
                cmd.Parameters.Add("@AddedAt", SqlDbType.DateTime).Value = li_Thana.CreatedDate;
                cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = li_Thana.CreatedBy;
                cmd.Parameters.Add("@ModifiedAt", SqlDbType.DateTime).Value = li_Thana.CreatedDate;
                cmd.Parameters.Add("@ModefiedBy", SqlDbType.Int).Value = li_Thana.ModefiedBy;
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@ThanaID"].Value;
            }
       

    }

    public bool Update_Thana(li_Thana li_Thana)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_Thana", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = li_Thana.ThanaID;
            cmd.Parameters.Add("@ThanaName", SqlDbType.VarChar).Value = li_Thana.ThanaName;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = li_Thana.DistrictID;      
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Delete_Thana(int thanaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_Thana", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = thanaID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<li_Thana> Get_ThanasFromReader(IDataReader reader)
    {
        List<li_Thana> li_thana = new List<li_Thana>();

        while (reader.Read())
        {
            li_thana.Add(Get_ThanaFromReader(reader));
        }
        return li_thana;
    }

    public li_Thana Get_ThanaFromReader(IDataReader reader)
    {
        try
        {
            li_Thana li_thana = new li_Thana
                (

                    (int)reader["ThanaID"],
                    reader["ThanaName"].ToString()
                );
            return li_thana;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}

