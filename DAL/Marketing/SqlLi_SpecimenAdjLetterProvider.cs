using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
  using System.Linq; 

public class SqlLi_SpecimenAdjLetterProvider:DataAccessObject
{
	public SqlLi_SpecimenAdjLetterProvider()
    {
    }


    public bool DeleteLi_SpecimenAdjLetter(int li_SpecimenAdjLetterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_SpecimenAdjLetter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_SpecimenAdjLetterID", SqlDbType.Int).Value = li_SpecimenAdjLetterID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_SpecimenAdjLetter> GetAllLi_SpecimenAdjLetters()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_SpecimenAdjLetters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SpecimenAdjLettersFromReader(reader);
        }
    }
    public List<Li_SpecimenAdjLetter> GetLi_SpecimenAdjLettersFromReader(IDataReader reader)
    {
        List<Li_SpecimenAdjLetter> li_SpecimenAdjLetters = new List<Li_SpecimenAdjLetter>();

        while (reader.Read())
        {
            li_SpecimenAdjLetters.Add(GetLi_SpecimenAdjLetterFromReader(reader));
        }
        return li_SpecimenAdjLetters;
    }

    public Li_SpecimenAdjLetter GetLi_SpecimenAdjLetterFromReader(IDataReader reader)
    {
        try
        {
            Li_SpecimenAdjLetter li_SpecimenAdjLetter = new Li_SpecimenAdjLetter
                (
           
                    (int)reader["LetterNo"],
                    reader["TsoId"].ToString(),
                    (decimal)reader["ReturnAmt"],
                    (decimal)reader["AdjustAmt"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    reader["Status_d"].ToString()
                );
             return li_SpecimenAdjLetter;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_SpecimenAdjLetter GetLi_SpecimenAdjLetterByID(int li_SpecimenAdjLetterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_SpecimenAdjLetterByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_SpecimenAdjLetterID", SqlDbType.Int).Value = li_SpecimenAdjLetterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SpecimenAdjLetterFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_SpecimenAdjLetter(Li_SpecimenAdjLetter li_SpecimenAdjLetter)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_SpecimenAdjLetter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@LetterNo", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TsoId", SqlDbType.VarChar).Value = li_SpecimenAdjLetter.TsoId;
            cmd.Parameters.Add("@ReturnAmt", SqlDbType.Decimal).Value = li_SpecimenAdjLetter.ReturnAmt;
            cmd.Parameters.Add("@AdjustAmt", SqlDbType.Decimal).Value = li_SpecimenAdjLetter.AdjustAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_SpecimenAdjLetter.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SpecimenAdjLetter.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_SpecimenAdjLetter.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_SpecimenAdjLetter.ModifiedDate;
            cmd.Parameters.Add("@Status_d", SqlDbType.VarChar).Value = li_SpecimenAdjLetter.Status_d;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LetterNo"].Value;
        }
    }

    public bool UpdateLi_SpecimenAdjLetter(Li_SpecimenAdjLetter li_SpecimenAdjLetter)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_SpecimenAdjLetter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@LetterNo", SqlDbType.Int).Value = li_SpecimenAdjLetter.LetterNo;
            cmd.Parameters.Add("@TsoId", SqlDbType.VarChar).Value = li_SpecimenAdjLetter.TsoId;
            cmd.Parameters.Add("@ReturnAmt", SqlDbType.Decimal).Value = li_SpecimenAdjLetter.ReturnAmt;
            cmd.Parameters.Add("@AdjustAmt", SqlDbType.Decimal).Value = li_SpecimenAdjLetter.AdjustAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_SpecimenAdjLetter.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SpecimenAdjLetter.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_SpecimenAdjLetter.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_SpecimenAdjLetter.ModifiedDate;
            cmd.Parameters.Add("@Status_d", SqlDbType.VarChar).Value = li_SpecimenAdjLetter.Status_d;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
