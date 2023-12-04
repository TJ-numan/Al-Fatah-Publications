using BLL.Marketing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Store_Rpt_CentralStockInventory : System.Web.UI.Page
    {

        DataAccessObject DAO = new DataAccessObject();
        string FormID = "MR024";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    getUserAccess();

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

                    LoadCategory();
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
        private void LoadCategory()
        {
            ddlCategory.DataSource = Li_CategoryManager.GetAllCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlGroup.DataSource = Li_Book_GManager.GetLi_Book_GByID(ddlCategory.SelectedValue.ToString());
                ddlGroup.DataTextField = "GName";
                ddlGroup.DataValueField = "GID";
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlClass.Items.Clear();
                ddlType.Items.Clear();
                ddlBookName.Items.Clear();
                ddlEdition.Items.Clear();
            }
            catch (Exception)
            {
            }
        }

        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Classes.LoadCategory.LoadBookCalssByBookGroup(ddlClass, ddlCategory, ddlGroup);
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, new ListItem("--Select--", ""));
                ddlType.Items.Clear();
                ddlBookName.Items.Clear();
                ddlEdition.Items.Clear();
            }
            catch (Exception)
            {
            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Classes.LoadCategory.LoadBookTypeByClass(ddlType, ddlClass, ddlCategory);
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("--Select--", ""));
                ddlBookName.Items.Clear();
                ddlEdition.Items.Clear();
            }
            catch (Exception)
            {
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Classes.LoadCategory.LoadBookByType(ddlBookName, ddlCategory, ddlClass, ddlType);
                ddlBookName.DataBind();
                ddlBookName.Items.Insert(0, new ListItem("--Select--", ""));
                ddlEdition.Items.Clear();
            }
            catch (Exception)
            {
            }
        }

        protected void ddlBookName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = li_BookInformationManager.GetEditionByBookID(ddlBookName.SelectedValue).Tables[0];

                ddlEdition.DataSource = dt;
                ddlEdition.DataTextField = "Edition";
                ddlEdition.DataValueField = "Edition";
                ddlEdition.DataBind();

            }
            catch (Exception)
            {
            }
        }
        ReportDocument rd = new ReportDocument();
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDateTime(dtpFromDate.Text) < Convert.ToDateTime(dtpToDate.Text))
                {
                    rd.Load(Server.MapPath(@"~/Reports/Store/rptCentralStoreInventoryReport.rpt"));
                    //rd.Load(Server.MapPath(@"~/Reports/Store/rptCentralStoreInventoryReportExtraforBank.rpt"));
                    rd.DataSourceConnections.Clear();
                    rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                    rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                    rd.SetParameterValue("@FromDate", dtpFromDate.Text);
                    rd.SetParameterValue("@ToDate", dtpToDate.Text);
                    rd.SetParameterValue("@Category", ddlCategory.SelectedValue);
                    rd.SetParameterValue("@GID", ddlGroup.SelectedValue);
                    rd.SetParameterValue("@Class", ddlClass.SelectedValue);
                    rd.SetParameterValue("@Type", ddlType.SelectedValue);
                    rd.SetParameterValue("@BookName", ddlBookName.SelectedValue);
                    rd.SetParameterValue("@Edition", ddlEdition.SelectedValue == "All" ? "" : ddlEdition.SelectedValue);

                    if (ddlViewers.SelectedValue == "0")
                    {

                    }

                    else if (ddlViewers.SelectedValue == "1")
                    {
                        rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "AgentStatementReport");
                    }

                    else if (ddlViewers.SelectedValue == "2")
                    {
                        rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "AgentStatementReport");
                    }


                    else if (ddlViewers.SelectedValue == "3")
                    {
                        rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "AgentStatementReport");
                    }

                    else
                    {

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('your date is incorrect');", true);
                    return;
                }
            }
            catch (Exception ex)
            {

            }
        }


      





        //NumanTestingReport
        protected void OurReportShow(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDateTime(dtpFromDate.Text) < Convert.ToDateTime(dtpToDate.Text))
                {
                    rd.Load(Server.MapPath(@"~/Reports/Store/rptCentralStoreInventoryReportNuman.rpt"));
                    //rd.Load(Server.MapPath(@"~/Reports/Store/rptCentralStoreInventoryReportExtraforBank.rpt"));
                    rd.DataSourceConnections.Clear();
                    rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                    rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                    rd.SetParameterValue("@FromDate", dtpFromDate.Text);
                    rd.SetParameterValue("@ToDate", dtpToDate.Text);
                    rd.SetParameterValue("@Category", ddlCategory.SelectedValue);
                    rd.SetParameterValue("@GID", ddlGroup.SelectedValue);
                    rd.SetParameterValue("@Class", ddlClass.SelectedValue);
                    rd.SetParameterValue("@Type", ddlType.SelectedValue);
                    rd.SetParameterValue("@BookName", ddlBookName.SelectedValue);
                    rd.SetParameterValue("@Edition", ddlEdition.SelectedValue == "All" ? "" : ddlEdition.SelectedValue);

                    if (ddlViewers.SelectedValue == "0")
                    {

                    }

                    else if (ddlViewers.SelectedValue == "1")
                    {
                        rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "AgentStatementReport");
                    }

                    else if (ddlViewers.SelectedValue == "2")
                    {
                        rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "AgentStatementReport");
                    }


                    else if (ddlViewers.SelectedValue == "3")
                    {
                        rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "AgentStatementReport");
                    }

                    else
                    {

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('your date is incorrect');", true);
                    return;
                }
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