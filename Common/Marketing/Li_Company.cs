using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Li_Company
    {
        public Li_Company()
        {
        }

        public Li_Company
            (

            int companyID,
            string companyName

            )
        {

            this.CompanyID = companyID;
            this.CompanyName = companyName;

        }

        private int _companyID;
        public int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }

        private string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
    }

}
