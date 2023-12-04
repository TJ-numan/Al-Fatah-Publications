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

public class Sqlli_PlateTransferDetailProvider : DataAccessObject
{
    public Sqlli_PlateTransferDetailProvider()
    {
    }


    public bool DeleteLi_PlateTransferDetail(int li_PlateTransferDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateTransferDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateTransferDetailID", SqlDbType.Int).Value = li_PlateTransferDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<li_PlateTransferDetail> GetAllLi_PlateTransferDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateTransferDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateTransferDetailsFromReader(reader);
        }
    }
    public List<li_PlateTransferDetail> GetLi_PlateTransferDetailsFromReader(IDataReader reader)
    {
        List<li_PlateTransferDetail> li_PlateTransferDetails = new List<li_PlateTransferDetail>();

        while (reader.Read())
        {
            li_PlateTransferDetails.Add(GetLi_PlateTransferDetailFromReader(reader));
        }
        return li_PlateTransferDetails;
    }

    public li_PlateTransferDetail GetLi_PlateTransferDetailFromReader(IDataReader reader)
    {
        try
        {
            li_PlateTransferDetail li_PlateTransferDetail = new li_PlateTransferDetail
                (

                    (int)reader["SlNo"],
                    (int)reader["TransNo"],
                    reader["PlateBrand"].ToString(),
                    (decimal)reader["UnitPrice"],
                    (decimal)reader["Qty"],
                    reader["PlateType"].ToString(),
                    reader["PlateSize"].ToString(),
                    (DateTime)reader["SupplyDate"],
                    reader["Receipt"].ToString()
                );
            return li_PlateTransferDetail;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public li_PlateTransferDetail GetLi_PlateTransferDetailByID(int li_PlateTransferDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateTransferDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateTransferDetailID", SqlDbType.Int).Value = li_PlateTransferDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateTransferDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PlateTransferDetail(li_PlateTransferDetail li_PlateTransferDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateTransferDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SlNo", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = li_PlateTransferDetail.TransNo;
            cmd.Parameters.Add("@PlateBrand", SqlDbType.VarChar).Value = li_PlateTransferDetail.PlateBrand;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_PlateTransferDetail.UnitPrice;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_PlateTransferDetail.Qty;
            cmd.Parameters.Add("@PlateType", SqlDbType.VarChar).Value = li_PlateTransferDetail.PlateType;
            cmd.Parameters.Add("@PlateSize", SqlDbType.VarChar).Value = li_PlateTransferDetail.PlateSize;
            cmd.Parameters.Add("@SupplyDate", SqlDbType.DateTime).Value = li_PlateTransferDetail.SupplyDate;
            cmd.Parameters.Add("@Receipt", SqlDbType.VarChar).Value = li_PlateTransferDetail.Receipt;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SlNo"].Value;
        }
    }

    public bool UpdateLi_PlateTransferDetail(li_PlateTransferDetail li_PlateTransferDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateTransferDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SlNo", SqlDbType.Int).Value = li_PlateTransferDetail.SlNo;
            cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = li_PlateTransferDetail.TransNo;
            cmd.Parameters.Add("@PlateBrand", SqlDbType.VarChar).Value = li_PlateTransferDetail.PlateBrand;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_PlateTransferDetail.UnitPrice;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_PlateTransferDetail.Qty;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
