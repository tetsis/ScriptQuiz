using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Quizzes.Answer
{
    public class QuizAnswerResult
    {
        public QuizAnswerResult(bool isCorrect)
        {
            IsCorrect = isCorrect;
        }

        public bool IsCorrect { get; }
    }
}
