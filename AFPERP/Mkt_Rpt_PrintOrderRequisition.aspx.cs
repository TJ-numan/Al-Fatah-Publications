using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Mkt_Rpt_RequisitionNo : System.Web.UI.Page
    {
        string FormID = "MR052";
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {                
                    string toDay = DateTime.Now.ToString("yyyy-MM-dd");
                    dtpFromDate.Text = toDay;
                    dtpToDate.Text = toDay;
                    gvPrintRequisition .DataSource =Li_PrintReq_CurManager .GetPrintReqForPrint(toDay,toDay);
                    gvPrintRequisition .DataBind ();
                   
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
                        btnShow.Enabled = true;
                    }
                    else
                    {
                        btnShow.Enabled = false;
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

        protected void gvPrintRequisition_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
        }

        ReportDocument rd = new ReportDocument();
        protected void gvPrintRequisition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvPrintRequisition.SelectedRow;
                ViewState["ReqNo"] = row.Cells[0].Text;
                rd.Load(Server.MapPath(@"~/Reports/MKT/rptBookPrintRequisitionForm.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables ;

           

            crConnectionInfo.ServerName = DAO.ServerName ;
            crConnectionInfo.DatabaseName = DAO.DatabaseName;
            crConnectionInfo.UserID =DAO.UserID ;
            crConnectionInfo.Password = DAO.Password ;

            CrTables = rd.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
 
                rd.SetParameterValue("@ReqNo",  ViewState["ReqNo"].ToString ());
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Print Order Requisition Report");
                rd.Close();
                rd.Dispose();
            }
            catch (Exception ex)
            {
                //throw ex;
              
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                gvPrintRequisition.DataSource = Li_PrintReq_CurManager.GetPrintReqForPrint(dtpFromDate.Text, dtpToDate.Text);
                gvPrintRequisition.DataBind();
            }
            catch (Exception)
            {
                
                 
            }
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                rd.Load(Server.MapPath(@"~/Reports/MKT/CASH/rptDatewisePrintReqRZ.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@FromDate", dtpFromDate.Text);
                rd.SetParameterValue("@ToDate", dtpToDate.Text);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Datewise Print Req");
              
                rd.Close();
                rd.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
    }
}