using BLL.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BLL
{
    public partial class HrmLetterTemplate : System.Web.UI.Page
    {

        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    gvwLetterTemplate.DataSource = Li_LetterTemplateManager.GetAllLi_LetterTemplates();
                    gvwLetterTemplate.DataBind();
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
                if (Int32.Parse(ddlInfoStatus.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information Status.');", true);
                    return;
                }


               
                if (txtLetTempName.Text.Trim() == ""  )
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid template name.');", true);
                    return;
                }
 

                if (File1.PostedFile.FileName == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Select a template file.');", true);
                    return;
                }



                if  (File1.PostedFile.ContentLength > 0) 
                {
                    string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("LetterTemplate") + "\\" + fn;
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

                 
 

                Li_LetterTemplate letterTemplate = new Li_LetterTemplate();
                letterTemplate.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                letterTemplate.CreatedDate = DateTime.Now;
                letterTemplate.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                letterTemplate.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                letterTemplate.ModifiedDate = DateTime.Now;
                letterTemplate.TempDes = txtTemplateDes.Text;
                letterTemplate.TempId = 0;
                letterTemplate.TempName = txtLetTempName.Text;
                letterTemplate.TempPath = "~/LetterTemplate/" + File1.PostedFile.FileName;
                Li_LetterTemplateManager.InsertLi_LetterTemplate(letterTemplate);


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



                if (txtLetTempName.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid template name.');", true);
                    return;
                }


                if (File1.PostedFile != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Select a template file.');", true);
                    return;
                }



                if (File1.PostedFile.ContentLength > 0 )
                {
                    string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("LetterTemplate") + "\\" + fn;
                    try
                    {
                        File1.PostedFile.SaveAs(SaveLocation);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File already exist.');", true);
                       
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('File size too large.');", true);
                    return;
                }





                Li_LetterTemplate letterTemplate = new Li_LetterTemplate();
                letterTemplate.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                letterTemplate.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                letterTemplate.ModifiedDate = DateTime.Now;
                letterTemplate.TempDes = txtTemplateDes.Text;
                letterTemplate.TempId = Int32.Parse(txtLetTempNameId.Text);
                letterTemplate.TempName = txtLetTempName.Text;
                letterTemplate.TempPath = Server.MapPath("~/LetterTemplate/") + File1.PostedFile.FileName;
                Li_LetterTemplateManager.UpdateLi_LetterTemplate(letterTemplate);

                string message = "Updated successfully.";
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

        protected void gvwLetterTemplate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));


        }

        protected void gvwLetterTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwLetterTemplate.SelectedRow;
                ViewState["TempId"] = row.Cells[1].Text;

                Li_LetterTemplate letterTemplate = new Li_LetterTemplate();
                letterTemplate = Li_LetterTemplateManager.GetLi_LetterTemplateByID(Int32.Parse(ViewState["TempId"].ToString()));

                txtLetTempName.Text = letterTemplate.TempName;
                txtLetTempNameId.Text = letterTemplate.TempId.ToString();
                txtTemplateDes.Text = letterTemplate.TempDes;
                ddlInfoStatus.SelectedValue = letterTemplate.InfStId.ToString();
                btnSave.Enabled = false;



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}