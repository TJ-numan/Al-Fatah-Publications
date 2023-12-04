using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Li_RoutePlanDetails
    {
        public Li_RoutePlanDetails()
        {
        }

        public Li_RoutePlanDetails
            (

            int routeID,
            int planID,
            string routeName,
            DateTime createdDate,
            int createdBy,
            bool isActive

            )
        {
            this.RouteID = routeID;
            this.PlanID = planID;
            this.RouteName = routeName;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.IsActive = isActive;
        }
        private int _routeID;
        public int RouteID
        {
            get { return _routeID; }
            set { _routeID = value; }
        }

        private int _planID;
        public int PlanID
        {
            get { return _planID; }
            set { _planID = value; }
        }

        private string _routeName;
        public string RouteName
        {
            get { return _routeName; }
            set { _routeName = value; }
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

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
    }

}
