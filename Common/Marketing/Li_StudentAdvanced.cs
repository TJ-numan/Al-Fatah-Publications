using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Marketing
{
    public class Li_StudentAdvanced
    {
        public Li_StudentAdvanced()
        {
        }

        public Li_StudentAdvanced
         (

         int slNo,
         int classID,
         int noOfStudents,
         string eiin,
         int createdBy,
         DateTime createdDate,
         string fy_Year
         )
        {

            this.SlNo = slNo;
            this.ClassID = classID;
            this.NoOfStudents = noOfStudents;
            this.EIIN = eiin;
            this.CreatedBy = createdBy;
            this.CreatedDate = createdDate;
            this.FY_Year = fy_Year;
        }



        private int _slNo;
        public int SlNo
        {
            get { return _slNo; }
            set { _slNo = value; }
        }

        private int _classID;
        public int ClassID
        {
            get { return _classID; }
            set { _classID = value; }
        }

        private int _noOfStudents;
        public int NoOfStudents
        {
            get { return _noOfStudents; }
            set { _noOfStudents = value; }
        }

        private string _eiin;
        public string EIIN
        {
            get { return _eiin; }
            set { _eiin = value; }
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


        private string _fy_year;
        public string FY_Year
        {
            get { return _fy_year; }
            set { _fy_year = value; }
        }
    }
}
