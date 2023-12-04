using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_SpecimenChalanProvider:DataAccessObject
{
	public SqlLi_SpecimenChalanProvider()
    {
    }


    public bool DeleteLi_SpecimenChalan(int li_SpecimenChalanID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_SpecimenChalan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_SpecimenChalanID", SqlDbType.Int).Value = li_SpecimenChalanID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_SpecimenChalan> GetAllLi_SpecimenChalans()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_SpecimenChalans", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SpecimenChalansFromReader(reader);
        }
    }
    public List<Li_SpecimenChalan> GetLi_SpecimenChalansFromReader(IDataReader reader)
    {
        List<Li_SpecimenChalan> li_SpecimenChalans = new List<Li_SpecimenChalan>();

        while (reader.Read())
        {
            li_SpecimenChalans.Add(GetLi_SpecimenChalanFromReader(reader));
        }
        return li_SpecimenChalans;
    }

    public Li_SpecimenChalan GetLi_SpecimenChalanFromReader(IDataReader reader)
    {
        try
        {
            Li_SpecimenChalan li_SpecimenChalan = new Li_SpecimenChalan
                (
                     
                    reader["ChallanID"].ToString(),
                    reader["MemoNo"].ToString(),
                    (decimal)reader["TotalAmount"],
                    (decimal)reader["AmountReceivable"],
                    reader["CreatedBy"].ToString(),
                    reader["DeliveredBy"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (DateTime)reader["DeliveryDate"],
                    
                     reader["TSO"].ToString(),
                    (int)reader["PacketNo"],
                    (decimal)reader["PerPacketCost"],                    
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"] ,
                    (bool )reader ["FreeChalan"],
                    (bool )reader ["Donation"]
                     
                );
             return li_SpecimenChalan;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_SpecimenChalan GetLi_SpecimenChalanByID(int li_SpecimenChalanID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_SpecimenChalanByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_SpecimenChalanID", SqlDbType.Int).Value = li_SpecimenChalanID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SpecimenChalanFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_SpecimenChalan(Li_SpecimenChalan li_SpecimenChalan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_SpecimenChalan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_SpecimenChalan.MemoNo;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_SpecimenChalan.TotalAmount;
            cmd.Parameters.Add("@AmountReceivable", SqlDbType.Decimal).Value = li_SpecimenChalan.AmountReceivable;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_SpecimenChalan.CreatedBy;
            cmd.Parameters.Add("@DeliveredBy", SqlDbType.VarChar).Value = li_SpecimenChalan. DeliveredAddress ;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SpecimenChalan.CreatedDate;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_SpecimenChalan.DeliveryDate;
            cmd.Parameters.Add("@TSO", SqlDbType.VarChar).Value = li_SpecimenChalan.TSO;
            cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_SpecimenChalan.PacketNo;
            cmd.Parameters.Add("@PerPacketCost", SqlDbType.Decimal).Value = li_SpecimenChalan.PerPacketCost;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_SpecimenChalan.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_SpecimenChalan.ModifiedDate;
            cmd.Parameters.Add("@FreeChalan", SqlDbType.Bit ).Value = li_SpecimenChalan.FreeChalan;
            cmd.Parameters.Add("@Donation", SqlDbType.Bit ).Value = li_SpecimenChalan. Donation;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ChallanID"].Value.ToString ();
        }
    }

    public bool UpdateLi_SpecimenChalan(Li_SpecimenChalan li_SpecimenChalan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_SpecimenChalan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = li_SpecimenChalan.ChallanID;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = li_SpecimenChalan.MemoNo;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_SpecimenChalan.TotalAmount;
            cmd.Parameters.Add("@AmountReceivable", SqlDbType.Decimal).Value = li_SpecimenChalan.AmountReceivable;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = li_SpecimenChalan.CreatedBy;
            cmd.Parameters.Add("@DeliveredBy", SqlDbType.VarChar).Value = li_SpecimenChalan. DeliveredAddress ;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SpecimenChalan.CreatedDate;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_SpecimenChalan.DeliveryDate;
            cmd.Parameters.Add("@TSO", SqlDbType.VarChar).Value = li_SpecimenChalan.TSO;
            cmd.Parameters.Add("@PacketNo", SqlDbType.Int).Value = li_SpecimenChalan.PacketNo;
            cmd.Parameters.Add("@PerPacketCost", SqlDbType.Decimal).Value = li_SpecimenChalan.PerPacketCost;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_SpecimenChalan.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_SpecimenChalan.ModifiedDate;
            cmd.Parameters.Add("@FreeChalan", SqlDbType.Bit).Value = li_SpecimenChalan.FreeChalan;
            cmd.Parameters.Add("@Donation", SqlDbType.Bit).Value = li_SpecimenChalan.Donation;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet GetSpecimenChallanInformationByMemoForEdit(string MemoNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {//SMPM_li_ChallanDetailsByChallanIDForEdit
            SqlCommand command = new SqlCommand("SMPM_li_SpecimenChallanByMemo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@memoNo", SqlDbType.VarChar).Value = MemoNo;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }

    public DataSet GetSpecimenChallanDetailsInformationByChallanIDForEdit(string ChallanID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_SpecimenChallanDetailsByChallanIDForEdit", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChllanID", SqlDbType.VarChar).Value = ChallanID;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }



    public DataSet Get_DailyPackingCost(string fromdate, string todate, string Name, string MemoNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_rptPrintPacketCostByDateForSpecimen", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromdate;
            command.Parameters.Add("@todate", SqlDbType.VarChar).Value = todate;
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            command.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = MemoNo;


            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }




    public DataSet Get_DailyPaidChalan(string fromdate, string todate, string Name, string MemoNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_rptPrintSpecimenPacketInPaid", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromdate;
            command.Parameters.Add("@todate", SqlDbType.VarChar).Value = todate;
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            command.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = MemoNo;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet getSpecimenForLetter(string TSOId, string FromDate, string ToDate)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetSpecimenForLetter", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = FromDate;
            command.Parameters.Add("@todate", SqlDbType.VarChar).Value = ToDate;
            command.Parameters.Add("@TSOID", SqlDbType.VarChar).Value = TSOId;
 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataTable  getSpecimenForXML(  string FromDate, string ToDate)
    {
        DataTable  dt = new  DataTable ();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("web_SMPM_li_rptSpecimanChallanByDateRange_XML", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = FromDate;
            command.Parameters.Add("@todate", SqlDbType.VarChar).Value = ToDate;
  

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();

            return dt;
        }
    }



}
