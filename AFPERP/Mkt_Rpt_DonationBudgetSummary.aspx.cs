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
    public partial class Mkt_Rpt_DonationBudgetSummary : System.Web.UI.Page
    {
        string FormID = "MR041";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadComboData.LoadDonYear(ddlAgreementYear);
                    GetAllDonationType();
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
        private void GetAllDonationType()
        {
            try
            {
                ddlDonationType.DataSource = Li_DonationDesManager.GetAllLi_DonationDessWithBudget();
                ddlDonationType.DataTextField = "DoDescription";
                ddlDonationType.DataValueField = "DoDesId";
                ddlDonationType.DataBind();
                ddlDonationType.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {

            }
        }

        DataAccessObject DAO = new DataAccessObject(); 
        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
              
              
                //rd.DataSourceConnections.Clear();
                //rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                //rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                if (ddlAgreementYear.SelectedValue == "2019-2020")
                {
                    rd.Load(Server.MapPath(@"~/Reports/MKT/rptProjectWiseDonBookBudget.rpt"));
                    rd.DataSourceConnections.Clear();
                    rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                    rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                    rd.SetParameterValue("@fromdate", dtpFromDate.Text);
                    rd.SetParameterValue("@todate", dtpFromDate.Text);
                }
                else
                {
                    rd.Load(Server.MapPath(@"~/Reports/MKT/rptDonationBudgetSummary.rpt"));
                    rd.DataSourceConnections.Clear();
                    rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                    rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                    rd.SetParameterValue("@DoDesId", ddlDonationType.SelectedValue == "4" ? "1" : ddlDonationType.SelectedValue);
                    rd.SetParameterValue("@UserId", int.Parse(Session["UserID"].ToString()));
                    rd.SetParameterValue("@AgrYear", ddlAgreementYear.SelectedItem.Text.Substring(ddlAgreementYear.SelectedItem.Text.Length - 2, 2));
                    //rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Madrasha Info");
                }
                if (ddlViewers.SelectedValue == "0")
                {

                }

                else if (ddlViewers.SelectedValue == "1")
                {
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Madrasha Info");
                }

                else if (ddlViewers.SelectedValue == "2")
                {
                    rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "Madrasha Info");
                }


                else if (ddlViewers.SelectedValue == "3")
                {
                    rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "Madrasha Info");
                }

                else
                {

                }
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

        protected void ddlAgreementYear_SelectedIndexChanged(object sender, EventArgs e)
        {
           if( ddlAgreementYear.SelectedValue=="2019-2020")
           {
               dtpFromDate.Visible = true;
               dtpToDate.Visible = true;
               lblFromDate.Visible = true;
               lblToDate.Visible = true;

               lblDonType.Visible = false;
               ddlDonationType.Visible = false;
               dtpFromDate.Text="2019-11-01";
               dtpToDate.Text = "2020-10-31";
           }
            else
           {
               dtpFromDate.Visible = false;
               dtpToDate.Visible = false;
               lblFromDate.Visible = false;
               lblToDate.Visible = false;

               lblDonType.Visible = true;
               ddlDonationType.Visible = true;
           }
        }

    }
}