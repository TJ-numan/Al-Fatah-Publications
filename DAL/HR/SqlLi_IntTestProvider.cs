using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_IntTestProvider:DataAccessObject
{
	public SqlLi_IntTestProvider()
    {
    }


    public bool DeleteLi_IntTest(int li_IntTestID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_IntTest", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TestId", SqlDbType.Int).Value = li_IntTestID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_IntTest> GetAllLi_IntTests()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_IntTests", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_IntTestsFromReader(reader);
        }
    }
    public List<Li_IntTest> GetLi_IntTestsFromReader(IDataReader reader)
    {
        List<Li_IntTest> li_IntTests = new List<Li_IntTest>();

        while (reader.Read())
        {
            li_IntTests.Add(GetLi_IntTestFromReader(reader));
        }
        return li_IntTests;
    }

    public Li_IntTest GetLi_IntTestFromReader(IDataReader reader)
    {
        try
        {
            Li_IntTest li_IntTest = new Li_IntTest
                (
                   
                    (int)reader["TestId"],
                    (int)reader["PosId"],
                    reader["TestTitle"].ToString(),
                    (decimal)reader["TotalMarks"],
                    (decimal)reader["TotalTime"],
                    reader["TimeSeg"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"],
                    reader["ObtainMark"].ToString()
                );
             return li_IntTest;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_IntTest GetLi_IntTestByID(int li_IntTestID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_IntTestByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TestId", SqlDbType.Int).Value = li_IntTestID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_IntTestFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_IntTest(Li_IntTest li_IntTest)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_IntTest", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@TestId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PosId", SqlDbType.Int).Value = li_IntTest.PosId;
            cmd.Parameters.Add("@TestTitle", SqlDbType.VarChar).Value = li_IntTest.TestTitle;
            cmd.Parameters.Add("@TotalMarks", SqlDbType.Decimal).Value = li_IntTest.TotalMarks;
            cmd.Parameters.Add("@TotalTime", SqlDbType.Decimal).Value = li_IntTest.TotalTime;
            cmd.Parameters.Add("@TimeSeg", SqlDbType.VarChar).Value = li_IntTest.TimeSeg;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_IntTest.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_IntTest.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_IntTest.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_IntTest.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_IntTest.InfStId;
            cmd.Parameters.Add("@ObtainMark", SqlDbType.NChar).Value = li_IntTest.ObtainMark;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TestId"].Value;
        }
    }

    public bool UpdateLi_IntTest(Li_IntTest li_IntTest)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_IntTest", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@TestId", SqlDbType.Int).Value = li_IntTest.TestId;
            cmd.Parameters.Add("@PosId", SqlDbType.Int).Value = li_IntTest.PosId;
            cmd.Parameters.Add("@TestTitle", SqlDbType.VarChar).Value = li_IntTest.TestTitle;
            cmd.Parameters.Add("@TotalMarks", SqlDbType.Decimal).Value = li_IntTest.TotalMarks;
            cmd.Parameters.Add("@TotalTime", SqlDbType.Decimal).Value = li_IntTest.TotalTime;
            cmd.Parameters.Add("@TimeSeg", SqlDbType.VarChar).Value = li_IntTest.TimeSeg;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_IntTest.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_IntTest.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_IntTest.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_IntTest.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_IntTest.InfStId;
            cmd.Parameters.Add("@ObtainMark", SqlDbType.NChar).Value = li_IntTest.ObtainMark;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
