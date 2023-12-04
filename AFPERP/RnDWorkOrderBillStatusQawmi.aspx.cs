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
    public partial class RnDWorkOrderBillStatusQawmi : System.Web.UI.Page
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
                    gvWorkOderDetails.DataSource = Li_RnDQawmiWorkOrderDetailsManager.GetLi_RnDWorkOrderBillStatus(txtWorkOrder.Text.ToString(), int.Parse(Session["UserID"].ToString()));
                    gvWorkOderDetails.DataBind();
                    for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
                    {
                        Button paid = (Button)gvWorkOderDetails.Rows[i].FindControl("btnPrint");
                        if (paid.Text == "Pending")
                        {
                            paid.Enabled = false;

                        }
                        else if (paid.Text == "Rejected")
                        {
                            paid.Enabled = false;
                            paid.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            paid.Enabled = false;
                            paid.BackColor = System.Drawing.Color.Green;
                        }
                    }

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
                gvWorkOderDetails.DataSource = Li_RnDQawmiWorkOrderDetailsManager.GetLi_RnDWorkOrderBillStatus(txtWorkOrder.Text.ToString(), int.Parse(Session["UserID"].ToString()));
                gvWorkOderDetails.DataBind();
                for (int i = 0; i < gvWorkOderDetails.Rows.Count; i++)
                {
                    Button paid = (Button)gvWorkOderDetails.Rows[i].FindControl("btnPrint");
                    if (paid.Text == "Pending")
                    {
                        paid.Enabled = false;

                    }
                    else if (paid.Text == "Rejected")
                    {
                        paid.Enabled = false;
                        paid.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        paid.Enabled = false;
                        paid.BackColor = System.Drawing.Color.Green;
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
                Button paid = (Button)gvWorkOderDetails.Rows[i].FindControl("btnPrint");
                if (paid.Text == "Pending")
                {
                    paid.Enabled = false;
                }
                else if (paid.Text == "Rejected")
                {
                    paid.Enabled = false;
                    paid.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    paid.Enabled = false;
                    paid.BackColor = System.Drawing.Color.Green;
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
                    Button paid = (Button)gvWorkOderDetails.Rows[i].FindControl("btnPrint");
                    if (paid.Text == "Pending")
                    {
                        paid.Enabled = false;
                    }
                    else if (paid.Text == "Rejected")
                    {
                        paid.Enabled = false;
                        paid.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        paid.Enabled = false;
                        paid.BackColor = System.Drawing.Color.Green;
                    }
                }
            }
            catch (Exception)
            {


            }
        }
    }
}