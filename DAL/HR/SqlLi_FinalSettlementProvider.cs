using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_FinalSettlementProvider:DataAccessObject
{
	public SqlLi_FinalSettlementProvider()
    {
    }


    public bool DeleteLi_FinalSettlement(int li_FinalSettlementID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_FinalSettlement", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FiSetId", SqlDbType.Int).Value = li_FinalSettlementID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_FinalSettlement> GetAllLi_FinalSettlements()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_FinalSettlements", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_FinalSettlementsFromReader(reader);
        }
    }
    public List<Li_FinalSettlement> GetLi_FinalSettlementsFromReader(IDataReader reader)
    {
        List<Li_FinalSettlement> li_FinalSettlements = new List<Li_FinalSettlement>();

        while (reader.Read())
        {
            li_FinalSettlements.Add(GetLi_FinalSettlementFromReader(reader));
        }
        return li_FinalSettlements;
    }

    public Li_FinalSettlement GetLi_FinalSettlementFromReader(IDataReader reader)
    {
        try
        {
            Li_FinalSettlement li_FinalSettlement = new Li_FinalSettlement
                (
                    
                    (int)reader["FiSetId"],
                    (int)reader["EmpSl"],
                    (int)reader["EmploymentStId"],
                    (DateTime)reader["DoJ"],
                    (DateTime)reader["EoS"],
                    reader["Comments"].ToString(),
                    reader["NOCPath"].ToString(),
                    reader["ResPath"].ToString(),
                    (decimal)reader["EPOF"],
                    (decimal)reader["Gratuity"],
                    (bool)reader["IsAssetClear"],
                    (bool)reader["IsDepClear"],
                    (decimal)reader["Loan"],
                    (decimal)reader["OthAmt"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_FinalSettlement;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_FinalSettlement GetLi_FinalSettlementByID(int li_FinalSettlementID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_FinalSettlementByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FiSetId", SqlDbType.Int).Value = li_FinalSettlementID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_FinalSettlementFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_FinalSettlement(Li_FinalSettlement li_FinalSettlement)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_FinalSettlement", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@FiSetId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_FinalSettlement.EmpSl;
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_FinalSettlement.EmploymentStId;
            cmd.Parameters.Add("@DoJ", SqlDbType.DateTime).Value = li_FinalSettlement.DoJ;
            cmd.Parameters.Add("@EoS", SqlDbType.DateTime).Value = li_FinalSettlement.EoS;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_FinalSettlement.Comments;
            cmd.Parameters.Add("@NOCPath", SqlDbType.VarChar).Value = li_FinalSettlement.NOCPath;
            cmd.Parameters.Add("@ResPath", SqlDbType.VarChar).Value = li_FinalSettlement.ResPath;
            cmd.Parameters.Add("@EPOF", SqlDbType.Decimal).Value = li_FinalSettlement.EPOF;
            cmd.Parameters.Add("@Gratuity", SqlDbType.Decimal).Value = li_FinalSettlement.Gratuity;
            cmd.Parameters.Add("@IsAssetClear", SqlDbType.Bit).Value = li_FinalSettlement.IsAssetClear;
            cmd.Parameters.Add("@IsDepClear", SqlDbType.Bit).Value = li_FinalSettlement.IsDepClear;
            cmd.Parameters.Add("@Loan", SqlDbType.Decimal).Value = li_FinalSettlement.Loan;
            cmd.Parameters.Add("@OthAmt", SqlDbType.Decimal).Value = li_FinalSettlement.OthAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_FinalSettlement.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_FinalSettlement.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_FinalSettlement.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_FinalSettlement.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_FinalSettlement.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@FiSetId"].Value;
        }
    }

    public bool UpdateLi_FinalSettlement(Li_FinalSettlement li_FinalSettlement)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_FinalSettlement", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@FiSetId", SqlDbType.Int).Value = li_FinalSettlement.FiSetId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_FinalSettlement.EmpSl;
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_FinalSettlement.EmploymentStId;
            cmd.Parameters.Add("@DoJ", SqlDbType.DateTime).Value = li_FinalSettlement.DoJ;
            cmd.Parameters.Add("@EoS", SqlDbType.DateTime).Value = li_FinalSettlement.EoS;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_FinalSettlement.Comments;
            cmd.Parameters.Add("@NOCPath", SqlDbType.VarChar).Value = li_FinalSettlement.NOCPath;
            cmd.Parameters.Add("@ResPath", SqlDbType.VarChar).Value = li_FinalSettlement.ResPath;
            cmd.Parameters.Add("@EPOF", SqlDbType.Decimal).Value = li_FinalSettlement.EPOF;
            cmd.Parameters.Add("@Gratuity", SqlDbType.Decimal).Value = li_FinalSettlement.Gratuity;
            cmd.Parameters.Add("@IsAssetClear", SqlDbType.Bit).Value = li_FinalSettlement.IsAssetClear;
            cmd.Parameters.Add("@IsDepClear", SqlDbType.Bit).Value = li_FinalSettlement.IsDepClear;
            cmd.Parameters.Add("@Loan", SqlDbType.Decimal).Value = li_FinalSettlement.Loan;
            cmd.Parameters.Add("@OthAmt", SqlDbType.Decimal).Value = li_FinalSettlement.OthAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_FinalSettlement.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_FinalSettlement.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_FinalSettlement.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_FinalSettlement.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_FinalSettlement.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
