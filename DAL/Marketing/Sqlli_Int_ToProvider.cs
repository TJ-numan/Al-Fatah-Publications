using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Int_ToProvider:DataAccessObject
{
	public SqlLi_Int_ToProvider()
    {
    }


    public bool DeleteLi_Int_To(int li_Int_ToID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Int_To", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Int_ToID", SqlDbType.Int).Value = li_Int_ToID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Int_To> GetAllLi_Int_Tos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Int_Tos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Int_TosFromReader(reader);
        }
    }
    public List<Li_Int_To> GetLi_Int_TosFromReader(IDataReader reader)
    {
        List<Li_Int_To> li_Int_Tos = new List<Li_Int_To>();

        while (reader.Read())
        {
            li_Int_Tos.Add(GetLi_Int_ToFromReader(reader));
        }
        return li_Int_Tos;
    }

    public Li_Int_To GetLi_Int_ToFromReader(IDataReader reader)
    {
        try
        {
            Li_Int_To li_Int_To = new Li_Int_To
                (
                     
                    reader["ID"].ToString(),
                    reader["SlipNo"].ToString(),
                    reader["LibraryID"].ToString(),
                    (decimal)reader["TotalAmount"],
                    (int)reader["PacQty"],
                    (decimal)reader["Per_Pac_Cost"],
                    (decimal)reader["AmoutReceivable"],
                    (DateTime)reader["Trans_Date"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (bool)reader["IsBoishki"],
                    (bool)reader["IsBoishki_Bonus"],
                    (bool)reader["IsAlim"],
                    (bool)reader["IsAlim_bonus"],
                    (bool)reader["IsRegular"],
                    (char)reader["Status_D"],
                    (int)reader["DeleteBy"],
                    (DateTime)reader["Dele_Date"],
                    reader["Cause_Del"].ToString() ,
                    (decimal )reader ["BonusAmount"] 
                );
             return li_Int_To;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Int_To GetLi_Int_ToByID(int li_Int_ToID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Int_ToByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Int_ToID", SqlDbType.Int).Value = li_Int_ToID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Int_ToFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_Int_To(Li_Int_To li_Int_To,bool IsPartyChalan)
    { SqlCommand cmd;
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            if (IsPartyChalan == true)
            {

                cmd = new SqlCommand("SMPM_InsertLi_Int_To", connection);
            }
            else
            {
                cmd = new SqlCommand("SMPM_InsertLi_Int_To_Specimen", connection);
            }
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50).Direction =ParameterDirection .Output ;
            cmd.Parameters.Add("@SlipNo", SqlDbType.VarChar).Value = li_Int_To.SlipNo;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Int_To.LibraryID;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_Int_To.TotalAmount;
            cmd.Parameters.Add("@PacQty", SqlDbType.Int).Value = li_Int_To.PacQty;
            cmd.Parameters.Add("@Per_Pac_Cost", SqlDbType.Decimal).Value = li_Int_To.Per_Pac_Cost;
            cmd.Parameters.Add("@AmoutReceivable", SqlDbType.Decimal).Value = li_Int_To.AmoutReceivable;
            cmd.Parameters.Add("@Trans_Date", SqlDbType.DateTime).Value = li_Int_To.Trans_Date;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Int_To.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Int_To.CreatedDate;
            cmd.Parameters.Add("@IsBoishki", SqlDbType.Bit).Value = li_Int_To.IsBoishki;
            cmd.Parameters.Add("@IsBoishki_Bonus", SqlDbType.Bit).Value = li_Int_To.IsBoishki_Bonus;
            cmd.Parameters.Add("@IsAlim", SqlDbType.Bit).Value = li_Int_To.IsAlim;
            cmd.Parameters.Add("@IsAlim_bonus", SqlDbType.Bit).Value = li_Int_To.IsAlim_bonus;
            cmd.Parameters.Add("@IsRegular", SqlDbType.Bit).Value = li_Int_To.IsRegular;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Int_To.Status_D;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = li_Int_To.DeleteBy;
            cmd.Parameters.Add("@Dele_Date", SqlDbType.DateTime).Value = li_Int_To.Dele_Date;
            cmd.Parameters.Add("@Cause_Del", SqlDbType.VarChar).Value = li_Int_To.Cause_Del;
            cmd.Parameters.Add("@BonusAmount", SqlDbType.Decimal).Value = li_Int_To .BonusAmount;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value .ToString ();
        }
    }

    public bool UpdateLi_Int_To(Li_Int_To li_Int_To)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Int_To", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_Int_To.ID;
            cmd.Parameters.Add("@SlipNo", SqlDbType.VarChar).Value = li_Int_To.SlipNo;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Int_To.LibraryID;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_Int_To.TotalAmount;
            cmd.Parameters.Add("@PacQty", SqlDbType.Int).Value = li_Int_To.PacQty;
            cmd.Parameters.Add("@Per_Pac_Cost", SqlDbType.Decimal).Value = li_Int_To.Per_Pac_Cost;
            cmd.Parameters.Add("@AmoutReceivable", SqlDbType.Decimal).Value = li_Int_To.AmoutReceivable;
            cmd.Parameters.Add("@Trans_Date", SqlDbType.DateTime).Value = li_Int_To.Trans_Date;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Int_To.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Int_To.CreatedDate;
            cmd.Parameters.Add("@IsBoishki", SqlDbType.Bit).Value = li_Int_To.IsBoishki;
            cmd.Parameters.Add("@IsBoishki_Bonus", SqlDbType.Bit).Value = li_Int_To.IsBoishki_Bonus;
            cmd.Parameters.Add("@IsAlim", SqlDbType.Bit).Value = li_Int_To.IsAlim;
            cmd.Parameters.Add("@IsAlim_bonus", SqlDbType.Bit).Value = li_Int_To.IsAlim_bonus;
            cmd.Parameters.Add("@IsRegular", SqlDbType.Bit).Value = li_Int_To.IsRegular;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Int_To.Status_D;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = li_Int_To.DeleteBy;
            cmd.Parameters.Add("@Dele_Date", SqlDbType.DateTime).Value = li_Int_To.Dele_Date;
            cmd.Parameters.Add("@Cause_Del", SqlDbType.VarChar).Value = li_Int_To.Cause_Del;
  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
