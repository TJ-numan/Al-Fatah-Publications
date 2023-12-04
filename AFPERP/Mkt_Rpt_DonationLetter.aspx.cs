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
    public partial class Mkt_Rpt_DonationLetter : System.Web.UI.Page
    {
        string FormID = "MR028";
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();

                    if (Request.QueryString["No"] != null)
                    {
                        string prefix = Request.QueryString["No"].Trim ().Substring(0, 2);
                        if (prefix == "CA" || prefix == "ca")
                        {
                            //rd.Load(Server.MapPath(@"~/Reports/MKT/rptDonationLetterR2.rpt"));
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptDonationLetterR2_edit.rpt"));
                        }
                        else
                        {
                            rd.Load(Server.MapPath(@"~/Reports/MKT/rptDonationLetter_WithoutCash.rpt"));
                        }
                        rd.DataSourceConnections.Clear();
                        rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                        rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                        rd.SetParameterValue("@LetterNo", Request.QueryString["No"].Trim ());
                        rd.SetParameterValue("@UserId", Int32.Parse(Session["UserID"].ToString()));
                        rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Donation Letter Report");
                        rd.Close();
                        rd.Dispose();
                    }


                    txtLetterNo.Attributes.Add("autocomplete", "off");
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
                        Response.Redirect("~/MarketingHome.aspx");
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
               
                string prefix = txtLetterNo.Text.Substring(0, 2);
                if (prefix == "CA")
                {
                    //rd.Load(Server.MapPath(@"~/Reports/MKT/rptDonationLetterR2.rpt"));
                    rd.Load(Server.MapPath(@"~/Reports/MKT/rptDonationLetterR2_edit.rpt"));
                }
                else
                {
                    rd.Load(Server.MapPath(@"~/Reports/MKT/rptDonationLetter_WithoutCash.rpt"));
                }
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@LetterNo", txtLetterNo.Text);
                rd.SetParameterValue("@UserId", Int32.Parse(Session["UserID"].ToString()));
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Donation Letter Report");
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