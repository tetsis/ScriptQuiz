using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Quizzes.Create
{
    public class QuizCreateResult
    {
        public QuizCreateResult(string createdQuizId)
        {
            CreatedQuizId = createdQuizId;
        }

        public string CreatedQuizId { get; }
    }
}
