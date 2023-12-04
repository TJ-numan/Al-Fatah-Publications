using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;


public class li_associateProvider : DataAccessObject
    {

        public li_associateProvider()
        {

        }

        public string Insert_AssociateInformation(li_LibraryWiseAssociate li_LibraryWiseAssociate)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_li_Insert_AssociateInformation", connection);
                cmd.CommandType = CommandType.StoredProcedure;
               
                
                cmd.Parameters.Add("@NameAssociate", SqlDbType.VarChar).Value = li_LibraryWiseAssociate.NameAssociate;
                cmd.Parameters.Add("@ResponsiblityAssociate", SqlDbType.VarChar).Value = li_LibraryWiseAssociate.ResponsiblityAssociate;
                cmd.Parameters.Add("@PhoneAssociate", SqlDbType.VarChar).Value = li_LibraryWiseAssociate.PhoneAssociate;
                cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_LibraryWiseAssociate.LibraryID;

                connection.Open();

                cmd.ExecuteNonQuery();

                return null;
            }
        }

        public DataSet GetALLLibraryWiseAssociateInformation(string LibraryID)
        {

            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_li_AllLibraryWisAssociateInformation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@libraryID", SqlDbType.VarChar).Value = LibraryID;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();

                return ds;
            }
        }

        public bool Delete_AssociateFromDatabase(string LibraryID, int serialAssociate)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_li_Delete_AssociateFromLibrary", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@libraryID", SqlDbType.VarChar).Value = LibraryID;
                cmd.Parameters.Add("@SerialAssociate", SqlDbType.Int).Value = serialAssociate;
                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }






    }

