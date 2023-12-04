using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PestingPartyInfoProvider:DataAccessObject
{
	public SqlLi_PestingPartyInfoProvider()
    {
    }


    public bool DeleteLi_PestingPartyInfo(int li_PestingPartyInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PestingPartyInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PestingPartyInfoID", SqlDbType.Int).Value = li_PestingPartyInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PestingPartyInfo> GetAllLi_PestingPartyInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PestingPartyInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PestingPartyInfosFromReader(reader);
        }
    }
    public List<Li_PestingPartyInfo> GetLi_PestingPartyInfosFromReader(IDataReader reader)
    {
        List<Li_PestingPartyInfo> li_PestingPartyInfos = new List<Li_PestingPartyInfo>();

        while (reader.Read())
        {
            li_PestingPartyInfos.Add(GetLi_PestingPartyInfoFromReader(reader));
        }
        return li_PestingPartyInfos;
    }

    public Li_PestingPartyInfo GetLi_PestingPartyInfoFromReader(IDataReader reader)
    {
        try
        {
            Li_PestingPartyInfo li_PestingPartyInfo = new Li_PestingPartyInfo
                (
                    
                    reader["ID"].ToString(),
                    reader["Name"].ToString(),
                    reader["Name_Bn"].ToString(),
                    reader["Address"].ToString(),
                    reader["Address_Bn"].ToString(),
                    reader["Phone"].ToString(),
                    (decimal)reader["O_Balance"],
                    (int)reader["SerialNo"],
                    (int)reader["CreatedBy"],
                    (DateTime )reader["CreatedDate"] 
                );
             return li_PestingPartyInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public DataSet GetLi_PestingPartyInfoByID(string PartyID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PestingPartyInfoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = PartyID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public string  InsertLi_PestingPartyInfo(Li_PestingPartyInfo li_PestingPartyInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PestingPartyInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_PestingPartyInfo.Name;
            cmd.Parameters.Add("@Name_Bn", SqlDbType.VarChar).Value = li_PestingPartyInfo.Name_Bn;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_PestingPartyInfo.Address;
            cmd.Parameters.Add("@Address_Bn", SqlDbType.VarChar).Value = li_PestingPartyInfo.Address_Bn;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_PestingPartyInfo.Phone;
            cmd.Parameters.Add("@O_Balance", SqlDbType.Decimal).Value = li_PestingPartyInfo.O_Balance;
             cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PestingPartyInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PestingPartyInfo.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PestingPartyInfo(Li_PestingPartyInfo li_PestingPartyInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PestingPartyInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PestingPartyInfo.ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_PestingPartyInfo.Name;
            cmd.Parameters.Add("@Name_Bn", SqlDbType.VarChar).Value = li_PestingPartyInfo.Name_Bn;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_PestingPartyInfo.Address;
            cmd.Parameters.Add("@Address_Bn", SqlDbType.VarChar).Value = li_PestingPartyInfo.Address_Bn;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_PestingPartyInfo.Phone;
            cmd.Parameters.Add("@O_Balance", SqlDbType.Decimal).Value = li_PestingPartyInfo.O_Balance;
             cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PestingPartyInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PestingPartyInfo.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
