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

    public partial class Pro_BindingOrder : System.Web.UI.Page
    {
        string FormID = "PF006";
        protected void Page_Load(object sender, EventArgs e)
        
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                getUserAccess();
                    LoadYear();


                    LoadBookBinder();

                    LoadPress();

                    LoadBook();

                    LoadBookType();

                    LoadClass();
                }

                    gvwBinderOrder.DataSource = Li_BindOrderManager.GetAll_BindOrder(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null, null, null).Tables[0];
                    gvwBinderOrder.DataBind();
                

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
                        btnLoad.Enabled = true;
                    }
                    else
                    {
                        btnLoad.Enabled = false;
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


        private void LoadClass()
        {
            ddlClass.DataSource = Li_ClassesManager.GetAllLi_Classess();
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("--Select--", ""));
        }

        private void LoadBookType()
        {
            LoadComboData loadClass = new LoadComboData();
            loadClass.BookType(ddlType);
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("--Select--", ""));
        }


        private void LoadPress()
        {
            ddlPressName.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlPressName.DataTextField = "PressName";
            ddlPressName.DataValueField = "PressID";
            ddlPressName.DataBind();
            ddlPressName.Items.Insert(0, new ListItem("--Select--", ""));
        }

        private void LoadBookBinder()
        {
            ddlBinderName.DataSource = Li_BookBinderInfoManager.GetAllLi_BookBinderInfos();
            ddlBinderName.DataTextField = "BinderName";
            ddlBinderName.DataValueField = "BinderCode";
            ddlBinderName.DataBind();
            ddlBinderName.Items.Insert(0, new ListItem("--Select--", ""));
        }

        private void LoadBook()
        {
            ddlBookName.DataSource = li_BookInformationManager.Get_BookInformations_ComboSourceData();
            ddlBookName.DataTextField = "BookName";
            ddlBookName.DataValueField = "BookID";
            ddlBookName.DataBind();
            ddlBookName.Items.Insert(0, new ListItem("--Select--", ""));

        }

        private void LoadYear()
        {
            ddlEdition.DataSource = li_ChallanManager.LoadYear().Tables[0];
            ddlEdition.DataTextField = "Edition";
            //txtEdition.ValueMember = "Edition";
            ddlEdition.DataBind();


        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string bookid = ddlBookName.SelectedIndex == -1 ? string.Empty : ddlBookName.SelectedValue;
                string pressid = ddlPressName.SelectedIndex == -1 ? string.Empty : ddlPressName.SelectedValue;
                string binderID = ddlBinderName.SelectedIndex == -1 ? string.Empty : ddlBinderName.SelectedValue;
                bool cover = chkCover.Checked ? true : false;
                bool inner = chkInner.Checked ? true : false;
                bool forma = chkForma.Checked ? true : false;


                gvwBinderOrder.DataSource = Li_BindOrderManager.GetAll_BindOrder(bookid, ddlClass.SelectedItem.Text, ddlType.SelectedItem.Text, ddlEdition.SelectedItem.Text, binderID, pressid, cover, inner, forma).Tables[0];
                gvwBinderOrder.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {

            gvwBinderOrder.DataSource = Li_BindOrderManager.GetAll_BindOrder(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null, null, null).Tables[0];
            gvwBinderOrder.DataBind();
        }

        protected void gvwBinderOrder_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwBinderOrder.PageIndex = e.NewPageIndex;
            gvwBinderOrder.DataSource = Li_BindOrderManager.GetAll_BindOrder(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null, null, null).Tables[0];
            gvwBinderOrder.DataBind();
        }
    }
}