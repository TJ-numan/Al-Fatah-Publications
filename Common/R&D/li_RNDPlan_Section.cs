using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_RNDPlan_Section
{
    public Li_RNDPlan_Section()
    {
    }

    public Li_RNDPlan_Section
        (
   
        int planID, 
    
        int sectionID, 
        char status_D, 
        DateTime createdDate, 
        int createdBy,
        bool isSelect
         
        )
    {
      
        this. PlanID  = planID ;         
        this.SectionID = sectionID;
        this.Status_D = status_D;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.IsSelect = isSelect;
       
    }

    public bool IsSelect { get; set; }

    private int _li_RNDPlan_SectionID;
    public int Li_RNDPlan_SectionID
    {
        get { return _li_RNDPlan_SectionID; }
        set { _li_RNDPlan_SectionID = value; }
    }

    private int _planID;
    public int PlanID
    {
        get { return _planID ; }
        set {_planID   = value; }
    }

    

    private int _sectionID;
    public int SectionID
    {
        get { return _sectionID; }
        set { _sectionID = value; }
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

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    
}
