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
    public partial class Acc_Rpt_MRSheetPrint : System.Web.UI.Page
    {
        string FormID = "AF006";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserID"] == null)
                        Response.Redirect("~/Login.aspx");
                    getUserAccess();
                    if (Request.QueryString["SheetNo"] != null || Request.QueryString["SheetNo"] != "")
                    {
                        ViewState["SheetNo"] = Request.QueryString["SheetNo"];
                        txtSheetNo.Text = ViewState["SheetNo"].ToString();
                    }

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
                        Response.Redirect("~/AccountsHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        ReportDocument rd = new ReportDocument();
        DataAccessObject DAO = new DataAccessObject();
        protected void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                rd.Load(Server.MapPath(@"~/Reports/ACC/rptMRSheetStatement.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@MRId",   txtSheetNo.Text)  ;
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "MR Sheet");
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

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                gvMRSheetDetailsPrint.DataSource = Li_MRSheetManager.Get_MRSheetNoWiseDetails(Int32.Parse(txtSheetNo.Text));
                gvMRSheetDetailsPrint.DataBind();
            }
            catch (Exception)
            {


            }
        }

        protected void gvMRSheetDetailsPrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvMRSheetDetailsPrint.SelectedRow;
                ViewState["MRNo"] = row.Cells[0].Text;
                ViewState["Com"] = row.Cells[5].Text;
                if (ViewState["Com"].ToString() == "A")
                {
                    rd.Load(Server.MapPath(@"~/Reports/MKT/rptPrintMoneyReceiptR2.rpt"));
                }
                else
                {
                    rd.Load(Server.MapPath(@"~/Reports/MKT/rptPrintMoneyReceipt_MaktabatulFatah.rpt"));
                }
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);

                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;



                crConnectionInfo.ServerName = DAO.ServerName;
                crConnectionInfo.DatabaseName = DAO.DatabaseName;
                crConnectionInfo.UserID = DAO.UserID;
                crConnectionInfo.Password = DAO.Password;

                CrTables = rd.Database.Tables;

                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                rd.SetParameterValue("@MRno", ViewState["MRNo"].ToString());

                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Print Order Requisition Report");
                rd.Close();
                rd.Dispose();
            }
            catch (Exception ex)
            {
                //throw ex;

            }
        }

        protected void gvMRSheetDetailsPrint_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
        }
    }
}