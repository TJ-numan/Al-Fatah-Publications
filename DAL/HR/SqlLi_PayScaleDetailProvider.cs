using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_PayScaleDetailProvider:DataAccessObject
{
	public SqlLi_PayScaleDetailProvider()
    {
    }


    public bool DeleteLi_PayScaleDetail(int li_PayScaleDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PayScaleDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PSDetId", SqlDbType.Int).Value = li_PayScaleDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PayScaleDetail> GetAllLi_PayScaleDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PayScaleDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PayScaleDetailsFromReader(reader);
        }
    }
    public List<Li_PayScaleDetail> GetLi_PayScaleDetailsFromReader(IDataReader reader)
    {
        List<Li_PayScaleDetail> li_PayScaleDetails = new List<Li_PayScaleDetail>();

        while (reader.Read())
        {
            li_PayScaleDetails.Add(GetLi_PayScaleDetailFromReader(reader));
        }
        return li_PayScaleDetails;
    }

    public Li_PayScaleDetail GetLi_PayScaleDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_PayScaleDetail li_PayScaleDetail = new Li_PayScaleDetail
                (
            
                    (int)reader["PSDetId"],
                    (int)reader["PScId"],
                    (int)reader["PaHId"],
                    (decimal)reader["Amount"]
                );
             return li_PayScaleDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PayScaleDetail GetLi_PayScaleDetailByID(int li_PayScaleDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PayScaleDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PSDetId", SqlDbType.Int).Value = li_PayScaleDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PayScaleDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PayScaleDetail(Li_PayScaleDetail li_PayScaleDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PayScaleDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@PSDetId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PScId", SqlDbType.Int).Value = li_PayScaleDetail.PScId;
            cmd.Parameters.Add("@PaHId", SqlDbType.Int).Value = li_PayScaleDetail.PaHId;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_PayScaleDetail.Amount;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PSDetId"].Value;
        }
    }

    public bool UpdateLi_PayScaleDetail(Li_PayScaleDetail li_PayScaleDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PayScaleDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@PSDetId", SqlDbType.Int).Value = li_PayScaleDetail.PSDetId;
            cmd.Parameters.Add("@PScId", SqlDbType.Int).Value = li_PayScaleDetail.PScId;
            cmd.Parameters.Add("@PaHId", SqlDbType.Int).Value = li_PayScaleDetail.PaHId;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_PayScaleDetail.Amount;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetPayScale_ByPayGradeID(int PayGradeID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetPayScale_ByPayGradeID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PayGradeID", SqlDbType.Int).Value = PayGradeID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
}
