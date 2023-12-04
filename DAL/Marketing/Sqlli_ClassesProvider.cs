using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ClassesProvider:DataAccessObject
{
	public SqlLi_ClassesProvider()
    {
    }


    public bool DeleteLi_Classes(int li_ClassesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Classes", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ClassesID", SqlDbType.Int).Value = li_ClassesID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Classes> GetAllLi_Classess()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Classess", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ClassessFromReader(reader);
        }
    }



    public List<Li_Classes> GetAllLi_ClassessByGroup(string Category, int groupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ClassessByGroupID", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Category", SqlDbType.VarChar).Value =Category;
            command.Parameters.Add("@GroupID", SqlDbType.Int).Value =groupID;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ClassessFromReader(reader);
        }
    }

    public List<Li_Classes> GetLi_ClassessFromReader(IDataReader reader)
    {
        List<Li_Classes> li_Classess = new List<Li_Classes>();

        while (reader.Read())
        {
            li_Classess.Add(GetLi_ClassesFromReader(reader));
        }
        return li_Classess;
    }

    public Li_Classes GetLi_ClassesFromReader(IDataReader reader)
    {
        try
        {
            Li_Classes li_Classes = new Li_Classes
                (
                     
                    (int)reader["ClassID"],
                    reader["ClassName"].ToString(),
                    reader["ClassDescription"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"] 
                );
             return li_Classes;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Classes GetLi_ClassesByID(int li_ClassesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ClassesByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ClassesID", SqlDbType.Int).Value = li_ClassesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ClassesFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Classes(Li_Classes li_Classes)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Classes", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ClassID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = li_Classes.ClassName;
            cmd.Parameters.Add("@ClassDescription", SqlDbType.VarChar).Value = li_Classes.ClassDescription;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Classes.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Classes.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Classes.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Classes.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClassID"].Value;
        }
    }

    public bool UpdateLi_Classes(Li_Classes li_Classes)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Classes", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_Classes.ClassID;
            cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = li_Classes.ClassName;
            cmd.Parameters.Add("@ClassDescription", SqlDbType.VarChar).Value = li_Classes.ClassDescription;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Classes.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Classes.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Classes.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Classes.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }



    public List<Li_Classes> GetComboSourceData_Classess()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetComboSourceData_Classess", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ClassessFromReader(reader);
        }
    }


    public DataSet GetClassBySession(int SessionID, int Section)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAllClassesBySectionNSession", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@SessionID", SqlDbType.Int).Value = SessionID;

            if (Section == 0)
            {
                command.Parameters.Add("@SectionID", SqlDbType.Int).Value = DBNull.Value ;
            }
            else
            {
                command.Parameters.Add("@SectionID", SqlDbType.Int).Value = Section ;
            }
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }

    }
    public List<Li_Classes> GetLi_ClassesByUserID(int UserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ClassesByUserIDRnD", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            return GetLi_ClassessFromReader(reader);           
        }
    }
    public List<Li_Classes> GetLi_ClassesByUserIDQawmi(int UserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ClassesByUserIDRnDQawmi", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            return GetLi_ClassessFromReader(reader);
        }
    }
    public List<Li_Classes> GetLi_ClassesWorkOrderByUserID(int UserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ClassesByUserIDRnDWorkOrder", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            return GetLi_ClassessFromReader(reader);
        }
    }
    public List<Li_Classes> GetLi_ClassesByUserIDForTecherEntry(int UserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_SMPM_li_Get_ClassesByUserIDForTeacherEntry", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            return GetLi_ClassessFromReader(reader);
        }
    }
    public List<Li_Classes> GetLi_ClassesByUserIDGraphics(int UserID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_SMPM_li_Get_ClassesByUserIDGraphics", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            return GetLi_ClassessFromReader(reader);
        }
    }

}
