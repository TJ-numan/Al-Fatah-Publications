
using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmEmpTraining : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {


                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);  
                    LoadComboData.LoadEmployeeInfo(ddlEmployee);
                    gvEmpTraning.DataSource = Li_EmpTrainingManager.LoadGvEmployeeTraining();
                    gvEmpTraning.DataBind();
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


                if (txtTrainTitle.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Training Title.');", true);
                    return;
                }


                if (File1.PostedFile.FileName == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Upload a Certificate file.');", true);
                    return;
                }



                if (File1.PostedFile.ContentLength > 0)
                {
                    string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("CertificateFile") + "\\" + fn;
                    try
                    {
                        File1.PostedFile.SaveAs(SaveLocation);

                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File size too large.');", true);
                    return;
                }




                Li_EmpTraining empTraining = new Li_EmpTraining();
                empTraining.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empTraining.CreatedDate = DateTime.Now;
                empTraining.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empTraining.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empTraining.ModifiedDate = DateTime.Now;
                empTraining.TranTitle = txtTrainTitle.Text;
                empTraining.TranId = 0;
                empTraining.TopicsCov = txtTopicsCover.Text;
                empTraining.InstituteName = txtInstituteName.Text;
                empTraining.CertifPath = "~/CertificateFile/" + File1.PostedFile.FileName;
                empTraining.Location = txtLocation.Text;
                empTraining.Country = txtCountry.Text;
                empTraining.TranYr = txtTrainingYear.Text;
                empTraining.Duration = txtDuration.Text;
                empTraining.EmpSl = Int32.Parse(ddlEmployee.SelectedValue);
                Li_EmpTrainingManager.InsertLi_EmpTraining(empTraining);


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