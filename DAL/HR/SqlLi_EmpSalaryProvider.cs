using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpSalaryProvider:DataAccessObject
{
	public SqlLi_EmpSalaryProvider()
    {
    }


    public bool DeleteLi_EmpSalary(int li_EmpSalaryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpSalary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalId", SqlDbType.Int).Value = li_EmpSalaryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpSalary> GetAllLi_EmpSalaries()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpSalaries", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpSalariesFromReader(reader);
        }
    }
    public List<Li_EmpSalary> GetLi_EmpSalariesFromReader(IDataReader reader)
    {
        List<Li_EmpSalary> li_EmpSalaries = new List<Li_EmpSalary>();

        while (reader.Read())
        {
            li_EmpSalaries.Add(GetLi_EmpSalaryFromReader(reader));
        }
        return li_EmpSalaries;
    }

    public Li_EmpSalary GetLi_EmpSalaryFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpSalary li_EmpSalary = new Li_EmpSalary
                (
                     (int)reader["SalId"],
                    (int)reader["EmpSl"],
                    (int)reader["PayGrId"],
                    (int)reader["PScId"],
                    (decimal)reader["EPF"],
                    (decimal)reader["CompanyCost"],
                    (decimal)reader["DeductionAmt"],
                    (decimal)reader["PayableAmt"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpSalary;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpSalary GetLi_EmpSalaryByID(int li_EmpSalaryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpSalaryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalId", SqlDbType.Int).Value = li_EmpSalaryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpSalaryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpSalary(Li_EmpSalary li_EmpSalary)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpSalary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@SalId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpSalary.EmpSl;
            cmd.Parameters.Add("@PayGrId", SqlDbType.Int).Value = li_EmpSalary.PayGrId;
            cmd.Parameters.Add("@PScId", SqlDbType.Int).Value = li_EmpSalary.PScId;
            cmd.Parameters.Add("@EPF", SqlDbType.Decimal).Value = li_EmpSalary.EPF;
            cmd.Parameters.Add("@CompanyCost", SqlDbType.Decimal).Value = li_EmpSalary.CompanyCost;
            cmd.Parameters.Add("@DeductionAmt", SqlDbType.Decimal).Value = li_EmpSalary.DeductionAmt;
            cmd.Parameters.Add("@PayableAmt", SqlDbType.Decimal).Value = li_EmpSalary.PayableAmt;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpSalary.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpSalary.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpSalary.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpSalary.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpSalary.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpSalary.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalId"].Value;
        }
    }

    public bool UpdateLi_EmpSalary(Li_EmpSalary li_EmpSalary)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpSalary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@SalId", SqlDbType.Int).Value = li_EmpSalary.SalId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpSalary.EmpSl;
            cmd.Parameters.Add("@PayGrId", SqlDbType.Int).Value = li_EmpSalary.PayGrId;
            cmd.Parameters.Add("@PScId", SqlDbType.Int).Value = li_EmpSalary.PScId;
            cmd.Parameters.Add("@EPF", SqlDbType.Decimal).Value = li_EmpSalary.EPF;
            cmd.Parameters.Add("@CompanyCost", SqlDbType.Decimal).Value = li_EmpSalary.CompanyCost;
            cmd.Parameters.Add("@DeductionAmt", SqlDbType.Decimal).Value = li_EmpSalary.DeductionAmt;
            cmd.Parameters.Add("@PayableAmt", SqlDbType.Decimal).Value = li_EmpSalary.PayableAmt;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpSalary.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpSalary.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpSalary.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpSalary.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpSalary.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpSalary.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataTable LoadGvEmployeeSalary()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadGvEmpSalary", connection);
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
