using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class li_BankProvider : DataAccessObject
    {

    public li_BankProvider()
    {

    }

    public string Insert_BankInformation(li_LibraryWiseBankInformation li_LibraryWiseBankInformation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_LibraryBankInformation", connection);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_LibraryWiseBankInformation.LibraryID;
            cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = li_LibraryWiseBankInformation.BankName;
            cmd.Parameters.Add("@BankBranch", SqlDbType.VarChar).Value = li_LibraryWiseBankInformation.BankBranch;
            cmd.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = li_LibraryWiseBankInformation.BankAccount;
            cmd.Parameters.Add("@BankType", SqlDbType.VarChar).Value = li_LibraryWiseBankInformation.BankType;

            connection.Open();

            cmd.ExecuteNonQuery();

            return null;
        }
    }

    public DataSet GetALLLibraryWiseBankInformation(string LibraryID)
    {

        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_AllLibraryWiseBankInformation", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@libraryID", SqlDbType.VarChar).Value = LibraryID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public bool Delete_BankFromDatabase(string LibraryID, int serialbnk)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_BankFromLibrary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@libraryID", SqlDbType.VarChar).Value = LibraryID;
            cmd.Parameters.Add("@Serialbnk", SqlDbType.Int).Value = serialbnk;
            connection.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
    }



  }

