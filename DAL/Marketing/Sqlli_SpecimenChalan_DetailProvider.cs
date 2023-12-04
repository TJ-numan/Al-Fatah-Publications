using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using DAL;

public class SqlLi_SpecimenChalan_DetailProvider : DataAccessObject
{
    public SqlLi_SpecimenChalan_DetailProvider()
    {
    }


    public bool DeleteLi_SpecimenChalan_Detail(int li_SpecimenChalan_DetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_SpecimenChalan_Detail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_SpecimenChalan_DetailID", SqlDbType.Int).Value = li_SpecimenChalan_DetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_SpecimenChalan_Detail> GetAllLi_SpecimenChalan_Details()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_SpecimenChalan_Details", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SpecimenChalan_DetailsFromReader(reader);
        }
    }
    public List<Li_SpecimenChalan_Detail> GetLi_SpecimenChalan_DetailsFromReader(IDataReader reader)
    {
        List<Li_SpecimenChalan_Detail> li_SpecimenChalan_Details = new List<Li_SpecimenChalan_Detail>();

        while (reader.Read())
        {
            li_SpecimenChalan_Details.Add(GetLi_SpecimenChalan_DetailFromReader(reader));
        }
        return li_SpecimenChalan_Details;
    }

    public Li_SpecimenChalan_Detail GetLi_SpecimenChalan_DetailFromReader(IDataReader reader)
    {
        try
        {
            Li_SpecimenChalan_Detail li_SpecimenChalan_Detail = new Li_SpecimenChalan_Detail
                (

                    reader["ChallanDetailsID"].ToString(),
                    reader["ChallanID"].ToString(),
                    reader["BookAcCode"].ToString(),
                    (int)reader["Qty"],
                    (decimal)reader["UnitPrice"],
                    reader["Edition"].ToString()
                );
            return li_SpecimenChalan_Detail;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_SpecimenChalan_Detail GetLi_SpecimenChalan_DetailByID(int li_SpecimenChalan_DetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_SpecimenChalan_DetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_SpecimenChalan_DetailID", SqlDbType.Int).Value = li_SpecimenChalan_DetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SpecimenChalan_DetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_SpecimenChalan_Detail(Li_SpecimenChalan_Detail li_SpecimenChalan_Detail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_SpecimenChalan_Detail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChallanDetailsID", SqlDbType.VarChar).Value = li_SpecimenChalan_Detail.ChallanDetailsID;
            cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = li_SpecimenChalan_Detail.ChallanID;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_SpecimenChalan_Detail.BookAcCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_SpecimenChalan_Detail.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = li_SpecimenChalan_Detail.UnitPrice;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar ).Value = li_SpecimenChalan_Detail.Edition;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_SpecimenChalan_Detail(Li_SpecimenChalan_Detail li_SpecimenChalan_Detail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_SpecimenChalan_Detail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChallanDetailsID", SqlDbType.VarChar).Value = li_SpecimenChalan_Detail.ChallanDetailsID;
            cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = li_SpecimenChalan_Detail.ChallanID;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_SpecimenChalan_Detail.BookAcCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_SpecimenChalan_Detail.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = li_SpecimenChalan_Detail.UnitPrice;
            cmd.Parameters.Add("@Edition", SqlDbType.Money).Value = li_SpecimenChalan_Detail.Edition;

            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
