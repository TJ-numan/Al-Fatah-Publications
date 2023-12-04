using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpMembershipProvider:DataAccessObject
{
	public SqlLi_EmpMembershipProvider()
    {
    }


    public bool DeleteLi_EmpMembership(int li_EmpMembershipID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpMembership", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemId", SqlDbType.Int).Value = li_EmpMembershipID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpMembership> GetAllLi_EmpMemberships()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpMemberships", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpMembershipsFromReader(reader);
        }
    }
    public List<Li_EmpMembership> GetLi_EmpMembershipsFromReader(IDataReader reader)
    {
        List<Li_EmpMembership> li_EmpMemberships = new List<Li_EmpMembership>();

        while (reader.Read())
        {
            li_EmpMemberships.Add(GetLi_EmpMembershipFromReader(reader));
        }
        return li_EmpMemberships;
    }

    public Li_EmpMembership GetLi_EmpMembershipFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpMembership li_EmpMembership = new Li_EmpMembership
                (
                    
                    (int)reader["MemId"],
                    (int)reader["EmpSl"],
                    reader["Membership"].ToString(),
                    reader["SubPaidBy"].ToString(),
                    reader["SubsFee"].ToString(),
                    reader["Currency"].ToString(),
                    (DateTime)reader["SubsCommenceDate"],
                    (DateTime)reader["SubsReDate"],
                    reader["MemDes"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpMembership;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpMembership GetLi_EmpMembershipByID(int li_EmpMembershipID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpMembershipByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MemId", SqlDbType.Int).Value = li_EmpMembershipID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpMembershipFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpMembership(Li_EmpMembership li_EmpMembership)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpMembership", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@MemId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpMembership.EmpSl;
            cmd.Parameters.Add("@Membership", SqlDbType.VarChar).Value = li_EmpMembership.Membership;
            cmd.Parameters.Add("@SubPaidBy", SqlDbType.VarChar).Value = li_EmpMembership.SubPaidBy;
            cmd.Parameters.Add("@SubsFee", SqlDbType.NChar).Value = li_EmpMembership.SubsFee;
            cmd.Parameters.Add("@Currency", SqlDbType.VarChar).Value = li_EmpMembership.Currency;
            cmd.Parameters.Add("@SubsCommenceDate", SqlDbType.DateTime).Value = li_EmpMembership.SubsCommenceDate;
            cmd.Parameters.Add("@SubsReDate", SqlDbType.DateTime).Value = li_EmpMembership.SubsReDate;
            cmd.Parameters.Add("@MemDes", SqlDbType.VarChar).Value = li_EmpMembership.MemDes;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpMembership.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpMembership.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpMembership.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpMembership.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpMembership.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MemId"].Value;
        }
    }

    public bool UpdateLi_EmpMembership(Li_EmpMembership li_EmpMembership)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpMembership", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@MemId", SqlDbType.Int).Value = li_EmpMembership.MemId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpMembership.EmpSl;
            cmd.Parameters.Add("@Membership", SqlDbType.VarChar).Value = li_EmpMembership.Membership;
            cmd.Parameters.Add("@SubPaidBy", SqlDbType.VarChar).Value = li_EmpMembership.SubPaidBy;
            cmd.Parameters.Add("@SubsFee", SqlDbType.NChar).Value = li_EmpMembership.SubsFee;
            cmd.Parameters.Add("@Currency", SqlDbType.VarChar).Value = li_EmpMembership.Currency;
            cmd.Parameters.Add("@SubsCommenceDate", SqlDbType.DateTime).Value = li_EmpMembership.SubsCommenceDate;
            cmd.Parameters.Add("@SubsReDate", SqlDbType.DateTime).Value = li_EmpMembership.SubsReDate;
            cmd.Parameters.Add("@MemDes", SqlDbType.VarChar).Value = li_EmpMembership.MemDes;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpMembership.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpMembership.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpMembership.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpMembership.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpMembership.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataTable LoadGvEmployeeMembership()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadGvEmployeeMembership", connection);
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
