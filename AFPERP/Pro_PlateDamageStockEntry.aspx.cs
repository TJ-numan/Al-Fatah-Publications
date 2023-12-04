using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Marketing;
using System.Data;

namespace BLL
{
    public partial class Pro_PlateDamageStockEntry : System.Web.UI.Page
    {
        string FormID = "PF028";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    LoadPlatetype();
                    LoadPlateSize();
                    LoadPress();
                    AddDefaultFirstRecord();
                    AddNewRecordRowToGrid();
                }
            }
            catch (Exception ex)
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
                        Response.Redirect("~/ProHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        private void LoadPlatetype()
        {
            ddlPlateType.DataSource = Li_PlateTypeBasicManager.GetAllLi_PlateTypeBasics();
            ddlPlateType.DataTextField = "Type";
            ddlPlateType.DataValueField = "ID";
            ddlPlateType.DataBind();
        }

        private void LoadPlateSize()
        {
            ddlPlateSize.DataSource = Li_PlateSizeBasicManager.GetAllLi_PlateSizeBasics();
            ddlPlateSize.DataTextField = "Size";
            ddlPlateSize.DataValueField = "ID";
            ddlPlateSize.DataBind();
        }

        private void LoadPress()
        {
            ddlFromPress.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlFromPress.DataTextField = "PressName";
            ddlFromPress.DataValueField = "PressID";
            ddlFromPress.DataBind();
            ddlFromPress.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblDamagePlate";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("PlateType", typeof(string));
            dt.Columns.Add("PlateTypeId", typeof(string));
            dt.Columns.Add("PlateSize", typeof(string));
            dt.Columns.Add("PlateSizeId", typeof(string));
            dt.Columns.Add("Qty", typeof(int));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblDamagePlate"] = dt;
            //bind Gridview  
            gvwPlatePur.DataSource = dt;
            gvwPlatePur.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {
            DataTable dtCurrentTable = (DataTable)ViewState["tblDamagePlate"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count == 0)
            {
                AddDefaultFirstRecord();

            }
            else
            {
                if ((bool)ViewState["LinkClick"] == true)
                {


                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        dtCurrentTable.Rows[i][0] = i + 1;
                        dtCurrentTable.AcceptChanges();
                    }

                    ViewState["LinkClick"] = false;
                }
                else
                {


                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {



                        //add each row into data table  
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Serial"] = dtCurrentTable.Rows.Count + 1;

                    }

                    // New row for data table
                    drCurrentRow["PlateType"] = ddlPlateType.SelectedItem.Text;
                    drCurrentRow["PlateTypeId"] = ddlPlateType.SelectedValue;
                    drCurrentRow["PlateSize"] = ddlPlateSize.SelectedItem.Text;
                    drCurrentRow["PlateSizeId"] = ddlPlateSize.SelectedValue;
                    drCurrentRow["Qty"] = txtQty.Text;

                    //Remove initial blank row  
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        drCurrentRow["Serial"] = dtCurrentTable.Rows.Count;
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();

                    }

                    //add created Rows into dataTable  
                    dtCurrentTable.Rows.Add(drCurrentRow);
                }

                //Save Data table into view state after creating each row  

                ViewState["tblDamagePlate"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwPlatePur.DataSource = dtCurrentTable;
                gvwPlatePur.DataBind();


                UpdateTotalPrice(dtCurrentTable);
            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
            txtQty.Text = "";
        }

        private void UpdateTotalPrice(DataTable dtCurrentTable)
        {

            int totalPlateQty = 0;

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {


                    int plateQty = Int32.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());


                    totalPlateQty += plateQty;


                }
            }


            txtTotalPlateQty.Text = String.Format("{0:0.##}", totalPlateQty);
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblDamagePlate"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();
                UpdateTotalPrice(dtCurrentTable);
            }
            catch (Exception)
            {


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtChallanDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Order Date missing');", true);
                    return;
                }

                Li_PlateDamage li_PlateDamage = new Li_PlateDamage();
                li_PlateDamage.PressID = ddlFromPress.SelectedValue.ToString();
                li_PlateDamage.ChallanDate = DateTime.Parse(txtChallanDate.Text);
                li_PlateDamage.TotalPlateQty = Int32.Parse(txtTotalPlateQty.Text);
                li_PlateDamage.CreatedBy = int.Parse(Session["UserID"].ToString());
                li_PlateDamage.Dam_PurID = TxtSlipNo.Text.ToString();
                li_PlateDamage.CreatedDate = DateTime.Now;
                string result = Li_PlateDamageManager.InsertLi_PlateDamageStock(li_PlateDamage);


                DataTable dtCurrentTable = (DataTable)ViewState["tblDamagePlate"];
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {

                    Li_PlateDamageDetail li_PlateDamageDetail = new Li_PlateDamageDetail();


                    li_PlateDamageDetail.PDM_ID = result;
                    li_PlateDamageDetail.PlateTypeID = dtCurrentTable.Rows[i]["PlateTypeId"].ToString();
                    li_PlateDamageDetail.PlateSizeID = dtCurrentTable.Rows[i]["PlateSizeId"].ToString();
                    li_PlateDamageDetail.Qty = Int32.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                    Li_PlateDamageDetailManager.InsertLi_PlateDamageStockDetail(li_PlateDamageDetail);

                }
                txtMemoNo.Text = result;


                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                dtCurrentTable.Rows.Clear();
                ViewState["tblDamagePlate"] = null;
                AddDefaultFirstRecord();
                txtTotalPlateQty.Text = "0";
                txtChallanDate.Text = "";
                ddlFromPress.SelectedIndex = 0;

            }
            catch (Exception)
            {


            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string MemoNo = txtMemoNo.Text;
            Response.Redirect("~/Pro_PrintDamageByMemo.aspx?No=" + MemoNo);
        }

    }
}