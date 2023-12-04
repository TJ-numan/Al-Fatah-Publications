using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmploymentProvider:DataAccessObject
{
	public SqlLi_EmploymentProvider()
    {
    }


    public bool DeleteLi_Employment(int li_EmploymentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Employment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExperId", SqlDbType.Int).Value = li_EmploymentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Employment> GetAllLi_Employments()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Employments", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmploymentsFromReader(reader);
        }
    }
    public List<Li_Employment> GetLi_EmploymentsFromReader(IDataReader reader)
    {
        List<Li_Employment> li_Employments = new List<Li_Employment>();

        while (reader.Read())
        {
            li_Employments.Add(GetLi_EmploymentFromReader(reader));
        }
        return li_Employments;
    }

    public Li_Employment GetLi_EmploymentFromReader(IDataReader reader)
    {
        try
        {
            Li_Employment li_Employment = new Li_Employment
                (
                     
                    (int)reader["ExperId"],
                    (int)reader["EmpSl"],
                    reader["CompName"].ToString(),
                    reader["CompBusiness"].ToString(),
                    reader["Designation"].ToString(),
                    reader["Department"].ToString(),
                    reader["Responsibilities"].ToString(),
                    reader["ComLocation"].ToString(),
                    reader["EmployPeriod"].ToString(),
                    (bool)reader["IsCurrentlyWorking"],
                    reader["AreaOfExperi"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Employment;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Employment GetLi_EmploymentByID(int li_EmploymentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmploymentByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExperId", SqlDbType.Int).Value = li_EmploymentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmploymentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Employment(Li_Employment li_Employment)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Employment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@ExperId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_Employment.EmpSl;
            cmd.Parameters.Add("@CompName", SqlDbType.VarChar).Value = li_Employment.CompName;
            cmd.Parameters.Add("@CompBusiness", SqlDbType.VarChar).Value = li_Employment.CompBusiness;
            cmd.Parameters.Add("@Designation", SqlDbType.VarChar).Value = li_Employment.Designation;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = li_Employment.Department;
            cmd.Parameters.Add("@Responsibilities", SqlDbType.VarChar).Value = li_Employment.Responsibilities;
            cmd.Parameters.Add("@ComLocation", SqlDbType.VarChar).Value = li_Employment.ComLocation;
            cmd.Parameters.Add("@EmployPeriod", SqlDbType.VarChar).Value = li_Employment.EmployPeriod;
            cmd.Parameters.Add("@IsCurrentlyWorking", SqlDbType.Bit).Value = li_Employment.IsCurrentlyWorking;
            cmd.Parameters.Add("@AreaOfExperi", SqlDbType.VarChar).Value = li_Employment.AreaOfExperi;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Employment.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Employment.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Employment.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Employment.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Employment.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExperId"].Value;
        }
    }

    public bool UpdateLi_Employment(Li_Employment li_Employment)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Employment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@ExperId", SqlDbType.Int).Value = li_Employment.ExperId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_Employment.EmpSl;
            cmd.Parameters.Add("@CompName", SqlDbType.VarChar).Value = li_Employment.CompName;
            cmd.Parameters.Add("@CompBusiness", SqlDbType.VarChar).Value = li_Employment.CompBusiness;
            cmd.Parameters.Add("@Designation", SqlDbType.VarChar).Value = li_Employment.Designation;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = li_Employment.Department;
            cmd.Parameters.Add("@Responsibilities", SqlDbType.VarChar).Value = li_Employment.Responsibilities;
            cmd.Parameters.Add("@ComLocation", SqlDbType.VarChar).Value = li_Employment.ComLocation;
            cmd.Parameters.Add("@EmployPeriod", SqlDbType.VarChar).Value = li_Employment.EmployPeriod;
            cmd.Parameters.Add("@IsCurrentlyWorking", SqlDbType.Bit).Value = li_Employment.IsCurrentlyWorking;
            cmd.Parameters.Add("@AreaOfExperi", SqlDbType.VarChar).Value = li_Employment.AreaOfExperi;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Employment.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Employment.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Employment.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Employment.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Employment.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataTable LoadGvEmployment()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadGvEmployment", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();

            return dt;
        }
    }


}
