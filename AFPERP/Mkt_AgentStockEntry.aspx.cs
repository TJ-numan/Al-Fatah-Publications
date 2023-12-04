using BLL.Classes;
using BLL.Marketing;
using Common.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Mkt_AgentStockEntry : System.Web.UI.Page
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
                    LoadAgent();

                    AllStockProject();
                }
            }
            catch (Exception)
            {


            }
        }

        private void AllStockProject()
        {
            try
            {
                ddlProjectName.DataSource = li_AgentStockEntryManager.GetLi_AllStockProject();
                ddlProjectName.DataTextField = "StockProjectName";
                ddlProjectName.DataValueField = "StockProjectID";
                ddlProjectName.DataBind();
                ddlProjectName.Items.Insert(0, new ListItem("All", "0"));
            }
            catch (Exception ex)
            {
                
                
            }
        }
        private void LoadAgent()
        {
            try
            {
                LoadComboData.LoadLibrary(ddlLibraryName, int.Parse(Session["UserID"].ToString()));
                ddlLibraryName.DataBind();
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

        protected void ddlProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFromDate.Text = "";
            dtpToDate.Text = "";

            DataTable dtProj = li_AgentStockEntryManager.GetLi_AllStockProject_ByPorjectID(Int32.Parse(ddlProjectName.SelectedValue)).Tables[0];
            if (dtProj.Rows.Count > 0)
            {
                dtpFromDate.Text = Convert.ToDateTime(dtProj.Rows[0]["StratDate"].ToString()).ToString("yyyy-MM-dd");
                dtpToDate.Text = Convert.ToDateTime(dtProj.Rows[0]["EndDate"].ToString()).ToString("yyyy-MM-dd");

            }

            gvwProjectBooks.DataSource = dtProj;
            gvwProjectBooks.DataBind();

            gvwProjectForView.DataSource = li_AgentStockEntryManager.GetLi_AgentStockProjectForView(Int32.Parse(ddlProjectName.SelectedValue)).Tables[0];
            gvwProjectForView.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvwProjectBooks.Rows.Count; i++)
                {



                        li_AgentStock li_agentstock = new li_AgentStock();
                        li_agentstock.BookAcCode = gvwProjectBooks.Rows[i].Cells[1].Text+'/'+gvwProjectBooks.Rows[i].Cells[3].Text;
                        li_agentstock.LibraryID = ddlLibraryName.SelectedValue;
                        li_agentstock.StockQty =  int.Parse(((TextBox)gvwProjectBooks.Rows[i].FindControl("txtQty")).Text);
                        li_agentstock.StockApproveQty = 0;
                        li_agentstock.StockProjectID =  int.Parse(ddlProjectName.SelectedValue);
                        li_agentstock.StockProjectBookID = int.Parse(gvwProjectBooks.Rows[i].Cells[0].Text);
                        li_agentstock.CreatedBy = int.Parse(Session["UserID"].ToString());
                        li_agentstock.CreatedDate = DateTime.Now;
                        li_agentstock.ModifiedBy = int.Parse(Session["UserID"].ToString());
                        li_agentstock.ModifiedDate = DateTime.Now;
                        li_agentstock.ApprovedBy = int.Parse(Session["UserID"].ToString());
                        li_agentstock.ApprovedDate = DateTime.Now;

                        li_AgentStockEntryManager.InsertLi_AgentStockEntry(li_agentstock);
                    

                }
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                gvwProjectBooks.DataSource = null;
                gvwProjectBooks.DataBind();

                gvwProjectForView.DataSource = li_AgentStockEntryManager.GetLi_AgentStockProjectForView(Int32.Parse(ddlProjectName.SelectedValue)).Tables[0];
                gvwProjectForView.DataBind();

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Any field missing or Exception problem');", true);
            }
        }

        protected void gvwProjectForView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvwProjectForView.SelectedRow;

            string StockProjectID = row.Cells[0].Text;
            ddlLibraryName.SelectedValue = row.Cells[2].Text;
            DataTable dtView = li_AgentStockEntryManager.GetAllProjectNameBy_ProjIDForEdit(Int32.Parse(StockProjectID), row.Cells[2].Text).Tables[0];
            if(dtView.Rows.Count>0)
            {
                dtpFromDate.Text = Convert.ToDateTime(dtView.Rows[0]["StratDate"].ToString()).ToString("yyyy-MM-dd");
                dtpToDate.Text = Convert.ToDateTime(dtView.Rows[0]["EndDate"].ToString()).ToString("yyyy-MM-dd");
            }
            gvwProjectBooks.DataSource = dtView;
            gvwProjectBooks.DataBind();
        }

        protected void gvwProjectForView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

    }
}