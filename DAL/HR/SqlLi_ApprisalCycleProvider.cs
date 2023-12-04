using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_ApprisalCycleProvider:DataAccessObject
{
	public SqlLi_ApprisalCycleProvider()
    {
    }


    public bool DeleteLi_ApprisalCycle(int li_ApprisalCycleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_ApprisalCycle", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AppId", SqlDbType.Int).Value = li_ApprisalCycleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ApprisalCycle> GetAllLi_ApprisalCycles()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_ApprisalCycles", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ApprisalCyclesFromReader(reader);
        }
    }
    public List<Li_ApprisalCycle> GetLi_ApprisalCyclesFromReader(IDataReader reader)
    {
        List<Li_ApprisalCycle> li_ApprisalCycles = new List<Li_ApprisalCycle>();

        while (reader.Read())
        {
            li_ApprisalCycles.Add(GetLi_ApprisalCycleFromReader(reader));
        }
        return li_ApprisalCycles;
    }

    public Li_ApprisalCycle GetLi_ApprisalCycleFromReader(IDataReader reader)
    {
        try
        {
            Li_ApprisalCycle li_ApprisalCycle = new Li_ApprisalCycle
                (
                  
                    (int)reader["AppId"],
                    reader["AppTitle"].ToString(),
                    (DateTime)reader["CyStDate"],
                    (DateTime)reader["CyEnDate"],
                    (DateTime)reader["TeFDate"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_ApprisalCycle;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ApprisalCycle GetLi_ApprisalCycleByID(int li_ApprisalCycleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_ApprisalCycleByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AppId", SqlDbType.Int).Value = li_ApprisalCycleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ApprisalCycleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ApprisalCycle(Li_ApprisalCycle li_ApprisalCycle)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_ApprisalCycle", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@AppId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AppTitle", SqlDbType.VarChar).Value = li_ApprisalCycle.AppTitle;
            cmd.Parameters.Add("@CyStDate", SqlDbType.DateTime).Value = li_ApprisalCycle.CyStDate;
            cmd.Parameters.Add("@CyEnDate", SqlDbType.DateTime).Value = li_ApprisalCycle.CyEnDate;
            cmd.Parameters.Add("@TeFDate", SqlDbType.DateTime).Value = li_ApprisalCycle.TeFDate;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_ApprisalCycle.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ApprisalCycle.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ApprisalCycle.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ApprisalCycle.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ApprisalCycle.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ApprisalCycle.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AppId"].Value;
        }
    }

    public bool UpdateLi_ApprisalCycle(Li_ApprisalCycle li_ApprisalCycle)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_ApprisalCycle", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@AppId", SqlDbType.Int).Value = li_ApprisalCycle.AppId;
            cmd.Parameters.Add("@AppTitle", SqlDbType.VarChar).Value = li_ApprisalCycle.AppTitle;
            cmd.Parameters.Add("@CyStDate", SqlDbType.DateTime).Value = li_ApprisalCycle.CyStDate;
            cmd.Parameters.Add("@CyEnDate", SqlDbType.DateTime).Value = li_ApprisalCycle.CyEnDate;
            cmd.Parameters.Add("@TeFDate", SqlDbType.DateTime).Value = li_ApprisalCycle.TeFDate;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_ApprisalCycle.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ApprisalCycle.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ApprisalCycle.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ApprisalCycle.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ApprisalCycle.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ApprisalCycle.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
