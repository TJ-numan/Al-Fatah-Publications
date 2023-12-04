using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PrintReq_CurProvider:DataAccessObject
{
	public SqlLi_PrintReq_CurProvider()
    {
    }


    public bool DeleteLi_PrintReq_Cur(int li_PrintReq_CurID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PrintReq_Cur", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PrintReq_CurID", SqlDbType.Int).Value = li_PrintReq_CurID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PrintReq_Cur> GetAllLi_PrintReq_Curs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PrintReq_Curs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PrintReq_CursFromReader(reader);
        }
    }
    public List<Li_PrintReq_Cur> GetLi_PrintReq_CursFromReader(IDataReader reader)
    {
        List<Li_PrintReq_Cur> li_PrintReq_Curs = new List<Li_PrintReq_Cur>();

        while (reader.Read())
        {
            li_PrintReq_Curs.Add(GetLi_PrintReq_CurFromReader(reader));
        }
        return li_PrintReq_Curs;
    }

    public Li_PrintReq_Cur GetLi_PrintReq_CurFromReader(IDataReader reader)
    {
        try
        {
            Li_PrintReq_Cur li_PrintReq_Cur = new Li_PrintReq_Cur
                (
                   
                    (int)reader["CurSl"],
                    reader["ReqNo"].ToString(),
                    reader["BookCode"].ToString(),
                    (int)reader["PrintSl"],
                    (int)reader["Target"],
                    (int) reader["PrintReq"],
                    (int)reader["Printed"],
                    (int)reader["Receive"],
                    (int)reader["Challan"],
                    (int)reader["RetQty"],
                    (int)reader["Specimen"],
                    (int)reader["StockInHand"],
                    (int)reader["ApprovedQty"],
                    (int)reader["EntryBy"],
                    (DateTime)reader["EntryDate"],
                    (bool)reader["IsApproved"],
                    (int)reader["StockQty"],
                    (int)reader["RetStkQty"]
                );
             return li_PrintReq_Cur;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PrintReq_Cur GetLi_PrintReq_CurByID(int li_PrintReq_CurID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PrintReq_CurByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PrintReq_CurID", SqlDbType.Int).Value = li_PrintReq_CurID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PrintReq_CurFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PrintReq_Cur(Li_PrintReq_Cur li_PrintReq_Cur)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PrintReq_Cur", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@CurSl", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = li_PrintReq_Cur.ReqNo;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PrintReq_Cur.BookCode;
            cmd.Parameters.Add("@PrintSl", SqlDbType.Int).Value = li_PrintReq_Cur.PrintSl;
            cmd.Parameters.Add("@Target", SqlDbType.Int).Value = li_PrintReq_Cur.Target;
            cmd.Parameters.Add("@PrintReq", SqlDbType.Int).Value = li_PrintReq_Cur. PrintReq;
            cmd.Parameters.Add("@Printed", SqlDbType.Int).Value = li_PrintReq_Cur.Printed;
            cmd.Parameters.Add("@Receive", SqlDbType.Int).Value = li_PrintReq_Cur.Receive;
            cmd.Parameters.Add("@Challan", SqlDbType.Int).Value = li_PrintReq_Cur.Challan;
            cmd.Parameters.Add("@RetQty", SqlDbType.Int).Value = li_PrintReq_Cur.RetQty;
            cmd.Parameters.Add("@Specimen", SqlDbType.Int).Value = li_PrintReq_Cur.Specimen;
            cmd.Parameters.Add("@StockInHand", SqlDbType.Int).Value = li_PrintReq_Cur.StockInHand;
            cmd.Parameters.Add("@StockQty", SqlDbType.Int).Value = li_PrintReq_Cur.StockQty;
            cmd.Parameters.Add("@RetStkQty", SqlDbType.Int).Value = li_PrintReq_Cur.RetStkQty;
         
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  1;
        }
    }

    public bool UpdateLi_PrintReq_Cur(Li_PrintReq_Cur li_PrintReq_Cur)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PrintReq_Cur", connection);
            cmd.CommandType = CommandType.StoredProcedure;

           
            cmd.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = li_PrintReq_Cur.ReqNo;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PrintReq_Cur.BookCode;
          
            cmd.Parameters.Add("@Targeted", SqlDbType.Int).Value = li_PrintReq_Cur.Target;
            cmd.Parameters.Add("@Printed", SqlDbType.Int).Value = li_PrintReq_Cur.Printed;
            cmd.Parameters.Add("@PrintReq", SqlDbType.Int).Value = li_PrintReq_Cur. PrintReq;
            cmd.Parameters.Add("@Received", SqlDbType.Int).Value = li_PrintReq_Cur.Receive;
            cmd.Parameters.Add("@Challan", SqlDbType.Int).Value = li_PrintReq_Cur.Challan;
            cmd.Parameters.Add("@RetQty", SqlDbType.Int).Value = li_PrintReq_Cur.RetQty;
            cmd.Parameters.Add("@Specimen", SqlDbType.Int).Value = li_PrintReq_Cur.Specimen;
            cmd.Parameters.Add("@StockInHand", SqlDbType.Int).Value = li_PrintReq_Cur.StockInHand;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public bool ApprovedPrintReq(Li_PrintReq_Cur li_PrintReq)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_ApprovedPrintRequsition", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = li_PrintReq.ReqNo;
            cmd.Parameters.Add("@ApprovedQty", SqlDbType.Int).Value = li_PrintReq.ApprovedQty;
            cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = li_PrintReq.EntryDate;
            cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = li_PrintReq.IsApproved;
            cmd.Parameters.Add("@EntryBy", SqlDbType.Int  ).Value = li_PrintReq.EntryBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet  GetPrintReqQty (string ReqNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetPrintRequisitionQty", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = ReqNo ;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataTable   GetPrintReqForPrint (string FromDate ,string ToDate )
    {
        DataTable dt = new  DataTable ();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_Li_GetPrintReqForPrint", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromDate  ;
            command.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = ToDate ;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();

            return dt;
        }
    }
}
