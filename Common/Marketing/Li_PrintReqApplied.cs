using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PrintReqApplied
{
    public Li_PrintReqApplied()
    {
    }

    public Li_PrintReqApplied
        (
 
        int sl, 
        string reqNo, 
        int reqForID, 
        bool isApplied  
         
        )
    {
 
        this.Sl = sl;
        this.ReqNo = reqNo;
        this.ReqForID = reqForID;
        this.IsApplied = isApplied;
        
    }


 

    private int _sl;
    public int Sl
    {
        get { return _sl; }
        set { _sl = value; }
    }

    private string _reqNo;
    public string ReqNo
    {
        get { return _reqNo; }
        set { _reqNo = value; }
    }

    private int _reqForID;
    public int ReqForID
    {
        get { return _reqForID; }
        set { _reqForID = value; }
    }

    private bool _isApplied;
    public bool IsApplied
    {
        get { return _isApplied; }
        set { _isApplied = value; }
    }

     
}
