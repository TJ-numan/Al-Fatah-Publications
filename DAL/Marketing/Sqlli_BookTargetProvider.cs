using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookTargetProvider:DataAccessObject
{
	public SqlLi_BookTargetProvider()
    {
    }


    public bool DeleteLi_BookTarget(int li_BookTargetID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookTarget", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookTargetID", SqlDbType.Int).Value = li_BookTargetID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookTarget> GetAllLi_BookTargets()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookTargets", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookTargetsFromReader(reader);
        }
    }
    public List<Li_BookTarget> GetLi_BookTargetsFromReader(IDataReader reader)
    {
        List<Li_BookTarget> li_BookTargets = new List<Li_BookTarget>();

        while (reader.Read())
        {
            li_BookTargets.Add(GetLi_BookTargetFromReader(reader));
        }
        return li_BookTargets;
    }

    public Li_BookTarget GetLi_BookTargetFromReader(IDataReader reader)
    {
        try
        {
            Li_BookTarget li_BookTarget = new Li_BookTarget
                (
                     
                    (DateTime)reader["SDate"],
                    (DateTime)reader["EDate"],
                    reader["TerritoryCode"].ToString(),
                    reader["TSOCode"].ToString(),
                    reader["BookCode"].ToString(),
                    (decimal)reader["Price"],
                    (decimal)reader["Qty"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"] ,
                    reader ["Edition"].ToString ()
                );
             return li_BookTarget;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookTarget GetLi_BookTargetByID(int li_BookTargetID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookTargetByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookTargetID", SqlDbType.Int).Value = li_BookTargetID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookTargetFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BookTarget(Li_BookTarget li_BookTarget)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookTarget", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@SDate", SqlDbType.DateTime).Value = li_BookTarget.SDate;
            cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = li_BookTarget.EDate;
            cmd.Parameters.Add("@TerritoryCode", SqlDbType.VarChar).Value = li_BookTarget.TerritoryCode;
            cmd.Parameters.Add("@TSOCode", SqlDbType.VarChar).Value = li_BookTarget.TSOCode;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookTarget.BookCode;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = li_BookTarget.Price;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_BookTarget.Qty;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookTarget.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookTarget.CreatedBy;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_BookTarget.Edition;     
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_BookTargetID"].Value;
        }
    }

    public bool UpdateLi_BookTarget(Li_BookTarget li_BookTarget)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookTarget", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SDate", SqlDbType.DateTime).Value = li_BookTarget.SDate;
            cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = li_BookTarget.EDate;
            cmd.Parameters.Add("@TerritoryCode", SqlDbType.VarChar).Value = li_BookTarget.TerritoryCode;
            cmd.Parameters.Add("@TSOCode", SqlDbType.VarChar).Value = li_BookTarget.TSOCode;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookTarget.BookCode;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = li_BookTarget.Price;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_BookTarget.Qty;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookTarget.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookTarget.CreatedBy;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet GetBookTergetQty(string  TerritoryCode,string BookCode,string Edition)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetTergetQty", connection);
            command.CommandType = CommandType.StoredProcedure;
            command .Parameters.Add("@TerritoryCode", SqlDbType.VarChar).Value =  TerritoryCode;
            command.Parameters.Add("@Edition", SqlDbType.VarChar).Value = Edition;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value =  BookCode;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet GetSalesTarget()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetSalesTargetName", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
}
