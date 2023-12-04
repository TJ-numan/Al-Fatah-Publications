using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Int_FromProvider:DataAccessObject
{
	public SqlLi_Int_FromProvider()
    {
    }


    public bool DeleteLi_Int_From(int li_Int_FromID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Int_From", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Int_FromID", SqlDbType.Int).Value = li_Int_FromID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Int_From> GetAllLi_Int_Froms()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Int_Froms", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Int_FromsFromReader(reader);
        }
    }
    public List<Li_Int_From> GetLi_Int_FromsFromReader(IDataReader reader)
    {
        List<Li_Int_From> li_Int_Froms = new List<Li_Int_From>();

        while (reader.Read())
        {
            li_Int_Froms.Add(GetLi_Int_FromFromReader(reader));
        }
        return li_Int_Froms;
    }

    public Li_Int_From GetLi_Int_FromFromReader(IDataReader reader)
    {
        try
        {
            Li_Int_From li_Int_From = new Li_Int_From
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
                     (decimal)reader["BonusAmount"] 
                );
             return li_Int_From;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Int_From GetLi_Int_FromByID(int li_Int_FromID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Int_FromByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Int_FromID", SqlDbType.Int).Value = li_Int_FromID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Int_FromFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_Int_From(Li_Int_From li_Int_From,bool IsPartyChalan)
    {
        SqlCommand cmd;
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            if (IsPartyChalan == true)
            {
                  cmd = new SqlCommand("SMPM_InsertLi_Int_From", connection);
            }
            else
            {
                cmd = new SqlCommand("SMPM_InsertLi_Int_From_Specimen", connection);
            }
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50).Direction =  ParameterDirection . Output;
            cmd.Parameters.Add("@SlipNo", SqlDbType.VarChar).Value = li_Int_From.SlipNo;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Int_From.LibraryID;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_Int_From.TotalAmount;
            cmd.Parameters.Add("@PacQty", SqlDbType.Int).Value = li_Int_From.PacQty;
            cmd.Parameters.Add("@Per_Pac_Cost", SqlDbType.Decimal).Value = li_Int_From.Per_Pac_Cost;
            cmd.Parameters.Add("@AmoutReceivable", SqlDbType.Decimal).Value = li_Int_From.AmoutReceivable;
            cmd.Parameters.Add("@Trans_Date", SqlDbType.DateTime).Value = li_Int_From.Trans_Date;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Int_From.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Int_From.CreatedDate;
            cmd.Parameters.Add("@IsBoishki", SqlDbType.Bit).Value = li_Int_From.IsBoishki;
            cmd.Parameters.Add("@IsBoishki_Bonus", SqlDbType.Bit).Value = li_Int_From.IsBoishki_Bonus;
            cmd.Parameters.Add("@IsAlim", SqlDbType.Bit).Value = li_Int_From.IsAlim;
            cmd.Parameters.Add("@IsAlim_bonus", SqlDbType.Bit).Value = li_Int_From.IsAlim_bonus;
            cmd.Parameters.Add("@IsRegular", SqlDbType.Bit).Value = li_Int_From.IsRegular;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Int_From.Status_D;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = DBNull .Value ;
            cmd.Parameters.Add("@Dele_Date", SqlDbType.DateTime).Value = DBNull .Value ;
            cmd.Parameters.Add("@Cause_Del", SqlDbType.VarChar).Value =DBNull .Value  ;
            cmd.Parameters.Add("@BonusAmount", SqlDbType.Decimal ).Value = li_Int_From. BonusAmount;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_Int_From(Li_Int_From li_Int_From)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Int_From", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_Int_From.ID;
            cmd.Parameters.Add("@SlipNo", SqlDbType.VarChar).Value = li_Int_From.SlipNo;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Int_From.LibraryID;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_Int_From.TotalAmount;
            cmd.Parameters.Add("@PacQty", SqlDbType.Int).Value = li_Int_From.PacQty;
            cmd.Parameters.Add("@Per_Pac_Cost", SqlDbType.Decimal).Value = li_Int_From.Per_Pac_Cost;
            cmd.Parameters.Add("@AmoutReceivable", SqlDbType.Decimal).Value = li_Int_From.AmoutReceivable;
            cmd.Parameters.Add("@Trans_Date", SqlDbType.DateTime).Value = li_Int_From.Trans_Date;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Int_From.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Int_From.CreatedDate;
            cmd.Parameters.Add("@IsBoishki", SqlDbType.Bit).Value = li_Int_From.IsBoishki;
            cmd.Parameters.Add("@IsBoishki_Bonus", SqlDbType.Bit).Value = li_Int_From.IsBoishki_Bonus;
            cmd.Parameters.Add("@IsAlim", SqlDbType.Bit).Value = li_Int_From.IsAlim;
            cmd.Parameters.Add("@IsAlim_bonus", SqlDbType.Bit).Value = li_Int_From.IsAlim_bonus;
            cmd.Parameters.Add("@IsRegular", SqlDbType.Bit).Value = li_Int_From.IsRegular;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Int_From.Status_D;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = li_Int_From.DeleteBy;
            cmd.Parameters.Add("@Dele_Date", SqlDbType.DateTime).Value = li_Int_From.Dele_Date;
            cmd.Parameters.Add("@Cause_Del", SqlDbType.VarChar).Value = li_Int_From.Cause_Del;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
