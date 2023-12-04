using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_MadrasahQawmiProvider:DataAccessObject
{
	public SqlLi_MadrasahQawmiProvider()
    {
    }


    public bool DeleteLi_MadrasahQawmi(int li_MadrasahQawmiID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_MadrasahQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_MadrasahQawmiID", SqlDbType.Int).Value = li_MadrasahQawmiID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_MadrasahQawmi> GetAllLi_MadrasahQawmis()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_MadrasahQawmis", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_MadrasahQawmisFromReader(reader);
        }
    }
    public List<Li_MadrasahQawmi> GetLi_MadrasahQawmisFromReader(IDataReader reader)
    {
        List<Li_MadrasahQawmi> li_MadrasahQawmis = new List<Li_MadrasahQawmi>();

        while (reader.Read())
        {
            li_MadrasahQawmis.Add(GetLi_MadrasahQawmiFromReader(reader));
        }
        return li_MadrasahQawmis;
    }

    public Li_MadrasahQawmi GetLi_MadrasahQawmiFromReader(IDataReader reader)
    {
        try
        {
            Li_MadrasahQawmi li_MadrasahQawmi = new Li_MadrasahQawmi
                (
 
                    (int)reader["MadrashId"],
                    reader["MadName"].ToString(),
                    (int)reader["MadType"],
                    reader["Ested"].ToString(),
                    reader["MadAddress"].ToString(),
                    reader ["MadrasahPhone"].ToString (),
                    reader["TerritoryID"].ToString(),
                    (int)reader["DistrictID"],
                    (int)reader["ThanaID"],
                    (int)reader["MadrasahPosition"],
                    reader["MaximumClass"].ToString(),
                    (int)reader["TotalStudent"],
                    reader["Board"].ToString(),
                    reader["PrincipalName"].ToString(),
                    reader["PrincipalPhone"].ToString(),
                    reader["ContactPublishers"].ToString(),
                    reader["MadrasahRelatedLibrary"].ToString(),
                    reader["OwnerName"].ToString(),
                    reader["OwnerPhone"].ToString(),
                    (decimal)reader["YearlySale"],
                    reader["AgentOf"].ToString() 
                );
             return li_MadrasahQawmi;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_MadrasahQawmi GetLi_MadrasahQawmiByID(int li_MadrasahQawmiID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_MadrasahQawmiByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_MadrasahQawmiID", SqlDbType.Int).Value = li_MadrasahQawmiID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_MadrasahQawmiFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_MadrasahQawmi(Li_MadrasahQawmi li_MadrasahQawmi)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_MadrasahQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@MadrashId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MadName", SqlDbType.VarChar).Value = li_MadrasahQawmi.MadName;
            cmd.Parameters.Add("@MadType", SqlDbType.Int).Value = li_MadrasahQawmi.MadType;
            cmd.Parameters.Add("@Ested", SqlDbType.VarChar).Value = li_MadrasahQawmi.Ested;
            cmd.Parameters.Add("@MadAddress", SqlDbType.VarChar).Value = li_MadrasahQawmi.MadAddress;
            cmd.Parameters.Add("@MadrasahPhone", SqlDbType.VarChar).Value = li_MadrasahQawmi. MadrasahPhone;
            cmd.Parameters.Add("@TerritoryID", SqlDbType.VarChar).Value = li_MadrasahQawmi.TerritoryID;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = li_MadrasahQawmi.DistrictID;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = li_MadrasahQawmi.ThanaID;
            cmd.Parameters.Add("@MadrasahPosition", SqlDbType.Int).Value = li_MadrasahQawmi.MadrasahPosition;
            cmd.Parameters.Add("@MaximumClass", SqlDbType.VarChar).Value = li_MadrasahQawmi.MaximumClass;
            cmd.Parameters.Add("@TotalStudent", SqlDbType.Int).Value = li_MadrasahQawmi.TotalStudent;
            cmd.Parameters.Add("@Board", SqlDbType.VarChar).Value = li_MadrasahQawmi.Board;
            cmd.Parameters.Add("@PrincipalName", SqlDbType.VarChar).Value = li_MadrasahQawmi.PrincipalName;
            cmd.Parameters.Add("@PrincipalPhone", SqlDbType.VarChar).Value = li_MadrasahQawmi.PrincipalPhone;
            cmd.Parameters.Add("@ContactPublishers", SqlDbType.VarChar).Value = li_MadrasahQawmi.ContactPublishers;
            cmd.Parameters.Add("@MadrasahRelatedLibrary", SqlDbType.VarChar).Value = li_MadrasahQawmi.MadrasahRelatedLibrary;
            cmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = li_MadrasahQawmi.OwnerName;
            cmd.Parameters.Add("@OwnerPhone", SqlDbType.VarChar).Value = li_MadrasahQawmi.OwnerPhone;
            cmd.Parameters.Add("@YearlySale", SqlDbType.Decimal).Value = li_MadrasahQawmi.YearlySale;
            cmd.Parameters.Add("@AgentOf", SqlDbType.VarChar).Value = li_MadrasahQawmi.AgentOf;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MadrashId"].Value;
        }
    }

    public bool UpdateLi_MadrasahQawmi(Li_MadrasahQawmi li_MadrasahQawmi)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_MadrasahQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@MadrashId", SqlDbType.Int).Value = li_MadrasahQawmi.MadrashId;
            cmd.Parameters.Add("@MadName", SqlDbType.VarChar).Value = li_MadrasahQawmi.MadName;
            cmd.Parameters.Add("@MadType", SqlDbType.Int).Value = li_MadrasahQawmi.MadType;
            cmd.Parameters.Add("@Ested", SqlDbType.VarChar).Value = li_MadrasahQawmi.Ested;
            cmd.Parameters.Add("@MadAddress", SqlDbType.VarChar).Value = li_MadrasahQawmi.MadAddress;
            cmd.Parameters.Add("@MadrasahPhone", SqlDbType.VarChar).Value = li_MadrasahQawmi.MadrasahPhone;
            cmd.Parameters.Add("@TerritoryID", SqlDbType.VarChar).Value = li_MadrasahQawmi.TerritoryID;
            cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = li_MadrasahQawmi.DistrictID;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = li_MadrasahQawmi.ThanaID;
            cmd.Parameters.Add("@MadrasahPosition", SqlDbType.Int).Value = li_MadrasahQawmi.MadrasahPosition;
            cmd.Parameters.Add("@MaximumClass", SqlDbType.VarChar).Value = li_MadrasahQawmi.MaximumClass;
            cmd.Parameters.Add("@TotalStudent", SqlDbType.Int).Value = li_MadrasahQawmi.TotalStudent;
            cmd.Parameters.Add("@Board", SqlDbType.VarChar).Value = li_MadrasahQawmi.Board;
            cmd.Parameters.Add("@PrincipalName", SqlDbType.VarChar).Value = li_MadrasahQawmi.PrincipalName;
            cmd.Parameters.Add("@PrincipalPhone", SqlDbType.VarChar).Value = li_MadrasahQawmi.PrincipalPhone;
            cmd.Parameters.Add("@ContactPublishers", SqlDbType.VarChar).Value = li_MadrasahQawmi.ContactPublishers;
            cmd.Parameters.Add("@MadrasahRelatedLibrary", SqlDbType.VarChar).Value = li_MadrasahQawmi.MadrasahRelatedLibrary;
            cmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = li_MadrasahQawmi.OwnerName;
            cmd.Parameters.Add("@OwnerPhone", SqlDbType.VarChar).Value = li_MadrasahQawmi.OwnerPhone;
            cmd.Parameters.Add("@YearlySale", SqlDbType.Decimal).Value = li_MadrasahQawmi.YearlySale;
            cmd.Parameters.Add("@AgentOf", SqlDbType.VarChar).Value = li_MadrasahQawmi.AgentOf;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
