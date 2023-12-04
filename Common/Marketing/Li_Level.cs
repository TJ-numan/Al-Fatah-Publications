using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Marketing
{
   public class Li_Level
    {
        public Li_Level()
        {
        }

        public Li_Level
            (

            int Level_ID,
            string Level_Name

            )
        {

            this.Level_ID = Level_ID;
            this.Level_Name = Level_Name;

        }

        private int _Level_ID;
        public int Level_ID
        {
            get { return _Level_ID; }
            set { _Level_ID = value; }
        }

        private string _Level_Name;
        public string Level_Name
        {
            get { return _Level_Name; }
            set { _Level_Name = value; }
        }
    }
}
