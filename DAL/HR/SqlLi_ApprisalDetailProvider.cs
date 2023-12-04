using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_ApprisalDetailProvider:DataAccessObject
{
	public SqlLi_ApprisalDetailProvider()
    {
    }


    public bool DeleteLi_ApprisalDetail(int li_ApprisalDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_ApprisalDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AppDeId", SqlDbType.Int).Value = li_ApprisalDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ApprisalDetail> GetAllLi_ApprisalDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_ApprisalDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ApprisalDetailsFromReader(reader);
        }
    }
    public List<Li_ApprisalDetail> GetLi_ApprisalDetailsFromReader(IDataReader reader)
    {
        List<Li_ApprisalDetail> li_ApprisalDetails = new List<Li_ApprisalDetail>();

        while (reader.Read())
        {
            li_ApprisalDetails.Add(GetLi_ApprisalDetailFromReader(reader));
        }
        return li_ApprisalDetails;
    }

    public Li_ApprisalDetail GetLi_ApprisalDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_ApprisalDetail li_ApprisalDetail = new Li_ApprisalDetail
                (
                   
                    (int)reader["AppDeId"],
                    (int)reader["AppId"],
                    (int)reader["CompeId"],
                    (int)reader["EmpSl"],
                    (decimal)reader["Weight"],
                    (decimal)reader["GivenRate"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_ApprisalDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ApprisalDetail GetLi_ApprisalDetailByID(int li_ApprisalDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_ApprisalDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AppDeId", SqlDbType.Int).Value = li_ApprisalDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ApprisalDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ApprisalDetail(Li_ApprisalDetail li_ApprisalDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_ApprisalDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@AppDeId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AppId", SqlDbType.Int).Value = li_ApprisalDetail.AppId;
            cmd.Parameters.Add("@CompeId", SqlDbType.Int).Value = li_ApprisalDetail.CompeId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_ApprisalDetail.EmpSl;
            cmd.Parameters.Add("@Weight", SqlDbType.Decimal).Value = li_ApprisalDetail.Weight;
            cmd.Parameters.Add("@GivenRate", SqlDbType.Decimal).Value = li_ApprisalDetail.GivenRate;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_ApprisalDetail.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ApprisalDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ApprisalDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ApprisalDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ApprisalDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ApprisalDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AppDeId"].Value;
        }
    }

    public bool UpdateLi_ApprisalDetail(Li_ApprisalDetail li_ApprisalDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_ApprisalDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@AppDeId", SqlDbType.Int).Value = li_ApprisalDetail.AppDeId;
            cmd.Parameters.Add("@AppId", SqlDbType.Int).Value = li_ApprisalDetail.AppId;
            cmd.Parameters.Add("@CompeId", SqlDbType.Int).Value = li_ApprisalDetail.CompeId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_ApprisalDetail.EmpSl;
            cmd.Parameters.Add("@Weight", SqlDbType.Decimal).Value = li_ApprisalDetail.Weight;
            cmd.Parameters.Add("@GivenRate", SqlDbType.Decimal).Value = li_ApprisalDetail.GivenRate;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_ApprisalDetail.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ApprisalDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ApprisalDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ApprisalDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ApprisalDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ApprisalDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
