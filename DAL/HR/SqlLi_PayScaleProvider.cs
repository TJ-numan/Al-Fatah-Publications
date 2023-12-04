using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_PayScaleProvider:DataAccessObject
{
	public SqlLi_PayScaleProvider()
    {
    }


    public bool DeleteLi_PayScale(int li_PayScaleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PayScale", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PScId", SqlDbType.Int).Value = li_PayScaleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PayScale> GetAllLi_PayScales()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PayScales", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PayScalesFromReader(reader);
        }
    }
    public List<Li_PayScale> GetLi_PayScalesFromReader(IDataReader reader)
    {
        List<Li_PayScale> li_PayScales = new List<Li_PayScale>();

        while (reader.Read())
        {
            li_PayScales.Add(GetLi_PayScaleFromReader(reader));
        }
        return li_PayScales;
    }

    public Li_PayScale GetLi_PayScaleFromReader(IDataReader reader)
    {
        try
        {
            Li_PayScale li_PayScale = new Li_PayScale
                (
                    
                    (int)reader["PScId"],
                    (int)reader["PayGrId"],
                    (decimal)reader["PSAmt"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_PayScale;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PayScale GetLi_PayScaleByID(int li_PayScaleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PayScaleByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PScId", SqlDbType.Int).Value = li_PayScaleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PayScaleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PayScale(Li_PayScale li_PayScale)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PayScale", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@PScId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PayGrId", SqlDbType.Int).Value = li_PayScale.PayGrId;
            cmd.Parameters.Add("@PSAmt", SqlDbType.Decimal).Value = li_PayScale.PSAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PayScale.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PayScale.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PayScale.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PayScale.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PayScale.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PScId"].Value;
        }
    }

    public bool UpdateLi_PayScale(Li_PayScale li_PayScale)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PayScale", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PScId", SqlDbType.Int).Value = li_PayScale.PScId;
            cmd.Parameters.Add("@PayGrId", SqlDbType.Int).Value = li_PayScale.PayGrId;
            cmd.Parameters.Add("@PSAmt", SqlDbType.Decimal).Value = li_PayScale.PSAmt; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PayScale.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PayScale.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PayScale.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
