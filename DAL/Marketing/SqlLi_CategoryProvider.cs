using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Common.Marketing;

namespace DAL.Marketing
{
   public class SqlLi_CategoryProvider:DataAccessObject
    {
        public List<li_Category> GetAllCategories()
        {
            List<li_Category> categories = new List<li_Category>();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("Web_SMPM_GetAllCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    li_Category category = new li_Category();
                    category.Id =reader["ID"].ToString();
                    category.CategoryName = reader["CategoryName"].ToString();
                    categories.Add(category);
                }

            }
            return categories;
        }

      
    }
}
