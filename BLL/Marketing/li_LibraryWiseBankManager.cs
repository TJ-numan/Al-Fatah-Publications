using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;


    public class li_LibraryWiseBankManager
    {

        public li_LibraryWiseBankManager()
        {

        }


        public static string InsertBank(li_LibraryWiseBankInformation li_LibraryWiseBankInformation)
        {
            li_BankProvider li_BankProvider = new li_BankProvider();

            return li_BankProvider.Insert_BankInformation(li_LibraryWiseBankInformation); ;
        }
        public static DataSet GetALLLibraryWiseBankInformation( string LibraryID)
        {
            DataSet ds = new DataSet();
            li_BankProvider SearchBankInformation = new li_BankProvider();
            ds = SearchBankInformation.GetALLLibraryWiseBankInformation(LibraryID);
            return ds;
        }


        public static bool DeleteBankFromDatabase(string LibraryID,int serialbnk)
        {
            li_BankProvider bankProvider = new li_BankProvider();
            return bankProvider.Delete_BankFromDatabase(LibraryID, serialbnk);
        }



    }

