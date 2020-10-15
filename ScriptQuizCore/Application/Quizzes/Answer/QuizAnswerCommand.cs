using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Quizzes.Answer
{
    public class QuizAnswerCommand
    {
        public QuizAnswerCommand(string id, int answerNumberOfAnswerer)
        {
            Id = id;
            AnswerNumberOfAnswerer = answerNumberOfAnswerer;
        }

        public string Id { get; }
        public int AnswerNumberOfAnswerer { get; }
    }
}
