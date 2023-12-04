using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace BLL
{
    public partial class Pro_Rpt_SupplierBill : System.Web.UI.Page
    {
        string FormID = "PF063";
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            getUserAccess();
            if(!IsPostBack)
            {
                LoadPaperSupplier();
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
                        Response.Redirect("~/ProHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadPaperSupplier()
        {
            ddlSupplier.DataSource = Li_PaperPartyManager.GetAllLi_PaperParties();
            ddlSupplier.DataTextField = "Name";
            ddlSupplier.DataValueField = "ID";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadReport(txtBillNo.Text, ddlSupplier.SelectedValue.ToString());
        }

        ReportDocument rd = new ReportDocument();
        private void LoadReport(string billNo, string SupplierID)
        {
            try
            {
               
                rd.Load(Server.MapPath(@"~/Reports/PRO/rptPrintPaperBill.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@BillNo", billNo);
                rd.SetParameterValue("@SupplierID", SupplierID);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "PrintPaperBill");
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