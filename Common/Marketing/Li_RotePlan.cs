using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Li_RotePlan
    {
        public Li_RotePlan()
        {
        }

        public Li_RotePlan
            (
            int planID,
            int companyID,
            int demarcationID,
            string locationID,
            string madeBy,
            string verifiedBy,
            int createdBy,
            DateTime createdDate
            )
        {
            this.PlanID = planID;
            this.CompanyID = companyID;
            this.DemarcationID = demarcationID;
            this.LocationID = locationID;
            this.MadeBy = madeBy;
            this.VerifiedBy = verifiedBy;
            this.CreatedBy = createdBy;
            this.CreatedDate = createdDate;
        }

        private int _planID;
        public int PlanID
        {
            get { return _planID; }
            set { _planID = value; }
        }

        private int _companyID;
        public int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }

        private int _demarcationID;
        public int DemarcationID
        {
            get { return _demarcationID; }
            set { _demarcationID = value; }
        }

        private string _locationID;
        public string LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }

        private string _madeBy;
        public string MadeBy
        {
            get { return _madeBy; }
            set { _madeBy = value; }
        }

        private string _verifiedBy;
        public string VerifiedBy
        {
            get { return _verifiedBy; }
            set { _verifiedBy = value; }
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

}
