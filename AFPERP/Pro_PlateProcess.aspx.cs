using BLL.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PlateProcess : System.Web.UI.Page
    {
        string FormID = "PF023";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {

                    int year = DateTime.Now.Year;
                    int month = DateTime.Now.Month;
                    int day = DateTime.Now.Day;

                    if (month >= 7)
                    {
                        var mydate = new DateTime(year, 07, 01);

                        txtFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    }

                    else
                    {
                        var mydate = new DateTime(year - 1, 07, 01);
                        txtFromDate.Text = String.Format("{0:yyyy-MM-dd}", mydate);
                    }
                    txtToDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);


                    LoadCategory();
                    LoadProcess();

                    txtOrderDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
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
                        Response.Redirect("~/ProHome.aspx");
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

        private void LoadProcess()
        {
            ddlPlateParty.DataSource = Li_PlateProcessPartyManager.GetAllLi_PlateProcessParties();
            ddlPlateParty.DataTextField = "Name";
            ddlPlateParty.DataValueField = "ID";
            ddlPlateParty.DataBind();
            ddlPlateParty.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void ddlPlateParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gvwPlateProMain.DataSource = null;
                gvwPlateProMain.DataBind();
                LoadOrder();

            }
            catch (Exception)
            {


            }
        }

        private void LoadOrder()
        {
            try
            {


                DataSet ds = new DataSet();
                ds = Li_PlateProcessManager.Get_PlatePurchaseOrderByReceiveID(ddlPlateParty.SelectedValue, txtFromDate.Text, txtToDate.Text);

                gvwPlateProMain.DataSource = ds.Tables[0];
                gvwPlateProMain.DataBind();


            }
            catch (Exception)
            {


            }
        }

        protected void gvwPlateProMain_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    var ddlPlateType = e.Row.FindControl("ddlProcess_Press") as DropDownList;
                    if (ddlPlateType != null)
                    {
                    ddlPlateType.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
                    ddlPlateType.DataTextField = "PressName";
                    ddlPlateType.DataValueField = "PressID";
                    ddlPlateType.DataBind();
                    ddlPlateType.Items.Insert(0, new ListItem("--Select--", ""));
                    }
                }

                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
            }
            catch (Exception)
            {
                
            }
        }

        protected void btnPlateProSave_Click(object sender, EventArgs e)
        {

            try
            {

                for (int i = 0; i < gvwPlateProMain.Rows.Count; i++)
                {
                    CheckBox chkRow = (gvwPlateProMain.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {
                        GridViewRow row = gvwPlateProMain.Rows[i];
                        object press = ((DropDownList)row.FindControl("ddlProcess_Press")).SelectedValue;

                        if (press == "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select press first then click on check box');", true);
                            return;
                        }

                    }
                }


                Li_PlateProcess plateProcess = new Li_PlateProcess();
                plateProcess.CauseOfDel = "";
                plateProcess.CreatedBy = int.Parse(Session["UserID"].ToString());
                plateProcess.CreatedDate = DateTime.Now;
                plateProcess.DelBy = 0;
                plateProcess.DelDate = DateTime.Now;
                plateProcess.PlateQty = int.Parse(txtTotalPlateQty.Text);
                plateProcess.ProcessID = ddlPlateParty.SelectedValue.ToString();
                plateProcess.Rate = decimal.Parse(txtProcessRate.Text);
                plateProcess.Status_D = 'C';
                plateProcess.TotalBill = decimal.Parse(txtTotalBill.Text);
                string result = Li_PlateProcessManager.InsertLi_PlateProcess(plateProcess);


                txtOrderNo.Text = result;

                for (int i = 0; i < gvwPlateProMain.Rows.Count; i++)
                {
                    CheckBox chkSRow = (gvwPlateProMain.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);
                    if (chkSRow.Checked == true)
                    {
                        GridViewRow row = gvwPlateProMain.Rows[i];

                        Li_PlateProcessDetail processDetail = new Li_PlateProcessDetail();
                        processDetail.PressID = ((DropDownList)row.FindControl("ddlProcess_Press")).SelectedValue;
                        processDetail.Pro_ID = result;
                        processDetail.Pur_Sl = Int32.Parse(gvwPlateProMain.Rows[i].Cells[2].Text);
                        processDetail.Qty = Int32.Parse(gvwPlateProMain.Rows[i].Cells[10].Text);
                        processDetail.BookCode = gvwPlateProMain.Rows[i].Cells[1].Text;
                        Li_PlateProcessDetailManager.InsertLi_PlateProcessDetail(processDetail);
                    }
                }
                
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                gvwPlateProMain.DataSource=null;
                gvwPlateProMain.DataBind();
                gvwGodownPlate.DataSource = null;
                gvwGodownPlate.DataBind();
                txtSelectedRowNo.Text = "";

            }
            catch (Exception)
            {


            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string OrderNo = txtOrderNo.Text;
            Response.Redirect("~/Pro_Rpt_PlateProcessOrder.aspx?No=" + OrderNo);
        }

    }
}