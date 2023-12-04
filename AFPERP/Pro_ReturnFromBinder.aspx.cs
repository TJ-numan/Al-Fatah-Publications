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
    public partial class Pro_ReturnFromBinder : System.Web.UI.Page
    {
        string FormID = "PF039";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    LoadCategory();
                    LoadBookBinder();
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
        private void LoadBookBinder()
        {
            ddlBookBinderName.DataSource = Li_BookBinderInfoManager.GetAllLi_BookBinderInfos();
            ddlBookBinderName.DataTextField = "BinderName";
            ddlBookBinderName.DataValueField = "BinderCode";
            ddlBookBinderName.DataBind();
            ddlBookBinderName.Items.Insert(0, new ListItem("--Select--", ""));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewRecordRowToGrid();
            }
            catch (Exception ex)
            {
                
            }
        }
        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblReturnFromBinder";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("BookName", typeof(string));
            dt.Columns.Add("BookId", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            dt.Columns.Add("ItemType", typeof(string));
            dt.Columns.Add("ItemTypeId", typeof(string));
            dt.Columns.Add("Qty", typeof(int));


            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblReturnFromBinder"] = dt;
            //bind Gridview  
            gvwReturnFB.DataSource = dt;
            gvwReturnFB.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void AddNewRecordRowToGrid()
        {


            DataTable dtCurrentTable = (DataTable)ViewState["tblReturnFromBinder"];
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
                    drCurrentRow["Type"] = ddlType.SelectedItem.Text;
                    drCurrentRow["Edition"] = ddlEdition.SelectedItem.Text;
                    drCurrentRow["ItemType"] = ddlItemType.SelectedItem.Text;
                    drCurrentRow["ItemTypeId"] = ddlItemType.SelectedIndex + 1;
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

                ViewState["tblReturnFromBinder"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvwReturnFB.DataSource = dtCurrentTable;
                gvwReturnFB.DataBind();


                UpdateTotalPrice(dtCurrentTable);
            }


        }

        private void UpdateTotalPrice(DataTable dtCurrentTable)
        {
            int totalPlateQty = 0;
            for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
            {
                int plateQty = Int32.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                totalPlateQty += plateQty;
            }

            txtTotalPlateQty.Text = String.Format("{0:0.##}", totalPlateQty);
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblReturnFromBinder"];
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

                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a date');", true);
                    return;
                }

                DataTable dtCurrentTable = (DataTable)ViewState["tblReturnFromBinder"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    Li_BinderReturn binderReturn = new Li_BinderReturn();
                    binderReturn.BinderID = ddlBookBinderName.SelectedValue;
                    binderReturn.CreatedBy = int.Parse(Session["UserID"].ToString());
                    binderReturn.CreatedDate = DateTime.Now;
                    binderReturn.ReceiveDate = DateTime.Parse(txtOrderDate.Text);
                    binderReturn.Statud_D = 'C';
                    binderReturn.TotalQty = decimal.Parse(txtTotalPlateQty.Text);
                    string result = Li_BinderReturnManager.InsertLi_BinderReturn(binderReturn);

                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {

                        Li_BinderReturnDetail binderReceiveDetail = new Li_BinderReturnDetail();


                        binderReceiveDetail.ReceiveID = result;
                        binderReceiveDetail.BookCode = dtCurrentTable.Rows[i]["BookId"].ToString() + "/" + dtCurrentTable.Rows[i]["Edition"].ToString();
                        binderReceiveDetail.Qty = decimal.Parse(dtCurrentTable.Rows[i]["Qty"].ToString());
                        binderReceiveDetail.ReceiveItemType = int.Parse(dtCurrentTable.Rows[i]["ItemTypeId"].ToString());
                        Li_BinderReturnDetailManager.InsertLi_BinderReturnDetail(binderReceiveDetail);

                    }

                    txtReceiceNo.Text = result;
                }

                string message = "Saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script,
                    true);

                dtCurrentTable.Rows.Clear();
                ViewState["tblReturnFromBinder"] = null;
                AddDefaultFirstRecord();
                txtTotalPlateQty.Text = "0";

            }
            catch (Exception)
            {


            }

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string RecNo = txtReceiceNo.Text;
            Response.Redirect("~/Pro_PrintReturnFromBinderMemo.aspx?No=" + RecNo);
        }
    }
}