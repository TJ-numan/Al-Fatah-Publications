using BLL.Classes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public partial class HrmAssetListByCategory : System.Web.UI.Page
    {
        DataAccessObject DAO = new DataAccessObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadComboData.LaodAssetCategory(ddlAssetCategory);
                    LoadComboData.LoadDepartments(ddlDepartment);
                }
            }
            catch (Exception)
            {


            }
        }

        ReportDocument rd = new ReportDocument();
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                rd.Load(Server.MapPath("~/Reports/HRD/rptAssetInformationByAssetTypeAndDepartment.rpt"));
                rd.DataSourceConnections.Clear();
                rd.SetDatabaseLogon(DAO.ServerName, DAO.DatabaseName);
                rd.DataSourceConnections[0].SetConnection(DAO.ServerName, DAO.DatabaseName, false);
                rd.DataSourceConnections[0].SetLogon(DAO.UserID, DAO.Password);
                rd.SetParameterValue("@AssetCatId", ddlAssetCategory.SelectedValue);
                rd.SetParameterValue("@DepId", ddlDepartment.SelectedValue);
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