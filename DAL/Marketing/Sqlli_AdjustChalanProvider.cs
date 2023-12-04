using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_AdjustChalanProvider:DataAccessObject
{
	public SqlLi_AdjustChalanProvider()
    {
    }


    public bool DeleteLi_AdjustChalan(int li_AdjustChalanID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_AdjustChalan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_AdjustChalanID", SqlDbType.Int).Value = li_AdjustChalanID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_AdjustChalan> GetAllLi_AdjustChalans()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_AdjustChalans", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_AdjustChalansFromReader(reader);
        }
    }
    public List<Li_AdjustChalan> GetLi_AdjustChalansFromReader(IDataReader reader)
    {
        List<Li_AdjustChalan> li_AdjustChalans = new List<Li_AdjustChalan>();

        while (reader.Read())
        {
            li_AdjustChalans.Add(GetLi_AdjustChalanFromReader(reader));
        }
        return li_AdjustChalans;
    }

    public Li_AdjustChalan GetLi_AdjustChalanFromReader(IDataReader reader)
    {
        try
        {
            Li_AdjustChalan li_AdjustChalan = new Li_AdjustChalan
                (
                   
                    reader["ID"].ToString(),
                    reader["RefNo"].ToString(),
                    (int)reader["MemoNo"],
                    reader["LibraryID"].ToString(),
                    (decimal)reader["SHAmount"],
                    (decimal)reader["OVAmount"],
                    (decimal)reader["BonusAmount"],
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
                    (char)reader["Status_D"],
                    (int)reader["DeleteBy"],
                    (DateTime)reader["Dele_Date"],
                    reader["Cause_Del"].ToString(),
                    (bool)reader["ForReturn"]
                );
             return li_AdjustChalan;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_AdjustChalan GetLi_AdjustChalanByID(int li_AdjustChalanID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_AdjustChalanByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_AdjustChalanID", SqlDbType.Int).Value = li_AdjustChalanID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_AdjustChalanFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_AdjustChalan(Li_AdjustChalan li_AdjustChalan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_AdjustChalan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_AdjustChalan.RefNo;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_AdjustChalan.MemoNo;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_AdjustChalan.LibraryID;
            cmd.Parameters.Add("@SHAmount", SqlDbType.Decimal).Value = li_AdjustChalan.SHAmount;
            cmd.Parameters.Add("@OVAmount", SqlDbType.Decimal).Value = li_AdjustChalan.OVAmount;
            cmd.Parameters.Add("@BonusAmount", SqlDbType.Decimal).Value = li_AdjustChalan.BonusAmount;
            cmd.Parameters.Add("@PacQty", SqlDbType.Int).Value = li_AdjustChalan.PacQty;
            cmd.Parameters.Add("@Per_Pac_Cost", SqlDbType.Decimal).Value = li_AdjustChalan.Per_Pac_Cost;
            cmd.Parameters.Add("@AmoutReceivable", SqlDbType.Decimal).Value = li_AdjustChalan.AmoutReceivable;
            cmd.Parameters.Add("@Trans_Date", SqlDbType.DateTime).Value = li_AdjustChalan.Trans_Date;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AdjustChalan.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AdjustChalan.CreatedDate;
            cmd.Parameters.Add("@IsBoishki", SqlDbType.Bit).Value = li_AdjustChalan.IsBoishki;
            cmd.Parameters.Add("@IsBoishki_Bonus", SqlDbType.Bit).Value = li_AdjustChalan.IsBoishki_Bonus;
            cmd.Parameters.Add("@IsAlim", SqlDbType.Bit).Value = li_AdjustChalan.IsAlim;
            cmd.Parameters.Add("@IsAlim_bonus", SqlDbType.Bit).Value = li_AdjustChalan.IsAlim_bonus;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_AdjustChalan.Status_D;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = li_AdjustChalan.DeleteBy;
            cmd.Parameters.Add("@Dele_Date", SqlDbType.DateTime).Value = li_AdjustChalan.Dele_Date;
            cmd.Parameters.Add("@Cause_Del", SqlDbType.VarChar).Value = li_AdjustChalan.Cause_Del;
            cmd.Parameters.Add("@ForReturn", SqlDbType.Bit).Value = li_AdjustChalan.ForReturn;        
            connection.Open();

            cmd.ExecuteNonQuery();
            return   cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_AdjustChalan(Li_AdjustChalan li_AdjustChalan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_AdjustChalan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_AdjustChalan.ID;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_AdjustChalan.RefNo;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_AdjustChalan.MemoNo;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_AdjustChalan.LibraryID;
            cmd.Parameters.Add("@SHAmount", SqlDbType.Decimal).Value = li_AdjustChalan.SHAmount;
            cmd.Parameters.Add("@OVAmount", SqlDbType.Decimal).Value = li_AdjustChalan.OVAmount;
            cmd.Parameters.Add("@BonusAmount", SqlDbType.Decimal).Value = li_AdjustChalan.BonusAmount;
            cmd.Parameters.Add("@PacQty", SqlDbType.Int).Value = li_AdjustChalan.PacQty;
            cmd.Parameters.Add("@Per_Pac_Cost", SqlDbType.Decimal).Value = li_AdjustChalan.Per_Pac_Cost;
            cmd.Parameters.Add("@AmoutReceivable", SqlDbType.Decimal).Value = li_AdjustChalan.AmoutReceivable;
            cmd.Parameters.Add("@Trans_Date", SqlDbType.DateTime).Value = li_AdjustChalan.Trans_Date;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AdjustChalan.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AdjustChalan.CreatedDate;
            cmd.Parameters.Add("@IsBoishki", SqlDbType.Bit).Value = li_AdjustChalan.IsBoishki;
            cmd.Parameters.Add("@IsBoishki_Bonus", SqlDbType.Bit).Value = li_AdjustChalan.IsBoishki_Bonus;
            cmd.Parameters.Add("@IsAlim", SqlDbType.Bit).Value = li_AdjustChalan.IsAlim;
            cmd.Parameters.Add("@IsAlim_bonus", SqlDbType.Bit).Value = li_AdjustChalan.IsAlim_bonus;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_AdjustChalan.Status_D;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = li_AdjustChalan.DeleteBy;
            cmd.Parameters.Add("@Dele_Date", SqlDbType.DateTime).Value = li_AdjustChalan.Dele_Date;
            cmd.Parameters.Add("@Cause_Del", SqlDbType.VarChar).Value = li_AdjustChalan.Cause_Del;
       
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
