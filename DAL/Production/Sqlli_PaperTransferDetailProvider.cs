using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperTransferDetailProvider:DataAccessObject
{
	public SqlLi_PaperTransferDetailProvider()
    {
    }


    public bool DeleteLi_PaperTransferDetail(int li_PaperTransferDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperTransferDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperTransferDetailID", SqlDbType.Int).Value = li_PaperTransferDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperTransferDetail> GetAllLi_PaperTransferDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperTransferDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperTransferDetailsFromReader(reader);
        }
    }
    public List<Li_PaperTransferDetail> GetLi_PaperTransferDetailsFromReader(IDataReader reader)
    {
        List<Li_PaperTransferDetail> li_PaperTransferDetails = new List<Li_PaperTransferDetail>();

        while (reader.Read())
        {
            li_PaperTransferDetails.Add(GetLi_PaperTransferDetailFromReader(reader));
        }
        return li_PaperTransferDetails;
    }

    public Li_PaperTransferDetail GetLi_PaperTransferDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperTransferDetail li_PaperTransferDetail = new Li_PaperTransferDetail
                (
 
                    (int)reader["SlNo"],
                    (int)reader["TransNo"],
                    reader["P_TS_ID"].ToString(),
                    reader["PaperBrand"].ToString(),
                    (decimal)reader["UnitPrice"],
                    (decimal)reader["Qty"],
                    (decimal)reader["RollQty"] ,
                    reader ["PaperType"].ToString (),
                    reader ["PaperSize"].ToString (),
                    reader ["PaperGSM"].ToString () ,
                    (DateTime )reader ["SupplyDate"] ,
                    reader ["Receipt"].ToString ()
                );
             return li_PaperTransferDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PaperTransferDetail GetLi_PaperTransferDetailByID(int li_PaperTransferDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperTransferDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PaperTransferDetailID", SqlDbType.Int).Value = li_PaperTransferDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PaperTransferDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PaperTransferDetail(Li_PaperTransferDetail li_PaperTransferDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperTransferDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SlNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = li_PaperTransferDetail.TransNo;
            cmd.Parameters.Add("@P_TS_ID", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@PaperBrand", SqlDbType.VarChar).Value = li_PaperTransferDetail.PaperBrand;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_PaperTransferDetail.UnitPrice;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_PaperTransferDetail.Qty;
            cmd.Parameters.Add("@RollQty", SqlDbType.Decimal).Value = li_PaperTransferDetail.RollQty;
            cmd.Parameters.Add("@PaperType", SqlDbType.VarChar).Value = li_PaperTransferDetail.PaperType;
            cmd.Parameters.Add("@PaperSize", SqlDbType.VarChar).Value = li_PaperTransferDetail.PaperSize;
            cmd.Parameters.Add("@PaperGSM", SqlDbType.VarChar).Value = li_PaperTransferDetail.PaperGSM;
            cmd.Parameters.Add("@SupplyDate", SqlDbType. DateTime ).Value = li_PaperTransferDetail. SupplyDate;
            cmd.Parameters.Add("@Receipt", SqlDbType. VarChar).Value = li_PaperTransferDetail. Receipt;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SlNo"].Value;
        }
    }

    public bool UpdateLi_PaperTransferDetail(Li_PaperTransferDetail li_PaperTransferDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperTransferDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SlNo", SqlDbType.Int).Value = li_PaperTransferDetail.SlNo;
            cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = li_PaperTransferDetail.TransNo;
            cmd.Parameters.Add("@P_TS_ID", SqlDbType.VarChar).Value = li_PaperTransferDetail.P_TS_ID;
            cmd.Parameters.Add("@PaperBrand", SqlDbType.VarChar).Value = li_PaperTransferDetail.PaperBrand;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_PaperTransferDetail.UnitPrice;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_PaperTransferDetail.Qty;
            cmd.Parameters.Add("@RollQty", SqlDbType.Decimal).Value = li_PaperTransferDetail.RollQty;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
