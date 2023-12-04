using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;

namespace BLL
{
    public partial class Pro_Rpt_PaperDelivery : System.Web.UI.Page
    {
        string FormID = "PF053";
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
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

                    LoadPaperSupplier();
                    LoadPress();
                    LoadPaperType();
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
                        Response.Redirect("~/ProHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        private void LoadPaperType()
        {
            ddlType.DataSource = Li_PaperTypeBasicManager.GetAllLi_PaperTypeBasics();
            ddlType.DataTextField = "Type";
            ddlType.DataValueField= "ID";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        private void LoadPress()
        {
            ddlPress.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlPress.DataTextField = "PressName";
            ddlPress.DataValueField = "PressID";
            ddlPress.DataBind();
            ddlPress.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        private void LoadPaperSupplier()
        {
            ddlSupplier.DataSource = Li_PaperPartyManager.GetAllLi_PaperParties();
            ddlSupplier.DataTextField = "Name";
            ddlSupplier.DataValueField = "ID";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSize.DataSource = Li_PaperSizeBasicManager.GetLi_PaperSizeBasicByID(ddlType.SelectedValue.ToString());
            ddlSize.DataTextField = "Size";
            ddlSize.DataValueField = "SizeID";
            ddlSize.DataBind();
            ddlSize.Items.Insert(0, new ListItem("--Select--", "0"));
        }


        protected void ddlSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddlGSM.DataSource = Li_PaperWeightBasicManager.GetAllLi_PaperWeightBasics(ddlSize.SelectedValue.ToString());
                ddlGSM.DataTextField = "Weight";
                ddlGSM.DataValueField = "ID";
                ddlGSM.DataBind();
            }
            catch (Exception ex)
            {
            }
        }

 ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
               
                rd.Load(Server.MapPath(@"~/Reports/PRO/rptSupplierPaperDeliveryReport.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@From", dtpFromDate.Text);
                rd.SetParameterValue("@To", dtpToDate.Text);
                rd.SetParameterValue("@Type", ddlType.SelectedValue);
                rd.SetParameterValue("@Size", ddlSize.SelectedValue);
                rd.SetParameterValue("@Weight", ddlGSM.SelectedValue);
                rd.SetParameterValue("@PressID", ddlPress.SelectedValue);
                rd.SetParameterValue("@SupplierID", ddlSupplier.SelectedValue);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Paper Delivery");
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