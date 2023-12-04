using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmWeekend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    ddlInfoStatus.DataBind();

                    LoadComboData.LoadJobLocation(ddlLocation);
                    ddlLocation.DataBind();

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



                if (Int32.Parse(ddlLocation.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Location');", true);
                    return;
                }

                if (txtWeekendDay.Text=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid WeekendDay');", true);
                    return;
                }






                Li_Weekend weekend = new Li_Weekend();
                weekend.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                weekend.CreatedDate = DateTime.Now;
                weekend.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                weekend.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                weekend.ModifiedDate = DateTime.Now;
                weekend.WekDayId = 0;
                weekend.LocId = Int32.Parse(ddlLocation.SelectedValue);
                weekend.DayName = txtWeekendDay.Text;
                weekend.IsWorkingDay = chkIsWorkingDay.Checked ? true : false;
                weekend.IsHalfDay = chkIsHalfDay.Checked ? true : false;
                Li_WeekendManager.InsertLi_Weekend(weekend);


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