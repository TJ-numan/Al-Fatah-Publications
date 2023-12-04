using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Marketing
{

    public class Li_MadrasahInfoAdvanced
    {
        public Li_MadrasahInfoAdvanced()
        {
        }

        public Li_MadrasahInfoAdvanced
        (
      
        string eiin,  
        string madName, 
        string villRoBaz, 
        string postOff, 
        int thanaId, 
        int madLevelId,
        int developIndex,
        string prinName, 
        string prinCont, 
        int createdBy, 
        DateTime createdDate,
        string remarks
        )
    {

        this.EIIN = eiin;
        this.MadName = madName;
        this.VillRoBaz = villRoBaz;
        this.PostOff = postOff;
        this.ThanaId = thanaId;
        this.MadLevelId = madLevelId;
        this.DevelopIndex = developIndex;
        this.PrinName = prinName;
        this.PrinCont = prinCont;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.Remarks = remarks;
    }




    private string _eiin;
    public string EIIN
    {
        get { return _eiin; }
        set { _eiin = value; }
    }

 

    private string _madName;
    public string MadName
    {
        get { return _madName; }
        set { _madName = value; }
    }

    private string _villRoBaz;
    public string VillRoBaz
    {
        get { return _villRoBaz; }
        set { _villRoBaz = value; }
    }

    private string _postOff;
    public string PostOff
    {
        get { return _postOff; }
        set { _postOff = value; }
    }

    private int _thanaId;
    public int ThanaId
    {
        get { return _thanaId; }
        set { _thanaId = value; }
    }
    private int _madLevelId;
    public int MadLevelId
    {
        get { return _madLevelId; }
        set { _madLevelId = value; }
    }

    private int _developIndex;
    public int DevelopIndex
    {
        get { return _developIndex; }
        set { _developIndex = value; }
    }


    private string _prinName;
    public string PrinName
    {
        get { return _prinName; }
        set { _prinName = value; }
    }

    private string _prinCont;
    public string PrinCont
    {
        get { return _prinCont; }
        set { _prinCont = value; }
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

    private string _remarks;
    public string Remarks
    {
        get { return _remarks; }
        set { _remarks = value; }
    }

    }
}
