using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_WorkTypeRNDProvider:DataAccessObject
{
	public SqlLi_WorkTypeRNDProvider()
    {
    }


    public bool DeleteLi_WorkTypeRND(int li_WorkTypeRNDID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SmartPublisherManagement_DeleteLi_WorkTypeRND", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_WorkTypeRNDID", SqlDbType.Int).Value = li_WorkTypeRNDID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_WorkTypeRND> GetAllLi_WorkTypeRNDs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_WorkTypeRNDsFromReader(reader);
        }
    }
    public List<Li_WorkTypeRND> GetLi_WorkTypeRNDsFromReader(IDataReader reader)
    {
        List<Li_WorkTypeRND> li_WorkTypeRNDs = new List<Li_WorkTypeRND>();

        while (reader.Read())
        {
            li_WorkTypeRNDs.Add(GetLi_WorkTypeRNDFromReader(reader));
        }
        return li_WorkTypeRNDs;
    }

    public Li_WorkTypeRND GetLi_WorkTypeRNDFromReader(IDataReader reader)
    {
        try
        {
            Li_WorkTypeRND li_WorkTypeRND = new Li_WorkTypeRND
                (
                    
                    (int)reader["WorksTypeID"],
                    reader["WorkType"].ToString(),
                    (int)reader["SectionID"],
                    (bool)reader["IsMeasureInTime"] 
                    
                );
             return li_WorkTypeRND;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_WorkTypeRND GetLi_WorkTypeRNDByID(int li_WorkTypeRNDID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SmartPublisherManagement_GetLi_WorkTypeRNDByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_WorkTypeRNDID", SqlDbType.Int).Value = li_WorkTypeRNDID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_WorkTypeRNDFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_WorkTypeRND(Li_WorkTypeRND li_WorkTypeRND)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SmartPublisherManagement_InsertLi_WorkTypeRND", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_WorkTypeRNDID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@WorksTypeID", SqlDbType.Int).Value = li_WorkTypeRND.WorksTypeID;
            cmd.Parameters.Add("@WorkType", SqlDbType.VarChar).Value = li_WorkTypeRND.WorkType;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_WorkTypeRND.SectionID;
            cmd.Parameters.Add("@IsMeasureInTime", SqlDbType.Bit).Value = li_WorkTypeRND.IsMeasureInTime;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Li_WorkTypeRNDID"].Value;
        }
    }

    public bool UpdateLi_WorkTypeRND(Li_WorkTypeRND li_WorkTypeRND)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SmartPublisherManagement_UpdateLi_WorkTypeRND", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@Li_WorkTypeRNDID", SqlDbType.Int).Value = li_WorkTypeRND.Li_WorkTypeRNDID;
            cmd.Parameters.Add("@WorksTypeID", SqlDbType.Int).Value = li_WorkTypeRND.WorksTypeID;
            cmd.Parameters.Add("@WorkType", SqlDbType.VarChar).Value = li_WorkTypeRND.WorkType;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_WorkTypeRND.SectionID;
            cmd.Parameters.Add("@IsMeasureInTime", SqlDbType.Bit).Value = li_WorkTypeRND.IsMeasureInTime;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
