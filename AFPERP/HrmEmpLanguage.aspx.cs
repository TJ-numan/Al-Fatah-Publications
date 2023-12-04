using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmEmpLanguage : System.Web.UI.Page
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

                    gvEmpLanguage.DataSource = Li_EmpLanguageManager.LoadGvEmployeeLanguage();
                    gvEmpLanguage.DataBind();


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



                if (txtLanguge.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Language Name.');", true);
                    return;
                }




                Li_EmpLanguage empLanguage = new Li_EmpLanguage();
                empLanguage.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empLanguage.CreatedDate = DateTime.Now;
                empLanguage.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empLanguage.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empLanguage.ModifiedDate = DateTime.Now;
                empLanguage.Language = txtLanguge.Text;
                empLanguage.LanId = 0;
                empLanguage.EmpSl = int.Parse(ddlEmployee.SelectedValue);
                empLanguage.Reading = txtReading.Text;
                empLanguage.Writing = txtWritting.Text;
                empLanguage.Speaking = txtSpeaking.Text;
                Li_EmpLanguageManager.InsertLi_EmpLanguage(empLanguage);


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