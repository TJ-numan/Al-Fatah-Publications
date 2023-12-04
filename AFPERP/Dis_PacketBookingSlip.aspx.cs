using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL.Reports.Store
{
    public partial class Dis_PacketBookingSlip : System.Web.UI.Page
    {
        string FormID = "";
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");

                getUserAccess();
                
            }
            catch (Exception)
            {

                throw;
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
                        btnPrint.Enabled = true;
                    }
                    else
                    {
                        btnPrint.Enabled = false;
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
                        Response.Redirect("~/DistributionHome.aspx");
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
            if (txtMemoNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please Input Memo No');", true);
                return;
            }
            if (ddlCompany.SelectedValue == "1" || ddlCompany.SelectedValue == "4")
            {
                rd.Load(Server.MapPath(@"~/Reports/Store/rptPacketBookingSlip_AliyaCashCredit.rpt"));
            }
            else if (ddlCompany.SelectedValue == "2" || ddlCompany.SelectedValue == "5")
            {
                rd.Load(Server.MapPath(@"~/Reports/Store/rptPacketBookingSlip_QawmiCashCredit.rpt"));
            }
            else  if (ddlCompany.SelectedValue == "3")
            {
                rd.Load(Server.MapPath(@"~/Reports/Store/rptPacketBookingSlip_Chancellor.rpt"));
            }
        
            rd.DataSourceConnections.Clear();
            rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
            rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
            rd.SetParameterValue("@memono", Int32.Parse(txtMemoNo.Text));
            rd.SetParameterValue("@Com", ddlCompany.SelectedValue);
            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Packet Booking Slip");
            rd.Close();
            rd.Dispose();
        }
    }
}