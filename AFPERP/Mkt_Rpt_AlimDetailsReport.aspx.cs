using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using System.Data;

namespace BLL
{
    public partial class Mkt_Rpt_AlimDetailsReport : System.Web.UI.Page
    {
        string FormID = "MR043";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {
                getUserAccess();
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;

                if (month >= 7)
                {
                    var mydate = new DateTime(year, 07, 01);

                    dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                }

                else
                {
                    var mydate = new DateTime(year - 1, 07, 01);
                    dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                }
                dtpToDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
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
        DataAccessObject DAO  = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
          
            rd.Load(Server.MapPath(@"~/Reports/MKT/rptLibraryAlimSummmary.rpt"));
            //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
            rd.DataSourceConnections.Clear();
            rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
            rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
            rd.SetParameterValue("@fromdate", dtpFromDate.Text);
            rd.SetParameterValue("@todate", dtpToDate.Text);
            rd.SetParameterValue("@UserID", int.Parse(Session["UserID"].ToString()));
            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "name");
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