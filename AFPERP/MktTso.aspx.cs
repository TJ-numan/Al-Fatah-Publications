using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Classes;
using Common;
using Common.Marketing;
using System.Data;

namespace BLL
{
    public partial class MktTso : System.Web.UI.Page
    {
        string FormID = "MF002";
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    LoadTerritory();
                    LoadAllTSO();
                    getUserAccess();
                    GetAllDistrict();
                    GetAllLi_TransportInfo();

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
                        Response.Redirect("~/MarketingHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }
        private void LoadTerritory()
        {
            try
            {

                ddlTerritory.DataSource = Li_TeritoryManager.GetAllLi_Teritories();
                ddlTerritory.DataTextField = "TeritoryName";
                ddlTerritory.DataValueField = "TeritoryCode";
                ddlTerritory.DataBind();
                ddlTerritory.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            catch (Exception)
            {

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Li_SalesPerson _salesperson = new Li_SalesPerson();
                _salesperson.EmployeeCode = txtEmployeeCode.Text;
                _salesperson.Name = txtName.Text;
                _salesperson.Address = txtAddress.Text;
                _salesperson.Mobile = txtMobile.Text;
                _salesperson.EmailID = txtEmail.Text;
                _salesperson.RegionID = 0; 
                _salesperson.AreaID = 0;   
                _salesperson.TeritoryID = ddlTerritory.SelectedValue.ToString();
                _salesperson.ThanaID = ddlThana.SelectedValue.ToString();
                _salesperson.TransportID = ddlTransportMain.Text;
                _salesperson.TransportID2 = ddlTransportAlter.Text;
                _salesperson.TSOID = "";
                _salesperson.CreatedBy = int.Parse(Session["UserID"].ToString());
                _salesperson.CreatedDate = DateTime.Now;
                _salesperson.ModifiedBy = int.Parse(Session["UserID"].ToString());
                _salesperson.ModifiedDate = DateTime.Now;
                string result = Li_SalesPersonManager.InsertLi_SalesPerson(_salesperson);
                if (result != string.Empty)
                {
                    string message = "Saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += Request.Url.AbsoluteUri;
                    script += "'; }";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
                    script, true);
                }
                txtTsoID.Text = result;
                LoadAllTSO();
                ClearAllData();
            }
            catch (Exception )
            {

            }
        
        }

        private void ClearAllData()
        {
            
            txtName.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddlTerritory.SelectedIndex = 0;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Li_SalesPerson _salesperson = new Li_SalesPerson();
                _salesperson.Name = txtName.Text;
                _salesperson.Address = txtAddress.Text;
                _salesperson.Mobile = txtMobile.Text;
                _salesperson.RegionID = 0;
                _salesperson.AreaID = 0;
                _salesperson.TeritoryID = ddlTerritory.SelectedValue.ToString();
                _salesperson.TSOID = txtTsoID.Text;
                int result =Li_SalesPersonManager.UpdateLi_SalesPerson(_salesperson);
                if (result > 0)
                {
                    string message = "alert('Updated Successfully')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", message, true);
                }
                LoadAllTSO();
            }
            catch (Exception )
            {
               
            }
        }
        private void LoadAllTSO()
        {
            try
            {
               Li_SalesPersonManager.Get_AllTSO();
            }
            catch (Exception)
            {
                
                
            }
          
        }
        private void GetAllDistrict()
        {
            try
            {
                ddlDristrict.DataSource = li_DistrictManager.GetAll_Districts();
                ddlDristrict.DataTextField = "DistrictName";
                ddlDristrict.DataValueField = "DistrictID";
                ddlDristrict.DataBind();
                ddlDristrict.Items.Insert(0, new ListItem("--Select District--", "0"));
            }
            catch (Exception)
            {

            }
        }

        protected void ddlDristrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlThana.DataSource = li_ThanaManager.Get_ThanaByDistrictID(int.Parse(ddlDristrict.SelectedValue));
                ddlThana.DataTextField = "ThanaName";
                ddlThana.DataValueField = "ThanaID";
                ddlThana.DataBind();
            }
            catch (Exception)
            {

            }
        }

        private void GetAllLi_TransportInfo()
        {
            try
            {
                ddlTransportMain.DataSource = Li_TransportInfoManager.GetAllLi_TransportInfos();
                ddlTransportMain.DataTextField = "TransportName";
                ddlTransportMain.DataValueField = "TransportID";
                ddlTransportMain.DataBind();
                ddlTransportMain.Items.Insert(0, new ListItem("--Select Primary Transport--", "0"));

                ddlTransportAlter.DataSource = Li_TransportInfoManager.GetAllLi_TransportInfos();
                ddlTransportAlter.DataTextField = "TransportName";
                ddlTransportAlter.DataValueField = "TransportID";
                ddlTransportAlter.DataBind();
                ddlTransportAlter.Items.Insert(0, new ListItem("--Select Alternative Transport --", "0"));
            }
            catch (Exception)
            {

            }
        }

        protected void txtSearchTSOName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

            }
        }
        protected void gvwLibraryInformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
}