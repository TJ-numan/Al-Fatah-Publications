using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

public class SqlLi_MRSheetProvider : DataAccessObject
{
    public SqlLi_MRSheetProvider()
    {
    }


    public bool DeleteLi_MRSheet(int li_MRSheetID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Acc_DeleteLi_MRSheet", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_MRSheetID", SqlDbType.Int).Value = li_MRSheetID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_MRSheet> GetAllLi_MRSheets()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Acc_GetAllLi_MRSheets", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_MRSheetsFromReader(reader);
        }
    }
    public List<Li_MRSheet> GetLi_MRSheetsFromReader(IDataReader reader)
    {
        List<Li_MRSheet> li_MRSheets = new List<Li_MRSheet>();

        while (reader.Read())
        {
            li_MRSheets.Add(GetLi_MRSheetFromReader(reader));
        }
        return li_MRSheets;
    }

    public Li_MRSheet GetLi_MRSheetFromReader(IDataReader reader)
    {
        try
        {
            Li_MRSheet li_MRSheet = new Li_MRSheet
                (

                    (int)reader["MRId"],
                    (decimal)reader["TotalAmount"],
                    (bool)reader["IsSend"],
                    (bool)reader["IsReSend"],
                    (bool)reader["IsLocked"],
                    (int)reader["SenderId"],
                    (DateTime)reader["SendDate"],
                    (int)reader["ReSendId"],
                    (DateTime)reader["ReSendDate"],
                    (int)reader["LockedId"],
                    (DateTime)reader["LockedDate"],
                    (int)reader["CreateBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    reader["Remarks"].ToString(),
                   (DateTime)reader["MRDate"]
                );
            return li_MRSheet;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_MRSheet GetLi_MRSheetByID(int li_MRSheetID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLi_MRSheetByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MRDetId", SqlDbType.Int).Value = li_MRSheetID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            if (reader.Read())
            {
                return GetLi_MRSheetFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_MRSheet(Li_MRSheet li_MRSheet)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLi_MRSheet", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MRId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = li_MRSheet.TotalAmount;
            cmd.Parameters.Add("@IsSend", SqlDbType.Bit).Value = li_MRSheet.IsSend;
            cmd.Parameters.Add("@IsReSend", SqlDbType.Bit).Value = li_MRSheet.IsReSend;
            cmd.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = li_MRSheet.IsLocked;
            cmd.Parameters.Add("@SenderId", SqlDbType.Int).Value = li_MRSheet.SenderId;
            cmd.Parameters.Add("@SendDate", SqlDbType.DateTime).Value = li_MRSheet.SendDate;
            cmd.Parameters.Add("@ReSendId", SqlDbType.Int).Value = li_MRSheet.ReSendId;
            cmd.Parameters.Add("@ReSendDate", SqlDbType.DateTime).Value = li_MRSheet.ReSendDate;
            cmd.Parameters.Add("@LockedId", SqlDbType.Int).Value = li_MRSheet.LockedId;
            cmd.Parameters.Add("@LockedDate", SqlDbType.DateTime).Value = li_MRSheet.LockedDate;
            cmd.Parameters.Add("@CreateBy", SqlDbType.Int).Value = li_MRSheet.CreateBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MRSheet.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MRSheet.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_MRSheet.ModifiedDate;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = li_MRSheet.Remarks;
            cmd.Parameters.Add("@MRDate", SqlDbType.DateTime).Value = li_MRSheet.MRDate;
            cmd.Parameters.Add("@Region", SqlDbType.Int).Value = li_MRSheet.MRId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MRId"].Value;
        }
    }

    public bool UpdateLi_MRSheetSenderMkt(Li_MRSheet li_MRSheet)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateLi_MRSheetSenderMkt", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MRId", SqlDbType.Int).Value = li_MRSheet.MRId;
            cmd.Parameters.Add("@IsSend", SqlDbType.Bit).Value = li_MRSheet.IsSend;
            cmd.Parameters.Add("@SenderId", SqlDbType.Int).Value = li_MRSheet.SenderId;
            cmd.Parameters.Add("@SendDate", SqlDbType.DateTime).Value = li_MRSheet.SendDate;
            cmd.Parameters.Add("@MRDate", SqlDbType.DateTime).Value = li_MRSheet.MRDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public bool UpdateLi_MRSheetSenderAcc(Li_MRSheet li_MRSheet)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateLi_MRSheetSenderAcc", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MRId", SqlDbType.Int).Value = li_MRSheet.MRId;
            cmd.Parameters.Add("@IsReSend", SqlDbType.Bit).Value = li_MRSheet.  IsReSend;
            cmd.Parameters.Add("@ReSendId", SqlDbType.Int).Value = li_MRSheet.ReSendId;
            cmd.Parameters.Add("@ReSendDate", SqlDbType.DateTime).Value = li_MRSheet.ReSendDate;
       
            connection.Open();
 
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    public DataSet Get_DateWiseMRSheet(string fromDate, string toDate, bool heldUp)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_getDatewiseMRSheet", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = toDate;
            cmd.Parameters.Add("@IsHeldUp", SqlDbType.Bit).Value = heldUp ;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
    public DataTable Get_MRSheetNoWiseDetails(int MRId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_rptMRSheetStatement", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MRId", SqlDbType.VarChar).Value = MRId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }

    }
    public DataTable Get_MRSheetNoWiseDetailsForDoMR(int MRId, bool heldUp, int DepositForId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            //SqlCommand cmd = new SqlCommand("SMPM_li_rptMRSheetStatement", connection);
            SqlCommand cmd = new SqlCommand("SMPM_li_DoMRFromSheet", connection);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MRId", SqlDbType.VarChar).Value = MRId;
            cmd.Parameters.Add("@IsHeldUp", SqlDbType.Bit).Value = heldUp ;
            cmd.Parameters.Add("@DepositForId", SqlDbType. Int).Value =  DepositForId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }

    }
}
