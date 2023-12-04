using Common.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Marketing
{
   public class Sqlli_AgentStockEntryProvider :DataAccessObject
    {
       public int InsertLi_AgentStockEntry(li_AgentStock li_agentstock)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_li_InsertAgentStock", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_agentstock.BookAcCode;
               cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_agentstock.LibraryID;
               cmd.Parameters.Add("@StockQty", SqlDbType.Int).Value = li_agentstock.StockQty;
               cmd.Parameters.Add("@StockApproveQty", SqlDbType.Int).Value = li_agentstock.StockApproveQty;
               cmd.Parameters.Add("@StockProjectID", SqlDbType.Int).Value = li_agentstock.StockProjectID;
               cmd.Parameters.Add("@StockProjectBookID", SqlDbType.Int).Value = li_agentstock.StockProjectBookID;

               cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_agentstock.CreatedBy;
               cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_agentstock.CreatedDate;
               cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_agentstock.ModifiedBy;
               cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_agentstock.ModifiedDate;
               cmd.Parameters.Add("@ApprovedBy", SqlDbType.Int).Value = li_agentstock.ApprovedBy;
               cmd.Parameters.Add("@ApprovedDate", SqlDbType.DateTime).Value = li_agentstock.ApprovedDate;
               connection.Open();
               int affectedRows = cmd.ExecuteNonQuery();
               return affectedRows;

           }
       }

       public DataSet GetLi_AllStockProject()
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               DataSet ds = new DataSet();
               SqlCommand cmd = new SqlCommand("GetAllProjectName", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               //cmd.Parameters.Add("@LetterNo", SqlDbType.VarChar).Value = LetterNo;
               connection.Open();
               SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
               myadapter.Fill(ds);
               myadapter.Dispose();
               connection.Close();
               return ds;
           }
       }
       public DataSet GetLi_AllStockProject_ByProjectID(int ProjID)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               DataSet ds = new DataSet();
               SqlCommand cmd = new SqlCommand("GetAllProjectNameBy_ProjectID", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@ProjID", SqlDbType.Int).Value = ProjID;
               connection.Open();
               SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
               myadapter.Fill(ds);
               myadapter.Dispose();
               connection.Close();
               return ds;
           }
       }
       public DataSet GetLi_AgentStockProjectForView(int ProjID)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               DataSet ds = new DataSet();
               SqlCommand cmd = new SqlCommand("GetAgentStockProjectForView", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@ProjID", SqlDbType.Int).Value = ProjID;
               connection.Open();
               SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
               myadapter.Fill(ds);
               myadapter.Dispose();
               connection.Close();
               return ds;
           }
       }
       public DataSet GetAllProjectNameBy_ProjIDForEdit(int ProjID, string LibraryId)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               DataSet ds = new DataSet();
               SqlCommand cmd = new SqlCommand("GetAllProjectNameBy_ProjIDForEdit", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@ProjID", SqlDbType.Int).Value = ProjID;
               cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = LibraryId;
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
