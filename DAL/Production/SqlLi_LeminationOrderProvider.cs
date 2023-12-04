using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_LeminationOrderProvider:DataAccessObject
{
	public SqlLi_LeminationOrderProvider()
    {
    }


    public bool DeleteLi_LeminationOrder(int li_LeminationOrderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_LeminationOrder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_LeminationOrderID", SqlDbType.Int).Value = li_LeminationOrderID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LeminationOrder> GetAllLi_LeminationOrders()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_LeminationOrders", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LeminationOrdersFromReader(reader);
        }
    }
    public List<Li_LeminationOrder> GetLi_LeminationOrdersFromReader(IDataReader reader)
    {
        List<Li_LeminationOrder> li_LeminationOrders = new List<Li_LeminationOrder>();

        while (reader.Read())
        {
            li_LeminationOrders.Add(GetLi_LeminationOrderFromReader(reader));
        }
        return li_LeminationOrders;
    }

    public Li_LeminationOrder GetLi_LeminationOrderFromReader(IDataReader reader)
    {
        try
        {
            Li_LeminationOrder li_LeminationOrder = new Li_LeminationOrder
                (
                     
                    reader["OrderNo"].ToString(),
                    (DateTime)reader["OrderDate"],
                    reader["PrintOrderNo"].ToString(),
                    reader["BookCode"].ToString(),
                    (int)reader["TotalQty"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Status_D"],
                    (DateTime)reader["DeleDate"],
                    reader["CauseOfDel"].ToString(),
                    (int)reader["DeleBy"] 
                );
             return li_LeminationOrder;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LeminationOrder GetLi_LeminationOrderByID(int li_LeminationOrderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_LeminationOrderByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_LeminationOrderID", SqlDbType.Int).Value = li_LeminationOrderID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LeminationOrderFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_LeminationOrder(Li_LeminationOrder li_LeminationOrder)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_LeminationOrder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_LeminationOrder.OrderDate;
            cmd.Parameters.Add("@PrintOrderNo", SqlDbType.VarChar).Value = li_LeminationOrder.PrintOrderNo;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_LeminationOrder.BookCode;
            cmd.Parameters.Add("@TotalQty", SqlDbType.Int).Value = li_LeminationOrder.TotalQty;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeminationOrder.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeminationOrder.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_LeminationOrder.Status_D;
            cmd.Parameters.Add("@DeleDate", SqlDbType.DateTime).Value = li_LeminationOrder.DeleDate;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_LeminationOrder.CauseOfDel;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = li_LeminationOrder.DeleBy;
      
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@OrderNo"].Value.ToString ();
        }
    }

    public bool UpdateLi_LeminationOrder(Li_LeminationOrder li_LeminationOrder)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_LeminationOrder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_LeminationOrder.OrderNo;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_LeminationOrder.OrderDate;
            cmd.Parameters.Add("@PrintOrderNo", SqlDbType.VarChar).Value = li_LeminationOrder.PrintOrderNo;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_LeminationOrder.BookCode;
            cmd.Parameters.Add("@TotalQty", SqlDbType.Int).Value = li_LeminationOrder.TotalQty;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeminationOrder.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeminationOrder.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_LeminationOrder.Status_D;
            cmd.Parameters.Add("@DeleDate", SqlDbType.DateTime).Value = li_LeminationOrder.DeleDate;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_LeminationOrder.CauseOfDel;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = li_LeminationOrder.DeleBy;
       
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }



    public DataSet GetLeminationOrderForPrint(string LemiParty, string FromDate ,string EndDate)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetLeminationOrderInfoByParty", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LemiParty", SqlDbType.VarChar).Value = LemiParty;
            command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value =FromDate ;
            command.Parameters.Add("@todate", SqlDbType.VarChar).Value = EndDate;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
