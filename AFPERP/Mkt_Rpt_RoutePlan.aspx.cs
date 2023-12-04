using BLL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BLL
{
    public partial class Mkt_Rpt_RoutePlan : System.Web.UI.Page
    {
        string FormID = "MR039";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    try
                    {
                        getUserAccess();
                        GetCompanyName();
                    }
                    catch (Exception)
                    {

                    }
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
                    if (Boolean.Parse(dt.Rows[0]["Insert_"].ToString()) == true)
                    {
                        btnPrint.Enabled = true;
                    }
                    else
                    {
                        btnPrint.Enabled = false;
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
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        public void GetCompanyName()
        {

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
            ddlUnitName.DataTextField   = "Value";
            ddlUnitName.DataValueField = "Key";
            ddlUnitName.DataBind();
         
        }

        protected void ddlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds2 = new DataSet();
                ds2 = DemLocationManager.getRoutePlanMappings(Convert.ToInt32(ddlUnitName .SelectedValue), 0);
                Dictionary<int, string> dcDem = new Dictionary<int, string>();
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        dcDem.Add(int.Parse(ds2.Tables[0].Rows[i]["PlanID"].ToString()), ds2.Tables[0].Rows[i]["Location"].ToString());
                    }
                }

                ddlDemarcationStep.DataSource = new BindingSource(dcDem, null);
                ddlDemarcationStep.DataTextField  = "Value";
                ddlDemarcationStep.DataValueField = "Key";
                ddlDemarcationStep .DataBind();
            }
            catch (Exception)
            {


            }
        }

        protected void ddlDemarcationStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds3 = new DataSet();
                ds3 = DemLocationManager.getRoutePlanMappings(Convert.ToInt32(ddlUnitName.SelectedValue), Convert.ToInt32( ddlDemarcationStep.SelectedValue));
                Dictionary<int, string> dcLoc = new Dictionary<int, string>();
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                    {
                        dcLoc.Add(int.Parse(ds3.Tables[0].Rows[i]["PlanID"].ToString()), ds3.Tables[0].Rows[i]["Location"].ToString());
                    }
                }

                ddlDemarcationName .DataSource = new BindingSource(dcLoc, null);
                ddlDemarcationName .DataTextField  = "Value";
                ddlDemarcationName .DataValueField  = "Key";
                ddlDemarcationName .DataBind();
            }
            catch (Exception)
            {


            }
        }
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                
       
                rd.Load(Server.MapPath(@"~/Reports/MKT/rptRoutePlanDetail.rpt"));

            
 

                //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@CompanyID", Convert .ToInt32 (    ddlUnitName.SelectedValue.ToString ()));
                rd.SetParameterValue("@DemarcationID", Convert .ToInt32 ( ddlDemarcationStep.SelectedValue.ToString ()));
                rd.SetParameterValue("@LocationID", ddlDemarcationName.SelectedValue.ToString ());
 
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Route Plan");
                rd.Close();
                rd.Dispose();

            }
            catch (Exception ex)
            { 

            } 
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            try
            {
                rd.Dispose();
            }
            catch (Exception)
            {


            }
        }
    }
}