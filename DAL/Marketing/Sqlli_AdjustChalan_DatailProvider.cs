using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_AdjustChalan_DatailProvider:DataAccessObject
{
	public SqlLi_AdjustChalan_DatailProvider()
    {
    }


    public bool DeleteLi_AdjustChalan_Datail(int li_AdjustChalan_DatailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_AdjustChalan_Datail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_AdjustChalan_DatailID", SqlDbType.Int).Value = li_AdjustChalan_DatailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_AdjustChalan_Datail> GetAllLi_AdjustChalan_Datails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_AdjustChalan_Datails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_AdjustChalan_DatailsFromReader(reader);
        }
    }
    public List<Li_AdjustChalan_Datail> GetLi_AdjustChalan_DatailsFromReader(IDataReader reader)
    {
        List<Li_AdjustChalan_Datail> li_AdjustChalan_Datails = new List<Li_AdjustChalan_Datail>();

        while (reader.Read())
        {
            li_AdjustChalan_Datails.Add(GetLi_AdjustChalan_DatailFromReader(reader));
        }
        return li_AdjustChalan_Datails;
    }

    public Li_AdjustChalan_Datail GetLi_AdjustChalan_DatailFromReader(IDataReader reader)
    {
        try
        {
            Li_AdjustChalan_Datail li_AdjustChalan_Datail = new Li_AdjustChalan_Datail
                (
                    
                    (int)reader["SerialNo"],
                    reader["ID"].ToString(),
                    reader["BookCode"].ToString(),
                    (int)reader["SHQty"],
                    (int)reader["OvQty"],
                    (decimal)reader["SHDisAmount"],
                    (decimal)reader["OverDisAmount"],
                    (bool)reader["IsBoishki"],
                    (bool)reader["IsBoishaki_Bonus"],
                    (bool)reader["IsAlim"],
                    (bool)reader["IsAlim_Bonus"],
                    
                    (char)reader["Status_D"] 
                );
             return li_AdjustChalan_Datail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_AdjustChalan_Datail GetLi_AdjustChalan_DatailByID(int li_AdjustChalan_DatailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_AdjustChalan_DatailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_AdjustChalan_DatailID", SqlDbType.Int).Value = li_AdjustChalan_DatailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_AdjustChalan_DatailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_AdjustChalan_Datail(Li_AdjustChalan_Datail li_AdjustChalan_Datail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_AdjustChalan_Datail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
 
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_AdjustChalan_Datail.ID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_AdjustChalan_Datail.BookCode;
            cmd.Parameters.Add("@SHQty", SqlDbType.Int).Value = li_AdjustChalan_Datail.SHQty;
            cmd.Parameters.Add("@OvQty", SqlDbType.Int).Value = li_AdjustChalan_Datail.OvQty;
            cmd.Parameters.Add("@SHDisAmount", SqlDbType.Decimal).Value = li_AdjustChalan_Datail.SHDisAmount;
            cmd.Parameters.Add("@OverDisAmount", SqlDbType.Decimal).Value = li_AdjustChalan_Datail.OverDisAmount;
            cmd.Parameters.Add("@IsBoishki", SqlDbType.Bit).Value = li_AdjustChalan_Datail.IsBoishki;
            cmd.Parameters.Add("@IsBoishaki_Bonus", SqlDbType.Bit).Value = li_AdjustChalan_Datail.IsBoishaki_Bonus;
            cmd.Parameters.Add("@IsAlim", SqlDbType.Bit).Value = li_AdjustChalan_Datail.IsAlim;
            cmd.Parameters.Add("@IsAlim_Bonus", SqlDbType.Bit).Value = li_AdjustChalan_Datail.IsAlim_Bonus;
         
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_AdjustChalan_Datail.Status_D;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_AdjustChalan_Datail(Li_AdjustChalan_Datail li_AdjustChalan_Datail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_AdjustChalan_Datail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_AdjustChalan_Datail.SerialNo;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_AdjustChalan_Datail.ID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_AdjustChalan_Datail.BookCode;
            cmd.Parameters.Add("@SHQty", SqlDbType.Int).Value = li_AdjustChalan_Datail.SHQty;
            cmd.Parameters.Add("@OvQty", SqlDbType.Int).Value = li_AdjustChalan_Datail.OvQty;
            cmd.Parameters.Add("@SHDisAmount", SqlDbType.Decimal).Value = li_AdjustChalan_Datail.SHDisAmount;
            cmd.Parameters.Add("@OverDisAmount", SqlDbType.Decimal).Value = li_AdjustChalan_Datail.OverDisAmount;
            cmd.Parameters.Add("@IsBoishki", SqlDbType.Bit).Value = li_AdjustChalan_Datail.IsBoishki;
            cmd.Parameters.Add("@IsBoishaki_Bonus", SqlDbType.Bit).Value = li_AdjustChalan_Datail.IsBoishaki_Bonus;
            cmd.Parameters.Add("@IsAlim", SqlDbType.Bit).Value = li_AdjustChalan_Datail.IsAlim;
            cmd.Parameters.Add("@IsAlim_Bonus", SqlDbType.Bit).Value = li_AdjustChalan_Datail.IsAlim_Bonus;
 
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_AdjustChalan_Datail.Status_D;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
