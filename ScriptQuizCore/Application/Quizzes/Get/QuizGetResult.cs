using ScriptQuizCore.Application.Quizzes.Commons;
using ScriptQuizCore.Application.Quizzes.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Quizzes.Get
{
    public class QuizGetResult
    {
        public QuizGetResult(QuizData quiz)
        {
            Quiz = quiz;
        }

        public QuizData Quiz { get; }
    }
}
