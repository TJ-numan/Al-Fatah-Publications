using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

  public  class Sql_li_OrganizationProvider :DataAccessObject
    {
      public Sql_li_OrganizationProvider()
    {
    }

      public DataSet GetALLLibraryWiseOrganizatioInformation(string LibraryID)
      {

          DataSet ds = new DataSet();
          using (SqlConnection connection = new SqlConnection(this.ConnectionString))
          {
              SqlCommand command = new SqlCommand("SMPM_li_AllLibraryWisOrganizationInformation", connection);
              command.CommandType = CommandType.StoredProcedure;
              command.Parameters.Add("@libraryID", SqlDbType.VarChar).Value = LibraryID;
              connection.Open();
              SqlDataAdapter myadapter = new SqlDataAdapter(command);
              myadapter.Fill(ds);
              myadapter.Dispose();
              connection.Close();

              return ds;
          }
      }


    public List<li_Organization> GetAll_Organization()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_Organizations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_OrganizationInfoFromReaders(reader);
        }
    }

    public DataSet GetOrganizationInformationByID(int ID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_OrganizationBy_ID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }

    }


    public string Insert_OrganizationInformation(li_LibraryWiseOrganizationInformation li_LibraryWiseOrganizationInformation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_OrganizationInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_LibraryWiseOrganizationInformation.ID;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_LibraryWiseOrganizationInformation.LibraryID;
            
            connection.Open();

            cmd.ExecuteNonQuery();

            return null;
        }
    }


    public List<li_Organization> Get_OrganizationByID(int ID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_OrganizationBy_ID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            return Get_OrganizationInfoFromReaders(reader);
        }
    }

    public bool Delete_OrganizationFromDatabase(string LibraryID, int serialOrganization)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_OrganizationFromLibrary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@libraryID", SqlDbType.VarChar).Value = LibraryID;
            cmd.Parameters.Add("@SerialOrg", SqlDbType.Int).Value = serialOrganization;
            connection.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
    }


    public List<li_Organization> Get_OrganizationInfoFromReaders(IDataReader reader)
    {
        List<li_Organization> li_Organization = new List<li_Organization>();

        while (reader.Read())
        {
            li_Organization.Add(Get_OrganizationInfoFromReader(reader));
        }
        return li_Organization;
    }

    public li_Organization Get_OrganizationInfoFromReader(IDataReader reader)
    {
        try
        {
            li_Organization li_Organization = new li_Organization
                (

                    (int)reader["ID"],
                    reader["Organization"].ToString(),
                    (int)reader["Serialorg"]

                );
            return li_Organization;
        }
        catch (Exception ex)
        {
            return null;
        }
    }




    }
