using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlateBuyerInfoProvider:DataAccessObject
{
	public SqlLi_PlateBuyerInfoProvider()
    {
    }


    public bool DeleteLi_PlateBuyerInfo(int li_PlateBuyerInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateBuyerInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateBuyerInfoID", SqlDbType.Int).Value = li_PlateBuyerInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateBuyerInfo> GetAllLi_PlateBuyerInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateBuyerInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateBuyerInfosFromReader(reader);
        }
    }
    public List<Li_PlateBuyerInfo> GetLi_PlateBuyerInfosFromReader(IDataReader reader)
    {
        List<Li_PlateBuyerInfo> li_PlateBuyerInfos = new List<Li_PlateBuyerInfo>();

        while (reader.Read())
        {
            li_PlateBuyerInfos.Add(GetLi_PlateBuyerInfoFromReader(reader));
        }
        return li_PlateBuyerInfos;
    }

    public Li_PlateBuyerInfo GetLi_PlateBuyerInfoFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateBuyerInfo li_PlateBuyerInfo = new Li_PlateBuyerInfo
                (
                     
                    reader["ID"].ToString(),
                    reader["Name"].ToString(),
                    reader["Address"].ToString(),
                    reader["Phone"].ToString(),
                    (decimal)reader["O_Balance"],
                     
                    (int)reader["CreatedBy"],
                    (DateTime )reader["CreatedDate"],
                    reader["B_Name"].ToString(),
                    reader["B_Add"].ToString()
                     
                );
             return li_PlateBuyerInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateBuyerInfo GetLi_PlateBuyerInfoByID(int li_PlateBuyerInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateBuyerInfoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateBuyerInfoID", SqlDbType.Int).Value = li_PlateBuyerInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateBuyerInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PlateBuyerInfo(Li_PlateBuyerInfo li_PlateBuyerInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_PlateBuyerInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_PlateBuyerInfo.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_PlateBuyerInfo.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_PlateBuyerInfo.Phone;
            cmd.Parameters.Add("@O_Balance", SqlDbType.Decimal).Value = li_PlateBuyerInfo.O_Balance;
            
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateBuyerInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateBuyerInfo.CreatedDate;
            cmd.Parameters.Add("@B_Name", SqlDbType.VarChar).Value = li_PlateBuyerInfo.B_Name;
            cmd.Parameters.Add("@B_Add", SqlDbType.VarChar).Value = li_PlateBuyerInfo.B_Add;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return   cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PlateBuyerInfo(Li_PlateBuyerInfo li_PlateBuyerInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_UpdateLi_PlateBuyerInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PlateBuyerInfo.ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_PlateBuyerInfo.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_PlateBuyerInfo.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_PlateBuyerInfo.Phone;
            cmd.Parameters.Add("@O_Balance", SqlDbType.Decimal).Value = li_PlateBuyerInfo.O_Balance;
             cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateBuyerInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateBuyerInfo.CreatedDate;
            cmd.Parameters.Add("@B_Name", SqlDbType.VarChar).Value = li_PlateBuyerInfo.B_Name;
            cmd.Parameters.Add("@B_Add", SqlDbType.VarChar).Value = li_PlateBuyerInfo.B_Add;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
