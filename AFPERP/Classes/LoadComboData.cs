using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public class LoadComboData
    {
        public LoadComboData()
        {
        }





        public static void LoadDepositFor(DropDownList ddlDepositFor)
        {
            ListItem li = new ListItem("Select Any..", "0");
            ddlDepositFor.Items.Add(li);

            List<Li_DepositFor> DepositFor = new List<Li_DepositFor>();
            DepositFor = Li_DepositForManager.GetAllLi_DepositFors();
            foreach (Li_DepositFor dep in DepositFor)
            {
                ListItem item = new ListItem(dep.DepForName, dep.DepForId.ToString());
                ddlDepositFor.Items.Add(item);
            }
        }


        public static void LoadBank(DropDownList ddlBankName)
        {
            ddlBankName.DataSource = Li_BankNameManager.GetAllLi_BankNames();
            ddlBankName.DataTextField = "BankName";
            ddlBankName.DataValueField = "BankCode";
            ddlBankName.DataBind();
            ddlBankName.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        public static void LoadTransactionTypes(DropDownList ddlDepositeType)
        {
            ddlDepositeType.DataSource = Li_TransectionTypeManager.GetAllLi_TransectionTypes();
            ddlDepositeType.DataTextField = "TranbType";
            ddlDepositeType.DataValueField = "TannID";
            ddlDepositeType.DataBind();
            ddlDepositeType.Items.Insert(0, new ListItem("-Select-", "0"));
        }




        public static void LoadRegion(DropDownList ddlRegion, int UserID)
        {
            List<li_Region> li_Regions = new List<li_Region>();

            li_Regions = li_RegionManager.GetComboSourceData_Regions(UserID);


            ddlRegion.DataSource = li_Regions;
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataValueField = "RegionID";

        }

        public void LoadDivision(DropDownList ddlDivision)
        {
            List<Li_Division> division = new List<Li_Division>();
            division = Li_DivisionManager.GetAllLi_Divisions();


            ddlDivision.DataSource = division;
            ddlDivision.DataTextField = "DivName";
            ddlDivision.DataValueField = "DivID";
        }

        public void LoadZone(DropDownList ddlZone)
        {
            List<Li_Zone> Zone = new List<Li_Zone>();
            Zone = Li_ZoneManager.GetAllLi_Zones();


            ddlZone.DataSource = Zone;
            ddlZone.DataTextField = "ZonName";
            ddlZone.DataValueField = "ZonID";
        }

        public void LoadThanaByDistrictID(DropDownList ddlThanaID, int DistrictID)
        {
            List<li_Thana> li_thana = new List<li_Thana>();
            li_thana = li_ThanaManager.Get_ThanaByDistrictID(DistrictID);
            ddlThanaID.DataSource = li_thana;
            ddlThanaID.DataTextField = "ThanaName";
            ddlThanaID.DataValueField = "ThanaID";
        }




        public void LoadRegionByID(DropDownList ddlRegionOwner, int regionID)
        {
            List<li_Region> li_Regions = new List<li_Region>();

            li_Regions = li_RegionManager.GetAll_Regions();


            ddlRegionOwner.DataSource = li_Regions;
            ddlRegionOwner.DataTextField = "RegionName";
            ddlRegionOwner.DataValueField = "RegionID";
        }





        public void LoadTeritory(DropDownList ddlTeritoryID)
        {


            List<Li_Teritory> li_teritory = new List<Li_Teritory>();

            li_teritory = Li_TeritoryManager.GetAllLi_Teritories(string.Empty);


            ddlTeritoryID.DataSource = li_teritory;
            ddlTeritoryID.DataTextField = "TeritoryName";
            ddlTeritoryID.DataValueField = "TeritoryCode";
            ddlTeritoryID.SelectedIndex = -1;

        }
        public static void LoadTeritoryR2(DropDownList ddlTeritoryID)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlTeritoryID.Items.Add(li);


            List<Li_Teritory> li_teritory = new List<Li_Teritory>();

            li_teritory = Li_TeritoryManager.GetAllLi_Teritories(string.Empty);

            foreach (Li_Teritory territoty in li_teritory)
            {
                ListItem item = new ListItem(territoty.TeritoryName, territoty.TeritoryCode);
                ddlTeritoryID.Items.Add(item);
            }


        }

        public static void LoadLibrary(DropDownList ddlLibraryID, int UserID)
        {
            try
            {
                List<li_LibraryInformation> li_LibraryInformation = new List<li_LibraryInformation>();
                li_LibraryInformation = li_LibraryInformationManager.GetAll_ComboBox_LibraryInformations(UserID);
                ddlLibraryID.DataSource = li_LibraryInformation;
                ddlLibraryID.DataTextField = "LibraryName";
                ddlLibraryID.DataValueField = "LibraryID";
            }
            catch (Exception)
            {
            }
        }


        public static void LoadLibrary(DropDownList ddlLibraryName)
        {
            try
            {
                List<Li_LibraryInformation> li_LibraryInformation = new List<Li_LibraryInformation>();

                li_LibraryInformation = Li_LibraryInformationManager.GetAll_ComboBox_LibraryInformations();
                ddlLibraryName.DataSource = li_LibraryInformation;
                ddlLibraryName.DataTextField = "LibraryName";
                ddlLibraryName.DataValueField = "LibraryID";
                ddlLibraryName.DataBind();



            }
            catch (Exception)
            {


            }
        }

        public void LoadLibraryByTerritory(DropDownList ddlLibraryID, string TerID)
        {
            try
            {
                List<li_LibraryInformation> li_LibraryInformation = new List<li_LibraryInformation>();

                li_LibraryInformation = li_LibraryInformationManager.GetAll_ComboBox_LibraryInformationsByTerritory(TerID);


                ddlLibraryID.DataSource = li_LibraryInformation;
                ddlLibraryID.DataTextField = "LibraryName";
                ddlLibraryID.DataValueField = "LibraryID";
                ddlLibraryID.DataBind();

            }
            catch (Exception rt)
            {
            }
        }




        public void LoadDistricts(DropDownList ddlDistrictName)
        {
            ddlDistrictName.DataSource = li_DistrictManager.GetAll_Districts();
            ddlDistrictName.DataTextField = "DistrictName";
            ddlDistrictName.DataValueField = "DistrictID";
            ddlDistrictName.SelectedIndex = -1;
        }


        public void LoadArea(DropDownList ddlArea)
        {
            List<li_Area> li_Regions = new List<li_Area>();

            li_Regions = li_AreaManager.GetAll_Areas();
            ddlArea.DataSource = li_Regions;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "AreaID";
            ddlArea.SelectedIndex = -1;
        }

        public static void LoadDivisionByRegionID(DropDownList ddlArea, int regionID)
        {
            List<Li_Division> li_Div = new List<Li_Division>();

            li_Div = Li_DivisionManager.GetLi_DivisionByID(regionID);
            ddlArea.DataSource = li_Div;
            ddlArea.DataTextField = "DivName";
            ddlArea.DataValueField = "DivID";
        }

        public static void LoadZoneByDivision(DropDownList ddlZone, int DivID)
        {
            List<Li_Zone> zones = new List<Li_Zone>();
            zones = Li_ZoneManager.GetLi_ZoneByID(DivID);
            ddlZone.DataSource = zones;
            ddlZone.DataTextField = "ZonName";
            ddlZone.DataValueField = "ZonID";

        }


        public static void LoadTeritoryByZone(DropDownList ddlTeritory, int ZonID)
        {
            List<Li_Teritory> li_Teritorys = new List<Li_Teritory>();

            li_Teritorys = Li_TeritoryManager.Get_TeritoryByZonID(ZonID);
            ddlTeritory.DataSource = li_Teritorys;
            ddlTeritory.DataTextField = "TeritoryName";
            ddlTeritory.DataValueField = "TeritoryCode";
        }

        public void LoadDistrictByTeritoryID(DropDownList ddlDistrictID, string TeritoryID)
        {
            List<li_District> li_district = new List<li_District>();
            li_district = li_DistrictManager.Get_AllDistrictByTeritoryID(TeritoryID);
            ddlDistrictID.DataSource = li_district;
            ddlDistrictID.DataTextField = "DistrictName";
            ddlDistrictID.DataValueField = "DistrictID";
        }

        public void LoadThanaByDistrictID(DropDownList ddlThanaID, string Territory, int DistrictID)
        {
            List<li_Thana> li_thana = new List<li_Thana>();
            li_thana = li_ThanaManager.Get_ThanaByDistrictID(Territory, DistrictID);
            ddlThanaID.DataSource = li_thana;
            ddlThanaID.DataTextField = "ThanaName";
            ddlThanaID.DataValueField = "ThanaID";
        }
        public void LoadBookIDbyCategory(DropDownList ddlBookID, string category)
        {

            List<li_BookInformation> li_bookinfo = new List<li_BookInformation>();
            li_bookinfo = li_BookInformationManager.Get_BookInformationByCategory_ComboSourceData(category);
            ddlBookID.DataSource = li_bookinfo;
            ddlBookID.DataTextField = "BookName";
            ddlBookID.DataValueField = "BookID";
        }

        public void LoadBookAcCodeByBookID(DropDownList ddlBookID, string BookID)
        {

            List<li_BookVersionInfo> li_bookinfo = new List<li_BookVersionInfo>();
            li_bookinfo = li_BookVersionInfoManager.GetAll_BookVersionInfosByBookID(BookID);
            ddlBookID.DataSource = li_bookinfo;
            ddlBookID.DataTextField = "Edition";
            ddlBookID.DataValueField = "BookAcCode";
        }


        public void LoadThana(DropDownList ddlRegionOwner)
        {
            List<li_Thana> li_Thanas = new List<li_Thana>();

            li_Thanas = li_ThanaManager.GetAll_Thanas();


            ddlRegionOwner.DataSource = li_Thanas;
            ddlRegionOwner.DataTextField = "ThanaName";
            ddlRegionOwner.DataValueField = "ThanaID";
        }

        public void LoadAuthor(DropDownList ddlAuthor)
        {
            List<Li_Author> liauthor = new List<Li_Author>();
            liauthor = Li_AuthorManager.GetAllLi_Authors();
            ddlAuthor.DataSource = liauthor;
            ddlAuthor.DataTextField = "AuthorName";
            ddlAuthor.DataValueField = "AuthorID";
        }
        public void LoadClassName(DropDownList ddlClassID)
        {
            List<Li_Classes> liClass = new List<Li_Classes>();
            liClass = Li_ClassesManager.GetComboSourceData_Classess();
            ddlClassID.DataSource = liClass;
            ddlClassID.DataTextField = "ClassName";
            ddlClassID.DataValueField = "ClassID";
        }

        public static void LoadBookSession(DropDownList ddlSession)
        {
            List<Li_Book_Session> liSessions = new List<Li_Book_Session>();
            liSessions = Li_Book_SessionManager.GetAllLi_Book_Sessions();
            ddlSession.DataSource = liSessions;
            ddlSession.DataTextField = "SessionName";
            ddlSession.DataValueField = "SessionID";
            ddlSession.DataBind();
        }


        public static void LoadBookID(DropDownList ddlBook)
        {
            List<li_BookInformation> LiBookInformation = new List<li_BookInformation>();
            LiBookInformation = li_BookInformationManager.Get_BookInformations_ComboSourceData();
            ddlBook.DataSource = LiBookInformation;
            ddlBook.DataTextField = "BookName";
            ddlBook.DataValueField = "BookID";
        }


        public void LibraryOwner(DropDownList ddlOwner)
        {
            List<li_LibraryOwner> libOwner = new List<li_LibraryOwner>();
            libOwner = li_LibraryOwnerManager.GetAll_LibraryOwners();
            ddlOwner.DataSource = libOwner;
            ddlOwner.DataTextField = "OwnerName";
            ddlOwner.DataValueField = "LibraryOwnerID";
        }


        public void BookType(DropDownList ddlBookType)
        {
            List<li_BookType> libooktype = new List<li_BookType>();
            libooktype = li_BookTypeManager.GetAll_BookTypes();
            ddlBookType.DataSource = libooktype;
            ddlBookType.DataTextField = "BookType";
            ddlBookType.DataValueField = "BookTypeID";
        }


        public static void LoadPress(DropDownList ddlPress)
        {
            ddlPress.DataSource = Li_PressInfoManager.GetAllLi_PressInfos();
            ddlPress.DataTextField = "PressName";
            ddlPress.DataValueField = "PressID";

        }


        public static void LoadHRInfoStatus(DropDownList ddlInfoStatus)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlInfoStatus.Items.Add(li);

            List<Li_InfoStatus> infos = new List<Li_InfoStatus>();
            infos = Li_InfoStatusManager.GetAllLi_InfoStatuss();
            foreach (Li_InfoStatus info in infos)
            {
                ListItem items = new ListItem(info.InfStatus, info.InfStId.ToString());
                ddlInfoStatus.Items.Add(items);
            }
        }

        public static void LoadDepartments(DropDownList ddlDepartment)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlDepartment.Items.Add(li);
            List<Li_Department> departments = new List<Li_Department>();
            departments = Li_DepartmentManager.GetAllLi_Departments();
            foreach (Li_Department department in departments)
            {
                ListItem items = new ListItem(department.DepName, department.DepId.ToString());
                ddlDepartment.Items.Add(items);
            }
        }



        public static void LoadDesignation(DropDownList ddlDesignation)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlDesignation.Items.Add(li);

            List<Li_Designation> designations = new List<Li_Designation>();
            designations = Li_DesignationManager.GetAllLi_Designations();

            foreach (Li_Designation designation in designations)
            {
                ListItem item = new ListItem(designation.DesName, designation.DesId.ToString());
                ddlDesignation.Items.Add(item);
            }
        }

        public static void LoadSection(DropDownList ddlSection)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlSection.Items.Add(li);

            List<Li_Section> Sections = new List<Li_Section>();
            Sections = Li_SectionManager.GetAllLi_Sections();

            foreach (Li_Section Section in Sections)
            {
                ListItem item = new ListItem(Section.SecName, Section.SecId.ToString());
                ddlSection.Items.Add(item);
            }
        }


        public static void LoadJobCategory(DropDownList ddlJobCategory)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlJobCategory.Items.Add(li);

            List<Li_JobCategory> JobCategories = new List<Li_JobCategory>();
            JobCategories = Li_JobCategoryManager.GetAllLi_JobCategories();

            foreach (Li_JobCategory JobCategory in JobCategories)
            {
                ListItem item = new ListItem(JobCategory.JobCatName, JobCategory.JobCatId.ToString());
                ddlJobCategory.Items.Add(item);
            }
        }

        public static void LoadJobTitle(DropDownList ddlJobTitle)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlJobTitle.Items.Add(li);

            List<Li_JobTitle> JobTitles = new List<Li_JobTitle>();
            JobTitles = Li_JobTitleManager.GetAllLi_JobTitles();

            foreach (Li_JobTitle JobTitle in JobTitles)
            {
                ListItem item = new ListItem(JobTitle.JobTiName, JobTitle.JobTiId.ToString());
                ddlJobTitle.Items.Add(item);
            }
        }

        public static void LoadEmploymentStatus(DropDownList ddlEmploymentStatus)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlEmploymentStatus.Items.Add(li);

            List<Li_EmploymentStatus> EmploymentStatuses = new List<Li_EmploymentStatus>();
            EmploymentStatuses = Li_EmploymentStatusManager.GetAllLi_EmploymentStatuss();

            foreach (Li_EmploymentStatus EmploymentStatus in EmploymentStatuses)
            {
                ListItem item = new ListItem(EmploymentStatus.EmploymentStName, EmploymentStatus.EmploymentStId.ToString());
                ddlEmploymentStatus.Items.Add(item);
            }
        }

        public static void LoadJobLocation(DropDownList ddlJobLocation)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlJobLocation.Items.Add(li);

            List<Li_JobLocation> JobLocations = new List<Li_JobLocation>();
            JobLocations = Li_JobLocationManager.GetAllLi_JobLocations();

            foreach (Li_JobLocation Joblocation in JobLocations)
            {
                ListItem item = new ListItem(Joblocation.LocName, Joblocation.LocId.ToString());
                ddlJobLocation.Items.Add(item);
            }
        }

        public static void LoadWorkShift(DropDownList ddlWorkShift)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlWorkShift.Items.Add(li);

            List<Li_WorkShift> workShifts = new List<Li_WorkShift>();
            workShifts = Li_WorkShiftManager.GetAllLi_WorkShifts();

            foreach (Li_WorkShift workShift in workShifts)
            {
                ListItem item = new ListItem(workShift.WkShfDes, workShift.WkShfId.ToString());
                ddlWorkShift.Items.Add(item);
            }
        }

        public static void LoadMaritalStatus(DropDownList ddlMaritalStatus)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlMaritalStatus.Items.Add(li);

            List<Li_MaritalStatus> MaritalStatus = new List<Li_MaritalStatus>();
            MaritalStatus = Li_MaritalStatusManager.GetAllLi_MaritalStatuss();

            foreach (Li_MaritalStatus maritalSt in MaritalStatus)
            {
                ListItem item = new ListItem(maritalSt.MarStName, maritalSt.MarStId.ToString());
                ddlMaritalStatus.Items.Add(item);
            }
        }

        public static void LoadGender(DropDownList ddlGender)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlGender.Items.Add(li);

            List<Li_Gender> Gernders = new List<Li_Gender>();
            Gernders = Li_GenderManager.GetAllLi_Genders();

            foreach (Li_Gender gender in Gernders)
            {
                ListItem item = new ListItem(gender.GenGp, gender.GenId.ToString());
                ddlGender.Items.Add(item);
            }
        }
        public static void LoadNationality(DropDownList ddlNationality)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlNationality.Items.Add(li);

            List<Li_Nationality> Nationalities = new List<Li_Nationality>();
            Nationalities = Li_NationalityManager.GetAllLi_Nationalities();

            foreach (Li_Nationality Nationality in Nationalities)
            {
                ListItem item = new ListItem(Nationality.NatiName, Nationality.NatiId.ToString());
                ddlNationality.Items.Add(item);
            }
        }

        public static void LoadPayGrade(DropDownList ddlPayGrade)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlPayGrade.Items.Add(li);

            List<Li_PayGrade> PayGrades = new List<Li_PayGrade>();
            PayGrades = Li_PayGradeManager.GetAllLi_PayGrades();

            foreach (Li_PayGrade PayGrade in PayGrades)
            {
                ListItem item = new ListItem(PayGrade.PayGrName, PayGrade.PayGrId.ToString());
                ddlPayGrade.Items.Add(item);
            }
        }

        public static void LoadPayHead(DropDownList ddlPayHead)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlPayHead.Items.Add(li);

            List<Li_PayHead> PayHeads = new List<Li_PayHead>();
            PayHeads = Li_PayHeadManager.GetAllLi_PayHeads();

            foreach (Li_PayHead PayHead in PayHeads)
            {
                ListItem item = new ListItem(PayHead.PaHName, PayHead.PaHId.ToString());
                ddlPayHead.Items.Add(item);
            }
        }

        public static void LoadPayScale(DropDownList ddlPayScale)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlPayScale.Items.Add(li);

            List<Li_PayScale> PayScales = new List<Li_PayScale>();
            PayScales = Li_PayScaleManager.GetAllLi_PayScales();

            foreach (Li_PayScale PayScale in PayScales)
            {
                ListItem item = new ListItem(PayScale.PSAmt.ToString(), PayScale.PScId.ToString());
                ddlPayScale.Items.Add(item);
            }
        }


        public static void LoadLetterTemplate(DropDownList ddlLetterTemplate)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlLetterTemplate.Items.Add(li);

            List<Li_LetterTemplate> letterTemplates = new List<Li_LetterTemplate>();
            letterTemplates = Li_LetterTemplateManager.GetAllLi_LetterTemplates();

            foreach (Li_LetterTemplate letterTemplate in letterTemplates)
            {
                ListItem item = new ListItem(letterTemplate.TempName, letterTemplate.TempId.ToString());
                ddlLetterTemplate.Items.Add(item);
            }
        }

        public static void LaodTerminationReason(DropDownList ddlTerminationReason)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlTerminationReason.Items.Add(li);

            List<Li_TermReason> terminationReasons = new List<Li_TermReason>();
            terminationReasons = Li_TermReasonManager.GetAllLi_TermReasons();

            foreach (Li_TermReason terminationReason in terminationReasons)
            {
                ListItem item = new ListItem(terminationReason.TeReName, terminationReason.TeReId.ToString());
                ddlTerminationReason.Items.Add(item);
            }
        }

        public static void LaodBloodGroup(DropDownList ddlBloodGroup)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlBloodGroup.Items.Add(li);

            List<Li_BloodGroup> bloodGroups = new List<Li_BloodGroup>();
            bloodGroups = Li_BloodGroupManager.GetAllLi_BloodGroups();

            foreach (Li_BloodGroup bloodGroup in bloodGroups)
            {
                ListItem item = new ListItem(bloodGroup.BGName, bloodGroup.BGId.ToString());
                ddlBloodGroup.Items.Add(item);
            }
        }

        public static void LoadReligion(DropDownList ddlReligion)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlReligion.Items.Add(li);

            List<Li_Religion> Religions = new List<Li_Religion>();
            Religions = Li_ReligionManager.GetAllLi_Religions();

            foreach (Li_Religion Religion in Religions)
            {
                ListItem item = new ListItem(Religion.RegName, Religion.RegId.ToString());
                ddlReligion.Items.Add(item);
            }
        }

        public static void LoadEducationLevel(DropDownList ddlEducationLevel)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlEducationLevel.Items.Add(li);

            List<Li_EducationLevel> educationLevels = new List<Li_EducationLevel>();
            educationLevels = Li_EducationLevelManager.GetAllLi_EducationLevels();

            foreach (Li_EducationLevel educationLevel in educationLevels)
            {
                ListItem item = new ListItem(educationLevel.EduLevelName, educationLevel.EduLId.ToString());
                ddlEducationLevel.Items.Add(item);
            }
        }




        public static void LoadExamTitle(DropDownList ddlExamTitle)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlExamTitle.Items.Add(li);

            List<Li_ExamTitle> examTitles = new List<Li_ExamTitle>();
            examTitles = Li_ExamTitleManager.GetAllLi_ExamTitles();

            foreach (Li_ExamTitle examTitle in examTitles)
            {
                ListItem item = new ListItem(examTitle.ExamName, examTitle.ExamId.ToString());
                ddlExamTitle.Items.Add(item);
            }
        }

        public static void LaodEduResult(DropDownList ddlEduResult)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlEduResult.Items.Add(li);

            List<Li_EduResult> eduResults = new List<Li_EduResult>();
            eduResults = Li_EduResultManager.GetAllLi_EduResults();

            foreach (Li_EduResult eduResult in eduResults)
            {
                ListItem item = new ListItem(eduResult.EduReName, eduResult.EduReId.ToString());
                ddlEduResult.Items.Add(item);
            }
        }

        public static void LoadEmployeeInfo(DropDownList ddlEmployee)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlEmployee.Items.Add(li);

            DataSet ds = new DataSet();
            ds = Li_EmployeeInfoManager.GetEmployeeInfoForComboDataSource();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {


                    string empName = ds.Tables[0].Rows[i]["EmpName"].ToString();
                    string nkName = ds.Tables[0].Rows[i]["NickName"].ToString();
                    string empDep = ds.Tables[0].Rows[i]["DepName"].ToString();
                    string empDes = ds.Tables[0].Rows[i]["DesName"].ToString();
                    string empId = ds.Tables[0].Rows[i]["IDNo"].ToString();
                    int empSl = Int32.Parse(ds.Tables[0].Rows[i]["EmpSl"].ToString());


                    ListItem item = new ListItem(empName + "  " + nkName + "  " + empDep + "  " + empDes + " " + empId, empSl.ToString());
                    ddlEmployee.Items.Add(item);
                }
            }
        }

        public static void LaodAssetBrand(DropDownList ddlAssetBrand)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlAssetBrand.Items.Add(li);

            List<Li_AssetBrand> assentBrands = new List<Li_AssetBrand>();
            assentBrands = Li_AssetBrandManager.GetAllLi_AssetBrands();

            foreach (Li_AssetBrand assentBrand in assentBrands)
            {
                ListItem item = new ListItem(assentBrand.BrandName, assentBrand.BrandId.ToString());
                ddlAssetBrand.Items.Add(item);
            }
        }

        public static void LaodAssetCategory(DropDownList ddlAssetCategory)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlAssetCategory.Items.Add(li);

            List<Li_AssetCategory> assentCategories = new List<Li_AssetCategory>();
            assentCategories = Li_AssetCategoryManager.GetAllLi_AssetCategories();

            foreach (Li_AssetCategory assentCategory in assentCategories)
            {
                ListItem item = new ListItem(assentCategory.Category, assentCategory.AssetCatId.ToString());
                ddlAssetCategory.Items.Add(item);
            }
        }

        public static void LaodAssetVendor(DropDownList ddlAssetVendor)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlAssetVendor.Items.Add(li);

            List<Li_AssetVendor> assentVendors = new List<Li_AssetVendor>();
            assentVendors = Li_AssetVendorManager.GetAllLi_AssetVendors();

            foreach (Li_AssetVendor assentVendor in assentVendors)
            {
                ListItem item = new ListItem(assentVendor.VendorName, assentVendor.AssetVenId.ToString());
                ddlAssetVendor.Items.Add(item);
            }
        }

        public static void LoadJobDesResponsibility(DropDownList ddlJobResposibility)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlJobResposibility.Items.Add(li);

            List<Li_JobDesReponsibility> jdResposibilities = new List<Li_JobDesReponsibility>();
            jdResposibilities = Li_JobDesReponsibilityManager.GetAllLi_JobDesReponsibilities();

            foreach (Li_JobDesReponsibility jdResposibility in jdResposibilities)
            {
                ListItem item = new ListItem(jdResposibility.JobRes, jdResposibility.JobResId.ToString());
                ddlJobResposibility.Items.Add(item);
            }
        }

        public static void LoadJobDesEducationalReq(DropDownList ddlJobEducationalReq)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlJobEducationalReq.Items.Add(li);

            List<Li_JobDesEducationalReq> jdEduRequirments = new List<Li_JobDesEducationalReq>();
            jdEduRequirments = Li_JobDesEducationalReqManager.GetAllLi_JobDesEducationalReqs();

            foreach (Li_JobDesEducationalReq jdEduRequirment in jdEduRequirments)
            {
                ListItem item = new ListItem(jdEduRequirment.EduReq, jdEduRequirment.EduReqId.ToString());
                ddlJobEducationalReq.Items.Add(item);
            }
        }


        public static void LoadJobDesExperienceReq(DropDownList ddlJobExperienceReq)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlJobExperienceReq.Items.Add(li);

            List<Li_JobDesExperienceReq> jdExpRequirments = new List<Li_JobDesExperienceReq>();
            jdExpRequirments = Li_JobDesExperienceReqManager.GetAllLi_JobDesExperienceReqs();

            foreach (Li_JobDesExperienceReq jdExpRequirment in jdExpRequirments)
            {
                ListItem item = new ListItem(jdExpRequirment.ExpReq, jdExpRequirment.ExpReqId.ToString());
                ddlJobExperienceReq.Items.Add(item);
            }
        }


        public static void LoadJobDesRequirment(DropDownList ddlJobRequirments)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlJobRequirments.Items.Add(li);

            List<Li_JobDesRequirment> jdRequirments = new List<Li_JobDesRequirment>();
            jdRequirments = Li_JobDesRequirmentManager.GetAllLi_JobDesRequirments();

            foreach (Li_JobDesRequirment jdRequirment in jdRequirments)
            {
                ListItem item = new ListItem(jdRequirment.JobReq, jdRequirment.JobReqId.ToString());
                ddlJobRequirments.Items.Add(item);
            }
        }

        public static void LoadJobDesBenefit(DropDownList ddlJobBenefit)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlJobBenefit.Items.Add(li);

            List<Li_JobDesBenefit> jdBenefits = new List<Li_JobDesBenefit>();
            jdBenefits = Li_JobDesBenefitManager.GetAllLi_JobDesBenefits();

            foreach (Li_JobDesBenefit jdBenefit in jdBenefits)
            {
                ListItem item = new ListItem(jdBenefit.JobBenefit, jdBenefit.JobBenId.ToString());
                ddlJobBenefit.Items.Add(item);
            }
        }

        public static void LoadJobTask(DropDownList ddlJobTask)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlJobTask.Items.Add(li);

            List<Li_JobTask> jdTasks = new List<Li_JobTask>();
            jdTasks = Li_JobTaskManager.GetAllLi_JobTasks();

            foreach (Li_JobTask jdTask in jdTasks)
            {
                ListItem item = new ListItem(jdTask.JobTask, jdTask.JobTaskId.ToString());
                ddlJobTask.Items.Add(item);
            }
        }

        public static void LoadOffSchedule(DropDownList ddlOffSchedule)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlOffSchedule.Items.Add(li);

            List<Li_OffSchedule> schedules = new List<Li_OffSchedule>();
            schedules = Li_OffScheduleManager.GetAllLi_OffSchedules();

            foreach (Li_OffSchedule schedule in schedules)
            {
                ListItem item = new ListItem(schedule.SchName, schedule.SchId.ToString());
                ddlOffSchedule.Items.Add(item);
            }
        }

        public static void LoadLeaveType(DropDownList ddlLeaveType)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlLeaveType.Items.Add(li);

            List<Li_LeaveType> lvtypes = new List<Li_LeaveType>();
            lvtypes = Li_LeaveTypeManager.GetAllLi_LeaveTypes();

            foreach (Li_LeaveType lvtype in lvtypes)
            {
                ListItem item = new ListItem(lvtype.LeTyName, lvtype.LeTypId.ToString());
                ddlLeaveType.Items.Add(item);
            }
        }

        public static void LoadLeaveRule(DropDownList ddlLeaveRule)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlLeaveRule.Items.Add(li);

            List<Li_LeaveRule> lvRules = new List<Li_LeaveRule>();
            lvRules = Li_LeaveRuleManager.GetAllLi_LeaveRules();

            foreach (Li_LeaveRule lvRule in lvRules)
            {
                ListItem item = new ListItem(lvRule.LeRuName, lvRule.LeRuId.ToString());
                ddlLeaveRule.Items.Add(item);
            }
        }

        public static void LoadLeavePeriod(DropDownList ddlPeriod)
        {
            ListItem li = new ListItem("Select Any", "0");
            ddlPeriod.Items.Add(li);

            List<Li_LeavePeriod> lvPeriods = new List<Li_LeavePeriod>();
            lvPeriods = Li_LeavePeriodManager.GetAllLi_LeavePeriods();

            foreach (Li_LeavePeriod lvPeriod in lvPeriods)
            {
                ListItem item = new ListItem(lvPeriod.PerName, lvPeriod.PerId.ToString());
                ddlPeriod.Items.Add(item);
            }
        }

        public static void LoadDonYear(DropDownList ddlYear)
        {
            ddlYear.Items.Clear();
            ListItem li = new ListItem("Select Any", "0");
            ddlYear.Items.Add(li);

            List<Li_DonYear> donYears = new List<Li_DonYear>();
            donYears = Li_DonYearManager.GetAllLi_DonYears();

            foreach (Li_DonYear donYear in donYears)
            {
                ListItem item = new ListItem(donYear.DonYear, donYear.DonYear);
                ddlYear.Items.Add(item);
            }
        }

        public static void LoadMadrasah(DropDownList ddlMadrasah, int thanaId)
        {
            ddlMadrasah.Items.Clear();
            ListItem li = new ListItem("Select Any", "0");
            ddlMadrasah.Items.Add(li);

            List<Li_MadrasahEntry> madrasahList = new List<Li_MadrasahEntry>();
            madrasahList = Li_MadrasahEntryManager.GetAllLi_MadrasahEntries(thanaId);

            foreach (Li_MadrasahEntry madrasah in madrasahList)
            {
                ListItem item = new ListItem(madrasah.Name + "   " + madrasah.Code, madrasah.Code);
                ddlMadrasah.Items.Add(item);
            }
        }

        public static void LoadDepartmentsFromEmpInfos(DropDownList ddlDepartment)
        {
            ddlDepartment.Items.Clear();
            ListItem li = new ListItem("Select Any", "0");
            ddlDepartment.Items.Add(li);

            DataTable dt = new DataTable();
            SqlLi_DepartmentProvider departmentProvider = new SqlLi_DepartmentProvider();
            dt = departmentProvider.loadDepartmentFromEmpInfo();



            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem item = new ListItem(dt.Rows[i]["DepName"].ToString(), dt.Rows[i]["DepId"].ToString());
                    ddlDepartment.Items.Add(item);
                }

            }
        }



        public static void LoadSectionFromEmpInfos(DropDownList ddlSection, int depId)
        {
            ddlSection.Items.Clear();
            DataTable dt = new System.Data.DataTable();

            ListItem li = new ListItem("Select Any", "0");
            ddlSection.Items.Add(li);
            SqlLi_SectionProvider sectionProvider = new SqlLi_SectionProvider();
            dt = sectionProvider.LoadSectionFromEmpInfos(depId);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem item = new ListItem(dt.Rows[i]["SecName"].ToString(), dt.Rows[i]["SecId"].ToString());
                    ddlSection.Items.Add(item);
                }
            }
        }



        public static void LoadDesignationsFromEmpInfos(DropDownList ddlDesignation, int depId, int SecId)
        {
            ddlDesignation.Items.Clear();
            DataTable dt = new System.Data.DataTable();

            ListItem li = new ListItem("Select Any", "0");
            ddlDesignation.Items.Add(li);

            SqlLi_DesignationProvider designationProvider = new SqlLi_DesignationProvider();
            dt = designationProvider.LoadDesignationFromEmpInfos(depId, SecId);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem item = new ListItem(dt.Rows[i]["DesName"].ToString(), dt.Rows[i]["DesId"].ToString());
                    ddlDesignation.Items.Add(item);
                }
            }
        }




        public static void LoadJobTitleFromEmpInfos(DropDownList ddlJobTitle, int depId, int SecId)
        {
            ddlJobTitle.Items.Clear();
            DataTable dt = new System.Data.DataTable();

            ListItem li = new ListItem("Select Any", "0");
            ddlJobTitle.Items.Add(li);

            SqlLi_JobTitleProvider JobTitles = new SqlLi_JobTitleProvider();
            dt = JobTitles.LoadJobTitleFromEmpInfos(depId, SecId);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem item = new ListItem(dt.Rows[i]["JobTiName"].ToString(), dt.Rows[i]["JobTiId"].ToString());
                    ddlJobTitle.Items.Add(item);

                }
            }
        }


        public static void LoadJobCategoryFormEmpInfos(DropDownList ddlJobCategory, int depId, int SecId)
        {
            ddlJobCategory.Items.Clear();
            DataTable dt = new System.Data.DataTable();

            ListItem li = new ListItem("Select Any", "0");
            ddlJobCategory.Items.Add(li);


            SqlLi_JobCategoryProvider JobCategories = new SqlLi_JobCategoryProvider();
            dt = JobCategories.LoadJobCategoryFromEmpInfos(depId, SecId);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem item = new ListItem(dt.Rows[i]["JobCatName"].ToString(), dt.Rows[i]["JobCatId"].ToString());
                    ddlJobCategory.Items.Add(item);
                }
            }
        }


        public static void LaodAssetList(DropDownList ddlAssetList)
        {
            ddlAssetList.Items.Clear();

            DataTable dt = new System.Data.DataTable();
            ListItem li = new ListItem("Select Any", "0");
            ddlAssetList.Items.Add(li);


            SqlLi_AssetListProvider assetListProvider = new SqlLi_AssetListProvider();
            dt = assetListProvider.LoadGvAssetList();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    ListItem item = new ListItem(dt.Rows[i]["cmbAssetName"].ToString(), dt.Rows[i]["AssetId"].ToString());
                    ddlAssetList.Items.Add(item);
                }

            }



        }

        //-----------------------Rezaul Hossain-------------------
        //public static void LoadTSO(DropDownList ddlTsoName)
        //{
        //    try
        //    {
        //        List<Li_SalesPerson> li_TSOInformation = new List<Li_SalesPerson>();

        //        li_TSOInformation = Li_SalesPersonManager.GetAll_ComboBox_TSOInformations();
        //        ddlTsoName.DataSource = li_TSOInformation;
        //        ddlTsoName.DataTextField = "TSOID";
        //        ddlTsoName.DataValueField = "Name";
        //        ddlTsoName.DataBind();



        //    }
        //    catch (Exception)
        //    {


        //    }
        //}
        public static void LoadRegion(DropDownList ddlRegion)
        {
            List<li_Region> li_Regions = new List<li_Region>();

            li_Regions = li_RegionManager.Get_AllRegion();
            ddlRegion.DataSource = li_Regions;
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataValueField = "RegionID";

        }

        public static void LoadTSOIndo(DropDownList ddlTSOName)
        {
            ddlTSOName.DataSource = Li_SalesPersonManager.Get_AllTSO();
            ddlTSOName.DataTextField = "Name";
            //ddlTSOName.DataValueField = "TName";
            ddlTSOName.DataValueField = "TSOID";
            ddlTSOName.SelectedIndex = -1;
        }



        public class ComboFirstItem
        {
            public string Name;
            public int Id;

            public ComboFirstItem(string name, int id)
            {
                Name = name;
                Id = id;
            }
        }
    }
}
