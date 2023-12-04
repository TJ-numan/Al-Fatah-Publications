using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperAcUsedProvider:DataAccessObject
{
	public SqlLi_PaperAcUsedProvider()
    {
    }


    public bool DeleteLi_PaperAcUsed(int li_PaperAcUsedID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperAcUsed", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperAcUsedID", SqlDbType.Int).Value = li_PaperAcUsedID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperAcUsed> GetAllLi_PaperAcUseds()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperAcUseds", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperAcUsedsFromReader(reader);
        }
    }
    public List<Li_PaperAcUsed> GetLi_PaperAcUsedsFromReader(IDataReader reader)
    {
        List<Li_PaperAcUsed> li_PaperAcUseds = new List<Li_PaperAcUsed>();

        while (reader.Read())
        {
            li_PaperAcUseds.Add(GetLi_PaperAcUsedFromReader(reader));
        }
        return li_PaperAcUseds;
    }

    public Li_PaperAcUsed GetLi_PaperAcUsedFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperAcUsed li_PaperAcUsed = new Li_PaperAcUsed
                (
                    reader ["PressID"].ToString (),
                    (int)reader["PrOrderSl"],
                    reader["Print_OrderNo"].ToString() ,                     
                    (DateTime)reader["PrintDate"],
                    (int)reader["PrintQty"],
                    (decimal)reader["PaperUsed"],
                    (int)reader["PlateUsed"],
                    (decimal)reader["RollQty"],
                    reader["Remark"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (char)reader["Status_D"],
                    reader["CauseOFDel"].ToString(),
                    (int)reader["DelBy"] 
                );
             return li_PaperAcUsed;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PaperAcUsed GetLi_PaperAcUsedByID(int li_PaperAcUsedID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperAcUsedByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PaperAcUsedID", SqlDbType.Int).Value = li_PaperAcUsedID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PaperAcUsedFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PaperAcUsed(Li_PaperAcUsed li_PaperAcUsed)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperAcUsed", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@PrOrderSl", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Print_OrderNo", SqlDbType.VarChar).Value = li_PaperAcUsed.Print_OrderNo;

            cmd.Parameters.Add("@PressID", SqlDbType. VarChar).Value = li_PaperAcUsed.PressID;

            cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime).Value = li_PaperAcUsed.PrintDate;
            cmd.Parameters.Add("@PrintQty", SqlDbType.Int).Value = li_PaperAcUsed.PrintQty;
            cmd.Parameters.Add("@PaperUsed", SqlDbType.Decimal).Value = li_PaperAcUsed.PaperUsed;
            cmd.Parameters.Add("@PlateUsed", SqlDbType.Int).Value = li_PaperAcUsed.PlateUsed;
            cmd.Parameters.Add("@RollQty", SqlDbType.Decimal).Value = li_PaperAcUsed.RollQty;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PaperAcUsed.Remark;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperAcUsed.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperAcUsed.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PaperAcUsed.Status_D;
            cmd.Parameters.Add("@CauseOFDel", SqlDbType.VarChar).Value = li_PaperAcUsed.CauseOFDel;
            cmd.Parameters.Add("@DelBy", SqlDbType.Int).Value = li_PaperAcUsed.DelBy;
       
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PrOrderSl"].Value;
        }
    }

    public bool UpdateLi_PaperAcUsed(Li_PaperAcUsed li_PaperAcUsed)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperAcUsed", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@PrOrderSl", SqlDbType.Int).Value = li_PaperAcUsed.PrOrderSl;
            cmd.Parameters.Add("@Print_OrderNo", SqlDbType.VarChar).Value = li_PaperAcUsed.Print_OrderNo;
            cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime).Value = li_PaperAcUsed.PrintDate;
            cmd.Parameters.Add("@PrintQty", SqlDbType.Int).Value = li_PaperAcUsed.PrintQty;
            cmd.Parameters.Add("@PaperUsed", SqlDbType.Decimal).Value = li_PaperAcUsed.PaperUsed;
            cmd.Parameters.Add("@PlateUsed", SqlDbType.Int).Value = li_PaperAcUsed.PlateUsed;
            cmd.Parameters.Add("@RollQty", SqlDbType.Decimal).Value = li_PaperAcUsed.RollQty;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PaperAcUsed.Remark;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperAcUsed.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperAcUsed.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PaperAcUsed.Status_D;
            cmd.Parameters.Add("@CauseOFDel", SqlDbType.VarChar).Value = li_PaperAcUsed.CauseOFDel;
            cmd.Parameters.Add("@DelBy", SqlDbType.Int).Value = li_PaperAcUsed.DelBy;
    
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
