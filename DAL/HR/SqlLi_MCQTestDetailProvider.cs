using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_MCQTestDetailProvider:DataAccessObject
{
	public SqlLi_MCQTestDetailProvider()
    {
    }


    public bool DeleteLi_MCQTestDetail(int li_MCQTestDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_MCQTestDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@McqTestDeId", SqlDbType.Int).Value = li_MCQTestDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_MCQTestDetail> GetAllLi_MCQTestDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_MCQTestDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_MCQTestDetailsFromReader(reader);
        }
    }
    public List<Li_MCQTestDetail> GetLi_MCQTestDetailsFromReader(IDataReader reader)
    {
        List<Li_MCQTestDetail> li_MCQTestDetails = new List<Li_MCQTestDetail>();

        while (reader.Read())
        {
            li_MCQTestDetails.Add(GetLi_MCQTestDetailFromReader(reader));
        }
        return li_MCQTestDetails;
    }

    public Li_MCQTestDetail GetLi_MCQTestDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_MCQTestDetail li_MCQTestDetail = new Li_MCQTestDetail
                (
                 
                    (int)reader["McqTestDeId"],
                    (int)reader["TestId"],
                    (int)reader["MCQuesId"],
                    (decimal)reader["Marks"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_MCQTestDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_MCQTestDetail GetLi_MCQTestDetailByID(int li_MCQTestDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_MCQTestDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@McqTestDeId", SqlDbType.Int).Value = li_MCQTestDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_MCQTestDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_MCQTestDetail(Li_MCQTestDetail li_MCQTestDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_MCQTestDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@McqTestDeId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TestId", SqlDbType.Int).Value = li_MCQTestDetail.TestId;
            cmd.Parameters.Add("@MCQuesId", SqlDbType.Int).Value = li_MCQTestDetail.MCQuesId;
            cmd.Parameters.Add("@Marks", SqlDbType.Decimal).Value = li_MCQTestDetail.Marks;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MCQTestDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MCQTestDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MCQTestDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_MCQTestDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_MCQTestDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@McqTestDeId"].Value;
        }
    }

    public bool UpdateLi_MCQTestDetail(Li_MCQTestDetail li_MCQTestDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_MCQTestDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@McqTestDeId", SqlDbType.Int).Value = li_MCQTestDetail.McqTestDeId;
            cmd.Parameters.Add("@TestId", SqlDbType.Int).Value = li_MCQTestDetail.TestId;
            cmd.Parameters.Add("@MCQuesId", SqlDbType.Int).Value = li_MCQTestDetail.MCQuesId;
            cmd.Parameters.Add("@Marks", SqlDbType.Decimal).Value = li_MCQTestDetail.Marks;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MCQTestDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MCQTestDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MCQTestDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_MCQTestDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_MCQTestDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
