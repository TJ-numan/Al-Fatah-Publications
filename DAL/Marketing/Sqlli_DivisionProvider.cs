using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_DivisionProvider:DataAccessObject
{
	public SqlLi_DivisionProvider()
    {
    }


    public bool DeleteLi_Division(int li_DivisionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Division", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_DivisionID", SqlDbType.Int).Value = li_DivisionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Division> GetAllLi_Divisions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Divisions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DivisionsFromReader(reader);
        }
    }

    public List<Li_Division> GetLi_DivisionsFromReader(IDataReader reader)
    {
        List<Li_Division> li_Divisions = new List<Li_Division>();

        while (reader.Read())
        {
            li_Divisions.Add(GetLi_DivisionFromReader(reader));
        }
        return li_Divisions;
    }

    public Li_Division GetLi_DivisionFromReader(IDataReader reader)
    {
        try
        {
            Li_Division li_Division = new Li_Division
                (

                    (int)reader["DivID"],
                    reader["DivName"].ToString(),
                    (int)reader["RegionID"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    reader["Div_Bn"].ToString(),
                     reader["RegionName"].ToString() 
                );
             return li_Division;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public List<Li_Division> GetLi_DivisionByID(int RegionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_DivisionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RegID", SqlDbType.Int).Value = RegionID;
            connection.Open();

            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DivisionsFromReader(reader);

             
        }
    }

    public int InsertLi_Division(Li_Division li_Division)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Division", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@DivID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DivName", SqlDbType.VarChar).Value = li_Division.DivName;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = li_Division.RegionID;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Division.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Division.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Division.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Division.ModifiedDate;
            cmd.Parameters.Add("@Div_Bn", SqlDbType.Text).Value = li_Division.Div_Bn;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DivID"].Value;
        }
    }

    public bool UpdateLi_Division(Li_Division li_Division)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Division", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@DivID", SqlDbType.Int).Value = li_Division.DivID;
            cmd.Parameters.Add("@DivName", SqlDbType.VarChar).Value = li_Division.DivName;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = li_Division.RegionID;
                   cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Division.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Division.ModifiedDate;
            cmd.Parameters.Add("@Div_Bn", SqlDbType.Text).Value = li_Division.Div_Bn;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAll_DivisionWithDivId(string DivId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_DivisionsById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DivID", SqlDbType.VarChar).Value = DivId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
