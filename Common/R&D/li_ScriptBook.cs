using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_ScriptBook
{
    public Li_ScriptBook()
    {
    }

    public Li_ScriptBook
        (
        
        string bookCode, 
        string edition, 
        decimal app_Forma, 
        decimal tot_Unit, 
        string sizeID, 
        DateTime pos_Date, 
        DateTime createdDate, 
        int createdBy, 
        char status_D 
         
        )
    {
   
        this.BookCode = bookCode;
        this.Edition = edition;
        this.App_Forma = app_Forma;
        this.Tot_Unit = tot_Unit;
        this.SizeID = sizeID;
        this.Pos_Date = pos_Date;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.Status_D = status_D;
    
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

    private decimal _app_Forma;
    public decimal App_Forma
    {
        get { return _app_Forma; }
        set { _app_Forma = value; }
    }

    private decimal _tot_Unit;
    public decimal Tot_Unit
    {
        get { return _tot_Unit; }
        set { _tot_Unit = value; }
    }

    private string _sizeID;
    public string SizeID
    {
        get { return _sizeID; }
        set { _sizeID = value; }
    }

    private DateTime _pos_Date;
    public DateTime Pos_Date
    {
        get { return _pos_Date; }
        set { _pos_Date = value; }
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
