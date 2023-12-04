using BLL.Classes;
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
    public partial class Pro_PastingOrder : System.Web.UI.Page
    {
        string FormID = "PF019";
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

                    LoadPestingParty();

                    LoadPestingType();

                    LoadBookSize();
                    txtTotalQty.Attributes.Add("readonly", "readonly");
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
                        btnPOSave.Enabled = true;
                    }
                    else
                    {
                        btnPOSave.Enabled = false;
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

        private void LoadPestingParty()
        {

            ddlPartyName.DataSource = Li_PestingPartyInfoManager.GetAllLi_PestingPartyInfos();
            ddlPartyName.DataTextField = "Name";
            ddlPartyName.DataValueField = "ID";
            ddlPartyName.DataBind();
            ddlPartyName.Items.Insert(0, new ListItem("--select--", "0"));
        }

        private void LoadBookSize()
        {
            ddlBookSize.DataSource = Li_BookSizeBasicManager.GetAllLi_BookSizeBasics();
            ddlBookSize.DataTextField = "SizeType";
            ddlBookSize.DataValueField = "BookSizeID";
            ddlBookSize.DataBind();
            ddlBookSize.Items.Insert(0, new ListItem("--select--", "0"));
        }
        private void LoadPestingType()
        {
            ddlPestingType.DataSource = Li_PestingBasicManager.GetAllLi_PestingBasics();
            ddlPestingType.DataTextField = "Type";
            ddlPestingType.DataValueField = "ID";
            ddlPestingType.DataBind();
            ddlPestingType.Items.Insert(0, new ListItem("--select--", "0"));
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
            }
            catch (Exception)
            {
            }

        }

        protected void txtInner_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int Inner = txtInner.Text == "" ? 0 : int.Parse(txtInner.Text);
                int Suggestion = txtSuggestion.Text == "" ? 0 : int.Parse(txtSuggestion.Text);
                int IndexP = txtIndex.Text == "" ? 0 : int.Parse(txtIndex.Text);
                int MainPa = txtMainPart.Text == "" ? 0 : int.Parse(txtMainPart.Text);
                int lastPage = txtLastPart.Text == "" ? 0 : int.Parse(txtLastPart.Text);

                txtTotalPages.Text = (Inner + Suggestion + IndexP + MainPa + lastPage).ToString();//(( endingP- startingP) + 1).ToString();
            }
            catch (Exception ex)
            {

            }
        }


        protected void btnPOSave_Click(object sender, EventArgs e)
        {

            try
            {
                string result = null;


                try
                {
                    // Pesting main Entry

                    Li_Pesting li_Pesting = new Li_Pesting();


                    li_Pesting.W_Date = DateTime.Parse(dtpWorkingDate.Text);
                    li_Pesting.PartyID = ddlPartyName.SelectedValue.ToString();
                    li_Pesting.BookID = ddlBookName.SelectedValue.ToString();
                    li_Pesting.Edition = txtEdition.Text;
                    li_Pesting.BookSizeID = ddlBookSize.SelectedValue.ToString();
                    li_Pesting.Exam = txtExam.Text;
                    li_Pesting.PageTotal = Int32.Parse(txtTotalPages.Text);
                    li_Pesting.FormaTotal = txtTotalQty.Text.Trim() == "" ? 0 : Decimal.Parse(txtTotalQty.Text);
                    li_Pesting.Pest_Bill_Forma = txtFormaNoPestingBill.Text.Trim() == "" ? 0 : Decimal.Parse(txtFormaNoPestingBill.Text);
                    li_Pesting.Rate = txtformaRate.Text.Trim() == "" ? 0 : Decimal.Parse(txtformaRate.Text);
                    li_Pesting.Amount = txtAmount.Text.Trim() == "" ? 0 : Decimal.Parse(txtAmount.Text);
                    li_Pesting.CreatedDate = DateTime.Now;
                    li_Pesting.CreatedBy = int.Parse(Session["UserID"].ToString());
                    li_Pesting.Pest_OrderNo = txtOrderNo.Text;
                    li_Pesting.PestingType = ddlPestingType.SelectedItem.Text;
                    result = Li_PestingManager.InsertLi_Pesting(li_Pesting);

                }

                catch (Exception ex)
                {

                }


                // Inner Pesting Entry Start
                try
                {

                    Li_Pesting_Inner li_Pesting_Inner = new Li_Pesting_Inner();


                    li_Pesting_Inner.OrderNo = txtOrderNo.Text;
                    li_Pesting_Inner.Fi_Color = txt_inner5color.Text != "" ? Decimal.Parse(txt_inner5color.Text) : 0.0m;
                    li_Pesting_Inner.Fo_Color = txt_inner4color.Text != "" ? Decimal.Parse(txt_inner4color.Text) : 0.0m;
                    li_Pesting_Inner.Thr_Color = txt_inner3color.Text != "" ? Decimal.Parse(txt_inner3color.Text) : 0.0m;
                    li_Pesting_Inner.Tw_Color = txt_inner2color.Text != "" ? Decimal.Parse(txt_inner2color.Text) : 0.0m;
                    li_Pesting_Inner.Si_Color = txt_inner1color.Text != "" ? Decimal.Parse(txt_inner1color.Text) : 0.0m;
                    li_Pesting_Inner.B_W = txt_innerBlack.Text != "" ? Decimal.Parse(txt_innerBlack.Text) : 0.0m;
                    li_Pesting_Inner.Total = txt_innerTotal.Text != "" ? Decimal.Parse(txt_innerTotal.Text) : 0.0m;
                    li_Pesting_Inner.Machine = ddlinnerMachine.Text;
                    li_Pesting_Inner.Status_D = 'C';

                    Li_Pesting_InnerManager.InsertLi_Pesting_Inner(li_Pesting_Inner);
                }
                catch (Exception ex)
                {

                }
                // Forma Pesting Entry Start

                try
                {

                    Li_Pesting_Forma li_Pesting_Forma = new Li_Pesting_Forma();
                    li_Pesting_Forma.OrderNo = txtOrderNo.Text;
                    li_Pesting_Forma.Fi_Color = txt_forma5color.Text != "" ? Decimal.Parse(txt_forma5color.Text) : 0.0m;
                    li_Pesting_Forma.Fo_Color = txt_forma4color.Text != "" ? Decimal.Parse(txt_forma4color.Text) : 0.0m;
                    li_Pesting_Forma.Thr_Color = txt_forma3color.Text != "" ? Decimal.Parse(txt_forma3color.Text) : 0.0m;
                    li_Pesting_Forma.Tw_Color = txt_forma2color.Text != "" ? Decimal.Parse(txt_forma2color.Text) : 0.0m;
                    li_Pesting_Forma.Si_Color = txt_forma1color.Text != "" ? Decimal.Parse(txt_forma1color.Text) : 0.0m;
                    li_Pesting_Forma.B_W = txt_formaBlack.Text != "" ? Decimal.Parse(txt_formaBlack.Text) : 0.0m;
                    li_Pesting_Forma.Total = txt_formaTotal.Text != "" ? Decimal.Parse(txt_formaTotal.Text) : 0.0m;
                    li_Pesting_Forma.Machine = ddlformaMachine.Text;
                    li_Pesting_Forma.Status_D = 'C';
                    Li_Pesting_FormaManager.InsertLi_Pesting_Forma(li_Pesting_Forma);
                }
                catch (Exception ex)
                {

                }

                // Postani Entry Start

                try
                {
                    Li_Pesting_Postani li_Pesting_Postani = new Li_Pesting_Postani();
                    li_Pesting_Postani.OrderNo = txtOrderNo.Text;
                    li_Pesting_Postani.Fi_Color = txt_postani5color.Text != "" ? Decimal.Parse(txt_postani5color.Text) : 0.0m;
                    li_Pesting_Postani.Fo_Color = txt_postani4color.Text != "" ? Decimal.Parse(txt_postani4color.Text) : 0.0m;
                    li_Pesting_Postani.Thr_Color = txt_postani3color.Text != "" ? Decimal.Parse(txt_postani3color.Text) : 0.0m;
                    li_Pesting_Postani.Tw_Color = txt_postani2color.Text != "" ? Decimal.Parse(txt_postani2color.Text) : 0.0m;
                    li_Pesting_Postani.Si_Color = txt_postani1color.Text != "" ? Decimal.Parse(txt_postani1color.Text) : 0.0m;
                    li_Pesting_Postani.B_W = txt_postaniBlack.Text != "" ? Decimal.Parse(txt_postaniBlack.Text) : 0.0m;
                    li_Pesting_Postani.Total = txt_postaniTotal.Text != "" ? Decimal.Parse(txt_postaniTotal.Text) : 0.0m;
                    li_Pesting_Postani.Machine = ddlpostaniMachine.Text;
                    li_Pesting_Postani.Status_D = 'C';
                    Li_Pesting_PostaniManager.InsertLi_Pesting_Postani(li_Pesting_Postani);
                }

                catch (Exception ex)
                {

                }

                // Pages Entry Start

                try
                {
                    Li_Pesting_Page li_Pesting_Page = new Li_Pesting_Page();
                    li_Pesting_Page.OrderNo = txtOrderNo.Text;
                    li_Pesting_Page.Inner_P = txtInner.Text != "" ? Int32.Parse(txtInner.Text) : 0;
                    li_Pesting_Page.Suggestion_P = txtSuggestion.Text != "" ? Int32.Parse(txtSuggestion.Text) : 0;
                    li_Pesting_Page.Index_P = txtIndex.Text != "" ? Int32.Parse(txtIndex.Text) : 0;
                    li_Pesting_Page.Main_P = txtMainPart.Text != "" ? Int32.Parse(txtMainPart.Text) : 0;
                    li_Pesting_Page.Last_P = txtLastPart.Text != "" ? Int32.Parse(txtLastPart.Text) : 0;
                    li_Pesting_Page.Total_P = txtTotalPages.Text != "" ? Int32.Parse(txtTotalPages.Text) : 0;
                    li_Pesting_Page.Status_D = 'C';
                    Li_Pesting_PageManager.InsertLi_Pesting_Page(li_Pesting_Page);
                }
                catch (Exception ex)
                {

                }

                if (result != null)
                {
                    string message = "Saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script,
                        true);
                }
                else
                {
                    string message = "Fail to save Pesting Order.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');}";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
                }
            }
            catch
            {

            }
        }

        protected void btnPOPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pro_PestingPrint.aspx");
        }
    }
}
   
