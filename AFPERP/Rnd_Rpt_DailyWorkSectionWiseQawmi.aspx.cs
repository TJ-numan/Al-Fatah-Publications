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
using System.Data.SqlClient;

namespace BLL
{
    public partial class Rnd_Rpt_DailyWorkSectionWiseQawmi : System.Web.UI.Page
    {
        string FormID = "RF008";
        DataAccessObject DAO = new DataAccessObject();
        //int sectionID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            getUserAccess();
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                try
                {
                    dtpToDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    LoadSection();
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
                        Response.Redirect("~/RandDHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadSection()
        {
            ddlSection.DataSource = Li_SectionManager.LoadAllSectionQawmi();
            ddlSection.DataTextField = "SectionName";
            ddlSection.DataValueField = "SectionID";
            ddlSection.DataBind();
            ddlSection.Items.Insert(0, new ListItem("--Select--", ""));
        }
        ReportDocument rd = new ReportDocument();
        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (ddlSection.SelectedValue == "0")
                {
                    rd.Load(Server.MapPath(@"~/Reports/RND/rptDailyWorkReportBySectionQawmi.rpt"));
                }
                else
                {
                    rd.Load(Server.MapPath(@"~/Reports/RND/rptDailyWorkReportByIndividualSectionQawmi.rpt"));
                }

                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@From", dtpFromDate.Text);
                rd.SetParameterValue("@To", dtpToDate.Text);
                rd.SetParameterValue("@EmployeeID", "0");
                rd.SetParameterValue("@SectionID", ddlSection.SelectedValue);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Section Work");
                rd.Close();
                rd.Dispose();
            }
            catch (Exception ex)
            {

            }

        }

        protected void btnDownloadExcel_Click(object sender, EventArgs e)
        {
            DataTable dtexcel = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.DAO.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_li_rptRND_DailyReportBySectionQawmi", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@From", SqlDbType.VarChar).Value = dtpFromDate.Text;
                command.Parameters.Add("@To", SqlDbType.VarChar).Value = dtpToDate.Text;
                command.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = "0";
                command.Parameters.Add("@SectionID", SqlDbType.Int).Value = ddlSection.SelectedValue;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(dtexcel);

                //For Excel Download Start Created By Md. Ruhul Amin and Created Date: 06/06/2023
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=QawmiSectionWiseDailyWorks.xls");
                Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                using (System.IO.StringWriter sw = new System.IO.StringWriter())
                {
                    using (System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw))
                    {
                        GridView grid = new GridView();
                        grid.DataSource = dtexcel;
                        grid.DataBind();
                        grid.RenderControl(htw);
                        Response.Write(sw.ToString());
                    }
                }
                Response.End();
                //For Excel Download Start End

                myadapter.Dispose();
                connection.Close();


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