using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_DependentProvider:DataAccessObject
{
	public SqlLi_DependentProvider()
    {
    }


    public bool DeleteLi_Dependent(int li_DependentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Dependent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DepenId", SqlDbType.Int).Value = li_DependentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Dependent> GetAllLi_Dependents()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Dependents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DependentsFromReader(reader);
        }
    }
    public List<Li_Dependent> GetLi_DependentsFromReader(IDataReader reader)
    {
        List<Li_Dependent> li_Dependents = new List<Li_Dependent>();

        while (reader.Read())
        {
            li_Dependents.Add(GetLi_DependentFromReader(reader));
        }
        return li_Dependents;
    }

    public Li_Dependent GetLi_DependentFromReader(IDataReader reader)
    {
        try
        {
            Li_Dependent li_Dependent = new Li_Dependent
                (
                   
                    (int)reader["DepenId"],
                    reader["DepenName"].ToString(),
                    (int)reader["EmpSl"],
                    reader["Relation"].ToString(),
                    (DateTime)reader["DoB"],
                    reader["CertificateNo"].ToString(),
                    reader["CertifPath"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Dependent;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Dependent GetLi_DependentByID(int li_DependentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_DependentByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DepenId", SqlDbType.Int).Value = li_DependentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DependentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Dependent(Li_Dependent li_Dependent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Dependent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@DepenId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DepenName", SqlDbType.VarChar).Value = li_Dependent.DepenName;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_Dependent.EmpSl;
            cmd.Parameters.Add("@Relation", SqlDbType.VarChar).Value = li_Dependent.Relation;
            cmd.Parameters.Add("@DoB", SqlDbType.DateTime).Value = li_Dependent.DoB;
            cmd.Parameters.Add("@CertificateNo", SqlDbType.VarChar).Value = li_Dependent.CertificateNo;
            cmd.Parameters.Add("@CertifPath", SqlDbType.VarChar).Value = li_Dependent.CertifPath;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Dependent.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Dependent.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Dependent.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Dependent.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Dependent.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DepenId"].Value;
        }
    }

    public bool UpdateLi_Dependent(Li_Dependent li_Dependent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Dependent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@DepenId", SqlDbType.Int).Value = li_Dependent.DepenId;
            cmd.Parameters.Add("@DepenName", SqlDbType.VarChar).Value = li_Dependent.DepenName;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_Dependent.EmpSl;
            cmd.Parameters.Add("@Relation", SqlDbType.VarChar).Value = li_Dependent.Relation;
            cmd.Parameters.Add("@DoB", SqlDbType.DateTime).Value = li_Dependent.DoB;
            cmd.Parameters.Add("@CertificateNo", SqlDbType.VarChar).Value = li_Dependent.CertificateNo;
            cmd.Parameters.Add("@CertifPath", SqlDbType.VarChar).Value = li_Dependent.CertifPath;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Dependent.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Dependent.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Dependent.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Dependent.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Dependent.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataTable LoadGvDependents()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadGvDependents", connection);
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
