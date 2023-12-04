using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;


   public  class BookWiseTaskListManager
    {
        public BookWiseTaskListManager()
        {


        }

        public static DataSet GetALLTaskBooKWise(string BookID)
        {
            DataSet ds = new DataSet();
            BookWiseTaskProvider SearchBookInformation = new BookWiseTaskProvider();
            ds = SearchBookInformation.GetALLTaskBookWise(BookID);
            return ds;
        }






    }

