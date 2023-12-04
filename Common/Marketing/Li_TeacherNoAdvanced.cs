using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Marketing
{
    public class Li_TeacherNoAdvanced
    {
        public Li_TeacherNoAdvanced()
        {
        }

        public Li_TeacherNoAdvanced
         (

         int slNo,
         int madLevelID,
         int noOfTeachers,
         string eiin,
         int createdBy,
         DateTime createdDate,
         string fy_Year,
         string agreementWith
         )
        {

            this.SlNo = slNo;
            this.Mad_Level_ID = madLevelID;
            this.NoOfTeachers = noOfTeachers;
            this.EIIN = eiin;
            this.CreatedBy = createdBy;
            this.CreatedDate = createdDate;
            this.FY_Year = fy_Year;
            this.AgreementWith = agreementWith;

        }



        private int _slNo;
        public int SlNo
        {
            get { return _slNo; }
            set { _slNo = value; }
        }

        private int _madLevelID;
        public int Mad_Level_ID
        {
            get { return _madLevelID; }
            set { _madLevelID = value; }
        }

        private int _noOfTeachers;
        public int NoOfTeachers
        {
            get { return _noOfTeachers; }
            set { _noOfTeachers = value; }
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
        private string _agreementWith;
        public string AgreementWith
        {
            get { return _agreementWith; }
            set { _agreementWith = value; }
        }
    }
}
