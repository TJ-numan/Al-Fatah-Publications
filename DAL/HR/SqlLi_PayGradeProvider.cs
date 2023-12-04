using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_PayGradeProvider:DataAccessObject
{
	public SqlLi_PayGradeProvider()
    {
    }


    public bool DeleteLi_PayGrade(int li_PayGradeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PayGrade", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PayGrId", SqlDbType.Int).Value = li_PayGradeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PayGrade> GetAllLi_PayGrades()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PayGrades", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PayGradesFromReader(reader);
        }
    }
    public List<Li_PayGrade> GetLi_PayGradesFromReader(IDataReader reader)
    {
        List<Li_PayGrade> li_PayGrades = new List<Li_PayGrade>();

        while (reader.Read())
        {
            li_PayGrades.Add(GetLi_PayGradeFromReader(reader));
        }
        return li_PayGrades;
    }

    public Li_PayGrade GetLi_PayGradeFromReader(IDataReader reader)
    {
        try
        {
            Li_PayGrade li_PayGrade = new Li_PayGrade
                (
                   
                    (int)reader["PayGrId"],
                    reader["PayGrName"].ToString(),
                    (decimal)reader["StartAmt"],
                    (decimal)reader["EndAmt"],
                    reader["PayGrDes"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_PayGrade;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PayGrade GetLi_PayGradeByID(int li_PayGradeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PayGradeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PayGrId", SqlDbType.Int).Value = li_PayGradeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PayGradeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PayGrade(Li_PayGrade li_PayGrade)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PayGrade", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@PayGrId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PayGrName", SqlDbType.VarChar).Value = li_PayGrade.PayGrName;
            cmd.Parameters.Add("@StartAmt", SqlDbType.Decimal).Value = li_PayGrade.StartAmt;
            cmd.Parameters.Add("@EndAmt", SqlDbType.Decimal).Value = li_PayGrade.EndAmt;
            cmd.Parameters.Add("@PayGrDes", SqlDbType.VarChar).Value = li_PayGrade.PayGrDes;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PayGrade.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PayGrade.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PayGrade.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PayGrade.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PayGrade.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PayGrId"].Value;
        }
    }

    public bool UpdateLi_PayGrade(Li_PayGrade li_PayGrade)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PayGrade", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@PayGrId", SqlDbType.Int).Value = li_PayGrade.PayGrId;
            cmd.Parameters.Add("@PayGrName", SqlDbType.VarChar).Value = li_PayGrade.PayGrName;
            cmd.Parameters.Add("@StartAmt", SqlDbType.Decimal).Value = li_PayGrade.StartAmt;
            cmd.Parameters.Add("@EndAmt", SqlDbType.Decimal).Value = li_PayGrade.EndAmt;
            cmd.Parameters.Add("@PayGrDes", SqlDbType.VarChar).Value = li_PayGrade.PayGrDes; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PayGrade.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PayGrade.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PayGrade.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
