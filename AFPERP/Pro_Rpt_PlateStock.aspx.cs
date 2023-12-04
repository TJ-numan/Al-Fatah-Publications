using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using BLL;

namespace BLL
{
    public partial class Pro_Rpt_PlateStock : System.Web.UI.Page
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
                    LoadPress();
                    getUserAccess();
                    int year = DateTime.Now.Year;
                    int month = DateTime.Now.Month;
                    int day = DateTime.Now.Day;

                    if (month >= 11)
                    {
                        var mydate = new DateTime(year, 11, 01);

                        dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    }

                    else
                    {
                        var mydate = new DateTime(year - 1, 11, 01);
                        dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    }
                    dtpToDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                }
            }
            catch (Exception)
            {

            }
        }
        private void LoadPress()
        {
            ddlPress.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlPress.DataTextField = "PressName";
            ddlPress.DataValueField = "PressID";
            ddlPress.DataBind();
            ddlPress.Items.Insert(0, new ListItem("All", " "));
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
                        Response.Redirect("~/ProHome.aspx");
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

            rd.Load(Server.MapPath(@"~/Reports/PRO/rptPlateStock.rpt"));
            rd.DataSourceConnections.Clear();
            rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
            rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
            rd.SetParameterValue("@PressID", ddlPress.SelectedValue.ToString());
            rd.SetParameterValue("@fromdate", dtpFromDate.Text);
            rd.SetParameterValue("@todate", dtpToDate.Text);
            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "DateWisePlatePurchase");
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