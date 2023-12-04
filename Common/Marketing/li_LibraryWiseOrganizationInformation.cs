using System;
using System.Data;
using System.Configuration;
using System.Linq;


    public class li_LibraryWiseOrganizationInformation
    {

        
        public li_LibraryWiseOrganizationInformation()
        {
        }



        public li_LibraryWiseOrganizationInformation
            (
            int ID,
            string LibraryID
            )
        {
            this.ID = ID;
            this.LibraryID = LibraryID;
            


        }
        

        private string _LibraryID;
        public string LibraryID
        {
            get { return _LibraryID; }
            set { _LibraryID = value; }
        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }

