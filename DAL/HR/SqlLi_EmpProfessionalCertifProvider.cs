using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
public class SqlLi_EmpProfessionalCertifProvider : DataAccessObject
{
    public SqlLi_EmpProfessionalCertifProvider()
    {
    }


    public bool DeleteLi_EmpProfessionalCertif(int li_EmpProfessionalCertifID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpProfessionalCertif", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProQuaId", SqlDbType.Int).Value = li_EmpProfessionalCertifID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpProfessionalCertif> GetAllLi_EmpProfessionalCertifs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpProfessionalCertifs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpProfessionalCertifsFromReader(reader);
        }
    }
    public List<Li_EmpProfessionalCertif> GetLi_EmpProfessionalCertifsFromReader(IDataReader reader)
    {
        List<Li_EmpProfessionalCertif> li_EmpProfessionalCertifs = new List<Li_EmpProfessionalCertif>();

        while (reader.Read())
        {
            li_EmpProfessionalCertifs.Add(GetLi_EmpProfessionalCertifFromReader(reader));
        }
        return li_EmpProfessionalCertifs;
    }

    public Li_EmpProfessionalCertif GetLi_EmpProfessionalCertifFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpProfessionalCertif li_EmpProfessionalCertif = new Li_EmpProfessionalCertif
                (

                    (int)reader["ProQuaId"],
                    (int)reader["EmpSl"],
                    reader["Certification"].ToString(),
                    reader["InstituteName"].ToString(),
                    reader["Location"].ToString(),
                    reader["CertificationPeriod"].ToString(),
                    reader["CertifPath"].ToString(),
                    (bool)reader["IsMembership"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
            return li_EmpProfessionalCertif;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_EmpProfessionalCertif GetLi_EmpProfessionalCertifByID(int li_EmpProfessionalCertifID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpProfessionalCertifByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ProQuaId", SqlDbType.Int).Value = li_EmpProfessionalCertifID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpProfessionalCertifFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpProfessionalCertif(Li_EmpProfessionalCertif li_EmpProfessionalCertif)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpProfessionalCertif", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ProQuaId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpProfessionalCertif.EmpSl;
            cmd.Parameters.Add("@Certification", SqlDbType.VarChar).Value = li_EmpProfessionalCertif.Certification;
            cmd.Parameters.Add("@InstituteName", SqlDbType.VarChar).Value = li_EmpProfessionalCertif.InstituteName;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = li_EmpProfessionalCertif.Location;
            cmd.Parameters.Add("@CertificationPeriod", SqlDbType.VarChar).Value = li_EmpProfessionalCertif.CertificationPeriod;
            cmd.Parameters.Add("@CertifPath", SqlDbType.VarChar).Value = li_EmpProfessionalCertif.CertifPath;
            cmd.Parameters.Add("@IsMembership", SqlDbType.Bit).Value = li_EmpProfessionalCertif.IsMembership;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpProfessionalCertif.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpProfessionalCertif.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpProfessionalCertif.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpProfessionalCertif.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpProfessionalCertif.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ProQuaId"].Value;
        }
    }

    public bool UpdateLi_EmpProfessionalCertif(Li_EmpProfessionalCertif li_EmpProfessionalCertif)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpProfessionalCertif", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ProQuaId", SqlDbType.Int).Value = li_EmpProfessionalCertif.ProQuaId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpProfessionalCertif.EmpSl;
            cmd.Parameters.Add("@Certification", SqlDbType.VarChar).Value = li_EmpProfessionalCertif.Certification;
            cmd.Parameters.Add("@InstituteName", SqlDbType.VarChar).Value = li_EmpProfessionalCertif.InstituteName;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = li_EmpProfessionalCertif.Location;
            cmd.Parameters.Add("@CertificationPeriod", SqlDbType.VarChar).Value = li_EmpProfessionalCertif.CertificationPeriod;
            cmd.Parameters.Add("@CertifPath", SqlDbType.VarChar).Value = li_EmpProfessionalCertif.CertifPath;
            cmd.Parameters.Add("@IsMembership", SqlDbType.Bit).Value = li_EmpProfessionalCertif.IsMembership;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpProfessionalCertif.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpProfessionalCertif.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpProfessionalCertif.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpProfessionalCertif.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpProfessionalCertif.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }




    public DataTable LoadGvProfessionalCertificate()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadGvProfessionalCertificate", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();

            return dt;
        }
    }
}
