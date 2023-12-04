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
    public partial class Pro_Rpt_FormaPrintingOrder : System.Web.UI.Page
    {
        string FormID = "PF050";
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    if (Session["UserID"] == null)
                        Response.Redirect("~/Login.aspx");
                    getUserAccess();
                    LoadPress();
                    txtOrderNo.Text = Request.QueryString["No"];
                    ddlPlateFor.SelectedValue = Request.QueryString["binder"];

                    DataSet ds = new DataSet();
                    ds = Li_Print_Order_FormaManager.GetPrintOrderInforByDistinctPress(Request.QueryString["No"], Request.QueryString["binder"]);

                    ddlPressName.DataSource = ds.Tables[0];
                    ddlPressName.DataTextField = "PressName";
                    ddlPressName.DataValueField = "PressID";
                    ddlPressName.DataBind();

                    ddlPlateFor.DataBind();

                }
                catch (Exception)
                {
                    
                }
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
        private void LoadPress()
        {
            ddlPressName.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlPressName.DataTextField = "PressName";
            ddlPressName.DataValueField = "PressID";
            ddlPressName.DataBind();
        }
        protected void txtOrderNo_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = Li_Print_Order_FormaManager.GetPrintOrderInforByDistinctPress(txtOrderNo.Text, ddlPlateFor.SelectedValue.ToString());

            ddlPressName.DataSource = ds.Tables[0];
            ddlPressName.DataTextField = "PressName";
            ddlPressName.DataValueField = "PressID";
            ddlPressName.DataBind();
        }
 ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (chkExtra.Checked)
                {
                    if (ddlPlateFor.SelectedValue == "F")
                    {
                        rd.Load(Server.MapPath(@"~/Reports/PRO/rptPrintPrintingExtraPlateSypplyOrder.rpt"));
                    }
                    else if(ddlPlateFor.SelectedValue=="C")
                    {
                        rd.Load(Server.MapPath(@"~/Reports/PRO/rptPrintOrderToPressCover_ExtraPlate.rpt"));
                    }
                    else
                    { }
                }
                else
                {
                    if(ddlPlateFor.SelectedValue=="F")
                    {
                        rd.Load(Server.MapPath(@"~/Reports/PRO/rptPrintPrintingOrderForma.rpt"));
                    }
                    else if(ddlPlateFor.SelectedValue=="C")
                    {
                        rd.Load(Server.MapPath(@"~/Reports/PRO/rptPrintOrderToPressCover.rpt"));
                    }
                    else
                    { }
                }

                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@PrintOrder", txtOrderNo.Text);
                rd.SetParameterValue("@PressID", ddlPressName.SelectedValue);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Forma Printing Order");
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