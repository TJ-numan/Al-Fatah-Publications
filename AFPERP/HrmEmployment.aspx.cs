using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmEmployment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    ddlInfoStatus.DataBind();

                    LoadComboData.LoadEmployeeInfo(ddlEmployee);
                    ddlEmployee.DataBind();

                    gvEmployment.DataSource = Li_EmploymentManager.LoadGvEmployment();
                    gvEmployment.DataBind();

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(ddlInfoStatus.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information Status.');", true);
                    return;
                }

                if (Int32.Parse(ddlEmployee.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Employee');", true);
                    return;
                }



                if (txtCompanyName.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Company Name.');", true);
                    return;
                }




                Li_Employment employment = new Li_Employment();
                employment.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                employment.CreatedDate = DateTime.Now;
                employment.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                employment.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                employment.ModifiedDate = DateTime.Now;
                employment.CompName = txtCompanyName.Text;
                employment.ExperId = 0;
                employment.EmpSl = int.Parse(ddlEmployee.SelectedValue);
                employment.CompBusiness = txtCompanyBusiness.Text;
                employment.Designation = txtDesignation.Text;
                employment.Department = txtDepartment.Text;
                employment.Responsibilities = txtResponsibilities.Text;
                employment.ComLocation = txtCompLocation.Text;
                employment.EmployPeriod = txtJobPeriod.Text;
                employment.IsCurrentlyWorking = chkIsCurWorking.Checked ? true : false;
                employment.AreaOfExperi = txtAreaOfExperience.Text;
                Li_EmploymentManager.InsertLi_Employment(employment);


                string message = "Saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                script, true);
            }
            catch (Exception)
            {


            }
        }
    }
}