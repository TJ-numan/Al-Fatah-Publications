using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_RNDPlan_SectionProvider:DataAccessObject
{
	public SqlLi_RNDPlan_SectionProvider()
    {
    }


    public bool DeleteLi_RNDPlan_Section(int li_RNDPlan_SectionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_RNDPlan_Section", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_RNDPlan_SectionID", SqlDbType.Int).Value = li_RNDPlan_SectionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_RNDPlan_Section> GetAllLi_RNDPlan_Sections()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_RNDPlan_Sections", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_RNDPlan_SectionsFromReader(reader);
        }
    }
    public List<Li_RNDPlan_Section> GetLi_RNDPlan_SectionsFromReader(IDataReader reader)
    {
        List<Li_RNDPlan_Section> li_RNDPlan_Sections = new List<Li_RNDPlan_Section>();

        while (reader.Read())
        {
            li_RNDPlan_Sections.Add(GetLi_RNDPlan_SectionFromReader(reader));
        }
        return li_RNDPlan_Sections;
    }

    public Li_RNDPlan_Section GetLi_RNDPlan_SectionFromReader(IDataReader reader)
    {
        try
        {
            Li_RNDPlan_Section li_RNDPlan_Section = new Li_RNDPlan_Section
                (
                     
                    (int)reader["PlanID"],
                   
                    (int)reader["SectionID"],
                    (char)reader["Status_D"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"] ,
                    (bool)reader["IsSelect"]
                );
             return li_RNDPlan_Section;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_RNDPlan_Section GetLi_RNDPlan_SectionByID(int li_RNDPlan_SectionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_RNDPlan_SectionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_RNDPlan_SectionID", SqlDbType.Int).Value = li_RNDPlan_SectionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_RNDPlan_SectionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_RNDPlan_Section(Li_RNDPlan_Section li_RNDPlan_Section)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_RNDPlan_Section", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = li_RNDPlan_Section.PlanID;     
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_RNDPlan_Section.SectionID;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_RNDPlan_Section.Status_D;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RNDPlan_Section.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RNDPlan_Section.CreatedBy;
            cmd.Parameters.Add("@IsSelect", SqlDbType.Bit).Value = li_RNDPlan_Section.IsSelect;
   
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_RNDPlan_SectionID"].Value;
        }
    }

    public bool UpdateLi_RNDPlan_Section(Li_RNDPlan_Section li_RNDPlan_Section)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_RNDPlan_Section", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = li_RNDPlan_Section.PlanID;
 
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_RNDPlan_Section.SectionID;

            cmd.Parameters.Add("@IsSelect", SqlDbType.Bit).Value = li_RNDPlan_Section.IsSelect;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
