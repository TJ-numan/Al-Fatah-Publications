using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL;
using Common;

namespace BLL
{
    public partial class MktRoutePlan : System.Web.UI.Page
    {
        string FormID = "MF022";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");

                DataSet ds1 = new DataSet();

                ds1 = DemLocationManager.getRoutePlanMappings(0, 0);

                Dictionary<int, string> dcUnit = new Dictionary<int, string>();


                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        dcUnit.Add(int.Parse(ds1.Tables[0].Rows[i]["PlanID"].ToString()), ds1.Tables[0].Rows[i]["Location"].ToString());
                    }
                }

                ddlUnitName.DataSource = new BindingSource(dcUnit, null);
                ddlUnitName.DataTextField = "Value";
                ddlUnitName.DataValueField = "Key";
                ddlUnitName.Items.Insert(0, new ListItem("-Select-", "0"));
                ddlUnitName.DataBind();

                getUserAccess();
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
        protected void ddlUnitName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds3 = new DataSet();
                ds3 = DemLocationManager.getRoutePlanMappings(Convert.ToInt32(ddlUnitName.SelectedValue), Convert.ToInt32(ddlDemarcationStep.SelectedValue));
                Dictionary<int, string> dcLoc = new Dictionary<int, string>();
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                    {
                        dcLoc.Add(int.Parse(ds3.Tables[0].Rows[i]["PlanID"].ToString()), ds3.Tables[0].Rows[i]["Location"].ToString());
                    }
                }

                ddlDemarcationName.DataSource = new BindingSource(dcLoc, null);
                ddlDemarcationName.DataTextField = "Value";
                ddlDemarcationName.DataValueField = "Key";
                ddlDemarcationName.SelectedIndex = -1;
                ddlDemarcationName.DataBind();
            }
            catch (Exception)
            {


            }
        }
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {

        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (gvPoints.Rows.Count > 0)
                {

                    Li_RoutePlanDetails routePlan = new Li_RoutePlanDetails();
                    routePlan.PlanID = int.Parse(ddlDemarcationName.SelectedValue.ToString());
                    routePlan.RouteID = 0;
                    routePlan.RouteName = txtRouteName.Text;
                    routePlan.IsActive = true;
                    routePlan.CreatedBy = (int) Session["UserID"];
                    routePlan.CreatedDate = DateTime.Now;
                    int result = Li_RoutePlanDetailsManager.InsertLi_RoutePlanDetails(routePlan);

                    for (int i = 0; i < gvPoints.Rows.Count; i++)
                    {
                        Li_Points point = new Li_Points();
                        point.PointName = gvPoints.Rows[i].Cells[0].ToString();
                        point.PointAddress = gvPoints.Rows[i].Cells[1].ToString();
                        point.RouteID = result;
                        point.IsStartPoint = bool.Parse(gvPoints.Rows[i].Cells[2].ToString());
                        point.IsEndPoint = bool.Parse(gvPoints.Rows[i].Cells[3].ToString());
                        point.Remarks = gvPoints.Rows[i].Cells[4].ToString();
                        point.PointsID = (int)Session["UserID"];
                        Li_PointsManager.InsertLi_Points(point);

                    }
                }
                string message = "Saved Successfully";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
                txtRouteName.Focus();

            }
            catch (Exception)
            {


            }
        }

       
    }
}