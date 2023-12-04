using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_WorkTypeRNDComputer
{
    public Li_WorkTypeRNDComputer()
    {
    }

    public Li_WorkTypeRNDComputer
        (
        
        int worksTypeID, 
        string workType, 
        int sectionID, 
        bool isMeasureInTime  
         
        )
    {
         
        this.WorksTypeID = worksTypeID;
        this.WorkType = workType;
        this.SectionID = sectionID;
        this.IsMeasureInTime = isMeasureInTime;
        
    }

 
    private int _worksTypeID;
    public int WorksTypeID
    {
        get { return _worksTypeID; }
        set { _worksTypeID = value; }
    }

    private string _workType;
    public string WorkType
    {
        get { return _workType; }
        set { _workType = value; }
    }

    private int _sectionID;
    public int SectionID
    {
        get { return _sectionID; }
        set { _sectionID = value; }
    }

    private bool _isMeasureInTime;
    public bool IsMeasureInTime
    {
        get { return _isMeasureInTime; }
        set { _isMeasureInTime = value; }
    }

     
}
