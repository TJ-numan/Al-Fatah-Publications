using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public partial class Mkt_MonthlyTargetEntryByTerritory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/Login.aspx");
                if (!IsPostBack)
                {
                    LoadTerritory();
                    AddDefaultFirstRecord();
                }

            }
            catch (Exception)
            {


            }
        }
        //private void LoadsalesPerson()
        //{

        //    ddlTSO.DataSource = Li_SalesPersonManager.GetAllLi_SalesPersonsByUserID(int.Parse(Session["UserID"].ToString()));
        //    ddlTSO.DataTextField = "Name";
        //    ddlTSO.DataValueField = "TSOID";
        //    ddlTSO.DataBind();
        //}

        //protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    ddlCompany.SelectedValue = ddlCompany.SelectedValue;
        //    //string selectedCompanyValue = ddlCompany.SelectedValue;

        //}


        private void LoadTerritory()
        {
            try
            {

                ddlTerritory.DataSource = Li_TeritoryManager.GetAllLi_TeritoryByUserID(int.Parse(Session["UserID"].ToString()));
                ddlTerritory.DataTextField = "Name";
                ddlTerritory.DataValueField = "TeritoryCode";
                ddlTerritory.DataBind();
                ddlTerritory.Items.Insert(0, new ListItem("Select- Territory.....", "0"));
            }
            catch (Exception)
            {

            }
        }
        protected void ddlTeritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                ddlTSO.Items.Clear();

                ListItem li = new ListItem("Select TSO......", "0");
                ddlTSO.Items.Add(li);

                List<Li_SalesPerson> SalesMen = new List<Li_SalesPerson>();
                SalesMen = Li_SalesPersonManager.GetLi_SalesPersonsByTerritory_OnlyActiveTSO(ddlTerritory.SelectedValue);

                foreach (Li_SalesPerson tso in SalesMen)
                {
                    ListItem item = new ListItem(tso.Name, tso.TSOID);
                    ddlTSO.Items.Add(item);
                }


            }
            catch
            {

            }
        }
        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Year = ddlYear.SelectedValue.ToString();
                if (Year != "0")
                {
                    if (ddlMonth.SelectedIndex == 1)
                    {
                        txtFromDate.Text = Year + "-01-01";
                        txtToDate.Text = Year + "-01-31";
                    }
                    else if (ddlMonth.SelectedIndex == 2)
                    {

                        txtFromDate.Text = Year + "-02-01";
                        if (int.Parse(Year) % 4 == 0)
                        {
                            txtToDate.Text = Year + "-02-29";
                        }
                        else
                        {
                            txtToDate.Text = Year + "-02-28";
                        }
                    }
                    else if (ddlMonth.SelectedIndex == 3)
                    {
                        txtFromDate.Text = Year + "-03-01";
                        txtToDate.Text = Year + "-03-31";
                    }
                    else if (ddlMonth.SelectedIndex == 4)
                    {
                        txtFromDate.Text = Year + "-04-01";
                        txtToDate.Text = Year + "-04-30";
                    }
                    else if (ddlMonth.SelectedIndex == 5)
                    {
                        txtFromDate.Text = Year + "-05-01";
                        txtToDate.Text = Year + "-05-31";
                    }
                    else if (ddlMonth.SelectedIndex == 6)
                    {
                        txtFromDate.Text = Year + "-06-01";
                        txtToDate.Text = Year + "-06-30";
                    }
                    else if (ddlMonth.SelectedIndex == 7)
                    {
                        txtFromDate.Text = Year + "-07-01";
                        txtToDate.Text = Year + "-07-31";
                    }
                    else if (ddlMonth.SelectedIndex == 8)
                    {
                        txtFromDate.Text = Year + "-08-01";
                        txtToDate.Text = Year + "-08-31";
                    }
                    else if (ddlMonth.SelectedIndex == 9)
                    {
                        txtFromDate.Text = Year + "-09-01";
                        txtToDate.Text = Year + "-09-30";
                    }
                    else if (ddlMonth.SelectedIndex == 10)
                    {
                        txtFromDate.Text = Year + "-10-01";
                        txtToDate.Text = Year + "-10-31";
                    }
                    else if (ddlMonth.SelectedIndex == 11)
                    {
                        txtFromDate.Text = Year + "-11-01";
                        txtToDate.Text = Year + "-11-30";
                    }
                    else if (ddlMonth.SelectedIndex == 12)
                    {
                        txtFromDate.Text = Year + "-12-01";
                        txtToDate.Text = Year + "-12-31";
                    }
                    else
                    {
                        txtFromDate.Text = "";
                        txtToDate.Text = "";
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a year');", true);
                    ddlMonth.SelectedValue = "0";
                    txtFromDate.Text = "";
                    txtToDate.Text = "";
                    return;
                }
            }
            catch (Exception)
            {


            }
        }

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        AddNewRecordRowToGrid();
        //    }
        //    catch
        //    {

        //    }
        //}

    

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (ddlCompany.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a company');", true);
                    return;
                }

                if (ddlTerritory.SelectedValue == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please select a Territory.');", true);
                    return;
                }

                if (ddlTSO.SelectedValue == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please select a TSO.');", true);
                    return;
                }

                if (string.IsNullOrEmpty(txtSalesAmt.Text) || string.IsNullOrEmpty(txtCollecAmt.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please enter Sales and Collection amounts.');", true);
                    return;
                }

                decimal salesAmt;
                decimal collecAmt;

                if (!decimal.TryParse(txtSalesAmt.Text, out salesAmt) || !decimal.TryParse(txtCollecAmt.Text, out collecAmt))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please enter valid numeric values for Sales and Collection amounts.');", true);
                    return;
                }

                // Check for duplicate values
                if (IsDuplicateEntry(ddlTerritory.SelectedValue, int.Parse(ddlMonth.SelectedValue), int.Parse(ddlYear.SelectedValue), int.Parse(ddlCompany.SelectedValue), salesAmt, collecAmt))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Duplicate entry detected. Please select a different combination of Territory, Month, and Year.');", true);
                    return;
                }

                // If validation passes and no duplicate, add the record
                AddNewRecordRowToGrid();
            }
            catch (Exception ex)
            {
                 //Handle exceptions here
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Duplicate entry detected. Please select a different combination of Territory, Month, and Year.');", true);
                return;
            }

            ddlTerritory.Focus();
        }
        protected void ddlTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTSO.Focus();
        }

        protected void ddlTSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSalesAmt.Focus();
        }




        private bool IsDuplicateEntry(string terCode, int monthNo, int year, int companyId, decimal salesAmt, decimal collecAmt)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["tblTarget"];

            foreach (DataRow row in dtCurrentTable.Rows)
            {

                //var ddll = row;



                //if (row["TeritoryCode"].ToString() == terCode &&
                //  Convert.ToInt32(row["MonthNo"]) == monthNo &&
                //  Convert.ToInt32(row["Year"]) == year)
                //{
                //    return true;
                //}
                // Safely get values from the DataRow
                string teritoryCodeFromRow = row["TeritoryCode"] == DBNull.Value ? null : row["TeritoryCode"].ToString();
                int? monthNoFromRow = row["MonthNo"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MonthNo"]);
                int? yearFromRow = row["Year"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["Year"]);
                //int? companyIdFromRow = row["CompanyId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["CompanyId"]);

                // Compare the values
                if (teritoryCodeFromRow == terCode &&
                    monthNoFromRow.HasValue && monthNoFromRow.Value == monthNo &&
                    yearFromRow.HasValue && yearFromRow.Value == year)
                    //companyIdFromRow.HasValue && companyIdFromRow.Value == companyId)
                {
                    return true;
                }


                else
                {
                    // Retrieve data from the database for further comparison
                    DataTable dbData = GetDataFromDatabase(terCode, monthNo, year, companyId);

                    foreach (DataRow dbRow in dbData.Rows)
                    {
                            string tcodes = dbRow["TerCode"].ToString();
                            int tmonths = (int)dbRow["MonthNo"];
                            int tyears = (int)dbRow["Year"];
                            int tcompId = (int)dbRow["CompanyId"];


                         if (tcodes == terCode && tmonths == monthNo && tyears == year && tcompId == companyId)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false; // No duplicate entry
        }

        private DataTable GetDataFromDatabase(string terCode, int monthNo, int year, int companyId)
        {
            DataTable result = new DataTable();

            // Assuming you have a method to execute the stored procedure and fill a DataTable
            // Replace "YourConnectionString" with your actual connection string
            using (SqlConnection connection = new SqlConnection("Data Source=192.168.1.67; Initial Catalog=ALFDB_13; User ID=sa; Password=123456"))
            {
                using (SqlCommand command = new SqlCommand("SMPM_li_SalesTargetInfoByTerCodeMonthYear", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TerCode", terCode);
                    command.Parameters.AddWithValue("@MonthNo", monthNo);
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@CompanyId", companyId);

                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                }
            }

            return result;
        }




        private void AddDefaultFirstRecord()
        {
            bool fromLinkButton = false;
            int result = 0;
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tblTarget";
            dt.Columns.Add("Serial", typeof(string));
            dt.Columns.Add("TeritoryCode", typeof(string));
            dt.Columns.Add("TerritoryName", typeof(string));
            dt.Columns.Add("TSOID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("SalesTar", typeof(Decimal));
            dt.Columns.Add("CollecTar", typeof(Decimal));
            dt.Columns.Add("MonthNo", typeof(int));
            dt.Columns.Add("Year", typeof(int));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["tblTarget"] = dt;
            //bind Gridview  
            gvLi_TargetDetail.DataSource = dt;
            gvLi_TargetDetail.DataBind();
            ViewState["LinkClick"] = fromLinkButton;
            Session["ResultMemo"] = result;
        }
        private void AddNewRecordRowToGrid()
        {
            // check view state is not null  
            if (ViewState["tblTarget"] != null)
            {
                //get datatable from view state

                DataTable dtCurrentTable = (DataTable)ViewState["tblTarget"];
                DataRow drCurrentRow = null;


                if (dtCurrentTable.Rows.Count == 0)
                {
                    AddDefaultFirstRecord();
                }
                else
                {
                    if ((bool)ViewState["LinkClick"] == true)
                    {


                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            dtCurrentTable.Rows[i][0] = i + 1;
                            dtCurrentTable.AcceptChanges();
                        }

                        ViewState["LinkClick"] = false;
                    }
                    else
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //add each row into data table  
                            drCurrentRow = dtCurrentTable.NewRow();
                            drCurrentRow["Serial"] = dtCurrentTable.Rows.Count + 1;

                            if (ddlTerritory.SelectedValue.ToString() == dtCurrentTable.Rows[i - 1]["TeritoryCode"].ToString())
                            {
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Selected Territory already exists in your grid. ');", true);
                                return;
                            }

                        }
                        // New row for data table

                        drCurrentRow["TeritoryCode"] = ddlTerritory.SelectedValue.ToString();
                        drCurrentRow["TerritoryName"] = ddlTerritory.SelectedItem.Text;
                        drCurrentRow["TSOID"] = ddlTSO.SelectedValue.ToString();
                        drCurrentRow["Name"] = ddlTSO.SelectedItem.Text;
                        drCurrentRow["SalesTar"] = decimal.Parse(txtSalesAmt.Text);
                        drCurrentRow["CollecTar"] = decimal.Parse(txtCollecAmt.Text);

                        //Remove initial blank row  
                        if (dtCurrentTable.Rows[0][0].ToString() == "")
                        {
                            drCurrentRow["Serial"] = dtCurrentTable.Rows.Count;
                            dtCurrentTable.Rows[0].Delete();
                            dtCurrentTable.AcceptChanges();

                        }

                        //add created Rows into dataTable  
                        dtCurrentTable.Rows.Add(drCurrentRow);
                    }

                    //Save Data table into view state after creating each row  

                    ViewState["tblTarget"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    gvLi_TargetDetail.DataSource = dtCurrentTable;
                    gvLi_TargetDetail.DataBind();
                    ddlTerritory.SelectedIndex = 0;
                    ddlTSO.SelectedIndex = 0;
                    txtSalesAmt.Text = "";
                    txtCollecAmt.Text = "";
                }

            }
        }
        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                DataTable dtCurrentTable = (DataTable)ViewState["tblTarget"];
                dtCurrentTable.Rows[Convert.ToInt32(linkButton.CommandArgument) - 1].Delete();
                dtCurrentTable.AcceptChanges();
                ViewState["LinkClick"] = true;
                AddNewRecordRowToGrid();

            }
            catch (Exception)
            {


            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlCompany.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a company');", true);
                    return;
                }
                if (txtFromDate.Text == "" || txtToDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Please select a Month');", true);
                    return;
                }
                DataTable dtCurrentTable = (DataTable)ViewState["tblTarget"];

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {

                        Li_TargetDetails TargetDetails = new Li_TargetDetails();
                        TargetDetails.TerCode = dtCurrentTable.Rows[i]["TeritoryCode"].ToString();
                        TargetDetails.TSOEmpCode = dtCurrentTable.Rows[i]["TSOID"].ToString();
                        TargetDetails.StartDate = DateTime.Parse(txtFromDate.Text);
                        TargetDetails.EndDate = DateTime.Parse(txtToDate.Text);
                        TargetDetails.SalesTar = decimal.Parse(dtCurrentTable.Rows[i]["SalesTar"].ToString());
                        TargetDetails.CollecTar = decimal.Parse(dtCurrentTable.Rows[i]["CollecTar"].ToString());
                        TargetDetails.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                        TargetDetails.CreatedDate = DateTime.Now;
                        TargetDetails.Status_D = 'C';
                        TargetDetails.CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);
                        Li_TargetDetailsManager.InsertLi_TargetDetail(TargetDetails);

                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), UniqueID, "alert('Details information not available');", true);
                    return;
                }

                AddDefaultFirstRecord();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Saved Sucessfully');", true);
            }

            catch (Exception)
            {



            }
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMonth.SelectedValue = "0";
            txtFromDate.Text = "";
            txtToDate.Text = "";
        }
        public int CompanyId { get; set; }
    }
}