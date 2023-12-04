using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_DepositProvider:DataAccessObject
{
	public SqlLi_DepositProvider()
    {
    }


    public bool DeleteLi_Deposite(String  Invoice, string MemoNo, int userid)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_DeleteDeposite", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Invoice", SqlDbType.VarChar).Value = Invoice;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = MemoNo;
            cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userid;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Deposit> GetAllLi_Deposits()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Deposits", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DepositsFromReader(reader);
        }
    }
    public List<Li_Deposit> GetLi_DepositsFromReader(IDataReader reader)
    {
        List<Li_Deposit> li_Deposits = new List<Li_Deposit>();

        while (reader.Read())
        {
            li_Deposits.Add(GetLi_DepositFromReader(reader));
        }
        return li_Deposits;
    }

    public Li_Deposit GetLi_DepositFromReader(IDataReader reader)
    {
        try
        {
            Li_Deposit li_Deposit = new Li_Deposit
                (
                     
                    reader["InvoiceNo"].ToString(),
                    reader["MRno"].ToString(),
                    reader["LibraryID"].ToString(),
                    (decimal)reader["AmountOfMoney"],
                    (DateTime)reader["DepositedDate"],
                    (DateTime)reader["ClearDate"],
                    (DateTime)reader["MRDate"],
                    reader["BankCode"].ToString(),
                    reader["BankAddress"].ToString(),
                    reader["BankSlipNo"].ToString(),
                    (int)reader["DepositeTpe"],
                    (int)reader["CreatedBy"],
                    reader["VrifiedBy"].ToString(),
                    reader["Remark"].ToString(),
                    (bool)reader["Boishaki"],
                    (bool)reader["Alim"],
                    (char)reader["Status_D"],
                    (int)reader["Dele_By"],
                    (DateTime)reader["Deledate"],
                    reader["CauseOfDelete"].ToString() ,
                    (bool)reader["Dam_BookSale"],
                    (bool)reader["HouseRent"],
                    (bool)reader["Dam_Other"],
                    (bool)reader["Others"] ,
                    reader ["Comp"].ToString (),
                    (int)reader["DepositForId"],
                    (int )reader ["AssetList"]
                );
             return li_Deposit;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Deposit GetLi_DepositByID(int li_DepositID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_DepositByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_DepositID", SqlDbType.Int).Value = li_DepositID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DepositFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_Deposit(Li_Deposit li_Deposit)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Deposit", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
             
            cmd.Parameters.Add("@MRno", SqlDbType.VarChar,50). Direction = ParameterDirection .Output ;
            cmd.Parameters.Add("@LibraryID", SqlDbType. VarChar).Value = li_Deposit.LibraryID;
            cmd.Parameters.Add("@AmountOfMoney", SqlDbType.Decimal).Value = li_Deposit.AmountOfMoney;
            cmd.Parameters.Add("@DepositedDate", SqlDbType.DateTime).Value = li_Deposit.DepositedDate;
            cmd.Parameters.Add("@ClearDate", SqlDbType.DateTime).Value = li_Deposit.ClearDate;
            cmd.Parameters.Add("@MRDate", SqlDbType.DateTime).Value = li_Deposit.MRDate;
            cmd.Parameters.Add("@BankCode", SqlDbType.VarChar).Value = li_Deposit.BankCode;
            cmd.Parameters.Add("@BankAddress", SqlDbType.VarChar).Value = li_Deposit.BankAddress;
            cmd.Parameters.Add("@BankSlipNo", SqlDbType.VarChar).Value = li_Deposit.BankSlipNo;
            cmd.Parameters.Add("@DepositeTpe", SqlDbType.Int).Value = li_Deposit.DepositeTpe;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Deposit.CreatedBy;
            cmd.Parameters.Add("@VrifiedBy", SqlDbType.VarChar).Value = li_Deposit.VrifiedBy;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_Deposit.Remark;
            cmd.Parameters.Add("@Boishaki", SqlDbType.Bit).Value = li_Deposit.Boishaki;
            cmd.Parameters.Add("@Alim", SqlDbType.Bit).Value = li_Deposit.Alim;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Deposit.Status_D;
            cmd.Parameters.Add("@Dele_By", SqlDbType.Int).Value = li_Deposit.Dele_By;
            cmd.Parameters.Add("@Deledate", SqlDbType.DateTime).Value = li_Deposit.Deledate;
            cmd.Parameters.Add("@CauseOfDelete", SqlDbType.VarChar).Value = li_Deposit.CauseOfDelete;
            cmd.Parameters.Add("@Dam_BookSale", SqlDbType.Bit).Value = li_Deposit.Dam_BookSale;
            cmd.Parameters.Add("@HouseRent", SqlDbType.Bit).Value = li_Deposit.HouseRent;
            cmd.Parameters.Add("@Dam_Other", SqlDbType.Bit).Value = li_Deposit.Dam_Other;
            cmd.Parameters.Add("@Others", SqlDbType.Bit).Value = li_Deposit.Others;
            cmd.Parameters.Add("@Comp", SqlDbType.VarChar).Value = li_Deposit.Comp;
            cmd.Parameters.Add("@DepositForId", SqlDbType.Int).Value = li_Deposit.DepositForId;
            cmd.Parameters.Add("@AssetId", SqlDbType.Int).Value = li_Deposit.AssetList;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@MRno"].Value.ToString();
        }
    }



    public string InsertLi_DepositByTSO(Li_Deposit li_Deposit)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_DepositByTSO", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar,50).Direction = ParameterDirection .Output ;
            cmd.Parameters.Add("@MRno", SqlDbType.VarChar).Value = DBNull .Value ;
            cmd.Parameters.Add("@TSOID", SqlDbType.VarChar).Value = li_Deposit.LibraryID;
            cmd.Parameters.Add("@AmountOfMoney", SqlDbType.Decimal).Value = li_Deposit.AmountOfMoney;
            cmd.Parameters.Add("@DepositedDate", SqlDbType.DateTime).Value = li_Deposit.DepositedDate;
            cmd.Parameters.Add("@ClearDate", SqlDbType.DateTime).Value = li_Deposit.ClearDate;
            cmd.Parameters.Add("@MRDate", SqlDbType.DateTime).Value = li_Deposit.MRDate;
            cmd.Parameters.Add("@BankCode", SqlDbType.VarChar).Value = li_Deposit.BankCode;
            cmd.Parameters.Add("@BankAddress", SqlDbType.VarChar).Value = li_Deposit.BankAddress;
            cmd.Parameters.Add("@BankSlipNo", SqlDbType.VarChar).Value = li_Deposit.BankSlipNo;
            cmd.Parameters.Add("@DepositeTpe", SqlDbType.Int).Value = li_Deposit.DepositeTpe;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Deposit.CreatedBy;
            cmd.Parameters.Add("@VrifiedBy", SqlDbType.VarChar).Value = li_Deposit.VrifiedBy;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_Deposit.Remark;
            cmd.Parameters.Add("@Boishaki", SqlDbType.Bit).Value = li_Deposit.Boishaki;
            cmd.Parameters.Add("@Alim", SqlDbType.Bit).Value = li_Deposit.Alim;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Deposit.Status_D;
            cmd.Parameters.Add("@Dele_By", SqlDbType.Int).Value = li_Deposit.Dele_By;
            cmd.Parameters.Add("@Deledate", SqlDbType.DateTime).Value = li_Deposit.Deledate;
            cmd.Parameters.Add("@CauseOfDelete", SqlDbType.VarChar).Value = li_Deposit.CauseOfDelete;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@InvoiceNo"].Value.ToString ();
        }
    }
    public bool UpdateLi_Deposit(Li_Deposit li_Deposit)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_Deposit", connection);
            cmd.CommandType = CommandType.StoredProcedure;


         
            cmd.Parameters.Add("@MRno", SqlDbType.VarChar).Value = li_Deposit.MRno;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Deposit.LibraryID;
            cmd.Parameters.Add("@AmountOfMoney", SqlDbType.Decimal).Value = li_Deposit.AmountOfMoney;
            cmd.Parameters.Add("@DepositedDate", SqlDbType.DateTime).Value = li_Deposit.DepositedDate;
            cmd.Parameters.Add("@ClearDate", SqlDbType.DateTime).Value = li_Deposit.ClearDate;
            cmd.Parameters.Add("@MRDate", SqlDbType.DateTime).Value = li_Deposit.MRDate;
            cmd.Parameters.Add("@BankCode", SqlDbType.VarChar).Value = li_Deposit.BankCode;
            cmd.Parameters.Add("@BankAddress", SqlDbType.VarChar).Value = li_Deposit.BankAddress;
            cmd.Parameters.Add("@BankSlipNo", SqlDbType.VarChar).Value = li_Deposit.BankSlipNo;
            cmd.Parameters.Add("@DepositeTpe", SqlDbType.Int).Value = li_Deposit.DepositeTpe;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Deposit.CreatedBy;
            cmd.Parameters.Add("@VrifiedBy", SqlDbType.VarChar).Value = li_Deposit.VrifiedBy;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_Deposit.Remark;
            cmd.Parameters.Add("@Boishaki", SqlDbType.Bit).Value = li_Deposit.Boishaki;
            cmd.Parameters.Add("@Alim", SqlDbType.Bit).Value = li_Deposit.Alim;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Deposit.Status_D;
            cmd.Parameters.Add("@Dele_By", SqlDbType.Int).Value = li_Deposit.Dele_By;
            cmd.Parameters.Add("@Deledate", SqlDbType.DateTime).Value = li_Deposit.Deledate;
            cmd.Parameters.Add("@CauseOfDelete", SqlDbType.VarChar).Value = li_Deposit.CauseOfDelete;
            cmd.Parameters.Add("@Dam_BookSale", SqlDbType.Bit).Value = li_Deposit.Dam_BookSale;
            cmd.Parameters.Add("@HouseRent", SqlDbType.Bit).Value = li_Deposit.HouseRent;
            cmd.Parameters.Add("@Dam_Other", SqlDbType.Bit).Value = li_Deposit.Dam_Other;
            cmd.Parameters.Add("@Others", SqlDbType.Bit).Value = li_Deposit.Others;
            cmd.Parameters.Add("@Comp", SqlDbType.VarChar).Value = li_Deposit.Comp;
            cmd.Parameters.Add("@DepositForId", SqlDbType.Int).Value = li_Deposit.DepositForId;
            cmd.Parameters.Add("@AssetList", SqlDbType.Int).Value = li_Deposit.AssetList;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }



    

    public DataSet Get_DepositeByID(string MRNo , string com)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllDepositeInfoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MRNo", SqlDbType.VarChar).Value =  MRNo;
            command.Parameters.Add("@Comp", SqlDbType.VarChar).Value = com;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose ();
            connection.Close();

            return ds;
        }
    }

    public DataSet Get_DepositeByMemo(string MemoNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllDepositeInfoByMemoNo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = MemoNo;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataSet Get_DepositeInvoiceByMemo(string MemoNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDepositeInvoce", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = MemoNo;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    //---------------------Rezaul Hossain--------------------------
    public bool DeleteLi_Deposit(String MRNo, int userid, string del_cause, string Comp)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_DeleteDepositNew", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemoNo", SqlDbType.VarChar).Value = MRNo;
            cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userid;
            cmd.Parameters.Add("@del_cause", SqlDbType.VarChar).Value = del_cause;
            cmd.Parameters.Add("@Comp", SqlDbType.VarChar).Value = Comp;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
    //-------------------------Just for Deposit SpBonus -2021--------------------------------
    public DataTable Get_DepositSpBonusInformation(string FromDate, string ToDate, int RegionID, int DivisionID, string TerritoryID, string Com)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_Li_rptSpecialDepositByLibrary_ForGridviw", connection);
            
            ////For gold bonus 2021-2022 Start
            //SqlCommand cmd = new SqlCommand("Web_SMPM_Li_rptGoldDepositByLibraryForGridview", connection);
            ////For gold bonus 2021-2022 End

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = ToDate;
            cmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = RegionID;
            cmd.Parameters.Add("@DivisionID", SqlDbType.Int).Value = DivisionID;
            cmd.Parameters.Add("@TeritoryID", SqlDbType.VarChar).Value = TerritoryID;
            cmd.Parameters.Add("@Com", SqlDbType.VarChar).Value = Com;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }

    }
    public string InsertLi_DepositSPBonus(Li_Deposit li_Deposit)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_DepositSPBonus", connection);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@MRno", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Deposit.LibraryID;
            cmd.Parameters.Add("@AmountOfMoney", SqlDbType.Decimal).Value = li_Deposit.AmountOfMoney;
            cmd.Parameters.Add("@DepositedDate", SqlDbType.DateTime).Value = li_Deposit.DepositedDate;
            cmd.Parameters.Add("@ClearDate", SqlDbType.DateTime).Value = li_Deposit.ClearDate;
            cmd.Parameters.Add("@MRDate", SqlDbType.DateTime).Value = li_Deposit.MRDate;
            cmd.Parameters.Add("@BankCode", SqlDbType.VarChar).Value = li_Deposit.BankCode;
            cmd.Parameters.Add("@BankAddress", SqlDbType.VarChar).Value = li_Deposit.BankAddress;
            cmd.Parameters.Add("@BankSlipNo", SqlDbType.VarChar).Value = li_Deposit.BankSlipNo;
            cmd.Parameters.Add("@DepositeTpe", SqlDbType.Int).Value = li_Deposit.DepositeTpe;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Deposit.CreatedBy;
            cmd.Parameters.Add("@VrifiedBy", SqlDbType.VarChar).Value = li_Deposit.VrifiedBy;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_Deposit.Remark;
            cmd.Parameters.Add("@Boishaki", SqlDbType.Bit).Value = li_Deposit.Boishaki;
            cmd.Parameters.Add("@Alim", SqlDbType.Bit).Value = li_Deposit.Alim;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Deposit.Status_D;
            cmd.Parameters.Add("@Dele_By", SqlDbType.Int).Value = li_Deposit.Dele_By;
            cmd.Parameters.Add("@Deledate", SqlDbType.DateTime).Value = li_Deposit.Deledate;
            cmd.Parameters.Add("@CauseOfDelete", SqlDbType.VarChar).Value = li_Deposit.CauseOfDelete;
            cmd.Parameters.Add("@Dam_BookSale", SqlDbType.Bit).Value = li_Deposit.Dam_BookSale;
            cmd.Parameters.Add("@HouseRent", SqlDbType.Bit).Value = li_Deposit.HouseRent;
            cmd.Parameters.Add("@Dam_Other", SqlDbType.Bit).Value = li_Deposit.Dam_Other;
            cmd.Parameters.Add("@Others", SqlDbType.Bit).Value = li_Deposit.Others;
            cmd.Parameters.Add("@Comp", SqlDbType.VarChar).Value = li_Deposit.Comp;
            cmd.Parameters.Add("@DepositForId", SqlDbType.Int).Value = li_Deposit.DepositForId;
            cmd.Parameters.Add("@AssetId", SqlDbType.Int).Value = li_Deposit.AssetList;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@MRno"].Value.ToString();
        }
    }
}
