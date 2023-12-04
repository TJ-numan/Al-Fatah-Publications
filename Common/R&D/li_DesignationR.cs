using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;


namespace Common.R_D
{
    public class li_DesignationR
    {
        public li_DesignationR()
        {
        }
        public li_DesignationR
            (

            int designationID,
            string designation
            )
        {

            this.DesignationID = designationID;
            this.Designation = designation;
        }

        private int _designationID;
        public int DesignationID
        {
            get { return _designationID; }
            set { _designationID = value; }
        }

        private string _designation;
        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }

    }
}




