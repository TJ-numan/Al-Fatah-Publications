using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

public class SqlLi_MRSheetDetailProvider : DataAccessObject
{
    public SqlLi_MRSheetDetailProvider()
    {
    }


    public bool DeleteLi_MRSheetDetail(Li_MRSheetDetail li_MRSheetDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteLi_MRSheetDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MRDetId", SqlDbType.Int).Value = li_MRSheetDetail.MRDetId;
            cmd.Parameters.Add("@MRId", SqlDbType.Int).Value = li_MRSheetDetail.MRId;
            cmd.Parameters.Add("@DeletedBy", SqlDbType.Int).Value = li_MRSheetDetail.DeletedBy;
            cmd.Parameters.Add("@CauseOfDelete  ", SqlDbType. VarChar).Value = li_MRSheetDetail. CauseOfDelete;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool HeldUpLi_MRSheetDetail(Li_MRSheetDetail li_MRSheetDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HeldUpLi_MRSheetDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MRDetId", SqlDbType.Int).Value = li_MRSheetDetail.MRDetId;
            cmd.Parameters.Add("@MRId", SqlDbType.Int).Value = li_MRSheetDetail.MRId;  
            cmd.Parameters.Add("@CauseOfDelete", SqlDbType. VarChar).Value = li_MRSheetDetail. CauseOfDelete;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MRSheetDetail.ModifiedBy;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }    

    public List<Li_MRSheetDetail> GetAllLi_MRSheetDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("ACC_GetAllLi_MRSheetDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_MRSheetDetailsFromReader(reader);
        }
    }
    public List<Li_MRSheetDetail> GetLi_MRSheetDetailsFromReader(IDataReader reader)
    {
        List<Li_MRSheetDetail> li_MRSheetDetails = new List<Li_MRSheetDetail>();

        while (reader.Read())
        {
            li_MRSheetDetails.Add(GetLi_MRSheetDetailFromReader(reader));
        }
        return li_MRSheetDetails;
    }

    public Li_MRSheetDetail GetLi_MRSheetDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_MRSheetDetail li_MRSheetDetail = new Li_MRSheetDetail
                (

                    (int)reader["MRDetId"],
                    (int)reader["MRId"],
                    reader["Com"].ToString(),
                    reader["LibraryID"].ToString(),
                    (bool)reader["IsHeldUp"],
                    (int)reader["DepositForId"],
                    (DateTime)reader["CollectionDate"],
                    reader["AccountNo"].ToString(),
                    (int)reader["DepositType"],
                    reader["BankSlipNo"].ToString(),
                    reader["BankCode"].ToString(),
                    reader["BankAddress"].ToString(),
                    (decimal)reader["Amount"],
                    (bool)reader["IsDeleted"],
                    (int)reader["DeletedBy"],
                    reader["CauseOfDelete"].ToString(),
                    (DateTime)reader["DeleteDate"],
                    reader["Remark"].ToString(),
                    (int)reader["ModifiedBy"]
                );
            return li_MRSheetDetail;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_MRSheetDetail GetLi_MRSheetDetailByID(int li_MRSheetDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLi_MRSheetDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MRDetId", SqlDbType.Int).Value = li_MRSheetDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_MRSheetDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_MRSheetDetail(Li_MRSheetDetail li_MRSheetDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLi_MRSheetDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MRDetId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MRId", SqlDbType.Int).Value = li_MRSheetDetail.MRId;
            cmd.Parameters.Add("@Com", SqlDbType.VarChar).Value = li_MRSheetDetail.Com;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_MRSheetDetail.LibraryID;
            cmd.Parameters.Add("@IsHeldUp", SqlDbType.Bit).Value = li_MRSheetDetail.IsHeldUp;
            cmd.Parameters.Add("@DepositForId", SqlDbType.Int).Value = li_MRSheetDetail.DepositForId;
            cmd.Parameters.Add("@CollectionDate", SqlDbType.DateTime).Value = li_MRSheetDetail.CollectionDate;
            cmd.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = li_MRSheetDetail.AccountNo;
            cmd.Parameters.Add("@DepositType", SqlDbType.Int).Value = li_MRSheetDetail.DepositType;
            cmd.Parameters.Add("@BankSlipNo", SqlDbType.VarChar).Value = li_MRSheetDetail.BankSlipNo;
            cmd.Parameters.Add("@BankCode", SqlDbType.VarChar).Value = li_MRSheetDetail.BankCode;
            cmd.Parameters.Add("@BankAddress", SqlDbType.VarChar).Value = li_MRSheetDetail.BankAddress;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_MRSheetDetail.Amount;
            cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = li_MRSheetDetail.IsDeleted;
            cmd.Parameters.Add("@DeletedBy", SqlDbType.Int).Value = li_MRSheetDetail.DeletedBy;
            cmd.Parameters.Add("@CauseOfDelete", SqlDbType.VarChar).Value = li_MRSheetDetail.CauseOfDelete;
            cmd.Parameters.Add("@DeleteDate", SqlDbType.DateTime).Value = li_MRSheetDetail.DeleteDate;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_MRSheetDetail.Remark;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MRSheetDetail.ModifiedBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_MRSheetDetail(Li_MRSheetDetail li_MRSheetDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateLi_MRSheetDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MRDetId", SqlDbType.Int).Value = li_MRSheetDetail.MRDetId;
            cmd.Parameters.Add("@MRId", SqlDbType.Int).Value = li_MRSheetDetail.MRId;
            cmd.Parameters.Add("@Com", SqlDbType.VarChar).Value = li_MRSheetDetail.Com;
            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_MRSheetDetail.LibraryID;
            cmd.Parameters.Add("@IsHeldUp", SqlDbType.Bit).Value = li_MRSheetDetail.IsHeldUp;
            cmd.Parameters.Add("@DepositForId", SqlDbType.Int).Value = li_MRSheetDetail.DepositForId;
            cmd.Parameters.Add("@CollectionDate", SqlDbType.DateTime).Value = li_MRSheetDetail.CollectionDate;
            cmd.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = li_MRSheetDetail.AccountNo;
            cmd.Parameters.Add("@DepositType", SqlDbType.Int).Value = li_MRSheetDetail.DepositType;
            cmd.Parameters.Add("@BankSlipNo", SqlDbType.VarChar).Value = li_MRSheetDetail.BankSlipNo;
            cmd.Parameters.Add("@BankCode", SqlDbType.VarChar).Value = li_MRSheetDetail.BankCode;
            cmd.Parameters.Add("@BankAddress", SqlDbType.VarChar).Value = li_MRSheetDetail.BankAddress;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_MRSheetDetail.Amount;
            cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = li_MRSheetDetail.IsDeleted;
            cmd.Parameters.Add("@DeletedBy", SqlDbType.Int).Value = li_MRSheetDetail.DeletedBy;
            cmd.Parameters.Add("@CauseOfDelete", SqlDbType.VarChar).Value = li_MRSheetDetail.CauseOfDelete;
            cmd.Parameters.Add("@DeleteDate", SqlDbType.DateTime).Value = li_MRSheetDetail.DeleteDate;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_MRSheetDetail.Remark;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MRSheetDetail.ModifiedBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataTable Get_MRSheetDetails(int MRDetId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_getMRDetailsFromSheet", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MRDetId", SqlDbType.VarChar).Value = MRDetId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }

    }
}
