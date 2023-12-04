using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_HRAnnounceDetailProvider:DataAccessObject
{
	public SqlLi_HRAnnounceDetailProvider()
    {
    }


    public bool DeleteLi_HRAnnounceDetail(int li_HRAnnounceDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_HRAnnounceDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AnnDetId", SqlDbType.Int).Value = li_HRAnnounceDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_HRAnnounceDetail> GetAllLi_HRAnnounceDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_HRAnnounceDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_HRAnnounceDetailsFromReader(reader);
        }
    }
    public List<Li_HRAnnounceDetail> GetLi_HRAnnounceDetailsFromReader(IDataReader reader)
    {
        List<Li_HRAnnounceDetail> li_HRAnnounceDetails = new List<Li_HRAnnounceDetail>();

        while (reader.Read())
        {
            li_HRAnnounceDetails.Add(GetLi_HRAnnounceDetailFromReader(reader));
        }
        return li_HRAnnounceDetails;
    }

    public Li_HRAnnounceDetail GetLi_HRAnnounceDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_HRAnnounceDetail li_HRAnnounceDetail = new Li_HRAnnounceDetail
                (
                 
                    (int)reader["AnnDetId"],
                    (int)reader["EmpSl"],
                    (bool)reader["IsPubAllow"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_HRAnnounceDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_HRAnnounceDetail GetLi_HRAnnounceDetailByID(int li_HRAnnounceDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_HRAnnounceDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AnnDetId", SqlDbType.Int).Value = li_HRAnnounceDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_HRAnnounceDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_HRAnnounceDetail(Li_HRAnnounceDetail li_HRAnnounceDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_HRAnnounceDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@AnnDetId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_HRAnnounceDetail.EmpSl;
            cmd.Parameters.Add("@IsPubAllow", SqlDbType.Bit).Value = li_HRAnnounceDetail.IsPubAllow;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_HRAnnounceDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_HRAnnounceDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_HRAnnounceDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_HRAnnounceDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_HRAnnounceDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AnnDetId"].Value;
        }
    }

    public bool UpdateLi_HRAnnounceDetail(Li_HRAnnounceDetail li_HRAnnounceDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_HRAnnounceDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@AnnDetId", SqlDbType.Int).Value = li_HRAnnounceDetail.AnnDetId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_HRAnnounceDetail.EmpSl;
            cmd.Parameters.Add("@IsPubAllow", SqlDbType.Bit).Value = li_HRAnnounceDetail.IsPubAllow;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_HRAnnounceDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_HRAnnounceDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_HRAnnounceDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_HRAnnounceDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_HRAnnounceDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
