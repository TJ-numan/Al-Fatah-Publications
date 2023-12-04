using BLL.Classes;
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
    public partial class Pro_PlateReturn : System.Web.UI.Page
    {
        string FormID = "PF028";
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    chkPlateRetPT.Checked = true;

                    LoadPlatetype();
                    LoadPlateSize();

                    LoadCategory();
                    LoadComboData.LoadPress(ddlPressName);
                    ddlPressName.DataBind();
                    LoadComboData.LoadPress(ddlTransferPress);
                    ddlTransferPress.DataBind();

                    AddDefaultFirstRecord();
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

        private void LoadCategory()
        {
            ddlCategory.DataSource = Li_CategoryManager.GetAllCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
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

        protected void btnPlateRetAdd_Click(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid(); 
        }

        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblPlateReturn";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("BookName", typeof(string));
            dt.Columns.Add("BookId", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("ClassId", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("TypeId", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            dt.Columns.Add("PlateFor", typeof(string));
            dt.Columns.Add("PlateForId", typeof(string));
            dt.Columns.Add("PlateType", typeof(string));
            dt.Columns.Add("PlateTypeId", typeof(string));
            dt.Columns.Add("PlateSize", typeof(string));
            dt.Columns.Add("PlateSizeId", typeof(string));
            dt.Columns.Add("PlateUseType", typeof(string));
            dt.Columns.Add("Qty", typeof(int));


            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblPlateReturn"] = dt;
            //bind Gridview  
            gvwPlateRet.DataSource = dt;
            gvwPlateRet.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {


            DataTable dtCurrentTable = (DataTable)ViewState["tblPlateReturn"];
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

                        //if ( decimal .Parse  ( txtChlNewQty.Text )_== 0.0m ) 
                        //{
                        //    return;
                        //}

                    }

                    // New row for data table

                    drCurrentRow["BookName"] = ddlBookName.SelectedItem.Text;
                    drCurrentRow["BookId"] = ddlBookName.SelectedValue;
                    drCurrentRow["Class"] = ddlClass.SelectedItem.Text;
                    drCurrentRow["ClassId"] = ddlClass.SelectedValue;
                    drCurrentRow["Type"] = ddlType.SelectedItem.Text;
                    drCurrentRow["TypeId"] = ddlType.SelectedValue;
                    drCurrentRow["Edition"] = ddlEdition.SelectedItem.Text;
                    drCurrentRow["PlateFor"] = ddlPlateFor.SelectedItem.Text;
                    drCurrentRow["PlateForId"] = ddlPlateFor.SelectedIndex + 1;
                    drCurrentRow["PlateType"] = ddlPlateType.SelectedItem.Text;
                    drCurrentRow["PlateTypeId"] = ddlPlateType.SelectedValue;
                    drCurrentRow["PlateSize"] = ddlPlateSize.SelectedItem.Text;
                    drCurrentRow["PlateSizeId"] = ddlPlateSize.SelectedValue;
                    drCurrentRow["PlateUseType"] = ddlPlateUse.SelectedItem.Text;
                    drCurrentRow["Qty"] = txtPlateRetQty.Text;





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

                ViewState["tblPlateReturn"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwPlateRet.DataSource = dtCurrentTable;
                gvwPlateRet.DataBind();


                UpdateTotalQty(dtCurrentTable);
            }


        }

        private void UpdateTotalQty(DataTable dtCurrentTable)
        {

            if (dtCurrentTable.Rows.Count > 0)
            {
                int totalQty = 0;
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {


                    int qty = Int32.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                    totalQty += qty;

                }
                txtTotalQty.Text = String.Format("{0:0.##}", totalQty);
            }

        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblPlateReturn"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPlateRetDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Date missing');", true);
                    return;
                }

                Li_PlateReturnTransfer liPlateRetTrns =new Li_PlateReturnTransfer();
                liPlateRetTrns.PressID = ddlPressName.SelectedValue;
                liPlateRetTrns.IsTransfer = chkPlateRetPT.Checked ? true : false;
                liPlateRetTrns.TransPressID = ddlTransferPress.SelectedValue;
                liPlateRetTrns.RecDate = DateTime.Parse(txtPlateRetDate.Text);
                liPlateRetTrns.TotalQty = int.Parse(txtTotalQty.Text);
                liPlateRetTrns.CreatedBy = int.Parse(Session["UserID"].ToString());
                liPlateRetTrns.CreatedDate = DateTime.Now;
                liPlateRetTrns.Status_D = 'C';
                liPlateRetTrns.CauseOfDel = txtCauseOfDel.Text;
                liPlateRetTrns.DelBy= int.Parse(Session["UserID"].ToString());
                liPlateRetTrns.DelDate = DateTime.Now;

                string resutl = Li_PlateReturnTransferManager.InsertLi_PlateReturnTransfer(liPlateRetTrns);
                txtReturnID.Text = resutl;
                DataTable dtCurrentTable = (DataTable)ViewState["tblPlateReturn"];
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {
                    Li_PlateReturnTransferDetail liPlateRetTrnsDetail = new Li_PlateReturnTransferDetail();

                    liPlateRetTrnsDetail.PlateRecID = resutl;
                    liPlateRetTrnsDetail.BookCode = dtCurrentTable.Rows[i]["BookId"].ToString() + "/" + dtCurrentTable.Rows[i]["Edition"].ToString();
                    liPlateRetTrnsDetail.PlateFor = Int32.Parse(dtCurrentTable.Rows[i]["PlateForId"].ToString());
                    liPlateRetTrnsDetail.Qty = Int32.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                    liPlateRetTrnsDetail.PlateTypeID = dtCurrentTable.Rows[i]["PlateTypeId"].ToString();
                    liPlateRetTrnsDetail.PlateSizeID = dtCurrentTable.Rows[i]["PlateSizeId"].ToString();
                    liPlateRetTrnsDetail.PlateUseType = dtCurrentTable.Rows[i]["PlateUseType"].ToString();

                    Li_PlateReturnTransferDetailManager.InsertLi_PlateReturnTransferDetail(liPlateRetTrnsDetail);
                }



                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                dtCurrentTable.Rows.Clear();
                ViewState["tblPlateReturn"] = null;
                AddDefaultFirstRecord();
                txtCauseOfDel.Text = "";
                txtTotalQty.Text = "";

            }
            catch (Exception)
            {
                
            }
        }

        protected void chkRtnGodown_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRtnGodown.Checked == true)
            {
                ddlTransferPress.Enabled = false;
                ddlTransferPress.SelectedValue = "PID-0042";
            }


            
        }

        protected void chkPlateRetPT_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPlateRetPT.Checked==true)
            {
                ddlTransferPress.Enabled = true;
                LoadComboData.LoadPress(ddlTransferPress);
                ddlTransferPress.DataBind();
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath(@"~/Reports/PRO/rptPlateReturnTransfer.rpt"));
            rd.DataSourceConnections.Clear();
            rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
            rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
            rd.SetParameterValue("@ReturnID", txtReturnID.Text);
            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Plate Return Transfer");
        }

    }
}