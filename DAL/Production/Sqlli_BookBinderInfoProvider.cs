using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookBinderInfoProvider:DataAccessObject
{
	public SqlLi_BookBinderInfoProvider()
    {
    }


    public bool DeleteLi_BookBinderInfo(int li_BookBinderInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookBinderInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookBinderInfoID", SqlDbType.Int).Value = li_BookBinderInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookBinderInfo> GetAllLi_BookBinderInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookBinderInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookBinderInfosFromReader(reader);
        }
    }

    public List<Li_BookBinderInfo> GetAllLi_BookBinderInfosForBill(string BookCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetBookBinderFromReceive", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookBinderInfosFromReader(reader);
        }
    }
    public List<Li_BookBinderInfo> GetLi_BookBinderInfosFromReader(IDataReader reader)
    {
        List<Li_BookBinderInfo> li_BookBinderInfos = new List<Li_BookBinderInfo>();

        while (reader.Read())
        {
            li_BookBinderInfos.Add(GetLi_BookBinderInfoFromReader(reader));
        }
        return li_BookBinderInfos;
    }

    public Li_BookBinderInfo GetLi_BookBinderInfoFromReader(IDataReader reader)
    {
        try
        {
            Li_BookBinderInfo li_BookBinderInfo = new Li_BookBinderInfo
                (
                     reader["BinderCode"].ToString(),
                    reader["BinderName"].ToString(),
                    reader["Address"].ToString(),
                    reader["Phone"].ToString(),
                    (decimal)reader["OpennigBalance"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    reader["B_Name"].ToString(),
                    reader["B_Add"].ToString()
                );
             return li_BookBinderInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookBinderInfo GetLi_BookBinderInfoByID(string  li_BookBinderInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookBinderInfoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BinderCode", SqlDbType.VarChar ).Value = li_BookBinderInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            if (reader.Read())
            {
                return GetLi_BookBinderInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_BookBinderInfo(Li_BookBinderInfo li_BookBinderInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookBinderInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BinderCode", SqlDbType.VarChar,50).Direction  = ParameterDirection .Output  ;
            cmd.Parameters.Add("@BinderName", SqlDbType.VarChar).Value = li_BookBinderInfo.BinderName;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_BookBinderInfo.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_BookBinderInfo.Phone;
            cmd.Parameters.Add("@OpennigBalance", SqlDbType.Decimal).Value = li_BookBinderInfo.OpennigBalance;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookBinderInfo.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookBinderInfo.CreatedBy;
            cmd.Parameters.Add("@B_Name", SqlDbType.VarChar).Value = li_BookBinderInfo.B_Name;
            cmd.Parameters.Add("@B_Add", SqlDbType.VarChar).Value = li_BookBinderInfo.B_Add;
            connection.Open();

            cmd.ExecuteNonQuery();
            return cmd.Parameters["@BinderCode"].Value.ToString();

        }
    }  

    public bool UpdateLi_BookBinderInfo(Li_BookBinderInfo li_BookBinderInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookBinderInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@BinderCode", SqlDbType.VarChar).Value = li_BookBinderInfo.BinderCode;
            cmd.Parameters.Add("@BinderName", SqlDbType.VarChar).Value = li_BookBinderInfo.BinderName;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_BookBinderInfo.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_BookBinderInfo.Phone;
            cmd.Parameters.Add("@OpennigBalance", SqlDbType.Decimal).Value = li_BookBinderInfo.OpennigBalance;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookBinderInfo.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookBinderInfo.CreatedBy;
            cmd.Parameters.Add("@B_Name", SqlDbType.VarChar).Value = li_BookBinderInfo.B_Name;
            cmd.Parameters.Add("@B_Add", SqlDbType.VarChar).Value = li_BookBinderInfo.B_Add;
            
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAllLi_BookBinderSupInfosByID(string BinderID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookBinderSupInfosByID", connection);
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
