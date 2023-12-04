using BLL.Classes;
using BLL.HR;
using Common.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmAssetTransfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LoadDepartments(ddlDepartmentFrom);
                    LoadComboData.LoadDepartments(ddlDepartmentTo);       
                }
            }
            catch (Exception)
            {


            }
        }

        protected void ddlDepartmentFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEmployeeFrom.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListByDepID(int.Parse(ddlDepartmentFrom.SelectedValue));
            ddlEmployeeFrom.DataTextField = "EmpName";
            ddlEmployeeFrom.DataValueField = "EmpSl";
            ddlEmployeeFrom.DataBind();
            ddlEmployeeFrom.Items.Insert(0, new ListItem("Select Any", "0"));
        }

        protected void ddlDepartmentTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEmployeeTo.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListByDepID(int.Parse(ddlDepartmentTo.SelectedValue));
            ddlEmployeeTo.DataTextField = "EmpName";
            ddlEmployeeTo.DataValueField = "EmpSl";
            ddlEmployeeTo.DataBind();
            ddlEmployeeTo.Items.Insert(0, new ListItem("Select Any", "0"));
        }

        protected void txtAssetCode_TextChanged(object sender, EventArgs e)
        {

            try
            {
                clear();

                DataTable dtAsset = Li_AssetTransferManager.GetAssetInfoForTransferByAssetCode(txtAssetCode.Text);
                if (dtAsset.Rows.Count > 0)
                {
                    ViewState["AssetId"] = dtAsset.Rows[0]["AssetId"].ToString();
                    txtAssetName.Text = dtAsset.Rows[0]["AssetName"].ToString();

                    ddlDepartmentFrom.SelectedValue = dtAsset.Rows[0]["DepId"].ToString();

                    ddlEmployeeFrom.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListByDepID(int.Parse(dtAsset.Rows[0]["DepId"].ToString()));
                    ddlEmployeeFrom.DataTextField = "EmpName";
                    ddlEmployeeFrom.DataValueField = "EmpSl";
                    ddlEmployeeFrom.DataBind();
                    ddlEmployeeFrom.Items.Insert(0, new ListItem("Select Any", "0"));

                    ddlEmployeeFrom.SelectedValue = dtAsset.Rows[0]["EmployeID"].ToString();



                    dtpPurchaseDate.Text = DateTime.Parse(dtAsset.Rows[0]["PurchaseDate"].ToString()).ToString("yyyy/MM/dd");
                    dtpWarrantyDate.Text = DateTime.Parse(dtAsset.Rows[0]["WarrantyPeriod"].ToString()).ToString("yyyy/MM/dd");
                    dtpLifeTimeDate.Text = DateTime.Parse(dtAsset.Rows[0]["Life_Time"].ToString()).ToString("yyyy/MM/dd");
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
                li_AssetTransfer assetTrns = new li_AssetTransfer();
                assetTrns.AssetId = Int32.Parse(ViewState["AssetId"].ToString());
                assetTrns.FromDepId =  Int32.Parse(ddlDepartmentFrom.SelectedValue);
                assetTrns.FromEmpId =  Int32.Parse(ddlEmployeeFrom.SelectedValue);
                assetTrns.ToDepId =    Int32.Parse(ddlDepartmentTo.SelectedValue);
                assetTrns.ToEmpId = Int32.Parse(ddlEmployeeTo.SelectedValue) ;
                assetTrns.TransferDate = DateTime.Now;
                assetTrns.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                assetTrns.CreatedDate = DateTime.Now;

                Li_AssetTransferManager.InsertLi_AssetTransfer(assetTrns);

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
     
            catch (Exception)
            {
                
            }
        }

        private void clear()
        {
            txtAssetName.Text = "";
            dtpPurchaseDate.Text = "";
            dtpWarrantyDate.Text = "";
            dtpLifeTimeDate.Text = "";
            ddlDepartmentFrom.SelectedValue = "0";


            ddlEmployeeFrom.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListByDepID(int.Parse(ddlDepartmentFrom.SelectedValue));
            ddlEmployeeFrom.DataTextField = "EmpName";
            ddlEmployeeFrom.DataValueField = "EmpSl";
            ddlEmployeeFrom.DataBind();
            ddlEmployeeFrom.Items.Insert(0, new ListItem("Select Any", "0"));
        }

    }
}