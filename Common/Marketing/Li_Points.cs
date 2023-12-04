using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{

    public class Li_Points
    {
        public Li_Points()
        {
        }

        public Li_Points
            (

            int pointsID,
            int routeID,
            string pointName,
            string pointAddress,
            bool isStartPoint,
            bool isEndPoint,
            string remarks

            )
        {

            this.PointsID = pointsID;
            this.RouteID = routeID;
            this.PointName = pointName;
            this.PointAddress = pointAddress;
            this.IsStartPoint = isStartPoint;
            this.IsEndPoint = isEndPoint;
            this.Remarks = remarks;
        }

        private int _pointsID;
        public int PointsID
        {
            get { return _pointsID; }
            set { _pointsID = value; }
        }

        private int _routeID;
        public int RouteID
        {
            get { return _routeID; }
            set { _routeID = value; }
        }

        private string _pointName;
        public string PointName
        {
            get { return _pointName; }
            set { _pointName = value; }
        }

        private string _pointAddress;
        public string PointAddress
        {
            get { return _pointAddress; }
            set { _pointAddress = value; }
        }

        private bool _isStartPoint;
        public bool IsStartPoint
        {
            get { return _isStartPoint; }
            set { _isStartPoint = value; }
        }

        private bool _isEndPoint;
        public bool IsEndPoint
        {
            get { return _isEndPoint; }
            set { _isEndPoint = value; }
        }

        private string _remarks;
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

    }

}
