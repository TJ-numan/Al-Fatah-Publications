using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_TeacherInfoProvider:DataAccessObject
{
	public SqlLi_TeacherInfoProvider()
    {
    }


    public bool DeleteLi_TeacherInfo(int li_TeacherInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_TeacherInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_TeacherInfoID", SqlDbType.Int).Value = li_TeacherInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TeacherInfo> GetAllLi_TeacherInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_TeacherInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TeacherInfosFromReader(reader);
        }
    }
    public List<Li_TeacherInfo> GetLi_TeacherInfosFromReader(IDataReader reader)
    {
        List<Li_TeacherInfo> li_TeacherInfos = new List<Li_TeacherInfo>();

        while (reader.Read())
        {
            li_TeacherInfos.Add(GetLi_TeacherInfoFromReader(reader));
        }
        return li_TeacherInfos;
    }

    public Li_TeacherInfo GetLi_TeacherInfoFromReader(IDataReader reader)
    {
        try
        {
            Li_TeacherInfo li_TeacherInfo = new Li_TeacherInfo
                (
                   
                    (int)reader["TeacherId"],
                    reader["TeachderName"].ToString(),
                    (int)reader["DesignationId"],
                    reader["SubjectName"].ToString(),
                    reader["MadrasahName"].ToString(),
                    reader["MobileNo"].ToString(),
                    reader["PaperSl"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    reader["Territory"].ToString(),
                    reader["ClassName"].ToString(),
                    reader["AccTitle"].ToString(),
                    reader["AccType"].ToString(),
                    reader["DepositType"].ToString(),
                    reader["AccNo"].ToString(),
                    reader["BankName"].ToString(),
                    reader["BankAddress"].ToString(),
                    reader["MadrasahAdd"].ToString(),
                    (DateTime)reader["VerifyDate"]
                );
             return li_TeacherInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TeacherInfo GetLi_TeacherInfoByID(int li_TeacherInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_TeacherInfoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_TeacherInfoID", SqlDbType.Int).Value = li_TeacherInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TeacherInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_TeacherInfo(Li_TeacherInfo li_TeacherInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_TeacherInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@TeacherId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TeachderName", SqlDbType.VarChar).Value = li_TeacherInfo.TeachderName;
            cmd.Parameters.Add("@DesignationId", SqlDbType.Int).Value = li_TeacherInfo.DesignationId;
            cmd.Parameters.Add("@SubjectName", SqlDbType.VarChar).Value = li_TeacherInfo.SubjectName;
            cmd.Parameters.Add("@MadrasahName", SqlDbType.VarChar).Value = li_TeacherInfo.MadrasahName;
            cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = li_TeacherInfo.MobileNo;
            cmd.Parameters.Add("@PaperSl", SqlDbType.VarChar).Value = li_TeacherInfo.PaperSl;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TeacherInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TeacherInfo.CreatedDate;
            cmd.Parameters.Add("@Territory", SqlDbType.VarChar).Value = li_TeacherInfo.Territory;
            cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = li_TeacherInfo.ClassName;
            cmd.Parameters.Add("@AccTitle", SqlDbType.VarChar).Value = li_TeacherInfo.AccTitle;
            cmd.Parameters.Add("@AccType", SqlDbType.VarChar).Value = li_TeacherInfo.AccType;
            cmd.Parameters.Add("@DepositType", SqlDbType.VarChar).Value = li_TeacherInfo.DepositType;
            cmd.Parameters.Add("@AccNo", SqlDbType.VarChar).Value = li_TeacherInfo.AccNo;
            cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = li_TeacherInfo.BankName;
            cmd.Parameters.Add("@BankAddress", SqlDbType.VarChar).Value = li_TeacherInfo.BankAddress;
            cmd.Parameters.Add("@MadrasahAdd", SqlDbType.VarChar).Value = li_TeacherInfo.MadrasahAdd;
            cmd.Parameters.Add("@VerifyDate", SqlDbType.DateTime).Value = li_TeacherInfo.VerifyDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result;
            //return (int)cmd.Parameters["@TeacherId"].Value;
        }
    }

    public bool UpdateLi_TeacherInfo(Li_TeacherInfo li_TeacherInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_TeacherInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@TeacherId", SqlDbType.Int).Value = li_TeacherInfo.TeacherId;
            cmd.Parameters.Add("@TeachderName", SqlDbType.VarChar).Value = li_TeacherInfo.TeachderName;
            cmd.Parameters.Add("@DesignationId", SqlDbType.Int).Value = li_TeacherInfo.DesignationId;
            cmd.Parameters.Add("@SubjectName", SqlDbType.VarChar).Value = li_TeacherInfo.SubjectName;
            cmd.Parameters.Add("@MadrasahName", SqlDbType.VarChar).Value = li_TeacherInfo.MadrasahName;
            cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = li_TeacherInfo.MobileNo;
            cmd.Parameters.Add("@PaperSl", SqlDbType.VarChar).Value = li_TeacherInfo.PaperSl;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TeacherInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TeacherInfo.CreatedDate;
            cmd.Parameters.Add("@Territory", SqlDbType.VarChar).Value = li_TeacherInfo.Territory;
            cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = li_TeacherInfo.ClassName;
            cmd.Parameters.Add("@AccTitle", SqlDbType.VarChar).Value = li_TeacherInfo.AccTitle;
            cmd.Parameters.Add("@AccType", SqlDbType.VarChar).Value = li_TeacherInfo.AccType;
            cmd.Parameters.Add("@AccNo", SqlDbType.VarChar).Value = li_TeacherInfo.AccNo;
            cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = li_TeacherInfo.BankName;
            cmd.Parameters.Add("@BankAddress", SqlDbType.VarChar).Value = li_TeacherInfo.BankAddress;
            cmd.Parameters.Add("@MadrasahAdd", SqlDbType.VarChar).Value = li_TeacherInfo.MadrasahAdd;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    //-----------------2021 Rezaul------------------
    public string InsertLi_QawmiTeacherInfoByMad(Li_TeacherInfo li_QawmiTeacherInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_QawmiTeacherInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Mad_ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mad_Name", SqlDbType.VarChar).Value = li_QawmiTeacherInfo.MadrasahName;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_QawmiTeacherInfo.MadrasahAdd;
            cmd.Parameters.Add("@TSO_ID", SqlDbType.VarChar).Value = li_QawmiTeacherInfo.TeachderName;
            cmd.Parameters.Add("@Thana_ID", SqlDbType.Int).Value = li_QawmiTeacherInfo.DesignationId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_QawmiTeacherInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_QawmiTeacherInfo.CreatedDate;         
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@Mad_ID"].Value.ToString();
        }
    }
    public int InsertLi_QawmiTeacherInfoByMadDetails(Li_TeacherInfo li_QawmiTeacherInfoDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_QawmiTeacherInfoByMadDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MadDet_ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mad_ID", SqlDbType.Int).Value = li_QawmiTeacherInfoDetails.TeacherId;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_QawmiTeacherInfoDetails.ClassName;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_QawmiTeacherInfoDetails.SubjectName;
            cmd.Parameters.Add("@Teacher_Name", SqlDbType.VarChar).Value = li_QawmiTeacherInfoDetails.TeachderName;
            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = li_QawmiTeacherInfoDetails.MobileNo;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_QawmiTeacherInfoDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_QawmiTeacherInfoDetails.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
}
