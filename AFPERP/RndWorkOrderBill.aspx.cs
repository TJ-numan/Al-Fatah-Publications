using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Marketing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using System.Data;

namespace BLL
{
    public partial class RndWorkOrderBill : System.Web.UI.Page
    {
        string FormID = "RF004";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    //dtpFromDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    //dtpToDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
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
        //protected void ddlSection_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (ddlSection.SelectedIndex >= 0)
        //        {

        //            LoadEmployee(int.Parse(ddlSection.SelectedValue.ToString()), int.Parse(ddlEmplyeeFor.SelectedValue.ToString()));
        //        }
        //    }
        //    catch (Exception)
        //    {


        //    }
        //}
        //private void LoadEmployee(int id, int employeer)
        //{

        //    ddlEmpName.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListRZBySecID(id, employeer);
        //    ddlEmpName.DataTextField = "Name";
        //    ddlEmpName.DataValueField = "EmployeeID";
        //    ddlEmpName.DataBind();
        //    ddlEmpName.Items.Insert(0, new ListItem("--Select--", ""));

        //}
        //protected void ddlEmpName_OnTextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (ddlEmpName.SelectedIndex >= 0)
        //        {
        //            LoadDesignation(int.Parse(ddlEmpName.SelectedValue.ToString()));
        //        }
        //    }
        //    catch (Exception)
        //    {


        //    }

        //}
        //protected void ddlEmployeeFor_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlEmplyeeFor.SelectedValue.ToString() == "1")
        //    {
        //        ddlSection.DataSource = Li_SectionManager.LoadAllSection();
        //        ddlSection.DataTextField = "SectionName";
        //        ddlSection.DataValueField = "SectionID";
        //        ddlSection.DataBind();
        //        ddlSection.Items.Insert(0, new ListItem("--Select--", ""));
        //    }
        //    else if (ddlEmplyeeFor.SelectedValue.ToString() == "2")
        //    {
        //        ddlSection.DataSource = Li_SectionManager.LoadHireSection();
        //        ddlSection.DataTextField = "SectionName";
        //        ddlSection.DataValueField = "SectionID";
        //        ddlSection.DataBind();
        //        ddlSection.Items.Insert(0, new ListItem("--Select--", ""));
        //    }
        //}
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            rd.Load(Server.MapPath(@"~/Reports/RND/rptPrintWorkOrderBillStatus.rpt"));
            //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
            rd.DataSourceConnections.Clear();
            rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
            rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
            rd.SetParameterValue("@WorkOrderID", txtWorkID.Text);
            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "PrintRnDWorkOrderBill");
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