using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpClearanceProvider:DataAccessObject
{
	public SqlLi_EmpClearanceProvider()
    {
    }


    public bool DeleteLi_EmpClearance(int li_EmpClearanceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpClearance", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClearId", SqlDbType.Int).Value = li_EmpClearanceID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpClearance> GetAllLi_EmpClearances()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpClearances", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpClearancesFromReader(reader);
        }
    }
    public List<Li_EmpClearance> GetLi_EmpClearancesFromReader(IDataReader reader)
    {
        List<Li_EmpClearance> li_EmpClearances = new List<Li_EmpClearance>();

        while (reader.Read())
        {
            li_EmpClearances.Add(GetLi_EmpClearanceFromReader(reader));
        }
        return li_EmpClearances;
    }

    public Li_EmpClearance GetLi_EmpClearanceFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpClearance li_EmpClearance = new Li_EmpClearance
                (
             
                    (int)reader["ClearId"],
                    (int)reader["EmpSl"],
                    (int)reader["EmploymentStId"],
                    reader["ClearTitle"].ToString(),
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpClearance;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpClearance GetLi_EmpClearanceByID(int li_EmpClearanceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpClearanceByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClearId", SqlDbType.Int).Value = li_EmpClearanceID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpClearanceFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpClearance(Li_EmpClearance li_EmpClearance)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpClearance", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@ClearId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpClearance.EmpSl;
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_EmpClearance.EmploymentStId;
            cmd.Parameters.Add("@ClearTitle", SqlDbType.VarChar).Value = li_EmpClearance.ClearTitle;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpClearance.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpClearance.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpClearance.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpClearance.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpClearance.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpClearance.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClearId"].Value;
        }
    }

    public bool UpdateLi_EmpClearance(Li_EmpClearance li_EmpClearance)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpClearance", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@ClearId", SqlDbType.Int).Value = li_EmpClearance.ClearId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpClearance.EmpSl;
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_EmpClearance.EmploymentStId;
            cmd.Parameters.Add("@ClearTitle", SqlDbType.VarChar).Value = li_EmpClearance.ClearTitle;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpClearance.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpClearance.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpClearance.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpClearance.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpClearance.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpClearance.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
