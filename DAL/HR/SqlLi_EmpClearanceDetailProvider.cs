using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpClearanceDetailProvider:DataAccessObject
{
	public SqlLi_EmpClearanceDetailProvider()
    {
    }


    public bool DeleteLi_EmpClearanceDetail(int li_EmpClearanceDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpClearanceDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClearDetId", SqlDbType.Int).Value = li_EmpClearanceDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpClearanceDetail> GetAllLi_EmpClearanceDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpClearanceDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpClearanceDetailsFromReader(reader);
        }
    }
    public List<Li_EmpClearanceDetail> GetLi_EmpClearanceDetailsFromReader(IDataReader reader)
    {
        List<Li_EmpClearanceDetail> li_EmpClearanceDetails = new List<Li_EmpClearanceDetail>();

        while (reader.Read())
        {
            li_EmpClearanceDetails.Add(GetLi_EmpClearanceDetailFromReader(reader));
        }
        return li_EmpClearanceDetails;
    }

    public Li_EmpClearanceDetail GetLi_EmpClearanceDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpClearanceDetail li_EmpClearanceDetail = new Li_EmpClearanceDetail
                (
                    
                    (int)reader["ClearDetId"],
                    (int)reader["ClearId"],
                    (int)reader["DepId"],
                    (int)reader["AthorizedId"],
                    reader["DepComments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpClearanceDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpClearanceDetail GetLi_EmpClearanceDetailByID(int li_EmpClearanceDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpClearanceDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClearDetId", SqlDbType.Int).Value = li_EmpClearanceDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpClearanceDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpClearanceDetail(Li_EmpClearanceDetail li_EmpClearanceDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpClearanceDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@ClearDetId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClearId", SqlDbType.Int).Value = li_EmpClearanceDetail.ClearId;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_EmpClearanceDetail.DepId;
            cmd.Parameters.Add("@AthorizedId", SqlDbType.Int).Value = li_EmpClearanceDetail.AthorizedId;
            cmd.Parameters.Add("@DepComments", SqlDbType.VarChar).Value = li_EmpClearanceDetail.DepComments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpClearanceDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpClearanceDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpClearanceDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpClearanceDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpClearanceDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClearDetId"].Value;
        }
    }

    public bool UpdateLi_EmpClearanceDetail(Li_EmpClearanceDetail li_EmpClearanceDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpClearanceDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@ClearDetId", SqlDbType.Int).Value = li_EmpClearanceDetail.ClearDetId;
            cmd.Parameters.Add("@ClearId", SqlDbType.Int).Value = li_EmpClearanceDetail.ClearId;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_EmpClearanceDetail.DepId;
            cmd.Parameters.Add("@AthorizedId", SqlDbType.Int).Value = li_EmpClearanceDetail.AthorizedId;
            cmd.Parameters.Add("@DepComments", SqlDbType.VarChar).Value = li_EmpClearanceDetail.DepComments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpClearanceDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpClearanceDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpClearanceDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpClearanceDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpClearanceDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
