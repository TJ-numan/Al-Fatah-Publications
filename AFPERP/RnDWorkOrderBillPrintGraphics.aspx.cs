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
    public partial class RnDWorkOrderBillPrintGraphics : System.Web.UI.Page
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

                    getUserAccess();
                    string toDay = DateTime.Now.ToString("yyyy-MM-dd");
                    gvDateWiseWorkOrderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderBillPrintInfoByOrderNoGraphics(txtEmpName.Text.ToString(), int.Parse(Session["UserID"].ToString()));
                    gvDateWiseWorkOrderDetails.DataBind();



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
                        //btnShow.Enabled = true;
                    }
                    else
                    {
                        //btnShow.Enabled = false;
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
                //Response.Redirect("~/RandDHome.aspx");
            }
        }
        protected void gvDateWiseWorkDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }
        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gvDateWiseWorkOrderDetails.DataSource = Li_RnDWorkOrderDetailsManager.GetLi_RnDWorkOrderBillPrintInfoByOrderNoGraphics(txtEmpName.Text.ToString(), int.Parse(Session["UserID"].ToString()));
                gvDateWiseWorkOrderDetails.DataBind();

            }
            catch (Exception)
            {


            }

        }
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        protected void gvDateWiseWorkDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    GridViewRow row = gvDateWiseWorkOrderDetails.SelectedRow;
                    ViewState["BillNo"] = row.Cells[3].Text;
                    rd.Load(Server.MapPath(@"~/Reports/RND/rptPrintWorkOrderBillStatusRzGraphics.rpt"));
                    //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
                    rd.DataSourceConnections.Clear();
                    rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                    rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                    rd.SetParameterValue("@WorkOrderID", Int32.Parse(ViewState["BillNo"].ToString()));
                    rd.SetParameterValue("@UserID", Int32.Parse(Session["UserID"].ToString()));
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "PrintRnDWorkOrderBill");
                    rd.Close();
                    rd.Dispose();
                }
                catch (Exception)
                {

                }
            }
            catch (Exception)
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