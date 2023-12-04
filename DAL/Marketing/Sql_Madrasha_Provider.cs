using Common.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Marketing
{
   public class Sql_Madrasha_Provider:DataAccessObject
    {
        public List<Li_Level> GetAllMadrasha_Level()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetAllLi_MadrashaLevel", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

                return GetLi_LevelsFromReader(reader);
            }
        }

        public List<Li_Level> GetLi_LevelsFromReader(IDataReader reader)
        {
            List<Li_Level> li_levels = new List<Li_Level>();

            while (reader.Read())
            {
                li_levels.Add(GetLi_LevelFromReader(reader));
            }
            return li_levels;
        }

        public Li_Level GetLi_LevelFromReader(IDataReader reader)
        {
            try
            {
                Li_Level li_levels = new Li_Level
                    (
                        (int)reader["Level_ID"],
                        reader["Level_Name"].ToString()
                    );
                return li_levels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet Get_LiMadrasah_SomiteeBy_AgrNo(string AgrYear,string AgrNo)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Get_LiMadrasha_SomiteeByAgrNo", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@agrYear", SqlDbType.VarChar).Value = AgrYear;
                cmd.Parameters.Add("@AGRNo", SqlDbType.VarChar).Value = AgrNo;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }
}
