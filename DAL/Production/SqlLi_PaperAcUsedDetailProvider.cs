using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperAcUsedDetailProvider:DataAccessObject
{
	public SqlLi_PaperAcUsedDetailProvider()
    {
    }


    public bool DeleteLi_PaperAcUsedDetail(int li_PaperAcUsedDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperAcUsedDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperAcUsedDetailID", SqlDbType.Int).Value = li_PaperAcUsedDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperAcUsedDetail> GetAllLi_PaperAcUsedDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperAcUsedDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperAcUsedDetailsFromReader(reader);
        }
    }
    public List<Li_PaperAcUsedDetail> GetLi_PaperAcUsedDetailsFromReader(IDataReader reader)
    {
        List<Li_PaperAcUsedDetail> li_PaperAcUsedDetails = new List<Li_PaperAcUsedDetail>();

        while (reader.Read())
        {
            li_PaperAcUsedDetails.Add(GetLi_PaperAcUsedDetailFromReader(reader));
        }
        return li_PaperAcUsedDetails;
    }

    public Li_PaperAcUsedDetail GetLi_PaperAcUsedDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperAcUsedDetail li_PaperAcUsedDetail = new Li_PaperAcUsedDetail
                (
                     
                    (int)reader["SerialNo"],
                    (int)reader["PrintOrderSl"],
                    reader["RunNo"].ToString(),
                    reader["RollNo"].ToString(),
                    reader["AFNo"].ToString(),
                    reader["BRNo"].ToString(),
                    (decimal)reader["PaperQty"] 
                );
             return li_PaperAcUsedDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PaperAcUsedDetail GetLi_PaperAcUsedDetailByID(int li_PaperAcUsedDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperAcUsedDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PaperAcUsedDetailID", SqlDbType.Int).Value = li_PaperAcUsedDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PaperAcUsedDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PaperAcUsedDetail(Li_PaperAcUsedDetail li_PaperAcUsedDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperAcUsedDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PrintOrderSl", SqlDbType.Int).Value = li_PaperAcUsedDetail.PrintOrderSl;
            cmd.Parameters.Add("@RunNo", SqlDbType.VarChar).Value = li_PaperAcUsedDetail.RunNo;
            cmd.Parameters.Add("@RollNo", SqlDbType.VarChar ).Value = li_PaperAcUsedDetail.RollNo;
            cmd.Parameters.Add("@AFNo", SqlDbType.VarChar).Value = li_PaperAcUsedDetail.AFNo;
            cmd.Parameters.Add("@BRNo", SqlDbType.VarChar).Value = li_PaperAcUsedDetail.BRNo;
            cmd.Parameters.Add("@PaperQty", SqlDbType.Decimal).Value = li_PaperAcUsedDetail.PaperQty;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_PaperAcUsedDetail(Li_PaperAcUsedDetail li_PaperAcUsedDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperAcUsedDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_PaperAcUsedDetail.SerialNo;
            cmd.Parameters.Add("@PrintOrderSl", SqlDbType.Int).Value = li_PaperAcUsedDetail.PrintOrderSl;
            cmd.Parameters.Add("@RunNo", SqlDbType.VarChar).Value = li_PaperAcUsedDetail.RunNo;
            cmd.Parameters.Add("@RollNo", SqlDbType.Decimal).Value = li_PaperAcUsedDetail.RollNo;
            cmd.Parameters.Add("@AFNo", SqlDbType.VarChar).Value = li_PaperAcUsedDetail.AFNo;
            cmd.Parameters.Add("@BRNo", SqlDbType.VarChar).Value = li_PaperAcUsedDetail.BRNo;
            cmd.Parameters.Add("@PaperQty", SqlDbType.Decimal).Value = li_PaperAcUsedDetail.PaperQty;
          
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
