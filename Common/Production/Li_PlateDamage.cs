using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

public class Li_PlateDamage
{
    public Li_PlateDamage()
    {
    }

    public Li_PlateDamage
        (

        string pdm_ID,
        DateTime challanDate,
        string pressID,
        string dam_PurID, 
        int totalPlateQty, 
        decimal totalBill, 
        int createdBy, 
        DateTime createdDate 
         
        )
    {
        this.PDM_ID = pdm_ID;
        this.ChallanDate = challanDate;
        this.PressID = pressID;
        this.Dam_PurID = dam_PurID;

        this.TotalPlateQty = totalPlateQty;
        this.TotalBill = totalBill;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
      
    }


     

    private string _pdm_ID;
    public string PDM_ID
    {
        get { return _pdm_ID; }
        set { _pdm_ID = value; }
    }

    private DateTime _challanDate;
    public DateTime ChallanDate
    {
        get { return _challanDate; }
        set { _challanDate = value; }
    }

    private string _pressID;
    public string PressID
    {
        get { return _pressID; }
        set { _pressID = value; }
    }

    private string _dam_PurID;
    public string Dam_PurID
    {
        get { return _dam_PurID; }
        set { _dam_PurID = value; }
    }

    private int _totalPlateQty;
    public int TotalPlateQty
    {
        get { return _totalPlateQty; }
        set { _totalPlateQty = value; }
    }

    private decimal _totalBill;
    public decimal TotalBill
    {
        get { return _totalBill; }
        set { _totalBill = value; }
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
 
}
