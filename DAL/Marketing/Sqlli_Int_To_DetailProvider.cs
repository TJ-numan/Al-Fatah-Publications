using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Int_To_DetailProvider:DataAccessObject
{
	public SqlLi_Int_To_DetailProvider()
    {
    }


    public bool DeleteLi_Int_To_Detail(int li_Int_To_DetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Int_To_Detail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Int_To_DetailID", SqlDbType.Int).Value = li_Int_To_DetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Int_To_Detail> GetAllLi_Int_To_Details()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Int_To_Details", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Int_To_DetailsFromReader(reader);
        }
    }
    public List<Li_Int_To_Detail> GetLi_Int_To_DetailsFromReader(IDataReader reader)
    {
        List<Li_Int_To_Detail> li_Int_To_Details = new List<Li_Int_To_Detail>();

        while (reader.Read())
        {
            li_Int_To_Details.Add(GetLi_Int_To_DetailFromReader(reader));
        }
        return li_Int_To_Details;
    }

    public Li_Int_To_Detail GetLi_Int_To_DetailFromReader(IDataReader reader)
    {
        try
        {
            Li_Int_To_Detail li_Int_To_Detail = new Li_Int_To_Detail
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
                    (char)reader["Status_D"] ,
                     (decimal)reader["DisAmount"] 
                );
             return li_Int_To_Detail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Int_To_Detail GetLi_Int_To_DetailByID(int li_Int_To_DetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Int_To_DetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Int_To_DetailID", SqlDbType.Int).Value = li_Int_To_DetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Int_To_DetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Int_To_Detail(Li_Int_To_Detail li_Int_To_Detail,bool IsPartyChalan)
    {           SqlCommand cmd; 
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            if (IsPartyChalan == true)
            {
                cmd = new SqlCommand("SMPM_InsertLi_Int_To_Detail", connection);
            }
            else
            {
                cmd = new SqlCommand("SMPM_InsertLi_Int_To_Detail_Specimen", connection);
            }
            cmd.CommandType = CommandType.StoredProcedure;
 
          
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_Int_To_Detail.ID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_Int_To_Detail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_Int_To_Detail.Qty;
            cmd.Parameters.Add("@IsBoishki", SqlDbType.Bit).Value = li_Int_To_Detail.IsBoishki;
            cmd.Parameters.Add("@IsBoishaki_Bonus", SqlDbType.Bit).Value = li_Int_To_Detail.IsBoishaki_Bonus;
            cmd.Parameters.Add("@IsAlim", SqlDbType.Bit).Value = li_Int_To_Detail.IsAlim;
            cmd.Parameters.Add("@IsAlim_Bonus", SqlDbType.Bit).Value = li_Int_To_Detail.IsAlim_Bonus;
            cmd.Parameters.Add("@IsRegular", SqlDbType.Bit).Value = li_Int_To_Detail.IsRegular;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Int_To_Detail.Status_D;
            cmd.Parameters.Add("@DisAmount", SqlDbType.Decimal).Value = li_Int_To_Detail .DisAmount;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_Int_To_DetailID"].Value;
        }
    }

    public bool UpdateLi_Int_To_Detail(Li_Int_To_Detail li_Int_To_Detail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Int_To_Detail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@Ser_No", SqlDbType.Int).Value = li_Int_To_Detail.Ser_No;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_Int_To_Detail.ID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_Int_To_Detail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_Int_To_Detail.Qty;
            cmd.Parameters.Add("@IsBoishki", SqlDbType.Bit).Value = li_Int_To_Detail.IsBoishki;
            cmd.Parameters.Add("@IsBoishaki_Bonus", SqlDbType.Bit).Value = li_Int_To_Detail.IsBoishaki_Bonus;
            cmd.Parameters.Add("@IsAlim", SqlDbType.Bit).Value = li_Int_To_Detail.IsAlim;
            cmd.Parameters.Add("@IsAlim_Bonus", SqlDbType.Bit).Value = li_Int_To_Detail.IsAlim_Bonus;
            cmd.Parameters.Add("@IsRegular", SqlDbType.Bit).Value = li_Int_To_Detail.IsRegular;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Int_To_Detail.Status_D;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
