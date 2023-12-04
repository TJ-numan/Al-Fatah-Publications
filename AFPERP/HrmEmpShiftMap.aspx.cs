using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmEmpShiftMap : System.Web.UI.Page
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

                    LoadComboData.LoadOffSchedule(ddlOffSchedule);
                    ddlOffSchedule.DataBind();
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

                if (Int32.Parse(ddlOffSchedule.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Schedule');", true);
                    return;
                }




                Li_EmpShiftMap empShiftMap = new Li_EmpShiftMap();
                empShiftMap.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empShiftMap.CreatedDate = DateTime.Now;
                empShiftMap.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empShiftMap.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empShiftMap.ModifiedDate = DateTime.Now;
                empShiftMap.EmpMapId = 0;
                empShiftMap.EmpSl = int.Parse(ddlEmployee.SelectedValue);
                empShiftMap.ShiftId = int.Parse(ddlOffSchedule.SelectedValue);
                Li_EmpShiftMapManager.InsertLi_EmpShiftMap(empShiftMap);


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