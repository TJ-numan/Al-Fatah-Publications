using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;
using System.Data;

namespace DAL
{
   public   class DemLocationProvider:DataAccessObject
   {
       public DemLocationProvider() { }
       public List<DemLocation> GetLocationsByDemarcation(int DemID)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("getDemarcationLocation" +
                                                    "", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@DemID", SqlDbType.Int).Value = DemID ;

                connection.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

                return GetLi_CompaniesFromReader(reader);
            }
        }
        public List<DemLocation> GetLi_CompaniesFromReader(IDataReader reader)
        {
            List<DemLocation>  demLocations  = new List<DemLocation>();

            while (reader.Read())
            {
                demLocations.Add(GetLi_CompanyFromReader(reader));
            }
            return demLocations;
        }

        public DemLocation GetLi_CompanyFromReader(IDataReader reader)
        {
            try
            {
                DemLocation  demloc = new DemLocation
                    (
                        reader["locID"].ToString(),
                        reader["Location"].ToString()
                    );
                return demloc ;
            }
            catch (Exception )
            {
                return null;
            }
        }


        public DataSet getRoutePlanMappings(int ComID, int DemID )
        {
            DataSet ds = new DataSet();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_li_GetRoutePlanMapping", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ComID", SqlDbType.Int).Value = ComID;
                cmd.Parameters.Add("@DemID", SqlDbType.Int).Value = DemID;
         
                connection.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                sda.Dispose();

                return ds;
            }


        }

    }
}
