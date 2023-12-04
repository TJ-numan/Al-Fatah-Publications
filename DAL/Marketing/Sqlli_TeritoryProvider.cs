using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_TeritoryProvider:DataAccessObject
{
	public SqlLi_TeritoryProvider()
    {
    }


    public bool DeleteLi_Teritory(int li_TeritoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Teritory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_TeritoryID", SqlDbType.Int).Value = li_TeritoryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Teritory> GetAllLi_Teritories(string   ZonID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Teritories", connection);//SMPM_GetAllLi_Teritories_Modified
            command.CommandType = CommandType.StoredProcedure;
            command .Parameters.Add("@ZonID", SqlDbType.VarChar).Value =  ZonID ;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TeritoriesFromReader(reader);
        }
    }
    public List<Li_Teritory> GetLi_TeritoriesFromReader(IDataReader reader)
    {
        List<Li_Teritory> li_Teritories = new List<Li_Teritory>();

        while (reader.Read())
        {
            li_Teritories.Add(GetLi_TeritoryFromReader(reader));
        }
        return li_Teritories;
    }

    public Li_Teritory GetLi_TeritoryFromReader(IDataReader reader)
    {
        try
        {
            Li_Teritory li_Teritory = new Li_Teritory
                (
                    (int)reader["TeritoryID"],
                    reader["TeritoryCode"].ToString(),
                    reader["TeritoryName"].ToString(),
                    (int)reader["ZonID"],                   
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"] ,
                    reader["Territory_Bn"].ToString() ,
                               reader["ZonName"].ToString() 
                );
             return li_Teritory;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Teritory GetLi_TeritoryByID(string TeritoryCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_TeritoryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TeritoryCode", SqlDbType.VarChar).Value = TeritoryCode;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            if (reader.Read())
            {
                return GetLi_TeritoryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Teritory(Li_Teritory li_Teritory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Teritory", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@TeritoryID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TeritoryCode", SqlDbType.VarChar).Value = li_Teritory.TeritoryCode;
            cmd.Parameters.Add("@TeritoryName", SqlDbType.VarChar).Value = li_Teritory.TeritoryName;
            cmd.Parameters.Add("@AreaID", SqlDbType.Int).Value = li_Teritory.ZonID;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Teritory.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Teritory.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Teritory.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Teritory.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)1;//cmd.Parameters["@Li_TeritoryID"].Value;
        }
    }

    public bool UpdateLi_Teritory(Li_Teritory li_Teritory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Teritory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@TeritoryID", SqlDbType.VarChar).Value = li_Teritory. TeritoryCode;
            cmd.Parameters.Add("@TeritoryName", SqlDbType.VarChar).Value = li_Teritory.TeritoryName;
            cmd.Parameters.Add("@Territory_Bn", SqlDbType.VarChar).Value = li_Teritory. Territory_Bn ;
            cmd.Parameters.Add("@ZonID", SqlDbType.Int).Value = li_Teritory.ZonID;
             
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public List<Li_Teritory> Get_TeritoryByZonID(int areaid)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_TeritoriesBy_ZonID", connection);
            command.Parameters.Add("@ZonID", SqlDbType.Int).Value = areaid;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TeritoriesFromReader(reader);
        }
    }


    public DataSet GetAll_TeritoriesWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_TeritoriesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }





    public DataSet GetAllLi_TeritoryByUserID(int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("web_SMPM_GetLi_Teritory_ByUserID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetAll_TeritoriesWithTeritoryId(string TeritoryId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_TeritoriesById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TeritoryID", SqlDbType.VarChar).Value = TeritoryId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetAllLi_Teritories()
    {
       DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_TeritoriesList", connection);
            command.CommandType= CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            adapter.Dispose();
            connection.Close();
            return ds;
        }
    }

    public DataSet GetAllLi_MadrashaByTeritory(string TeritoryCode)
    {
       DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_Madrasha_ListByTeritoryCode", connection);
            command.CommandType= CommandType.StoredProcedure;

            command.Parameters.Add("@TeritoryCode", SqlDbType.VarChar).Value = TeritoryCode;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            adapter.Dispose();
            connection.Close();
            return ds;
        }
    }


}
