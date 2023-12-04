using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Common.Marketing;

namespace DAL.Marketing
{
    public class Sqlli_DepositInformationProvider:DataAccessObject
    {

        public List<li_DepositInformation> GetDepositInformationByMRno(string memoNo)
        {
            List<li_DepositInformation> depositInformations = new List<li_DepositInformation>();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))          
            {
                SqlCommand command = new SqlCommand("GetDepositInformationByMRno", connection);
                command.CommandType= CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@MRno", memoNo);
                command.Parameters.Add(parameter);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    li_DepositInformation aDepositInformation = new li_DepositInformation();
                    aDepositInformation.MRDate = (DateTime) reader["MRDate"];
                    aDepositInformation.DepositedDate = (DateTime)reader["DepositedDate"];
                    aDepositInformation.ClearDate = (DateTime)reader["ClearDate"];
                    aDepositInformation.BankAddress = (string)reader["BankAddress"];
                    aDepositInformation.BankSlipNo = (string) reader["BankSlipNo"];
                   // aDepositInformation.BankName = (string) reader["BankName"];
                    aDepositInformation.BankCode = (string) reader["BankCode"];
                    aDepositInformation.AmountOfMoney = (decimal) reader["AmountOfMoney"];
                    aDepositInformation.Remark = (string) reader["Remark"];
                    aDepositInformation.VerifiedBy = (string)reader["VrifiedBy"];                  
                    //aDepositInformation.TranbType = (string) reader["TranbType"];
                    aDepositInformation.TrannID = (int)reader["DepositeTpe"];
                    aDepositInformation.DepositForID = (int)reader["DepositForId"];
                    //aDepositInformation.LibraryName = (string) reader["LibraryName"];
                    aDepositInformation.AssetId = (int)reader["AssetId"];
                    aDepositInformation.LibraryID = (string)reader["LibraryID"];
                    depositInformations.Add(aDepositInformation);
                }
            }
            return depositInformations;
        }
        public List<li_DepositInformation> GetDepositInformationByMRno_Q(string memoNo)
        {
            List<li_DepositInformation> depositInformations = new List<li_DepositInformation>();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetDepositInformationByMRno_Q", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@MRno", memoNo);
                command.Parameters.Add(parameter);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    li_DepositInformation aDepositInformation = new li_DepositInformation();
                    aDepositInformation.MRDate = (DateTime)reader["MRDate"];
                    aDepositInformation.DepositedDate = (DateTime)reader["DepositedDate"];
                    aDepositInformation.ClearDate = (DateTime)reader["ClearDate"];
                    aDepositInformation.BankAddress = (string)reader["BankAddress"];
                    aDepositInformation.BankSlipNo = (string)reader["BankSlipNo"];
                    //aDepositInformation.BankName = (string)reader["BankName"];
                    aDepositInformation.BankCode = (string)reader["BankCode"];
                    aDepositInformation.AmountOfMoney = (decimal)reader["AmountOfMoney"];
                    aDepositInformation.Remark = (string)reader["Remark"];
                    aDepositInformation.VerifiedBy = (string)reader["VrifiedBy"];
                    //aDepositInformation.TranbType = (string)reader["TranbType"];
                    aDepositInformation.TrannID = (int)reader["DepositeTpe"];
                    aDepositInformation.DepositForID = (int)reader["DepositForId"];
                    //aDepositInformation.LibraryName = (string)reader["LibraryName"];
                    aDepositInformation.LibraryID = (string)reader["LibraryID"];
                    depositInformations.Add(aDepositInformation);
                }
            }
            return depositInformations;
        }


    }
}
