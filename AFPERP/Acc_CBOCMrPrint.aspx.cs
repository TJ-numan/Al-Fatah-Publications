using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL.Classes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BLL
{
    public partial class Acc_CBOCMrPrint : System.Web.UI.Page
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

                }

                if (Session["MRNO"] != null)
                {
                    txtMemoNo.Text = Session["MRNO"].ToString();
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
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/AccountsHome.aspx");
                    }
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
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
      
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDocument rd = new ReportDocument();
                if (ddlCom.SelectedValue == "0")
                    {
                        rd.Load(Server.MapPath(@"~/Reports/ACC/rptPrintCashBackOfferMR_A.rpt"));
                    }
                else
                    {
                        rd.Load(Server.MapPath(@"~/Reports/ACC/rptPrintCashBackOfferMR_Q.rpt"));
                    }
                //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@MRno", txtMemoNo.Text);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Deposit Money Report");
            }
            catch (Exception)
            {

            }
        }
    }
}