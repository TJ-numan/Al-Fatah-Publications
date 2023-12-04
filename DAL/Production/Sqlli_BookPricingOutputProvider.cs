using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookPricingOutputProvider:DataAccessObject
{
	public SqlLi_BookPricingOutputProvider()
    {
    }


    public bool DeleteLi_BookPricingOutput(int li_BookPricingOutputID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookPricingOutput", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookPricingOutputID", SqlDbType.Int).Value = li_BookPricingOutputID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookPricingOutput> GetAllLi_BookPricingOutputs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookPricingOutputs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookPricingOutputsFromReader(reader);
        }
    }
    public List<Li_BookPricingOutput> GetLi_BookPricingOutputsFromReader(IDataReader reader)
    {
        List<Li_BookPricingOutput> li_BookPricingOutputs = new List<Li_BookPricingOutput>();

        while (reader.Read())
        {
            li_BookPricingOutputs.Add(GetLi_BookPricingOutputFromReader(reader));
        }
        return li_BookPricingOutputs;
    }

    public Li_BookPricingOutput GetLi_BookPricingOutputFromReader(IDataReader reader)
    {
        try
        {
            Li_BookPricingOutput li_BookPricingOutput = new Li_BookPricingOutput
                (
                    
                    reader["BookAcCode"].ToString(),
                    reader["Tot_Dir_Cost"].ToString(),
                    reader["Tot_Cost_Sale"].ToString(),
                    reader["Final_Rev"].ToString(),
                    reader["Net_Price"].ToString(),
                    reader["Writ_Price"].ToString(),
                    reader["TCS_Forma"].ToString(),
                    reader["FinalRe_Forma"].ToString() ,
                    reader ["MRP_Forma"].ToString ()
                   
                );
             return li_BookPricingOutput;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookPricingOutput GetLi_BookPricingOutputByID(string  li_BookPricingOutputID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookPricingOutputByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_BookPricingOutputID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            if (reader.Read())
            {
                return GetLi_BookPricingOutputFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BookPricingOutput(Li_BookPricingOutput li_BookPricingOutput)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookPricingOutput", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_BookPricingOutput.BookAcCode;
            cmd.Parameters.Add("@Tot_Dir_Cost", SqlDbType.VarChar).Value = li_BookPricingOutput.Tot_Dir_Cost;
            cmd.Parameters.Add("@Tot_Cost_Sale", SqlDbType.VarChar).Value = li_BookPricingOutput.Tot_Cost_Sale;
            cmd.Parameters.Add("@Final_Rev", SqlDbType.VarChar).Value = li_BookPricingOutput.Final_Rev;
            cmd.Parameters.Add("@Net_Price", SqlDbType.VarChar).Value = li_BookPricingOutput.Net_Price;
            cmd.Parameters.Add("@Writ_Price", SqlDbType.VarChar).Value = li_BookPricingOutput.Writ_Price;
            cmd.Parameters.Add("@TCS_Forma", SqlDbType.VarChar).Value = li_BookPricingOutput.TCS_Forma;
            cmd.Parameters.Add("@FinalRe_Forma", SqlDbType.VarChar).Value = li_BookPricingOutput.FinalRe_Forma;
            cmd.Parameters.Add("@MRP_Forma", SqlDbType.VarChar).Value = li_BookPricingOutput.MRP_Forma;
        
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  1;
        }
    }

    public bool UpdateLi_BookPricingOutput(Li_BookPricingOutput li_BookPricingOutput)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookPricingOutput", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_BookPricingOutput.BookAcCode;
            cmd.Parameters.Add("@Tot_Dir_Cost", SqlDbType.VarChar).Value = li_BookPricingOutput.Tot_Dir_Cost;
            cmd.Parameters.Add("@Tot_Cost_Sale", SqlDbType.VarChar).Value = li_BookPricingOutput.Tot_Cost_Sale;
            cmd.Parameters.Add("@Final_Rev", SqlDbType.VarChar).Value = li_BookPricingOutput.Final_Rev;
            cmd.Parameters.Add("@Net_Price", SqlDbType.VarChar).Value = li_BookPricingOutput.Net_Price;
            cmd.Parameters.Add("@Writ_Price", SqlDbType.VarChar).Value = li_BookPricingOutput.Writ_Price;
            cmd.Parameters.Add("@TCS_Forma", SqlDbType.VarChar).Value = li_BookPricingOutput.TCS_Forma;
            cmd.Parameters.Add("@FinalRe_Forma", SqlDbType.VarChar).Value = li_BookPricingOutput.FinalRe_Forma;
            cmd.Parameters.Add("@MRP_Forma", SqlDbType.VarChar).Value = li_BookPricingOutput.MRP_Forma; 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
