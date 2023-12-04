using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_CashLibraryProvider:DataAccessObject
{
	public SqlLi_CashLibraryProvider()
    {
    }


    public bool DeleteLi_CashLibrary(int li_CashLibraryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_CashLibrary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_CashLibraryID", SqlDbType.Int).Value = li_CashLibraryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_CashLibrary> GetAllLi_CashLibraries()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_CashLibraries", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_CashLibrariesFromReader(reader);
        }
    }
    public List<Li_CashLibrary> GetLi_CashLibrariesFromReader(IDataReader reader)
    {
        List<Li_CashLibrary> li_CashLibraries = new List<Li_CashLibrary>();

        while (reader.Read())
        {
            li_CashLibraries.Add(GetLi_CashLibraryFromReader(reader));
        }
        return li_CashLibraries;
    }

    public Li_CashLibrary GetLi_CashLibraryFromReader(IDataReader reader)
    {
        try
        {
            Li_CashLibrary li_CashLibrary = new Li_CashLibrary
                (
                
                    reader["LibraryID"].ToString(),
                    reader["LibraryName"].ToString(),
                    reader["PropName"].ToString(),
                    reader["Mobile"].ToString(),
                    reader["Category"].ToString(),
                    (decimal)reader["MonthlyAvg"],
                    reader["Add1"].ToString(),
                    reader["PostNo"].ToString(),
                    reader["TerritoryID"].ToString(),
                    reader["DistrictID"].ToString(),
                    (int)reader["ThanaID"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (char)reader["Status_D"],
                    reader["CauseOfDel"].ToString(),
                    (DateTime)reader["DelDate"],
                    reader["CreditID"].ToString() 
                     
                );
             return li_CashLibrary;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_CashLibrary GetLi_CashLibraryByID(int li_CashLibraryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_CashLibraryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_CashLibraryID", SqlDbType.Int).Value = li_CashLibraryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_CashLibraryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_CashLibrary(Li_CashLibrary li_CashLibrary)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_CashLibrary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = li_CashLibrary.LibraryName;
            cmd.Parameters.Add("@PropName", SqlDbType.VarChar).Value = li_CashLibrary.PropName;
            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = li_CashLibrary.Mobile;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = li_CashLibrary.Category;
            cmd.Parameters.Add("@MonthlyAvg", SqlDbType.Decimal).Value = li_CashLibrary.MonthlyAvg;
            cmd.Parameters.Add("@Add1", SqlDbType.VarChar).Value = li_CashLibrary.Add1;
            cmd.Parameters.Add("@PostNo", SqlDbType.VarChar).Value = li_CashLibrary.PostNo;
            cmd.Parameters.Add("@TerritoryID", SqlDbType.VarChar).Value = li_CashLibrary.TerritoryID;
            cmd.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = li_CashLibrary.DistrictID;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = li_CashLibrary.ThanaID;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_CashLibrary.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CashLibrary.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_CashLibrary.Status_D;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_CashLibrary.CauseOfDel;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_CashLibrary.DelDate;
            cmd.Parameters.Add("@CreditID", SqlDbType.VarChar).Value = li_CashLibrary.CreditID;
        
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@LibraryID"].Value.ToString ();
        }
    }

    public bool UpdateLi_CashLibrary(Li_CashLibrary li_CashLibrary)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_CashLibrary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_CashLibrary.LibraryID;
            cmd.Parameters.Add("@LibraryName", SqlDbType.VarChar).Value = li_CashLibrary.LibraryName;
            cmd.Parameters.Add("@PropName", SqlDbType.VarChar).Value = li_CashLibrary.PropName;
            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = li_CashLibrary.Mobile;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = li_CashLibrary.Category;
            cmd.Parameters.Add("@MonthlyAvg", SqlDbType.Decimal).Value = li_CashLibrary.MonthlyAvg;
            cmd.Parameters.Add("@Add1", SqlDbType.VarChar).Value = li_CashLibrary.Add1;
            cmd.Parameters.Add("@PostNo", SqlDbType.VarChar).Value = li_CashLibrary.PostNo;
            cmd.Parameters.Add("@TerritoryID", SqlDbType.VarChar).Value = li_CashLibrary.TerritoryID;
            cmd.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = li_CashLibrary.DistrictID;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = li_CashLibrary.ThanaID;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_CashLibrary.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CashLibrary.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_CashLibrary.Status_D;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_CashLibrary.CauseOfDel;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_CashLibrary.DelDate;
            cmd.Parameters.Add("@CreditID", SqlDbType.VarChar).Value = li_CashLibrary.CreditID;
        
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
