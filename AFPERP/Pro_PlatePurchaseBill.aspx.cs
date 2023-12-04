using BLL.Classes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PlatePurchaseBill : System.Web.UI.Page
    {
        string FormID = "PF027";
        string ReturnMemo;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    //txtTotalQty.Text = ReturnMemo;

                    LoadPlateSupplier();
                }
            }
            catch (Exception)
            {

            }
        }
        private void getUserAccess()
        {
            DataTable dt = Li_AdminUserManager.GetUserAccess(int.Parse(Session["UserID"].ToString()), FormID).Tables[0];
            if (dt.Rows.Count > 0)
            {

                if (Session["UserID"].ToString() == dt.Rows[0]["UserID"].ToString() && FormID == dt.Rows[0]["FormId"].ToString())
                {
                    if (Boolean.Parse(dt.Rows[0]["Insert_"].ToString()) == true)
                    {
                        //btnSave.Enabled = true;
                    }
                    else
                    {
                        //btnSave.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Update_"].ToString()) == true)
                    {
                        //btnUpdate.Enabled = true;
                    }
                    else
                    {
                        //btnUpdate.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Delete_"].ToString()) == true)
                    {
                        //btnDelete.Enabled = true;
                    }
                    else
                    {
                        //btnDelete.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/ProHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        private void LoadPlateSupplier()
        {
            ddlSupplier.DataSource = Li_PlateBuyerInfoManager.GetAllLi_PlateBuyerInfos();
            ddlSupplier.DataTextField = "Name";
            ddlSupplier.DataValueField = "ID";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, new ListItem("--Select--", ""));
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //txtTotalQty.Text = "0";
                //txtTotalBill.Text = "0";

                //gvwReceiveDetails.DataSource=null;

                //DataSet ds = new DataSet();
                //ds = Li_PlateBillManager.GetPlatePurchaseDetail(ddlSupplier.SelectedValue);

                //gvwReceiveDetails.DataSource = ds.Tables[0];
                //gvwReceiveDetails.DataBind();
                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                    //object[] row = { false  , ds.Tables[0].Rows[i]["TotalPlateQty"].ToString() 
                    //                   ,ds.Tables[0].Rows[i]["Pur_ID"].ToString()
                    //                   ,ds.Tables[0].Rows[i]["TotalBill"].ToString()
                    //                   ,ds.Tables[0].Rows[i]["ReceiveIn"].ToString()
                    //               };

                    //gvPlateReceive.Rows.Add(row);

                //}

            }
            catch (Exception)
            {


            }
        }

        //protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int totalPlate = 0; decimal totalBill = 0.0m;
        //        for (int i = 0; i < gvwReceiveDetails.Rows.Count; i++)
        //        {
        //            CheckBox chkRow = (gvwReceiveDetails.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);
        //            if(chkRow.Checked == true)
        //            {
        //                int plate = int.Parse(gvwReceiveDetails.Rows[i].Cells[1].Text);
        //                decimal bill = decimal.Parse(gvwReceiveDetails.Rows[i].Cells[3].Text);

        //                totalPlate += plate;
        //                totalBill += bill;
        //            }

        //            txtTotalBill.Text = string.Format("{0:0.##}", totalBill);
        //            txtTotalQty.Text = string.Format("{0:0.##}", totalPlate);

        //        }
        //    }
        //    catch (Exception)
        //    {


        //    }
        //}

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtBillDate.Text == "")
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please given a Valid Date');", true);
        //            return;
        //        }
        //        if (decimal.Parse(txtTotalBill.Text) == 0.0m)
        //        {

        //            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select order for Bill adjustment');", true);
        //            return;
        //        }

        //        Li_PlateBill plateBill = new Li_PlateBill();
        //        plateBill.Amount = decimal.Parse(txtTotalBill.Text);
        //        plateBill.BillNo = txtBillNo.Text;
        //        plateBill.CreatedBy = int.Parse(Session["UserID"].ToString());
        //        plateBill.CreatedDate = DateTime.Parse(txtBillDate.Text);
        //        plateBill.SupplierID = ddlSupplier.SelectedValue;
        //        plateBill.Status_D = 'C';
        //        int result = Li_PlateBillManager.InsertLi_PlateBill(plateBill);

        //        for (int i = 0; i < gvwReceiveDetails.Rows.Count; i++)
        //        {

        //            CheckBox chkRow = (gvwReceiveDetails.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);
        //            if (chkRow.Checked == true)
        //            {
        //                Li_PlateBillDetail plateBillDetail = new Li_PlateBillDetail();
        //                plateBillDetail.Pur_Order = gvwReceiveDetails.Rows[i].Cells[2].Text;
        //                plateBillDetail.OrderAmount = decimal.Parse(gvwReceiveDetails.Rows[i].Cells[3].Text);
        //                plateBillDetail.SerialNo = result;
        //                Li_PlateBillDetailManager.InsertLi_PlateBillDetail(plateBillDetail);
        //            }


        //        }


        //        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
        //        gvwReceiveDetails.DataSource = null;
        //        gvwReceiveDetails.DataBind();

        //        txtTotalBill.Text = "";
        //        txtTotalQty.Text = "";

        //    }
        //    catch (Exception)
        //    {


        //    }

        //}
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        protected void btnShowBill_Click(object sender, EventArgs e)
        {
            try
            {
                rd.Load(Server.MapPath(@"~/Reports/PRO/rptPrintPlatePurchaseBill.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@BillNo", txtBillNo.Text);
                rd.SetParameterValue("@SupplierID", ddlSupplier.SelectedValue);
                rd.SetParameterValue("@BillDate", txtBillDate.Text);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "PlatePurchaseBill");
                //rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "PlatePurchaseBill");
                rd.Close();
                rd.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            try
            {
                rd.Dispose();
            }
            catch (Exception)
            {


            }
        }
    }
}