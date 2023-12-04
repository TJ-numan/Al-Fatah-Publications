using System;
 
using System.Linq;
 
public class Li_SpecimenAdjLetterDetail
{
    public Li_SpecimenAdjLetterDetail()
    {
    }

    public Li_SpecimenAdjLetterDetail
        (
 
        int letDetId, 
        int letterId, 
        DateTime tran_Date, 
        string memoNo, 
        decimal returnAmount, 
        decimal adjustAmount, 
        bool isIntFrom
        )
    {
    
        this.LetDetId = letDetId;
        this.LetterId = letterId;
        this.Tran_Date = tran_Date;
        this.MemoNo = memoNo;
        this.ReturnAmount = returnAmount;
        this.AdjustAmount = adjustAmount;
        this.IsIntFrom = isIntFrom;
    }

 
    private int _letDetId;
    public int LetDetId
    {
        get { return _letDetId; }
        set { _letDetId = value; }
    }

    private int _letterId;
    public int LetterId
    {
        get { return _letterId; }
        set { _letterId = value; }
    }

    private DateTime _tran_Date;
    public DateTime Tran_Date
    {
        get { return _tran_Date; }
        set { _tran_Date = value; }
    }

    private string _memoNo;
    public string MemoNo
    {
        get { return _memoNo; }
        set { _memoNo = value; }
    }

    private decimal _returnAmount;
    public decimal ReturnAmount
    {
        get { return _returnAmount; }
        set { _returnAmount = value; }
    }

    private decimal _adjustAmount;
    public decimal AdjustAmount
    {
        get { return _adjustAmount; }
        set { _adjustAmount = value; }
    }

    private bool _isIntFrom;
    public bool IsIntFrom
    {
        get { return _isIntFrom; }
        set { _isIntFrom = value; }
    }
}
