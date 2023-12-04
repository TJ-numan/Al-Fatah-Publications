using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmHoliday : System.Web.UI.Page
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

                if (txtHolidayTitle.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Holiday Title');", true);
                    return;
                }






                Li_Holiday holiday = new Li_Holiday();
                holiday.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                holiday.CreatedDate = DateTime.Now;
                holiday.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                holiday.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                holiday.ModifiedDate = DateTime.Now;
                holiday.HoliId = 0;
                holiday.LocId = Int32.Parse(ddlLocation.SelectedValue);
                holiday.HoliDayTitle = txtHolidayTitle.Text;
                holiday.StDate = DateTime.Parse(txtStartDate.Text);
                holiday.EnDate= DateTime.Parse(txtEndDate.Text);
                holiday.Comments = txtComments.Text;
                Li_HolidayManager.InsertLi_Holiday(holiday);


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