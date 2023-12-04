using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmExamTitle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    LoadExamLevel();
                    gvwExamTitle.DataSource = Li_ExamTitleManager.GetAllLi_ExamTitles();
                    gvwExamTitle.DataBind();
                }
            }
            catch (Exception)
            {
                 
            }

        }

        private void LoadExamLevel()
        {
            ListItem li = new ListItem("Select Any Level", "0");
            ddlEduLevel.Items.Add(li);
            List<Li_EducationLevel> eduLevels = new List<Li_EducationLevel>();
            eduLevels = Li_EducationLevelManager.GetAllLi_EducationLevels();
            foreach (Li_EducationLevel edulevel in eduLevels)
            {
                ListItem item = new ListItem(edulevel.EduLevelName, edulevel.EduLId.ToString());
                ddlEduLevel.Items.Add(item);
            }
        }

        protected void gvwExamTitle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                    e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));

            }
            catch (Exception)
            {
                
                 
            }
        }

        protected void gvwExamTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
                GridViewRow row = gvwExamTitle.SelectedRow;
                ViewState["ExamId"] = row.Cells[1].Text;

 

                Li_ExamTitle exTitle = new Li_ExamTitle();
                exTitle = Li_ExamTitleManager.GetLi_ExamTitleByID(Int32.Parse(ViewState["ExamId"].ToString()));
                ddlEduLevel.SelectedValue = exTitle.EduLId.ToString ();
                txtExamId.Text = exTitle.ExamId.ToString();
                txtExamTitle.Text = exTitle.ExamName;                
                ddlInfoStatus .SelectedValue  = exTitle.InfStId.ToString();
                btnSave.Enabled = false;

             
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

                if (Int32.Parse(ddlEduLevel.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Exam Level.');", true);
                    return;
                }
                if (txtExamTitle.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Exam Title.');", true);
                    return;
                }


                Li_ExamTitle examTitle = new Li_ExamTitle();
                examTitle.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                examTitle.CreatedDate = DateTime.Now;
                examTitle.EduLId = Int32.Parse(ddlEduLevel.SelectedValue);
                examTitle.ExamId = 0;
                examTitle.ExamName = txtExamTitle.Text;
                examTitle.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                examTitle.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                examTitle.ModifiedDate = DateTime.Now;
                Li_ExamTitleManager.InsertLi_ExamTitle(examTitle);

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

                if (Int32.Parse(ddlEduLevel.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Exam Level.');", true);
                    return;
                }
                if (txtExamTitle.Text.Trim() == "" || txtExamId .Text .Trim ()=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Exam Title.');", true);
                    return;
                }


                Li_ExamTitle examTitle = new Li_ExamTitle(); 
                examTitle.EduLId = Int32.Parse(ddlEduLevel.SelectedValue);
                examTitle.ExamId = Int32 .Parse (txtExamId .Text );
                examTitle.ExamName = txtExamTitle.Text;
                examTitle.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                examTitle.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                examTitle.ModifiedDate = DateTime.Now;
                Li_ExamTitleManager. UpdateLi_ExamTitle(examTitle);

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


    }
}