using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlateProcessProvider:DataAccessObject
{
	public SqlLi_PlateProcessProvider()
    {
    }


    public bool DeleteLi_PlateProcess(int li_PlateProcessID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateProcess", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateProcessID", SqlDbType.Int).Value = li_PlateProcessID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateProcess> GetAllLi_PlateProcesss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateProcesss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateProcesssFromReader(reader);
        }
    }
    public List<Li_PlateProcess> GetLi_PlateProcesssFromReader(IDataReader reader)
    {
        List<Li_PlateProcess> li_PlateProcesss = new List<Li_PlateProcess>();

        while (reader.Read())
        {
            li_PlateProcesss.Add(GetLi_PlateProcessFromReader(reader));
        }
        return li_PlateProcesss;
    }

    public Li_PlateProcess GetLi_PlateProcessFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateProcess li_PlateProcess = new Li_PlateProcess
                (
 
                    reader["Pro_ID"].ToString(),
                    reader["ProcessID"].ToString(),
                    (int)reader["PlateQty"],
                    (decimal)reader["Rate"],
                    (decimal)reader["TotalBill"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (DateTime)reader["DelDate"],
                    (int)reader["DelBy"],
                    reader["CauseOfDel"].ToString(),
                    (char)reader["Status_D"] 
                );
             return li_PlateProcess;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateProcess GetLi_PlateProcessByID(int li_PlateProcessID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateProcessByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateProcessID", SqlDbType.Int).Value = li_PlateProcessID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateProcessFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PlateProcess(Li_PlateProcess li_PlateProcess)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateProcess", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@Pro_ID", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = li_PlateProcess.ProcessID;
            cmd.Parameters.Add("@PlateQty", SqlDbType.Int).Value = li_PlateProcess.PlateQty;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = li_PlateProcess.Rate;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PlateProcess.TotalBill;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateProcess.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateProcess.CreatedDate;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_PlateProcess.DelDate;
            cmd.Parameters.Add("@DelBy", SqlDbType.Int).Value = li_PlateProcess.DelBy;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_PlateProcess.CauseOfDel;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PlateProcess.Status_D;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@Pro_ID"].Value.ToString();
        }
    }

    public bool UpdateLi_PlateProcess(Li_PlateProcess li_PlateProcess)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateProcess", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@Pro_ID", SqlDbType.VarChar).Value = li_PlateProcess.Pro_ID;
            cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = li_PlateProcess.ProcessID;
            cmd.Parameters.Add("@PlateQty", SqlDbType.Int).Value = li_PlateProcess.PlateQty;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = li_PlateProcess.Rate;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PlateProcess.TotalBill;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateProcess.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateProcess.CreatedDate;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_PlateProcess.DelDate;
            cmd.Parameters.Add("@DelBy", SqlDbType.Int).Value = li_PlateProcess.DelBy;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_PlateProcess.CauseOfDel;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PlateProcess.Status_D;
       
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    public DataSet Get_PlatePurchaseOrderByReceiveID(string ReceiveID, string fromDate, string toDate)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetPlatePurchaseOrderByProcess", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = ReceiveID;
            command.Parameters.Add("@From", SqlDbType.VarChar).Value = fromDate;
            command.Parameters.Add("@To", SqlDbType.VarChar).Value = toDate;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public DataSet GetProcessOrderInforByDistinctPress(string OrderNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetProcessOrderInforByOrderNo_Distinct", connection);
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


    public DataSet getGodownPlateQty(string fromDate, string toDate)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetPlateGodownReceive", connection);
            command.CommandType = CommandType.StoredProcedure;
          
            command.Parameters.Add("@From", SqlDbType.VarChar).Value = fromDate;
            command.Parameters.Add("@To", SqlDbType.VarChar).Value = toDate;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
