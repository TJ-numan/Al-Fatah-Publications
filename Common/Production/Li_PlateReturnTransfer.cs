using System;
using System.Data;
using System.Configuration;
using System.Linq;



public class Li_PlateReturnTransfer
{
    public Li_PlateReturnTransfer()
    {
    }

    public Li_PlateReturnTransfer
        (
        
        string plateRecID, 
        string pressID, 
        bool isTransfer, 
        string transPressID, 
        DateTime recDate, 
        int totalQty, 
        int createdBy, 
        DateTime createdDate, 
        char status_D, 
        string causeOfDel, 
        int delBy, 
        DateTime delDate 
         
        )
    {
         this.PlateRecID = plateRecID;
        this.PressID = pressID;
        this.IsTransfer = isTransfer;
        this.TransPressID = transPressID;
        this.RecDate = recDate;
        this.TotalQty = totalQty;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.Status_D = status_D;
        this.CauseOfDel = causeOfDel;
        this.DelBy = delBy;
        this.DelDate = delDate;
         
    }


     

    private string _plateRecID;
    public string PlateRecID
    {
        get { return _plateRecID; }
        set { _plateRecID = value; }
    }

    private string _pressID;
    public string PressID
    {
        get { return _pressID; }
        set { _pressID = value; }
    }

    private bool _isTransfer;
    public bool IsTransfer
    {
        get { return _isTransfer; }
        set { _isTransfer = value; }
    }

    private string _transPressID;
    public string TransPressID
    {
        get { return _transPressID; }
        set { _transPressID = value; }
    }

    private DateTime _recDate;
    public DateTime RecDate
    {
        get { return _recDate; }
        set { _recDate = value; }
    }

    private int _totalQty;
    public int TotalQty
    {
        get { return _totalQty; }
        set { _totalQty = value; }
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

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private string _causeOfDel;
    public string CauseOfDel
    {
        get { return _causeOfDel; }
        set { _causeOfDel = value; }
    }

    private int _delBy;
    public int DelBy
    {
        get { return _delBy; }
        set { _delBy = value; }
    }

    private DateTime _delDate;
    public DateTime DelDate
    {
        get { return _delDate; }
        set { _delDate = value; }
    }

  

}
