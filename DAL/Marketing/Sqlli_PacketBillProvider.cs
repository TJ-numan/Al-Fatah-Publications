using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PacketBillProvider:DataAccessObject
{
	public SqlLi_PacketBillProvider()
    {
    }


    public bool DeleteLi_PacketBill(int li_PacketBillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PacketBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PacketBillID", SqlDbType.Int).Value = li_PacketBillID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PacketBill> GetAllLi_PacketBills()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PacketBills", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PacketBillsFromReader(reader);
        }
    }
    public List<Li_PacketBill> GetLi_PacketBillsFromReader(IDataReader reader)
    {
        List<Li_PacketBill> li_PacketBills = new List<Li_PacketBill>();

        while (reader.Read())
        {
            li_PacketBills.Add(GetLi_PacketBillFromReader(reader));
        }
        return li_PacketBills;
    }

    public Li_PacketBill GetLi_PacketBillFromReader(IDataReader reader)
    {
        try
        {
            Li_PacketBill li_PacketBill = new Li_PacketBill
                (
                    
                    reader["MemoNo"].ToString(),
                    reader["TransportID"].ToString(),
                    reader["LibraryID"].ToString(),
                    reader["LibraryName"].ToString(),
                    reader["LibraryAddress"].ToString(),
                    reader["TransportName"].ToString(),
                    reader["RRNo"].ToString(),
                    (decimal)reader["PackNo"],
                    (decimal)reader["PerPacCost"],
                    (decimal)reader["TotalPackCost"],
                    (DateTime)reader["ChalanDate"],
                    (DateTime)reader["DeliveryDate"],
                    (int)reader["CreatedBy"] ,
                    (int)reader["IsPending"],
                    (decimal )reader ["Van"],
                    (decimal)reader["VanOwn"],
                    (decimal)reader["LabourLoad"],
                    (decimal)reader["LabourUnload"],
                    (decimal )reader ["Transport"],
                    (decimal)reader["TransportOwn"],
                    (decimal )reader ["Choat"],
                    (decimal )reader ["Polithin"],
                    (decimal )reader ["SelaiIn"],
                    (decimal )reader ["SelaiOut"],
                    (bool )reader ["ISQawmi"]
                );
             return li_PacketBill;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PacketBill GetLi_PacketBillByID(int li_PacketBillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PacketBillByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PacketBillID", SqlDbType.Int).Value = li_PacketBillID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PacketBillFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PacketBill(Li_PacketBill li_PacketBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PacketBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_PacketBill.MemoNo;
            cmd.Parameters.Add("@TransportID", SqlDbType.VarChar).Value = li_PacketBill.TransportID;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_PacketBill.LibraryID;
            cmd.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = li_PacketBill.LibraryName;
            cmd.Parameters.Add("@LibraryAddress", SqlDbType.VarChar).Value = li_PacketBill.LibraryAddress;
            cmd.Parameters.Add("@TransportName", SqlDbType.VarChar).Value = li_PacketBill.TransportName;
            cmd.Parameters.Add("@RRNo", SqlDbType.VarChar).Value = li_PacketBill.RRNo;
            cmd.Parameters.Add("@PackNo", SqlDbType.Decimal).Value = li_PacketBill.PackNo;
            cmd.Parameters.Add("@PerPacCost", SqlDbType.Decimal).Value = li_PacketBill.PerPacCost;
            cmd.Parameters.Add("@TotalPackCost", SqlDbType.Decimal).Value = li_PacketBill.TotalPackCost;
            cmd.Parameters.Add("@ChalanDate", SqlDbType.DateTime).Value = li_PacketBill.ChalanDate;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_PacketBill.DeliveryDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PacketBill.CreatedBy;
            cmd.Parameters.Add("@IsComplete", SqlDbType.Int).Value = li_PacketBill.IsPending  ;

            cmd.Parameters.Add("@Van", SqlDbType.Decimal).Value = li_PacketBill.Van;
            cmd.Parameters.Add("@VanOwn", SqlDbType.Decimal).Value = li_PacketBill.VanOwn;
            cmd.Parameters.Add("@LabourLoad", SqlDbType.Decimal).Value = li_PacketBill.LabourLoad;
            cmd.Parameters.Add("@LabourUnload", SqlDbType.Decimal).Value = li_PacketBill.LabourUnload;
            cmd.Parameters.Add("@Transport", SqlDbType.Decimal).Value = li_PacketBill.Transport ;
            cmd.Parameters.Add("@TransportOwn", SqlDbType.Decimal).Value = li_PacketBill.TransportOwn;
            cmd.Parameters.Add("@Choat", SqlDbType.Decimal).Value = li_PacketBill.Choat ;
            cmd.Parameters.Add("@Polithin", SqlDbType.Decimal).Value = li_PacketBill.Polithin;

            cmd.Parameters.Add("@SelaiIn", SqlDbType.Decimal).Value = li_PacketBill. SelaiIn;
            cmd.Parameters.Add("@SelaiOut", SqlDbType.Decimal).Value = li_PacketBill. SelaiOut; 
            cmd.Parameters.Add("@ISQawmi", SqlDbType.Bit   ).Value = li_PacketBill.ISQawmi;       
    
   
     
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  1;
        }
    }


    public int InsertLi_SpecimenPacketBill(Li_PacketBill li_PacketBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_SpecimenPacketBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_PacketBill.MemoNo;
            cmd.Parameters.Add("@TransportID", SqlDbType.VarChar).Value = li_PacketBill.TransportID;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_PacketBill.LibraryID;
            cmd.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = li_PacketBill.LibraryName;
            cmd.Parameters.Add("@LibraryAddress", SqlDbType.VarChar).Value = li_PacketBill.LibraryAddress;
            cmd.Parameters.Add("@TransportName", SqlDbType.VarChar).Value = li_PacketBill.TransportName;
            cmd.Parameters.Add("@RRNo", SqlDbType.VarChar).Value = li_PacketBill.RRNo;
            cmd.Parameters.Add("@PackNo", SqlDbType.Decimal).Value = li_PacketBill.PackNo;
            cmd.Parameters.Add("@PerPacCost", SqlDbType.Decimal).Value = li_PacketBill.PerPacCost;
            cmd.Parameters.Add("@TotalPackCost", SqlDbType.Decimal).Value = li_PacketBill.TotalPackCost;
            cmd.Parameters.Add("@ChalanDate", SqlDbType.DateTime).Value = li_PacketBill.ChalanDate;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_PacketBill.DeliveryDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PacketBill.CreatedBy;
            cmd.Parameters.Add("@IsComplete", SqlDbType.Int).Value = li_PacketBill.IsPending;

            cmd.Parameters.Add("@Van", SqlDbType.Decimal).Value = li_PacketBill.Van;
            cmd.Parameters.Add("@VanOwn", SqlDbType.Decimal).Value = li_PacketBill.VanOwn;
            cmd.Parameters.Add("@LabourLoad", SqlDbType.Decimal).Value = li_PacketBill.LabourLoad;
            cmd.Parameters.Add("@LabourUnload", SqlDbType.Decimal).Value = li_PacketBill.LabourUnload;
            cmd.Parameters.Add("@Transport", SqlDbType.Decimal).Value = li_PacketBill.Transport;
            cmd.Parameters.Add("@TransportOwn", SqlDbType.Decimal).Value = li_PacketBill.TransportOwn;
            cmd.Parameters.Add("@Choat", SqlDbType.Decimal).Value = li_PacketBill.Choat;
            cmd.Parameters.Add("@Polithin", SqlDbType.Decimal).Value = li_PacketBill.Polithin;

            cmd.Parameters.Add("@SelaiIn", SqlDbType.Decimal).Value = li_PacketBill.SelaiIn;
            cmd.Parameters.Add("@SelaiOut", SqlDbType.Decimal).Value = li_PacketBill.SelaiOut;  



            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }





    public bool UpdateLi_PacketBill(Li_PacketBill li_PacketBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PacketBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_PacketBill.MemoNo;
            cmd.Parameters.Add("@TransportID", SqlDbType.VarChar).Value = li_PacketBill.TransportID;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_PacketBill.LibraryID;
            cmd.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = li_PacketBill.LibraryName;
            cmd.Parameters.Add("@LibraryAddress", SqlDbType.VarChar).Value = li_PacketBill.LibraryAddress;
            cmd.Parameters.Add("@TransportName", SqlDbType.VarChar).Value = li_PacketBill.TransportName;
            cmd.Parameters.Add("@RRNo", SqlDbType.VarChar).Value = li_PacketBill.RRNo;
            cmd.Parameters.Add("@PackNo", SqlDbType.Decimal).Value = li_PacketBill.PackNo;
            cmd.Parameters.Add("@PerPacCost", SqlDbType.Decimal).Value = li_PacketBill.PerPacCost;
            cmd.Parameters.Add("@TotalPackCost", SqlDbType.Decimal).Value = li_PacketBill.TotalPackCost;
            cmd.Parameters.Add("@ChalanDate", SqlDbType.DateTime).Value = li_PacketBill.ChalanDate;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_PacketBill.DeliveryDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PacketBill.CreatedBy;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
