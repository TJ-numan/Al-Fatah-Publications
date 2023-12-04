using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class ACC_MRSheet : System.Web.UI.Page
    {
        string FormID = "AF003";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadComboData.LoadBank(ddlBank);
                    LoadComboData.LoadTransactionTypes( ddlDepositType); 
                    AddDefaultFirstRecord();
                }

                if (Session["SheetNo"] != null)
                {
                    txtSheetNo.Text = Session["SheetNo"].ToString();
                }



                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;
                String FromDate;

                if (month >= 11)
                {
                    var mydate = new DateTime(year, 11, 02);

                    FromDate = String.Format("{0:yyyy-MM-dd}", mydate);
                }

                else
                {
                    var mydate = new DateTime(year - 1, 11, 02);
                    FromDate = String.Format("{0:yyyy-MM-dd}", mydate);
                }

                Calender1.StartDate = DateTime.Parse(FromDate);
                Calender1.EndDate = DateTime.Now;
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
                        Response.Redirect("~/AccountsHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void AddDefaultFirstRecord()
        {
            try
            {


                DataTable dt = new DataTable();
                DataRow dr;
                bool fromLinkButton = false;
                dt.TableName = "tblMrSheetDetail";
                dt.Columns.Add("Serial", typeof(int));
                dt.Columns.Add("DepositDate", typeof(DateTime));
                dt.Columns.Add("DepositTypeId", typeof(int));
                dt.Columns.Add("DepositType", typeof(string));
                dt.Columns.Add("DDTTRDNo", typeof(string));
                dt.Columns.Add("BankCode", typeof(string));
                dt.Columns.Add("BankBranch", typeof(string));
                dt.Columns.Add("Amount", typeof(decimal));
                dt.Columns.Add("AccNo", typeof(string));
                dt.Columns.Add("Remark", typeof(string));
                dr = dt.NewRow();
                dt.Rows.Add(dr);
                ViewState["tblMrSheetDetail"] = dt;
                gvMRSheet.DataSource = dt;
                gvMRSheet.DataBind();
                ViewState["LinkClick"] = fromLinkButton;
            }
            catch (Exception)
            {

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAmount.Text.Trim() == "" || decimal.Parse(txtAmount.Text) == 0.0m)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Amount.');", true);
                    return;
                }
                AddNewRecordRowToGrid();
            }
            catch (Exception)
            {


            }
        }
        private void AddNewRecordRowToGrid()
        {
            // check view state is not null  
            if (ViewState["tblMrSheetDetail"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["tblMrSheetDetail"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultFirstRecord();
                    txtTotalAmount.Text = "";
                    txtRemarks.Text = "";
                    return;
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
                        
                        drCurrentRow["DepositDate"] = dtpDepositDate.Text;
                        drCurrentRow["DepositTypeId"] = Int32.Parse(ddlDepositType.SelectedValue);
                        drCurrentRow["DepositType"] = ddlDepositType.SelectedItem.Text;
                        drCurrentRow["DDTTRDNo"] = txtDDTTRDNo.Text;
                        drCurrentRow["BankCode"] = ddlBank.SelectedValue;
                        drCurrentRow["BankBranch"] = txtBankBranch.Text;
                        drCurrentRow["Amount"] = decimal.Parse(txtAmount.Text);
                        drCurrentRow["AccNo"] = txtAccNo.Text;
                        drCurrentRow["Remark"] = txtRemarkInv.Text;
                        ClearTextBoxData();
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

                }


                ViewState["tblMrSheetDetail"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                gvMRSheet.DataSource = dtCurrentTable;
                gvMRSheet.DataBind();
                decimal subTotal = 0.0m;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        decimal unitTotal = decimal.Parse(dtCurrentTable.Rows[i]["Amount"].ToString());
                        subTotal += unitTotal;
                    }


                txtTotalAmount.Text = subTotal.ToString();
                }

                txtDDTTRDNo.Focus();
            }

        }

        private void ClearTextBoxData()
        { 
            txtDDTTRDNo.Text = string.Empty; 
            txtBankBranch.Text = string.Empty;
            txtAmount.Text = string.Empty;
           
        }

        protected void lblDelete_OnClick(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblMrSheetDetail"];
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
                DataTable dtCurrentTable = (DataTable)ViewState["tblMrSheetDetail"];
                if (decimal.Parse(txtTotalAmount.Text) <= 0.0m)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please add minimum one collection.');", true);
                    return;
                }
                if (Int32.Parse(ddlRegion.SelectedValue)==0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select Region For!');", true);
                    return;
                }
                Li_MRSheet mrSheet = new Li_MRSheet();
                mrSheet.CreateBy =Int32.Parse ( Session["UserID"].ToString());
                mrSheet.CreatedDate = DateTime.Now;
                mrSheet.IsLocked = false;
                mrSheet.IsReSend = false;
                mrSheet.IsSend = false;
                mrSheet.LockedDate = DateTime.Now;
                mrSheet.LockedId = 0;
                mrSheet.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                mrSheet.ModifiedDate = DateTime.Now;
                mrSheet.MRId = Int32.Parse(ddlRegion.SelectedValue);
                mrSheet.Remarks = txtRemarks .Text ;
                mrSheet.ReSendDate = DateTime.Now;
                mrSheet.ReSendId = 0;
                mrSheet.SendDate = DateTime.Now;
                mrSheet.SenderId = 0;
                mrSheet.TotalAmount = decimal.Parse(txtTotalAmount .Text );
                mrSheet.MRDate = DateTime.Now;
                Session ["SheetNo"]= Li_MRSheetManager.InsertLi_MRSheet(mrSheet);

               for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
               { 
                   Li_MRSheetDetail mrDetailSheet = new Li_MRSheetDetail();
                   mrDetailSheet.AccountNo = dtCurrentTable.Rows[i]["AccNo"].ToString();
                   mrDetailSheet.Amount = decimal.Parse(dtCurrentTable.Rows[i]["Amount"].ToString());
                   mrDetailSheet.BankAddress = dtCurrentTable.Rows[i]["BankBranch"].ToString();
                   mrDetailSheet.BankCode = dtCurrentTable.Rows[i]["BankCode"].ToString();
                   mrDetailSheet.BankSlipNo = dtCurrentTable.Rows[i]["DDTTRDNo"].ToString();
                   mrDetailSheet.CollectionDate = DateTime.Parse(dtCurrentTable.Rows[i]["DepositDate"].ToString());
                   mrDetailSheet.DepositForId = 0;
                   mrDetailSheet.DepositType = Int32.Parse(dtCurrentTable.Rows[i]["DepositTypeId"].ToString());
                   mrDetailSheet.LibraryID = "";
                   mrDetailSheet.MRDetId = 0;
                   mrDetailSheet.MRId = Int32.Parse(Session["SheetNo"].ToString());
                   mrDetailSheet.Remark = dtCurrentTable.Rows[i]["Remark"].ToString();
                   mrDetailSheet.CauseOfDelete = "";
                   mrDetailSheet.Com = "";
                   mrDetailSheet.DeleteDate = DateTime.Now;
                   mrDetailSheet.DeletedBy = 0;
                   mrDetailSheet.IsDeleted = false;
                   mrDetailSheet.IsHeldUp = false;
                   mrDetailSheet.ModifiedBy = Convert.ToInt32(Session["UserID"].ToString());
                   Li_MRSheetDetailManager .InsertLi_MRSheetDetail (mrDetailSheet);
               } 

               dtCurrentTable.Rows.Clear();

               txtSheetNo.Text = Session["SheetNo"].ToString();
               string message = "Saved successfully.";
               string script = "window.onload = function(){ alert('";
               script += message;
               script += "');";
               script += "window.location = '";
               script += Request.Url.AbsoluteUri;
               script += "'; }";
               ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",script, true);


            }
            catch (Exception)
            {

            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Acc_Rpt_MRSheetPrint.aspx?SheetNo="+txtSheetNo .Text );
        }
    }
}