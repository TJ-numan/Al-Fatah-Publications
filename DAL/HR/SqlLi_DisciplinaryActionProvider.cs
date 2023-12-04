using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_DisciplinaryActionProvider:DataAccessObject
{
	public SqlLi_DisciplinaryActionProvider()
    {
    }


    public bool DeleteLi_DisciplinaryAction(int li_DisciplinaryActionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_DisciplinaryAction", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DisAcId", SqlDbType.Int).Value = li_DisciplinaryActionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DisciplinaryAction> GetAllLi_DisciplinaryActions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_DisciplinaryActions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DisciplinaryActionsFromReader(reader);
        }
    }
    public List<Li_DisciplinaryAction> GetLi_DisciplinaryActionsFromReader(IDataReader reader)
    {
        List<Li_DisciplinaryAction> li_DisciplinaryActions = new List<Li_DisciplinaryAction>();

        while (reader.Read())
        {
            li_DisciplinaryActions.Add(GetLi_DisciplinaryActionFromReader(reader));
        }
        return li_DisciplinaryActions;
    }

    public Li_DisciplinaryAction GetLi_DisciplinaryActionFromReader(IDataReader reader)
    {
        try
        {
            Li_DisciplinaryAction li_DisciplinaryAction = new Li_DisciplinaryAction
                (
                     
                    (int)reader["DisAcId"],
                    (int)reader["EmpSl"],
                    (int)reader["EmploymentStId"],
                    reader["ActionTitle"].ToString(),
                    reader["ActionDes"].ToString(),
                    reader["AcDocPath"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_DisciplinaryAction;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_DisciplinaryAction GetLi_DisciplinaryActionByID(int li_DisciplinaryActionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_DisciplinaryActionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DisAcId", SqlDbType.Int).Value = li_DisciplinaryActionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DisciplinaryActionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DisciplinaryAction(Li_DisciplinaryAction li_DisciplinaryAction)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_DisciplinaryAction", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@DisAcId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_DisciplinaryAction.EmpSl;
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_DisciplinaryAction.EmploymentStId;
            cmd.Parameters.Add("@ActionTitle", SqlDbType.VarChar).Value = li_DisciplinaryAction.ActionTitle;
            cmd.Parameters.Add("@ActionDes", SqlDbType.VarChar).Value = li_DisciplinaryAction.ActionDes;
            cmd.Parameters.Add("@AcDocPath", SqlDbType.VarChar).Value = li_DisciplinaryAction.AcDocPath;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DisciplinaryAction.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DisciplinaryAction.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_DisciplinaryAction.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_DisciplinaryAction.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_DisciplinaryAction.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DisAcId"].Value;
        }
    }

    public bool UpdateLi_DisciplinaryAction(Li_DisciplinaryAction li_DisciplinaryAction)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_DisciplinaryAction", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@DisAcId", SqlDbType.Int).Value = li_DisciplinaryAction.DisAcId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_DisciplinaryAction.EmpSl;
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_DisciplinaryAction.EmploymentStId;
            cmd.Parameters.Add("@ActionTitle", SqlDbType.VarChar).Value = li_DisciplinaryAction.ActionTitle;
            cmd.Parameters.Add("@ActionDes", SqlDbType.VarChar).Value = li_DisciplinaryAction.ActionDes;
            cmd.Parameters.Add("@AcDocPath", SqlDbType.VarChar).Value = li_DisciplinaryAction.AcDocPath;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DisciplinaryAction.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DisciplinaryAction.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_DisciplinaryAction.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_DisciplinaryAction.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_DisciplinaryAction.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
