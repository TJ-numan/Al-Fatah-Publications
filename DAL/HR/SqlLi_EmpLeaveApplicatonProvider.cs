using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpLeaveApplicatonProvider:DataAccessObject
{
	public SqlLi_EmpLeaveApplicatonProvider()
    {
    }


    public bool DeleteLi_EmpLeaveApplicaton(int li_EmpLeaveApplicatonID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpLeaveApplicaton", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeavSl", SqlDbType.Int).Value = li_EmpLeaveApplicatonID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpLeaveApplicaton> GetAllLi_EmpLeaveApplicatons()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpLeaveApplicatons", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpLeaveApplicatonsFromReader(reader);
        }
    }
    public List<Li_EmpLeaveApplicaton> GetLi_EmpLeaveApplicatonsFromReader(IDataReader reader)
    {
        List<Li_EmpLeaveApplicaton> li_EmpLeaveApplicatons = new List<Li_EmpLeaveApplicaton>();

        while (reader.Read())
        {
            li_EmpLeaveApplicatons.Add(GetLi_EmpLeaveApplicatonFromReader(reader));
        }
        return li_EmpLeaveApplicatons;
    }

    public Li_EmpLeaveApplicaton GetLi_EmpLeaveApplicatonFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpLeaveApplicaton li_EmpLeaveApplicaton = new Li_EmpLeaveApplicaton
                (
                 
                    (int)reader["LeavSl"],
                    (int)reader["EmpSl"],
                    (int)reader["LeTypId"],
                    (DateTime)reader["LeStDate"],
                    (DateTime)reader["LeEnDate"],
                    (decimal)reader["LeQty"],
                    (bool)reader["IsDay"],
                    (bool)reader["IsHalfDay"],
                    (bool)reader["IsHour"],
                    reader["LeCause"].ToString(),
                    reader["ConAddNPhone"].ToString(),
                    (int)reader["ResposibleEmpSl"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpLeaveApplicaton;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpLeaveApplicaton GetLi_EmpLeaveApplicatonByID(int li_EmpLeaveApplicatonID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpLeaveApplicatonByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LeavSl", SqlDbType.Int).Value = li_EmpLeaveApplicatonID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpLeaveApplicatonFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpLeaveApplicaton(Li_EmpLeaveApplicaton li_EmpLeaveApplicaton)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpLeaveApplicaton", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@LeavSl", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpLeaveApplicaton.EmpSl;
            cmd.Parameters.Add("@LeTypId", SqlDbType.Int).Value = li_EmpLeaveApplicaton.LeTypId;
            cmd.Parameters.Add("@LeStDate", SqlDbType.DateTime).Value = li_EmpLeaveApplicaton.LeStDate;
            cmd.Parameters.Add("@LeEnDate", SqlDbType.DateTime).Value = li_EmpLeaveApplicaton.LeEnDate;
            cmd.Parameters.Add("@LeQty", SqlDbType.Decimal).Value = li_EmpLeaveApplicaton.LeQty;
            cmd.Parameters.Add("@IsDay", SqlDbType.Bit).Value = li_EmpLeaveApplicaton.IsDay;
            cmd.Parameters.Add("@IsHalfDay", SqlDbType.Bit).Value = li_EmpLeaveApplicaton.IsHalfDay;
            cmd.Parameters.Add("@IsHour", SqlDbType.Bit).Value = li_EmpLeaveApplicaton.IsHour;
            cmd.Parameters.Add("@LeCause", SqlDbType.VarChar).Value = li_EmpLeaveApplicaton.LeCause;
            cmd.Parameters.Add("@ConAddNPhone", SqlDbType.VarChar).Value = li_EmpLeaveApplicaton.ConAddNPhone;
            cmd.Parameters.Add("@ResposibleEmpSl", SqlDbType.Int).Value = li_EmpLeaveApplicaton.ResposibleEmpSl;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpLeaveApplicaton.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpLeaveApplicaton.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpLeaveApplicaton.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpLeaveApplicaton.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpLeaveApplicaton.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LeavSl"].Value;
        }
    }

    public bool UpdateLi_EmpLeaveApplicaton(Li_EmpLeaveApplicaton li_EmpLeaveApplicaton)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpLeaveApplicaton", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@LeavSl", SqlDbType.Int).Value = li_EmpLeaveApplicaton.LeavSl;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpLeaveApplicaton.EmpSl;
            cmd.Parameters.Add("@LeTypId", SqlDbType.Int).Value = li_EmpLeaveApplicaton.LeTypId;
            cmd.Parameters.Add("@LeStDate", SqlDbType.DateTime).Value = li_EmpLeaveApplicaton.LeStDate;
            cmd.Parameters.Add("@LeEnDate", SqlDbType.DateTime).Value = li_EmpLeaveApplicaton.LeEnDate;
            cmd.Parameters.Add("@LeQty", SqlDbType.Decimal).Value = li_EmpLeaveApplicaton.LeQty;
            cmd.Parameters.Add("@IsDay", SqlDbType.Bit).Value = li_EmpLeaveApplicaton.IsDay;
            cmd.Parameters.Add("@IsHalfDay", SqlDbType.Bit).Value = li_EmpLeaveApplicaton.IsHalfDay;
            cmd.Parameters.Add("@IsHour", SqlDbType.Bit).Value = li_EmpLeaveApplicaton.IsHour;
            cmd.Parameters.Add("@LeCause", SqlDbType.VarChar).Value = li_EmpLeaveApplicaton.LeCause;
            cmd.Parameters.Add("@ConAddNPhone", SqlDbType.VarChar).Value = li_EmpLeaveApplicaton.ConAddNPhone;
            cmd.Parameters.Add("@ResposibleEmpSl", SqlDbType.Int).Value = li_EmpLeaveApplicaton.ResposibleEmpSl;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpLeaveApplicaton.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpLeaveApplicaton.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpLeaveApplicaton.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpLeaveApplicaton.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpLeaveApplicaton.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
