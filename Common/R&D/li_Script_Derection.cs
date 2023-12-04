using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Script_Derection
{
    public Li_Script_Derection()
    {
    }

    public Li_Script_Derection
        (
        int serialNo,
        string bookCode, 
        string edition, 
        int slNo, 
        string dir_Text, 
        DateTime createdDate, 
        int createdBy, 
        char status_D 
         
        )
    {
        this.SerialNo = serialNo;
        this.BookCode = bookCode;
        this.Edition = edition;
        this.SlNo = slNo;
        this.Dir_Text = dir_Text;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.Status_D = status_D;
       
    }

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set {   _serialNo =value ; }
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

    private int _slNo;

    public int SlNo
    {
        get { return _slNo; }
        set { _slNo = value; }
    }

    private string _dir_Text;
    public string Dir_Text
    {
        get { return _dir_Text; }
        set { _dir_Text = value; }
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
