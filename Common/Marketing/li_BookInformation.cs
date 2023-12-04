using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_BookInformation
{
    public li_BookInformation()
    {
    }


  
   public li_BookInformation
      (
        string bookID,
        string bookName 

      )
    {
        this.BookID = bookID;
        this.BookName = bookName; 

    }
     
    public li_BookInformation
        (
            string  bookID,
            string  bookName,

            int  classID,

            int  createdBy,
            DateTime  createdDate,
            int   modifiedBy,
            DateTime  modifiedDate,


            int bookType,
            char bookgroup,
            string b_Name,
            int bookSession


        )

    {
            this.BookID = bookID;
            this.BookName = bookName;            
            this.ClassID = classID;             
            this.CreatedBy = createdBy;
            this.CreatedDate = createdDate;
            this.ModifiedBy = modifiedBy;
            this.ModifiedDate = modifiedDate;             
            this.BookType = bookType;
            this.BookGroup = bookgroup;
            this.B_Name = b_Name;
            this.Book_Session = bookSession;
    }

    public int Book_Session { get; set; }

    public string B_Name { get; set; }


    public char BookGroup { get; set; }

    private string  _bookID;
    public string  BookID
    {
        get { return _bookID; }
        set { _bookID = value; }
    }

    private string  _bookName;
    public string  BookName
    {
        get { return _bookName; }
        set { _bookName = value; }
    }
 
    private int  _classID;
    public int  ClassID
    {
        get { return _classID; }
        set { _classID = value; }
    }

   
    private int  _createdBy;
    public int  CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private DateTime  _createdDate;
    public DateTime  CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int  _modifiedBy;
    public int  ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime   _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    
    private int _bookType;

    public int BookType
    {
        get { return _bookType ;}
        set { _bookType =value ;}
    }
   
}

