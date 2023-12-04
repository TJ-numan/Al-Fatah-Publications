using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

public class SqlLi_TaskWiseBookInformationProvider : DataAccessObject
    {
    public SqlLi_TaskWiseBookInformationProvider()
    {

    }




    public DataSet GetALLBookInformation(string BookID, int ClassID, string Edition, string SizeID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_li_AllBookInformation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
                command.Parameters.Add("@ClassID", SqlDbType.Int).Value = ClassID;
                command.Parameters.Add("@Edition", SqlDbType.VarChar).Value = Edition;
                command.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = SizeID;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();

                return ds;
            }
        }


        public DataSet GetALLBookbyPram(string BookID,string BookName,int ClassID, string Edition, string SizeID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("Web_SMPM_SelectLi_RnDWorkPlanForBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@BookID", SqlDbType.VarChar).Value = BookID;
                command.Parameters.Add("@Edition", SqlDbType.VarChar).Value = ClassID;
                command.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = Edition;
                command.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = SizeID;


                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();

                return ds;
            }
        }



    }

