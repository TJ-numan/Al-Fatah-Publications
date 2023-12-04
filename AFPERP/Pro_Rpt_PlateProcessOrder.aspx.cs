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
    public partial class Pro_Rpt_PlateProcessOrder : System.Web.UI.Page
    {
        string FormID = "PF055";
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            getUserAccess();
            //if (!IsPostBack)
            //{
            //    txtOrderNo.Text = Request.QueryString["No"];
            //}
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

        protected void txtOrderNo_TextChanged(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            ds = Li_PlateProcessManager.GetProcessOrderInforByDistinctPress(txtOrderNo.Text);
            ddlPress.DataSource = ds.Tables[0];
            ddlPress.DataTextField = "PressName";
            ddlPress.DataValueField = "PressID";
            ddlPress.DataBind();

            //LoadReport(txtOrderNo.Text,ddlPress.SelectedValue);
        }



        protected void ddlPress_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //LoadReport(txtOrderNo.Text, ddlPress.SelectedValue);
            }
            catch (Exception)
            {
               
            }
        }
 ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
               
                rd.Load(Server.MapPath(@"~/Reports/PRO/rptPrintPlateProcessOrder.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@Pro_ID", txtOrderNo.Text);
                rd.SetParameterValue("@PressID", ddlPress.SelectedValue);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Plate Process Order");
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