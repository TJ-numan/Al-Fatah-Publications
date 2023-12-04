using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Author
{
    public Li_Author()
    {
    }

    public Li_Author
        (
       
        string authorID, 
        string  au_Name, 
        string au_Phone, 
        string au_Address, 
        bool isOut, 
        char status_D, 
        DateTime createdDate, 
        int createdBy  
         
        )
    {
         
        this.AuthorID = authorID;
        this.Au_Name = au_Name;
        this.Au_Phone = au_Phone;
        this.Au_Address = au_Address;
        this.IsOut = isOut;
        this.Status_D = status_D;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        
    }

 

    private string _authorID;
    public string AuthorID
    {
        get { return _authorID; }
        set { _authorID = value; }
    }

    private string  _au_Name;
    public string Au_Name
    {
        get { return _au_Name; }
        set { _au_Name = value; }
    }

    private string _au_Phone;
    public string Au_Phone
    {
        get { return _au_Phone; }
        set { _au_Phone = value; }
    }

    private string _au_Address;
    public string Au_Address
    {
        get { return _au_Address; }
        set { _au_Address = value; }
    }

    private bool _isOut;
    public bool IsOut
    {
        get { return _isOut; }
        set { _isOut = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }
 
}
