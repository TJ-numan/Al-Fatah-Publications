using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
public class SqlLi_TargetDetailsProvider : DataAccessObject
{

    public SqlLi_TargetDetailsProvider()
    {
    }


    public bool DeleteLi_TargetDetail(int li_TargetDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteLi_TargetDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_TargetDetailID", SqlDbType.Int).Value = li_TargetDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TargetDetails> GetAllLi_TargetDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLi_TargetDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TargetDetailsFromReader(reader);
        }
    }
    public List<Li_TargetDetails> GetLi_TargetDetailsFromReader(IDataReader reader)
    {
        List<Li_TargetDetails> li_TargetDetails = new List<Li_TargetDetails>();

        while (reader.Read())
        {
            li_TargetDetails.Add(GetLi_TargetDetailFromReader(reader));
        }
        return li_TargetDetails;
    }

    public Li_TargetDetails GetLi_TargetDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_TargetDetails li_TargetDetails = new Li_TargetDetails
                (

                    (int)reader["TerID"],
                    (string)reader["TerCode"],
                    (string)reader["TSOEmpCode"],
                    (DateTime)reader["StartDate"],
                    (DateTime)reader["EndDate"],
                    (decimal)reader["SalesTar"],
                    (decimal)reader["CollecTar"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (char)reader["Status_D"],
                    (int)reader["CompanyId"]

                );
            return li_TargetDetails;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_TargetDetails GetLi_TargetDetailByID(int li_TargetDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLi_TargetDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_TargetDetailID", SqlDbType.Int).Value = li_TargetDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TargetDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_TargetDetail(Li_TargetDetails li_TargetDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_TargetDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@TergID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TerCode", SqlDbType.VarChar).Value = li_TargetDetails.TerCode;
            cmd.Parameters.Add("@TSOEmpCode", SqlDbType.VarChar).Value = li_TargetDetails.TSOEmpCode;
            cmd.Parameters.Add("@SalesTar", SqlDbType.Decimal).Value = li_TargetDetails.SalesTar;
            cmd.Parameters.Add("@CollecTar", SqlDbType.Decimal).Value = li_TargetDetails.CollecTar;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = li_TargetDetails.StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = li_TargetDetails.EndDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TargetDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TargetDetails.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_TargetDetails.Status_D;
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = li_TargetDetails.CompanyId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@TergID"].Value;
        }
    }

    public bool UpdateLi_TargetDetail(Li_TargetDetails li_TargetDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateLi_TargetDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@TergID", SqlDbType.Int).Value = li_TargetDetail.TergID;
            cmd.Parameters.Add("@TerCode", SqlDbType.VarChar).Value = li_TargetDetail.TerCode;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = li_TargetDetail.StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = li_TargetDetail.EndDate;
            cmd.Parameters.Add("@SalesTar", SqlDbType.Decimal).Value = li_TargetDetail.SalesTar;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_TargetDetail.Status_D;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public int InsertLi_SOTargetDetail(Li_TargetDetails li_TargetDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLi_SOTargetDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TerCode", SqlDbType.VarChar).Value = li_TargetDetails.TerCode;
            cmd.Parameters.Add("@SalesTar", SqlDbType.Decimal).Value = li_TargetDetails.SalesTar;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = li_TargetDetails.StartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = li_TargetDetails.EndDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TargetDetails.CreatedBy;
            cmd.Parameters.Add("@IsCanceled", SqlDbType.Bit).Value = li_TargetDetails.Status_D;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TargetDetails.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
}
