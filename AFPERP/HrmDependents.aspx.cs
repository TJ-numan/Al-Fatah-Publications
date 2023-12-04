using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmDependents : System.Web.UI.Page
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

                    gvwDependents.DataSource = Li_DependentManager.LoadGvDependents();
                    gvwDependents.DataBind();
 

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



                if (txtDependentName.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Dependent name.');", true);
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




                Li_Dependent dependent = new Li_Dependent();
                dependent.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                dependent.CreatedDate = DateTime.Now;
                dependent.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                dependent.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                dependent.ModifiedDate = DateTime.Now;
                dependent.DepenName = txtDependentName.Text;
                dependent.DepenId = 0;
                dependent.EmpSl = int.Parse(ddlEmployee.SelectedValue);
                dependent.Relation = txtRelation.Text;
                dependent.DoB = DateTime.Parse(txtDateOfBirth.Text);
                dependent.CertificateNo = txtCertificateNo.Text;
                dependent.CertifPath = "~/CertificateFile/" + File1.PostedFile.FileName;
                Li_DependentManager.InsertLi_Dependent(dependent);


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



                if (txtDependentName.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Dependent name.');", true);
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




                Li_Dependent dependent = new Li_Dependent();
                dependent.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                dependent.CreatedDate = DateTime.Now;
                dependent.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                dependent.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                dependent.ModifiedDate = DateTime.Now;
                dependent.DepenName = txtDependentName.Text;
                dependent.DepenId = Int32.Parse(txtDependentId.Text);
                dependent.EmpSl = int.Parse(ddlEmployee.SelectedValue);
                dependent.Relation = txtRelation.Text;
                dependent.DoB = DateTime.Parse(txtDateOfBirth.Text);
                dependent.CertificateNo = txtCertificateNo.Text;
                dependent.CertifPath = "~/CertificateFile/" + File1.PostedFile.FileName;
                Li_DependentManager.InsertLi_Dependent(dependent);


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