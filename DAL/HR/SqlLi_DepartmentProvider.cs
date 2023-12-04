using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_DepartmentProvider:DataAccessObject
{
	public SqlLi_DepartmentProvider()
    {
    }


    public bool DeleteLi_Department(int li_DepartmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Department", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_DepartmentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Department> GetAllLi_Departments()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Departments", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DepartmentsFromReader(reader);
        }
    }
    public List<Li_Department> GetLi_DepartmentsFromReader(IDataReader reader)
    {
        List<Li_Department> li_Departments = new List<Li_Department>();

        while (reader.Read())
        {
            li_Departments.Add(GetLi_DepartmentFromReader(reader));
        }
        return li_Departments;
    }

    public Li_Department GetLi_DepartmentFromReader(IDataReader reader)
    {
        try
        {
            Li_Department li_Department = new Li_Department
                (
                   
                    (int)reader["DepId"],
                    reader["DepName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Department;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Department GetLi_DepartmentByID(int li_DepartmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_DepartmentByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DepId", SqlDbType.Int).Value = li_DepartmentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DepartmentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Department(Li_Department li_Department)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Department", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@DepId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DepName", SqlDbType.VarChar).Value = li_Department.DepName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Department.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Department.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Department.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Department.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Department.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DepId"].Value;
        }
    }

    public bool UpdateLi_Department(Li_Department li_Department)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Department", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_Department.DepId;
            cmd.Parameters.Add("@DepName", SqlDbType.VarChar).Value = li_Department.DepName; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Department.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Department.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Department.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public   DataTable loadDepartmentFromEmpInfo()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.LoadDepartmentsFromEmpInfos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
    //--------------------------Rezaul Hossain-----------------------------2020---------------------
    public Li_Department GetLi_DepartmentByEmpID(int EmpId)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_DepartmentByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmpId", SqlDbType.Int).Value = EmpId;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DepartmentFromReaderReza(reader);
            }
            else
            {
                return null;
            }
        }
    }
    public Li_Department GetLi_DepartmentFromReaderReza(IDataReader reader)
    {
        try
        {
            Li_Department li_Department = new Li_Department
                (

                    (int)reader["DepId"],
                    reader["DepName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
            return li_Department;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
