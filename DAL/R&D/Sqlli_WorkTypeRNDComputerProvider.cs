using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_WorkTypeRNDComputerProvider:DataAccessObject
{
	public SqlLi_WorkTypeRNDComputerProvider()
    {
    }


    public bool DeleteLi_WorkTypeRNDComputer(int li_WorkTypeRNDComputerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SmartPublisherManagement_DeleteLi_WorkTypeRNDComputer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_WorkTypeRNDComputerID", SqlDbType.Int).Value = li_WorkTypeRNDComputerID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_WorkTypeRNDComputer> GetAllLi_WorkTypeRNDComputers()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SmartPublisherManagement_GetAllLi_WorkTypeRNDComputers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_WorkTypeRNDComputersFromReader(reader);
        }
    }
    public List<Li_WorkTypeRNDComputer> GetLi_WorkTypeRNDComputersFromReader(IDataReader reader)
    {
        List<Li_WorkTypeRNDComputer> li_WorkTypeRNDComputers = new List<Li_WorkTypeRNDComputer>();

        while (reader.Read())
        {
            li_WorkTypeRNDComputers.Add(GetLi_WorkTypeRNDComputerFromReader(reader));
        }
        return li_WorkTypeRNDComputers;
    }

    public Li_WorkTypeRNDComputer GetLi_WorkTypeRNDComputerFromReader(IDataReader reader)
    {
        try
        {
            Li_WorkTypeRNDComputer li_WorkTypeRNDComputer = new Li_WorkTypeRNDComputer
                (
                    
                    (int)reader["WorksTypeID"],
                    reader["WorkType"].ToString(),
                    (int)reader["SectionID"],
                    (bool)reader["IsMeasureInTime"] 
                );
             return li_WorkTypeRNDComputer;
        }
        catch(Exception)
        {
            return null;
        }
    }

    public Li_WorkTypeRNDComputer GetLi_WorkTypeRNDComputerByID(int li_WorkTypeRNDComputerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SmartPublisherManagement_GetLi_WorkTypeRNDComputerByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_WorkTypeRNDComputerID", SqlDbType.Int).Value = li_WorkTypeRNDComputerID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_WorkTypeRNDComputerFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_WorkTypeRNDComputer(Li_WorkTypeRNDComputer li_WorkTypeRNDComputer)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SmartPublisherManagement_InsertLi_WorkTypeRNDComputer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_WorkTypeRNDComputerID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@WorksTypeID", SqlDbType.Int).Value = li_WorkTypeRNDComputer.WorksTypeID;
            cmd.Parameters.Add("@WorkType", SqlDbType.VarChar).Value = li_WorkTypeRNDComputer.WorkType;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_WorkTypeRNDComputer.SectionID;
            cmd.Parameters.Add("@IsMeasureInTime", SqlDbType.Bit).Value = li_WorkTypeRNDComputer.IsMeasureInTime;
      
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Li_WorkTypeRNDComputerID"].Value;
        }
    }

    public bool UpdateLi_WorkTypeRNDComputer(Li_WorkTypeRNDComputer li_WorkTypeRNDComputer)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SmartPublisherManagement_UpdateLi_WorkTypeRNDComputer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@Li_WorkTypeRNDComputerID", SqlDbType.Int).Value = li_WorkTypeRNDComputer.Li_WorkTypeRNDComputerID;
            cmd.Parameters.Add("@WorksTypeID", SqlDbType.Int).Value = li_WorkTypeRNDComputer.WorksTypeID;
            cmd.Parameters.Add("@WorkType", SqlDbType.VarChar).Value = li_WorkTypeRNDComputer.WorkType;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_WorkTypeRNDComputer.SectionID;
            cmd.Parameters.Add("@IsMeasureInTime", SqlDbType.Bit).Value = li_WorkTypeRNDComputer.IsMeasureInTime;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
