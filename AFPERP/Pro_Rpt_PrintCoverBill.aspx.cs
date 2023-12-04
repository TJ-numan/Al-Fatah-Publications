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
    public partial class Pro_Rpt_PrintCoverBill : System.Web.UI.Page
    {
        string FormID = "PF060";
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            getUserAccess();

            if (!IsPostBack)
            {
                txtBillNo.Text = Request.QueryString["No"];
                ddlSource.SelectedValue = Request.QueryString["SourceNo"];
                ddlSupplier.SelectedValue = Request.QueryString["Supplier"];
                dtpFromDate.Text = Request.QueryString["date"];
                dtpToDate.Text = Request.QueryString["date"];

                ddlCoverSource_SelectedIndexChanged(sender,e);
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

        protected void ddlCoverSource_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (ddlSource.SelectedIndex == 1)
            {
                ddlSupplier.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
                ddlSupplier.DataTextField = "PressName";
                ddlSupplier.DataValueField = "PressID";
                ddlSupplier.DataBind();
                ddlSupplier.Items.Insert(0, new ListItem("--select--", ""));

            }

            else if (ddlSource.SelectedIndex == 2)
            {
                ddlSupplier.DataSource = Li_LeminatioPartyInfoManager.GetAllLi_LeminatioPartyInfos();
                ddlSupplier.DataTextField = "Name";
                ddlSupplier.DataValueField = "ID";
                ddlSupplier.DataBind();
                ddlSupplier.Items.Insert(0, new ListItem("--select--", ""));
            }


            else if (ddlSource.SelectedIndex == 3)
            {
                ddlSupplier.DataSource = Li_BookCoverSupInfoManager.GetAllLi_BookCoverSupInfos();
                ddlSupplier.DataTextField = "SupName";
                ddlSupplier.DataValueField = "COSCode";
                ddlSupplier.DataBind();
                ddlSupplier.Items.Insert(0, new ListItem("--select--", ""));
            }
            else
            {

            }



        }

        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                rd.Load(Server.MapPath(@"~/Reports/PRO/rptPrintCoverBill.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@From", dtpFromDate.Text);
                rd.SetParameterValue("@To", dtpToDate.Text);
                rd.SetParameterValue("@SupplierID", ddlSupplier.SelectedValue);
                rd.SetParameterValue("@Billno", txtBillNo.Text);
                rd.SetParameterValue("@Source", ddlSource.SelectedValue);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Print Cover Bill");
            }
            catch (Exception ex)
            {

            }
        }
    }
}