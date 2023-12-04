using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookCoverSupInfoProvider:DataAccessObject
{
	public SqlLi_BookCoverSupInfoProvider()
    {
    }


    public bool DeleteLi_BookCoverSupInfo(int li_BookCoverSupInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookCoverSupInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookCoverSupInfoID", SqlDbType.Int).Value = li_BookCoverSupInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookCoverSupInfo> GetAllLi_BookCoverSupInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookCoverSupInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookCoverSupInfosFromReader(reader);
        }
    }
    public List<Li_BookCoverSupInfo> GetLi_BookCoverSupInfosFromReader(IDataReader reader)
    {
        List<Li_BookCoverSupInfo> li_BookCoverSupInfos = new List<Li_BookCoverSupInfo>();

        while (reader.Read())
        {
            li_BookCoverSupInfos.Add(GetLi_BookCoverSupInfoFromReader(reader));
        }
        return li_BookCoverSupInfos;
    }

    public Li_BookCoverSupInfo GetLi_BookCoverSupInfoFromReader(IDataReader reader)
    {
        try
        {
            Li_BookCoverSupInfo li_BookCoverSupInfo = new Li_BookCoverSupInfo
                (
                   
                    reader["COSCode"].ToString(),
                    reader["SupName"].ToString(),
                    reader["Address"].ToString(),
                    reader["Phone"].ToString(),
                    (decimal)reader["OpennigBalance"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    reader["B_Name"].ToString(),
                    reader["B_Add"].ToString() 
                );
             return li_BookCoverSupInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookCoverSupInfo GetLi_BookCoverSupInfoByID(int li_BookCoverSupInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookCoverSupInfoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookCoverSupInfoID", SqlDbType.Int).Value = li_BookCoverSupInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookCoverSupInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_BookCoverSupInfo(Li_BookCoverSupInfo li_BookCoverSupInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookCoverSupInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@COSCode", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SupName", SqlDbType.VarChar).Value = li_BookCoverSupInfo.SupName;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_BookCoverSupInfo.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_BookCoverSupInfo.Phone;
            cmd.Parameters.Add("@OpennigBalance", SqlDbType.Decimal).Value = li_BookCoverSupInfo.OpennigBalance;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookCoverSupInfo.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookCoverSupInfo.CreatedBy;
            cmd.Parameters.Add("@B_Name", SqlDbType.Text).Value = li_BookCoverSupInfo.B_Name;
            cmd.Parameters.Add("@B_Add", SqlDbType.Text).Value = li_BookCoverSupInfo.B_Add;
     
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@COSCode"].Value.ToString ();
        }
    }

    public bool UpdateLi_BookCoverSupInfo(Li_BookCoverSupInfo li_BookCoverSupInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookCoverSupInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@COSCode", SqlDbType.VarChar).Value = li_BookCoverSupInfo.COSCode;
            cmd.Parameters.Add("@SupName", SqlDbType.VarChar).Value = li_BookCoverSupInfo.SupName;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_BookCoverSupInfo.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_BookCoverSupInfo.Phone;
            cmd.Parameters.Add("@OpennigBalance", SqlDbType.Decimal).Value = li_BookCoverSupInfo.OpennigBalance;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookCoverSupInfo.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookCoverSupInfo.CreatedBy;
            cmd.Parameters.Add("@B_Name", SqlDbType.Text).Value = li_BookCoverSupInfo.B_Name;
            cmd.Parameters.Add("@B_Add", SqlDbType.Text).Value = li_BookCoverSupInfo.B_Add;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAllLi_BookCoverSupInfosByID(string BinderID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookCoverSupInfosByID", connection);
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
