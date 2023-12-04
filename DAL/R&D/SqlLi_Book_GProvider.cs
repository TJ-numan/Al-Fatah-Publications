using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Book_GProvider:DataAccessObject
{
	public SqlLi_Book_GProvider()
    {
    }


    public bool DeleteLi_Book_G(int li_Book_GID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Book_G", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Book_GID", SqlDbType.Int).Value = li_Book_GID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Book_G> GetAllLi_Book_Gs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Book_Gs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Book_GsFromReader(reader);
        }
    }
    public List<Li_Book_G> GetLi_Book_GsFromReader(IDataReader reader)
    {
        List<Li_Book_G> li_Book_Gs = new List<Li_Book_G>();

        while (reader.Read())
        {
            li_Book_Gs.Add(GetLi_Book_GFromReader(reader));
        }
        return li_Book_Gs;
    }



    public Li_Book_G GetLi_Book_GFromReader(IDataReader reader)
    {
        try
        {
            Li_Book_G li_Book_G = new Li_Book_G
                (
                     
                    (int)reader["GID"],
                    reader["GName"].ToString(),
                    reader["G_Detail"].ToString() 
                );
             return li_Book_G;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public List<Li_Book_G> GetLi_Book_GByID( string  CategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Book_GByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.VarChar ).Value = CategoryID ;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Book_GsFromReader(reader);
            
        }
    }

    public int InsertLi_Book_G(Li_Book_G li_Book_G)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Book_G", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@GID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@GName", SqlDbType.VarChar).Value = li_Book_G.GName;
            cmd.Parameters.Add("@G_Detail", SqlDbType.VarChar).Value = li_Book_G.G_Detail;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_Book_G(Li_Book_G li_Book_G)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Book_G", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@GID", SqlDbType.Int).Value = li_Book_G.GID;
            cmd.Parameters.Add("@GName", SqlDbType.VarChar).Value = li_Book_G.GName;
            cmd.Parameters.Add("@G_Detail", SqlDbType.VarChar).Value = li_Book_G.G_Detail;
         
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }



    public DataSet GetBookTypeByMonth(  string fromDate  ,  string toDate ,int GroupID ,int ClassID )
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetBookTypeIDByMonth", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromDate;

            command.Parameters.Add("@Todate", SqlDbType.VarChar).Value = toDate;

            
            if (GroupID  == 0)
            {
                command.Parameters.Add("@GroupID", SqlDbType.VarChar).Value = DBNull.Value;

            }
            else
            {
                command.Parameters.Add("@GroupID", SqlDbType.VarChar).Value =  GroupID  ;
            }
    
            if (ClassID == 0)
            {
                command.Parameters.Add("@ClassID", SqlDbType.VarChar).Value = DBNull.Value;

            }
            else
            {
                command.Parameters.Add("@ClassID", SqlDbType.VarChar).Value = ClassID;
            }
    
           
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }

    }
 public DataSet GetBookClassByMonth(  string fromDate  ,  string toDate ,int GroupID   )
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetBookClassIDByMonth", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromDate;

            command.Parameters.Add("@Todate", SqlDbType.VarChar).Value = toDate;

            
            if (GroupID  == 0)
            {
                command.Parameters.Add("@GroupID", SqlDbType.VarChar).Value = DBNull.Value;

            }
            else
            {
                command.Parameters.Add("@GroupID", SqlDbType.VarChar).Value =  GroupID  ;
            }
    
             
    
           
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }

    }
 public DataSet GetBookGroupByMonth(  string fromDate  ,  string toDate   )
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetBookGroupIDByMonth", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromDate;

            command.Parameters.Add("@Todate", SqlDbType.VarChar).Value = toDate;

            
             
    
           
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }

    }
}
