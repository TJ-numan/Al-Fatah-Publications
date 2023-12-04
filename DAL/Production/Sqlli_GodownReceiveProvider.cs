using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_GodownReceiveProvider:DataAccessObject
{
	public SqlLi_GodownReceiveProvider()
    {
    }


    public bool DeleteLi_GodownReceive(int li_GodownReceiveID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_GodownReceive", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_GodownReceiveID", SqlDbType.Int).Value = li_GodownReceiveID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_GodownReceive> GetAllLi_GodownReceives()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_GodownReceives", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_GodownReceivesFromReader(reader);
        }
    }
    public List<Li_GodownReceive> GetLi_GodownReceivesFromReader(IDataReader reader)
    {
        List<Li_GodownReceive> li_GodownReceives = new List<Li_GodownReceive>();

        while (reader.Read())
        {
            li_GodownReceives.Add(GetLi_GodownReceiveFromReader(reader));
        }
        return li_GodownReceives;
    }

    public Li_GodownReceive GetLi_GodownReceiveFromReader(IDataReader reader)
    {
        try
        {
            Li_GodownReceive li_GodownReceive = new Li_GodownReceive
                (
                     
                    (int)reader["SerialNo"],
                    reader["StockID"].ToString(),
                    reader["ReceiveID"].ToString(),
                    reader["ReceiveMemo"].ToString(),
                    (int)reader["ReceiveBy"],
                    (DateTime)reader["ReceiveDate"],
                    reader["BookCode"].ToString(),
                    (int)reader["Qty"],
                    (bool)reader["IsReprinted"],
                    (bool)reader["IsRebind"],
                     reader ["IspromotionalItemID"].ToString (), 
                    (bool )reader ["IsopeningStock"],                     
                    (bool )reader ["IsreceiveReturnStock"],
                    (bool )reader ["IsSpecimen"] ,
                     reader["Edition"].ToString () 

                      
                );
             return li_GodownReceive;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_GodownReceive GetLi_GodownReceiveByID(int li_GodownReceiveID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_GodownReceiveByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_GodownReceiveID", SqlDbType.Int).Value = li_GodownReceiveID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_GodownReceiveFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_GodownReceive(Li_GodownReceive li_GodownReceive)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_GodownReceive", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@StockID", SqlDbType.VarChar).Value = li_GodownReceive.StockID;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;  
            cmd.Parameters.Add("@ReceiveMemo", SqlDbType.VarChar).Value = li_GodownReceive.ReceiveMemo;
            cmd.Parameters.Add("@ReceiveBy", SqlDbType.Int).Value = li_GodownReceive.ReceiveBy;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = li_GodownReceive.ReceiveDate;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_GodownReceive.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_GodownReceive.Qty;
            cmd.Parameters.Add("@IsReprinted", SqlDbType.Bit).Value = li_GodownReceive.IsReprinted;
            cmd.Parameters.Add("@IsRebind", SqlDbType.Bit).Value = li_GodownReceive.IsRebind;

            cmd.Parameters.Add("@PromotionalItemID", SqlDbType.VarChar).Value = li_GodownReceive.IspromotionalItemID ;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_GodownReceive. Edition  ;

            cmd.Parameters.Add("@IsSpecimen", SqlDbType.Bit).Value = li_GodownReceive.IsSpecimen ;
            cmd.Parameters.Add("@IsopeningStock", SqlDbType.Bit).Value = li_GodownReceive.IsopeningStock ;
            cmd.Parameters.Add("@IsReceiveFromReturn", SqlDbType.Bit).Value = li_GodownReceive.IsreceiveReturnStock ;
            
             
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ReceiveID"].Value.ToString ();




        }
    }

    public bool UpdateLi_GodownReceive(Li_GodownReceive li_GodownReceive)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_GodownReceive", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.Add("@Li_GodownReceiveID", SqlDbType.Int).Value = li_GodownReceive.Li_GodownReceiveID;
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_GodownReceive.SerialNo;
            cmd.Parameters.Add("@StockID", SqlDbType.VarChar).Value = li_GodownReceive.StockID;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_GodownReceive.ReceiveID;
            cmd.Parameters.Add("@ReceiveMemo", SqlDbType.VarChar).Value = li_GodownReceive.ReceiveMemo;
            cmd.Parameters.Add("@ReceiveBy", SqlDbType.Int).Value = li_GodownReceive.ReceiveBy;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = li_GodownReceive.ReceiveDate;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_GodownReceive.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_GodownReceive.Qty;
            cmd.Parameters.Add("@IsReprinted", SqlDbType.Bit).Value = li_GodownReceive.IsReprinted;
            cmd.Parameters.Add("@IsRebind", SqlDbType.Bit).Value = li_GodownReceive.IsRebind;
             
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    public DataSet GetAll_GodownReceive( string memo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_ShowAllGodownBookReceiving", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReceiveMemo", SqlDbType.VarChar).Value =  memo ;


            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public DataSet GetAll_GodownReceiveForBill(string BinderID, string BookCode, string ReceiveType)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetBookReciveByBinder", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = BinderID;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value =BookCode ;
            command.Parameters.Add("@IsRebind", SqlDbType.NVarChar).Value = ReceiveType;              
 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetAll_GodownReceiveCoverForBill(string BinderID, string BookCode, string ReceiveType)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetBookReciveCover", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = BinderID;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value =BookCode ;
            command.Parameters.Add("@IsRebind", SqlDbType.NVarChar).Value = ReceiveType;              
 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetAll_GodownReceiveCoverForBill_R2(int SourceID, string SupplierId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_getGodownReceiving_Cover", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SourceId", SqlDbType.VarChar).Value = SourceID;
            command.Parameters.Add("@SupplierID", SqlDbType.VarChar).Value = SupplierId;
 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetDistinctReceive(string BinderID, string BookCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetDistinctBookReciveByBinder", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = BinderID;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value =BookCode ;
              
 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetDistinctReceiveCover(string BinderID, string BookCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetDistinctCoverRecive", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = BinderID;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;


            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


}
