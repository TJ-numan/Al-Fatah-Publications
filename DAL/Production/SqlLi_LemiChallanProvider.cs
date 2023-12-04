using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_LemiChallanProvider:DataAccessObject
{
	public SqlLi_LemiChallanProvider()
    {
    }


    public bool DeleteLi_LemiChallan(int li_LemiChallanID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_LemiChallan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_LemiChallanID", SqlDbType.Int).Value = li_LemiChallanID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LemiChallan> GetAllLi_LemiChallans()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_LemiChallans", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LemiChallansFromReader(reader);
        }
    }
    public List<Li_LemiChallan> GetLi_LemiChallansFromReader(IDataReader reader)
    {
        List<Li_LemiChallan> li_LemiChallans = new List<Li_LemiChallan>();

        while (reader.Read())
        {
            li_LemiChallans.Add(GetLi_LemiChallanFromReader(reader));
        }
        return li_LemiChallans;
    }

    public Li_LemiChallan GetLi_LemiChallanFromReader(IDataReader reader)
    {
        try
        {
            Li_LemiChallan li_LemiChallan = new Li_LemiChallan
                (
                    
                    reader["ChallanID"].ToString(),
                    (int)reader["MemoNo"],
                    (string )reader["AgentID"],
                    (DateTime)reader["ChallanDate"],
                    (decimal)reader["TotalAmount"],
                    (decimal)reader["TotalDiscount"],
                    (int)reader["PacketNo"],
                    (decimal)reader["PerPacketCost"],
                    (decimal)reader["AmountReceivable"],
                    (bool)reader["IsDelivered"],
                    (bool)reader["IsPrinted"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    reader["Status_D"].ToString(),
                    (int)reader["CanceledBy"],
                    reader["CauseOfCanel"].ToString()
                );
             return li_LemiChallan;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LemiChallan GetLi_LemiChallanByID(int li_LemiChallanID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_LemiChallanByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_LemiChallanID", SqlDbType.Int).Value = li_LemiChallanID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LemiChallanFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_LemiChallan(Li_LemiChallan li_LemiChallan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_LemiChallan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AgentID", SqlDbType.VarChar).Value = li_LemiChallan.AgentID;
            cmd.Parameters.Add("@ChallanDate", SqlDbType.DateTime).Value = li_LemiChallan.ChallanDate;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_LemiChallan.TotalAmount;
            cmd.Parameters.Add("@TotalDiscount", SqlDbType.Decimal).Value = li_LemiChallan.TotalDiscount;
            cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_LemiChallan.PacketNo;
            cmd.Parameters.Add("@PerPacketCost", SqlDbType.Decimal).Value = li_LemiChallan.PerPacketCost;
            cmd.Parameters.Add("@AmountReceivable", SqlDbType.Decimal).Value = li_LemiChallan.AmountReceivable;
            cmd.Parameters.Add("@IsDelivered", SqlDbType.Bit).Value = li_LemiChallan.IsDelivered;
            cmd.Parameters.Add("@IsPrinted", SqlDbType.Bit).Value = li_LemiChallan.IsPrinted;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LemiChallan.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LemiChallan.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.VarChar).Value = li_LemiChallan.Status_D;
            cmd.Parameters.Add("@CanceledBy", SqlDbType.Int).Value = li_LemiChallan.CanceledBy;
            cmd.Parameters.Add("@CauseOfCanel", SqlDbType.VarChar).Value = li_LemiChallan.CauseOfCanel;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@MemoNo"].Value.ToString ();
        }
    }

    public bool UpdateLi_LemiChallan(Li_LemiChallan li_LemiChallan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_LemiChallan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = li_LemiChallan.ChallanID;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_LemiChallan.MemoNo;
            cmd.Parameters.Add("@AgentID", SqlDbType.Int).Value = li_LemiChallan.AgentID;
            cmd.Parameters.Add("@ChallanDate", SqlDbType.DateTime).Value = li_LemiChallan.ChallanDate;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_LemiChallan.TotalAmount;
            cmd.Parameters.Add("@TotalDiscount", SqlDbType.Decimal).Value = li_LemiChallan.TotalDiscount;
            cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_LemiChallan.PacketNo;
            cmd.Parameters.Add("@PerPacketCost", SqlDbType.Decimal).Value = li_LemiChallan.PerPacketCost;
            cmd.Parameters.Add("@AmountReceivable", SqlDbType.Decimal).Value = li_LemiChallan.AmountReceivable;
            cmd.Parameters.Add("@IsDelivered", SqlDbType.Bit).Value = li_LemiChallan.IsDelivered;
            cmd.Parameters.Add("@IsPrinted", SqlDbType.Bit).Value = li_LemiChallan.IsPrinted;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LemiChallan.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LemiChallan.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.VarChar).Value = li_LemiChallan.Status_D;
            cmd.Parameters.Add("@CanceledBy", SqlDbType.Int).Value = li_LemiChallan.CanceledBy;
            cmd.Parameters.Add("@CauseOfCanel", SqlDbType.VarChar).Value = li_LemiChallan.CauseOfCanel;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
