using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

public class SqlLi_CourseOutlineProvider : DataAccessObject
{
    public SqlLi_CourseOutlineProvider()
    {
    }


    public bool DeleteLi_CourseOutline(int li_CourseOutlineID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_CourseOutline", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CourseDetId", SqlDbType.Int).Value = li_CourseOutlineID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_CourseOutline> GetAllLi_CourseOutlines()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_CourseOutlines", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_CourseOutlinesFromReader(reader);
        }
    }
    public List<Li_CourseOutline> GetLi_CourseOutlinesFromReader(IDataReader reader)
    {
        List<Li_CourseOutline> li_CourseOutlines = new List<Li_CourseOutline>();

        while (reader.Read())
        {
            li_CourseOutlines.Add(GetLi_CourseOutlineFromReader(reader));
        }
        return li_CourseOutlines;
    }

    public Li_CourseOutline GetLi_CourseOutlineFromReader(IDataReader reader)
    {
        try
        {
            Li_CourseOutline li_CourseOutline = new Li_CourseOutline
                (

                    (int)reader["CourseDetId"],
                    reader["CourseOut"].ToString(),
                    reader["OutSession"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
            return li_CourseOutline;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_CourseOutline GetLi_CourseOutlineByID(int li_CourseOutlineID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_CourseOutlineByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseDetId", SqlDbType.Int).Value = li_CourseOutlineID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_CourseOutlineFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_CourseOutline(Li_CourseOutline li_CourseOutline)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_CourseOutline", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CourseDetId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CourseOut", SqlDbType.VarChar).Value = li_CourseOutline.CourseOut;
            cmd.Parameters.Add("@OutSession", SqlDbType.VarChar).Value = li_CourseOutline.OutSession;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_CourseOutline.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CourseOutline.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_CourseOutline.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_CourseOutline.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_CourseOutline.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CourseDetId"].Value;
        }
    }

    public bool UpdateLi_CourseOutline(Li_CourseOutline li_CourseOutline)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_CourseOutline", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@CourseDetId", SqlDbType.Int).Value = li_CourseOutline.CourseDetId;
            cmd.Parameters.Add("@CourseOut", SqlDbType.VarChar).Value = li_CourseOutline.CourseOut;
            cmd.Parameters.Add("@OutSession", SqlDbType.VarChar).Value = li_CourseOutline.OutSession;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_CourseOutline.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CourseOutline.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_CourseOutline.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_CourseOutline.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_CourseOutline.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
