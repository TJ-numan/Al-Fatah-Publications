using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 

public class SqlLi_GoalProvider:DataAccessObject
{
	public SqlLi_GoalProvider()
    {
    }


    public bool DeleteLi_Goal(int li_GoalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Goal", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GoalId", SqlDbType.Int).Value = li_GoalID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Goal> GetAllLi_Goals()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Goals", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_GoalsFromReader(reader);
        }
    }
    public List<Li_Goal> GetLi_GoalsFromReader(IDataReader reader)
    {
        List<Li_Goal> li_Goals = new List<Li_Goal>();

        while (reader.Read())
        {
            li_Goals.Add(GetLi_GoalFromReader(reader));
        }
        return li_Goals;
    }

    public Li_Goal GetLi_GoalFromReader(IDataReader reader)
    {
        try
        {
            Li_Goal li_Goal = new Li_Goal
                (
                     
                    (int)reader["GoalId"],
                    reader["GoalTitle"].ToString(),
                    reader["GoalDes"].ToString(),
                    (int)reader["DepId"],
                    (int)reader["SecId"],
                    (int)reader["EmpNo"],
                    (DateTime)reader["StDate"],
                    (DateTime)reader["EnDate"],
                    (decimal)reader["Amount"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Goal;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Goal GetLi_GoalByID(int li_GoalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_GoalByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@GoalId", SqlDbType.Int).Value = li_GoalID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_GoalFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Goal(Li_Goal li_Goal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Goal", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@GoalId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@GoalTitle", SqlDbType.VarChar).Value = li_Goal.GoalTitle;
            cmd.Parameters.Add("@GoalDes", SqlDbType.VarChar).Value = li_Goal.GoalDes;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_Goal.DepId;
            cmd.Parameters.Add("@SecId", SqlDbType.Int).Value = li_Goal.SecId;
            cmd.Parameters.Add("@EmpNo", SqlDbType.Int).Value = li_Goal.EmpNo;
            cmd.Parameters.Add("@StDate", SqlDbType.DateTime).Value = li_Goal.StDate;
            cmd.Parameters.Add("@EnDate", SqlDbType.DateTime).Value = li_Goal.EnDate;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_Goal.Amount;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Goal.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Goal.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Goal.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Goal.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Goal.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@GoalId"].Value;
        }
    }

    public bool UpdateLi_Goal(Li_Goal li_Goal)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Goal", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@GoalId", SqlDbType.Int).Value = li_Goal.GoalId;
            cmd.Parameters.Add("@GoalTitle", SqlDbType.VarChar).Value = li_Goal.GoalTitle;
            cmd.Parameters.Add("@GoalDes", SqlDbType.VarChar).Value = li_Goal.GoalDes;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_Goal.DepId;
            cmd.Parameters.Add("@SecId", SqlDbType.Int).Value = li_Goal.SecId;
            cmd.Parameters.Add("@EmpNo", SqlDbType.Int).Value = li_Goal.EmpNo;
            cmd.Parameters.Add("@StDate", SqlDbType.DateTime).Value = li_Goal.StDate;
            cmd.Parameters.Add("@EnDate", SqlDbType.DateTime).Value = li_Goal.EnDate;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_Goal.Amount;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Goal.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Goal.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Goal.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Goal.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Goal.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
