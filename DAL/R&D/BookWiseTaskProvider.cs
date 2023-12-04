using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class BookWiseTaskProvider : DataAccessObject
    {
        public BookWiseTaskProvider()
        {

        }

        public DataSet GetALLTaskBookWise(string BookID)
        {

            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_li_AllBookInformationTaskWiseReport", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
                command.Parameters.Add("@ClassID", SqlDbType.Int).Value =0;
                command.Parameters.Add("@Edition", SqlDbType.VarChar).Value = DBNull.Value;
                command.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = DBNull.Value;
                command.Parameters.Add("@TaskStatus", SqlDbType.VarChar).Value = DBNull.Value;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();

                return ds;
            }
        }

    }

