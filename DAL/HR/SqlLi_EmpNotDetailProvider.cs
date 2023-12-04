using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_EmpNotDetailProvider:DataAccessObject
{
	public SqlLi_EmpNotDetailProvider()
    {
    }


    public bool DeleteLi_EmpNotDetail(int li_EmpNotDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpNotDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpNotId", SqlDbType.Int).Value = li_EmpNotDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpNotDetail> GetAllLi_EmpNotDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpNotDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpNotDetailsFromReader(reader);
        }
    }
    public List<Li_EmpNotDetail> GetLi_EmpNotDetailsFromReader(IDataReader reader)
    {
        List<Li_EmpNotDetail> li_EmpNotDetails = new List<Li_EmpNotDetail>();

        while (reader.Read())
        {
            li_EmpNotDetails.Add(GetLi_EmpNotDetailFromReader(reader));
        }
        return li_EmpNotDetails;
    }

    public Li_EmpNotDetail GetLi_EmpNotDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpNotDetail li_EmpNotDetail = new Li_EmpNotDetail
                (
                 
                    (int)reader["EmpNotId"],
                    (int)reader["EmpSl"],
                    (int)reader["NotId"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpNotDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpNotDetail GetLi_EmpNotDetailByID(int li_EmpNotDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpNotDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmpNotId", SqlDbType.Int).Value = li_EmpNotDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpNotDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpNotDetail(Li_EmpNotDetail li_EmpNotDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpNotDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@EmpNotId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpNotDetail.EmpSl;
            cmd.Parameters.Add("@NotId", SqlDbType.Int).Value = li_EmpNotDetail.NotId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpNotDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpNotDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpNotDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpNotDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpNotDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmpNotId"].Value;
        }
    }

    public bool UpdateLi_EmpNotDetail(Li_EmpNotDetail li_EmpNotDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpNotDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@EmpNotId", SqlDbType.Int).Value = li_EmpNotDetail.EmpNotId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpNotDetail.EmpSl;
            cmd.Parameters.Add("@NotId", SqlDbType.Int).Value = li_EmpNotDetail.NotId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpNotDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpNotDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpNotDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpNotDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpNotDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
