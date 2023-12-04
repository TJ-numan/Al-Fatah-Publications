using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using DAL;


public class SqlLi_PlateDamageProvider : DataAccessObject
{
    public SqlLi_PlateDamageProvider()
    {
    }
    public bool DeleteLi_PlateDamage(int li_PlateDamageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateDamage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@li_PlateDamageID", SqlDbType.Int).Value = li_PlateDamageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateDamage> GetAllLi_PlateDamage()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateDamage", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateDamagesFromReader(reader);
        }
    }
    public List<Li_PlateDamage> GetLi_PlateDamagesFromReader(IDataReader reader)
    {
        List<Li_PlateDamage> li_PlateDamage = new List<Li_PlateDamage>();

        while (reader.Read())
        {
            li_PlateDamage.Add(GetLi_PlateDamageFromReader(reader));
        }
        return li_PlateDamage;
    }

    public Li_PlateDamage GetLi_PlateDamageFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateDamage li_PlateDamage = new Li_PlateDamage
                (
                    
                    reader["PDM_ID"].ToString(),
                    (DateTime)reader["ChallanDate"],
                    reader["PressID"].ToString(),
                    reader["Dam_PurID"].ToString(),
                    (int)reader["TotalPlateQty"],
                    (decimal)reader["TotalBill"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                );
            return li_PlateDamage;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateDamage GetLi_PlateDamageByID(int li_PlateDamageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateDamageByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateDamageID", SqlDbType.Int).Value = li_PlateDamageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateDamageFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string InsertLi_PlateDamage(Li_PlateDamage li_PlateDamage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateDamage", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PDM_ID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ChallanDate", SqlDbType.DateTime).Value = li_PlateDamage.ChallanDate;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PlateDamage.PressID;
            cmd.Parameters.Add("@Dam_PurID", SqlDbType.VarChar).Value = li_PlateDamage.Dam_PurID;
            cmd.Parameters.Add("@TotalPlateQty", SqlDbType.Int).Value = li_PlateDamage.TotalPlateQty;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PlateDamage.TotalBill;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateDamage.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateDamage.CreatedDate;
   
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@PDM_ID"].Value.ToString();
        }
    }

    public bool UpdateLi_PlateDamage(Li_PlateDamage li_PlateDamage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateDamage", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PDM_ID", SqlDbType.VarChar).Value = li_PlateDamage.PDM_ID;
            cmd.Parameters.Add("@ChallanDate", SqlDbType.DateTime).Value = li_PlateDamage.ChallanDate;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PlateDamage.PressID;
            cmd.Parameters.Add("@Dam_PurID", SqlDbType.VarChar).Value = li_PlateDamage.Dam_PurID;
            cmd.Parameters.Add("@TotalPlateQty", SqlDbType.Int).Value = li_PlateDamage.TotalPlateQty;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PlateDamage.TotalBill;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateDamage.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateDamage.CreatedDate;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public string InsertLi_PlateDamageStock(Li_PlateDamage li_PlateDamage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateDamageStock", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PDS_ID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DamageDate", SqlDbType.DateTime).Value = li_PlateDamage.ChallanDate;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PlateDamage.PressID;
            cmd.Parameters.Add("@TotalPlateQty", SqlDbType.Int).Value = li_PlateDamage.TotalPlateQty;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateDamage.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateDamage.CreatedDate;
            cmd.Parameters.Add("@SlipNo", SqlDbType.VarChar).Value = li_PlateDamage.Dam_PurID;


            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@PDS_ID"].Value.ToString();
        }
    }
}


