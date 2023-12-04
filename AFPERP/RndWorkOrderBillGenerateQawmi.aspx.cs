using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Marketing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;


namespace BLL
{
    public partial class RndWorkOrderBillGenerateQawmi : System.Web.UI.Page
    {
        string FormID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");

                if (!IsPostBack)
                {
                    getUserAccess();

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
                        btnShow.Enabled = true;
                    }
                    else
                    {
                        btnShow.Enabled = false;
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
                        Response.Redirect("~/RandDHome.aspx");
                    }
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                gvWorkOderDetails.DataSource = Li_RnDQawmiWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkIDforBillGenerate(txtWorkOrder.Text.ToString(), int.Parse(Session["UserID"].ToString()));
                gvWorkOderDetails.DataBind();
                for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvWorkOderDetails.Rows[i].Cells[0].FindControl("chkWorkOrderSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtActualDelivery")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRate")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtTotal")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("dtpdeliveryDate")).Enabled = true;
                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnGenerateBill")).Enabled = true;
                        //((Button)gvWorkOderDetails.Rows[i].FindControl("btnPrint")).Enabled = true;

                    }
                    else
                    {
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtActualDelivery")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRate")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtTotal")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("dtpdeliveryDate")).Enabled = false;
                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnGenerateBill")).Enabled = false;
                        //((Button)gvWorkOderDetails.Rows[i].FindControl("btnPrint")).Enabled = false;

                    }

                }


            }
            catch (Exception)
            {

            }
        }

        protected void gvWorkOderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
            {
                Button name = (Button)gvWorkOderDetails.Rows[i].FindControl("btnGenerateBill");
                //Button paid = (Button)gvWorkOderDetails.Rows[i].FindControl("btnPrint");

                if (name.Text == "Generated")
                {
                    name.Enabled = false;
                }

                else
                {
                    name.Enabled = true;
                }
 

            }

        }
        protected void gvWorkOderDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {


            }

        }
        protected void chkWorkOrderSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvWorkOderDetails.Rows[i].Cells[0].FindControl("chkWorkOrderSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {
                        Button name = (Button)gvWorkOderDetails.Rows[i].FindControl("btnGenerateBill");
                        //Button paid = (Button)gvWorkOderDetails.Rows[i].FindControl("btnPrint");

                        if (name.Text == "Generated")
                        {
                            name.Enabled = false;
                            ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtActualDelivery")).Enabled = false;
                            ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRate")).Enabled = false;
                            ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtTotal")).Enabled = false;
                            ((TextBox)gvWorkOderDetails.Rows[i].FindControl("dtpdeliveryDate")).Enabled = false;
                        }

                        else
                        {
                            name.Enabled = true;
                            ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtActualDelivery")).Enabled = true;
                            ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRate")).Enabled = true;
                            ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtTotal")).Enabled = true;
                            ((TextBox)gvWorkOderDetails.Rows[i].FindControl("dtpdeliveryDate")).Enabled = true;
                        }

                    }
                    else
                    {
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtActualDelivery")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRate")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtTotal")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("dtpdeliveryDate")).Enabled = false;
                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnGenerateBill")).Enabled = false;
                        //((Button)gvWorkOderDetails.Rows[i].FindControl("btnPrint")).Enabled = false;


                    }

                }
            }
            catch (Exception)
            {


            }
        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
                {
                    CheckBox chkRow = (gvWorkOderDetails.Rows[i].Cells[0].FindControl("chkWorkOrderSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {
                        Li_RnDQawmiWorkOrderDetails WorkOderBill = new Li_RnDQawmiWorkOrderDetails();
                        WorkOderBill.WorkOrderDetID = int.Parse(gvWorkOderDetails.Rows[i].Cells[2].Text);
                        WorkOderBill.WorkDate = DateTime.Parse(((TextBox)gvWorkOderDetails.Rows[i].FindControl("dtpdeliveryDate")).Text);
                        //decimal forma=Convert.ToDecimal(gvWorkOderDetails.Rows[i].Cells[14].Text);
                        decimal totchar = Convert.ToDecimal(gvWorkOderDetails.Rows[i].Cells[16].Text);
                        decimal toActualy = decimal.Parse(((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtActualDelivery")).Text);

                        //if ((Convert.ToDecimal(gvWorkOderDetails.Rows[i].Cells[14].Text) - Convert.ToDecimal(gvWorkOderDetails.Rows[i].Cells[15].Text)) < decimal.Parse(((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtActualDelivery")).Text))

                        if (totchar < toActualy)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Delivery quantity is greater than Due quantity');", true);
                            return;
                        }
                        WorkOderBill.TotalCharacter = decimal.Parse(((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtActualDelivery")).Text);
                        WorkOderBill.TotalForma = 0;// decimal.Parse(((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRate")).Text);
                        WorkOderBill.CreatedBy = int.Parse(Session["UserID"].ToString());
                        WorkOderBill.CreatedDate = DateTime.Now;
                        Li_RnDQawmiWorkOrderDetailsManager.InsertLi_RnDWorkOrderBill(WorkOderBill);
                    }

                }
                ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Bill Generated Successfully!');", true);
                gvWorkOderDetails.DataSource = Li_RnDQawmiWorkOrderDetailsManager.GetLi_RnDWorkOrderDetailsByWorkIDforBillGenerate(txtWorkOrder.Text.ToString(), int.Parse(Session["UserID"].ToString()));
                gvWorkOderDetails.DataBind();
                for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
                {

                    CheckBox chkRow = (gvWorkOderDetails.Rows[i].Cells[0].FindControl("chkWorkOrderSelect") as CheckBox);

                    if (chkRow.Checked == true)
                    {
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtActualDelivery")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRate")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtTotal")).Enabled = true;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("dtpdeliveryDate")).Enabled = true;
                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnGenerateBill")).Enabled = true;
                        //((Button)gvWorkOderDetails.Rows[i].FindControl("btnPrint")).Enabled = true;

                    }
                    else
                    {
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtActualDelivery")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtRate")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("txtTotal")).Enabled = false;
                        ((TextBox)gvWorkOderDetails.Rows[i].FindControl("dtpdeliveryDate")).Enabled = false;
                        ((Button)gvWorkOderDetails.Rows[i].FindControl("btnGenerateBill")).Enabled = false;
                        //((Button)gvWorkOderDetails.Rows[i].FindControl("btnPrint")).Enabled = false;

                    }

                }
            }
            catch (Exception)
            {

            }
        }
        DataAccessObject DAO = new DataAccessObject();
        ReportDocument rd = new ReportDocument();

    }
}