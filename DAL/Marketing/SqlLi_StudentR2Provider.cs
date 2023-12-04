using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using Common.Marketing;

public class SqlLi_StudentR2Provider:DataAccessObject
{
	public SqlLi_StudentR2Provider()
    {
    }


    public bool DeleteLi_StudentR2(int li_StudentR2ID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(" ", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ ", SqlDbType.Int).Value = li_StudentR2ID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_StudentR2> GetAllLi_StudentR2s()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(" ", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_StudentR2sFromReader(reader);
        }
    }
    public List<Li_StudentR2> GetLi_StudentR2sFromReader(IDataReader reader)
    {
        List<Li_StudentR2> li_StudentR2s = new List<Li_StudentR2>();

        while (reader.Read())
        {
            li_StudentR2s.Add(GetLi_StudentR2FromReader(reader));
        }
        return li_StudentR2s;
    }

    public Li_StudentR2 GetLi_StudentR2FromReader(IDataReader reader)
    {
        try
        {
            Li_StudentR2 li_StudentR2 = new Li_StudentR2
                (
                   
                    (int)reader["SlNo"],
                    (int)reader["ClassID"],
                    (int)reader["NoOfStudents"],
                    reader["MadId"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                );
             return li_StudentR2;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_StudentR2 GetLi_StudentR2ByID(int li_StudentR2ID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(" ", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ ", SqlDbType.Int).Value = li_StudentR2ID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_StudentR2FromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_StudentR2(Li_StudentR2 li_StudentR2)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_NoOfStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@SlNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_StudentR2.ClassID;
            cmd.Parameters.Add("@NoOfStudents", SqlDbType.Int).Value = li_StudentR2.NoOfStudents;
            cmd.Parameters.Add("@MadId", SqlDbType.VarChar).Value = li_StudentR2.MadId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_StudentR2.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_StudentR2.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SlNo"].Value;
        }
    }

    public bool UpdateLi_StudentR2(Li_StudentR2 li_StudentR2)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_UpdateMadrashaStudentR2", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            //cmd.Parameters.Add("@SlNo", SqlDbType.Int).Value = li_StudentR2.SlNo;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_StudentR2.ClassID;
            cmd.Parameters.Add("@NoOfStudents", SqlDbType.Int).Value = li_StudentR2.NoOfStudents;
            cmd.Parameters.Add("@MadId", SqlDbType.VarChar).Value = li_StudentR2.MadId;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_StudentR2.CreatedBy;
            //cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_StudentR2.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetLi_StudentR2By_MadId(string MadId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_MadrashaStudentBy_MadId", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MadId", SqlDbType.VarChar).Value = MadId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;

        }
    }


    public int InsertLi_StudentAdvanced(Li_StudentAdvanced li_Student_adv)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_NoOfStudentAdvanced", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SlNo", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_Student_adv.ClassID;
            cmd.Parameters.Add("@NoOfStudents", SqlDbType.Int).Value = li_Student_adv.NoOfStudents;
            cmd.Parameters.Add("@EIIN", SqlDbType.VarChar).Value = li_Student_adv.EIIN;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Student_adv.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Student_adv.CreatedDate;
            cmd.Parameters.Add("@FY_Year", SqlDbType.VarChar).Value = li_Student_adv.FY_Year;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SlNo"].Value;
        }
    }
    public int InsertLi_TeacherNoAdvanced(Li_TeacherNoAdvanced li_TeacherNoAdv)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_NoOfTeacherAdvanced", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SlNo", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mad_Level_ID", SqlDbType.Int).Value = li_TeacherNoAdv.Mad_Level_ID;
            cmd.Parameters.Add("@NoOfTeachers", SqlDbType.Int).Value = li_TeacherNoAdv.NoOfTeachers;
            cmd.Parameters.Add("@EIIN", SqlDbType.VarChar).Value = li_TeacherNoAdv.EIIN;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TeacherNoAdv.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TeacherNoAdv.CreatedDate;
            cmd.Parameters.Add("@FY_Year", SqlDbType.VarChar).Value = li_TeacherNoAdv.FY_Year;
            cmd.Parameters.Add("@AgreementWith", SqlDbType.VarChar).Value = li_TeacherNoAdv.AgreementWith;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SlNo"].Value;
        }
    }
    public int UpdateLi_StudentAdvanced(Li_StudentAdvanced li_Student_adv)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_NoOfStudentAdvanced", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_Student_adv.ClassID;
            cmd.Parameters.Add("@NoOfStudents", SqlDbType.Int).Value = li_Student_adv.NoOfStudents;
            cmd.Parameters.Add("@EIIN", SqlDbType.VarChar).Value = li_Student_adv.EIIN;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Student_adv.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Student_adv.CreatedDate;
            cmd.Parameters.Add("@FY_Year", SqlDbType.VarChar).Value = li_Student_adv.FY_Year;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result=1;
        }
    }
    public int UpdateLi_TeacherNoAdvanced(Li_TeacherNoAdvanced li_TeacherNoAdv)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_NoOfTeacherAdvanced", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Mad_Level_ID", SqlDbType.Int).Value = li_TeacherNoAdv.Mad_Level_ID;
            cmd.Parameters.Add("@NoOfTeachers", SqlDbType.Int).Value = li_TeacherNoAdv.NoOfTeachers;
            cmd.Parameters.Add("@EIIN", SqlDbType.VarChar).Value = li_TeacherNoAdv.EIIN;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TeacherNoAdv.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TeacherNoAdv.CreatedDate;
            cmd.Parameters.Add("@FY_Year", SqlDbType.VarChar).Value = li_TeacherNoAdv.FY_Year;
            cmd.Parameters.Add("@AgreementWith", SqlDbType.VarChar).Value = li_TeacherNoAdv.AgreementWith;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result=1;
        }
    }
}
