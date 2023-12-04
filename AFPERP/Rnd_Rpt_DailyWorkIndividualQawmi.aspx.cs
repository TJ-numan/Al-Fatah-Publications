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
    public partial class Rnd_Rpt_DailyWorkIndividualQawmi : System.Web.UI.Page
    {
        string FormID = "RF007";
        DataAccessObject DAO = new DataAccessObject();
        int sectionID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                try
                {
                    dtpToDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    LoadSection();
                    DataTable dts = Li_SectionManager.LoadAllSection();
                    if (dts.Rows.Count > 0)
                    {
                        sectionID = Convert.ToInt32(dts.Rows[0]["SectionID"].ToString());
                        if (sectionID == 0)
                        {
                            ddlSection.Enabled = true;

                        }
                        else
                        {
                            ddlSection.Enabled = false;
                            ddlSection.SelectedValue = sectionID.ToString();
                        }
                    }
                }
                catch (Exception)
                {


                }
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

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int SecID = Int32.Parse(ddlSection.SelectedValue.ToString());

                LoadEmployee(SecID);
            }
            catch (Exception)
            {

            }
        }

        private void LoadEmployee(int id)
        {

            ddlEmployee.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListBySecIDQawmi(id);
            ddlEmployee.DataTextField = "Name";
            ddlEmployee.DataValueField = "EmployeeID";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("--Select--", ""));

        }
        ReportDocument rd = new ReportDocument();
        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            try
            {

                rd.Load(Server.MapPath(@"~/Reports/RND/rptDailyWorkReportByEmployeeIDQawmi.rpt"));
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@From", dtpFromDate.Text);
                rd.SetParameterValue("@To", dtpToDate.Text);
                rd.SetParameterValue("@EmployeeID", ddlEmployee.SelectedValue);
                rd.SetParameterValue("@SectionID", ddlSection.SelectedValue);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Individual Work");
                rd.Close();
                rd.Dispose();
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

        protected void btnDownloadExcel_Click(object sender, EventArgs e)
        {
            DataTable dtexcel = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.DAO.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SMPM_li_rptRND_DailyReportByEmployeeQawmi", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@From", SqlDbType.VarChar).Value = dtpFromDate.Text;
                command.Parameters.Add("@To", SqlDbType.VarChar).Value = dtpToDate.Text;
                command.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = ddlEmployee.SelectedValue;
                command.Parameters.Add("@SectionID", SqlDbType.Int).Value = ddlSection.SelectedValue;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(dtexcel);

                //For Excel Download Start Created By Md. Ruhul Amin and Created Date: 06/06/2023
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=QawmiIndividualDailyWorks.xls");
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
    }
}