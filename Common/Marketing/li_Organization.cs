using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class  li_Organization
    {


        public li_Organization()
        {
        }



        public li_Organization
            (
            int ID,
            string Organization,
            int serial_number

            )
        {
            this.ID = ID;
            this.Organization = Organization;
            this.serial_number = serial_number;


        }
        

        private int _serial_number;
        public int serial_number
        {
            get { return _serial_number; }
            set { _serial_number = value; }
        }

        private string _Organization;
        public string Organization
        {
            get { return _Organization; }
            set { _Organization = value; }
        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

    }