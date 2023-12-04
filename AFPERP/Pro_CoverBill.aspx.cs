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
    public partial class Pro_CoverBill : System.Web.UI.Page
    {
        string FormID = "PF008";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    getUserAccess();
                    LoadCategory();
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

        protected void ddlCoverSource_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (ddlSource.SelectedIndex == 1)
            {
                ddlSupplier.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
                ddlSupplier.DataTextField = "PressName";
                ddlSupplier.DataValueField = "PressID";
                ddlSupplier.DataBind();
                ddlSupplier.Items.Insert(0, new ListItem("--select--", ""));

            }

            else if (ddlSource.SelectedIndex == 2)
            {
                ddlSupplier.DataSource = Li_LeminatioPartyInfoManager.GetAllLi_LeminatioPartyInfos();
                ddlSupplier.DataTextField = "Name";
                ddlSupplier.DataValueField = "ID";
                ddlSupplier.DataBind();
                ddlSupplier.Items.Insert(0, new ListItem("--select--", ""));
            }


            else if (ddlSource.SelectedIndex == 3)
            {
                ddlSupplier.DataSource = Li_BookCoverSupInfoManager.GetAllLi_BookCoverSupInfos();
                ddlSupplier.DataTextField = "SupName";
                ddlSupplier.DataValueField = "COSCode";
                ddlSupplier.DataBind();
                ddlSupplier.Items.Insert(0, new ListItem("--select--", ""));
            }
            else
            {

            }



        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                txtTotalQty.Text = "0";
                txtTotalBill.Text = "0";

                gvwCoverBill.DataSource = null;

                DataSet ds = new DataSet();
                //ds = Li_GodownReceiveManager.GetAll_GodownReceiveCoverForBill_R2(int.Parse(ddlSource.SelectedValue), ddlSupplier.SelectedValue);

                string BookAcCode=ddlBookName.SelectedValue + "/" + ddlEdition.SelectedValue;
                ds = Li_GodownReceiveManager.GetAll_GodownReceiveCoverForBill(ddlSupplier.SelectedValue,BookAcCode, "0");

                gvwCoverBill.DataSource = ds.Tables[0];
                gvwCoverBill.DataBind();



            }
            catch (Exception)
            {


            }

        }


        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                decimal totalCQty = 0; //decimal totalBill = 0.0m;
                for (int i = 0; i < gvwCoverBill.Rows.Count; i++)
                {
                    CheckBox chkRow = (gvwCoverBill.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);
                    if (chkRow.Checked == true)
                    {
                        decimal CQty = decimal.Parse(gvwCoverBill.Rows[i].Cells[7].Text);
                        //decimal bill = decimal.Parse(gvwCoverBill.Rows[i].Cells[3].Text);

                        totalCQty += CQty;
                        //totalBill += bill;
                    }

                    //txtTotalBill.Text = string.Format("{0:0.##}", totalBill);
                    txtTotalQty.Text = string.Format("{0:0.##}", totalCQty);

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

                if (txtBillNo.Text.Trim() == "")
                {
                   
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please Give a Bill no');", true);
                    
                    txtBillNo.Focus();
                    return;
                }


                if (txtBillRate.Text.Trim() == "" || decimal.Parse(txtBillRate.Text) == 0.0m)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give the rate');", true);
                    return;
                }

                if (dtpBillDate.Text=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Bill Date missing');", true);
                    return;

                }

                Li_CoverBill tempLi_CoverBill = new Li_CoverBill();
                tempLi_CoverBill.BillDate = DateTime.Parse(dtpBillDate.Text);
                tempLi_CoverBill.BillNo = txtBillNo.Text;
                tempLi_CoverBill.SupplierID = ddlSupplier.SelectedValue;
                tempLi_CoverBill.BookCode = ddlBookName.SelectedValue + "/" + ddlEdition.SelectedValue;
                tempLi_CoverBill.IsRebind = false;
                tempLi_CoverBill.TotalQty = Decimal.Parse(txtTotalQty.Text);

                tempLi_CoverBill.BillRate = Decimal.Parse(txtBillRate.Text);
                tempLi_CoverBill.TotalBill = Decimal.Parse(txtTotalBill.Text);
                tempLi_CoverBill.CreatedDate = DateTime.Now;
                tempLi_CoverBill.CreateBy = int.Parse(Session["UserID"].ToString());
                tempLi_CoverBill.Status_D = 'C';
                tempLi_CoverBill.DelDate = DateTime.Now;
                tempLi_CoverBill.CauseOfDel = "";
                tempLi_CoverBill.DeleBy = 0;
                string result = Li_CoverBillManager.InsertLi_CoverBill(tempLi_CoverBill);



                for (int i = 0; i < gvwCoverBill.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvwCoverBill.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);
                    if (chkRow.Checked == true)
                    {

                        Li_CoverBillDetail tempLi_CoverBillDetail = new Li_CoverBillDetail();


                        tempLi_CoverBillDetail.BillNo = result;
                        tempLi_CoverBillDetail.ReceiveID = gvwCoverBill.Rows[i].Cells[1].Text;
                        tempLi_CoverBillDetail.Qty = Decimal.Parse(gvwCoverBill.Rows[i].Cells[3].Text);

                        Li_CoverBillDetailManager.InsertLi_CoverBillDetail(tempLi_CoverBillDetail);



                    }
                }


                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);

                ddlType.SelectedValue = "0";

                gvwCoverBill.DataSource = null;
                ddlSupplier.SelectedValue = "0";
                ddlSource.SelectedValue = "0";

 

            }
            catch (Exception)
            {


            }
        }

        protected void btnPrintBillPrint_Click(object sender, EventArgs e)
        {

            try
            {
                string BillNo = txtBillNo.Text;
                string SourceNo = ddlSource.SelectedValue;
                string Supplier = ddlSupplier.SelectedValue;
                string billdate = dtpBillDate.Text;

                Response.Redirect("~/Pro_Rpt_PrintCoverBill.aspx?No=" + BillNo + "&SourceNo=" + SourceNo + "&Supplier="+Supplier+ "&date=" + billdate);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}