using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_TrainInstituteProvider:DataAccessObject
{
	public SqlLi_TrainInstituteProvider()
    {
    }


    public bool DeleteLi_TrainInstitute(int li_TrainInstituteID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_TrainInstitute", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InsId", SqlDbType.Int).Value = li_TrainInstituteID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TrainInstitute> GetAllLi_TrainInstitutes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_TrainInstitutes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TrainInstitutesFromReader(reader);
        }
    }
    public List<Li_TrainInstitute> GetLi_TrainInstitutesFromReader(IDataReader reader)
    {
        List<Li_TrainInstitute> li_TrainInstitutes = new List<Li_TrainInstitute>();

        while (reader.Read())
        {
            li_TrainInstitutes.Add(GetLi_TrainInstituteFromReader(reader));
        }
        return li_TrainInstitutes;
    }

    public Li_TrainInstitute GetLi_TrainInstituteFromReader(IDataReader reader)
    {
        try
        {
            Li_TrainInstitute li_TrainInstitute = new Li_TrainInstitute
                (
                     
                    (int)reader["InsId"],
                    reader["InsName"].ToString(),
                    reader["InsAdd"].ToString(),
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_TrainInstitute;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TrainInstitute GetLi_TrainInstituteByID(int li_TrainInstituteID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_TrainInstituteByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@InsId", SqlDbType.Int).Value = li_TrainInstituteID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TrainInstituteFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_TrainInstitute(Li_TrainInstitute li_TrainInstitute)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_TrainInstitute", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@InsId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@InsName", SqlDbType.VarChar).Value = li_TrainInstitute.InsName;
            cmd.Parameters.Add("@InsAdd", SqlDbType.VarChar).Value = li_TrainInstitute.InsAdd;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_TrainInstitute.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TrainInstitute.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TrainInstitute.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_TrainInstitute.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_TrainInstitute.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_TrainInstitute.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@InsId"].Value;
        }
    }

    public bool UpdateLi_TrainInstitute(Li_TrainInstitute li_TrainInstitute)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_TrainInstitute", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@InsId", SqlDbType.Int).Value = li_TrainInstitute.InsId;
            cmd.Parameters.Add("@InsName", SqlDbType.VarChar).Value = li_TrainInstitute.InsName;
            cmd.Parameters.Add("@InsAdd", SqlDbType.VarChar).Value = li_TrainInstitute.InsAdd;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_TrainInstitute.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TrainInstitute.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TrainInstitute.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_TrainInstitute.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_TrainInstitute.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_TrainInstitute.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
