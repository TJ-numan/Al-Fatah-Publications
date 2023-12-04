using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;


    public class li_AssociateManager
    {

        public li_AssociateManager()
        { 
        
        }

        public static string InsertAssociate(li_LibraryWiseAssociate li_LibraryWiseAssociate)
        {
            li_associateProvider li_associateProvider = new li_associateProvider();

            return li_associateProvider.Insert_AssociateInformation(li_LibraryWiseAssociate); ;
        }

        public static DataSet GetALLLibraryWiseAssociateInformation(string LibraryID)
        {
            DataSet ds = new DataSet();
            li_associateProvider SearchAssociateInformation = new li_associateProvider();
            ds = SearchAssociateInformation.GetALLLibraryWiseAssociateInformation(LibraryID);
            return ds;
        }
        public static bool DeleteAssociateFromDatabase(string LibraryID, int serialAssociate)
        {
            li_associateProvider AssociateProvider = new li_associateProvider();
            return AssociateProvider.Delete_AssociateFromDatabase(LibraryID, serialAssociate);
        }



    }

