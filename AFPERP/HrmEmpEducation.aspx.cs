using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;

namespace BLL
{
    public partial class HrmEmpEducation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    LoadComboData.LoadEmployeeInfo(ddlEmployee);
                    LoadComboData.LoadEducationLevel(ddlEducationLevel);
                    LoadComboData.LoadExamTitle(ddlExamination);
                    LoadComboData.LaodEduResult(ddlEduResult);
                    gvEmpEducation.DataSource = Li_EmpEducationManager.LoadGvEmployeeEducation();
                    gvEmpEducation.DataBind();
                }
            }
            catch (Exception)
            {
                
                 
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Li_EmpEducation empEducation = new Li_EmpEducation();
                empEducation.Achievement = txtAchievement.Text;
                empEducation.CertifPath = "";
                empEducation.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empEducation.CreatedDate = DateTime.Now;
                empEducation.EduId = 0;
                empEducation.EduLId = Int32.Parse(ddlEducationLevel.SelectedValue);
                empEducation.EduReId = Int32.Parse(ddlEduResult.SelectedValue);
                empEducation.EmpSl = Int32.Parse(ddlEmployee.SelectedValue);
                empEducation.ExamId = Int32.Parse(ddlExamination.SelectedValue);
                empEducation.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empEducation.InstituteName = txtInstituteName.Text;
                empEducation.IsForeign = chkIsForeign.Checked;
                empEducation.MajorOrGroup = txtMajorOrGroup.Text;
                empEducation.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empEducation.ModifiedDate = DateTime.Now;
                empEducation.PassYr = txtPassingYear.Text;
                Li_EmpEducationManager.InsertLi_EmpEducation(empEducation);

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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}