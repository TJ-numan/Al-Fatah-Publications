using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
 
using System.Linq; 
public class SqlLi_SpecimenAdjLetterDetailProvider:DataAccessObject
{
	public SqlLi_SpecimenAdjLetterDetailProvider()
    {
    }


    public bool DeleteLi_SpecimenAdjLetterDetail(int li_SpecimenAdjLetterDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_SpecimenAdjLetterDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_SpecimenAdjLetterDetailID", SqlDbType.Int).Value = li_SpecimenAdjLetterDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_SpecimenAdjLetterDetail> GetAllLi_SpecimenAdjLetterDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_SpecimenAdjLetterDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SpecimenAdjLetterDetailsFromReader(reader);
        }
    }
    public List<Li_SpecimenAdjLetterDetail> GetLi_SpecimenAdjLetterDetailsFromReader(IDataReader reader)
    {
        List<Li_SpecimenAdjLetterDetail> li_SpecimenAdjLetterDetails = new List<Li_SpecimenAdjLetterDetail>();

        while (reader.Read())
        {
            li_SpecimenAdjLetterDetails.Add(GetLi_SpecimenAdjLetterDetailFromReader(reader));
        }
        return li_SpecimenAdjLetterDetails;
    }

    public Li_SpecimenAdjLetterDetail GetLi_SpecimenAdjLetterDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_SpecimenAdjLetterDetail li_SpecimenAdjLetterDetail = new Li_SpecimenAdjLetterDetail
                (
               
                    (int)reader["LetDetId"],
                    (int)reader["LetterId"],
                    (DateTime)reader["Tran_Date"],
                    reader["MemoNo"].ToString(),
                    (decimal)reader["ReturnAmount"],
                    (decimal)reader["AdjustAmount"],
                    (bool)reader["IsIntFrom"]
                );
             return li_SpecimenAdjLetterDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_SpecimenAdjLetterDetail GetLi_SpecimenAdjLetterDetailByID(int li_SpecimenAdjLetterDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_SpecimenAdjLetterDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_SpecimenAdjLetterDetailID", SqlDbType.Int).Value = li_SpecimenAdjLetterDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SpecimenAdjLetterDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_SpecimenAdjLetterDetail(Li_SpecimenAdjLetterDetail li_SpecimenAdjLetterDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_SpecimenAdjLetterDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@LetDetId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LetterId", SqlDbType.Int).Value = li_SpecimenAdjLetterDetail.LetterId;
            cmd.Parameters.Add("@Tran_Date", SqlDbType.DateTime).Value = li_SpecimenAdjLetterDetail.Tran_Date;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_SpecimenAdjLetterDetail.MemoNo;
            cmd.Parameters.Add("@ReturnAmount", SqlDbType.Decimal).Value = li_SpecimenAdjLetterDetail.ReturnAmount;
            cmd.Parameters.Add("@AdjustAmount", SqlDbType.Decimal).Value = li_SpecimenAdjLetterDetail.AdjustAmount;
            cmd.Parameters.Add("@IsIntFrom", SqlDbType.Bit).Value = li_SpecimenAdjLetterDetail.IsIntFrom;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LetDetId"].Value;
        }
    }

    public bool UpdateLi_SpecimenAdjLetterDetail(Li_SpecimenAdjLetterDetail li_SpecimenAdjLetterDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_SpecimenAdjLetterDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@LetDetId", SqlDbType.Int).Value = li_SpecimenAdjLetterDetail.LetDetId;
            cmd.Parameters.Add("@LetterId", SqlDbType.Int).Value = li_SpecimenAdjLetterDetail.LetterId;
            cmd.Parameters.Add("@Tran_Date", SqlDbType.DateTime).Value = li_SpecimenAdjLetterDetail.Tran_Date;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_SpecimenAdjLetterDetail.MemoNo;
            cmd.Parameters.Add("@ReturnAmount", SqlDbType.Decimal).Value = li_SpecimenAdjLetterDetail.ReturnAmount;
            cmd.Parameters.Add("@AdjustAmount", SqlDbType.Decimal).Value = li_SpecimenAdjLetterDetail.AdjustAmount;
            cmd.Parameters.Add("@IsIntFrom", SqlDbType.Bit).Value = li_SpecimenAdjLetterDetail.IsIntFrom;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
