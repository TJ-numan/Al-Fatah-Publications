using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmJobDescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    LoadComboData.LoadJobTitle(ddlPosition);
                    LoadComboData.LoadJobDesResponsibility(ddlJobResposibility);
                    LoadComboData.LoadJobDesEducationalReq(ddlEducationReq);
                    LoadComboData.LoadJobDesExperienceReq(ddlExperienceReq);
                    LoadComboData.LoadJobDesRequirment(ddlJobRequirement);
                    LoadComboData.LoadJobDesBenefit(ddlJobBenefit);

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
                if (
            Int32.Parse(ddlInfoStatus.SelectedValue) < 1 ||
            Int32.Parse(ddlEducationReq.SelectedValue) < 1 ||
            Int32.Parse(ddlExperienceReq.SelectedValue) < 1 ||
            Int32.Parse(ddlJobBenefit.SelectedValue) < 1 ||
            Int32.Parse(ddlJobRequirement.SelectedValue) < 1 ||
            Int32.Parse(ddlJobResposibility.SelectedValue) < 1 ||
            Int32.Parse(ddlPosition.SelectedValue) < 1
            )
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information Status.');", true);
                    return;
                }

                Li_JobDescription jd = new Li_JobDescription();
                jd.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                jd.CreatedDate = DateTime.Now;
                jd.EduReqId = Int32.Parse(ddlEducationReq.SelectedValue);
                jd.ExpReqId = Int32.Parse(ddlExperienceReq.SelectedValue);
                jd.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                jd.JDId = 0;
                jd.JobBenId = Int32.Parse(ddlJobBenefit.SelectedValue);
                jd.JobReqId = Int32.Parse(ddlJobRequirement.SelectedValue);
                jd.JobResId = Int32.Parse(ddlJobResposibility.SelectedValue);
                jd.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                jd.ModifiedDate = DateTime.Now;
                jd.PosId = Int32.Parse(ddlPosition.SelectedValue);
                Li_JobDescriptionManager.InsertLi_JobDescription(jd);




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