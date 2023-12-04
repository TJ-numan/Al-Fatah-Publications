using System;
using System.Data;
using System.Configuration;
using System.Linq;



public class Li_PlateReturnTransferDetail
{
    public Li_PlateReturnTransferDetail()
    {
    }

    public Li_PlateReturnTransferDetail
        (

        int serialNo, 
        string plateRecID, 
        string bookCode, 
        int plateFor,
        int qty,
        string plateTypeID,
        string plateSizeID, 
        string plateUseType

         
        )
    {

        this.SerialNo = serialNo;
        this.PlateRecID = plateRecID;
        this.BookCode = bookCode;
        this.PlateFor = plateFor;
        this.Qty = qty;
        this.PlateTypeID = plateTypeID;
        this.PlateSizeID = plateSizeID;
        this.PlateUseType = plateUseType;
     

    }


    


    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string _plateRecID;
    public string PlateRecID
    {
        get { return _plateRecID; }
        set { _plateRecID = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private int _plateFor;
    public int PlateFor
    {
        get { return _plateFor; }
        set { _plateFor = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private string _plateTypeID;
    public string PlateTypeID
    {
        get { return _plateTypeID; }
        set { _plateTypeID = value; }
    }

    private string _plateSizeID;
    public string PlateSizeID
    {
        get { return _plateSizeID; }
        set { _plateSizeID = value; }
    }

    private string _plateUseType;
    public string PlateUseType
    {
        get { return _plateUseType; }
        set { _plateUseType = value; }
    }

}
