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


public class Sqlli_PlateTransferProvider:DataAccessObject
{
    public Sqlli_PlateTransferProvider()
    {
    }


    public bool DeleteLi_PlateTransfer(int li_PlateTransferID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateTransfer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateTransferID", SqlDbType.Int).Value = li_PlateTransferID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateTransfer> GetAllLi_PlateTransfers()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateTransfers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateTransfersFromReader(reader);
        }
    }
    public List<Li_PlateTransfer> GetLi_PlateTransfersFromReader(IDataReader reader)
    {
        List<Li_PlateTransfer> li_PlateTransfers = new List<Li_PlateTransfer>();

        while (reader.Read())
        {
            li_PlateTransfers.Add(GetLi_PlateTransferFromReader(reader));
        }
        return li_PlateTransfers;
    }

    public Li_PlateTransfer GetLi_PlateTransferFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateTransfer li_PlateTransfer = new Li_PlateTransfer
                (
              
                    (int)reader["TransNo"],
                    reader["RefNo"].ToString(),
                    (DateTime)reader["TransDate"],
                    reader["PrssFrom"].ToString(),
                    reader["PressTo"].ToString(),
                    (decimal)reader["TotalBill"],
                    reader["Remark"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Status_D"],
                    (int)reader["DeletBy"],
                    (DateTime)reader["DeleteDate"],
                    reader["CauseOFDel"].ToString() 
                );
            return li_PlateTransfer;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateTransfer GetLi_PlateTransferByID(int li_PlateTransferID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateTransferByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateTransferID", SqlDbType.Int).Value = li_PlateTransferID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateTransferFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PlateTransfer(Li_PlateTransfer li_PlateTransfer)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateTransfer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@TransNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_PlateTransfer.RefNo;
            cmd.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = li_PlateTransfer.TransDate;
            cmd.Parameters.Add("@PrssFrom", SqlDbType.VarChar).Value = li_PlateTransfer.PrssFrom;
            cmd.Parameters.Add("@PressTo", SqlDbType.VarChar).Value = li_PlateTransfer.PressTo;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PlateTransfer.TotalBill;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PlateTransfer.Remark;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateTransfer.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateTransfer.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PlateTransfer.Status_D;
            cmd.Parameters.Add("@DeletBy", SqlDbType.Int).Value =  DBNull .Value ;
            cmd.Parameters.Add("@DeleteDate", SqlDbType.DateTime).Value =  DBNull .Value ;
            cmd.Parameters.Add("@CauseOFDel", SqlDbType.VarChar).Value = DBNull .Value ;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TransNo"].Value;
        }
    }

    public bool UpdateLi_PlateTransfer(Li_PlateTransfer li_PlateTransfer)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateTransfer", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = li_PlateTransfer.TransNo;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_PlateTransfer.RefNo;
            cmd.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = li_PlateTransfer.TransDate;
            cmd.Parameters.Add("@PrssFrom", SqlDbType.VarChar).Value = li_PlateTransfer.PrssFrom;
            cmd.Parameters.Add("@PressTo", SqlDbType.VarChar).Value = li_PlateTransfer.PressTo;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PlateTransfer.TotalBill;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PlateTransfer.Remark;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateTransfer.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateTransfer.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PlateTransfer.Status_D;
            cmd.Parameters.Add("@DeletBy", SqlDbType.Int).Value = li_PlateTransfer.DeletBy;
            cmd.Parameters.Add("@DeleteDate", SqlDbType.DateTime).Value = li_PlateTransfer.DeleteDate;
            cmd.Parameters.Add("@CauseOFDel", SqlDbType.VarChar).Value = li_PlateTransfer.CauseOFDel;
  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}