using Common.Production;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Li_SutrapurLaminationProvider : DataAccessObject
    {
      public Li_SutrapurLaminationProvider()
      {

      }
      public DataSet GetAllLi_LemiSupplyPartyInfo()
      {
          DataSet ds = new DataSet();
          using (SqlConnection connection = new SqlConnection(this.ConnectionString))
          {
              SqlCommand command = new SqlCommand("SMPM_GetAllLi_LemiSupplyPartyInfo", connection);
              command.CommandType = CommandType.StoredProcedure;
              //command.Parameters.Add("@ID", SqlDbType.VarChar).Value = BinderID;
              connection.Open();
              SqlDataAdapter myadapter = new SqlDataAdapter(command);
              myadapter.Fill(ds);
              myadapter.Dispose();
              connection.Close();

              return ds;
          }
      }

      public DataSet GetAllLi_LemiSizeBasics()
      {
          DataSet ds = new DataSet();
          using (SqlConnection connection = new SqlConnection(this.ConnectionString))
          {
              SqlCommand command = new SqlCommand("SMPM_GetAllLi_LemiSizeBasics", connection);
              command.CommandType = CommandType.StoredProcedure;
              connection.Open();
              SqlDataAdapter myadapter = new SqlDataAdapter(command);
              myadapter.Fill(ds);
              myadapter.Dispose();
              connection.Close();

              return ds;
          }
      }

      //public string InsertLi_SutrapurLaminationGodownReceive(SutrapurLamination SutrapurLamiGodownRcv)
      //{
      //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
      //    {
      //        SqlCommand cmd = new SqlCommand("SMPM_InsertSutrapurLamiGodownRcv", connection);
      //        cmd.CommandType = CommandType.StoredProcedure;

      //        cmd.Parameters.Add("@ReceivedID", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;
      //        cmd.Parameters.Add("@ReceiveMemo", SqlDbType.VarChar).Value = SutrapurLamiGodownRcv.ReceiveMemo;
      //        cmd.Parameters.Add("@SupplierID", SqlDbType.VarChar).Value = SutrapurLamiGodownRcv.SupplierID;
      //        cmd.Parameters.Add("@SupplyDate", SqlDbType.DateTime).Value = SutrapurLamiGodownRcv.SupplyDate;
      //        cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = SutrapurLamiGodownRcv.TotalAmount;
      //        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = SutrapurLamiGodownRcv.Remarks;
      //        cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = SutrapurLamiGodownRcv.CreatedBy;
      //        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = SutrapurLamiGodownRcv.CreatedDate;
      //        cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = SutrapurLamiGodownRcv.ModifiedBy;
      //        cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = SutrapurLamiGodownRcv.ModifiedDate;
      //        cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = SutrapurLamiGodownRcv.Status_D;
      //        cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = SutrapurLamiGodownRcv.IsPaid; 
               



      //        connection.Open();

      //        int result = cmd.ExecuteNonQuery();
      //        return  cmd.Parameters["@ReceivedID"].Value.ToString();




      //    }
      //}

      public string InsertLi_SutrapurLaminationGodownReceive(SutrapurLamination SutrapurLamiGodownRcv)
      {
          using (SqlConnection connection = new SqlConnection(this.ConnectionString))
          {
              SqlCommand cmd = new SqlCommand("SMPM_InsertSutrapurLamiGodownRcv", connection);
              cmd.CommandType = CommandType.StoredProcedure;

              cmd.Parameters.Add("@ReceivedID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
              cmd.Parameters.Add("@ReceiveMemo", SqlDbType.VarChar).Value = SutrapurLamiGodownRcv.ReceiveMemo;
              cmd.Parameters.Add("@SupplierBillNo", SqlDbType.VarChar).Value = SutrapurLamiGodownRcv.SupplierBillNo;
              cmd.Parameters.Add("@SupplierID", SqlDbType.VarChar).Value = SutrapurLamiGodownRcv.SupplierID;
              cmd.Parameters.Add("@SupplyDate", SqlDbType.DateTime).Value = SutrapurLamiGodownRcv.SupplyDate;
              cmd.Parameters.Add("@RcvDate", SqlDbType.DateTime).Value = SutrapurLamiGodownRcv.RcvDate;
              cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = SutrapurLamiGodownRcv.TotalAmount;
              cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = SutrapurLamiGodownRcv.Remarks;
              cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = SutrapurLamiGodownRcv.CreatedBy;
              cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = SutrapurLamiGodownRcv.CreatedDate;
              cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = SutrapurLamiGodownRcv.ModifiedBy;
              cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = SutrapurLamiGodownRcv.ModifiedDate;
              cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = SutrapurLamiGodownRcv.Status_D;
              cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = SutrapurLamiGodownRcv.IsPaid;




              connection.Open();

              int result = cmd.ExecuteNonQuery();
              return cmd.Parameters["@ReceivedID"].Value.ToString();




          }
      }

      public string InsertLi_SutrapurLaminationItemChallan(SutrapurLamiItemChallan SutrapurLamiItemChallan)
      {
          using (SqlConnection connection = new SqlConnection(this.ConnectionString))
          {
              SqlCommand cmd = new SqlCommand("SMPM_InsertSutrapurLamiItemChallan", connection);
              cmd.CommandType = CommandType.StoredProcedure;

              cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
              cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = SutrapurLamiItemChallan.RefNo;
              cmd.Parameters.Add("@PartyID", SqlDbType.VarChar).Value = SutrapurLamiItemChallan.PartyID;
              cmd.Parameters.Add("@ChallanDate", SqlDbType.DateTime).Value = SutrapurLamiItemChallan.ChallanDate;
              cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = SutrapurLamiItemChallan.TotalAmount;
              cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = SutrapurLamiItemChallan.Remarks;
              cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = SutrapurLamiItemChallan.CreatedBy;
              cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = SutrapurLamiItemChallan.CreatedDate;
              cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = SutrapurLamiItemChallan.ModifiedBy;
              cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = SutrapurLamiItemChallan.ModifiedDate;
              cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = SutrapurLamiItemChallan.Status_D;
              cmd.Parameters.Add("@CauseOfDelete", SqlDbType.VarChar).Value = SutrapurLamiItemChallan.CauseOfDelete; 
               



              connection.Open();

              int result = cmd.ExecuteNonQuery();
              return cmd.Parameters["@ChallanID"].Value.ToString();


          }
      }

      public int InsertLi_SutrapurLaminationGodownReceiveDetails(SutrapurLaminationDetails SutrapurLamiGodownRcvDet)
      {
          using (SqlConnection connection = new SqlConnection(this.ConnectionString))
          {
              SqlCommand cmd = new SqlCommand("SMPM_InsertSutrapurLamiGodownRcvDetails", connection);
              cmd.CommandType = CommandType.StoredProcedure;

              cmd.Parameters.Add("@ReceivedID", SqlDbType.VarChar).Value = SutrapurLamiGodownRcvDet.ReceivedID;
              cmd.Parameters.Add("@TypeId", SqlDbType.VarChar).Value = SutrapurLamiGodownRcvDet.TypeId;
              cmd.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = SutrapurLamiGodownRcvDet.SizeID;
              cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = SutrapurLamiGodownRcvDet.Quantity;
              cmd.Parameters.Add("@UnitMeasure", SqlDbType.VarChar).Value = SutrapurLamiGodownRcvDet.UnitMeasure;
              cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = SutrapurLamiGodownRcvDet.UnitPrice;
              cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = SutrapurLamiGodownRcvDet.CreatedBy;
              cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = SutrapurLamiGodownRcvDet.CreatedDate;
              cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = SutrapurLamiGodownRcvDet.ModifiedBy;
              cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = SutrapurLamiGodownRcvDet.ModifiedDate;
              cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = SutrapurLamiGodownRcvDet.Status_D;


              connection.Open();

              int result = cmd.ExecuteNonQuery();
              return 1;

          }
      }
      public int InsertLi_SutrapurLaminationItemChallanDetails(SutrapurLamiItemChallanDetails SutrapurLamiItemChallanDet)
      {
          using (SqlConnection connection = new SqlConnection(this.ConnectionString))
          {
              SqlCommand cmd = new SqlCommand("SMPM_InsertSutrapurLamiItemChallanDetails", connection);
              cmd.CommandType = CommandType.StoredProcedure;

              cmd.Parameters.Add("@ChallanID", SqlDbType.VarChar).Value = SutrapurLamiItemChallanDet.ChallanID;
              cmd.Parameters.Add("@TypeId", SqlDbType.VarChar).Value = SutrapurLamiItemChallanDet.TypeId;
              cmd.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = SutrapurLamiItemChallanDet.SizeID;
              cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = SutrapurLamiItemChallanDet.Quantity;
              cmd.Parameters.Add("@UnitMeasure", SqlDbType.VarChar).Value = SutrapurLamiItemChallanDet.UnitMeasure;
              cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = SutrapurLamiItemChallanDet.UnitPrice;
              cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = SutrapurLamiItemChallanDet.CreatedBy;
              cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = SutrapurLamiItemChallanDet.CreatedDate;
              cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = SutrapurLamiItemChallanDet.ModifiedBy;
              cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = SutrapurLamiItemChallanDet.ModifiedDate;
              cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = SutrapurLamiItemChallanDet.Status_D;
              cmd.Parameters.Add("@CauseOfDelete", SqlDbType.VarChar).Value = SutrapurLamiItemChallanDet.CauseOfDelete; 


              connection.Open();

              int result = cmd.ExecuteNonQuery();
              return 1;

          }
      }

    }

}
