using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class Pro_PlateSupply : System.Web.UI.Page
    {
        string FormID = "PF029";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                getUserAccess();
                if (!IsPostBack)
                {
                    txtOrderNo.Text = Request.QueryString["No"];

                    LoadBook();
                    LoadOrder();

                    SetPlateFor();
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
                        btnPlateSupSave.Enabled = true;
                    }
                    else
                    {
                        btnPlateSupSave.Enabled = false;
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

        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblPlateSupply";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("Press", typeof(string));
            dt.Columns.Add("PressID", typeof(string));
            dt.Columns.Add("Part", typeof(string));
            dt.Columns.Add("ColorNo", typeof(string));
            dt.Columns.Add("FormaQty", typeof(string));
            dt.Columns.Add("PrintQty", typeof(string));
            dt.Columns.Add("PlateType", typeof(string));
            dt.Columns.Add("TypeID", typeof(string));
            dt.Columns.Add("PlateSize", typeof(string));
            dt.Columns.Add("SizeID", typeof(string));
            dt.Columns.Add("PlateQty", typeof(string));
            dt.Columns.Add("PlateGivenQty", typeof(string));
            dt.Columns.Add("PlateRate", typeof(string));
            dt.Columns.Add("ProcessType", typeof(string));
            dt.Columns.Add("ProcessRate", typeof(string));
            dt.Columns.Add("Total", typeof(string));

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblPlateSupply"] = dt;
            //bind Gridview  
            gvwPlateSup.DataSource = dt;
            gvwPlateSup.DataBind();

            ViewState["LinkClick"] = fromLinkButton;

        }

        private void LoadBook()
        {
            ddlBookName.DataSource = li_BookInformationManager.Get_BookInformations_ComboSourceData();
            ddlBookName.DataTextField = "BookName";
            ddlBookName.DataValueField = "BookID";
            ddlBookName.DataBind();
        }

        private void LoadOrder()
        {
            try
            {


                DataSet ds = new DataSet();
                ds = Li_Print_Order_FormaManager.GetPrintOrderInforByOrderNo(txtOrderNo.Text);
                //  cmbOrderNo.Text = ds.Tables[0].Rows[0]["Print_OrderNo"].ToString();
                ddlBookName.SelectedValue = ds.Tables[0].Rows[0]["BookID"].ToString();
                txtGroup.Text = ds.Tables[0].Rows[0]["GName"].ToString();
                txtClassName.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                txtTypeName.Text = ds.Tables[0].Rows[0]["TypeName"].ToString();
                ddlEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                dtpOrderDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString()).ToString("yyyy-MM-dd");
                txtDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

                gvwPlateSup.Focus(); 

                    gvwPlateSup.DataSource=ds.Tables[0];
                    gvwPlateSup.DataBind();
                 

                    UpdateTotalPrice();

            }
            catch (Exception)
            {


            }
        }

        private void SetPlateFor()
        {
            if (txtOrderNo.Text.Trim() != "")
            {
                string[] arr = txtOrderNo.Text.Split(new char[] { '-' });//'-'

                string OrderPrifix = arr[0];

                if (OrderPrifix == "POF")
                {
                    ddlPlateFor.SelectedValue = "F";
                }
                else if (OrderPrifix == "POC")
                {
                    ddlPlateFor.SelectedValue = "C";
                }
                else if (OrderPrifix == "POA")
                {
                    ddlPlateFor.SelectedValue = "A";
                }
                else if (OrderPrifix == "POP")
                {
                    ddlPlateFor.SelectedValue = "P";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give a valid print order.');", true);
                    return;
                }
            }
        }

        protected void txtOrderNo_TextChanged(object sender, EventArgs e)
        {
            SetPlateFor();
            gvwPlateSup.DataSource = null;
            LoadOrder();
        }

        protected void gvwPlateSup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ddlPlateType = e.Row.FindControl("ddlPlateTypeo") as DropDownList;
                if (ddlPlateType != null)
                {
                    ddlPlateType.DataSource = Li_PlateTypeBasicManager.GetAllLi_PlateTypeBasics();
                    ddlPlateType.DataTextField = "Type";
                    ddlPlateType.DataValueField = "ID";
                    ddlPlateType.DataBind();
                }

                var ddlPlateSize = e.Row.FindControl("ddlPlatesize") as DropDownList;
                if (ddlPlateSize != null)
                {
                    ddlPlateSize.DataSource = Li_PlateSizeBasicManager.GetAllLi_PlateSizeBasics();
                    ddlPlateSize.DataTextField = "Size";
                    ddlPlateSize.DataValueField = "ID";
                    ddlPlateSize.DataBind();
                }
            }
        }

        protected void btnPlateSupSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (ddlBookName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a book for plate supply');", true);
                    return;
                }


                //if (Int32.Parse(txtTotalPlateQty.Text) == 0)
                //{
                    //DialogResult response = MessageBox.Show("Plate Qty is zero.Do you want to save ?", "Al Fatah Soft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (response == DialogResult.No)
                    //{
                    //    return;
                    //}
                    //else
                    //{ }
                //}
               
                Li_PlateSupply_Forma plateSupply = new Li_PlateSupply_Forma();
                plateSupply.BookCode = ddlBookName.SelectedValue.ToString() + "/" + ddlEdition.Text;
                plateSupply.CreatedBy = int.Parse(Session["UserID"].ToString());
                plateSupply.CreatedDate = DateTime.Now;
                plateSupply.Print_OID = txtOrderNo.Text;
                plateSupply.PlateQty = decimal.Parse(txtTotalPlateQty.Text);
                plateSupply.PlateBill = decimal.Parse(txtTotalPlateBill.Text);
                plateSupply.ProcessBill = decimal.Parse(txtTotalProcessBill.Text);
                plateSupply.TotalAmount = decimal.Parse(txtTotalBill.Text);
                plateSupply.IsExtra = chkExtra.Checked ? true : false;
                plateSupply.PlateFor = ddlPlateFor.SelectedValue.ToString();
                string ID = Li_PlateSupply_FormaManager.InsertLi_PlateSupply_Forma(plateSupply);

                if (chkExtra.Checked==true)
                {
                    for (int i = 0; i < gvwPlateSup.Rows.Count; i++)
                    {

                        GridViewRow row = gvwPlateSup.Rows[i];
                        bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                        
                        if (isChecked)
                        {
                            decimal PlateQtys = decimal.Parse(((TextBox)row.FindControl("txtPlateQty")).Text);

                            Li_PlateSupply_FormaDetail li_PlateSupply_detail = new Li_PlateSupply_FormaDetail();
                            li_PlateSupply_detail.Plate_SID = ID;
                            li_PlateSupply_detail.PresID = gvwPlateSup.Rows[i].Cells[1].Text;
                            li_PlateSupply_detail.PlateTypeID = ((DropDownList)row.FindControl("ddlPlateTypeo")).SelectedValue;
                            li_PlateSupply_detail.PlateSizeID = ((DropDownList)row.FindControl("ddlPlatesize")).SelectedValue;
                            li_PlateSupply_detail.PlateQty = PlateQtys;
                            li_PlateSupply_detail.PlateGivenType = Int32.Parse(((DropDownList)row.FindControl("ddlPlateGivenType")).SelectedValue);
                            li_PlateSupply_detail.PlateBillRate = decimal.Parse(((TextBox)row.FindControl("txtPlateRate")).Text);
                            li_PlateSupply_detail.ProcessGivenType = Int32.Parse(((DropDownList)row.FindControl("ddlProcessType")).SelectedValue);
                            li_PlateSupply_detail.ProcessBillRate = decimal.Parse(((TextBox)row.FindControl("txtProcessRate")).Text);

                            li_PlateSupply_detail.TotalAmount = decimal.Parse(((TextBox)row.FindControl("txtGridViewTotall")).Text);

                            Li_PlateSupply_FormaDetailManager.InsertLi_PlateSupply_FormaDetail(li_PlateSupply_detail);
                        }
                    

                    }

                }
                else
                {

                    for (int i = 0; i < gvwPlateSup.Rows.Count; i++)
                    {
                        GridViewRow row = gvwPlateSup.Rows[i];

                        decimal PlateQtys = decimal.Parse(((TextBox)row.FindControl("txtPlateQty")).Text);

                        Li_PlateSupply_FormaDetail li_PlateSupply_detail = new Li_PlateSupply_FormaDetail();
                        li_PlateSupply_detail.Plate_SID = ID;
                        li_PlateSupply_detail.PresID = gvwPlateSup.Rows[i].Cells[1].Text;
                        li_PlateSupply_detail.PlateTypeID = ((DropDownList)row.FindControl("ddlPlateTypeo")).SelectedValue;
                        li_PlateSupply_detail.PlateSizeID = ((DropDownList)row.FindControl("ddlPlatesize")).SelectedValue;
                        li_PlateSupply_detail.PlateQty = PlateQtys;
                        li_PlateSupply_detail.PlateGivenType = Int32.Parse(((DropDownList)row.FindControl("ddlPlateGivenType")).SelectedValue);
                        li_PlateSupply_detail.PlateBillRate = decimal.Parse(((TextBox)row.FindControl("txtPlateRate")).Text);
                        li_PlateSupply_detail.ProcessGivenType = Int32.Parse(((DropDownList)row.FindControl("ddlProcessType")).SelectedValue);
                        li_PlateSupply_detail.ProcessBillRate = decimal.Parse(((TextBox)row.FindControl("txtProcessRate")).Text);

                        li_PlateSupply_detail.TotalAmount = decimal.Parse(((TextBox)row.FindControl("txtGridViewTotall")).Text);

                        Li_PlateSupply_FormaDetailManager.InsertLi_PlateSupply_FormaDetail(li_PlateSupply_detail);


                    }
                }

                //string message = "Save successfully.";
                //string script = "window.onload = function(){ alert('";
                //script += message;
                //script += "');";
                //script += "window.location = '";
                //script += Request.Url.AbsoluteUri;
                //script += "'; }";
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "SuccessMessage", script, true);
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Save Successfully');", true);
                }
            catch (Exception)
            {


            }
        }

        private void UpdateTotalPrice()
        {
            decimal totalPlateQty = 0.0m;
            decimal totalPlateBill = 0.0m;
            decimal totalProcess = 0.0m;
            decimal totalBill = 0.0m;

            for (int i = 0; i < gvwPlateSup.Rows.Count; i++)
            {
                GridViewRow row = gvwPlateSup.Rows[i];

                decimal _PlateQty = ((TextBox)row.FindControl("txtPlateQty")).Text != "" ? decimal.Parse(((TextBox)row.FindControl("txtPlateQty")).Text) : 0.0m;


                decimal _PlateBill = ((TextBox)row.FindControl("txtPlateRate")).Text != "" ? decimal.Parse(((TextBox)row.FindControl("txtPlateRate")).Text) : 0.0m;
                totalPlateQty += _PlateQty;
                totalPlateBill += _PlateQty * _PlateBill;


                decimal _ProcessBill = ((TextBox)row.FindControl("txtProcessRate")).Text != "" ? decimal.Parse(((TextBox)row.FindControl("txtProcessRate")).Text) : 0.0m;
                totalProcess += _PlateQty * _ProcessBill;

                //  MessageBox.Show(gvPap_Supply.Rows[i].Cells["TotalBill"].Value.ToString());

                decimal _TotalBill = ((TextBox)row.FindControl("txtGridViewTotall")).Text != "" ? decimal.Parse(((TextBox)row.FindControl("txtGridViewTotall")).Text) : 0.0m;
                totalBill += _TotalBill;

            }

            txtTotalPlateQty.Text = String.Format("{0:0.##}", totalPlateQty);
            txtTotalPlateBill.Text = String.Format("{0:0.##}", totalPlateBill);
            txtTotalProcessBill.Text = String.Format("{0:0.##}", totalProcess);
            txtTotalBill.Text = String.Format("{0:0.##}", totalBill);

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string OrderNo = txtOrderNo.Text;
            string Platefor = ddlPlateFor.SelectedValue;

            Response.Redirect("~/Pro_Rpt_FormaPrintingOrder.aspx?No=" + OrderNo + "&binder=" + Platefor);
        }
    }
}