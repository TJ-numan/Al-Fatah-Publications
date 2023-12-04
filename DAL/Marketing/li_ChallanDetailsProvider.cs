using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class Sql_li_ChallanDetailsProvider:DataAccessObject
{
	public Sql_li_ChallanDetailsProvider()
    {
    }


    public List<li_ChallanDetails> GetAll_ChallanDetailss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ChallanDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_ChallanDetailssFromReader(reader);
        }
    }

    public DataSet   GetAll_ChallanDetailssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_ChallanDetailssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<li_ChallanDetails> Get_ChallanDetailssFromReader(IDataReader reader)
    {
        List<li_ChallanDetails> li_ChallanDetailss = new List<li_ChallanDetails>();

        while (reader.Read())
        {
            li_ChallanDetailss.Add(Get_ChallanDetailsFromReader(reader));
        }
        return li_ChallanDetailss;
    }

    public li_ChallanDetails Get_ChallanDetailsFromReader(IDataReader reader)
    {
        try
        {
            li_ChallanDetails li_ChallanDetails = new li_ChallanDetails
                (
                    reader["ChallanDetailsID"].ToString(),
                    reader["ChallanID"].ToString(),
                    reader["BookAcCode"].ToString(),
                    (int)reader["Qty"],
                    (decimal)reader["UnitPrice"],
                    (DateTime)reader["CreatedDate"],
                    (long)reader["OldStock"],
                    (decimal)reader["BonusPercentage"],
                    (int)reader["Specimen"],
                    (bool)reader["Boishaki"],
                    (bool)reader["DakhilBonus"],
                    (bool)reader["AlimBonus"],
                    (bool)reader["AlimSpecial"],
                     reader["Edition"].ToString() 
                );
             return li_ChallanDetails;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public li_ChallanDetails Get_ChallanDetailsByChallanDetailsID(int  challanDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_ChallanDetailsByChallanDetailsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChallanDetailsID", SqlDbType.Int).Value = challanDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_ChallanDetailsFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public void Insert_ChallanDetails(li_ChallanDetails li_ChallanDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_ChallanDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@ChallanDetailsID", SqlDbType.VarChar).Value = Guid .NewGuid ().ToString();//.Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = li_ChallanDetails.ChallanID;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_ChallanDetails.BookAcCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_ChallanDetails.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = li_ChallanDetails.UnitPrice;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ChallanDetails.CreatedDate;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_ChallanDetails.Edition ;
    
            cmd.Parameters.Add("@BonusPercentage", SqlDbType.Money).Value = li_ChallanDetails.BonusPercentage;
            cmd.Parameters.Add("@Specimen", SqlDbType.Int).Value = li_ChallanDetails.Specimen;
            cmd.Parameters.Add("@Boishaki", SqlDbType.Bit).Value = li_ChallanDetails.Boishaki;
            cmd.Parameters.Add("@DakhilBonus", SqlDbType.Bit).Value = li_ChallanDetails.DakhilBonus;
            cmd.Parameters.Add("@AlimBonus", SqlDbType.Bit).Value = li_ChallanDetails.AlimBonus;
            cmd.Parameters.Add("@AlimSpecial", SqlDbType.Bit).Value = li_ChallanDetails.AlimSpecial;
         
            connection.Open();

            cmd.ExecuteNonQuery();
        
        }
    }


    public void Insert_ChallanDetails_Qawmi(li_ChallanDetails li_ChallanDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_ChallanDetails_Qawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ChallanDetailsID", SqlDbType.VarChar).Value = Guid.NewGuid().ToString();//.Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = li_ChallanDetails.ChallanID;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_ChallanDetails.BookAcCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_ChallanDetails.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = li_ChallanDetails.UnitPrice;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ChallanDetails.CreatedDate;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_ChallanDetails.Edition;

            cmd.Parameters.Add("@BonusPercentage", SqlDbType.Money).Value = li_ChallanDetails.BonusPercentage;
            cmd.Parameters.Add("@Specimen", SqlDbType.Int).Value = li_ChallanDetails.Specimen;
            cmd.Parameters.Add("@Boishaki", SqlDbType.Bit).Value = li_ChallanDetails.Boishaki;
            cmd.Parameters.Add("@DakhilBonus", SqlDbType.Bit).Value = li_ChallanDetails.DakhilBonus;
            cmd.Parameters.Add("@AlimBonus", SqlDbType.Bit).Value = li_ChallanDetails.AlimBonus;
            cmd.Parameters.Add("@AlimSpecial", SqlDbType.Bit).Value = li_ChallanDetails.AlimSpecial;

            connection.Open();

            cmd.ExecuteNonQuery();

        }
    }

    public void  Update_ChallanDetails(li_ChallanDetails li_ChallanDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_ChallanDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ChallanDetailsID", SqlDbType.VarChar).Value = Guid.NewGuid().ToString();//.Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = li_ChallanDetails.ChallanID;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_ChallanDetails.BookAcCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_ChallanDetails.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = li_ChallanDetails.UnitPrice;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ChallanDetails.CreatedDate;
          //  cmd.Parameters.Add("@OldStock", SqlDbType.BigInt).Value = li_ChallanDetails.OldStock;
            cmd.Parameters.Add("@BonusPercentage", SqlDbType.Money).Value = li_ChallanDetails.BonusPercentage;
            cmd.Parameters.Add("@Specimen", SqlDbType.Int).Value = li_ChallanDetails.Specimen;
            cmd.Parameters.Add("@Boishaki", SqlDbType.Bit).Value = li_ChallanDetails.Boishaki;
            cmd.Parameters.Add("@DakhilBonus", SqlDbType.Bit).Value = li_ChallanDetails.DakhilBonus;
            cmd.Parameters.Add("@AlimBonus", SqlDbType.Bit).Value = li_ChallanDetails.AlimBonus;
            cmd.Parameters.Add("@AlimSpecial", SqlDbType.Bit).Value = li_ChallanDetails.AlimSpecial;
         
            connection.Open();

            cmd.ExecuteNonQuery();

        }

    }

    public bool Delete_ChallanDetails(string  challanDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_Challan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = challanDetailsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

