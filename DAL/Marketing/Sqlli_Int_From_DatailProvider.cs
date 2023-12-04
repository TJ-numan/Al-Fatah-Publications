using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Int_From_DatailProvider:DataAccessObject
{
	public SqlLi_Int_From_DatailProvider()
    {
    }


    public bool DeleteLi_Int_From_Datail(int li_Int_From_DatailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Int_From_Datail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Int_From_DatailID", SqlDbType.Int).Value = li_Int_From_DatailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Int_From_Datail> GetAllLi_Int_From_Datails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Int_From_Datails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Int_From_DatailsFromReader(reader);
        }
    }
    public List<Li_Int_From_Datail> GetLi_Int_From_DatailsFromReader(IDataReader reader)
    {
        List<Li_Int_From_Datail> li_Int_From_Datails = new List<Li_Int_From_Datail>();

        while (reader.Read())
        {
            li_Int_From_Datails.Add(GetLi_Int_From_DatailFromReader(reader));
        }
        return li_Int_From_Datails;
    }

    public Li_Int_From_Datail GetLi_Int_From_DatailFromReader(IDataReader reader)
    {
        try
        {
            Li_Int_From_Datail li_Int_From_Datail = new Li_Int_From_Datail
                (
                    
                    (int)reader["Ser_No"],
                    reader["ID"].ToString(),
                    reader["BookCode"].ToString(),
                    (int)reader["Qty"],
                    (bool)reader["IsBoishki"],
                    (bool)reader["IsBoishaki_Bonus"],
                    (bool)reader["IsAlim"],
                    (bool)reader["IsAlim_Bonus"],
                    (bool)reader["IsRegular"],
                    (char)reader["Status_D"],
                    (decimal)reader["DisAmount"] 
                     
                );
             return li_Int_From_Datail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Int_From_Datail GetLi_Int_From_DatailByID(int li_Int_From_DatailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Int_From_DatailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Int_From_DatailID", SqlDbType.Int).Value = li_Int_From_DatailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Int_From_DatailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Int_From_Datail(Li_Int_From_Datail li_Int_From_Datail,bool IsPartyChalan)
    {
        SqlCommand cmd;
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            if (IsPartyChalan == true)
            {
                cmd = new SqlCommand("SMPM_InsertLi_Int_From_Datail", connection);
            }
            else
            {
                cmd = new SqlCommand("SMPM_InsertLi_Int_From_Datail_Specimen", connection);
            }

            cmd.CommandType = CommandType.StoredProcedure;
            
         
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_Int_From_Datail.ID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_Int_From_Datail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_Int_From_Datail.Qty;
            cmd.Parameters.Add("@IsBoishki", SqlDbType.Bit).Value = li_Int_From_Datail.IsBoishki;
            cmd.Parameters.Add("@IsBoishaki_Bonus", SqlDbType.Bit).Value = li_Int_From_Datail.IsBoishaki_Bonus;
            cmd.Parameters.Add("@IsAlim", SqlDbType.Bit).Value = li_Int_From_Datail.IsAlim;
            cmd.Parameters.Add("@IsAlim_Bonus", SqlDbType.Bit).Value = li_Int_From_Datail.IsAlim_Bonus;
            cmd.Parameters.Add("@IsRegular", SqlDbType.Bit).Value = li_Int_From_Datail.IsRegular;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Int_From_Datail.Status_D;
            cmd.Parameters.Add("@DisAmount", SqlDbType.Decimal).Value = li_Int_From_Datail . DisAmount;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_Int_From_DatailID"].Value;
        }
    }

    public bool UpdateLi_Int_From_Datail(Li_Int_From_Datail li_Int_From_Datail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Int_From_Datail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@Ser_No", SqlDbType.Int).Value = li_Int_From_Datail.Ser_No;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_Int_From_Datail.ID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_Int_From_Datail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_Int_From_Datail.Qty;
            cmd.Parameters.Add("@IsBoishki", SqlDbType.Bit).Value = li_Int_From_Datail.IsBoishki;
            cmd.Parameters.Add("@IsBoishaki_Bonus", SqlDbType.Bit).Value = li_Int_From_Datail.IsBoishaki_Bonus;
            cmd.Parameters.Add("@IsAlim", SqlDbType.Bit).Value = li_Int_From_Datail.IsAlim;
            cmd.Parameters.Add("@IsAlim_Bonus", SqlDbType.Bit).Value = li_Int_From_Datail.IsAlim_Bonus;
            cmd.Parameters.Add("@IsRegular", SqlDbType.Bit).Value = li_Int_From_Datail.IsRegular;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Int_From_Datail.Status_D;
         
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
