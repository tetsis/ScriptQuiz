using ScriptQuizWeb.ViewModels.Quizzes.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptQuizWeb.ViewModels.Quizzes.Get
{
    public class QuizGetResponseModel
    {
        public QuizGetResponseModel(QuizResponseModel quiz)
        {
            Quiz = quiz;
        }

        public QuizResponseModel Quiz { get; }
    }
}
