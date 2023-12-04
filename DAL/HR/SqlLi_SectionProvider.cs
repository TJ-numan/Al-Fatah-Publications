using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_SectionProvider:DataAccessObject
{
	public SqlLi_SectionProvider()
    {
    }


    public bool DeleteLi_Section(int li_SectionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Section", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SecId", SqlDbType.Int).Value = li_SectionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Section> GetAllLi_Sections()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLi_Sections", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SectionsFromReader(reader);
        }
    }
    public List<Li_Section> GetLi_SectionsFromReader(IDataReader reader)
    {
        List<Li_Section> li_Sections = new List<Li_Section>();

        while (reader.Read())
        {
            li_Sections.Add(GetLi_SectionFromReader(reader));
        }
        return li_Sections;
    }

    public Li_Section GetLi_SectionFromReader(IDataReader reader)
    {
        try
        {
            Li_Section li_Section = new Li_Section
                (
                   
                    (int)reader["SectId"],
                    reader["SecName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Section;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Section GetLi_SectionByID(int li_SectionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_SectionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SecId", SqlDbType.Int).Value = li_SectionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SectionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Section(Li_Section li_Section)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Section", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@SecId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SecName", SqlDbType.VarChar).Value = li_Section.SecName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Section.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Section.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Section.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Section.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Section.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SecId"].Value;
        }
    }

    public bool UpdateLi_Section(Li_Section li_Section)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Section", connection);
            cmd.CommandType = CommandType.StoredProcedure;          
            cmd.Parameters.Add("@SecId", SqlDbType.Int).Value = li_Section.SecId;
            cmd.Parameters.Add("@SecName", SqlDbType.VarChar).Value = li_Section.SecName; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Section.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Section.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Section.InfStId;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataTable LoadSectionFromEmpInfos(int DepId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.LoadsectionFromEmpInfos",connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value =DepId; 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
    public DataTable LoadAllSection()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("GetAllLi_Sections", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@DepId", SqlDbType.Int).Value =DepId; 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }

    public DataTable LoadHireSection()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_GetHireLi_Sections", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
    public DataTable LoadSectionByUser(int UserID)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_GetAllLi_LoadSectionByUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value =UserID; 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
    //--------------------------------------------rezaul Hossain------------------2021-06-01-----------
    public DataTable LoadAllSectionQawmi()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("GetAllLi_SectionsQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@DepId", SqlDbType.Int).Value =DepId; 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
    public DataTable LoadHireSectionQawmi()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_GetHireLi_SectionsQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
}
