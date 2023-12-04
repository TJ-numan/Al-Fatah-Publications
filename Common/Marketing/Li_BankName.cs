using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_BankName
{
    public Li_BankName()
    {
    }

    public Li_BankName
        (
         
        int iD, 
        string bankCode, 
        string bankName, 
        DateTime createdDate, 
        int ceatedBy 
         
        )
    {
        
        this.ID = iD;
        this.BankCode = bankCode;
        this.BankName = bankName;
        this.CreatedDate = createdDate;
        this.CeatedBy = ceatedBy;
         
    }


    
    private int _iD;
    public int ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _bankCode;
    public string BankCode
    {
        get { return _bankCode; }
        set { _bankCode = value; }
    }

    private string _bankName;
    public string BankName
    {
        get { return _bankName; }
        set { _bankName = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _ceatedBy;
    public int CeatedBy
    {
        get { return _ceatedBy; }
        set { _ceatedBy = value; }
    }

    
}
