using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace BLL
{
    public partial class HrmMonthlyPF : System.Web.UI.Page
    { string ConnectionStringDB = @"Data Source= 192.168.1.111; Initial Catalog=AFP; Persist Security Info=True; User ID=sa;Password=12345";                 
        
        
        
        string FormID = "HF001";

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    getUserAccess();
                    GetAllYear();
                    GetAllUnit();
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
            }
        }
        private void getUserAccess()
        {
            DataTable dt = Li_AdminUserManager.GetUserAccess(int.Parse(Session["UserID"].ToString()), FormID).Tables[0];
            if (dt.Rows.Count > 0)
            {

                if (Session["UserID"].ToString() == dt.Rows[0]["UserID"].ToString() && FormID == dt.Rows[0]["FormId"].ToString())
                {
                    if (Boolean.Parse(dt.Rows[0]["View_"].ToString()) == false)
                    {
                        Response.Redirect("~/HRHome.aspx");
                    }
                    if (Boolean.Parse(dt.Rows[0]["Insert_"].ToString()) == true)
                    {
                        btnShow.Enabled = true;
                        btnConvertXML.Enabled = true;
                        DownloadXML.Enabled = true;
                    }
                    else
                    {
                        btnShow.Enabled = false;
                        btnConvertXML.Enabled = false;
                        DownloadXML.Enabled = false;
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
                }

            }
            else
            {
                //Response.Redirect("~/MarketingHome.aspx");
            }
        }

        private void GetAllUnit()
        {
            try
            {
                DataTable dtUnit = GetAllUnitofCompany();
                ddlUnitType.DataSource = dtUnit;
                ddlUnitType.DataValueField = "UnitID";
                ddlUnitType.DataTextField = "Unit";
                ddlUnitType.DataBind();
                ddlUnitType.Items.Insert(0, new ListItem("--Select--", ""));
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private void GetAllYear()
        {
            try
            {
                DataTable dtYear = GetLoadAllYear();
                ddlYear.DataSource = dtYear;
                ddlYear.DataValueField = "YearNo";
                ddlYear.DataTextField = "YearNo";
                ddlYear.DataBind();
                ddlYear.Items.Insert(0, new ListItem("--Select Year--", ""));
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
 

        public DataTable GetAllUnitofCompany()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.ConnectionStringDB))
            {
                SqlCommand command = new SqlCommand("GetAllUnitofCompany", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(dt);
                myadapter.Dispose();
                connection.Close();

                return dt;
            }
        }

        public DataTable GetLoadAllYear()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.ConnectionStringDB))
            {
                SqlCommand command = new SqlCommand("GetLoadAllYear", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(dt);
                myadapter.Dispose();
                connection.Close();

                return dt;
            }
        }
        public DataTable GetLoadMonthByYear(int YearNo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.ConnectionStringDB))
            {
                SqlCommand command = new SqlCommand("GetMonthByYear", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@YearNo", SqlDbType.Int).Value = YearNo;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(dt);
                myadapter.Dispose();
                connection.Close();

                return dt;
            }
        }
        public DataTable GetProvidentFundByUnit(int UnitId, int YearNo,int MonthNo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.ConnectionStringDB))
            {
                SqlCommand command = new SqlCommand("GetProvidentFundByUnit", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@UnitID", SqlDbType.Int).Value = UnitId;
                command.Parameters.Add("@YearNo", SqlDbType.Int).Value = YearNo;
                command.Parameters.Add("@MonthNo", SqlDbType.Int).Value = MonthNo;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(dt);
                myadapter.Dispose();
                connection.Close();

                return dt;
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtvw = GetProvidentFundByUnit(int.Parse(ddlUnitType.SelectedValue),int.Parse(ddlYear.SelectedValue),int.Parse(ddlMonth.SelectedValue));
                gvwMonthlyPF.DataSource = dtvw;
                gvwMonthlyPF.DataBind();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        protected void btnConvertXML_Click(object sender, EventArgs e)
        {
            try
            {

                gvwMonthlyPF.DataSource = null;
                DataTable dt = new DataTable();
                dt = GetProvidentFundByUnit(int.Parse(ddlUnitType.SelectedValue), int.Parse(ddlYear.SelectedValue), int.Parse(ddlMonth.SelectedValue));
                //gvwMonthlyPF.DataSource = dt;
                //gvwMonthlyPF.DataBind();

                //string ChallanID = dt.Rows[0]["EmployeeCode"].ToString();
                //string LibraryID = dt.Rows[0]["LibraryID"].ToString();
                //string amount = Math.Round((0 - Convert.ToDecimal(dt.Rows[0]["AmountReceivable"].ToString())), 0).ToString();

                //string TotalAmount = Math.Round(Convert.ToDecimal(dt.Rows[0]["TotalAmount"].ToString()), 0).ToString();

                //string TotalPacCost = Math.Round(Convert.ToDecimal(dt.Rows[0]["TotalPacCost"].ToString()), 0).ToString();

                string path = Server.MapPath("~/MonthlyPF.xml");

                using (XmlWriter writer = XmlWriter.Create(path))
                {
                    writer.WriteStartElement("ENVELOPE");

                    writer.WriteStartElement("HEADER");
                    writer.WriteElementString("TALLYREQUEST", "Import Data");
                    writer.WriteEndElement();

                    writer.WriteStartElement("BODY");
                    writer.WriteStartElement("IMPORTDATA");

                    writer.WriteStartElement("REQUESTDESC");
                    writer.WriteElementString("REPORTNAME", "Vouchers");
                    writer.WriteEndElement(); // REQUESTDESC End 	


                    writer.WriteStartElement("REQUESTDATA");


                    writer.WriteStartElement("TALLYMESSAGE");

                    writer.WriteAttributeString("xmlns", "UDF", null, "TallyUDF");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        writer.WriteStartElement("VOUCHER");
                        writer.WriteAttributeString("REMOTEID",ddlMonth.SelectedItem.Text+"-"+ddlYear.SelectedValue+"-"+ dt.Rows[i]["EmployeeCode"].ToString());
                        writer.WriteAttributeString("VCHTYPE", "Payroll");
                        writer.WriteAttributeString("ACTION", "Create");
                        writer.WriteAttributeString("OBJVIEW", "Accounting Voucher View");

                        writer.WriteElementString("DATE", Convert.ToDateTime(dtpDateofMonth.Text).ToString("yyyyMMdd"));
                        writer.WriteElementString("VOUCHERTYPENAME", "Payroll");
                        writer.WriteElementString("VOUCHERNUMBER", Convert.ToDateTime(dtpDateofMonth.Text).ToString("yyyyMMdd")+"-001");

                        writer.WriteElementString("PARTYLEDGERNAME", "Islami Bank Bangladesh Limited");
                        writer.WriteElementString("PERSISTEDVIEW", "Accounting Voucher View");


                        writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                        writer.WriteElementString("LEDGERNAME", "Islami Bank Bangladesh Limited");
                        writer.WriteElementString("ISDEEMEDPOSITIVE", "Yes");
                        writer.WriteElementString("AMOUNT", Math.Round((0 - Convert.ToDecimal(dt.Rows[i]["Amount"].ToString())), 0).ToString());
                        writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End 


                        writer.WriteStartElement("ALLLEDGERENTRIES.LIST");
                        writer.WriteElementString("LEDGERNAME", "G. Contribution of Employee");
                        writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                        writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["Amount"].ToString()), 0).ToString());
                        writer.WriteStartElement("CATEGORYALLOCATIONS.LIST");
                        writer.WriteElementString("CATEGORY", "Employees");
                        writer.WriteElementString("ISDEEMEDPOSITIVE", "No");
                        writer.WriteStartElement("COSTCENTREALLOCATIONS.LIST");
                        writer.WriteElementString("NAME", dt.Rows[i]["EmployeeCode"].ToString());
                        writer.WriteElementString("AMOUNT", Math.Round(Convert.ToDecimal(dt.Rows[i]["Amount"].ToString()), 0).ToString());
                        writer.WriteEndElement();//COSTCENTREALLOCATIONS.LIST
                        writer.WriteEndElement();// CATEGORYALLOCATIONS.LIST End 
                        writer.WriteEndElement();// ALLLEDGERENTRIES.LIST End	

                        writer.WriteEndElement();// VOUCHER End 	
                    }

                    writer.WriteEndElement();// TALLYMESSAGE End 		
                    writer.WriteEndElement();// REQUESTDATA End 	
                    writer.WriteEndElement();// IMPORTDATA End 		
                    writer.WriteEndElement();// Body End 
                    writer.WriteEndElement();// ENVELOPE End 
                    writer.Flush();

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

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        protected void DownloadXML_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("~/MonthlyPF.xml");
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/xml";
                response.AddHeader("Content-Disposition", "attachment; filename=" + path + ";");
                response.TransmitFile(path);
                response.Flush();
                response.End();
            }
            catch (Exception)
            {
            }
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtMonth = GetLoadMonthByYear(int.Parse(ddlYear.SelectedValue));
                ddlMonth.DataSource = dtMonth;
                ddlMonth.DataValueField = "MonthId";
                ddlMonth.DataTextField = "MonthNames";
                ddlMonth.DataBind();
                ddlMonth.Items.Insert(0, new ListItem("--Select Year--", ""));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

  
    }
}