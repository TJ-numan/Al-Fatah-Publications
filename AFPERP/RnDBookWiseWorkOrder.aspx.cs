using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Marketing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using System.Data;


namespace BLL
{
    public partial class RnDBookWiseWorkOrder : System.Web.UI.Page
    {
        string FormID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadClassByUserID();

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
                        Response.Redirect("~/RandDHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadClassByUserID()
        {
            ddlClass.DataSource = Li_ClassesManager.GetLi_ClassesWorkOrderByUserID(int.Parse(Session["UserID"].ToString()));
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("--select--", "0"));
        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlBookName.DataSource = li_BookInformationManager.Get_BookInformationsByUserAndClassIDForWorkOrderBook(int.Parse(Session["UserID"].ToString()), int.Parse(ddlClass.SelectedValue.ToString()));
                ddlBookName.DataTextField = "BookName";
                ddlBookName.DataValueField = "BookID";
                ddlBookName.DataBind();
                ddlBookName.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception)
            {
            }


        }

        protected void ddlBookName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Classes.LoadCategory.LoadEditionByBookIDForRnDWorkOrderAia(ddlEdition, ddlBookName);
                ddlEdition.DataBind();

            }
            catch (Exception)
            {
            }
        }       
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();
        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            rd.Load(Server.MapPath(@"~/Reports/RND/rptPrintRnDWorkOrderDetailsByBookIDForRnd.rpt"));
            //rd.SetDatabaseLogon(DAO.UserID, DAO.Password, DAO.ServerName, DAO.DatabaseName);
            rd.DataSourceConnections.Clear();
            rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
            rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
            rd.SetParameterValue("@BookID", ddlBookName.SelectedValue.ToString());
            rd.SetParameterValue("@Edition", ddlEdition.SelectedValue.ToString());
            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "PrintRnDBookWiseWorkOrder");
            rd.Close();
            rd.Dispose();
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