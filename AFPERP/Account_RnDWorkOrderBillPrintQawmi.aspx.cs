using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Marketing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;

namespace BLL
{
    public partial class Account_RnDWorkOrderBillPrintQawmi : System.Web.UI.Page
    {
        string FormID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    txtWorkOrder.Text = Request.QueryString["BillNo"];
                    getUserAccess();
                    gvWorkOderDetails.DataSource = Li_RnDQawmiWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkDetID(Int32.Parse(txtWorkOrder.Text.ToString()));
                    gvWorkOderDetails.DataBind();


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
                        Response.Redirect("~/RandDHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            try
            {
                rd.Load(Server.MapPath(@"~/Reports/RND/rptPrintWorkOrderBillStatusQawmiAcc.rpt"));
                //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@WorkOrderID", txtWorkOrder.Text);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "PrintRnDWorkOrderBill");
                rd.Close();
                rd.Dispose();

            }
            catch
            {

            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                gvWorkOderDetails.DataSource = Li_RnDQawmiWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkDetID(Int32.Parse(txtWorkOrder.Text.ToString()));
                gvWorkOderDetails.DataBind();

            }
            catch (Exception)
            {

            }
        }
        protected void gvWorkOderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void gvWorkOderDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {


            }

        }
    }
}