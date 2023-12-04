using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
    public class SqlLi_PointsProvider : DataAccessObject
    {
        public SqlLi_PointsProvider()
        {
        }


        public bool DeleteLi_Points(int PointsID)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Points", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PointsID", SqlDbType.Int).Value = PointsID;
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return (result == 1);
            }
        }

        public List<Li_Points> GetAllLi_Pointss()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_GetAllLi_Pointss", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

                return GetLi_PointssFromReader(reader);
            }
        }
        public List<Li_Points> GetLi_PointssFromReader(IDataReader reader)
        {
            List<Li_Points> li_Pointss = new List<Li_Points>();

            while (reader.Read())
            {
                li_Pointss.Add(GetLi_PointsFromReader(reader));
            }
            return li_Pointss;
        }

        public Li_Points GetLi_PointsFromReader(IDataReader reader)
        {
            try
            {
                Li_Points li_Points = new Li_Points
                    (
                        (int)reader["PointsID"],
                        (int)reader["RouteID"],
                        reader["PointName"].ToString(),
                        reader["PointAddress"].ToString(),
                        (bool)reader["IsStartPoint"],
                        (bool)reader["IsEndPoint"],
                        reader["Remarks"].ToString()

                    );
                return li_Points;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Li_Points GetLi_PointsByID(int PointsID)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_GetLi_PointsByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PointsID", SqlDbType.Int).Value = PointsID;
                connection.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    return GetLi_PointsFromReader(reader);
                }
                else
                {
                    return null;
                }
            }
        }

        public int InsertLi_Points(Li_Points li_Points)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Points", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PointsID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RouteID", SqlDbType.Int).Value = li_Points.RouteID;
                cmd.Parameters.Add("@PointName", SqlDbType.VarChar).Value = li_Points.PointName;
                cmd.Parameters.Add("@PointAddress", SqlDbType.VarChar).Value = li_Points.PointAddress;
                cmd.Parameters.Add("@IsStartPoint", SqlDbType.Bit).Value = li_Points.IsStartPoint;
                cmd.Parameters.Add("@IsEndPoint", SqlDbType.Bit).Value = li_Points.IsEndPoint;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = li_Points.Remarks;
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return 1;// (int)cmd.Parameters["@PointsID"].Value;
            }
        }

        public bool UpdateLi_Points(Li_Points li_Points)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Points", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PointsID", SqlDbType.Int).Value = li_Points.PointsID;
                cmd.Parameters.Add("@RouteID", SqlDbType.Int).Value = li_Points.RouteID;
                cmd.Parameters.Add("@PointName", SqlDbType.VarChar).Value = li_Points.PointName;
                cmd.Parameters.Add("@PointAddress", SqlDbType.VarChar).Value = li_Points.PointAddress;
                cmd.Parameters.Add("@IsStartPoint", SqlDbType.Bit).Value = li_Points.IsStartPoint;
                cmd.Parameters.Add("@IsEndPoint", SqlDbType.Bit).Value = li_Points.IsEndPoint;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = li_Points.Remarks;
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result == 1;
            }
        }
    }

}
