using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PressInfoProvider:DataAccessObject
{
	public SqlLi_PressInfoProvider()
    {
    }


    public bool DeleteLi_PressInfo(int li_PressInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PressInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PressInfoID", SqlDbType.Int).Value = li_PressInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PressInfo> GetAllLi_PressInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PressInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PressInfosFromReader(reader);
        }
    }
    public List<Li_PressInfo> GetLi_PressInfosFromReader(IDataReader reader)
    {
        List<Li_PressInfo> li_PressInfos = new List<Li_PressInfo>();

        while (reader.Read())
        {
            li_PressInfos.Add(GetLi_PressInfoFromReader(reader));
        }
        return li_PressInfos;
    }

    public Li_PressInfo GetLi_PressInfoFromReader(IDataReader reader)
    {
        try
        {
            Li_PressInfo li_PressInfo = new Li_PressInfo
                (
                    
                    reader["PressID"].ToString(),
                    reader ["PressName"].ToString (),
                    reader["Address"].ToString(),
                    reader["Phone"].ToString(),
                    (decimal)reader["OpeningBalance"],
                    (DateTime)reader["CrteatedDate"],
                    (int)reader["CreatedBy"] ,
                    reader ["Name_Bn"].ToString (),
                    reader ["Add_Bn"].ToString ()
                     
                );
             return li_PressInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PressInfo GetLi_PressInfoByID(string  li_PressInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PressInfoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PressInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            if (reader.Read())
            {
                return GetLi_PressInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PressInfo(Li_PressInfo li_PressInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PressInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar,50) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PressName", SqlDbType.VarChar).Value = li_PressInfo.PressName;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_PressInfo.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_PressInfo.Phone;
            cmd.Parameters.Add("@OpeningBalance", SqlDbType.Decimal).Value = li_PressInfo.OpeningBalance;
            cmd.Parameters.Add("@CrteatedDate", SqlDbType.DateTime).Value = li_PressInfo.CrteatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PressInfo.CreatedBy;
            cmd.Parameters.Add("@Name_Bn", SqlDbType.VarChar).Value = li_PressInfo.Name_Bn;
            cmd.Parameters.Add("@Add_Bn", SqlDbType.VarChar).Value = li_PressInfo.Add_Bn;

             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@PressID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PressInfo(Li_PressInfo li_PressInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PressInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PressInfo.PressID;
            cmd.Parameters.Add("@PressName", SqlDbType.VarChar).Value = li_PressInfo.PressName;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_PressInfo.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_PressInfo.Phone;
            cmd.Parameters.Add("@OpeningBalance", SqlDbType.Decimal).Value = li_PressInfo.OpeningBalance;
            cmd.Parameters.Add("@CrteatedDate", SqlDbType.DateTime).Value = li_PressInfo.CrteatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PressInfo.CreatedBy;
            cmd.Parameters.Add("@Name_Bn", SqlDbType.VarChar).Value = li_PressInfo.Name_Bn;
            cmd.Parameters.Add("@Add_Bn", SqlDbType.VarChar).Value = li_PressInfo.Add_Bn;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetLi_PressPartyInfoByID(string PressID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PressInfosByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PressID", SqlDbType.VarChar).Value = PressID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


}
