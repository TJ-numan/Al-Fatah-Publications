using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_McqQuestionManager
{
	public Li_McqQuestionManager()
	{
	}

    public static List<Li_McqQuestion> GetAllLi_McqQuestions()
    {
        List<Li_McqQuestion> li_McqQuestions = new List<Li_McqQuestion>();
        SqlLi_McqQuestionProvider sqlLi_McqQuestionProvider = new SqlLi_McqQuestionProvider();
        li_McqQuestions = sqlLi_McqQuestionProvider.GetAllLi_McqQuestions();
        return li_McqQuestions;
    }


    public static Li_McqQuestion GetLi_McqQuestionByID(int id)
    {
        Li_McqQuestion li_McqQuestion = new Li_McqQuestion();
        SqlLi_McqQuestionProvider sqlLi_McqQuestionProvider = new SqlLi_McqQuestionProvider();
        li_McqQuestion = sqlLi_McqQuestionProvider.GetLi_McqQuestionByID(id);
        return li_McqQuestion;
    }


    public static int InsertLi_McqQuestion(Li_McqQuestion li_McqQuestion)
    {
        SqlLi_McqQuestionProvider sqlLi_McqQuestionProvider = new SqlLi_McqQuestionProvider();
        return sqlLi_McqQuestionProvider.InsertLi_McqQuestion(li_McqQuestion);
    }


    public static bool UpdateLi_McqQuestion(Li_McqQuestion li_McqQuestion)
    {
        SqlLi_McqQuestionProvider sqlLi_McqQuestionProvider = new SqlLi_McqQuestionProvider();
        return sqlLi_McqQuestionProvider.UpdateLi_McqQuestion(li_McqQuestion);
    }

    public static bool DeleteLi_McqQuestion(int li_McqQuestionID)
    {
        SqlLi_McqQuestionProvider sqlLi_McqQuestionProvider = new SqlLi_McqQuestionProvider();
        return sqlLi_McqQuestionProvider.DeleteLi_McqQuestion(li_McqQuestionID);
    }
}
