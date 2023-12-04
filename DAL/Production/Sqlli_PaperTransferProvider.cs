using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperTransferProvider:DataAccessObject
{
	public SqlLi_PaperTransferProvider()
    {
    }


    public bool DeleteLi_PaperTransfer(int li_PaperTransferID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperTransfer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperTransferID", SqlDbType.Int).Value = li_PaperTransferID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperTransfer> GetAllLi_PaperTransfers()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperTransfers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperTransfersFromReader(reader);
        }
    }
    public List<Li_PaperTransfer> GetLi_PaperTransfersFromReader(IDataReader reader)
    {
        List<Li_PaperTransfer> li_PaperTransfers = new List<Li_PaperTransfer>();

        while (reader.Read())
        {
            li_PaperTransfers.Add(GetLi_PaperTransferFromReader(reader));
        }
        return li_PaperTransfers;
    }

    public Li_PaperTransfer GetLi_PaperTransferFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperTransfer li_PaperTransfer = new Li_PaperTransfer
                (
              
                    (int)reader["TransNo"],
                    reader["RefNo"].ToString(),
                    (DateTime)reader["TransDate"],
                    reader["PrssFrom"].ToString(),
                    reader["PressTo"].ToString(),
                    (decimal)reader["TotalBill"],
                    (decimal)reader["LabourBill"],
                    reader["Remark"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Status_D"],
                    (int)reader["DeletBy"],
                    (DateTime)reader["DeleteDate"],
                    reader["CauseOFDel"].ToString() 
                );
             return li_PaperTransfer;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PaperTransfer GetLi_PaperTransferByID(int li_PaperTransferID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperTransferByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PaperTransferID", SqlDbType.Int).Value = li_PaperTransferID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PaperTransferFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PaperTransfer(Li_PaperTransfer li_PaperTransfer)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperTransfer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@TransNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_PaperTransfer.RefNo;
            cmd.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = li_PaperTransfer.TransDate;
            cmd.Parameters.Add("@PrssFrom", SqlDbType.VarChar).Value = li_PaperTransfer.PrssFrom;
            cmd.Parameters.Add("@PressTo", SqlDbType.VarChar).Value = li_PaperTransfer.PressTo;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PaperTransfer.TotalBill;
            cmd.Parameters.Add("@LabourBill", SqlDbType.Decimal).Value = li_PaperTransfer.LabourBill;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PaperTransfer.Remark;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperTransfer.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperTransfer.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PaperTransfer.Status_D;
            cmd.Parameters.Add("@DeletBy", SqlDbType.Int).Value =  DBNull .Value ;
            cmd.Parameters.Add("@DeleteDate", SqlDbType.DateTime).Value =  DBNull .Value ;
            cmd.Parameters.Add("@CauseOFDel", SqlDbType.VarChar).Value = DBNull .Value ;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TransNo"].Value;
        }
    }

    public bool UpdateLi_PaperTransfer(Li_PaperTransfer li_PaperTransfer)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperTransfer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = li_PaperTransfer.TransNo;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_PaperTransfer.RefNo;
            cmd.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = li_PaperTransfer.TransDate;
            cmd.Parameters.Add("@PrssFrom", SqlDbType.VarChar).Value = li_PaperTransfer.PrssFrom;
            cmd.Parameters.Add("@PressTo", SqlDbType.VarChar).Value = li_PaperTransfer.PressTo;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PaperTransfer.TotalBill;
            cmd.Parameters.Add("@LabourBill", SqlDbType.Decimal).Value = li_PaperTransfer.LabourBill;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PaperTransfer.Remark;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperTransfer.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperTransfer.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PaperTransfer.Status_D;
            cmd.Parameters.Add("@DeletBy", SqlDbType.Int).Value = li_PaperTransfer.DeletBy;
            cmd.Parameters.Add("@DeleteDate", SqlDbType.DateTime).Value = li_PaperTransfer.DeleteDate;
            cmd.Parameters.Add("@CauseOFDel", SqlDbType.VarChar).Value = li_PaperTransfer.CauseOFDel;
  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
