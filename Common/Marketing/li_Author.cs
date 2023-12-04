using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

public class li_Author
{
    public li_Author()
    {
    }


    public li_Author
        (
int  authorID,
string  authorName,
string  authorPhone,
string  authorAddress

        )

    {
this.AuthorID = authorID;
this.AuthorName = authorName;
this.AuthorPhone = authorPhone;
this.AuthorAddress = authorAddress;

    }

    private int  _authorID;
    public int  AuthorID
    {
        get { return _authorID; }
        set { _authorID = value; }
    }

    private string  _authorName;
    public string  AuthorName
    {
        get { return _authorName; }
        set { _authorName = value; }
    }

    private string  _authorPhone;
    public string  AuthorPhone
    {
        get { return _authorPhone; }
        set { _authorPhone = value; }
    }

    private string  _authorAddress;
    public string  AuthorAddress
    {
        get { return _authorAddress; }
        set { _authorAddress = value; }
    }

}

