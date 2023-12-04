using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperReturnDetailProvider : DataAccessObject
{
    public SqlLi_PaperReturnDetailProvider()
    {
    }


    public bool DeleteLi_PaperReturnDetails(int li_PaperTransferDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperReturnDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperTransferDetailID", SqlDbType.Int).Value = li_PaperTransferDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperReturnDetails> GetAllLi_PaperReturnDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperReturnDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperReturnDetailsFromReader(reader);
        }
    }
    public List<Li_PaperReturnDetails> GetLi_PaperReturnDetailsFromReader(IDataReader reader)
    {
        List<Li_PaperReturnDetails> li_PaperReturnDetails = new List<Li_PaperReturnDetails>();

        while (reader.Read())
        {
            li_PaperReturnDetails.Add(GetLi_PaperReturnDetailFromReader(reader));
        }
        return li_PaperReturnDetails;
    }

    public Li_PaperReturnDetails GetLi_PaperReturnDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperReturnDetails li_PaperReturnDetails = new Li_PaperReturnDetails
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
            return li_PaperReturnDetails;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PaperReturnDetails GetLi_PaperReturnDetailsByID(int li_PaperReturnDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperReturnDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PaperReturnDetailID", SqlDbType.Int).Value = li_PaperReturnDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PaperReturnDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PaperReturnDetails(Li_PaperReturnDetails li_PaperReturnDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperReturnDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SlNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RetNo", SqlDbType.Int).Value = li_PaperReturnDetails.RetNo;
            cmd.Parameters.Add("@P_TS_ID", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@PaperBrand", SqlDbType.VarChar).Value = li_PaperReturnDetails.PaperBrand;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_PaperReturnDetails.UnitPrice;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_PaperReturnDetails.Qty;
            cmd.Parameters.Add("@RollQty", SqlDbType.Decimal).Value = li_PaperReturnDetails.RollQty;
            cmd.Parameters.Add("@PaperType", SqlDbType.VarChar).Value = li_PaperReturnDetails.PaperType;
            cmd.Parameters.Add("@PaperSize", SqlDbType.VarChar).Value = li_PaperReturnDetails.PaperSize;
            cmd.Parameters.Add("@PaperGSM", SqlDbType.VarChar).Value = li_PaperReturnDetails.PaperGSM;
            cmd.Parameters.Add("@SupplyDate", SqlDbType.DateTime).Value = li_PaperReturnDetails.SupplyDate;
            cmd.Parameters.Add("@Receipt", SqlDbType.VarChar).Value = li_PaperReturnDetails.Receipt;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SlNo"].Value;
        }
    }

    public bool UpdateLi_PaperReturnDetails(Li_PaperReturnDetails li_PaperReturnDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperReturnDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SlNo", SqlDbType.Int).Value = li_PaperReturnDetail.SlNo;
            cmd.Parameters.Add("@RetNo", SqlDbType.Int).Value = li_PaperReturnDetail.RetNo;
            cmd.Parameters.Add("@P_TS_ID", SqlDbType.VarChar).Value = li_PaperReturnDetail.P_TS_ID;
            cmd.Parameters.Add("@PaperBrand", SqlDbType.VarChar).Value = li_PaperReturnDetail.PaperBrand;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_PaperReturnDetail.UnitPrice;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_PaperReturnDetail.Qty;
            cmd.Parameters.Add("@RollQty", SqlDbType.Decimal).Value = li_PaperReturnDetail.RollQty;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}

