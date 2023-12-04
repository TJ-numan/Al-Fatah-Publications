using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class Sqlli_BookTypeProvider:DataAccessObject
{
	public Sqlli_BookTypeProvider()
    {
    }


    public List<li_BookType> GetAll_BookTypes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_BookTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_BookTypesFromReader(reader);
        }
    }
    public List<li_BookType> Get_BookTypesFromReader(IDataReader reader)
    {
        List<li_BookType> li_BookTypes = new List<li_BookType>();

        while (reader.Read())
        {
            li_BookTypes.Add(Get_BookTypeFromReader(reader));
        }
        return li_BookTypes;
    }

    public li_BookType Get_BookTypeFromReader(IDataReader reader)
    {
        try
        {
            li_BookType li_BookType = new li_BookType
                (

                    (int)reader["BookTypeID"],
                    reader["BookType"].ToString()
                );
             return li_BookType;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public li_BookType Get_BookTypeByBookTypeID(int  bookTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_BookTypeByBookTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookTypeID", SqlDbType.Int).Value = bookTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_BookTypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int Insert_BookType(li_BookType li_BookType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_BookType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BookType", SqlDbType.VarChar).Value = li_BookType.BookType;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BookTypeID"].Value;
        }
    }

    public bool Update_BookType(li_BookType li_BookType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_BookType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookTypeID", SqlDbType.Int).Value = li_BookType.BookTypeID;
            cmd.Parameters.Add("@BookType", SqlDbType.VarChar).Value = li_BookType.BookType;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Delete_BookType(int bookTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_BookType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookTypeID", SqlDbType.Int).Value = bookTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public DataSet GetBookTypeByGroupNClass(string CatID, int ClassID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAllTypeByClassOrGroup", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@CategoryID", SqlDbType.VarChar).Value = CatID;
            if (ClassID == 0)
            {
                command.Parameters.Add("@ClassID", SqlDbType.VarChar).Value = DBNull.Value;

            }
            else
            {
                command.Parameters.Add("@ClassID", SqlDbType.VarChar).Value = ClassID ;
            }
            connection.Open();

            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }

    }

    public DataSet GetBookTypeBySessionNClass(int SessionID, int SectionID, int ClassID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAllTypeBySectionNSession", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@SessionID", SqlDbType.Int).Value = SessionID  ;

             
  
            if ( SectionID == 0)
            {
                command.Parameters.Add("@SectionID", SqlDbType.VarChar).Value = DBNull.Value;

            }
            else
            {
                command.Parameters.Add("@SectionID", SqlDbType.VarChar).Value = SectionID  ;
            }



            if (ClassID == 0)
            {
                command.Parameters.Add("@ClassID", SqlDbType.VarChar).Value = DBNull.Value;

            }
            else
            {
                command.Parameters.Add("@ClassID", SqlDbType.VarChar).Value = ClassID ;
            }


            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }

    }
}

