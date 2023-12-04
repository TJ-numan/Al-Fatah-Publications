using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Paper_DeliveryProvider:DataAccessObject
{
	public SqlLi_Paper_DeliveryProvider()
    {
    }


    public bool DeleteLi_Paper_Delivery(int li_Paper_DeliveryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Paper_Delivery", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Paper_DeliveryID", SqlDbType.Int).Value = li_Paper_DeliveryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Paper_Delivery> GetAllLi_Paper_Deliveries()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Paper_Deliveries", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Paper_DeliveriesFromReader(reader);
        }
    }
    public List<Li_Paper_Delivery> GetLi_Paper_DeliveriesFromReader(IDataReader reader)
    {
        List<Li_Paper_Delivery> li_Paper_Deliveries = new List<Li_Paper_Delivery>();

        while (reader.Read())
        {
            li_Paper_Deliveries.Add(GetLi_Paper_DeliveryFromReader(reader));
        }
        return li_Paper_Deliveries;
    }

    public Li_Paper_Delivery GetLi_Paper_DeliveryFromReader(IDataReader reader)
    {
        try
        {
            Li_Paper_Delivery li_Paper_Delivery = new Li_Paper_Delivery
                (
                    
                    reader["InvNo"].ToString(),
                    reader["SupplierID"].ToString(),
                    reader["BillNo"].ToString(),
                    (DateTime)reader["BillDate"],
                    (decimal)reader["Amount"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (char)reader["Status_D"],
                    (int)reader["DeletBy"],
                    (DateTime)reader["DeleteDate"],
                    reader["CauseOFDel"].ToString(),
                    reader["Remark"].ToString() ,
                    (decimal )reader ["Lay_Cost"] ,
                    reader["Purchase_OrderNo"].ToString()
                );
             return li_Paper_Delivery;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Paper_Delivery GetLi_Paper_DeliveryByID(int li_Paper_DeliveryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Paper_DeliveryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Paper_DeliveryID", SqlDbType.Int).Value = li_Paper_DeliveryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Paper_DeliveryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_Paper_Delivery(Li_Paper_Delivery li_Paper_Delivery)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Paper_Delivery", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@InvNo", SqlDbType.VarChar,50).Direction  =  ParameterDirection .Output ;
            cmd.Parameters.Add("@SupplierID", SqlDbType.VarChar).Value = li_Paper_Delivery.SupplierID;
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_Paper_Delivery.BillNo;
            cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = li_Paper_Delivery.BillDate;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_Paper_Delivery.Amount;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Paper_Delivery.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Paper_Delivery.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Paper_Delivery.Status_D;
            cmd.Parameters.Add("@DeletBy", SqlDbType.Int).Value = DBNull .Value ;
            cmd.Parameters.Add("@DeleteDate", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@CauseOFDel", SqlDbType.VarChar).Value = DBNull.Value;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_Paper_Delivery.Remark;
            cmd.Parameters.Add("@Lay_Cost", SqlDbType.Decimal).Value = li_Paper_Delivery.Lay_Cost;
            //cmd.Parameters.Add("@Purchase_OrderNo", SqlDbType.VarChar).Value = "";// li_Paper_Delivery.Purchase_OrderNo;

        
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@InvNo"].Value.ToString ();
        }
    }

    public bool UpdateLi_Paper_Delivery(Li_Paper_Delivery li_Paper_Delivery)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Paper_Delivery", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@InvNo", SqlDbType.VarChar).Value = li_Paper_Delivery.InvNo;
            cmd.Parameters.Add("@SupplierID", SqlDbType.VarChar).Value = li_Paper_Delivery.SupplierID;
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_Paper_Delivery.BillNo;
            cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = li_Paper_Delivery.BillDate;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_Paper_Delivery.Amount;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Paper_Delivery.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Paper_Delivery.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Paper_Delivery.Status_D;
            cmd.Parameters.Add("@DeletBy", SqlDbType.DateTime).Value = li_Paper_Delivery.DeletBy;
            cmd.Parameters.Add("@DeleteDate", SqlDbType.DateTime).Value = li_Paper_Delivery.DeleteDate;
            cmd.Parameters.Add("@CauseOFDel", SqlDbType.VarChar).Value = li_Paper_Delivery.CauseOFDel;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_Paper_Delivery.Remark;
            cmd.Parameters.Add("@Lay_Cost", SqlDbType.Decimal).Value = li_Paper_Delivery.Lay_Cost;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet GetPaperBillInfo(string fromDate, string toDate, string SupplierID, string BillNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetPaperBillInfo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@From", SqlDbType.VarChar).Value = fromDate;
            command.Parameters.Add("@To", SqlDbType.VarChar).Value = toDate;
            command.Parameters.Add("@SupplierID", SqlDbType.VarChar).Value = SupplierID;
            command.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = BillNo;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }

    public  void  CancelPaperDelivery(int SlNo, string PressID, string PaperCode, decimal Qty, int deleBy, DateTime DeleteDate, string CauseOfDel, string DeleveryID)
    {
        
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_UpdatePaperDelivery", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@SlNo", SqlDbType.Int).Value = SlNo  ;
            command.Parameters.Add("@PressID", SqlDbType.VarChar).Value =   PressID ;
            command.Parameters.Add("@PaperCode", SqlDbType.VarChar).Value =  PaperCode  ;
            command.Parameters.Add("@Qty", SqlDbType. Decimal).Value =  Qty  ;

            command.Parameters.Add("@DeletBy", SqlDbType.Int).Value = deleBy  ;
            command.Parameters.Add("@DeleteDate", SqlDbType.DateTime).Value = DeleteDate ;
            command.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value =   CauseOfDel ;
            command.Parameters.Add("@DeliveryID", SqlDbType.VarChar).Value =  DeleveryID  ;

            connection.Open();
            command.ExecuteNonQuery();

        }
    }

}
