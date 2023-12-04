using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintReq
{
    public Li_PrintReq()
    {
    }

    public Li_PrintReq
        (
   
        string rqeNo, 
        DateTime req_Date, 
        string pestType, 
        int proposedQty, 
        DateTime goRecDate, 
        string remark, 
        int createdBy, 
        DateTime createdDate, 
        char statud_D, 
        string causeOfDel, 
        DateTime delDate 


        )
    {
 
        this.RqeNo = rqeNo;
        this.Req_Date = req_Date;
        this.PestType = pestType;
        this.ProposedQty = proposedQty;
        this.GoRecDate = goRecDate;
        this.Remark = remark;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.Statud_D = statud_D;
        this.CauseOfDel = causeOfDel;
        this.DelDate = delDate;
      
       
    }

 

    private string _rqeNo;
    public string RqeNo
    {
        get { return _rqeNo; }
        set { _rqeNo = value; }
    }

    private DateTime _req_Date;
    public DateTime Req_Date
    {
        get { return _req_Date; }
        set { _req_Date = value; }
    }

    private string _pestType;
    public string PestType
    {
        get { return _pestType; }
        set { _pestType = value; }
    }

    private int _proposedQty;
    public int ProposedQty
    {
        get { return _proposedQty; }
        set { _proposedQty = value; }
    }

    private DateTime _goRecDate;
    public DateTime GoRecDate
    {
        get { return _goRecDate; }
        set { _goRecDate = value; }
    }

    private string _remark;
    public string Remark
    {
        get { return _remark; }
        set { _remark = value; }
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

    private char _statud_D;
    public char Statud_D
    {
        get { return _statud_D; }
        set { _statud_D = value; }
    }

    private string _causeOfDel;
    public string CauseOfDel
    {
        get { return _causeOfDel; }
        set { _causeOfDel = value; }
    }

    private DateTime _delDate;
    public DateTime DelDate
    {
        get { return _delDate; }
        set { _delDate = value; }
    }

   
}
