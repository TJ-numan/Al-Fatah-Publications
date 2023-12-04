using System;
using System.Data;
using System.Configuration;
using System.Linq;


 public class li_LibraryWiseBankInformation
    {

     public li_LibraryWiseBankInformation()
     {

     }
     public li_LibraryWiseBankInformation(string BankName, string BankBranch, string BankAccount, string BankType, string LibraryID)
     {
         this.BankName = BankName;
         this.BankBranch = BankBranch;
         this.BankAccount = BankAccount;
         this.BankType = BankType;
         this.LibraryID = LibraryID;

     }

     private string _BankName;
     public string BankName
     {
         get { return _BankName; }
         set { _BankName = value; }
     }

     private string _BankBranch;
     public string BankBranch
     {
         get { return _BankBranch; }
         set { _BankBranch = value; }
     }
     private string _BankAccount;
     public string BankAccount
     {
         get { return _BankAccount; }
         set { _BankAccount = value; }
     }
     private string _BankType;
     public string BankType
     {
         get { return _BankType; }
         set { _BankType = value; }
     }


     private string _LibraryID;
     public string LibraryID
     {
         get { return _LibraryID; }
         set { _LibraryID = value; }
     }


    }

