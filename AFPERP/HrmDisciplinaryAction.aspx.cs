using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmDisciplinaryAction : System.Web.UI.Page
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

                    LoadComboData.LoadEmploymentStatus(ddlEmploymentSt);
                    ddlEmploymentSt.DataBind();

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



                if (txtActionTitle.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Action Title.');", true);
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




                Li_DisciplinaryAction dsplAction = new Li_DisciplinaryAction();
                dsplAction.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                dsplAction.CreatedDate = DateTime.Now;
                dsplAction.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                dsplAction.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                dsplAction.ModifiedDate = DateTime.Now;
                dsplAction.ActionTitle = txtActionTitle.Text;
                dsplAction.DisAcId = 0;
                dsplAction.EmpSl = int.Parse(ddlEmployee.SelectedValue);
                dsplAction.EmploymentStId = int.Parse(ddlEmploymentSt.SelectedValue);
                dsplAction.ActionDes = txtActionDescr.Text;
                dsplAction.AcDocPath = "~/CertificateFile/" + File1.PostedFile.FileName;
                Li_DisciplinaryActionManager.InsertLi_DisciplinaryAction(dsplAction);


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