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
    public partial class Pro_PlatePurchase : System.Web.UI.Page
    {
        string FormID = "PF026";
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
                    LoadPlateSupplier();
                    LoadCategory();
                    AddDefaultFirstRecord();
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

        private void LoadPlateSupplier()
        {
            ddlSupplier.DataSource = Li_PlateBuyerInfoManager.GetAllLi_PlateBuyerInfos();
            ddlSupplier.DataTextField = "Name";
            ddlSupplier.DataValueField = "ID";
            ddlSupplier.DataBind();
            ddlSupplier.SelectedIndex = -1;
        }

        private void LoadCategory()
        {
            ddlCategory.DataSource = Li_CategoryManager.GetAllCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        private void LoadPress()
        {
            ddlReceiveAt.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlReceiveAt.DataTextField = "PressName";
            ddlReceiveAt.DataValueField = "PressID";
            ddlReceiveAt.DataBind();
            ddlReceiveAt.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        private void LoadProcess()
        {
            ddlReceiveAt.DataSource = Li_PlateProcessPartyManager.GetAllLi_PlateProcessParties();
            ddlReceiveAt.DataTextField = "Name";
            ddlReceiveAt.DataValueField = "ID";
            ddlReceiveAt.DataBind(); 
            ddlReceiveAt.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void ddlReceiveBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReceiveBy.SelectedValue == "0")
            {
                LoadPress();
            }
            else if (ddlReceiveBy.SelectedValue == "1")
            {
                LoadProcess();

            }
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

        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblPlatePurchase";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("BookName", typeof(string));
            dt.Columns.Add("BookId", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("ClassId", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("TypeId", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            dt.Columns.Add("ReferNo", typeof(string));
            dt.Columns.Add("PurchaseDate", typeof(string));
            dt.Columns.Add("PlateFor", typeof(string));
            dt.Columns.Add("PlateForId", typeof(string));
            dt.Columns.Add("PlateType", typeof(string));
            dt.Columns.Add("PlateTypeId", typeof(string));
            dt.Columns.Add("PlateSize", typeof(string));
            dt.Columns.Add("PlateSizeId", typeof(string));
            dt.Columns.Add("Qty", typeof(int));
            dt.Columns.Add("BillRate", typeof(string));
            dt.Columns.Add("TotalBill", typeof(string));


            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblPlatePurchase"] = dt;
            //bind Gridview  
            gvwPlatePur.DataSource = dt;
            gvwPlatePur.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {


            DataTable dtCurrentTable = (DataTable)ViewState["tblPlatePurchase"];
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
                    drCurrentRow["ReferNo"] = txtRefNo.Text;
                    drCurrentRow["PurchaseDate"] = txtPurchaseDate.Text;
                    drCurrentRow["PlateFor"] = ddlPlateFor.SelectedItem.Text;
                    drCurrentRow["PlateForId"] = ddlPlateFor.SelectedIndex + 1;
                    drCurrentRow["PlateType"] = ddlPlateType.SelectedItem.Text;
                    drCurrentRow["PlateTypeId"] = ddlPlateType.SelectedValue;
                    drCurrentRow["PlateSize"] = ddlPlateSize.SelectedItem.Text;
                    drCurrentRow["PlateSizeId"] = ddlPlateSize.SelectedValue;
                    drCurrentRow["Qty"] = txtQty.Text;
                    drCurrentRow["BillRate"] = txtRate.Text;
                    drCurrentRow["TotalBill"] = txtTotalBill.Text;





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

                ViewState["tblPlatePurchase"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwPlatePur.DataSource = dtCurrentTable;
                gvwPlatePur.DataBind();


                UpdateTotalPrice(dtCurrentTable);
            }

            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
            txtRefNo.Text = "";
            txtQty.Text = "";
            txtRate.Text = "";
            txtTotalBill.Text = "";
            txtPurchaseDate.Text = "";
        }

        private void UpdateTotalPrice(DataTable dtCurrentTable)
        {

            decimal totalAmount = 0.0m;
            int totalPlateQty = 0;

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {

                    decimal plateBill = decimal.Parse(dtCurrentTable.Rows[i]["TotalBill"].ToString());

                    int plateQty = Int32.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());


                    totalAmount += plateBill;
                    totalPlateQty += plateQty;


                }
            }




            txtTotalAmount.Text = String.Format("{0:0.##}", totalAmount);
            txtTotalPlateQty.Text = String.Format("{0:0.##}", totalPlateQty);
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblPlatePurchase"];
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
                if (txtOrderDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Order Date missing');", true);
                    return;
                }

                Li_PlatePurchase li_PlatePurchase = new Li_PlatePurchase();
                li_PlatePurchase.Pur_PartyID = ddlSupplier.SelectedValue.ToString();
                li_PlatePurchase.OrderDate = DateTime.Parse(txtOrderDate.Text);
                li_PlatePurchase.TotalPlateQty = Int32.Parse(txtTotalPlateQty.Text);
                li_PlatePurchase.TotalBill = Decimal.Parse(txtTotalAmount.Text);
                li_PlatePurchase.ReceiveID = ddlReceiveAt.SelectedValue.ToString();
                li_PlatePurchase.IsPress = ddlReceiveBy.SelectedValue == "0" ? true : false;
                li_PlatePurchase.CreatedBy = int.Parse(Session["UserID"].ToString());
                li_PlatePurchase.CreatedDate = DateTime.Now;
                string resutl = Li_PlatePurchaseManager.InsertLi_PlatePurchase(li_PlatePurchase);


                DataTable dtCurrentTable = (DataTable)ViewState["tblPlatePurchase"];
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {

                    Li_PlatePurchaseDetail li_PlatePurchaseDetail = new Li_PlatePurchaseDetail();


                    li_PlatePurchaseDetail.Pur_ID = resutl;
                    li_PlatePurchaseDetail.BookCode = dtCurrentTable.Rows[i]["BookId"].ToString() + "/" + dtCurrentTable.Rows[i]["Edition"].ToString();
                    li_PlatePurchaseDetail.Edition = dtCurrentTable.Rows[i]["Edition"].ToString();
                    li_PlatePurchaseDetail.PlateTypeID = dtCurrentTable.Rows[i]["PlateTypeId"].ToString();
                    li_PlatePurchaseDetail.PlateSizeID = dtCurrentTable.Rows[i]["PlateSizeId"].ToString();
                    li_PlatePurchaseDetail.Qty = Int32.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                    li_PlatePurchaseDetail.BillRate = Decimal.Parse(dtCurrentTable.Rows[i]["BillRate"].ToString());
                    li_PlatePurchaseDetail.Refno = dtCurrentTable.Rows[i]["ReferNo"].ToString();
                    li_PlatePurchaseDetail.PlateFor = Int32.Parse(dtCurrentTable.Rows[i]["PlateForId"].ToString());
                    li_PlatePurchaseDetail.PurDate = DateTime.Parse(dtCurrentTable.Rows[i]["PurchaseDate"].ToString());


                    Li_PlatePurchaseDetailManager.InsertLi_PlatePurchaseDetail(li_PlatePurchaseDetail);

                }
                txtOrderNo.Text = resutl;


                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                dtCurrentTable.Rows.Clear();
                ViewState["tblPlatePurchase"] = null;
                AddDefaultFirstRecord();
                txtTotalPlateQty.Text = "0";
                txtTotalAmount.Text = "0";

                txtOrderDate.Text = "";
                ddlReceiveBy.SelectedIndex = -1;
                ddlReceiveAt.SelectedIndex = 0;

                ddlEdition.SelectedIndex = 0;
                ddlBookName.SelectedIndex = 0;
                ddlType.SelectedIndex = 0;
                ddlClass.SelectedIndex = 0;
                ddlGroup.SelectedIndex = 0;
                ddlCategory.SelectedIndex = 0;
                
            }
            catch (Exception)
            {


            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string OrderNo = txtOrderNo.Text;
            Response.Redirect("~/Pro_Rpt_PlatePurchaseOrder.aspx?No=" + OrderNo);
        }

    }
}