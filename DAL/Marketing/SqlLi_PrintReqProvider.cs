using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PrintReqProvider:DataAccessObject
{
	public SqlLi_PrintReqProvider()
    {
    }


    public bool DeleteLi_PrintReq(int li_PrintReqID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PrintReq", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PrintReqID", SqlDbType.Int).Value = li_PrintReqID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PrintReq> GetAllLi_PrintReqs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PrintReqs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PrintReqsFromReader(reader);
        }
    }
    public List<Li_PrintReq> GetLi_PrintReqsFromReader(IDataReader reader)
    {
        List<Li_PrintReq> li_PrintReqs = new List<Li_PrintReq>();

        while (reader.Read())
        {
            li_PrintReqs.Add(GetLi_PrintReqFromReader(reader));
        }
        return li_PrintReqs;
    }

    public Li_PrintReq GetLi_PrintReqFromReader(IDataReader reader)
    {
        try
        {
            Li_PrintReq li_PrintReq = new Li_PrintReq
                (
                     
                    reader["RqeNo"].ToString(),
                    (DateTime)reader["Req_Date"],
                    reader["PestType"].ToString(),
                    (int)reader["ProposedQty"],
                    (DateTime)reader["GoRecDate"],
                    reader["Remark"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (char)reader["Statud_D"],
                    reader["CauseOfDel"].ToString(),
                    (DateTime)reader["DelDate"] 
                );
             return li_PrintReq;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PrintReq GetLi_PrintReqByID(int li_PrintReqID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PrintReqByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PrintReqID", SqlDbType.Int).Value = li_PrintReqID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PrintReqFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PrintReq(Li_PrintReq li_PrintReq)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PrintReq", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@RqeNo", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Req_Date", SqlDbType.DateTime).Value = li_PrintReq.Req_Date;
            cmd.Parameters.Add("@PestType", SqlDbType.VarChar).Value = li_PrintReq.PestType;
            cmd.Parameters.Add("@ProposedQty", SqlDbType.Int).Value = li_PrintReq.ProposedQty;
            cmd.Parameters.Add("@GoRecDate", SqlDbType.DateTime).Value = li_PrintReq.GoRecDate;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PrintReq.Remark;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PrintReq.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PrintReq.CreatedDate;
            cmd.Parameters.Add("@Statud_D", SqlDbType.Char).Value = li_PrintReq.Statud_D;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_PrintReq.CauseOfDel;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_PrintReq.DelDate;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@RqeNo"].Value.ToString ();
        }
    }

    public bool UpdateLi_PrintReq(Li_PrintReq li_PrintReq)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PrintReq", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@RqeNo", SqlDbType.VarChar).Value = li_PrintReq.RqeNo;
            cmd.Parameters.Add("@Req_Date", SqlDbType.DateTime).Value = li_PrintReq.Req_Date;
            cmd.Parameters.Add("@PestType", SqlDbType.VarChar).Value = li_PrintReq.PestType;
            cmd.Parameters.Add("@ProposedQty", SqlDbType.Int).Value = li_PrintReq.ProposedQty;
            cmd.Parameters.Add("@GoRecDate", SqlDbType.DateTime).Value = li_PrintReq.GoRecDate;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PrintReq.Remark;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PrintReq.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PrintReq.CreatedDate;
            cmd.Parameters.Add("@Statud_D", SqlDbType.Char).Value = li_PrintReq.Statud_D;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_PrintReq.CauseOfDel;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_PrintReq.DelDate; 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public string  IsExistPrintReq(int PrintSl, string BookCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetIsExistPrintReqNo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqNo", SqlDbType.VarChar,50).Direction = ParameterDirection.Output; 
            cmd.Parameters.Add("@PrintSl", SqlDbType.Int).Value = PrintSl;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@ReqNo"].Value.ToString();
        }
    }

    public DataSet GetPrintReqBasic()
    {     
        
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {

            SqlCommand cmd = new SqlCommand("SMPM_li_PrintReqBasics", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }

    public DataTable   printRequisitionReport(string FromDate ,string ToDate  ,string BookName  , string Class, string Type, string Edition, int GID ,string Category  )
    {

        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {

            SqlCommand cmd = new SqlCommand("SMPM_li_rptPrintRequisitionDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar).Value =FromDate ;
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar ).Value = ToDate;
            cmd.Parameters.Add("@BookName", SqlDbType.VarChar).Value =  BookName;
            cmd.Parameters.Add("@Class", SqlDbType.VarChar ).Value = Class;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar ).Value = Type ;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = Edition ;
            cmd.Parameters.Add("@GID", SqlDbType.Int).Value =  GID;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar ).Value =Category  ;
 

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill( dt );
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
}
