using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_EmpEducationProvider:DataAccessObject
{
	public SqlLi_EmpEducationProvider()
    {
    }


    public bool DeleteLi_EmpEducation(int li_EmpEducationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpEducation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EduId", SqlDbType.Int).Value = li_EmpEducationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpEducation> GetAllLi_EmpEducations()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpEducations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpEducationsFromReader(reader);
        }
    }
    public List<Li_EmpEducation> GetLi_EmpEducationsFromReader(IDataReader reader)
    {
        List<Li_EmpEducation> li_EmpEducations = new List<Li_EmpEducation>();

        while (reader.Read())
        {
            li_EmpEducations.Add(GetLi_EmpEducationFromReader(reader));
        }
        return li_EmpEducations;
    }

    public Li_EmpEducation GetLi_EmpEducationFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpEducation li_EmpEducation = new Li_EmpEducation
                ( 
                    (int)reader["EduId"],
                    (int)reader["EmpSl"],
                    (int)reader["EduLId"],
                    (int)reader["ExamId"],
                    (int)reader["EduReId"],
                    reader["MajorOrGroup"].ToString(),
                    reader["PassYr"].ToString(),
                    reader["CertifPath"].ToString(),
                    reader["InstituteName"].ToString(),
                    (bool)reader["IsForeign"],
                    reader["Achievement"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpEducation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpEducation GetLi_EmpEducationByID(int li_EmpEducationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpEducationByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EduId", SqlDbType.Int).Value = li_EmpEducationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpEducationFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpEducation(Li_EmpEducation li_EmpEducation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpEducation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@EduId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpEducation.EmpSl;
            cmd.Parameters.Add("@EduLId", SqlDbType.Int).Value = li_EmpEducation.EduLId;
            cmd.Parameters.Add("@ExamId", SqlDbType.Int).Value = li_EmpEducation.ExamId;
            cmd.Parameters.Add("@EduReId", SqlDbType.Int).Value = li_EmpEducation.EduReId;
            cmd.Parameters.Add("@MajorOrGroup", SqlDbType.VarChar).Value = li_EmpEducation.MajorOrGroup;
            cmd.Parameters.Add("@PassYr", SqlDbType.VarChar).Value = li_EmpEducation.PassYr;
            cmd.Parameters.Add("@CertifPath", SqlDbType.VarChar).Value = li_EmpEducation.CertifPath;
            cmd.Parameters.Add("@InstituteName", SqlDbType.VarChar).Value = li_EmpEducation.InstituteName;
            cmd.Parameters.Add("@IsForeign", SqlDbType.Bit).Value = li_EmpEducation.IsForeign;
            cmd.Parameters.Add("@Achievement", SqlDbType.VarChar).Value = li_EmpEducation.Achievement;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpEducation.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpEducation.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpEducation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpEducation.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpEducation.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EduId"].Value;
        }
    }

    public bool UpdateLi_EmpEducation(Li_EmpEducation li_EmpEducation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpEducation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@EduId", SqlDbType.Int).Value = li_EmpEducation.EduId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpEducation.EmpSl;
            cmd.Parameters.Add("@EduLId", SqlDbType.Int).Value = li_EmpEducation.EduLId;
            cmd.Parameters.Add("@ExamId", SqlDbType.Int).Value = li_EmpEducation.ExamId;
            cmd.Parameters.Add("@EduReId", SqlDbType.Int).Value = li_EmpEducation.EduReId;
            cmd.Parameters.Add("@MajorOrGroup", SqlDbType.VarChar).Value = li_EmpEducation.MajorOrGroup;
            cmd.Parameters.Add("@PassYr", SqlDbType.VarChar).Value = li_EmpEducation.PassYr;
            cmd.Parameters.Add("@CertifPath", SqlDbType.VarChar).Value = li_EmpEducation.CertifPath;
            cmd.Parameters.Add("@InstituteName", SqlDbType.VarChar).Value = li_EmpEducation.InstituteName;
            cmd.Parameters.Add("@IsForeign", SqlDbType.Bit).Value = li_EmpEducation.IsForeign;
            cmd.Parameters.Add("@Achievement", SqlDbType.VarChar).Value = li_EmpEducation.Achievement;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpEducation.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpEducation.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpEducation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpEducation.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpEducation.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }



    public DataTable LoadGvEmployeeEducation()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadGvEmployeeEducation", connection);
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
