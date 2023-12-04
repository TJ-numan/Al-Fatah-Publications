using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmployeeInfoProvider:DataAccessObject
{
	public SqlLi_EmployeeInfoProvider()
    {
    }


    public bool DeleteLi_EmployeeInfo(int li_EmployeeInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmployeeInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmployeeInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmployeeInfo> GetAllLi_EmployeeInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmployeeInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmployeeInfosFromReader(reader);
        }
    }
    public List<Li_EmployeeInfo> GetLi_EmployeeInfosFromReader(IDataReader reader)
    {
        List<Li_EmployeeInfo> li_EmployeeInfos = new List<Li_EmployeeInfo>();

        while (reader.Read())
        {
            li_EmployeeInfos.Add(GetLi_EmployeeInfoFromReader(reader));
        }
        return li_EmployeeInfos;
    }

    public Li_EmployeeInfo GetLi_EmployeeInfoFromReader(IDataReader reader)
    {
        try
        {
            Li_EmployeeInfo li_EmployeeInfo = new Li_EmployeeInfo
                (
                    
                    (int)reader["EmpSl"],
                    reader["IDNo"].ToString(),
                    reader["ProximityNo"].ToString(),
                    reader["EmpName"].ToString(),
                    reader["EmpNameBn"].ToString(),
                    reader["NickName"].ToString(),
                    (int)reader["DepId"],
                    (int)reader["DesId"],
                    (int)reader["SecId"],
                    (int)reader["GenId"],
                    (int)reader["BGId"],
                    (int)reader["RegId"],
                    (int)reader["EmploymentStId"],
                    (int)reader["ReportTo"],
                    (DateTime)reader["JoiningDate"],
                    (DateTime)reader["DateOfBirth"],
                    (decimal)reader["EmpAge"],
                    reader["PhoneNo"].ToString(),
                    (byte[])reader["ImgPath"] ,
                    (byte[])reader["SignPath"] ,
                    reader["FName"].ToString(),
                    reader["MName"].ToString(),
                    (int)reader["MarStId"],
                    reader["SName"].ToString(),
                    reader["PreAdd"].ToString(),
                    (int)reader["PreThanaId"],
                    (int)reader["PreDistrictId"],
                    reader["PerAdd"].ToString(),
                    (int)reader["PerThanaId"],
                    (int)reader["PerDistrictId"],
                    (int)reader["NatiId"] ,
                    reader["EmailAdd"].ToString(),
                    (byte[])reader["CvPath"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"],
                    reader ["NID"].ToString (),
                    (int)reader ["JobTitleId"]
                );
             return li_EmployeeInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmployeeInfo GetLi_EmployeeInfoByID(int li_EmployeeInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmployeeInfoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmployeeInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmployeeInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmployeeInfo(Li_EmployeeInfo li_EmployeeInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmployeeInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@IDNo", SqlDbType.VarChar).Value = li_EmployeeInfo.IDNo;
            cmd.Parameters.Add("@ProximityNo", SqlDbType.VarChar).Value = li_EmployeeInfo.ProximityNo;
            cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = li_EmployeeInfo.EmpName;
            cmd.Parameters.Add("@EmpNameBn", SqlDbType.Text).Value = li_EmployeeInfo.EmpNameBn;
            cmd.Parameters.Add("@NickName", SqlDbType.VarChar).Value = li_EmployeeInfo.NickName;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_EmployeeInfo.DepId;
            cmd.Parameters.Add("@DesId", SqlDbType.Int).Value = li_EmployeeInfo.DesId;
            cmd.Parameters.Add("@SecId", SqlDbType.Int).Value = li_EmployeeInfo.SecId;
            cmd.Parameters.Add("@GenId", SqlDbType.Int).Value = li_EmployeeInfo.GenId;
            cmd.Parameters.Add("@BGId", SqlDbType.Int).Value = li_EmployeeInfo.BGId;
            cmd.Parameters.Add("@RegId", SqlDbType.Int).Value = li_EmployeeInfo.RegId;
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_EmployeeInfo.EmploymentStId;
            cmd.Parameters.Add("@ReportTo", SqlDbType.Int).Value = li_EmployeeInfo.ReportTo;
            cmd.Parameters.Add("@JoiningDate", SqlDbType.DateTime).Value = li_EmployeeInfo.JoiningDate;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = li_EmployeeInfo.DateOfBirth;
            cmd.Parameters.Add("@EmpAge", SqlDbType.Decimal).Value = li_EmployeeInfo.EmpAge;
            cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar).Value = li_EmployeeInfo.PhoneNo;
            cmd.Parameters.Add("@ImgPath", SqlDbType.Binary).Value = li_EmployeeInfo.ImgPath;
            cmd.Parameters.Add("@SignPath", SqlDbType.Binary ).Value = li_EmployeeInfo.SignPath;
            cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = li_EmployeeInfo.FName;
            cmd.Parameters.Add("@MName", SqlDbType.VarChar).Value = li_EmployeeInfo.MName;
            cmd.Parameters.Add("@MarStId", SqlDbType.Int).Value = li_EmployeeInfo.MarStId;
            cmd.Parameters.Add("@SName", SqlDbType.VarChar).Value = li_EmployeeInfo.SName;
            cmd.Parameters.Add("@PreAdd", SqlDbType.VarChar).Value = li_EmployeeInfo.PreAdd;
            cmd.Parameters.Add("@PreThanaId", SqlDbType.Int).Value = li_EmployeeInfo.PreThanaId;
            cmd.Parameters.Add("@PreDistrictId", SqlDbType.Int).Value = li_EmployeeInfo.PreDistrictId;
            cmd.Parameters.Add("@PerAdd", SqlDbType.VarChar).Value = li_EmployeeInfo.PerAdd;
            cmd.Parameters.Add("@PerThanaId", SqlDbType.Int).Value = li_EmployeeInfo.PerThanaId;
            cmd.Parameters.Add("@PerDistrictId", SqlDbType.Int).Value = li_EmployeeInfo.PerDistrictId;
            cmd.Parameters.Add("@NatiId", SqlDbType.VarChar).Value = li_EmployeeInfo.NatiId;
            cmd.Parameters.Add("@EmailAdd", SqlDbType.VarChar).Value = li_EmployeeInfo.EmailAdd;
            cmd.Parameters.Add("@CvPath", SqlDbType.Binary).Value = li_EmployeeInfo.CvPath;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmployeeInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmployeeInfo.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmployeeInfo.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmployeeInfo.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmployeeInfo.InfStId;
            cmd.Parameters.Add("@NID", SqlDbType.VarChar).Value = li_EmployeeInfo.NID;
            cmd.Parameters.Add("@JobTitleId", SqlDbType.Int).Value = li_EmployeeInfo.JobTitleId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmpSl"].Value;
        }
    }

    public bool UpdateLi_EmployeeInfo(Li_EmployeeInfo li_EmployeeInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmployeeInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmployeeInfo.EmpSl;
            cmd.Parameters.Add("@IDNo", SqlDbType.VarChar).Value = li_EmployeeInfo.IDNo;
            cmd.Parameters.Add("@ProximityNo", SqlDbType.VarChar).Value = li_EmployeeInfo.ProximityNo;
            cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = li_EmployeeInfo.EmpName;
            cmd.Parameters.Add("@EmpNameBn", SqlDbType.Text).Value = li_EmployeeInfo.EmpNameBn;
            cmd.Parameters.Add("@NickName", SqlDbType.VarChar).Value = li_EmployeeInfo.NickName;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_EmployeeInfo.DepId;
            cmd.Parameters.Add("@DesId", SqlDbType.Int).Value = li_EmployeeInfo.DesId;
            cmd.Parameters.Add("@SecId", SqlDbType.Int).Value = li_EmployeeInfo.SecId;
            cmd.Parameters.Add("@GenId", SqlDbType.Int).Value = li_EmployeeInfo.GenId;
            cmd.Parameters.Add("@BGId", SqlDbType.Int).Value = li_EmployeeInfo.BGId;
            cmd.Parameters.Add("@RegId", SqlDbType.Int).Value = li_EmployeeInfo.RegId;
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_EmployeeInfo.EmploymentStId;
            cmd.Parameters.Add("@ReportTo", SqlDbType.Int).Value = li_EmployeeInfo.ReportTo;
            cmd.Parameters.Add("@JoiningDate", SqlDbType.DateTime).Value = li_EmployeeInfo.JoiningDate;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = li_EmployeeInfo.DateOfBirth;
            cmd.Parameters.Add("@EmpAge", SqlDbType.Decimal).Value = li_EmployeeInfo.EmpAge;
            cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar).Value = li_EmployeeInfo.PhoneNo;
            cmd.Parameters.Add("@ImgPath", SqlDbType.Binary).Value = li_EmployeeInfo.ImgPath;
            cmd.Parameters.Add("@SignPath", SqlDbType.Binary).Value = li_EmployeeInfo.SignPath;
            cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = li_EmployeeInfo.FName;
            cmd.Parameters.Add("@MName", SqlDbType.VarChar).Value = li_EmployeeInfo.MName;
            cmd.Parameters.Add("@MarStId", SqlDbType.Int).Value = li_EmployeeInfo.MarStId;
            cmd.Parameters.Add("@SName", SqlDbType.VarChar).Value = li_EmployeeInfo.SName;
            cmd.Parameters.Add("@PreAdd", SqlDbType.VarChar).Value = li_EmployeeInfo.PreAdd;
            cmd.Parameters.Add("@PreThanaId", SqlDbType.Int).Value = li_EmployeeInfo.PreThanaId;
            cmd.Parameters.Add("@PreDistrictId", SqlDbType.Int).Value = li_EmployeeInfo.PreDistrictId;
            cmd.Parameters.Add("@PerAdd", SqlDbType.VarChar).Value = li_EmployeeInfo.PerAdd;
            cmd.Parameters.Add("@PerThanaId", SqlDbType.Int).Value = li_EmployeeInfo.PerThanaId;
            cmd.Parameters.Add("@PerDistrictId", SqlDbType.Int).Value = li_EmployeeInfo.PerDistrictId;
            cmd.Parameters.Add("@NatiId", SqlDbType.VarChar).Value = li_EmployeeInfo.NatiId;
            cmd.Parameters.Add("@EmailAdd", SqlDbType.VarChar).Value = li_EmployeeInfo.EmailAdd;
            cmd.Parameters.Add("@CvPath", SqlDbType.Binary).Value = li_EmployeeInfo.CvPath;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmployeeInfo.CreatedBy;
            //cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmployeeInfo.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmployeeInfo.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmployeeInfo.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmployeeInfo.InfStId;
            cmd.Parameters.Add("@NID", SqlDbType.VarChar).Value = li_EmployeeInfo.NID;
            cmd.Parameters.Add("@JobTitleId", SqlDbType.Int).Value = li_EmployeeInfo.JobTitleId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
         

    }

    public DataSet GetEmployeeInfoForComboDataSource()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadEmployeeForComboDataSource", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public DataTable  GetEmployeeNextSL()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetEmpNextSl", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@NextSl", SqlDbType.Int).Direction = ParameterDirection. Output;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }


    public DataTable  LoadGvEmployeeInfo()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadGvEmployee", connection);
            command.CommandType = CommandType.StoredProcedure; 
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
    public DataTable LoadGvEmployeeInfoEmpId(int EmpSl)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.[LoadGvEmployeeByEmpId]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmpSl", SqlDbType.Int).Value = EmpSl;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
    public DataTable GetLi_EmployeeListByDepID(int DepId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.[SMPM_li_GetLi_EmployeeListByDepID]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DepId", SqlDbType.Int).Value = DepId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }

   public DataTable  LoadrptGvEmployeeInfo(int DepId, int SecId, int DesId , int  JotId  , int EmpStId , int SerAgeFrom , int SerAgeTo , int DPart , int SalFrom , int SalTo  )
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.rptLoadGvEmployee", connection);
            command.CommandType = CommandType.StoredProcedure; 

             command .Parameters .Add ("@DepId",SqlDbType .Int ).Value =DepId;
             command .Parameters .Add ("@SecId",SqlDbType .Int ).Value =SecId ;	
             command .Parameters .Add ("@DesId",SqlDbType .Int ).Value = DesId;
             command .Parameters .Add ("@JotId",SqlDbType .Int ).Value =JotId ;	  
             command .Parameters .Add ("@EmpStId",SqlDbType .Int ).Value =EmpStId ;
             command .Parameters .Add ("@SerAgeFrom",SqlDbType .Int ).Value =SerAgeFrom ;	
             command .Parameters .Add ("@SerAgeTo",SqlDbType .Int ).Value =SerAgeTo ;
             command .Parameters .Add ("@DPart",SqlDbType .Int ).Value =DPart ;	
             command .Parameters .Add ("@SalFrom",SqlDbType .Int ).Value =SalFrom ;			  
             command .Parameters .Add ("@SalTo",SqlDbType .Int ).Value = SalTo;	 

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
     }
   public DataTable GetLi_EmployeeListBySecID(int SecId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_Li_GetAllEmployeesBySection", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SectionID", SqlDbType.Int).Value = SecId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
   public DataTable GetLi_EmployeeRZListBySecID(int SecId, int Employeer)
   {
       DataTable dt = new DataTable();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_Li_GetAllEmployeesRZBySection", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("@SectionID", SqlDbType.Int).Value = SecId;
           command.Parameters.Add("@Employeer", SqlDbType.Int).Value = Employeer;
           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(dt);
           myadapter.Dispose();
           connection.Close();
           return dt;
       }
   }
   //--------------------------------------------rezaul Hossain------------------2021-06-01-----------
   public DataTable GetLi_EmployeeListBySecIDQawmi(int SecId)
   {
       DataTable dt = new DataTable();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_Li_GetAllEmployeesBySectionQawmi", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("@SectionID", SqlDbType.Int).Value = SecId;
           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(dt);
           myadapter.Dispose();
           connection.Close();
           return dt;
       }
   }
   public DataTable GetLi_EmployeeRZListBySecIDQawmi(int SecId, int Employeer)
   {
       DataTable dt = new DataTable();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_Li_GetAllEmployeesRZBySectionQawmi", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("@SectionID", SqlDbType.Int).Value = SecId;
           command.Parameters.Add("@Employeer", SqlDbType.Int).Value = Employeer;
           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(dt);
           myadapter.Dispose();
           connection.Close();
           return dt;
       }
   }
   public DataTable GetLi_EmployeeListRZByEmployeer(int Employeer)
   {
       DataTable dt = new DataTable();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_Li_GetAllEmployeesRZByEmployeer", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("@Employeer", SqlDbType.Int).Value = Employeer;
           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(dt);
           myadapter.Dispose();
           connection.Close();
           return dt;
       }
   }
   public DataTable GetLi_EmployeeListRZByEmployeerQawmi(int Employeer)
   {
       DataTable dt = new DataTable();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
           SqlCommand command = new SqlCommand("SMPM_Li_GetAllEmployeesRZByEmployeerQawmi", connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Add("@Employeer", SqlDbType.Int).Value = Employeer;
           connection.Open();
           SqlDataAdapter myadapter = new SqlDataAdapter(command);
           myadapter.Fill(dt);
           myadapter.Dispose();
           connection.Close();
           return dt;
       }
   }

}
