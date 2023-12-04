using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using DAL;

public class SqlLi_LeminatioPartyInfoProvider:DataAccessObject
{
	public SqlLi_LeminatioPartyInfoProvider()
    {
    }


    public bool DeleteLi_LeminatioPartyInfo(int li_LeminatioPartyInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_LeminatioPartyInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_LeminatioPartyInfoID", SqlDbType.Int).Value = li_LeminatioPartyInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LeminatioPartyInfo> GetAllLi_LeminatioPartyInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_SMPM_GetAllLi_LeminatioPartyInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LeminatioPartyInfosFromReader(reader);
        }
    }
    public List<Li_LeminatioPartyInfo> GetLi_LeminatioPartyInfosFromReader(IDataReader reader)
    {
        List<Li_LeminatioPartyInfo> li_LeminatioPartyInfos = new List<Li_LeminatioPartyInfo>();

        while (reader.Read())
        {
            li_LeminatioPartyInfos.Add(GetLi_LeminatioPartyInfoFromReader(reader));
        }
        return li_LeminatioPartyInfos;
    }

    public Li_LeminatioPartyInfo GetLi_LeminatioPartyInfoFromReader(IDataReader reader)
    {
        try
        {
            Li_LeminatioPartyInfo li_LeminatioPartyInfo = new Li_LeminatioPartyInfo
                (
                   
                    reader["ID"].ToString(),
                    reader["Name"].ToString(),
                    reader["Address"].ToString(),
                    reader["Phone"].ToString(),
                    (decimal)reader["OpeningBalance"],
                    (DateTime)reader["CrteatedDate"],
                    (int)reader["CreatedBy"],
                    (int)reader["SerialNo"],
                    reader["Name_Bn"].ToString(),
                    reader["Add_Bn"].ToString()
                );
             return li_LeminatioPartyInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LeminatioPartyInfo GetLi_LeminatioPartyInfoByID(int li_LeminatioPartyInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_LeminatioPartyInfoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_LeminatioPartyInfoID", SqlDbType.Int).Value = li_LeminatioPartyInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LeminatioPartyInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_LeminatioPartyInfo(Li_LeminatioPartyInfo li_LeminatioPartyInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_LeminatioPartyInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_LeminatioPartyInfo.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_LeminatioPartyInfo.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_LeminatioPartyInfo.Phone;
            cmd.Parameters.Add("@OpeningBalance", SqlDbType.Decimal).Value = li_LeminatioPartyInfo.OpeningBalance;
            cmd.Parameters.Add("@CrteatedDate", SqlDbType.DateTime).Value = li_LeminatioPartyInfo.CrteatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeminatioPartyInfo.CreatedBy;
            //cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_LeminatioPartyInfo.SerialNo;
            cmd.Parameters.Add("@Name_Bn", SqlDbType.Text).Value = li_LeminatioPartyInfo.Name_Bn;
            cmd.Parameters.Add("@Add_Bn", SqlDbType.Text).Value = li_LeminatioPartyInfo.Add_Bn;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_LeminatioPartyInfo(Li_LeminatioPartyInfo li_LeminatioPartyInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_LeminatioPartyInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_LeminatioPartyInfo.ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_LeminatioPartyInfo.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_LeminatioPartyInfo.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_LeminatioPartyInfo.Phone;
            cmd.Parameters.Add("@OpeningBalance", SqlDbType.Decimal).Value = li_LeminatioPartyInfo.OpeningBalance;
            cmd.Parameters.Add("@CrteatedDate", SqlDbType.DateTime).Value = li_LeminatioPartyInfo.CrteatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeminatioPartyInfo.CreatedBy;
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_LeminatioPartyInfo.SerialNo;
            cmd.Parameters.Add("@Name_Bn", SqlDbType.Text).Value = li_LeminatioPartyInfo.Name_Bn;
            cmd.Parameters.Add("@Add_Bn", SqlDbType.Text).Value = li_LeminatioPartyInfo.Add_Bn;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAllLi_LeminatioPartyInfosByID(string BinderID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_LeminatioPartyInfosBy_Id", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = BinderID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
