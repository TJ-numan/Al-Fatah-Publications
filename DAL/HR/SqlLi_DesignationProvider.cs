using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using Common.R_D;

public class SqlLi_DesignationProvider:DataAccessObject
{
	public SqlLi_DesignationProvider()
    {
    }


    public bool DeleteLi_Designation(int li_DesignationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Designation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DesId", SqlDbType.Int).Value = li_DesignationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Designation> GetAllLi_Designations()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Designations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DesignationsFromReader(reader);
        }
    }
    public List<Li_Designation> GetLi_DesignationsFromReader(IDataReader reader)
    {
        List<Li_Designation> li_Designations = new List<Li_Designation>();

        while (reader.Read())
        {
            li_Designations.Add(GetLi_DesignationFromReader(reader));
        }
        return li_Designations;
    }

    public Li_Designation GetLi_DesignationFromReader(IDataReader reader)
    {
        try
        {
            Li_Designation li_Designation = new Li_Designation
                (                 
                    (int)reader["DesId"],
                    reader["DesName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Designation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Designation GetLi_DesignationByID(int li_DesignationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_DesignationByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DesId", SqlDbType.Int).Value = li_DesignationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DesignationFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Designation(Li_Designation li_Designation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Designation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DesId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DesName", SqlDbType.VarChar).Value = li_Designation.DesName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Designation.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Designation.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Designation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Designation.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Designation.InfStId;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DesId"].Value;
        }
    }

    public bool UpdateLi_Designation(Li_Designation li_Designation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Designation", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@DesId", SqlDbType.Int).Value = li_Designation.DesId;
            cmd.Parameters.Add("@DesName", SqlDbType.VarChar).Value = li_Designation.DesName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Designation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Designation.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Designation.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataTable LoadDesignationFromEmpInfos(int departmentId, int SecId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.LoadDesignationFromEmpInfos",connection );
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = departmentId;
            cmd.Parameters.Add("@SecId", SqlDbType.Int).Value = SecId ;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
    //--------------------------Rezaul Hossain-----------------------------2020---------------------
    //public li_DesignationR GetLi_DesignationByEmpID(int Empid)
    //{
        //using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        //{
        //    SqlCommand command = new SqlCommand("SMPM_GetLi_DesignationByEmpID", connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.Add("@Empid", SqlDbType.Int).Value = Empid;
        //    connection.Open();
        //    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

        //    if (reader.Read())
        //    {
        //        return GetLi_DesignationFromReaderReza(reader);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    public DataTable GetLi_DesignationByEmpID(int EmpId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_DesignationByEmpID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmpId", SqlDbType.Int).Value = EmpId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
    
    public li_DesignationR GetLi_DesignationFromReaderReza(IDataReader reader)
    {
        try
        {
            li_DesignationR li_Designation = new li_DesignationR
                (                 
                    (int)reader["DesignationID"],
                    reader["Designation"].ToString()
                );
             return li_Designation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }
    //--------------Rezaul Hossain--------2021-06-01------------------------------
    public DataTable GetLi_DesignationQawmiByEmpID(int EmpId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_DesignationQawmiByEmpID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmpId", SqlDbType.Int).Value = EmpId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
}
