using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Pesting_InnerProvider:DataAccessObject
{
	public SqlLi_Pesting_InnerProvider()
    {
    }


    public bool DeleteLi_Pesting_Inner(int li_Pesting_InnerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Pesting_Inner", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Pesting_InnerID", SqlDbType.Int).Value = li_Pesting_InnerID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Pesting_Inner> GetAllLi_Pesting_Inners()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Pesting_Inners", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Pesting_InnersFromReader(reader);
        }
    }
    public List<Li_Pesting_Inner> GetLi_Pesting_InnersFromReader(IDataReader reader)
    {
        List<Li_Pesting_Inner> li_Pesting_Inners = new List<Li_Pesting_Inner>();

        while (reader.Read())
        {
            li_Pesting_Inners.Add(GetLi_Pesting_InnerFromReader(reader));
        }
        return li_Pesting_Inners;
    }

    public Li_Pesting_Inner GetLi_Pesting_InnerFromReader(IDataReader reader)
    {
        try
        {
            Li_Pesting_Inner li_Pesting_Inner = new Li_Pesting_Inner
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
             return li_Pesting_Inner;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Pesting_Inner GetLi_Pesting_InnerByID(int li_Pesting_InnerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Pesting_InnerByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Pesting_InnerID", SqlDbType.Int).Value = li_Pesting_InnerID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Pesting_InnerFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Pesting_Inner(Li_Pesting_Inner li_Pesting_Inner)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_Pesting_Inner", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
          //  cmd.Parameters.Add("@SerialNo", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_Pesting_Inner.OrderNo;
            cmd.Parameters.Add("@Fi_Color", SqlDbType.Decimal).Value = li_Pesting_Inner.Fi_Color;
            cmd.Parameters.Add("@Fo_Color", SqlDbType.Decimal).Value = li_Pesting_Inner.Fo_Color;
            cmd.Parameters.Add("@Thr_Color", SqlDbType.Decimal).Value = li_Pesting_Inner.Thr_Color;
            cmd.Parameters.Add("@Tw_Color", SqlDbType.Decimal).Value = li_Pesting_Inner.Tw_Color;
            cmd.Parameters.Add("@Si_Color", SqlDbType.Decimal).Value = li_Pesting_Inner.Si_Color;
            cmd.Parameters.Add("@B_W", SqlDbType.Decimal).Value = li_Pesting_Inner.B_W;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = li_Pesting_Inner.Total;
            cmd.Parameters.Add("@Machine", SqlDbType.VarChar).Value = li_Pesting_Inner.Machine;
            //cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Pesting_Inner.Status_D;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  1;
        }
    }

    public bool UpdateLi_Pesting_Inner(Li_Pesting_Inner li_Pesting_Inner)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Pesting_Inner", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_Pesting_Inner.SerialNo;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_Pesting_Inner.OrderNo;
            cmd.Parameters.Add("@Fo_Color", SqlDbType.Decimal).Value = li_Pesting_Inner.Fo_Color;
            cmd.Parameters.Add("@Tw_Color", SqlDbType.Decimal).Value = li_Pesting_Inner.Tw_Color;
            cmd.Parameters.Add("@Si_Color", SqlDbType.Decimal).Value = li_Pesting_Inner.Si_Color;
            cmd.Parameters.Add("@B_W", SqlDbType.Decimal).Value = li_Pesting_Inner.B_W;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = li_Pesting_Inner.Total;
            cmd.Parameters.Add("@Machine", SqlDbType.VarChar).Value = li_Pesting_Inner.Machine;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Pesting_Inner.Status_D;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet getPestingInnerDetailByOrder(string OrderNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_getPestingInnerDetailByOrder", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@P_Order", SqlDbType.VarChar).Value =  OrderNo ;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);

            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


}
