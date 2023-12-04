using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmEmpProfesionCertf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    

                    LoadComboData.LoadEmployeeInfo(ddlEmployee);
                    gvProfessionalCertificates.DataSource = Li_EmpProfessionalCertifManager.LoadGvProfessionalCertificate();
                    gvProfessionalCertificates.DataBind();
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



                if (txtCertification.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Certification.');", true);
                    return;
                }


                if (File1.PostedFile.FileName == null || File1.PostedFile.FileName =="" )
                {
                    string SaveLocation = "";
                }



                else if (File1.PostedFile.ContentLength > 0)
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




                Li_EmpProfessionalCertif empProfCertf = new Li_EmpProfessionalCertif();
                empProfCertf.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empProfCertf.CreatedDate = DateTime.Now;
                empProfCertf.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empProfCertf.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empProfCertf.ModifiedDate = DateTime.Now;
                empProfCertf.Certification = txtCertification.Text;
                empProfCertf.ProQuaId = 0;
                empProfCertf.EmpSl = int.Parse(ddlEmployee.SelectedValue);
                empProfCertf.InstituteName = txtInstituteName.Text;
                empProfCertf.Location =  txtLocation.Text;
                empProfCertf.CertificationPeriod = txtCertificationPeriod.Text;
                empProfCertf.CertifPath = "~/CertificateFile/" + File1.PostedFile.FileName;
                empProfCertf.IsMembership = chkIsMembership.Checked ? true : false;
                Li_EmpProfessionalCertifManager.InsertLi_EmpProfessionalCertif(empProfCertf);


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