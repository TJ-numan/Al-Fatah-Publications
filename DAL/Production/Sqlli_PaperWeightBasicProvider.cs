using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperWeightBasicProvider:DataAccessObject
{
	public SqlLi_PaperWeightBasicProvider()
    {
    }


    public bool DeleteLi_PaperWeightBasic(int li_PaperWeightBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperWeightBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperWeightBasicID", SqlDbType.Int).Value = li_PaperWeightBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperWeightBasic> GetAllLi_PaperWeightBasics(string PaperSize)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperWeightBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PaperSize", SqlDbType.VarChar).Value = PaperSize;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperWeightBasicsFromReader(reader);
        }
    }
    public List<Li_PaperWeightBasic> GetLi_PaperWeightBasicsFromReader(IDataReader reader)
    {
        List<Li_PaperWeightBasic> li_PaperWeightBasics = new List<Li_PaperWeightBasic>();

        while (reader.Read())
        {
            li_PaperWeightBasics.Add(GetLi_PaperWeightBasicFromReader(reader));
        }
        return li_PaperWeightBasics;
    }

    public Li_PaperWeightBasic GetLi_PaperWeightBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperWeightBasic li_PaperWeightBasic = new Li_PaperWeightBasic
                (
                   
                    reader["ID"].ToString(),
                    reader["Weight"].ToString(),
                    reader ["PaperType"].ToString (),
                    reader["PaperSize"].ToString(),
                    reader["CreatedBy"].ToString(),
                    (DateTime)reader["CreatedDate"] 
                   
                );
             return li_PaperWeightBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PaperWeightBasic GetLi_PaperWeightBasicByID(int li_PaperWeightBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperWeightBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PaperWeightBasicID", SqlDbType.Int).Value = li_PaperWeightBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PaperWeightBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PaperWeightBasic(Li_PaperWeightBasic li_PaperWeightBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperWeightBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = li_PaperWeightBasic.Weight;
            cmd.Parameters.Add("@PaperType", SqlDbType.VarChar).Value = li_PaperWeightBasic. PaperType;
            cmd.Parameters.Add("@PaperSize", SqlDbType.VarChar).Value = li_PaperWeightBasic. PaperSize;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_PaperWeightBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperWeightBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PaperWeightBasic(Li_PaperWeightBasic li_PaperWeightBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperWeightBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PaperWeightBasic.ID;
            cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = li_PaperWeightBasic.Weight;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_PaperWeightBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperWeightBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
