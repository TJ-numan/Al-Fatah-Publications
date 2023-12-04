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
    public partial class HrmEmployeeSalary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    LoadComboData.LoadHRInfoStatus(ddlInfoStatus);
                    ddlInfoStatus.DataBind();

                    LoadComboData.LoadEmployeeInfo(ddlEmployee);
                    ddlEmployee.DataBind();

                    LoadComboData.LoadPayGrade(ddlPayGrade);
                    ddlPayGrade.DataBind();

                    gvEmpSalary.DataSource = Li_EmpSalaryManager.LoadGvEmployeeSalary();
                    gvEmpSalary.DataBind();


                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (Int32.Parse(ddlInfoStatus.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Information Status.');", true);
                    return;
                }

                if (Int32.Parse(ddlEmployee.SelectedValue) < 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Employee');", true);
                    return;
                }



                if (txtPayableAmt.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Invalid Payable Amount.');", true);
                    return;
                }



                Li_EmpSalary empSalary = new Li_EmpSalary();
                empSalary.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                empSalary.CreatedDate = DateTime.Now;
                empSalary.InfStId = Int32.Parse(ddlInfoStatus.SelectedValue);
                empSalary.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                empSalary.ModifiedDate = DateTime.Now;
                empSalary.EPF = decimal.Parse(txtEmpProvidentFund.Text);
                empSalary.SalId = 0;
                empSalary.EmpSl = int.Parse(ddlEmployee.SelectedValue);
                empSalary.PayGrId = int.Parse(ddlPayGrade.SelectedValue);
                empSalary.PScId = int.Parse(ddlPayScale.SelectedValue);
                empSalary.CompanyCost = 0.0m;
                empSalary.DeductionAmt = 0.0m;
                empSalary.PayableAmt = decimal.Parse(txtPayableAmt.Text);
                empSalary.Comments = txtComments.Text;
                int SalaryID = Li_EmpSalaryManager.InsertLi_EmpSalary(empSalary);

                DataTable dtSalDetail = (DataTable)ViewState["tblSalDetail"];
                if (dtSalDetail.Rows.Count > 0)
                {
                    for (int i = 0; i < dtSalDetail.Rows.Count; i++)
                    {
                        Li_EmpSalaryDetail EmpSalDetail = new Li_EmpSalaryDetail();
                        EmpSalDetail.SalDeId = 0;
                        EmpSalDetail.SalId = SalaryID;
                        EmpSalDetail.PaHId = Int32.Parse(dtSalDetail.Rows[i]["PayHId"].ToString());
                        EmpSalDetail.Amount = decimal.Parse(dtSalDetail.Rows[i]["Amount"].ToString());
                        EmpSalDetail.CreatedBy = Int32.Parse(Session["UserID"].ToString());
                        EmpSalDetail.CreatedDate = DateTime.Now;
                        EmpSalDetail.ModifiedBy = Int32.Parse(Session["UserID"].ToString());
                        EmpSalDetail.ModifiedDate = DateTime.Now;
                        Li_EmpSalaryDetailManager.InsertLi_EmpSalaryDetail(EmpSalDetail);
                    }
                }


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

        protected void ddlPayScale_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            try
            {
                if (ddlPayScale.SelectedValue == "0")
                {
                    txtEmpProvidentFund.Text = "";
                    txtPayableAmt.Text = "";
                }
                else
                {
                    decimal pfAmount = decimal.Parse(ddlPayScale.SelectedItem.Text) * 0.55m * 0.06m;

                    txtEmpProvidentFund.Text = String.Format("{0:0.##}", pfAmount);
                    txtPayableAmt.Text = String.Format("{0:0.##}", decimal.Parse(ddlPayScale.SelectedItem.Text) - pfAmount);


                    gvEmpSalaryDetail.DataSource = null;

                    DataTable dt = new DataTable();

                    DataRow dr;
                    dt.TableName = "tblEmpSalDetail";
                    dt.Columns.Add("PayHId", typeof(Int32));
                    dt.Columns.Add("PayHead", typeof(string));
                    dt.Columns.Add("Amount", typeof(decimal));
                    dt.Columns.Add("ExcludeGross", typeof(bool));

                    List<Li_PayHead> PayHeads = new List<Li_PayHead>();
                    PayHeads = Li_PayHeadManager.GetAllLi_PayHeads();

                    foreach (Li_PayHead PayHead in PayHeads)
                    {
                        dr = dt.NewRow();
                        dr["PayHId"] = PayHead.PaHId;
                        dr["PayHead"] = PayHead.PaHName;
                        if (PayHead.PaHId == 1)
                        {

                            dr["Amount"] = String.Format("{0:0.##}", decimal.Parse(ddlPayScale.SelectedItem.Text) * 0.55m);// 55% for basic salary
                        }
                        else if (PayHead.PaHId == 2)
                        {
                            dr["Amount"] = String.Format("{0:0.##}", decimal.Parse(ddlPayScale.SelectedItem.Text) * 0.25m);// 25% for House Rent
                        }

                        else if (PayHead.PaHId == 3)
                        {
                            dr["Amount"] = String.Format("{0:0.##}", decimal.Parse(ddlPayScale.SelectedItem.Text) * 0.10m);// 10% for Medical Allowance
                        }

                        else if (PayHead.PaHId == 4)
                        {
                            dr["Amount"] = String.Format("{0:0.##}", decimal.Parse(ddlPayScale.SelectedItem.Text) * 0.10m);// 10% for Conveyance

                        }
                        else if (PayHead.PaHId == 5)
                        {
                            dr["Amount"] = String.Format("{0:0.##}", 500m);// fixed 500 for Office Entertainment
                        }

                        dr["ExcludeGross"] = PayHead.IsExcluedGross;
                        dt.Rows.Add(dr);


                    }


                    //saving databale into viewstate   
                    ViewState["tblSalDetail"] = dt;

                    gvEmpSalaryDetail.DataSource = dt;
                    gvEmpSalaryDetail.DataBind();
                }
            }
            catch (Exception)
            {
                
                
            }

        }

        protected void ddlPayGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtGetPayScale = Li_PayScaleDetailManager.GetPayScale_ByPayGradeID(int.Parse(ddlPayGrade.SelectedValue)).Tables[0];
                ddlPayScale.DataSource = dtGetPayScale;
                ddlPayScale.DataTextField = "PSAmt";
                ddlPayScale.DataValueField = "PScId";
                ddlPayScale.DataBind();
                ddlPayScale.Items.Insert(0, new ListItem("--select--", "0"));
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}