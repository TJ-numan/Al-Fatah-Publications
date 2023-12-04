using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class Sql_li_LibraryOwnerProvider:DataAccessObject
{
	public Sql_li_LibraryOwnerProvider()
    {
    }


    public List<li_LibraryOwner> GetAll_LibraryOwners()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_LibraryOwners", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_LibraryOwnersFromReader(reader);
        }
    }
    public List<li_LibraryOwner> Get_LibraryOwnersFromReader(IDataReader reader)
    {
        List<li_LibraryOwner> li_LibraryOwners = new List<li_LibraryOwner>();

        while (reader.Read())
        {
            li_LibraryOwners.Add(Get_LibraryOwnerFromReader(reader));
        }
        return li_LibraryOwners;
    }

    public li_LibraryOwner Get_LibraryOwnerFromReader(IDataReader reader)
    {
        try
        {
            li_LibraryOwner li_LibraryOwner = new li_LibraryOwner
                (

                    reader["LibraryOwnerID"].ToString(),
                    reader["OwnerName"].ToString(),
                    reader["PropitorMobile"].ToString(),
                    reader["ManagerMobile"].ToString(),
                    reader["ProbableFutueAgent"].ToString(),
                   (int) reader ["RegionID"],
                   (int)reader["TeritoryID"],
                   (int)reader["AreaID"],
                   (int)reader["DistrictID"],
                   (int)reader["ThanaID"]
                );
             return li_LibraryOwner;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public li_LibraryOwner Get_LibraryOwnerByLibraryOwnerID(string  libraryOwnerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_LibraryOwnerByLibraryOwnerID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LibraryOwnerID", SqlDbType.VarChar).Value = libraryOwnerID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_LibraryOwnerFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string    Insert_LibraryOwner(li_LibraryOwner li_LibraryOwner)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_LibraryOwner", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.Add("@LibraryOwnerID", SqlDbType.VarChar).Value = li_LibraryOwner.LibraryOwnerID;//.Direction = ParameterDirection.Output;
          //cmd.Parameters.Add("@LibraryOwnerID", SqlDbType.VarChar).Value = li_LibraryOwner.LibraryOwnerID;
            cmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = li_LibraryOwner.OwnerName;
            cmd.Parameters.Add("@PropitorMobile", SqlDbType.VarChar).Value = li_LibraryOwner.PropitorMobile;
            cmd.Parameters.Add("@ManagerMobile", SqlDbType.VarChar).Value = li_LibraryOwner.ManagerMobile;
            cmd.Parameters.Add("@ProbableFutueAgent", SqlDbType.VarChar).Value = li_LibraryOwner.ProbableFutueAgent;
            cmd .Parameters .Add ("@RegionID",SqlDbType.Int).Value =li_LibraryOwner .RegionID ;
            cmd .Parameters .Add ("@TeritoryID",SqlDbType.Int ).Value =li_LibraryOwner.TeritoryID;
            cmd .Parameters .Add ("@AreaID",SqlDbType.Int).Value=li_LibraryOwner .Area;

            cmd .Parameters .Add ("@DistrictID",SqlDbType.Int ).Value =li_LibraryOwner.District ;

            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = li_LibraryOwner.Thana;
            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
 
            connection.Open();
            cmd.ExecuteNonQuery();
            return cmd.Parameters["@ReturnID"].Value.ToString();

        }
    }

    public bool Update_LibraryOwner(li_LibraryOwner li_LibraryOwner)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_LibraryOwner", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LibraryOwnerID", SqlDbType.VarChar).Value = li_LibraryOwner.LibraryOwnerID;
            cmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = li_LibraryOwner.OwnerName;
            cmd.Parameters.Add("@PropitorMobile", SqlDbType.VarChar).Value = li_LibraryOwner.PropitorMobile;
            cmd.Parameters.Add("@ManagerMobile", SqlDbType.VarChar).Value = li_LibraryOwner.ManagerMobile;
            cmd.Parameters.Add("@ProbableFutueAgent", SqlDbType.VarChar).Value = li_LibraryOwner.ProbableFutueAgent;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Delete_LibraryOwner(int libraryOwnerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_LibraryOwner", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LibraryOwnerID", SqlDbType.VarChar).Value = libraryOwnerID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public DataSet GetALLLibraryOwnerInformation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_ShowAllLibraryOwner", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

}

