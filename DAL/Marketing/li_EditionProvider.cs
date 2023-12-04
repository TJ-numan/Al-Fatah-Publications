using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class Sql_li_EditionProvider:DataAccessObject
{
	public Sql_li_EditionProvider()
    {
    }


    public List<li_Edition> GetAll_Editions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_Editions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_EditionsFromReader(reader);
        }
    }

    public DataSet   GetAll_ThanasWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ThanasWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<li_Edition> Get_EditionsFromReader(IDataReader reader)
    {
        List<li_Edition> li_Editions = new List<li_Edition>();

        while (reader.Read())
        {
            li_Editions.Add(Get_EditionFromReader(reader));
        }
        return li_Editions;
    }

    public li_Edition Get_EditionFromReader(IDataReader reader)
    {
        try
        {
            li_Edition li_Edition = new li_Edition
                (

                    (int)reader["EditonID"],
                    reader["EditionName"].ToString(),
                    reader["EditionDescription"].ToString()
                );
             return li_Edition;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public li_Edition Get_EditionByEditonID(int  editonID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_EditionByEditonID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EditonID", SqlDbType.Int).Value = editonID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_EditionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int Insert_Edition(li_Edition li_Edition)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_Edition", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EditonID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EditionName", SqlDbType.VarChar).Value = li_Edition.EditionName;
            cmd.Parameters.Add("@EditionDescription", SqlDbType.NChar).Value = li_Edition.EditionDescription;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EditonID"].Value;
        }
    }

    public bool Update_Edition(li_Edition li_Edition)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_Edition", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EditonID", SqlDbType.Int).Value = li_Edition.EditonID;
            cmd.Parameters.Add("@EditionName", SqlDbType.VarChar).Value = li_Edition.EditionName;
            cmd.Parameters.Add("@EditionDescription", SqlDbType.NChar).Value = li_Edition.EditionDescription;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Delete_Edition(int editonID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_Edition", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EditonID", SqlDbType.Int).Value = editonID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public string  getDistinctEditionByBookID(string BookID)
    {
         
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetDistinctEditionByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
            command.Parameters.Add("@Edition", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            connection.Open();
            command .ExecuteNonQuery();
            return command.Parameters["@Edition"].Value.ToString();
           
        }
    }

    public string getPlanEditionByBookID(string BookID)
    {

        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetPlanEditionByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
            command.Parameters.Add("@Edition", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            connection.Open();
            command.ExecuteNonQuery();
            return command.Parameters["@Edition"].Value.ToString();

        }
    }
}

