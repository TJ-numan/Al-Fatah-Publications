using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;

namespace BLL
{
    public partial class Mkt_InvoiceSummary : System.Web.UI.Page
    {
        string FormID = "RF004";
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        DataRow dr;
        DataTable dtSubItem = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                    if (Session["UserID"] == null)
                        Response.Redirect("~/Login.aspx");
                    dtSubItem.Columns.Add("MemoNo", typeof(string));
                    dtSubItem.Columns.Add("LibraryID", typeof(string));
                    dtSubItem.Columns.Add("TotalAmount", typeof(string));
                    dtSubItem.Columns.Add("PacketNo", typeof(string));
                    if (!IsPostBack)
                    {
                        dtpToDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                        dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                        getUserAccess();
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
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
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
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                gvInvoiceDetails.DataSource = li_ChallanManager.Get_DatewiseMemoForSummary(dtpFromDate.Text, dtpToDate.Text, int.Parse(ddlCompany.SelectedValue.ToString()));
                gvInvoiceDetails.DataBind();
                for (int i = 0; i < gvInvoiceDetails.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvInvoiceDetails.Rows[i].Cells[0].FindControl("chkMemoNo") as CheckBox);

                }


            }
            catch (Exception)
            {

            }
        }
        protected void chkMemoNo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                decimal totAmt = 0; int totPack = 0;
                for (int i = 0; i < gvInvoiceDetails.Rows.Count; i++)
                {
                    CheckBox chkRow = (gvInvoiceDetails.Rows[i].Cells[0].FindControl("chkMemoNo") as CheckBox);

                    if (chkRow.Checked == true)
                    {

                        dr = dtSubItem.NewRow();
                        dr["MemoNo"] = gvInvoiceDetails.Rows[i].Cells[1].Text;
                        dr["LibraryID"] = gvInvoiceDetails.Rows[i].Cells[2].Text;

                        dr["TotalAmount"] = gvInvoiceDetails.Rows[i].Cells[3].Text;
                        dr["PacketNo"] = gvInvoiceDetails.Rows[i].Cells[4].Text;
                        totAmt = totAmt + Decimal.Parse(gvInvoiceDetails.Rows[i].Cells[3].Text);
                        totPack = totPack + int.Parse(gvInvoiceDetails.Rows[i].Cells[4].Text);
                        dtSubItem.Rows.Add(dr);

                        gvSummaryDetails.DataSource = dtSubItem;
                        gvSummaryDetails.DataBind();


                    }

                }

                txtTotalAmount.Text = totAmt.ToString();
                txtTotalPackNo.Text = totPack.ToString();

            }
            catch (Exception)
            {


            }

        }

        //protected void gvwInvSummary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        gvInvoiceDetails.PageIndex = e.NewPageIndex;
        //        gvInvoiceDetails.DataSource = li_ChallanManager.Get_DatewiseMemoForSummary(dtpFromDate.Text, dtpToDate.Text, int.Parse(ddlCompany.SelectedValue.ToString()));
        //        gvInvoiceDetails.DataBind();
        //        gvInvoiceDetails.SelectedIndex = -1;
        //    }
        //    catch (Exception ex)
        //    {


        //    }
        //}
  
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (gvSummaryDetails.Rows.Count > 0)
                {

                    li_Challan _invoicesummary = new li_Challan();
                    _invoicesummary.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    _invoicesummary.CreatedDate = DateTime.Now;
                    _invoicesummary.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                    _invoicesummary.PacketNo = int.Parse(txtTotalPackNo.Text);
                    _invoicesummary.Comp = ddlCompany.SelectedValue.ToString();
                    string returnSummarySl = li_ChallanManager.Insert_InvoiceSummaryChallan(_invoicesummary);
                    txtSummarySL.Text = returnSummarySl;
                    for (int i = 0; i < gvSummaryDetails.Rows.Count; i++)
                    {
                        li_Challan invDetails = new li_Challan();
                        invDetails.MemoNo = gvSummaryDetails.Rows[i].Cells[0].Text;
                        invDetails.ChallanID = returnSummarySl;
                        invDetails.ModifiedBy = int.Parse(Session["UserID"].ToString());
                        invDetails.CreatedDate = DateTime.Now;
                        li_ChallanManager.Insert_InvoiceSummaryChallanDetails(invDetails);
                    }
                    

                    //string message = "Saved successfully.";
                    //string script = "window.onload = function(){ alert('";
                    //script += message;
                    //script += "');";
                    //script += "window.location = '";
                    //script += Request.Url.AbsoluteUri;
                    //script += "'; }";
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);


                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                  
                    gvInvoiceDetails.DataSource = null;
                    gvInvoiceDetails.DataBind();
                    
                    gvSummaryDetails.DataSource = null;
                    gvSummaryDetails.DataBind();


                     
                }
            }
            catch (Exception)
            {

            }
        }
        protected void btnSumPrint_OnClick(object sender, EventArgs e)
        {
            rd.Load(Server.MapPath(@"~/Reports/MKT/rptPrintInvoiceSummary.rpt"));
            //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
            rd.DataSourceConnections.Clear();
            rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
            rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
            rd.SetParameterValue("@SlNo", txtSummarySL.Text);
            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "PrintInvoiceSummary");
            rd.Close();
            rd.Dispose();
        }
        protected void btnMemoPrint_OnClick(object sender, EventArgs e)
        {
            rd.Load(Server.MapPath(@"~/Reports/MKT/rptPrintInvoiceSummary.rpt"));
            //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
            rd.DataSourceConnections.Clear();
            rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
            rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
            rd.SetParameterValue("@SlNo", txtSummarySL.Text);
            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "PrintMemobySummary");
            rd.Close();
            rd.Dispose();
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