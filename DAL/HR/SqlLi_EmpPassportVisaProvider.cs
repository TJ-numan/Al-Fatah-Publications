using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
public class SqlLi_EmpPassportVisaProvider:DataAccessObject
{
	public SqlLi_EmpPassportVisaProvider()
    {
    }


    public bool DeleteLi_EmpPassportVisa(int li_EmpPassportVisaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpPassportVisa", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaViId", SqlDbType.Int).Value = li_EmpPassportVisaID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpPassportVisa> GetAllLi_EmpPassportVisas()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpPassportVisas", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpPassportVisasFromReader(reader);
        }
    }
    public List<Li_EmpPassportVisa> GetLi_EmpPassportVisasFromReader(IDataReader reader)
    {
        List<Li_EmpPassportVisa> li_EmpPassportVisas = new List<Li_EmpPassportVisa>();

        while (reader.Read())
        {
            li_EmpPassportVisas.Add(GetLi_EmpPassportVisaFromReader(reader));
        }
        return li_EmpPassportVisas;
    }

    public Li_EmpPassportVisa GetLi_EmpPassportVisaFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpPassportVisa li_EmpPassportVisa = new Li_EmpPassportVisa
                (
                   
                    (int)reader["PaViId"],
                    reader["PaViNo"].ToString(),
                    (int)reader["EmpSl"],
                    reader["PassOrVisa"].ToString(),
                    reader["IssuedBy"].ToString(),
                    (DateTime)reader["IssueDate"],
                    (DateTime)reader["ExpiryDate"],
                    (DateTime)reader["EligibleReviewDate"],
                    reader["EligibleStatus"].ToString(),
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpPassportVisa;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpPassportVisa GetLi_EmpPassportVisaByID(int li_EmpPassportVisaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpPassportVisaByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PaViId", SqlDbType.Int).Value = li_EmpPassportVisaID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpPassportVisaFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpPassportVisa(Li_EmpPassportVisa li_EmpPassportVisa)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpPassportVisa", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaViId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PaViNo", SqlDbType.VarChar).Value = li_EmpPassportVisa.PaViNo;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpPassportVisa.EmpSl;
            cmd.Parameters.Add("@PassOrVisa", SqlDbType.VarChar).Value = li_EmpPassportVisa.PassOrVisa;
            cmd.Parameters.Add("@IssuedBy", SqlDbType.VarChar).Value = li_EmpPassportVisa.IssuedBy;
            cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = li_EmpPassportVisa.IssueDate;
            cmd.Parameters.Add("@ExpiryDate", SqlDbType.DateTime).Value = li_EmpPassportVisa.ExpiryDate;
            cmd.Parameters.Add("@EligibleReviewDate", SqlDbType.DateTime).Value = li_EmpPassportVisa.EligibleReviewDate;
            cmd.Parameters.Add("@EligibleStatus", SqlDbType.VarChar).Value = li_EmpPassportVisa.EligibleStatus;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpPassportVisa.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpPassportVisa.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpPassportVisa.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpPassportVisa.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpPassportVisa.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpPassportVisa.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PaViId"].Value;
        }
    }

    public bool UpdateLi_EmpPassportVisa(Li_EmpPassportVisa li_EmpPassportVisa)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpPassportVisa", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@PaViId", SqlDbType.Int).Value = li_EmpPassportVisa.PaViId;
            cmd.Parameters.Add("@PaViNo", SqlDbType.VarChar).Value = li_EmpPassportVisa.PaViNo;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpPassportVisa.EmpSl;
            cmd.Parameters.Add("@PassOrVisa", SqlDbType.VarChar).Value = li_EmpPassportVisa.PassOrVisa;
            cmd.Parameters.Add("@IssuedBy", SqlDbType.VarChar).Value = li_EmpPassportVisa.IssuedBy;
            cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = li_EmpPassportVisa.IssueDate;
            cmd.Parameters.Add("@ExpiryDate", SqlDbType.DateTime).Value = li_EmpPassportVisa.ExpiryDate;
            cmd.Parameters.Add("@EligibleReviewDate", SqlDbType.DateTime).Value = li_EmpPassportVisa.EligibleReviewDate;
            cmd.Parameters.Add("@EligibleStatus", SqlDbType.VarChar).Value = li_EmpPassportVisa.EligibleStatus;
            cmd.Parameters.Add("@Comments", SqlDbType.DateTime).Value = li_EmpPassportVisa.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpPassportVisa.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpPassportVisa.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpPassportVisa.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpPassportVisa.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpPassportVisa.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataTable LoadGvEmployeePassport()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadGvEmpPassport", connection);
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
