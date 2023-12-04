using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmEmployeeSkills : System.Web.UI.Page
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
                    gvEmpSkill.DataSource = Li_EmpSkillsManager.LoadGvEmpSkill();
                    gvEmpSkill.DataBind();
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



                if (txtSkillTitle.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Skill Title.');", true);
                    return;
                }




                Li_EmpSkills empSkill = new Li_EmpSkills();
                empSkill.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empSkill.CreatedDate = DateTime.Now;
                empSkill.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empSkill.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empSkill.ModifiedDate = DateTime.Now;
                empSkill.Skills = txtSkillTitle.Text;
                empSkill.SkilId = 0;
                empSkill.EmpSl = int.Parse(ddlEmployee.SelectedValue);
                empSkill.SkilDes = txtSkillDescription.Text;
                empSkill.ExtraActivities = txtExtrActivities.Text;
                Li_EmpSkillsManager.InsertLi_EmpSkills(empSkill);


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