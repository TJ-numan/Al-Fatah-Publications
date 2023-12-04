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
    public partial class Pro_BinderBill : System.Web.UI.Page
    {
        string FormID = "PF003";
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

                    txtBillDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
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
                ddlEdition.Items.Insert(0, new ListItem("--Select--", ""));

            }
            catch (Exception)
            {
            }
        }

        protected void ddlEdition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlBindingHosue.DataSource = Li_BookBinderInfoManager.GetAllLi_BookBinderInfosForBill(ddlBookName.SelectedValue.ToString() + "/" + ddlEdition.SelectedItem.Text);
                ddlBindingHosue.DataTextField = "BinderName";
                ddlBindingHosue.DataValueField = "BinderCode";
                ddlBindingHosue.DataBind();
                ddlBindingHosue.Items.Insert(0, new ListItem("--Select--", ""));
            }
            catch (Exception)
            {


            }
        }

        protected void ddlBindingHosue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = Li_GodownReceiveManager.GetDistinctReceive(ddlBindingHosue.SelectedValue.ToString(), ddlBookName.SelectedValue.ToString() + "/" + ddlEdition.SelectedItem.Text);


                ddlReceiveType.DataSource = ds.Tables[0];
                ddlReceiveType.DataTextField = "Book";
                ddlReceiveType.DataValueField = "IsRebind";
                ddlReceiveType.DataBind();
                ddlReceiveType.Items.Insert(0, new ListItem("--Select--", ""));

            }
            catch (Exception)
            {


            }
        }

        protected void ddlReceiveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                test();
            }
            catch (Exception)
            {

            }
        }

        private void test()
        {
            ClearData();


            if (Int32.Parse(ddlReceiveType.SelectedValue.ToString()) == 0)
            {
                lblMiniBill.Visible=false;
                txtMinimumBillRate.Visible=false;
            }
            else
            {
                lblMiniBill.Visible = true;
                txtMinimumBillRate.Visible=true;

            }



            DataSet ds = new DataSet();
            ds = Li_GodownReceiveManager.GetAll_GodownReceiveForBill(ddlBindingHosue.SelectedValue.ToString(), ddlBookName.SelectedValue.ToString() + "/" + ddlEdition.SelectedItem.Text, ddlReceiveType.SelectedValue.ToString());

            //string strQuery = "IsRebind = 0";
            //DataRow[] drFilterRows = ds.Tables[0].Select(strQuery);


            /*
            foreach (DataRow dr in drFilterRows)
            {
                 dss.Tables[0].ImportRow(dr);
            }
            */


            gvwBinderBill.DataSource = ds.Tables[0];
            gvwBinderBill.DataBind();


            //for (int i = 0; i < gvwBinderBill.Rows.Count; i++)
            //{
            //    gvReceive.Rows[i].Cells["Select"].Value = false;

            //}
            UpdateTotalQty();
            txtAcForma.Text = ds.Tables[0].Rows[0]["FormaQty"].ToString();

        }

        private void ClearData()
        {
            txtBillRate.Text = "0";
            txtMinimumBillRate.Text = "0";
            txtPayForma.Text = "0";
            txtBindingBill.Text = "0";
        }

        private void UpdateTotalQty()
        {


            int totalQty = 0;
            for (int i = 0; i < gvwBinderBill.Rows.Count; i++)
            {
                CheckBox chkRow = (gvwBinderBill.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);

                if (chkRow.Checked == true)
                {

                    int qty = Int32.Parse(gvwBinderBill.Rows[i].Cells[1].Text);
                    totalQty += qty;
                }
            }
            txtTotalQty.Text = String.Format("{0:0.##}", totalQty);


        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateTotalQty();
            }
            catch (Exception)
            {


            }
        }

        protected void txtPayForma_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal totalTotalBill = 0.0m;
                decimal totalBindingBill = 0.0m;

                decimal Qty = txtTotalQty.Text != "" ? decimal.Parse(txtTotalQty.Text) : 0.0m;
                decimal payFormaQty = txtPayForma.Text != "" ? decimal.Parse(txtPayForma.Text) : 0.0m;
                decimal miniBillrate = txtMinimumBillRate.Text != "" ? decimal.Parse(txtMinimumBillRate.Text) : 0.0m;
                decimal labourBill = txtLabourBill.Text != "" ? decimal.Parse(txtLabourBill.Text) : 0.0m;
                decimal OtherCost = txtOtherCost.Text != "" ? decimal.Parse(txtOtherCost.Text) : 0.0m;

                if (ddlReceiveType.SelectedItem.Text == "New Book")
                {
                    if (ddlRateBy.SelectedIndex == 0)
                    {
                        lblMiniBill.Visible=false;
                        txtMinimumBillRate.Visible=false;
                        totalBindingBill = (Qty * payFormaQty * decimal.Parse(txtBillRate.Text)) / 1000;
                        totalTotalBill = totalBindingBill + labourBill + OtherCost;
                    }
                    else
                    {
                        lblMiniBill.Visible=false;
                        txtMinimumBillRate.Visible=false;
                        totalBindingBill = (Qty * decimal.Parse(txtBillRate.Text));
                        totalTotalBill = totalBindingBill + labourBill + OtherCost;

                    }
                }

                else if (ddlReceiveType.SelectedItem.Text == "Rebinding")
                {
                    lblMiniBill.Visible=true;
                    txtMinimumBillRate.Visible=true;

                    if (payFormaQty >= 6.0m)
                    {
                        txtBillRate.Text = (miniBillrate + (0.10m * payFormaQty)).ToString();
                        totalBindingBill = Qty * (miniBillrate + (0.10m * payFormaQty));
                        totalTotalBill = totalBindingBill + labourBill + OtherCost;
                    }
                    else
                    {
                        txtBillRate.Text = miniBillrate.ToString();
                        totalBindingBill = (Qty * miniBillrate);
                        totalTotalBill = totalBindingBill + labourBill + OtherCost;

                    }
                }
                else
                {
                }

                txtBindingBill.Text = string.Format("{0:0.##}", totalBindingBill);
                txtTotalBill.Text = string.Format("{0:0.##}", totalTotalBill);

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
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please give the rate ');", true);
                    return;
                }

                //if (txtBillDate.Text == String.Format("{0:yyyy-MM-dd}", DateTime.Now))
                //{

                //    DialogResult response = MessageBox.Show("Do you want to Bill in ToDay ?", "Al Fatah Softare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (response == DialogResult.No)
                //    {
                //        return;
                //    }
                //    else
                //    { }
                //}

                Li_BinderBill tempLi_BinderBill = new Li_BinderBill();

                tempLi_BinderBill.BillDate = DateTime.Parse(txtBillDate.Text);
                tempLi_BinderBill.BillNo = txtBillNo.Text;
                tempLi_BinderBill.BinderID = ddlBindingHosue.SelectedValue.ToString();
                tempLi_BinderBill.BookCode = ddlBookName.SelectedValue.ToString() + "/" + ddlEdition.SelectedItem.Text;
                tempLi_BinderBill.IsRebind = false; //bool .Parse ( cmbReceiveType.SelectedValue .ToString ()) ;
                tempLi_BinderBill.TotalQty = Decimal.Parse(txtTotalQty.Text);
                tempLi_BinderBill.Ac_Forma = Decimal.Parse(txtAcForma.Text);
                tempLi_BinderBill.Pay_Forma = Decimal.Parse(txtPayForma.Text);
                tempLi_BinderBill.MiniRate = Decimal.Parse(txtMinimumBillRate.Text);
                tempLi_BinderBill.BillRate = Decimal.Parse(txtBillRate.Text);
                tempLi_BinderBill.TotalBill = Decimal.Parse(txtBindingBill.Text);
                tempLi_BinderBill.CreatedDate = DateTime.Now;
                tempLi_BinderBill.CreateBy = int.Parse(Session["UserID"].ToString());
                tempLi_BinderBill.Status_D = 'C';
                tempLi_BinderBill.DelDate = DateTime.Now;
                tempLi_BinderBill.CauseOfDel = "";
                tempLi_BinderBill.DeleBy = 0;
                tempLi_BinderBill.RateBy = ddlRateBy.SelectedIndex + 1;
                tempLi_BinderBill.LabourBill = txtLabourBill.Text != "" ? decimal.Parse(txtLabourBill.Text) : 0.0m;
                tempLi_BinderBill.OtherCost = txtOtherCost.Text != "" ? decimal.Parse(txtOtherCost.Text) : 0.0m;
                string result = Li_BinderBillManager.InsertLi_BinderBill(tempLi_BinderBill);



                for (int i = 0; i < gvwBinderBill.Rows.Count; i++)
                {
                    CheckBox chkRow = (gvwBinderBill.Rows[i].Cells[0].FindControl("chkSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {

                        Li_BinderBillDetail tempLi_BinderBillDetail = new Li_BinderBillDetail();


                        tempLi_BinderBillDetail.BillNo = result;
                        tempLi_BinderBillDetail.Qty = Decimal.Parse(gvwBinderBill.Rows[i].Cells[1].Text);
                        tempLi_BinderBillDetail.ReceiveID = gvwBinderBill.Rows[i].Cells[2].Text;

                        Li_BinderBillDetailManager.InsertLi_BinderBillDetail(tempLi_BinderBillDetail);



                    }
                }


                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Saved Successfully');", true);
                //cmbReceiveType.SelectedIndex = 2;
                //cmbReceiveType.SelectedIndexChanged +=new EventHandler(cmbReceiveType_SelectedIndexChanged);
                test();
                txtBillNo.Text = "";
                gvwBinderBill.DataSource = null;
                gvwBinderBill.DataBind();

                txtBillDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
            }
            catch (Exception)
            {


            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {

            string BillNo = txtBillNo.Text;
            string binderNo = ddlBindingHosue.SelectedValue;
            string billdate = txtBillDate.Text;

            Response.Redirect("~/Pro_Rpt_PrintBinderBill.aspx?No=" + BillNo + "&binder=" + binderNo + "&date=" + billdate);
        }

    }
}