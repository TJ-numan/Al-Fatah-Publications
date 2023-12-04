using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Script_Chapter
{
    public Li_Script_Chapter()
    {
    }

    public Li_Script_Chapter
        (
        int serialNo,
        string bookCode, 
        string edition, 
        decimal unit_No, 
        string unit_Heading, 
        string auth_ID, 
        bool inHouse, 
        DateTime lastDate, 
        DateTime createdDate, 
        int createdBy, 
        char status_D 
        )
    {
        this.SerialNo = serialNo;
        this.BookCode = bookCode;
        this.Edition = edition;
        this.Unit_No = unit_No;
        this.Unit_Heading = unit_Heading;
        this.Auth_ID = auth_ID;
        this.InHouse = inHouse;
        this.LastDate = lastDate;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.Status_D = status_D;
         
    }


    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

 
 

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _edition;
    public string Edition
    {
        get { return _edition; }
        set { _edition = value; }
    }

    private decimal _unit_No;
    public decimal Unit_No
    {
        get { return _unit_No; }
        set { _unit_No = value; }
    }

    private string _unit_Heading;
    public string Unit_Heading
    {
        get { return _unit_Heading; }
        set { _unit_Heading = value; }
    }

    private string _auth_ID;
    public string Auth_ID
    {
        get { return _auth_ID; }
        set { _auth_ID = value; }
    }

    private bool _inHouse;
    public bool InHouse
    {
        get { return _inHouse; }
        set { _inHouse = value; }
    }

    private DateTime _lastDate;
    public DateTime LastDate
    {
        get { return _lastDate; }
        set { _lastDate = value; }
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

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }
     
}
