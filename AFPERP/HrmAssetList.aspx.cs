using BLL.Classes;
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
    public partial class HrmAssetList : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    btnUpdate.Enabled = false;

                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    LoadComboData.LaodAssetBrand(ddlAssetBrand);
                    LoadComboData.LaodAssetCategory(ddlAssetCategory);
                    LoadComboData.LaodAssetVendor(ddlAssetVendor);
                    LoadComboData.LoadDepartments(ddlDepartment);
                    //LoadComboData.LoadEmployeeInfo(ddlEmployee);


                    gvAssetList.DataSource = Li_AssetListManager.GetAllLi_AssetList_Load();
                    gvAssetList.DataBind();
                }
            }
            catch (Exception)
            {
                
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(ddlInfoStatus.SelectedValue) < 1 || 
                Int32.Parse(ddlAssetBrand.SelectedValue) < 1 || 
                Int32.Parse(ddlAssetCategory.SelectedValue) < 1 || 
                Int32.Parse( ddlAssetVendor.SelectedValue) < 1  

                )
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information Status.');", true);
                return;
            }
              

            Li_AssetList assetList = new Li_AssetList();
            assetList.AssetCatId = Int32.Parse(ddlAssetCategory.SelectedValue);
            assetList.AssetId = 0;
            assetList.AssetName = txtAssetName.Text;
            assetList.AssetVenId = Int32.Parse(ddlAssetVendor.SelectedValue);
            assetList.BrandId = Int32.Parse(ddlAssetBrand.SelectedValue);
            assetList.PurchaseAmt = txtPurchaseAmt.Text == "" ? 0 : Decimal.Parse(txtPurchaseAmt.Text); 
            assetList.PurchaseDate = DateTime.Parse(dtpPurchaseDate.Text);
            assetList.WarrantyPeriod = DateTime.Parse(dtpWarrantyDate.Text);
            assetList.Life_Time = DateTime.Parse(dtpLifeTimeDate.Text);
            assetList.DepId= Int32.Parse(ddlDepartment.SelectedValue);
            assetList.EmployeID= Int32.Parse(ddlEmployee.SelectedValue);
            assetList.CreatedBy = Int32.Parse(Session["UserID"].ToString());
            assetList.CreatedDate = DateTime.Now;
            assetList.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
            assetList.ModelNo = txtModelNo.Text;
            assetList.ModifiedBy=Int32.Parse(Session["UserID"].ToString());
            assetList.ModifiedDate = DateTime.Now;
            //assetList.AssetCode = txtAssetCode.Text;
            txtAssetCode.Text = Li_AssetListManager.InsertLi_AssetList(assetList);

            string message = "Saved successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += Request.Url.AbsoluteUri;
            script += "'; }";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
            script, true);

            //ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved successfully');", true);
            //return;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(ddlInfoStatus.SelectedValue) < 1 ||
                Int32.Parse(ddlAssetBrand.SelectedValue) < 1 ||
                Int32.Parse(ddlAssetCategory.SelectedValue) < 1 ||
                Int32.Parse(ddlAssetVendor.SelectedValue) < 1

                )
            {
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information Status.');", true);
                return;
            }


            Li_AssetList assetList = new Li_AssetList();
            assetList.AssetCatId = Int32.Parse(ddlAssetCategory.SelectedValue);
            assetList.AssetId = int.Parse(ViewState["AssetId"].ToString());
            assetList.AssetCode = txtAssetCode.Text;
            assetList.AssetName = txtAssetName.Text;
            assetList.AssetVenId = Int32.Parse(ddlAssetVendor.SelectedValue);
            assetList.BrandId = Int32.Parse(ddlAssetBrand.SelectedValue);
            assetList.PurchaseAmt = txtPurchaseAmt.Text==""?0:Decimal.Parse(txtPurchaseAmt.Text);
            assetList.PurchaseDate = DateTime.Parse(dtpPurchaseDate.Text);
            assetList.WarrantyPeriod = DateTime.Parse(dtpWarrantyDate.Text);
            assetList.Life_Time = DateTime.Parse(dtpLifeTimeDate.Text);
            assetList.DepId = Int32.Parse(ddlDepartment.SelectedValue);
            assetList.EmployeID = Int32.Parse(ddlEmployee.SelectedValue);
            assetList.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
            assetList.ModelNo = txtModelNo.Text;
            assetList.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
            assetList.ModifiedDate = DateTime.Now;
            Li_AssetListManager.UpdateLi_AssetList(assetList);

            string message = "Update successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += Request.Url.AbsoluteUri;
            script += "'; }";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage",
            script, true);
        }

        protected void gvAssetList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onClick", Page.ClientScript.GetPostBackEventReference(sender as GridView, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void gvAssetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                clear();

                GridViewRow row = gvAssetList.SelectedRow;
                ViewState["AssetId"] = row.Cells[1].Text;

                DataTable dtAsset = Li_AssetListManager.GetAllLi_AssetList_ByAssetId(int.Parse(ViewState["AssetId"].ToString()));

                ddlInfoStatus.SelectedValue = dtAsset.Rows[0]["InfStId"].ToString();
                txtAssetCode.Text = dtAsset.Rows[0]["AssetCode"].ToString();
                txtAssetName.Text = dtAsset.Rows[0]["AssetName"].ToString();
                txtModelNo.Text = dtAsset.Rows[0]["ModelNo"].ToString();
                ddlAssetCategory.SelectedValue = dtAsset.Rows[0]["AssetCatId"].ToString();
                ddlAssetBrand.SelectedValue = dtAsset.Rows[0]["BrandId"].ToString();
                ddlAssetVendor.SelectedValue = dtAsset.Rows[0]["AssetVenId"].ToString();
                txtPurchaseAmt.Text = dtAsset.Rows[0]["PurchaseAmt"].ToString();

                ddlDepartment.SelectedValue = dtAsset.Rows[0]["DepId"].ToString();

                ddlEmployee.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListByDepID(int.Parse(dtAsset.Rows[0]["DepId"].ToString()));
                ddlEmployee.DataTextField = "EmpName";
                ddlEmployee.DataValueField = "EmpSl";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, new ListItem("Select Any", "0"));

                ddlEmployee.SelectedValue = dtAsset.Rows[0]["EmployeID"].ToString();

                dtpPurchaseDate.Text = DateTime.Parse(dtAsset.Rows[0]["PurchaseDate"].ToString()).ToString("yyyy/MM/dd");
                dtpWarrantyDate.Text = DateTime.Parse(dtAsset.Rows[0]["WarrantyPeriod"].ToString()).ToString("yyyy/MM/dd");
                dtpLifeTimeDate.Text = DateTime.Parse(dtAsset.Rows[0]["Life_Time"].ToString()).ToString("yyyy/MM/dd");
            }
            catch (Exception)
            {

            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEmployee.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListByDepID(int.Parse(ddlDepartment.SelectedValue));
            ddlEmployee.DataTextField = "EmpName";
            ddlEmployee.DataValueField = "EmpSl";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("Select Any", "0"));
        }

        private void clear()
        {
            ddlInfoStatus.SelectedValue = "0";
            ddlAssetCategory.SelectedValue = "0";
            ddlAssetBrand.SelectedValue = "0";
            txtModelNo.Text = "";
            txtAssetName.Text = "";
            ddlAssetVendor.SelectedValue = "0";
            dtpPurchaseDate.Text = "";
            dtpWarrantyDate.Text = "";
            dtpLifeTimeDate.Text = "";
            ddlDepartment.SelectedValue = "0";

            ddlEmployee.DataSource = Li_EmployeeInfoManager.GetLi_EmployeeListByDepID(int.Parse(ddlDepartment.SelectedValue));
            ddlEmployee.DataTextField = "EmpName";
            ddlEmployee.DataValueField = "EmpSl";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("Select Any", "0"));
        }

        ReportDocument rd = new ReportDocument();
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                rd.Load(Server.MapPath("~/Reports/HRD/rptAssetDetailsByAssetCode.rpt"));
                rd.DataSourceConnections.Clear();
                rd.SetDatabaseLogon(DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@AssetCode", txtAssetCode.Text);
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Asset Info");
                rd.Close();
                rd.Dispose();
            }
            catch (Exception)
            {


            }
        }
    }
}