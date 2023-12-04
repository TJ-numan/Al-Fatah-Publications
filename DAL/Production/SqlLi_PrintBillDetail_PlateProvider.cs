using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PrintBillDetail_PlateProvider:DataAccessObject
{
	public SqlLi_PrintBillDetail_PlateProvider()
    {
    }


    public bool DeleteLi_PrintBillDetail_Plate(int li_PrintBillDetail_PlateID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PrintBillDetail_Plate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PrintBillDetail_PlateID", SqlDbType.Int).Value = li_PrintBillDetail_PlateID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PrintBillDetail_Plate> GetAllLi_PrintBillDetail_Plates()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PrintBillDetail_Plates", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PrintBillDetail_PlatesFromReader(reader);
        }
    }
    public List<Li_PrintBillDetail_Plate> GetLi_PrintBillDetail_PlatesFromReader(IDataReader reader)
    {
        List<Li_PrintBillDetail_Plate> li_PrintBillDetail_Plates = new List<Li_PrintBillDetail_Plate>();

        while (reader.Read())
        {
            li_PrintBillDetail_Plates.Add(GetLi_PrintBillDetail_PlateFromReader(reader));
        }
        return li_PrintBillDetail_Plates;
    }

    public Li_PrintBillDetail_Plate GetLi_PrintBillDetail_PlateFromReader(IDataReader reader)
    {
        try
        {
            Li_PrintBillDetail_Plate li_PrintBillDetail_Plate = new Li_PrintBillDetail_Plate
                (
                   
                    (int)reader["SerialNo"],
                    (int)reader["BillSerial"],
                    (int)reader["PintPSerial"],
                    (int)reader["PlateQty"],
                    (decimal)reader["PlateRate"],
                    (decimal)reader["ProcessRate"],
                    (decimal)reader["TotalBill"] 
                );
             return li_PrintBillDetail_Plate;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PrintBillDetail_Plate GetLi_PrintBillDetail_PlateByID(int li_PrintBillDetail_PlateID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PrintBillDetail_PlateByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PrintBillDetail_PlateID", SqlDbType.Int).Value = li_PrintBillDetail_PlateID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PrintBillDetail_PlateFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PrintBillDetail_Plate(Li_PrintBillDetail_Plate li_PrintBillDetail_Plate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PrintBillDetail_Plate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).  Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BillSerial", SqlDbType.Int).Value = li_PrintBillDetail_Plate.BillSerial;
            cmd.Parameters.Add("@PintPSerial", SqlDbType.Int).Value = li_PrintBillDetail_Plate.PintPSerial;
            cmd.Parameters.Add("@PlateQty", SqlDbType.Int).Value = li_PrintBillDetail_Plate.PlateQty;
            cmd.Parameters.Add("@PlateRate", SqlDbType.Decimal).Value = li_PrintBillDetail_Plate.PlateRate;
            cmd.Parameters.Add("@ProcessRate", SqlDbType.Decimal).Value = li_PrintBillDetail_Plate.ProcessRate;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PrintBillDetail_Plate.TotalBill;
       
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1 ;//(int)cmd.Parameters["@Li_PrintBillDetail_PlateID"].Value;
        }
    }

    public bool UpdateLi_PrintBillDetail_Plate(Li_PrintBillDetail_Plate li_PrintBillDetail_Plate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PrintBillDetail_Plate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_PrintBillDetail_Plate.SerialNo;
            cmd.Parameters.Add("@BillSerial", SqlDbType.Int).Value = li_PrintBillDetail_Plate.BillSerial;
            cmd.Parameters.Add("@PintPSerial", SqlDbType.Int).Value = li_PrintBillDetail_Plate.PintPSerial;
            cmd.Parameters.Add("@PlateQty", SqlDbType.Int).Value = li_PrintBillDetail_Plate.PlateQty;
            cmd.Parameters.Add("@PlateRate", SqlDbType.Decimal).Value = li_PrintBillDetail_Plate.PlateRate;
            cmd.Parameters.Add("@ProcessRate", SqlDbType.Decimal).Value = li_PrintBillDetail_Plate.ProcessRate;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PrintBillDetail_Plate.TotalBill;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
