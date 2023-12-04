using BLL.Classes;
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
    public partial class HRM_rptEmployeeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadDepartmentsFromEmpInfos(ddlDepartment);

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadComboData.LoadSectionFromEmpInfos(ddlSection, Int32.Parse(ddlDepartment.SelectedValue));

            }
            catch (Exception)
            {


            }
        }

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadComboData.LoadDesignationsFromEmpInfos(ddlDesignation, Int32.Parse(ddlDepartment.SelectedValue), Int32.Parse(ddlSection.SelectedValue));
                LoadComboData.LoadJobCategoryFormEmpInfos(ddlEmploymentStatus, Int32.Parse(ddlDepartment.SelectedValue), Int32.Parse(ddlSection.SelectedValue));
                LoadComboData.LoadJobTitleFromEmpInfos(ddlFuncDesignation, Int32.Parse(ddlDepartment.SelectedValue), Int32.Parse(ddlSection.SelectedValue));
            }
            catch (Exception)
            {


            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlLi_EmployeeInfoProvider empInfoProvider = new SqlLi_EmployeeInfoProvider();
                dt = empInfoProvider.LoadrptGvEmployeeInfo(
                    Int32.Parse(ddlDepartment.SelectedValue),
                    Int32.Parse(ddlSection.SelectedValue),
                    Int32.Parse(ddlDesignation.SelectedValue),
                    Int32.Parse(ddlFuncDesignation.SelectedValue),
                    Int32.Parse(ddlEmploymentStatus.SelectedValue),
                    txtServAgeFrom.Text != "" ? Int32.Parse(txtServAgeFrom.Text) : 0,
                    txtServAgeTo.Text != "" ? Int32.Parse(txtServAgeTo.Text) : 0,
                    Int32 .Parse (ddlDatePart.SelectedValue),
                   txtSalaryRangeFrom.Text != "" ? Int32.Parse(txtSalaryRangeFrom.Text) : 0,
                   txtSalaryRangeTo.Text != "" ? Int32.Parse(txtSalaryRangeTo.Text) : 0);

                gvEmployeeInfo.DataSource = dt;
                gvEmployeeInfo.DataBind();
            }
            catch (Exception)
            {


            }
        }

        protected void gvEmployeeInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvEmployeeInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


        DataAccessObject DAO = new DataAccessObject();


        ReportDocument rd = new ReportDocument();
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                rd.Load(Server.MapPath(@"~/Reports/HRD/rptEmployeeInfoReport.rpt"));
                

                
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@DepId", Int32 .Parse (ddlDepartment.SelectedValue));
                rd.SetParameterValue("@SecId", Int32 .Parse (ddlSection.SelectedValue));
                rd.SetParameterValue("@DesId", Int32 .Parse (ddlDesignation.SelectedValue));
                rd.SetParameterValue("@JotId", Int32 .Parse (ddlFuncDesignation.SelectedValue));
                rd.SetParameterValue("@EmpStId", Int32 .Parse (ddlEmploymentStatus.SelectedValue));
                rd.SetParameterValue("@SerAgeFrom", txtServAgeFrom.Text != "" ? Int32.Parse(txtServAgeFrom.Text) : 0);
                rd.SetParameterValue("@SerAgeTo", txtServAgeTo.Text != "" ? Int32.Parse(txtServAgeTo.Text) : 0);
                rd.SetParameterValue("@DPart", Int32 .Parse (ddlDatePart.SelectedValue));
                rd.SetParameterValue("@SalFrom", txtSalaryRangeFrom.Text != "" ? decimal.Parse(txtSalaryRangeFrom.Text) : 0.0m);
                rd.SetParameterValue("@SalTo", txtSalaryRangeTo.Text != "" ? decimal.Parse(txtSalaryRangeTo.Text) : 0.0m);
                //rd.SetParameterValue("@UserId", Int32.Parse(Session["UserID"].ToString()));
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Employee Information");


                rd.Close();
                rd.Dispose();




            }
            catch (Exception ex)
            {


            }
        }


    }
}