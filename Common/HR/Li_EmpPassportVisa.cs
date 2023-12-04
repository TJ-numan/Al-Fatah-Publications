using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpPassportVisa
{
    public Li_EmpPassportVisa()
    {
    }

    public Li_EmpPassportVisa
        (
        
        int paViId, 
        string paViNo, 
        int empSl, 
        string passOrVisa, 
        string issuedBy, 
        DateTime issueDate, 
        DateTime expiryDate, 
        DateTime eligibleReviewDate, 
        string eligibleStatus, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    { 
        
        this.PaViId = paViId;
        this.PaViNo = paViNo;
        this.EmpSl = empSl;
        this.PassOrVisa = passOrVisa;
        this.IssuedBy = issuedBy;
        this.IssueDate = issueDate;
        this.ExpiryDate = expiryDate;
        this.EligibleReviewDate = eligibleReviewDate;
        this.EligibleStatus = eligibleStatus;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _paViId;
    public int PaViId
    {
        get { return _paViId; }
        set { _paViId = value; }
    }

    private string _paViNo;
    public string PaViNo
    {
        get { return _paViNo; }
        set { _paViNo = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _passOrVisa;
    public string PassOrVisa
    {
        get { return _passOrVisa; }
        set { _passOrVisa = value; }
    }

    private string _issuedBy;
    public string IssuedBy
    {
        get { return _issuedBy; }
        set { _issuedBy = value; }
    }

    private DateTime _issueDate;
    public DateTime IssueDate
    {
        get { return _issueDate; }
        set { _issueDate = value; }
    }

    private DateTime _expiryDate;
    public DateTime ExpiryDate
    {
        get { return _expiryDate; }
        set { _expiryDate = value; }
    }

    private DateTime _eligibleReviewDate;
    public DateTime EligibleReviewDate
    {
        get { return _eligibleReviewDate; }
        set { _eligibleReviewDate = value; }
    }

    private string _eligibleStatus;
    public string EligibleStatus
    {
        get { return _eligibleStatus; }
        set { _eligibleStatus = value; }
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
