using System;
using System.Data;
using System.Configuration;
using System.Linq;


   public class  li_LibraryWiseAssociate
    {
       public li_LibraryWiseAssociate()
       {

       }

       public li_LibraryWiseAssociate(string NameAssociate, string ResponsiblityAssociate, string PhoneAssociate, string LibraryID)
       {
           this.PhoneAssociate = PhoneAssociate;
           this.ResponsiblityAssociate = ResponsiblityAssociate;
           this.NameAssociate = NameAssociate;
           this.LibraryID = LibraryID;

       }

       private string _PhoneAssociate;
       public string PhoneAssociate
       {
           get { return _PhoneAssociate; }
           set { _PhoneAssociate = value; }
       }
        private string _LibraryID;
       public string LibraryID
       {
           get { return _LibraryID; }
           set { _LibraryID = value; }
       }
       private string _ResponsiblityAssociate;
       public string ResponsiblityAssociate
       {
           get { return _ResponsiblityAssociate; }
           set { _ResponsiblityAssociate = value; }
       }
       private string _NameAssociate;
       public string NameAssociate
       {
           get { return _NameAssociate; }
           set { _NameAssociate = value; }
       }
    }

