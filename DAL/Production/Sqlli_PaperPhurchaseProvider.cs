using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperPhurchaseProvider : DataAccessObject
{
    public SqlLi_PaperPhurchaseProvider()
    {
    }


    public bool DeleteLi_PaperPhurchase(int li_PaperPhurchaseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperPhurchase", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperPhurchaseID", SqlDbType.Int).Value = li_PaperPhurchaseID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperPhurchase> GetAllLi_PaperPhurchases()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperPhurchases", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperPhurchasesFromReader(reader);
        }
    }
    public List<Li_PaperPhurchase> GetLi_PaperPhurchasesFromReader(IDataReader reader)
    {
        List<Li_PaperPhurchase> li_PaperPhurchases = new List<Li_PaperPhurchase>();

        while (reader.Read())
        {
            li_PaperPhurchases.Add(GetLi_PaperPhurchaseFromReader(reader));
        }
        return li_PaperPhurchases;
    }

    public Li_PaperPhurchase GetLi_PaperPhurchaseFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperPhurchase li_PaperPhurchase = new Li_PaperPhurchase
                (

                    reader["OrderNo"].ToString(),
                    (DateTime)reader["OrderDate"],
                    reader["PartyID"].ToString(),
                    reader["PaperSize"].ToString(),
                    reader["PaperType"].ToString(),
                    reader["PaperBrand"].ToString(),
                    reader["PaperOrigin"].ToString(),
                    reader["GSM"].ToString(),
                    (decimal)reader["Qty"],
                    reader["MUint"].ToString(),
                    (decimal)reader["UnitPrice"],
                    (decimal)reader["Total"],
                    reader["Remark"].ToString(),

                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (decimal)reader["Roll"],
                    reader["Purchase_OrderNo"].ToString()

                );
            return li_PaperPhurchase;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_PaperPhurchase GetLi_PaperPhurchaseByID(int li_PaperPhurchaseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperPhurchaseByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PaperPhurchaseID", SqlDbType.Int).Value = li_PaperPhurchaseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PaperPhurchaseFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string InsertLi_PaperPhurchase(Li_PaperPhurchase li_PaperPhurchase)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperPhurchase", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_PaperPhurchase.OrderDate;
            cmd.Parameters.Add("@PartyID", SqlDbType.VarChar).Value = li_PaperPhurchase.PartyID;
            cmd.Parameters.Add("@PaperSize", SqlDbType.VarChar).Value = li_PaperPhurchase.PaperSize;
            cmd.Parameters.Add("@PaperType", SqlDbType.VarChar).Value = li_PaperPhurchase.PaperType;
            cmd.Parameters.Add("@PaperBrand", SqlDbType.VarChar).Value = li_PaperPhurchase.PaperBrand;
            cmd.Parameters.Add("@PaperOrigin", SqlDbType.VarChar).Value = li_PaperPhurchase.PaperOrigin;
            cmd.Parameters.Add("@GSM", SqlDbType.VarChar).Value = li_PaperPhurchase.GSM;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_PaperPhurchase.Qty;
            cmd.Parameters.Add("@MUint", SqlDbType.VarChar).Value = li_PaperPhurchase.MUint;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_PaperPhurchase.UnitPrice;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = li_PaperPhurchase.Total;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PaperPhurchase.Remark;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperPhurchase.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperPhurchase.CreatedDate;
            cmd.Parameters.Add("Roll", SqlDbType.Decimal).Value = li_PaperPhurchase.Roll;
            cmd.Parameters.Add("@Purchase_OrderNo", SqlDbType.VarChar).Value = li_PaperPhurchase. Purchase_OrderNo;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@OrderNo"].Value.ToString();
        }
    }

    public bool UpdateLi_PaperPhurchase(Li_PaperPhurchase li_PaperPhurchase)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperPhurchase", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_PaperPhurchase.OrderNo;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_PaperPhurchase.OrderDate;
            cmd.Parameters.Add("@PartyID", SqlDbType.VarChar).Value = li_PaperPhurchase.PartyID;
            cmd.Parameters.Add("@PaperSize", SqlDbType.VarChar).Value = li_PaperPhurchase.PaperSize;
            cmd.Parameters.Add("@PaperType", SqlDbType.VarChar).Value = li_PaperPhurchase.PaperType;
            cmd.Parameters.Add("@PaperBrand", SqlDbType.VarChar).Value = li_PaperPhurchase.PaperBrand;
            cmd.Parameters.Add("@PaperOrigin", SqlDbType.VarChar).Value = li_PaperPhurchase.PaperOrigin;
            cmd.Parameters.Add("@GSM", SqlDbType.VarChar).Value = li_PaperPhurchase.GSM;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_PaperPhurchase.Qty;
            cmd.Parameters.Add("@MUint", SqlDbType.VarChar).Value = li_PaperPhurchase.MUint;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_PaperPhurchase.UnitPrice;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = li_PaperPhurchase.Total;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PaperPhurchase.Remark;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperPhurchase.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperPhurchase.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet Get_UndeliveredPurchaseOrder(string PartyID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetUnDeliveredPaperPurchaseOrderByParty", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PartyID", SqlDbType.VarChar).Value = PartyID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public DataSet Get_UndeliveredPurchaseItemByOrder(string OrderID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetUnDeliveredPaperPurchaseItemByOrder", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = OrderID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet Get_UndeliveredPurchaseItemByOrderAndParty(string OrderID, string PartyID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetUnDeliveredPaperPurchaseItemByOrderAndParty", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = OrderID;
            command.Parameters.Add("@PartyID", SqlDbType.VarChar).Value = PartyID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}