using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;

namespace BLL
{
    public partial class ManagementHome : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    dtpToDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    gvDailySummaryDetails.DataSource = Li_ManagementSummaryManager.GetLi_ManagementDatewiseSummaryDetails(dtpFromDate.Text, dtpToDate.Text);
                    gvDailySummaryDetails.DataBind();


                    decimal TotalChln = 0, TotalRtn = 0, TotalNet = 0, TotalPC = 0, TotalDepo = 0, TotalDue = 0;
                    gvDailySummaryDetails.FooterRow.Cells[0].Text = "Total";
                    gvDailySummaryDetails.FooterRow.Cells[0].Font.Bold = true;
                    gvDailySummaryDetails.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    gvDailySummaryDetails.FooterRow.BackColor = System.Drawing.Color.Beige;

                    for (int i = 0; i < gvDailySummaryDetails.Rows.Count; i++)
                    {
                        TotalChln = TotalChln + decimal.Parse(gvDailySummaryDetails.Rows[i].Cells[1].Text);
                        TotalRtn = TotalRtn + decimal.Parse(gvDailySummaryDetails.Rows[i].Cells[2].Text);
                        TotalNet = TotalNet + decimal.Parse(gvDailySummaryDetails.Rows[i].Cells[3].Text);
                        TotalPC = TotalPC + decimal.Parse(gvDailySummaryDetails.Rows[i].Cells[4].Text);
                        TotalDepo = TotalDepo + decimal.Parse(gvDailySummaryDetails.Rows[i].Cells[5].Text);
                        TotalDue = TotalDue + decimal.Parse(gvDailySummaryDetails.Rows[i].Cells[6].Text);
                    }


                    gvDailySummaryDetails.FooterRow.Cells[1].Text = TotalChln.ToString();
                    gvDailySummaryDetails.FooterRow.Cells[1].Font.Bold = true;
                    gvDailySummaryDetails.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Left;

                    gvDailySummaryDetails.FooterRow.Cells[2].Text = TotalRtn.ToString();
                    gvDailySummaryDetails.FooterRow.Cells[2].Font.Bold = true;
                    gvDailySummaryDetails.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Left;

                    gvDailySummaryDetails.FooterRow.Cells[3].Text = TotalNet.ToString();
                    gvDailySummaryDetails.FooterRow.Cells[3].Font.Bold = true;
                    gvDailySummaryDetails.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Left;

                    gvDailySummaryDetails.FooterRow.Cells[4].Text = TotalPC.ToString();
                    gvDailySummaryDetails.FooterRow.Cells[4].Font.Bold = true;
                    gvDailySummaryDetails.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Left;

                    gvDailySummaryDetails.FooterRow.Cells[5].Text = TotalDepo.ToString();
                    gvDailySummaryDetails.FooterRow.Cells[5].Font.Bold = true;
                    gvDailySummaryDetails.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Left;

                    gvDailySummaryDetails.FooterRow.Cells[6].Text = TotalDue.ToString();
                    gvDailySummaryDetails.FooterRow.Cells[6].Font.Bold = true;
                    gvDailySummaryDetails.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Left;

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
                        Response.Redirect("~/ManagementHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {


                rd.Load(Server.MapPath(@"~/Reports/Rpt_PrintDateWiseSummaryReport.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@fromdate", dtpFromDate.Text);
                rd.SetParameterValue("@todate", dtpToDate.Text);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "DatewiseSummaryReport");
                //if (ddlViewers.SelectedValue == "0")
                //{

                //}

                //else if (ddlViewers.SelectedValue == "1")
                //{
                //    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "DatewiseSummaryReport");
                //}

                //else if (ddlViewers.SelectedValue == "2")
                //{
                //    rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "DatewiseSummaryReport");
                //}


                //else if (ddlViewers.SelectedValue == "3")
                //{
                //    rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "DatewiseSummaryReport");
                //}

                //else
                //{

                //}

                rd.Close();
                rd.Dispose();

            }
            catch (Exception)
            {


            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                gvDailySummaryDetails.DataSource = Li_ManagementSummaryManager.GetLi_ManagementDatewiseSummaryDetails(dtpFromDate.Text, dtpToDate.Text);
                gvDailySummaryDetails.DataBind();

                decimal TotalChln = 0, TotalRtn = 0, TotalNet = 0, TotalPC = 0, TotalDepo = 0, TotalDue = 0;
                gvDailySummaryDetails.FooterRow.Cells[0].Text = "Total";
                gvDailySummaryDetails.FooterRow.Cells[0].Font.Bold = true;
                gvDailySummaryDetails.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                gvDailySummaryDetails.FooterRow.BackColor = System.Drawing.Color.Beige;

                for (int i = 0; i < gvDailySummaryDetails.Rows.Count; i++)
                {
                    TotalChln = TotalChln + decimal.Parse(gvDailySummaryDetails.Rows[i].Cells[1].Text);
                    TotalRtn = TotalRtn + decimal.Parse(gvDailySummaryDetails.Rows[i].Cells[2].Text);
                    TotalNet = TotalNet + decimal.Parse(gvDailySummaryDetails.Rows[i].Cells[3].Text);
                    TotalPC = TotalPC + decimal.Parse(gvDailySummaryDetails.Rows[i].Cells[4].Text);
                    TotalDepo = TotalDepo + decimal.Parse(gvDailySummaryDetails.Rows[i].Cells[5].Text);
                    TotalDue = TotalDue + decimal.Parse(gvDailySummaryDetails.Rows[i].Cells[6].Text);
                }


                gvDailySummaryDetails.FooterRow.Cells[1].Text = TotalChln.ToString();
                gvDailySummaryDetails.FooterRow.Cells[1].Font.Bold = true;
                gvDailySummaryDetails.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Left;

                gvDailySummaryDetails.FooterRow.Cells[2].Text = TotalRtn.ToString();
                gvDailySummaryDetails.FooterRow.Cells[2].Font.Bold = true;
                gvDailySummaryDetails.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Left;

                gvDailySummaryDetails.FooterRow.Cells[3].Text = TotalNet.ToString();
                gvDailySummaryDetails.FooterRow.Cells[3].Font.Bold = true;
                gvDailySummaryDetails.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Left;

                gvDailySummaryDetails.FooterRow.Cells[4].Text = TotalPC.ToString();
                gvDailySummaryDetails.FooterRow.Cells[4].Font.Bold = true;
                gvDailySummaryDetails.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Left;

                gvDailySummaryDetails.FooterRow.Cells[5].Text = TotalDepo.ToString();
                gvDailySummaryDetails.FooterRow.Cells[5].Font.Bold = true;
                gvDailySummaryDetails.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Left;

                gvDailySummaryDetails.FooterRow.Cells[6].Text = TotalDue.ToString();
                gvDailySummaryDetails.FooterRow.Cells[6].Font.Bold = true;
                gvDailySummaryDetails.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Left;
            }
            catch (Exception)
            {


            }
        }
        protected void gvDailySummaryDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

            }
            catch (Exception)
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