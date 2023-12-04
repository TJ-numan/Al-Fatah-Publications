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
    public partial class Mkt_MadrasahInfoDetailsEntry : System.Web.UI.Page
    {
        string FormID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserID"] == null)
                        Response.Redirect("~/Login.aspx");
                    if (!IsPostBack)
                    {
                        btnSave.Enabled = true;
                        getUserAccess();
                        LoadDemarcation();

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
                        Response.Redirect("~/AccountsHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadDemarcation()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = li_RegionManager.GetRegionByUser(int.Parse(Session["UserID"].ToString()));
                DataTable dtregmain = ds.Tables[0].DefaultView.ToTable(true, "RegionMainName", "RegionMainID");
                DataTable dtreg = ds.Tables[0].DefaultView.ToTable(true, "RegionName", "RegionID");
                DataTable dtdiv = ds.Tables[0].DefaultView.ToTable(true, "DivName", "DivID");
                DataTable dtTer = ds.Tables[0].DefaultView.ToTable(true, "TeritoryName", "TeritoryCode");
                if (dtTer.Rows.Count == 1)
                {
                    ddlRegionMain.DataSource = dtregmain;
                    ddlRegionMain.DataTextField = "RegionMainName";
                    ddlRegionMain.DataValueField = "RegionMainID";
                    ddlRegionMain.DataBind();

                    ddlRegion.DataSource = dtreg;
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();

                    ddlDivision.DataSource = dtdiv;
                    ddlDivision.DataTextField = "DivName";
                    ddlDivision.DataValueField = "DivID";
                    ddlDivision.DataBind();
                    ddlTeritory.DataSource = dtTer;
                    ddlTeritory.DataTextField = "TeritoryName";
                    ddlTeritory.DataValueField = "TeritoryCode";
                    ddlTeritory.DataBind();

                }
                else if (dtdiv.Rows.Count == 1)
                {

                    ddlRegionMain.DataSource = dtregmain;
                    ddlRegionMain.DataTextField = "RegionMainName";
                    ddlRegionMain.DataValueField = "RegionMainID";
                    ddlRegionMain.DataBind();

                    ddlRegion.DataSource = dtreg;
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();

                    ddlDivision.DataSource = dtdiv;
                    ddlDivision.DataTextField = "DivName";
                    ddlDivision.DataValueField = "DivID";
                    ddlDivision.DataBind();
                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));

                }
                else if (dtreg.Rows.Count == 1)
                {
                    ddlRegionMain.DataSource = dtregmain;
                    ddlRegionMain.DataTextField = "RegionMainName";
                    ddlRegionMain.DataValueField = "RegionMainID";
                    ddlRegionMain.DataBind();

                    ddlRegion.DataSource = dtreg;
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();

                    ddlDivision.DataSource = dtdiv;
                    ddlDivision.DataTextField = "DivName";
                    ddlDivision.DataValueField = "DivID";
                    ddlDivision.DataBind();

                    ddlDivision.Items.Insert(0, new ListItem("All", "0"));
                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));


                }
                else if (dtregmain.Rows.Count == 1)
                {
                    ddlRegionMain.DataSource = dtregmain;
                    ddlRegionMain.DataTextField = "RegionMainName";
                    ddlRegionMain.DataValueField = "RegionMainID";
                    ddlRegionMain.DataBind();

                    ddlRegion.DataSource = dtreg;
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();
                    ddlRegion.Items.Insert(0, new ListItem("All", "0"));

                    ddlDivision.Items.Insert(0, new ListItem("All", "0"));
                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));

                }
                else
                {
                    ddlRegionMain.DataSource = dtregmain;
                    ddlRegionMain.DataTextField = "RegionMainName";
                    ddlRegionMain.DataValueField = "RegionMainID";
                    ddlRegionMain.DataBind();

                    ddlRegionMain.Items.Insert(0, new ListItem("All", "0"));
                    ddlRegion.Items.Insert(0, new ListItem("All", "0"));
                    ddlDivision.Items.Insert(0, new ListItem("All", "0"));
                    ddlTeritory.Items.Insert(0, new ListItem("All", ""));
                }

            }
            catch (Exception)
            {
            }
        }
        protected void ddlRegionMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = li_RegionManager.GetRegionByRegionMainId(ddlRegionMain.SelectedValue).Tables[0];
                ddlRegion.DataSource = dt;
                ddlRegion.DataTextField = "RegionName";
                ddlRegion.DataValueField = "RegionID";
                ddlRegion.DataBind();

                ddlDivision.Items.Clear();
                ddlDivision.Items.Insert(0, new ListItem("All", "0"));

                ddlTeritory.Items.Clear();
                ddlTeritory.Items.Insert(0, new ListItem("All", ""));
            }
            catch (Exception)
            {

            }
        }
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                LoadComboData.LoadDivisionByRegionID(ddlDivision, int.Parse(ddlRegion.SelectedValue.ToString()));
                ddlDivision.DataBind();

                ddlTeritory.Items.Clear();
                ddlTeritory.Items.Insert(0, new ListItem("All", ""));
            }
            catch (Exception)
            {

            }
        }
        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadComboData.LoadTeritoryByZone(ddlTeritory, int.Parse(ddlDivision.SelectedValue));
                ddlTeritory.DataBind();

            }
            catch (Exception)
            {


            }
        }


        protected void btnShow_Click(object sender, EventArgs e)
        {

            try
            {

                DataTable dtexisEiin = new DataTable();
                dtexisEiin = Li_MadrasahInfoManager.GetLi_MadrasahEIIN_ForExistingEIIN(txteiin.Text.Trim()).Tables[0];
                if (dtexisEiin.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This Madrasah entry already completed');", true);
                    return;
                }
                
                DataTable dt = new DataTable();


                //dt = Li_MadrasahEntryManager.Get_MadrasahInfoByRegDivTer(int.Parse(ddlRegion.SelectedValue), int.Parse(ddlDivision.SelectedValue), ddlTeritory.SelectedValue).Tables[0];
                dt = Li_MadrasahEntryManager.Get_MadrasahInfoByEIIN(txteiin.Text.Trim()).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        gvMRSheetDetailsUpdate.DataSource = dt;
                        gvMRSheetDetailsUpdate.DataBind();
                    }
                    else
                    {
                        gvMRSheetDetailsUpdate.DataSource = null;
                        gvMRSheetDetailsUpdate.DataBind();
                    }
               
            }
            catch (Exception)
            {


            }

        }



        protected void gvMRSheetDetailsUpdate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    var ddlInstLevel = e.Row.FindControl("ddlInstLevel") as DropDownList;
                    if (ddlInstLevel != null)
                    {
                        ddlInstLevel.DataSource = li_MadrashalevelsManager.GetAllLi_MadrashaLevels();
                        ddlInstLevel.DataTextField = "Level_Name";
                        ddlInstLevel.DataValueField = "Level_ID";
                        ddlInstLevel.DataBind();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void ddlInstLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                {
                    DropDownList ddlRow = (gvMRSheetDetailsUpdate.Rows[i].Cells[6].FindControl("ddlInstLevel") as DropDownList);

                    if (ddlRow.SelectedValue == "1")
                    {
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL1")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL2")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL3")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL4")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL5")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL6")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL7")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL8")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL9")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL10")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL1")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL2")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtFZ1to3")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtKM1to2")).Enabled = false;

                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTEB")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTDH")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTAL")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTFZ")).Enabled = false;
                    }
                    else if (ddlRow.SelectedValue == "2")
                    {
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL1")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL2")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL3")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL4")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL5")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL6")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL7")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL8")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL9")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL10")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL1")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL2")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtFZ1to3")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtKM1to2")).Enabled = false;

                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTEB")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTDH")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTAL")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTFZ")).Enabled = false;
                    }
                    else if (ddlRow.SelectedValue == "3")
                    {

                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL1")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL2")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL3")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL4")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL5")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL6")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL7")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL8")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL9")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL10")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL1")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL2")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtFZ1to3")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtKM1to2")).Enabled = false;

                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTEB")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTDH")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTAL")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTFZ")).Enabled = false;
                    

                    }
                    else if (ddlRow.SelectedValue == "4")
                    {

                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL1")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL2")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL3")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL4")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL5")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL6")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL7")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL8")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL9")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL10")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL1")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL2")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtFZ1to3")).Enabled = false;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtKM1to2")).Enabled = false;

                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTEB")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTDH")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTAL")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTFZ")).Enabled = false;
                    

                    }
                    else if (ddlRow.SelectedValue == "5")
                    {


                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL1")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL2")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL3")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL4")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL5")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL6")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL7")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL8")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL9")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL10")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL1")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL2")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtFZ1to3")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtKM1to2")).Enabled = false;

                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTEB")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTDH")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTAL")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTFZ")).Enabled = true;
                    
                    }
                    else
                    {

                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL1")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL2")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL3")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL4")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL5")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL6")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL7")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL8")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL9")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL10")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL1")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL2")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtFZ1to3")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtKM1to2")).Enabled = true;

                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTEB")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTDH")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTAL")).Enabled = true;
                        ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTFZ")).Enabled = true;
                    }


                    //ddlRow.Focus();

                }
            }
            catch (Exception)
            {


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvMRSheetDetailsUpdate.Rows.Count; i++)
                {

                    GridViewRow gvwrow = gvMRSheetDetailsUpdate.Rows[i];
                    if (((DropDownList)gvwrow.FindControl("ddlInstLevel")).SelectedValue != "0")
                    {
                        DataTable dtexisEiin = new DataTable();
                        dtexisEiin = Li_MadrasahInfoManager.GetLi_MadrasahEIIN_ForExistingEIIN(gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text).Tables[0];
                        if (dtexisEiin.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('This Madrasah already exist !');", true);
                            return;
                        }

                        Li_MadrasahInfoAdvanced liMadrasahInf = new Li_MadrasahInfoAdvanced();

                        liMadrasahInf.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                        liMadrasahInf.MadName = gvMRSheetDetailsUpdate.Rows[i].Cells[2].Text;
                        liMadrasahInf.VillRoBaz = "";
                        liMadrasahInf.PostOff = "";
                        liMadrasahInf.ThanaId = int.Parse(gvMRSheetDetailsUpdate.Rows[i].Cells[4].Text);
                        liMadrasahInf.MadLevelId = int.Parse(((DropDownList)gvwrow.FindControl("ddlInstLevel")).SelectedValue);
                        liMadrasahInf.DevelopIndex = int.Parse(gvMRSheetDetailsUpdate.Rows[i].Cells[6].Text);
                        liMadrasahInf.PrinName = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtPrincipalName")).Text;
                        liMadrasahInf.PrinCont = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtContactNo")).Text;
                        liMadrasahInf.CreatedBy = int.Parse(Session["UserID"].ToString());
                        liMadrasahInf.CreatedDate = DateTime.Now;
                        liMadrasahInf.Remarks = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtRemarks")).Text;

                        Li_MadrasahInfoManager.InsertLi_MadrasahInfoAdvanced(liMadrasahInf);

                        //For No. of Student Entry
                        Li_StudentAdvanced listudent = new Li_StudentAdvanced();
                        int classNo = 14;
                        for (int j = 1; j <= 14; j++)
                        {
                            classNo = j;

                            switch (classNo)
                            {
                                //case 0:
                                //    listudent.ClassID = classNo;
                                //    listudent.NoOfStudents = txtChildren.Text.Trim() == "" ? 0 : int.Parse(txtChildren.Text);
                                //    listudent.MadId = MadrashaId;
                                //    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                //    listudent.CreatedDate = DateTime.Now;
                                //    Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                //    break;
                                case 1:
                                    listudent.ClassID = classNo;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL1")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL1")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 2:
                                    listudent.ClassID = classNo;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL2")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL2")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 3:
                                    listudent.ClassID = classNo;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL3")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL3")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 4:
                                    listudent.ClassID = classNo;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL4")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL4")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 5:
                                    listudent.ClassID = classNo;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL5")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL5")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 6:
                                    listudent.ClassID = classNo;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL6")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL6")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 7:
                                    listudent.ClassID = classNo;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL7")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL7")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 8:
                                    listudent.ClassID = classNo;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL8")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL8")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 9:
                                    listudent.ClassID = classNo;
                                    //int CLNine=((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL9")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL9")).Text);
                                    //int CLTen=((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL10")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL10")).Text);
                                    //int CLNineTen=CLNine+CLTen;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL9")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL9")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 10:
                                    listudent.ClassID = classNo;
                                    //int CLA1 = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL1")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL1")).Text);
                                    //int CLA2 = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL2")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL2")).Text);
                                    //int CLA1A2 = CLA1 + CLA2;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL10")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCL10")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 11:
                                    listudent.ClassID = classNo;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL1")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL1")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 12:
                                    listudent.ClassID = classNo;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL2")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtCLAL2")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 13:
                                    listudent.ClassID = classNo;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtFZ1to3")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtFZ1to3")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;
                                case 14:
                                    listudent.ClassID = classNo;
                                    listudent.NoOfStudents = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtKM1to2")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtKM1to2")).Text);
                                    listudent.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    listudent.CreatedDate = DateTime.Now;
                                    listudent.FY_Year = "";
                                    Li_StudentR2Manager.InsertLi_StudentAdvanced(listudent);
                                    break;

                                default:
                                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Class');", true);
                                    break;
                            }

                        }


                        //For No. of Teacher Entry
                        Li_TeacherNoAdvanced liNoOfTeacher = new Li_TeacherNoAdvanced();
                        int teacherNo = 6;
                        for (int k = 1; k <= 6; k++)
                        {
                            teacherNo = k;

                            switch (teacherNo)
                            {
                                //case 0:
                                //    listudent.ClassID = classNo;
                                //    listudent.NoOfStudents = txtChildren.Text.Trim() == "" ? 0 : int.Parse(txtChildren.Text);
                                //    listudent.MadId = MadrashaId;
                                //    listudent.CreatedBy = int.Parse(Session["UserID"].ToString());
                                //    listudent.CreatedDate = DateTime.Now;
                                //    Li_StudentR2Manager.InsertLi_StudentR2(listudent);
                                //    break;
                                case 1:
                                    liNoOfTeacher.Mad_Level_ID = teacherNo;
                                    liNoOfTeacher.NoOfTeachers = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTEB")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTEB")).Text);
                                    liNoOfTeacher.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    liNoOfTeacher.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    liNoOfTeacher.CreatedDate = DateTime.Now;
                                    liNoOfTeacher.FY_Year = "";
                                    liNoOfTeacher.AgreementWith = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtContactWith")).Text.Trim();
                                    Li_StudentR2Manager.InsertLi_TeacherNoAdvanced(liNoOfTeacher);
                                    break;
                                case 2:
                                    liNoOfTeacher.Mad_Level_ID = teacherNo;
                                    liNoOfTeacher.NoOfTeachers = 0;
                                    liNoOfTeacher.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    liNoOfTeacher.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    liNoOfTeacher.CreatedDate = DateTime.Now;
                                    liNoOfTeacher.FY_Year = "";
                                    liNoOfTeacher.AgreementWith = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtContactWith")).Text.Trim();
                                    Li_StudentR2Manager.InsertLi_TeacherNoAdvanced(liNoOfTeacher);
                                    break;
                                case 3:
                                    liNoOfTeacher.Mad_Level_ID = teacherNo;
                                    liNoOfTeacher.NoOfTeachers = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTDH")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTDH")).Text);
                                    liNoOfTeacher.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    liNoOfTeacher.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    liNoOfTeacher.CreatedDate = DateTime.Now;
                                    liNoOfTeacher.FY_Year = "";
                                    liNoOfTeacher.AgreementWith = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtContactWith")).Text.Trim();
                                    Li_StudentR2Manager.InsertLi_TeacherNoAdvanced(liNoOfTeacher);
                                    break;
                                case 4:
                                    liNoOfTeacher.Mad_Level_ID = teacherNo;
                                    liNoOfTeacher.NoOfTeachers = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTAL")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTAL")).Text);
                                    liNoOfTeacher.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    liNoOfTeacher.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    liNoOfTeacher.CreatedDate = DateTime.Now;
                                    liNoOfTeacher.FY_Year = "";
                                    liNoOfTeacher.AgreementWith = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtContactWith")).Text.Trim();
                                    Li_StudentR2Manager.InsertLi_TeacherNoAdvanced(liNoOfTeacher);
                                    break;
                                case 5:
                                    liNoOfTeacher.Mad_Level_ID = teacherNo;
                                    liNoOfTeacher.NoOfTeachers = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTFZ")).Text.Trim() == "" ? 0 : int.Parse(((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtNoTFZ")).Text);
                                    liNoOfTeacher.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    liNoOfTeacher.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    liNoOfTeacher.CreatedDate = DateTime.Now;
                                    liNoOfTeacher.FY_Year = "";
                                    liNoOfTeacher.AgreementWith = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtContactWith")).Text.Trim();
                                    Li_StudentR2Manager.InsertLi_TeacherNoAdvanced(liNoOfTeacher);
                                    break;
                                case 6:
                                    liNoOfTeacher.Mad_Level_ID = teacherNo;
                                    liNoOfTeacher.NoOfTeachers = 0;
                                    liNoOfTeacher.EIIN = gvMRSheetDetailsUpdate.Rows[i].Cells[1].Text;
                                    liNoOfTeacher.CreatedBy = int.Parse(Session["UserID"].ToString());
                                    liNoOfTeacher.CreatedDate = DateTime.Now;
                                    liNoOfTeacher.FY_Year = "";
                                    liNoOfTeacher.AgreementWith = ((TextBox)gvMRSheetDetailsUpdate.Rows[i].FindControl("txtContactWith")).Text.Trim();
                                    Li_StudentR2Manager.InsertLi_TeacherNoAdvanced(liNoOfTeacher);
                                    break;

                                default:
                                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Madrasah Level');", true);
                                    break;
                            }

                        }
                    }

                }


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
            catch (Exception ex)
            {
                
                throw;
            }
        }

    }
}