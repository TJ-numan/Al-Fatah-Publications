using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Specimen_ReturnProvider:DataAccessObject
{
	public SqlLi_Specimen_ReturnProvider()
    {
    }


    public bool DeleteLi_Specimen_Return(int li_Specimen_ReturnID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Specimen_Return", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Specimen_ReturnID", SqlDbType.Int).Value = li_Specimen_ReturnID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Specimen_Return> GetAllLi_Specimen_Returns()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Specimen_Returns", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Specimen_ReturnsFromReader(reader);
        }
    }
    public List<Li_Specimen_Return> GetLi_Specimen_ReturnsFromReader(IDataReader reader)
    {
        List<Li_Specimen_Return> li_Specimen_Returns = new List<Li_Specimen_Return>();

        while (reader.Read())
        {
            li_Specimen_Returns.Add(GetLi_Specimen_ReturnFromReader(reader));
        }
        return li_Specimen_Returns;
    }

    public Li_Specimen_Return GetLi_Specimen_ReturnFromReader(IDataReader reader)
    {
        try
        {
            Li_Specimen_Return li_Specimen_Return = new Li_Specimen_Return
                (
                     
                    reader["ReturnID"].ToString(),
                    reader["MemoNo"].ToString(),
                    (decimal)reader["TotalAmount"],
                    (decimal)reader["AdjustedAmount"],
                    (decimal)reader["AmountPayable"],
                    reader["CreatedBy"].ToString(),
                    reader["DeliveredBy"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (DateTime)reader["ReceiveDate"],
                    reader["TSO"].ToString(),
                    (int)reader["PacketNo"],
                    (decimal)reader["PerPacketCost"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"] ,
                    (bool)reader ["Donation"]
                );
             return li_Specimen_Return;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Specimen_Return GetLi_Specimen_ReturnByID(int li_Specimen_ReturnID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Specimen_ReturnByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Specimen_ReturnID", SqlDbType.Int).Value = li_Specimen_ReturnID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Specimen_ReturnFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_Specimen_Return(Li_Specimen_Return li_Specimen_Return)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Specimen_Return", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar,50).Direction  = ParameterDirection .Output ;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_Specimen_Return.MemoNo;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_Specimen_Return.TotalAmount;
            cmd.Parameters.Add("@AdjustedAmount", SqlDbType.Decimal).Value = li_Specimen_Return.AdjustedAmount;
            cmd.Parameters.Add("@AmountPayable", SqlDbType.Decimal).Value = li_Specimen_Return.AmountPayable;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_Specimen_Return.CreatedBy;
            cmd.Parameters.Add("@DeliveredBy", SqlDbType.VarChar).Value = li_Specimen_Return.DeliveredBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Specimen_Return.CreatedDate;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = li_Specimen_Return.ReceiveDate;
            cmd.Parameters.Add("@TSO", SqlDbType.VarChar).Value = li_Specimen_Return.TSO;
            cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_Specimen_Return.PacketNo;
            cmd.Parameters.Add("@PerPacketCost", SqlDbType.Decimal).Value = li_Specimen_Return.PerPacketCost;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Specimen_Return.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Specimen_Return.ModifiedDate;
            cmd.Parameters.Add("@Donation", SqlDbType.Bit).Value =  li_Specimen_Return.Donation;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@ReturnID"].Value.ToString();
        }
    }

    public bool UpdateLi_Specimen_Return(Li_Specimen_Return li_Specimen_Return)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Specimen_Return", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar).Value = li_Specimen_Return.ReturnID;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_Specimen_Return.MemoNo;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_Specimen_Return.TotalAmount;
            cmd.Parameters.Add("@AdjustedAmount", SqlDbType.Decimal).Value = li_Specimen_Return.AdjustedAmount;
            cmd.Parameters.Add("@AmountPayable", SqlDbType.Decimal).Value = li_Specimen_Return.AmountPayable;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_Specimen_Return.CreatedBy;
            cmd.Parameters.Add("@DeliveredBy", SqlDbType.VarChar).Value = li_Specimen_Return.DeliveredBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Specimen_Return.CreatedDate;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = li_Specimen_Return.ReceiveDate;
            cmd.Parameters.Add("@TSO", SqlDbType.VarChar).Value = li_Specimen_Return.TSO;
            cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_Specimen_Return.PacketNo;
            cmd.Parameters.Add("@PerPacketCost", SqlDbType.Decimal).Value = li_Specimen_Return.PerPacketCost;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Specimen_Return.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Specimen_Return.ModifiedDate;
              connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet GetAll_BookPriceAndTSOwiseQty(string TSOId, string bookAcCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetBookCodeAndTSOwisePriceQty", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TSOID", SqlDbType.VarChar).Value = TSOId;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
