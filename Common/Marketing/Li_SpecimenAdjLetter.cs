using System;
 
using System.Linq; 

public class Li_SpecimenAdjLetter
{
    public Li_SpecimenAdjLetter()
    {
    }

    public Li_SpecimenAdjLetter
        (
 
        int letterNo, 
        string tsoId, 
        decimal returnAmt, 
        decimal adjustAmt, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        string status_d
        )
    {
     
        this.LetterNo = letterNo;
        this.TsoId = tsoId;
        this.ReturnAmt = returnAmt;
        this.AdjustAmt = adjustAmt;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.Status_d = status_d;
    }

 
    private int _letterNo;
    public int LetterNo
    {
        get { return _letterNo; }
        set { _letterNo = value; }
    }

    private string _tsoId;
    public string TsoId
    {
        get { return _tsoId; }
        set { _tsoId = value; }
    }

    private decimal _returnAmt;
    public decimal ReturnAmt
    {
        get { return _returnAmt; }
        set { _returnAmt = value; }
    }

    private decimal _adjustAmt;
    public decimal AdjustAmt
    {
        get { return _adjustAmt; }
        set { _adjustAmt = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private string _status_d;
    public string Status_d
    {
        get { return _status_d; }
        set { _status_d = value; }
    }
}
