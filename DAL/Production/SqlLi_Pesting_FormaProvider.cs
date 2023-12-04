using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Pesting_FormaProvider:DataAccessObject
{
	public SqlLi_Pesting_FormaProvider()
    {
    }


    public bool DeleteLi_Pesting_Forma(int li_Pesting_FormaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Pesting_Forma", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Pesting_FormaID", SqlDbType.Int).Value = li_Pesting_FormaID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Pesting_Forma> GetAllLi_Pesting_Formas()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Pesting_Formas", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Pesting_FormasFromReader(reader);
        }
    }
    public List<Li_Pesting_Forma> GetLi_Pesting_FormasFromReader(IDataReader reader)
    {
        List<Li_Pesting_Forma> li_Pesting_Formas = new List<Li_Pesting_Forma>();

        while (reader.Read())
        {
            li_Pesting_Formas.Add(GetLi_Pesting_FormaFromReader(reader));
        }
        return li_Pesting_Formas;
    }

    public Li_Pesting_Forma GetLi_Pesting_FormaFromReader(IDataReader reader)
    {
        try
        {
            Li_Pesting_Forma li_Pesting_Forma = new Li_Pesting_Forma
                (
                    
                    (int)reader["SerialNo"],
                    reader["OrderNo"].ToString(),
                    (decimal)reader["Fi_Color"],
                    (decimal)reader["Fo_Color"],
                    (decimal)reader["Thr_Color"],
                    (decimal)reader["Tw_Color"],
                    (decimal)reader["Si_Color"],
                    (decimal)reader["B_W"],
                    (decimal)reader["Total"],
                    reader["Machine"].ToString(),
                    (char)reader["Status_D"] 
                );
             return li_Pesting_Forma;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Pesting_Forma GetLi_Pesting_FormaByID(int li_Pesting_FormaID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Pesting_FormaByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Pesting_FormaID", SqlDbType.Int).Value = li_Pesting_FormaID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Pesting_FormaFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Pesting_Forma(Li_Pesting_Forma li_Pesting_Forma)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_Pesting_Forma", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
           // cmd.Parameters.Add("@SerialNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_Pesting_Forma.OrderNo;
            cmd.Parameters.Add("@Fi_Color", SqlDbType.Decimal).Value = li_Pesting_Forma.Fi_Color;
            cmd.Parameters.Add("@Fo_Color", SqlDbType.Decimal).Value = li_Pesting_Forma.Fo_Color;
            cmd.Parameters.Add("@Thr_Color", SqlDbType.Decimal).Value = li_Pesting_Forma.Thr_Color;
            cmd.Parameters.Add("@Tw_Color", SqlDbType.Decimal).Value = li_Pesting_Forma.Tw_Color;
            cmd.Parameters.Add("@Si_Color", SqlDbType.Decimal).Value = li_Pesting_Forma.Si_Color;
            cmd.Parameters.Add("@B_W", SqlDbType.Decimal).Value = li_Pesting_Forma.B_W;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = li_Pesting_Forma.Total;
            cmd.Parameters.Add("@Machine", SqlDbType.VarChar).Value = li_Pesting_Forma.Machine;
            //cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Pesting_Forma.Status_D;
             
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_Pesting_Forma(Li_Pesting_Forma li_Pesting_Forma)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Pesting_Forma", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_Pesting_Forma.SerialNo;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_Pesting_Forma.OrderNo;
            cmd.Parameters.Add("@Fo_Color", SqlDbType.Decimal).Value = li_Pesting_Forma.Fo_Color;
            cmd.Parameters.Add("@Tw_Color", SqlDbType.Decimal).Value = li_Pesting_Forma.Tw_Color;
            cmd.Parameters.Add("@Si_Color", SqlDbType.Decimal).Value = li_Pesting_Forma.Si_Color;
            cmd.Parameters.Add("@B_W", SqlDbType.Decimal).Value = li_Pesting_Forma.B_W;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = li_Pesting_Forma.Total;
            cmd.Parameters.Add("@Machine", SqlDbType.VarChar).Value = li_Pesting_Forma.Machine;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Pesting_Forma.Status_D;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet getPestingFormaDetailByOrder(string OrderNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_getPestingFormaDetailByOrder", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@P_Order", SqlDbType.VarChar).Value = OrderNo;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


}
