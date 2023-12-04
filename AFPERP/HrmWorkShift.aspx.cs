using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmWorkShift : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    LoadComboData.LoadOffSchedule( ddlScheduleId);
                    LoadWorkShift();
                }
                catch (Exception)
                {


                }
            } 
        }

        private void LoadWorkShift()
        {
            gvwWorkShift.DataSource = Li_WorkShiftManager.GetAllLi_WorkShifts();
            gvwWorkShift.DataBind();
        }




        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlInfoStatus.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid info status.');", true);
                    return;
                }

                if (txtWorkShift.Text.Trim() == "" || txtStartingTime .Text .Trim ()=="" || txtEndingTime .Text .Trim ()=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Department Name');", true);
                    return;
                }

                Li_WorkShift  workShift = new  Li_WorkShift ();
                workShift.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                workShift.CreatedDate = DateTime.Now;
                workShift.WkShfId = 0;
                workShift. WkShfDes = txtWorkShift.Text;
                workShift.WkShfStartT =  txtStartingTime.Text ;
                workShift.WkShfEndT =  txtEndingTime.Text ;
                workShift.MinStayHour = decimal .Parse (txtMinStatyHr .Text );
                workShift.SchedId = Int32 .Parse (ddlScheduleId.SelectedValue );
                workShift.GraceMinute = Int32 .Parse (txtGraceMinutes.Text);
                workShift.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                workShift.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                workShift.ModifiedDate = DateTime.Now;
                Li_WorkShiftManager  . InsertLi_WorkShift (workShift );


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
                if (ddlInfoStatus.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid info status.');", true);
                    return;
                }

                if (txtWorkShift.Text.Trim() == "" || txtStartingTime.Text.Trim() == "" || txtEndingTime.Text.Trim() == "" || txtWorkShiftId .Text.Trim ()=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Data ');", true);
                    return;
                }

                Li_WorkShift workShift = new Li_WorkShift();
 
                workShift.WkShfId = Int32 .Parse (txtWorkShiftId .Text );
                workShift.WkShfDes = txtWorkShift.Text;
                workShift.WkShfStartT = txtStartingTime.Text ;
                workShift.WkShfEndT =  txtEndingTime.Text ;
                workShift.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                workShift.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                workShift.ModifiedDate = DateTime.Now;
                Li_WorkShiftManager.UpdateLi_WorkShift(workShift);


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

        protected void gvwWorkShift_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
				
				
        }

        protected void gvwWorkShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gvwWorkShift.SelectedRow;
                ViewState["WkShfId"] = row.Cells[1].Text;
                Li_WorkShift wShift = new Li_WorkShift();
                wShift = Li_WorkShiftManager.GetLi_WorkShiftByID(Int32.Parse(ViewState["WkShfId"].ToString()));
                txtWorkShiftId.Text = wShift.WkShfId.ToString();
                txtWorkShift.Text = wShift.WkShfDes;
                txtStartingTime.Text = wShift.WkShfStartT.ToString();
                txtEndingTime.Text = wShift.WkShfEndT.ToString();
            }
            catch (Exception)
            {
                                
            }
 

        }
    }
}