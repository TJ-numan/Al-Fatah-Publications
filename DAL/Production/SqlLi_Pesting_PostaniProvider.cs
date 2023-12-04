using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Pesting_PostaniProvider:DataAccessObject
{
	public SqlLi_Pesting_PostaniProvider()
    {
    }


    public bool DeleteLi_Pesting_Postani(int li_Pesting_PostaniID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Pesting_Postani", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Pesting_PostaniID", SqlDbType.Int).Value = li_Pesting_PostaniID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Pesting_Postani> GetAllLi_Pesting_Postanis()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Pesting_Postanis", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Pesting_PostanisFromReader(reader);
        }
    }
    public List<Li_Pesting_Postani> GetLi_Pesting_PostanisFromReader(IDataReader reader)
    {
        List<Li_Pesting_Postani> li_Pesting_Postanis = new List<Li_Pesting_Postani>();

        while (reader.Read())
        {
            li_Pesting_Postanis.Add(GetLi_Pesting_PostaniFromReader(reader));
        }
        return li_Pesting_Postanis;
    }

    public Li_Pesting_Postani GetLi_Pesting_PostaniFromReader(IDataReader reader)
    {
        try
        {
            Li_Pesting_Postani li_Pesting_Postani = new Li_Pesting_Postani
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
             return li_Pesting_Postani;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Pesting_Postani GetLi_Pesting_PostaniByID(int li_Pesting_PostaniID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Pesting_PostaniByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Pesting_PostaniID", SqlDbType.Int).Value = li_Pesting_PostaniID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Pesting_PostaniFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Pesting_Postani(Li_Pesting_Postani li_Pesting_Postani)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_Pesting_Postani", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
           // cmd.Parameters.Add("@SerialNo", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_Pesting_Postani.OrderNo;
            cmd.Parameters.Add("@Fi_Color", SqlDbType.Decimal).Value = li_Pesting_Postani.Fi_Color;
            cmd.Parameters.Add("@Fo_Color", SqlDbType.Decimal).Value = li_Pesting_Postani.Fo_Color;
            cmd.Parameters.Add("@Thr_Color", SqlDbType.Decimal).Value = li_Pesting_Postani.Thr_Color;
            cmd.Parameters.Add("@Tw_Color", SqlDbType.Decimal).Value = li_Pesting_Postani.Tw_Color;
            cmd.Parameters.Add("@Si_Color", SqlDbType.Decimal).Value = li_Pesting_Postani.Si_Color;
            cmd.Parameters.Add("@B_W", SqlDbType.Decimal).Value = li_Pesting_Postani.B_W;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = li_Pesting_Postani.Total;
            cmd.Parameters.Add("@Machine", SqlDbType.VarChar).Value = li_Pesting_Postani.Machine;
            //cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Pesting_Postani.Status_D;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  1;
        }
    }

    public bool UpdateLi_Pesting_Postani(Li_Pesting_Postani li_Pesting_Postani)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Pesting_Postani", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_Pesting_Postani.SerialNo;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_Pesting_Postani.OrderNo;
            cmd.Parameters.Add("@Fo_Color", SqlDbType.Decimal).Value = li_Pesting_Postani.Fo_Color;
            cmd.Parameters.Add("@Tw_Color", SqlDbType.Decimal).Value = li_Pesting_Postani.Tw_Color;
            cmd.Parameters.Add("@Si_Color", SqlDbType.Decimal).Value = li_Pesting_Postani.Si_Color;
            cmd.Parameters.Add("@B_W", SqlDbType.Decimal).Value = li_Pesting_Postani.B_W;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = li_Pesting_Postani.Total;
            cmd.Parameters.Add("@Machine", SqlDbType.VarChar).Value = li_Pesting_Postani.Machine;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Pesting_Postani.Status_D;
      
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet getPestingPostaniDetailByOrder(string OrderNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_getPestingPostaniDetailByOrder", connection);
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
