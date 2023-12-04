using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_EmpIncrePromoTranProvider:DataAccessObject
{
	public SqlLi_EmpIncrePromoTranProvider()
    {
    }


    public bool DeleteLi_EmpIncrePromoTran(int li_EmpIncrePromoTranID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpIncrePromoTran", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InPrTrId", SqlDbType.Int).Value = li_EmpIncrePromoTranID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpIncrePromoTran> GetAllLi_EmpIncrePromoTrans()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpIncrePromoTrans", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpIncrePromoTransFromReader(reader);
        }
    }
    public List<Li_EmpIncrePromoTran> GetLi_EmpIncrePromoTransFromReader(IDataReader reader)
    {
        List<Li_EmpIncrePromoTran> li_EmpIncrePromoTrans = new List<Li_EmpIncrePromoTran>();

        while (reader.Read())
        {
            li_EmpIncrePromoTrans.Add(GetLi_EmpIncrePromoTranFromReader(reader));
        }
        return li_EmpIncrePromoTrans;
    }

    public Li_EmpIncrePromoTran GetLi_EmpIncrePromoTranFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpIncrePromoTran li_EmpIncrePromoTran = new Li_EmpIncrePromoTran
                (
                  
                    (int)reader["InPrTrId"],
                    (int)reader["EmpSl"],
                    (int)reader["PreDepId"],
                    (int)reader["PreDesId"],
                    (int)reader["PreSecId"],
                    (int)reader["PrePayGrId"],
                    (int)reader["PrePScId"],
                    (int)reader["EmploymentStId"],
                    reader["Comments"].ToString(),
                    (int)reader["CurDepId"],
                    (int)reader["CurDesId"],
                    (int)reader["CurSecId"],
                    (int)reader["CurPayGrId"],
                    (int)reader["CurPScId"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpIncrePromoTran;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpIncrePromoTran GetLi_EmpIncrePromoTranByID(int li_EmpIncrePromoTranID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpIncrePromoTranByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@InPrTrId", SqlDbType.Int).Value = li_EmpIncrePromoTranID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpIncrePromoTranFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpIncrePromoTran(Li_EmpIncrePromoTran li_EmpIncrePromoTran)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpIncrePromoTran", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@InPrTrId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpIncrePromoTran.EmpSl;
            cmd.Parameters.Add("@PreDepId", SqlDbType.Int).Value = li_EmpIncrePromoTran.PreDepId;
            cmd.Parameters.Add("@PreDesId", SqlDbType.Int).Value = li_EmpIncrePromoTran.PreDesId;
            cmd.Parameters.Add("@PreSecId", SqlDbType.Int).Value = li_EmpIncrePromoTran.PreSecId;
            cmd.Parameters.Add("@PrePayGrId", SqlDbType.Int).Value = li_EmpIncrePromoTran.PrePayGrId;
            cmd.Parameters.Add("@PrePScId", SqlDbType.Int).Value = li_EmpIncrePromoTran.PrePScId;
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_EmpIncrePromoTran.EmploymentStId;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpIncrePromoTran.Comments;
            cmd.Parameters.Add("@CurDepId", SqlDbType.Int).Value = li_EmpIncrePromoTran.CurDepId;
            cmd.Parameters.Add("@CurDesId", SqlDbType.Int).Value = li_EmpIncrePromoTran.CurDesId;
            cmd.Parameters.Add("@CurSecId", SqlDbType.Int).Value = li_EmpIncrePromoTran.CurSecId;
            cmd.Parameters.Add("@CurPayGrId", SqlDbType.Int).Value = li_EmpIncrePromoTran.CurPayGrId;
            cmd.Parameters.Add("@CurPScId", SqlDbType.Int).Value = li_EmpIncrePromoTran.CurPScId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpIncrePromoTran.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpIncrePromoTran.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpIncrePromoTran.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpIncrePromoTran.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpIncrePromoTran.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@InPrTrId"].Value;
        }
    }

    public bool UpdateLi_EmpIncrePromoTran(Li_EmpIncrePromoTran li_EmpIncrePromoTran)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpIncrePromoTran", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@InPrTrId", SqlDbType.Int).Value = li_EmpIncrePromoTran.InPrTrId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpIncrePromoTran.EmpSl;
            cmd.Parameters.Add("@PreDepId", SqlDbType.Int).Value = li_EmpIncrePromoTran.PreDepId;
            cmd.Parameters.Add("@PreDesId", SqlDbType.Int).Value = li_EmpIncrePromoTran.PreDesId;
            cmd.Parameters.Add("@PreSecId", SqlDbType.Int).Value = li_EmpIncrePromoTran.PreSecId;
            cmd.Parameters.Add("@PrePayGrId", SqlDbType.Int).Value = li_EmpIncrePromoTran.PrePayGrId;
            cmd.Parameters.Add("@PrePScId", SqlDbType.Int).Value = li_EmpIncrePromoTran.PrePScId;
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_EmpIncrePromoTran.EmploymentStId;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpIncrePromoTran.Comments;
            cmd.Parameters.Add("@CurDepId", SqlDbType.Int).Value = li_EmpIncrePromoTran.CurDepId;
            cmd.Parameters.Add("@CurDesId", SqlDbType.Int).Value = li_EmpIncrePromoTran.CurDesId;
            cmd.Parameters.Add("@CurSecId", SqlDbType.Int).Value = li_EmpIncrePromoTran.CurSecId;
            cmd.Parameters.Add("@CurPayGrId", SqlDbType.Int).Value = li_EmpIncrePromoTran.CurPayGrId;
            cmd.Parameters.Add("@CurPScId", SqlDbType.Int).Value = li_EmpIncrePromoTran.CurPScId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpIncrePromoTran.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpIncrePromoTran.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpIncrePromoTran.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpIncrePromoTran.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpIncrePromoTran.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
