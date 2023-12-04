using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_LeminationOrderPrintProvider:DataAccessObject
{
	public SqlLi_LeminationOrderPrintProvider()
    {
    }


    public bool DeleteLi_LeminationOrderPrint(int li_LeminationOrderPrintID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_LeminationOrderPrint", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_LeminationOrderPrintID", SqlDbType.Int).Value = li_LeminationOrderPrintID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LeminationOrderPrint> GetAllLi_LeminationOrderPrints()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_LeminationOrderPrints", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LeminationOrderPrintsFromReader(reader);
        }
    }
    public List<Li_LeminationOrderPrint> GetLi_LeminationOrderPrintsFromReader(IDataReader reader)
    {
        List<Li_LeminationOrderPrint> li_LeminationOrderPrints = new List<Li_LeminationOrderPrint>();

        while (reader.Read())
        {
            li_LeminationOrderPrints.Add(GetLi_LeminationOrderPrintFromReader(reader));
        }
        return li_LeminationOrderPrints;
    }

    public Li_LeminationOrderPrint GetLi_LeminationOrderPrintFromReader(IDataReader reader)
    {
        try
        {
            Li_LeminationOrderPrint li_LeminationOrderPrint = new Li_LeminationOrderPrint
                (
                     
                    reader["OrderNo"].ToString(),
                    (DateTime)reader["OrderDate"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Status_D"],
                    (DateTime)reader["DeleDate"],
                    reader["CauseOfDel"].ToString(),
                    (int)reader["DeleBy"] 
                );
             return li_LeminationOrderPrint;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LeminationOrderPrint GetLi_LeminationOrderPrintByID(int li_LeminationOrderPrintID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_LeminationOrderPrintByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_LeminationOrderPrintID", SqlDbType.Int).Value = li_LeminationOrderPrintID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LeminationOrderPrintFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_LeminationOrderPrint(Li_LeminationOrderPrint li_LeminationOrderPrint)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_LeminationOrderPrint", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_LeminationOrderPrint.OrderDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeminationOrderPrint.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeminationOrderPrint.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_LeminationOrderPrint.Status_D;
            cmd.Parameters.Add("@DeleDate", SqlDbType.DateTime).Value = li_LeminationOrderPrint.DeleDate;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_LeminationOrderPrint.CauseOfDel;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = li_LeminationOrderPrint.DeleBy;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@OrderNo"].Value.ToString ();
        }
    }

    public bool UpdateLi_LeminationOrderPrint(Li_LeminationOrderPrint li_LeminationOrderPrint)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_LeminationOrderPrint", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_LeminationOrderPrint.OrderNo;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_LeminationOrderPrint.OrderDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeminationOrderPrint.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeminationOrderPrint.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_LeminationOrderPrint.Status_D;
            cmd.Parameters.Add("@DeleDate", SqlDbType.DateTime).Value = li_LeminationOrderPrint.DeleDate;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_LeminationOrderPrint.CauseOfDel;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = li_LeminationOrderPrint.DeleBy;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
