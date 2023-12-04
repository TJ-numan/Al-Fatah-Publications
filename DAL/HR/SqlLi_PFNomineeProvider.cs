using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_PFNomineeProvider:DataAccessObject
{
	public SqlLi_PFNomineeProvider()
    {
    }


    public bool DeleteLi_PFNominee(int li_PFNomineeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PFNominee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NomiId", SqlDbType.Int).Value = li_PFNomineeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PFNominee> GetAllLi_PFNominees()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PFNominees", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PFNomineesFromReader(reader);
        }
    }
    public List<Li_PFNominee> GetLi_PFNomineesFromReader(IDataReader reader)
    {
        List<Li_PFNominee> li_PFNominees = new List<Li_PFNominee>();

        while (reader.Read())
        {
            li_PFNominees.Add(GetLi_PFNomineeFromReader(reader));
        }
        return li_PFNominees;
    }

    public Li_PFNominee GetLi_PFNomineeFromReader(IDataReader reader)
    {
        try
        {
            Li_PFNominee li_PFNominee = new Li_PFNominee
                (
                  
                    (int)reader["NomiId"],
                    (int)reader["PFAppId"],
                    reader["NomiName"].ToString(),
                    reader["EmpRelation"].ToString(),
                    reader["NomiPerAddress"].ToString(),
                    reader["NomiPreAddress"].ToString(),
                    reader["NID"].ToString(),
                    reader["BirthId"].ToString(),
                    (decimal)reader["PercentRatio"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_PFNominee;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PFNominee GetLi_PFNomineeByID(int li_PFNomineeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PFNomineeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@NomiId", SqlDbType.Int).Value = li_PFNomineeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PFNomineeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PFNominee(Li_PFNominee li_PFNominee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PFNominee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@NomiId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PFAppId", SqlDbType.Int).Value = li_PFNominee.PFAppId;
            cmd.Parameters.Add("@NomiName", SqlDbType.VarChar).Value = li_PFNominee.NomiName;
            cmd.Parameters.Add("@EmpRelation", SqlDbType.VarChar).Value = li_PFNominee.EmpRelation;
            cmd.Parameters.Add("@NomiPerAddress", SqlDbType.VarChar).Value = li_PFNominee.NomiPerAddress;
            cmd.Parameters.Add("@NomiPreAddress", SqlDbType.VarChar).Value = li_PFNominee.NomiPreAddress;
            cmd.Parameters.Add("@NID", SqlDbType.VarChar).Value = li_PFNominee.NID;
            cmd.Parameters.Add("@BirthId", SqlDbType.VarChar).Value = li_PFNominee.BirthId;
            cmd.Parameters.Add("@PercentRatio", SqlDbType.Decimal).Value = li_PFNominee.PercentRatio;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_PFNominee.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFNominee.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFNominee.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFNominee.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFNominee.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFNominee.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@NomiId"].Value;
        }
    }

    public bool UpdateLi_PFNominee(Li_PFNominee li_PFNominee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PFNominee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@NomiId", SqlDbType.Int).Value = li_PFNominee.NomiId;
            cmd.Parameters.Add("@PFAppId", SqlDbType.Int).Value = li_PFNominee.PFAppId;
            cmd.Parameters.Add("@NomiName", SqlDbType.VarChar).Value = li_PFNominee.NomiName;
            cmd.Parameters.Add("@EmpRelation", SqlDbType.VarChar).Value = li_PFNominee.EmpRelation;
            cmd.Parameters.Add("@NomiPerAddress", SqlDbType.VarChar).Value = li_PFNominee.NomiPerAddress;
            cmd.Parameters.Add("@NomiPreAddress", SqlDbType.VarChar).Value = li_PFNominee.NomiPreAddress;
            cmd.Parameters.Add("@NID", SqlDbType.VarChar).Value = li_PFNominee.NID;
            cmd.Parameters.Add("@BirthId", SqlDbType.VarChar).Value = li_PFNominee.BirthId;
            cmd.Parameters.Add("@PercentRatio", SqlDbType.Decimal).Value = li_PFNominee.PercentRatio;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_PFNominee.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFNominee.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFNominee.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFNominee.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFNominee.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFNominee.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
