using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL;
using Common;
using System.Data;

namespace BLL
{
    public partial class MktRouteMapping : System.Web.UI.Page
    {
        string FormID = "MF021";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadCompany();
                    LoadDemarcationStep();
                    dgvRouteMaping.DataSource = Li_RotePlanManager.getRouteMappings(0, 0, "").Tables[0];

                }
            }
            catch (Exception)
            {


            }   
           
        }
        private void getUserAccess()
        {
            DataTable dt = Li_AdminUserManager.GetUserAccess(int.Parse(Session["UserID"].ToString()), FormID).Tables[0];
            if (dt.Rows.Count > 0)
            {

                if (Session["UserID"].ToString() == dt.Rows[0]["UserID"].ToString() && FormID == dt.Rows[0]["FormId"].ToString())
                {
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                    if (Boolean.Parse(dt.Rows[0]["Insert_"].ToString()) == true)
                    {
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Update_"].ToString()) == true)
                    {
                        //btnUpdate.Enabled = true;
                    }
                    else
                    {
                        //btnUpdate.Enabled = false;
                    }
                    if (Boolean.Parse(dt.Rows[0]["Delete_"].ToString()) == true)
                    {
                        //btnDelete.Enabled = true;
                    }
                    else
                    {
                        //btnDelete.Enabled = false;
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadDemarcationStep()
        {
            ddlDemarcationStep.DataSource = Li_DemercationManager.GetAllLi_Demercations();
            ddlDemarcationStep.DataTextField = "DemName";
            ddlDemarcationStep.DataValueField = "DemID";
            ddlDemarcationStep.DataBind();           
        }

        private void LoadCompany()
        {
            
            ddlUnitName.DataSource = Li_CompanyManager.GetAllLi_Companies();
            ddlUnitName.DataTextField = "CompanyName";
            ddlUnitName.DataValueField = "CompanyID";
            ddlUnitName.DataBind();
          
        }
        protected void ddlDemarcationStep_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlDemarcationLocation.DataSource = DemLocationManager.GetLocationsByDemarcation(int.Parse(ddlDemarcationStep.SelectedValue.ToString()));
                ddlDemarcationLocation.DataTextField = "Location";
                ddlDemarcationLocation.DataValueField = "locID";
                ddlDemarcationLocation.DataBind();
               
            }
            catch (Exception)
            {


            }
        }
        protected void ddlDemarcationLocation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        }
       
        private Li_RotePlan li_RotePlan;
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                li_RotePlan = new Li_RotePlan();
                li_RotePlan.CompanyID = Convert.ToInt32(ddlUnitName.SelectedValue);
                li_RotePlan.DemarcationID = Convert.ToInt32(ddlDemarcationStep.SelectedValue);
                li_RotePlan.LocationID = ddlDemarcationLocation.SelectedValue.ToString();
                li_RotePlan.MadeBy = txtMadeBy.Text;
                li_RotePlan.VerifiedBy = txtVerifiedBy.Text;
                li_RotePlan.CreatedBy = int.Parse(Session["UserID"].ToString()); ;
                li_RotePlan.CreatedDate = DateTime.Now;
                Li_RotePlanManager.InsertLi_RotePlan(li_RotePlan);
                string message = "Saved Data Successfully";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";              
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
                dgvRouteMaping.DataSource =
                   Li_RotePlanManager.getRouteMappings(int.Parse(ddlUnitName.SelectedValue.ToString()),
                   int.Parse(ddlDemarcationStep.SelectedValue.ToString()),
                   ddlDemarcationLocation.SelectedValue.ToString()).Tables[0];
                ddlUnitName.Focus();
             
            }
            catch (Exception)
            {


            }
        }
       
     

       
    }
}