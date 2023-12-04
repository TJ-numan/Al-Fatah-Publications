using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common.MIS;

namespace DAL.MIS
{
   public class SqlLi_FormListProvider:DataAccessObject
    {
       public List<li_Form> GetAllForm()
       {
           List<li_Form> forms = new List<li_Form>();
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand command = new SqlCommand("SMPM_GetAllFormList", connection);
               command.CommandType= CommandType.StoredProcedure;
               connection.Open();
               SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                   li_Form form = new li_Form();
                   form.FormName = (string) reader["FormName"];
                   form.FormId = (string) reader["FormId"];
                   forms.Add(form);
               }
               connection.Close();
           }
           return forms;
       }
    }
}
