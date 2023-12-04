using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFRule
{
    public Li_PFRule()
    {
    }

    public Li_PFRule
        (
       
        int pFRuId, 
        string pFRuName, 
        decimal pFRate, 
        decimal jobYerF, 
        decimal jobYerT, 
        decimal benefitRate, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.PFRuId = pFRuId;
        this.PFRuName = pFRuName;
        this.PFRate = pFRate;
        this.JobYerF = jobYerF;
        this.JobYerT = jobYerT;
        this.BenefitRate = benefitRate;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }




    private int _pFRuId;
    public int PFRuId
    {
        get { return _pFRuId; }
        set { _pFRuId = value; }
    }

    private string _pFRuName;
    public string PFRuName
    {
        get { return _pFRuName; }
        set { _pFRuName = value; }
    }

    private decimal _pFRate;
    public decimal PFRate
    {
        get { return _pFRate; }
        set { _pFRate = value; }
    }

    private decimal _jobYerF;
    public decimal JobYerF
    {
        get { return _jobYerF; }
        set { _jobYerF = value; }
    }

    private decimal _jobYerT;
    public decimal JobYerT
    {
        get { return _jobYerT; }
        set { _jobYerT = value; }
    }

    private decimal _benefitRate;
    public decimal BenefitRate
    {
        get { return _benefitRate; }
        set { _benefitRate = value; }
    }

    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
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

    private int _infStId;
    public int InfStId
    {
        get { return _infStId; }
        set { _infStId = value; }
    }
}
