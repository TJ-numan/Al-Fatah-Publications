using System;
using System.Data;
using System.Configuration;
using System.Linq;



public class li_BookType
{
    public li_BookType()
    {
    }


    public li_BookType
        (
int  bookTypeID,
string  bookType

        )

    {
this.BookTypeID = bookTypeID;
this.BookType = bookType;

    }

    private int  _bookTypeID;
    public int  BookTypeID
    {
        get { return _bookTypeID; }
        set { _bookTypeID = value; }
    }

    private string  _bookType;
    public string  BookType
    {
        get { return _bookType; }
        set { _bookType = value; }
    }

}

