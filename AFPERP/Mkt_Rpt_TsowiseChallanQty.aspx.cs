using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using System.Data;

namespace BLL
{
    public partial class Mkt_Rpt_TsowiseChallanQty : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        string FormID = "MR019";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadTeritory();
                    LoadBook();
                    LoadYear();

                    int year = DateTime.Now.Year;
                    int month = DateTime.Now.Month;
                    int day = DateTime.Now.Day;

                    if (month >= 11)
                    {
                        var mydate = new DateTime(year, 11, 01);

                        dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    }

                    else
                    {
                        var mydate = new DateTime(year - 1, 11, 01);
                        dtpFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    }
                    dtpToDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
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
                        btnShow.Enabled = true;
                    }
                    else
                    {
                        btnShow.Enabled = false;
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

        private void LoadTeritory()
        {

            try
            {
                ddlTeritory.DataSource = Li_TeritoryManager.GetAllLi_TeritoryByUserID(int.Parse(Session["UserID"].ToString()));
                ddlTeritory.DataTextField = "Name";
                ddlTeritory.DataValueField = "TeritoryCode";
                ddlTeritory.DataBind();
                ddlTeritory.Items.Insert(0, new ListItem("--Select--", ""));
            }
            catch (Exception ex)
            {
                
            }
        }

        private void LoadBook()
        {
            try
            {
                ddlBookName.DataSource = li_BookInformationManager.Get_BookInformations_ComboSourceData();
                ddlBookName.DataTextField = "BookName";
                ddlBookName.DataValueField = "BookID";
                ddlBookName.DataBind();
            }
            catch (Exception)
            {

            }
        }
        private void LoadYear()
        {
            try
            {
                ddlEdition.DataSource = li_ChallanManager.LoadYear().Tables[0];
                ddlEdition.DataTextField = "Edition";
                ddlEdition.DataBind();
            }
            catch (Exception ex)
            {
                
            }

        }
 
  ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
              

                rd.Load(Server.MapPath(@"~/Reports/MKT/rptTSOChalan.rpt"));

                //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections.Clear();
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@fromDate", dtpFromDate.Text);
                rd.SetParameterValue("@toDate", dtpToDate.Text);
                rd.SetParameterValue("@TSOID", ddlTso.SelectedValue);
                //rd.SetParameterValue("@BookID", ddlBookName.SelectedValue);
                //rd.SetParameterValue("@edition", ddlEdition.SelectedValue);        
                //rd.SetParameterValue("@userID", int.Parse(Session["UserID"].ToString()));
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "TsowiseChalanQtyReport");

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
        protected void ddlTeritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlTso.DataSource = Li_SalesPersonManager.GetLi_SalesPersonByID(ddlTeritory.SelectedValue.ToString());
                ddlTso.DataTextField = "Name";
                ddlTso.DataValueField = "TSOID";
                ddlTso.DataBind();
            }
            catch (Exception ex)
            {
                
                 
            }
        }


       
    }
}