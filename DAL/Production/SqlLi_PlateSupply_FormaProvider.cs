using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlateSupply_FormaProvider : DataAccessObject
{
    public SqlLi_PlateSupply_FormaProvider()
    {
    }


    public bool DeleteLi_PlateSupply_Forma(int li_PlateSupply_FormaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateSupply_Forma", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateSupply_FormaID", SqlDbType.Int).Value = li_PlateSupply_FormaID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateSupply_Forma> GetAllLi_PlateSupply_Formas()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateSupply_Formas", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateSupply_FormasFromReader(reader);
        }
    }
    public List<Li_PlateSupply_Forma> GetLi_PlateSupply_FormasFromReader(IDataReader reader)
    {
        List<Li_PlateSupply_Forma> li_PlateSupply_Formas = new List<Li_PlateSupply_Forma>();

        while (reader.Read())
        {
            li_PlateSupply_Formas.Add(GetLi_PlateSupply_FormaFromReader(reader));
        }
        return li_PlateSupply_Formas;
    }

    public Li_PlateSupply_Forma GetLi_PlateSupply_FormaFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateSupply_Forma li_PlateSupply_Forma = new Li_PlateSupply_Forma
                (

                    reader["Plate_SID"].ToString(),
                    reader["Print_OID"].ToString(),
                    reader["BookCode"].ToString(),
                    (int)reader["PlateQty"],
                    (decimal)reader["PlateBill"],
                    (decimal)reader["ProcessBill"],
                    (decimal)reader["TotalAmount"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (bool)reader["IsExtra"],
                    reader ["PlateFor"].ToString ()
                );
            return li_PlateSupply_Forma;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_PlateSupply_Forma GetLi_PlateSupply_FormaByID(int li_PlateSupply_FormaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateSupply_FormaByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateSupply_FormaID", SqlDbType.Int).Value = li_PlateSupply_FormaID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateSupply_FormaFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string InsertLi_PlateSupply_Forma(Li_PlateSupply_Forma li_PlateSupply_Forma)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_PlateSupply_Forma", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Plate_SID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Print_OID", SqlDbType.VarChar).Value = li_PlateSupply_Forma.Print_OID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PlateSupply_Forma.BookCode;
            cmd.Parameters.Add("@PlateQty", SqlDbType.Decimal).Value = li_PlateSupply_Forma.PlateQty;
            cmd.Parameters.Add("@PlateBill", SqlDbType.Decimal).Value = li_PlateSupply_Forma.PlateBill;
            cmd.Parameters.Add("@ProcessBill", SqlDbType.Decimal).Value = li_PlateSupply_Forma.ProcessBill;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_PlateSupply_Forma.TotalAmount;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateSupply_Forma.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateSupply_Forma.CreatedBy;
            cmd.Parameters.Add("@IsExtra", SqlDbType.Bit).Value = li_PlateSupply_Forma. IsExtra;
            cmd.Parameters.Add("@PlateFor", SqlDbType.VarChar).Value = li_PlateSupply_Forma. PlateFor ;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@Plate_SID"].Value.ToString();
        }
    }

    public bool UpdateLi_PlateSupply_Forma(Li_PlateSupply_Forma li_PlateSupply_Forma)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateSupply_Forma", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Plate_SID", SqlDbType.VarChar).Value = li_PlateSupply_Forma.Plate_SID;

            cmd.Parameters.Add("@Print_OID", SqlDbType.VarChar).Value = li_PlateSupply_Forma.Print_OID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PlateSupply_Forma.BookCode;
            cmd.Parameters.Add("@PlateQty", SqlDbType.Int).Value = li_PlateSupply_Forma.PlateQty;
            cmd.Parameters.Add("@PlateBill", SqlDbType.Decimal).Value = li_PlateSupply_Forma.PlateBill;
            cmd.Parameters.Add("@ProcessBill", SqlDbType.Decimal).Value = li_PlateSupply_Forma.ProcessBill;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_PlateSupply_Forma.TotalAmount;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateSupply_Forma.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateSupply_Forma.CreatedBy;
            cmd.Parameters.Add("@IsExtra", SqlDbType.Bit).Value = li_PlateSupply_Forma.IsExtra;
            cmd.Parameters.Add("@PlateFor", SqlDbType.VarChar).Value = li_PlateSupply_Forma.PlateFor;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }



    public DataSet getPlateOrderInfoByBookID(string BookID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetEditionOfPlateSupplyOrder", connection);
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


    public DataSet getPlateOrderInfoByEdition(string BookCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_getPrintOrderByPlateSupply", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public DataSet GetPlateDeliveryInforByPrintOrderNo(string OrderNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetPlateDeliveryInforByPrintOrderNo", connection);
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

    public DataSet GetPlateDeliveryInforByPrintOrderNoAndPress(string OrderNo,string PressID, bool IsExtra)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetPrintingPlateSupplyInfo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PrintOrder", SqlDbType.VarChar).Value = OrderNo;
            command.Parameters.Add("@PressID", SqlDbType.VarChar).Value =  PressID;
            command.Parameters.Add("@IsExtra", SqlDbType.Bit).Value =  IsExtra;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


}