using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperReturnProvider: DataAccessObject
{
    public SqlLi_PaperReturnProvider()
    {
    }
    public bool DeleteLi_PaperReturn(int li_PaperReturnID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperReturnID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperReturnID", SqlDbType.Int).Value = li_PaperReturnID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperReturn> GetAllLi_PaperReturn()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperReturn", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperReturnFromReader(reader);
        }
    }
    public List<Li_PaperReturn> GetLi_PaperReturnFromReader(IDataReader reader)
    {
        List<Li_PaperReturn> li_PaperReturn = new List<Li_PaperReturn>();

        while (reader.Read())
        {
            li_PaperReturn.Add(GetLi_PaperReturnsFromReader(reader));
        }
        return li_PaperReturn;
    }

    public Li_PaperReturn GetLi_PaperReturnsFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperReturn li_PaperReturn = new Li_PaperReturn
                (
              
                    (int)reader["RetNo"],
                    (DateTime)reader["RetDate"],
                    reader["PrssFrom"].ToString(),
                    reader["PressTo"].ToString(),
                    (decimal)reader["TotalBill"],
                    (decimal)reader["LabourBill"],
                    reader["Remark"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["ModifiedBy"],
                    (char)reader["Status_D"],
                    (int)reader["DeletBy"],
                    (DateTime)reader["DeleteDate"],
                    reader["CauseOFDel"].ToString() 
                );
            return li_PaperReturn;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PaperReturn GetLi_PaperReturnID(int li_PaperReturnID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperReturnByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PaperReturnID", SqlDbType.Int).Value = li_PaperReturnID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PaperReturnsFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PaperReturn(Li_PaperReturn li_PaperReturn)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperReturn", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@RetNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RetDate", SqlDbType.DateTime).Value = li_PaperReturn.RetDate;
            cmd.Parameters.Add("@PrssFrom", SqlDbType.VarChar).Value = li_PaperReturn.PrssFrom;
            cmd.Parameters.Add("@SupplTo", SqlDbType.VarChar).Value = li_PaperReturn.SupplTo;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PaperReturn.TotalBill;
            cmd.Parameters.Add("@LabourBill", SqlDbType.Decimal).Value = li_PaperReturn.LabourBill;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PaperReturn.Remark;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperReturn.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperReturn.CreatedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PaperReturn.ModifiedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PaperReturn.ModifiedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PaperReturn.Status_D;
            cmd.Parameters.Add("@DeletBy", SqlDbType.Int).Value =  DBNull .Value ;
            cmd.Parameters.Add("@DeleteDate", SqlDbType.DateTime).Value =  DBNull .Value ;
            cmd.Parameters.Add("@CauseOFDel", SqlDbType.VarChar).Value = DBNull .Value ;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RetNo"].Value;
        }
    }

    public bool UpdateLi_PaperReturn(Li_PaperReturn li_PaperReturn)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperReturn", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = li_PaperReturn.RetNo;
            cmd.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = li_PaperReturn.RetDate;
            cmd.Parameters.Add("@PrssFrom", SqlDbType.VarChar).Value = li_PaperReturn.PrssFrom;
            cmd.Parameters.Add("@SupplTo", SqlDbType.VarChar).Value = li_PaperReturn.SupplTo;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PaperReturn.TotalBill;
            cmd.Parameters.Add("@LabourBill", SqlDbType.Decimal).Value = li_PaperReturn.LabourBill;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PaperReturn.Remark;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperReturn.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperReturn.CreatedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PaperReturn.ModifiedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PaperReturn.ModifiedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PaperReturn.Status_D;
            cmd.Parameters.Add("@DeletBy", SqlDbType.Int).Value = li_PaperReturn.DeletBy;
            cmd.Parameters.Add("@DeleteDate", SqlDbType.DateTime).Value = li_PaperReturn.DeleteDate;
            cmd.Parameters.Add("@CauseOFDel", SqlDbType.VarChar).Value = li_PaperReturn.CauseOFDel;
  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

