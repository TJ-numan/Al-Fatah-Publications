using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Li_TargetDetails
{
    public Li_TargetDetails()
    {
    }

    public Li_TargetDetails
        (
        int tergID,
        string terCode,
        string tSOEmpCode,
        DateTime startDate,
        DateTime endDate,
        decimal salesTar,
        decimal collecTar,
        int createdBy,
        DateTime createdDate,
        char status_D,
        int CompanyId


        )
    {

        this.TergID = tergID;
        this.TerCode = terCode;
        this.TSOEmpCode = tSOEmpCode;
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.SalesTar = salesTar;
        this.CollecTar = collecTar;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.Status_D = status_D;
        this.CompanyId = CompanyId;
    }

    public int CompanyId { get; set; }
    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }
    private int _tergID;
    public int TergID
    {
        get { return _tergID; }
        set { _tergID = value; }
    }

    private string _terCode;
    public string TerCode
    {
        get { return _terCode; }
        set { _terCode = value; }
    }
    private string _tSOEmpCode;
    public string TSOEmpCode
    {
        get { return _tSOEmpCode; }
        set { _tSOEmpCode = value; }
    }

    private decimal _salesTar;
    public decimal SalesTar
    {
        get { return _salesTar; }
        set { _salesTar = value; }
    }

    private decimal _collecTar;
    public decimal CollecTar
    {
        get { return _collecTar; }
        set { _collecTar = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }
    private DateTime _startDate;
    public DateTime StartDate
    {
        get { return _startDate; }
        set { _startDate = value; }
    }
    private DateTime _endDate;
    public DateTime EndDate
    {
        get { return _endDate; }
        set { _endDate = value; }
    }
}


