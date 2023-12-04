using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_GodownReceive_CoverProvider:DataAccessObject
{
	public SqlLi_GodownReceive_CoverProvider()
    {
    }


    public bool DeleteLi_GodownReceive_Cover(int li_GodownReceive_CoverID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_GodownReceive_Cover", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_GodownReceive_CoverID", SqlDbType.Int).Value = li_GodownReceive_CoverID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }





    public List<Li_GodownReceive_Cover> GetAllLi_GodownReceive_Covers()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_GodownReceive_Covers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_GodownReceive_CoversFromReader(reader);
        }
    }


    public DataSet  GetCoverSupplierforBill( string BookCode ,int Source )
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        { 
            SqlCommand command = new SqlCommand("SMPM_li_GetSupplierFromReceive", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
            command.Parameters.Add("@Source", SqlDbType.Int).Value = Source;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        
           
        }
    }



    public List<Li_GodownReceive_Cover> GetLi_GodownReceive_CoversFromReader(IDataReader reader)
    {
        List<Li_GodownReceive_Cover> li_GodownReceive_Covers = new List<Li_GodownReceive_Cover>();

        while (reader.Read())
        {
            li_GodownReceive_Covers.Add(GetLi_GodownReceive_CoverFromReader(reader));
        }
        return li_GodownReceive_Covers;
    }

    public Li_GodownReceive_Cover GetLi_GodownReceive_CoverFromReader(IDataReader reader)
    {
        try
        {
            Li_GodownReceive_Cover li_GodownReceive_Cover = new Li_GodownReceive_Cover
                ( 
                    (int)reader["SerialNo"],
                    reader["PressID"].ToString(),
                    reader["ReceiveID"].ToString(),
                    reader["ReceiveMemo"].ToString(),
                    (int)reader["ReceiveBy"],
                    (DateTime)reader["ReceiveDate"],
                    reader["BookCode"].ToString(),
                    (decimal)reader["Qty"],
                    (bool)reader["IsReprinted"],
                    (bool)reader["IsRebind"],
                    reader["PromotionalItemID"].ToString(),
                    (bool)reader["IsSpecimen"],
                    (bool)reader["IsopeningStock"],
                    (bool)reader["IsPaid"],
                    (char)reader["Status_D"],
                    reader["CauseOfDel"].ToString(),
                    (int)reader["DelBy"],
                    (DateTime)reader["DelDate"],
                    (int)reader["IsRe_Mat"] ,
                    reader ["SizeID"].ToString ()
                     
                );
             return li_GodownReceive_Cover;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_GodownReceive_Cover GetLi_GodownReceive_CoverByID(int li_GodownReceive_CoverID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_GodownReceive_CoverByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_GodownReceive_CoverID", SqlDbType.Int).Value = li_GodownReceive_CoverID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_GodownReceive_CoverFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_GodownReceive_Cover(Li_GodownReceive_Cover li_GodownReceive_Cover)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_GodownReceive_Cover", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
 
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_GodownReceive_Cover.PressID;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar,50).   Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ReceiveMemo", SqlDbType.VarChar).Value = li_GodownReceive_Cover.ReceiveMemo;
            cmd.Parameters.Add("@ReceiveBy", SqlDbType.Int).Value = li_GodownReceive_Cover.ReceiveBy;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = li_GodownReceive_Cover.ReceiveDate;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_GodownReceive_Cover.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_GodownReceive_Cover.Qty;
            cmd.Parameters.Add("@IsReprinted", SqlDbType.Bit).Value = li_GodownReceive_Cover.IsReprinted;
            cmd.Parameters.Add("@IsRebind", SqlDbType.Bit).Value = li_GodownReceive_Cover.IsRebind;
            cmd.Parameters.Add("@PromotionalItemID", SqlDbType.VarChar).Value = li_GodownReceive_Cover.PromotionalItemID;
            cmd.Parameters.Add("@IsSpecimen", SqlDbType.Bit).Value = li_GodownReceive_Cover.IsSpecimen;
            cmd.Parameters.Add("@IsopeningStock", SqlDbType.Bit).Value = li_GodownReceive_Cover.IsopeningStock;
            cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = li_GodownReceive_Cover.IsPaid;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_GodownReceive_Cover.Status_D;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_GodownReceive_Cover.CauseOfDel;
            cmd.Parameters.Add("@DelBy", SqlDbType.Int).Value = li_GodownReceive_Cover.DelBy;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_GodownReceive_Cover.DelDate;
            cmd.Parameters.Add("@SourceNo", SqlDbType.Bit).Value = li_GodownReceive_Cover.SourceNo;
            cmd.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = li_GodownReceive_Cover. SizeID ;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ReceiveID"].Value.ToString ();
        }
    }

    public bool UpdateLi_GodownReceive_Cover(Li_GodownReceive_Cover li_GodownReceive_Cover)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_GodownReceive_Cover", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_GodownReceive_Cover.SerialNo;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_GodownReceive_Cover.PressID;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_GodownReceive_Cover.ReceiveID;
            cmd.Parameters.Add("@ReceiveMemo", SqlDbType.VarChar).Value = li_GodownReceive_Cover.ReceiveMemo;
            cmd.Parameters.Add("@ReceiveBy", SqlDbType.Int).Value = li_GodownReceive_Cover.ReceiveBy;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = li_GodownReceive_Cover.ReceiveDate;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_GodownReceive_Cover.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_GodownReceive_Cover.Qty;
            cmd.Parameters.Add("@IsReprinted", SqlDbType.Bit).Value = li_GodownReceive_Cover.IsReprinted;
            cmd.Parameters.Add("@IsRebind", SqlDbType.Bit).Value = li_GodownReceive_Cover.IsRebind;
            cmd.Parameters.Add("@PromotionalItemID", SqlDbType.VarChar).Value = li_GodownReceive_Cover.PromotionalItemID;
            cmd.Parameters.Add("@IsSpecimen", SqlDbType.Bit).Value = li_GodownReceive_Cover.IsSpecimen;
            cmd.Parameters.Add("@IsopeningStock", SqlDbType.Bit).Value = li_GodownReceive_Cover.IsopeningStock;
            cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = li_GodownReceive_Cover.IsPaid;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_GodownReceive_Cover.Status_D;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_GodownReceive_Cover.CauseOfDel;
            cmd.Parameters.Add("@DelBy", SqlDbType.Int).Value = li_GodownReceive_Cover.DelBy;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_GodownReceive_Cover.DelDate;
            cmd.Parameters.Add("@IsRe_Mat", SqlDbType.Bit).Value = li_GodownReceive_Cover.SourceNo;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
