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
    public partial class Pro_CoverReceive : System.Web.UI.Page
    {
        string FormID = "PF009";
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
                    LaminationSize();
                }
                if (Session["CoverReceiveId"] != null)
                {
                    txtReceivedID.Text = Session["CoverReceiveId"].ToString();
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

        private void LaminationSize()
        {
           

            List<Li_LemiSizeBasic> lemiSizes = new List<Li_LemiSizeBasic>();
            lemiSizes = Li_LemiSizeBasicManager.GetAllLi_LemiSizeBasics();
            foreach (Li_LemiSizeBasic size in lemiSizes)
            {
                ListItem item = new ListItem(size.LemiSize, size.LemiSizeID);
                ddlLaminationSize.Items.Add(item);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                if (ddlBookName.SelectedValue == "")
                {
                
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give book code');", true);
                    ddlBookName.Focus();
                    return;
                }


                if (txtQuantity.Text == "")
                {
                     
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Give a valid Quantity.');", true);
                    txtQuantity.Focus();
                    return;
                }



                Li_GodownReceive_Cover li_GodownReceive_Cover = new Li_GodownReceive_Cover();
                li_GodownReceive_Cover.SourceNo = ddlCoverSource.SelectedIndex;
                li_GodownReceive_Cover.PressID = ddlSourceName.SelectedValue;
                li_GodownReceive_Cover.ReceiveMemo = txtMemoNo.Text;
                li_GodownReceive_Cover.ReceiveBy = Int32.Parse(Session["UserID"].ToString());
                li_GodownReceive_Cover.ReceiveDate = DateTime.Parse(dtpReceiveDate.Text);
                li_GodownReceive_Cover.BookCode = ddlBookName.SelectedValue + "/" + ddlEdition.SelectedItem.Text;
                li_GodownReceive_Cover.Qty = Decimal.Parse(txtQuantity.Text);
                li_GodownReceive_Cover.IsReprinted = false;
                li_GodownReceive_Cover.IsRebind = false;
                li_GodownReceive_Cover.PromotionalItemID = "";
                li_GodownReceive_Cover.IsSpecimen = false;
                li_GodownReceive_Cover.IsopeningStock = false;
                li_GodownReceive_Cover.IsPaid = false;
                li_GodownReceive_Cover.Status_D = 'C';
                li_GodownReceive_Cover.CauseOfDel = "";
                li_GodownReceive_Cover.DelBy = 0;
                li_GodownReceive_Cover.DelDate = DateTime.Now;
                li_GodownReceive_Cover.SizeID = ddlLaminationSize.SelectedValue;
                Session["CoverReceiveId"] = Li_GodownReceive_CoverManager.InsertLi_GodownReceive_Cover(li_GodownReceive_Cover);

            

                string message = "Saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);

            }
            catch (Exception ex)
            {
                
            }


        }

        protected void ddlCoverSource_SelectedIndexChanged(object sender, EventArgs e)
        {

           

            if (ddlCoverSource.SelectedIndex == 1)
            {
                ddlSourceName.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
                ddlSourceName.DataTextField = "PressName";
                ddlSourceName.DataValueField = "PressID";
                ddlSourceName.DataBind();
                ddlSourceName.Items.Insert(0, new ListItem("--select--", ""));

            }

            else if (ddlCoverSource.SelectedIndex == 2)
            {
                ddlSourceName.DataSource = Li_LeminatioPartyInfoManager.GetAllLi_LeminatioPartyInfos();
                ddlSourceName.DataTextField = "Name";
                ddlSourceName.DataValueField = "ID";
                ddlSourceName.DataBind();
                ddlSourceName.Items.Insert(0, new ListItem("--select--", ""));
            }


            else if (ddlCoverSource.SelectedIndex == 3)
            {
                ddlSourceName.DataSource = Li_BookCoverSupInfoManager.GetAllLi_BookCoverSupInfos();
                ddlSourceName.DataTextField = "SupName";
                ddlSourceName.DataValueField = "COSCode";
                ddlSourceName.DataBind();
                ddlSourceName.Items.Insert(0, new ListItem("--select--", ""));
            }
            else
            {

            }

           
        
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string ReceiveId = txtReceivedID.Text;
            Response.Redirect("~/Pro_Rpt_GodownCoverReceivingMemo.aspx?No=" + ReceiveId +"&SourceId="+ddlSourceName.SelectedValue );
        }

    }
}