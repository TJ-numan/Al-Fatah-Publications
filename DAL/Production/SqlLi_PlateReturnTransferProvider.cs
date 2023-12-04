using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

using System.Xml.Linq;
using DAL;

public class SqlLi_PlateReturnTransferProvider:DataAccessObject
{
	public SqlLi_PlateReturnTransferProvider()
    {
    }


    public bool DeleteLi_PlateReturnTransfer(int li_PlateReturnTransferID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateReturnTransfer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateReturnTransferID", SqlDbType.Int).Value = li_PlateReturnTransferID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateReturnTransfer> GetAllLi_PlateReturnTransfers()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateReturnTransfers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateReturnTransfersFromReader(reader);
        }
    }
    public List<Li_PlateReturnTransfer> GetLi_PlateReturnTransfersFromReader(IDataReader reader)
    {
        List<Li_PlateReturnTransfer> li_PlateReturnTransfers = new List<Li_PlateReturnTransfer>();

        while (reader.Read())
        {
            li_PlateReturnTransfers.Add(GetLi_PlateReturnTransferFromReader(reader));
        }
        return li_PlateReturnTransfers;
    }

    public Li_PlateReturnTransfer GetLi_PlateReturnTransferFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateReturnTransfer li_PlateReturnTransfer = new Li_PlateReturnTransfer
                (
              
                    reader["PlateRecID"].ToString(),
                    reader["PressID"].ToString(),
                    (bool)reader["IsTransfer"],
                    reader["TransPressID"].ToString(),
                    (DateTime)reader["RecDate"],
                    (int)reader["TotalQty"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (char)reader["Status_D"],
                    reader["CauseOfDel"].ToString(),
                    (int)reader["DelBy"],
                    (DateTime)reader["DelDate"]  
                );
             return li_PlateReturnTransfer;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateReturnTransfer GetLi_PlateReturnTransferByID(int li_PlateReturnTransferID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateReturnTransferByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateReturnTransferID", SqlDbType.Int).Value = li_PlateReturnTransferID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateReturnTransferFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PlateReturnTransfer(Li_PlateReturnTransfer li_PlateReturnTransfer)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateReturnTransfer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@PlateRecID", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PlateReturnTransfer.PressID;
            cmd.Parameters.Add("@IsTransfer", SqlDbType.Bit).Value = li_PlateReturnTransfer.IsTransfer;
            cmd.Parameters.Add("@TransPressID", SqlDbType.VarChar).Value = li_PlateReturnTransfer.TransPressID;
            cmd.Parameters.Add("@RecDate", SqlDbType.DateTime).Value = li_PlateReturnTransfer.RecDate;
            cmd.Parameters.Add("@TotalQty", SqlDbType.Int).Value = li_PlateReturnTransfer.TotalQty;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateReturnTransfer.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateReturnTransfer.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PlateReturnTransfer.Status_D;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_PlateReturnTransfer.CauseOfDel;
            cmd.Parameters.Add("@DelBy", SqlDbType.Int).Value = li_PlateReturnTransfer.DelBy;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_PlateReturnTransfer.DelDate;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@PlateRecID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PlateReturnTransfer(Li_PlateReturnTransfer li_PlateReturnTransfer)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateReturnTransfer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@PlateRecID", SqlDbType.VarChar).Value = li_PlateReturnTransfer.PlateRecID;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PlateReturnTransfer.PressID;
            cmd.Parameters.Add("@IsTransfer", SqlDbType.Bit).Value = li_PlateReturnTransfer.IsTransfer;
            cmd.Parameters.Add("@TransPressID", SqlDbType.VarChar).Value = li_PlateReturnTransfer.TransPressID;
            cmd.Parameters.Add("@RecDate", SqlDbType.DateTime).Value = li_PlateReturnTransfer.RecDate;
            cmd.Parameters.Add("@TotalQty", SqlDbType.Int).Value = li_PlateReturnTransfer.TotalQty;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateReturnTransfer.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateReturnTransfer.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PlateReturnTransfer.Status_D;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_PlateReturnTransfer.CauseOfDel;
            cmd.Parameters.Add("@DelBy", SqlDbType.Int).Value = li_PlateReturnTransfer.DelBy;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_PlateReturnTransfer.DelDate;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
