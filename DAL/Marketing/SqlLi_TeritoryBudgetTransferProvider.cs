using Common.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Marketing
{
    public class SqlLi_TeritoryBudgetTransferProvider:DataAccessObject
    {
        public String InsertLi_TeritoryBudgetTransfer(li_TeritoryBudgetTransfer teritorybudget)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_li_Insert_TeritoryBudgetTransfer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RefNo", SqlDbType.Int).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = teritorybudget.RefNo;
                cmd.Parameters.Add("@DoDesId", SqlDbType.Int).Value = teritorybudget.DoDesId;
                cmd.Parameters.Add("@FromTeritoryID", SqlDbType.VarChar).Value = teritorybudget.FromTeritoryID;
                cmd.Parameters.Add("@ToTeritoryID", SqlDbType.VarChar).Value = teritorybudget.ToTeritoryID;
                cmd.Parameters.Add("@TransferAmount", SqlDbType.Decimal).Value = teritorybudget.TransferAmount;
                cmd.Parameters.Add("@TransferDate", SqlDbType.DateTime).Value = teritorybudget.TransferDate;
                cmd.Parameters.Add("@FromTeritoryBudget", SqlDbType.Decimal).Value = teritorybudget.FromTeritoryBudget;
                cmd.Parameters.Add("@ToTeritoryBudget", SqlDbType.Decimal).Value = teritorybudget.ToTeritoryBudget;
                cmd.Parameters.Add("@AgrYear", SqlDbType.VarChar).Value = teritorybudget.AgrYear;
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return cmd.Parameters["@RefNo"].Value.ToString();
            }
        }
        //public int InsertLi_DonLetterDetail(Li_DonLetter li_donletter)
        //{
        //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("SMPM_li_InsertDonationLetterDetail", connection);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add("@LetterNo", SqlDbType.VarChar).Value = li_donletter.LetterNo;
        //        cmd.Parameters.Add("@PSId", SqlDbType.Int).Value = li_donletter.PSId;
        //        cmd.Parameters.Add("@DonationAmnt", SqlDbType.Decimal).Value = li_donletter.DonationAmnt;
        //        cmd.Parameters.Add("@PrevPayment", SqlDbType.Decimal).Value = li_donletter.PrevPayment;
        //        cmd.Parameters.Add("@DueAmnt", SqlDbType.Decimal).Value = li_donletter.DueAmnt;
        //        cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_donletter.CreatedBy;
        //        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_donletter.CreatedDate;
        //        connection.Open();

        //        int result = cmd.ExecuteNonQuery();
        //        return result;
        //    }
        //}


        public DataSet Get_DonationTeritoryWiseBudget(string TeritoryId, int DoDesId, string AgrYear)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_li_Get_DonationTeritoryWiseBudget_ViewEdit", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@TeritoryID", SqlDbType.VarChar).Value = TeritoryId;
                command.Parameters.Add("@DoDesID", SqlDbType.Int).Value = DoDesId;
                command.Parameters.Add("@AgrYear", SqlDbType.VarChar).Value = AgrYear;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();

                return ds;
            }
        }

        public DataSet Get_DonationTeritoryWiseBudget_Paid(string TeritoryId, int DoDesId, string AgrYear)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_li_Get_DonationTeritoryWiseBudgetPaid_ViewEdit_R2", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@TeritoryID", SqlDbType.VarChar).Value = TeritoryId;
                command.Parameters.Add("@DoDesID", SqlDbType.Int).Value = DoDesId;
                command.Parameters.Add("@AgrYear", SqlDbType.VarChar).Value = AgrYear;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();

                return ds;
            }
        }



    }
}
