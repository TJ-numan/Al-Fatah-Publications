using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookGroupProvider:DataAccessObject
{
	public SqlLi_BookGroupProvider()
    {
    }


    public bool DeleteLi_BookGroup(int li_BookGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookGroupID", SqlDbType.Int).Value = li_BookGroupID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookGroup> GetAllLi_BookGroups()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookGroups", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookGroupsFromReader(reader);
        }
    }
    public List<Li_BookGroup> GetLi_BookGroupsFromReader(IDataReader reader)
    {
        List<Li_BookGroup> li_BookGroups = new List<Li_BookGroup>();

        while (reader.Read())
        {
            li_BookGroups.Add(GetLi_BookGroupFromReader(reader));
        }
        return li_BookGroups;
    }

    public Li_BookGroup GetLi_BookGroupFromReader(IDataReader reader)
    {
        try
        {
            Li_BookGroup li_BookGroup = new Li_BookGroup
                (
                     
                    reader["MainItem"].ToString() 
                   
                );
             return li_BookGroup;
        }
        catch(Exception)
        {
            return null;
        }
    }

    public DataSet  GetLi_BookGroupByID(string  MainItem ,bool IsCentralStore)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            DataSet ds = new DataSet();
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookGroupByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MainItem", SqlDbType.VarChar).Value = MainItem;
            command.Parameters.Add("@IsCentralStore", SqlDbType.Bit).Value = IsCentralStore;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

           return ds;
        }
    }

    public int InsertLi_BookGroup(Li_BookGroup li_BookGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@MainItem", SqlDbType.VarChar).Value = li_BookGroup.MainItem;
            cmd.Parameters.Add("@SubItem", SqlDbType.VarChar).Value = li_BookGroup.SubItem;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_BookGroup.Status_D;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookGroup.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookGroup.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_BookGroup.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_BookGroup.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1; //(int)cmd.Parameters["@Li_BookGroupID"].Value;
        }
    }

    public bool UpdateLi_BookGroup(Li_BookGroup li_BookGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@MainItem", SqlDbType.VarChar).Value = li_BookGroup.MainItem;
            cmd.Parameters.Add("@SubItem", SqlDbType.VarChar).Value = li_BookGroup.SubItem;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_BookGroup.Status_D;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookGroup.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookGroup.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_BookGroup.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_BookGroup.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
