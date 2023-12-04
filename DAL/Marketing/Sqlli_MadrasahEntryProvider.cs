using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_MadrasahEntryProvider:DataAccessObject
{
	public SqlLi_MadrasahEntryProvider()
    {
    }


    public bool DeleteLi_MadrasahEntry(int li_MadrasahEntryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteLi_MadrasahEntry", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_MadrasahEntryID", SqlDbType.Int).Value = li_MadrasahEntryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_MadrasahEntry> GetAllLi_MadrasahEntries( int thanaId)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLi_MadrasahEntries", connection);
            command.CommandType = CommandType.StoredProcedure;
            command .Parameters.Add("@ThanaId", SqlDbType.Int).Value = thanaId ;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_MadrasahEntriesFromReader(reader);
        }
    }
    public List<Li_MadrasahEntry> GetLi_MadrasahEntriesFromReader(IDataReader reader)
    {
        List<Li_MadrasahEntry> li_MadrasahEntries = new List<Li_MadrasahEntry>();

        while (reader.Read())
        {
            li_MadrasahEntries.Add(GetLi_MadrasahEntryFromReader(reader));
        }
        return li_MadrasahEntries;
    }

    public Li_MadrasahEntry GetLi_MadrasahEntryFromReader(IDataReader reader)
    {
        try
        {
            Li_MadrasahEntry li_MadrasahEntry = new Li_MadrasahEntry
                (
                     
                    reader["Code"].ToString(),
                    reader["Name"].ToString(),
                    reader["Address"].ToString(),
                    reader["PostOffice"].ToString(),
                    reader["Mobile"].ToString(),
                    (int)reader["MadLevel"],
                    (int)reader["Th_ID"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"]
                );
             return li_MadrasahEntry;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_MadrasahEntry GetLi_MadrasahEntryByID(string  Code)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLi_MadrasahEntryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Code", SqlDbType.VarChar).Value = Code ;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_MadrasahEntryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_MadrasahEntry(Li_MadrasahEntry li_MadrasahEntry)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLi_MadrasahEntry", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = li_MadrasahEntry.Code;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_MadrasahEntry.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_MadrasahEntry.Address;
            cmd.Parameters.Add("@PostOffice", SqlDbType.VarChar).Value = li_MadrasahEntry.PostOffice;
            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = li_MadrasahEntry.Mobile;
            cmd.Parameters.Add("@MadLevel", SqlDbType.Int).Value = li_MadrasahEntry.MadLevel;
            cmd.Parameters.Add("@Th_ID", SqlDbType.Int).Value = li_MadrasahEntry.Th_ID;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MadrasahEntry.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MadrasahEntry.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MadrasahEntry.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_MadrasahEntry.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_MadrasahEntry(Li_MadrasahEntry li_MadrasahEntry)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateLi_MadrasahEntry", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = li_MadrasahEntry.Code;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_MadrasahEntry.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_MadrasahEntry.Address;
            cmd.Parameters.Add("@PostOffice", SqlDbType.VarChar).Value = li_MadrasahEntry.PostOffice;
            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = li_MadrasahEntry.Mobile;
            cmd.Parameters.Add("@MadLevel", SqlDbType.Int).Value = li_MadrasahEntry.MadLevel;
            cmd.Parameters.Add("@Th_ID", SqlDbType.Int).Value = li_MadrasahEntry.Th_ID;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MadrasahEntry.CreatedBy;
            //cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MadrasahEntry.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MadrasahEntry.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_MadrasahEntry.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAllLi_MadrasahEntryByEIIN(string EIIN)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAllMadrasahEntryByEIIN", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Code", SqlDbType.VarChar).Value = EIIN;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetAllMadrasahEntry()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAllMadrasahEntry", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetMadrasahEntryByMadrashName(string MadName)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetMadrasahEntryByMadrashName", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MadName", SqlDbType.VarChar).Value = MadName;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetAllLi_MadrasahEntryByTerCodeAndEIIN(string EIIN,string TerCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAllMadrasahEntryByTeritoryCode_and_EIIN", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Code", SqlDbType.VarChar).Value = EIIN;
            command.Parameters.Add("@TerritoryCode", SqlDbType.VarChar).Value = TerCode;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet GetAllLi_MadrasahEntryByEIINandTerritoryID(string EIIN, int DetID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAllMadrasahEntryByEIINandTerritoryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Code", SqlDbType.VarChar).Value = EIIN;
            command.Parameters.Add("@DetID", SqlDbType.Int).Value = DetID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public DataSet Get_MadrasahInfoByRegDivTer(int RegID, int DivID, string TerCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetMadrasahInfoForDataEntry", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RegionID", SqlDbType.Int).Value = RegID;
            command.Parameters.Add("@DivisionID", SqlDbType.Int).Value = DivID;
            command.Parameters.Add("@TerritoryCode", SqlDbType.VarChar).Value = TerCode;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet Get_MadrasahInfoByEIIN( string eiin)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetMadrasahInfoForDataEntryByEIIN", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EIIN", SqlDbType.VarChar).Value = eiin;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
