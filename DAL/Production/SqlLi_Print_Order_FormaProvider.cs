using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Print_Order_FormaProvider:DataAccessObject
{
	public SqlLi_Print_Order_FormaProvider()
    {
    }


    public bool DeleteLi_Print_Order_Forma(int li_Print_Order_FormaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Print_Order_Forma", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Print_Order_FormaID", SqlDbType.Int).Value = li_Print_Order_FormaID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Print_Order_Forma> GetAllLi_Print_Order_Formas()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Print_Order_Formas", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Print_Order_FormasFromReader(reader);
        }
    }
    public List<Li_Print_Order_Forma> GetLi_Print_Order_FormasFromReader(IDataReader reader)
    {
        List<Li_Print_Order_Forma> li_Print_Order_Formas = new List<Li_Print_Order_Forma>();

        while (reader.Read())
        {
            li_Print_Order_Formas.Add(GetLi_Print_Order_FormaFromReader(reader));
        }
        return li_Print_Order_Formas;
    }

    public Li_Print_Order_Forma GetLi_Print_Order_FormaFromReader(IDataReader reader)
    {
        try
        {
            Li_Print_Order_Forma li_Print_Order_Forma = new Li_Print_Order_Forma
                (
              
                    reader["Print_OrderNo"].ToString(),
                    (DateTime)reader["OrderDate"],
                    reader["BookID"].ToString(),
                    reader["Edition"].ToString(),
                    (int)reader["PrintQty"],
                    (int)reader["PrintSl"],
                    (decimal)reader["FormaTotal"],
                    (decimal)reader["TotalBill"],
                    reader["Remark"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (char)reader["Status_D"],
                    (int)reader["DeleBy"],
                    (DateTime)reader["DeleDate"],
                    reader["CauseOfDel"].ToString() ,
                    reader  ["P_Type"].ToString (),
                    (bool) reader ["ShortForma"], 
                    (bool )reader ["OtherPrint"]
                );
             return li_Print_Order_Forma;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Print_Order_Forma GetLi_Print_Order_FormaByID(int li_Print_Order_FormaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Print_Order_FormaByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Print_Order_FormaID", SqlDbType.Int).Value = li_Print_Order_FormaID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Print_Order_FormaFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_Print_Order_Forma(Li_Print_Order_Forma li_Print_Order_Forma)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_Print_Order_Forma", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@Print_OrderNo", SqlDbType.VarChar,50).Direction = ParameterDirection .Output ;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_Print_Order_Forma.OrderDate;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_Print_Order_Forma.BookID;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_Print_Order_Forma.Edition;
            cmd.Parameters.Add("@PrintQty", SqlDbType.Int).Value = li_Print_Order_Forma.PrintQty;
            cmd.Parameters.Add("@PrintSl", SqlDbType.Int).Value = li_Print_Order_Forma.PrintSl;
            cmd.Parameters.Add("@FormaTotal", SqlDbType.Decimal).Value = li_Print_Order_Forma.FormaTotal;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_Print_Order_Forma.TotalBill;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_Print_Order_Forma.Remark;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Print_Order_Forma.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Print_Order_Forma.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Print_Order_Forma.Status_D;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = li_Print_Order_Forma.DeleBy;
            cmd.Parameters.Add("@DeleDate", SqlDbType.DateTime).Value = li_Print_Order_Forma.DeleDate;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_Print_Order_Forma.CauseOfDel;
            cmd.Parameters.Add("@P_Type", SqlDbType.VarChar).Value = li_Print_Order_Forma. P_Type ;
            cmd.Parameters .Add ("@ShortForma", SqlDbType.Bit).Value = li_Print_Order_Forma. S_Print   ;
            cmd.Parameters .Add ("@OtherPrint", SqlDbType.Bit).Value = li_Print_Order_Forma.O_Print   ;             	 
		
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@Print_OrderNo"].Value.ToString ();
        }
    }

    public bool UpdateLi_Print_Order_Forma(Li_Print_Order_Forma li_Print_Order_Forma)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Print_Order_Forma", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@Print_OrderNo", SqlDbType.VarChar).Value = li_Print_Order_Forma.Print_OrderNo;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_Print_Order_Forma.OrderDate;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_Print_Order_Forma.BookID;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_Print_Order_Forma.Edition;
            cmd.Parameters.Add("@PrintQty", SqlDbType.Int).Value = li_Print_Order_Forma.PrintQty;
            cmd.Parameters.Add("@PrintSl", SqlDbType.Int).Value = li_Print_Order_Forma.PrintSl;
            cmd.Parameters.Add("@FormaTotal", SqlDbType.Decimal).Value = li_Print_Order_Forma.FormaTotal;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_Print_Order_Forma.TotalBill;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_Print_Order_Forma.Remark;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Print_Order_Forma.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Print_Order_Forma.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Print_Order_Forma.Status_D;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = li_Print_Order_Forma.DeleBy;
            cmd.Parameters.Add("@DeleDate", SqlDbType.DateTime).Value = li_Print_Order_Forma.DeleDate;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_Print_Order_Forma.CauseOfDel;
            cmd.Parameters.Add("@P_Type", SqlDbType.VarChar).Value = li_Print_Order_Forma.P_Type;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }



    
    }


    public DataSet GetPrintOrderInforByOrderNo(string  OrderNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            
            SqlCommand command = new SqlCommand("web_SMPM_li_GetPrintOrderInforByOrderNo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OrderNO", SqlDbType.VarChar).Value = OrderNo;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }


    public DataSet GetPrintOrderInforByOrderNoAndPress(string OrderNo, string PressID, string OrderFor, bool ExtraPlate, bool ForBill)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = null;
            if (ForBill == true)
            {
                  command = new SqlCommand("SMPM_li_GetPrintingOrderInfo", connection);
            }

            else
            {
                  command = new SqlCommand("SMPM_li_GetPrintingOrderInfo_ActualUsed", connection);
            }

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@PrintOrder", SqlDbType.VarChar).Value = OrderNo;
            command.Parameters.Add("@PressID", SqlDbType.VarChar).Value = PressID ;
            command.Parameters.Add("@OrderFor", SqlDbType.VarChar).Value = OrderFor ;
            command.Parameters.Add("@ExtraPlate", SqlDbType.Bit).Value = ExtraPlate;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }



    public DataSet GetPrintOrderInforByDistinctPress(string OrderNo, string OrderFor) 
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("web_SMPM_li_GetPrintOrderInforByOrderNo_Distinct", connection); 
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OrderNO", SqlDbType.VarChar).Value = OrderNo;
            command.Parameters.Add("@OrderFor", SqlDbType.VarChar).Value = OrderFor ;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet getPrintOrderFormaInfoByBookID(string BookID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_getPrintingOrderFormaInfoByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


     public DataSet getPrintOrderFormaOderNoInfoByBookIDEdition(string BookID,string Edition)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_li_getPrintingOrderFormaOrderNoInfoByBookIDEdition", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
                command.Parameters.Add("@Edition", SqlDbType.VarChar).Value = Edition;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);

                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();

                return ds;
            }
        }






    public DataSet getPrintingOrderInfoDetailByBookIDEditionOrder(string BookID, string Edition, string OrderNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_getPestingOrderDetailInfoByBookIDEditionOrder", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
            command.Parameters.Add("@Edition", SqlDbType.VarChar).Value = Edition;
            command.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = OrderNo;


            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public DataSet getPrintingQtyAndPrintSl(string BookCode,  char  PrintFor)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_getPrintQtyAndPrintSl", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
           
            command.Parameters.Add("@PrintFor", SqlDbType.Char).Value = PrintFor ;
               


            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
