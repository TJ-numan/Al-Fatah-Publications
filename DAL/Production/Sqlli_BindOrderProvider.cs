using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BindOrderProvider:DataAccessObject
{
	public SqlLi_BindOrderProvider()
    {
    }


    public bool DeleteLi_BindOrder(int li_BindOrderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BindOrder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BindOrderID", SqlDbType.Int).Value = li_BindOrderID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BindOrder> GetAllLi_BindOrders()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BindOrders", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BindOrdersFromReader(reader);
        }
    }
    public List<Li_BindOrder> GetLi_BindOrdersFromReader(IDataReader reader)
    {
        List<Li_BindOrder> li_BindOrders = new List<Li_BindOrder>();

        while (reader.Read())
        {
            li_BindOrders.Add(GetLi_BindOrderFromReader(reader));
        }
        return li_BindOrders;
    }

    public Li_BindOrder GetLi_BindOrderFromReader(IDataReader reader)
    {
        try
        {
            Li_BindOrder li_BindOrder = new Li_BindOrder
                (
                    
                    reader["BindCode"].ToString(),
                    reader["PressID"].ToString(),
                    reader["BinderID"].ToString(),
                    reader["BookCode"].ToString(),
                    (bool)reader["Iscover"],
                    (bool)reader["InInner"],
                    (bool)reader["IsNew"],
                    (bool)reader["IsRb"],
                    (int)reader["Qty"],
                    reader["WorkType"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (bool)reader["IsForma"] ,
                    (decimal)reader["FormaQty"],
                    (bool)reader["IsInnerForma"],
                    reader["PrintOrder"].ToString(),
                    reader ["Edition"].ToString ()
                );
             return li_BindOrder;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BindOrder GetLi_BindOrderByID(int li_BindOrderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BindOrderByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BindOrderID", SqlDbType.Int).Value = li_BindOrderID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BindOrderFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_BindOrder(Li_BindOrder li_BindOrder)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BindOrder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@BindCode", SqlDbType.VarChar,50) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_BindOrder.PressID;
            cmd.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = li_BindOrder.BinderID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BindOrder.BookCode;
            cmd.Parameters.Add("@Iscover", SqlDbType.Bit).Value = li_BindOrder.Iscover;
            cmd.Parameters.Add("@InInner", SqlDbType.Bit).Value = li_BindOrder.InInner;
            cmd.Parameters.Add("@IsNew", SqlDbType.Bit).Value = li_BindOrder.IsNew;
            cmd.Parameters.Add("@IsRb", SqlDbType.Bit).Value = li_BindOrder.IsRb;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_BindOrder.Qty;
            cmd.Parameters.Add("@WorkType", SqlDbType.VarChar).Value = li_BindOrder.WorkType;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BindOrder.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BindOrder.CreatedDate;
            cmd.Parameters.Add("@IsForma", SqlDbType.Bit).Value = li_BindOrder.IsForma;
            cmd.Parameters.Add("@FormaQty", SqlDbType.Decimal).Value = li_BindOrder.FormaQty ;
            cmd.Parameters.Add("@IsInnerForma", SqlDbType.Bit).Value = li_BindOrder.IsInnerForma;
            cmd.Parameters.Add("@PressOrder", SqlDbType.VarChar).Value = li_BindOrder.PrintOrder ;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_BindOrder.Edition;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@BindCode"].Value.ToString ();
        }
    }

    public bool UpdateLi_BindOrder(Li_BindOrder li_BindOrder)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BindOrder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BindCode", SqlDbType.VarChar).Value = li_BindOrder.BindCode;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_BindOrder.PressID;
            cmd.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = li_BindOrder.BinderID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BindOrder.BookCode;
            cmd.Parameters.Add("@Iscover", SqlDbType.Bit).Value = li_BindOrder.Iscover;
            cmd.Parameters.Add("@InInner", SqlDbType.Bit).Value = li_BindOrder.InInner;
            cmd.Parameters.Add("@IsNew", SqlDbType.Bit).Value = li_BindOrder.IsNew;
            cmd.Parameters.Add("@IsRb", SqlDbType.Bit).Value = li_BindOrder.IsRb;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_BindOrder.Qty;
            cmd.Parameters.Add("@WorkType", SqlDbType.VarChar).Value = li_BindOrder.WorkType;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BindOrder.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BindOrder.CreatedDate;
            cmd.Parameters.Add("@IsForma", SqlDbType.Bit).Value = li_BindOrder.IsForma;
            cmd.Parameters.Add("@FormaQty", SqlDbType.Decimal).Value = li_BindOrder.FormaQty;
            cmd.Parameters.Add("@IsInnerForma", SqlDbType.Bit).Value = li_BindOrder.IsInnerForma;
            cmd.Parameters.Add("@PressOrder", SqlDbType.VarChar).Value = li_BindOrder.PrintOrder;

            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAll_BindOrder(string BID, string CID, string Type, string edition, string BiderID, string PressID, Boolean? Cov, Boolean? Inn, Boolean? Forma)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_FormaCoverDeliveryInfo", connection);


            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = PressID;
            cmd.Parameters.Add("@BinderID", SqlDbType.VarChar).Value =  BiderID ;
            cmd.Parameters.Add("@BookName", SqlDbType.VarChar).Value = BID ;
            cmd.Parameters.Add("@Class", SqlDbType.VarChar).Value = CID ;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type ;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = edition ;
            cmd.Parameters.Add("@IsCover", SqlDbType.Bit).Value = Cov;
            cmd.Parameters.Add("@IsInner", SqlDbType.Bit).Value = Inn;
            cmd.Parameters.Add("@IsForma", SqlDbType.Bit).Value = Forma ;


            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
