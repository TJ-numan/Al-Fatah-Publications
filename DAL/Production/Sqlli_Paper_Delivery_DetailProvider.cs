using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Paper_Delivery_DetailProvider:DataAccessObject
{
	public SqlLi_Paper_Delivery_DetailProvider()
    {
    }


    public bool DeleteLi_Paper_Delivery_Detail(int li_Paper_Delivery_DetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Paper_Delivery_Detail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Paper_Delivery_DetailID", SqlDbType.Int).Value = li_Paper_Delivery_DetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Paper_Delivery_Detail> GetAllLi_Paper_Delivery_Details()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Paper_Delivery_Details", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Paper_Delivery_DetailsFromReader(reader);
        }
    }
    public List<Li_Paper_Delivery_Detail> GetLi_Paper_Delivery_DetailsFromReader(IDataReader reader)
    {
        List<Li_Paper_Delivery_Detail> li_Paper_Delivery_Details = new List<Li_Paper_Delivery_Detail>();

        while (reader.Read())
        {
            li_Paper_Delivery_Details.Add(GetLi_Paper_Delivery_DetailFromReader(reader));
        }
        return li_Paper_Delivery_Details;
    }

    public Li_Paper_Delivery_Detail GetLi_Paper_Delivery_DetailFromReader(IDataReader reader)
    {
        try
        {
            Li_Paper_Delivery_Detail li_Paper_Delivery_Detail = new Li_Paper_Delivery_Detail
                (
                    
                    (int)reader["SlNo"],
                    reader["InvID"].ToString(),
                    reader["PressID"].ToString(),
                    reader["PressRefNo"].ToString(),
                    (DateTime)reader["DeliveryDate"],
                    reader["P_TS_ID"].ToString(),
                    reader["PaperBrand"].ToString(),
                    reader["PaperOrigin"].ToString(),
                    (decimal)reader["UnitPrice"],
                    (decimal)reader["Qty"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Status_D"],
                    reader["TypeID"].ToString(),
                    reader["SizeID"].ToString(),
                    reader["GSM"].ToString() ,
                    reader["PurchaseOrder"].ToString() ,
                    (decimal)reader["RollQty"] 

                );
             return li_Paper_Delivery_Detail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Paper_Delivery_Detail GetLi_Paper_Delivery_DetailByID(int li_Paper_Delivery_DetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Paper_Delivery_DetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Paper_Delivery_DetailID", SqlDbType.Int).Value = li_Paper_Delivery_DetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Paper_Delivery_DetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Paper_Delivery_Detail(Li_Paper_Delivery_Detail li_Paper_Delivery_Detail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Paper_Delivery_Detail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
          //  cmd.Parameters.Add("@SlNo", SqlDbType.Int).Value = li_Paper_Delivery_Detail.SlNo;
            cmd.Parameters.Add("@InvID", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.InvID;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.PressID;
            cmd.Parameters.Add("@PressRefNo", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.PressRefNo;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_Paper_Delivery_Detail.DeliveryDate;
           // cmd.Parameters.Add("@P_TS_ID", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.P_TS_ID;
            cmd.Parameters.Add("@PaperBrand", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.PaperBrand;
            cmd.Parameters.Add("@PaperOrigin", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.PaperOrigin;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_Paper_Delivery_Detail.UnitPrice;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_Paper_Delivery_Detail.Qty;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Paper_Delivery_Detail.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Paper_Delivery_Detail.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Paper_Delivery_Detail.Status_D;
            cmd.Parameters.Add("@TypeID", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.TypeID;
            cmd.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.SizeID;
            cmd.Parameters.Add("@GSMID", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.GSM;
            cmd.Parameters.Add("@PurchaseOrder", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.PurchaseOrder ;   
            cmd.Parameters.Add("@RollQty", SqlDbType.Decimal).Value = li_Paper_Delivery_Detail. RollQty;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_Paper_Delivery_DetailID"].Value;
        }
    }

    public bool UpdateLi_Paper_Delivery_Detail(Li_Paper_Delivery_Detail li_Paper_Delivery_Detail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Paper_Delivery_Detail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@SlNo", SqlDbType.Int).Value = li_Paper_Delivery_Detail.SlNo;
            cmd.Parameters.Add("@InvID", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.InvID;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.PressID;
            cmd.Parameters.Add("@PressRefNo", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.PressRefNo;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_Paper_Delivery_Detail.DeliveryDate;
            cmd.Parameters.Add("@P_TS_ID", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.P_TS_ID;
            cmd.Parameters.Add("@PaperBrand", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.PaperBrand;
            cmd.Parameters.Add("@PaperOrigin", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.PaperOrigin;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_Paper_Delivery_Detail.UnitPrice;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_Paper_Delivery_Detail.Qty;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Paper_Delivery_Detail.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Paper_Delivery_Detail.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Paper_Delivery_Detail.Status_D;
            cmd.Parameters.Add("@TypeID", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.TypeID;
            cmd.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.SizeID;
            cmd.Parameters.Add("@GSM", SqlDbType.VarChar).Value = li_Paper_Delivery_Detail.GSM;
      
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataTable GetQtyAndReceiptByPaperCode(string paperTypeId, string paperSizeId, string paperGsmId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQtyAndReceiptByPaperCode", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TypeID", SqlDbType.VarChar).Value = paperTypeId;
            command.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = paperSizeId;
            command.Parameters.Add("@GSMID", SqlDbType.VarChar).Value = paperGsmId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
}
