using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpTrainingManager
{
	public Li_EmpTrainingManager()
	{
	}

    public static List<Li_EmpTraining> GetAllLi_EmpTrainings()
    {
        List<Li_EmpTraining> li_EmpTrainings = new List<Li_EmpTraining>();
        SqlLi_EmpTrainingProvider sqlLi_EmpTrainingProvider = new SqlLi_EmpTrainingProvider();
        li_EmpTrainings = sqlLi_EmpTrainingProvider.GetAllLi_EmpTrainings();
        return li_EmpTrainings;
    }


    public static Li_EmpTraining GetLi_EmpTrainingByID(int id)
    {
        Li_EmpTraining li_EmpTraining = new Li_EmpTraining();
        SqlLi_EmpTrainingProvider sqlLi_EmpTrainingProvider = new SqlLi_EmpTrainingProvider();
        li_EmpTraining = sqlLi_EmpTrainingProvider.GetLi_EmpTrainingByID(id);
        return li_EmpTraining;
    }


    public static int InsertLi_EmpTraining(Li_EmpTraining li_EmpTraining)
    {
        SqlLi_EmpTrainingProvider sqlLi_EmpTrainingProvider = new SqlLi_EmpTrainingProvider();
        return sqlLi_EmpTrainingProvider.InsertLi_EmpTraining(li_EmpTraining);
    }


    public static bool UpdateLi_EmpTraining(Li_EmpTraining li_EmpTraining)
    {
        SqlLi_EmpTrainingProvider sqlLi_EmpTrainingProvider = new SqlLi_EmpTrainingProvider();
        return sqlLi_EmpTrainingProvider.UpdateLi_EmpTraining(li_EmpTraining);
    }

    public static bool DeleteLi_EmpTraining(int li_EmpTrainingID)
    {
        SqlLi_EmpTrainingProvider sqlLi_EmpTrainingProvider = new SqlLi_EmpTrainingProvider();
        return sqlLi_EmpTrainingProvider.DeleteLi_EmpTraining(li_EmpTrainingID);
    }

    public static DataTable  LoadGvEmployeeTraining()
    {
        SqlLi_EmpTrainingProvider sqlLi_EmpTrainingProvider = new SqlLi_EmpTrainingProvider();
        return sqlLi_EmpTrainingProvider.LoadGvEmployeeTraining();
    }

}
