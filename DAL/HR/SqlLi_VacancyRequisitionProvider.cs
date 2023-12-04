using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_VacancyRequisitionProvider:DataAccessObject
{
	public SqlLi_VacancyRequisitionProvider()
    {
    }


    public bool DeleteLi_VacancyRequisition(int li_VacancyRequisitionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_VacancyRequisition", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VacId", SqlDbType.Int).Value = li_VacancyRequisitionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_VacancyRequisition> GetAllLi_VacancyRequisitions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_VacancyRequisitions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_VacancyRequisitionsFromReader(reader);
        }
    }
    public List<Li_VacancyRequisition> GetLi_VacancyRequisitionsFromReader(IDataReader reader)
    {
        List<Li_VacancyRequisition> li_VacancyRequisitions = new List<Li_VacancyRequisition>();

        while (reader.Read())
        {
            li_VacancyRequisitions.Add(GetLi_VacancyRequisitionFromReader(reader));
        }
        return li_VacancyRequisitions;
    }

    public Li_VacancyRequisition GetLi_VacancyRequisitionFromReader(IDataReader reader)
    {
        try
        {
            Li_VacancyRequisition li_VacancyRequisition = new Li_VacancyRequisition
                (
                   
                    (int)reader["VacId"],
                    reader["VacTitle"].ToString(),
                    (int)reader["PosId"],
                    (int)reader["VacForId"],
                    (int)reader["EmpTypeId"],
                    reader["Qualification"].ToString(),
                    reader["Experience"].ToString(),
                    reader["RequiredTime"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_VacancyRequisition;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_VacancyRequisition GetLi_VacancyRequisitionByID(int li_VacancyRequisitionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_VacancyRequisitionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@VacId", SqlDbType.Int).Value = li_VacancyRequisitionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_VacancyRequisitionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_VacancyRequisition(Li_VacancyRequisition li_VacancyRequisition)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_VacancyRequisition", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@VacId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@VacTitle", SqlDbType.VarChar).Value = li_VacancyRequisition.VacTitle;
            cmd.Parameters.Add("@PosId", SqlDbType.Int).Value = li_VacancyRequisition.PosId;
            cmd.Parameters.Add("@VacForId", SqlDbType.Int).Value = li_VacancyRequisition.VacForId;
            cmd.Parameters.Add("@EmpTypeId", SqlDbType.Int).Value = li_VacancyRequisition.EmpTypeId;
            cmd.Parameters.Add("@Qualification", SqlDbType.VarChar).Value = li_VacancyRequisition.Qualification;
            cmd.Parameters.Add("@Experience", SqlDbType.VarChar).Value = li_VacancyRequisition.Experience;
            cmd.Parameters.Add("@RequiredTime", SqlDbType.VarChar).Value = li_VacancyRequisition.RequiredTime;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_VacancyRequisition.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_VacancyRequisition.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_VacancyRequisition.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_VacancyRequisition.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_VacancyRequisition.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@VacId"].Value;
        }
    }

    public bool UpdateLi_VacancyRequisition(Li_VacancyRequisition li_VacancyRequisition)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_VacancyRequisition", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@VacId", SqlDbType.Int).Value = li_VacancyRequisition.VacId;
            cmd.Parameters.Add("@VacTitle", SqlDbType.VarChar).Value = li_VacancyRequisition.VacTitle;
            cmd.Parameters.Add("@PosId", SqlDbType.Int).Value = li_VacancyRequisition.PosId;
            cmd.Parameters.Add("@VacForId", SqlDbType.Int).Value = li_VacancyRequisition.VacForId;
            cmd.Parameters.Add("@EmpTypeId", SqlDbType.Int).Value = li_VacancyRequisition.EmpTypeId;
            cmd.Parameters.Add("@Qualification", SqlDbType.VarChar).Value = li_VacancyRequisition.Qualification;
            cmd.Parameters.Add("@Experience", SqlDbType.VarChar).Value = li_VacancyRequisition.Experience;
            cmd.Parameters.Add("@RequiredTime", SqlDbType.VarChar).Value = li_VacancyRequisition.RequiredTime;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_VacancyRequisition.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_VacancyRequisition.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_VacancyRequisition.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_VacancyRequisition.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_VacancyRequisition.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
