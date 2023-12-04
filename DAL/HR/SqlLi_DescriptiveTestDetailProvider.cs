using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_DescriptiveTestDetailProvider:DataAccessObject
{
	public SqlLi_DescriptiveTestDetailProvider()
    {
    }


    public bool DeleteLi_DescriptiveTestDetail(int li_DescriptiveTestDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_DescriptiveTestDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DesTestDeId", SqlDbType.Int).Value = li_DescriptiveTestDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DescriptiveTestDetail> GetAllLi_DescriptiveTestDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_DescriptiveTestDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DescriptiveTestDetailsFromReader(reader);
        }
    }
    public List<Li_DescriptiveTestDetail> GetLi_DescriptiveTestDetailsFromReader(IDataReader reader)
    {
        List<Li_DescriptiveTestDetail> li_DescriptiveTestDetails = new List<Li_DescriptiveTestDetail>();

        while (reader.Read())
        {
            li_DescriptiveTestDetails.Add(GetLi_DescriptiveTestDetailFromReader(reader));
        }
        return li_DescriptiveTestDetails;
    }

    public Li_DescriptiveTestDetail GetLi_DescriptiveTestDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_DescriptiveTestDetail li_DescriptiveTestDetail = new Li_DescriptiveTestDetail
                (
                    
                    (int)reader["DesTestDeId"],
                    (int)reader["TestId"],
                    (int)reader["DesQuesId"],
                    (decimal)reader["Marks"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_DescriptiveTestDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_DescriptiveTestDetail GetLi_DescriptiveTestDetailByID(int li_DescriptiveTestDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_DescriptiveTestDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DesTestDeId", SqlDbType.Int).Value = li_DescriptiveTestDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DescriptiveTestDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DescriptiveTestDetail(Li_DescriptiveTestDetail li_DescriptiveTestDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_DescriptiveTestDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@DesTestDeId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TestId", SqlDbType.Int).Value = li_DescriptiveTestDetail.TestId;
            cmd.Parameters.Add("@DesQuesId", SqlDbType.Int).Value = li_DescriptiveTestDetail.DesQuesId;
            cmd.Parameters.Add("@Marks", SqlDbType.Decimal).Value = li_DescriptiveTestDetail.Marks;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DescriptiveTestDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DescriptiveTestDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_DescriptiveTestDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_DescriptiveTestDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_DescriptiveTestDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DesTestDeId"].Value;
        }
    }

    public bool UpdateLi_DescriptiveTestDetail(Li_DescriptiveTestDetail li_DescriptiveTestDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_DescriptiveTestDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@DesTestDeId", SqlDbType.Int).Value = li_DescriptiveTestDetail.DesTestDeId;
            cmd.Parameters.Add("@TestId", SqlDbType.Int).Value = li_DescriptiveTestDetail.TestId;
            cmd.Parameters.Add("@DesQuesId", SqlDbType.Int).Value = li_DescriptiveTestDetail.DesQuesId;
            cmd.Parameters.Add("@Marks", SqlDbType.Decimal).Value = li_DescriptiveTestDetail.Marks;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DescriptiveTestDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DescriptiveTestDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_DescriptiveTestDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_DescriptiveTestDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_DescriptiveTestDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
