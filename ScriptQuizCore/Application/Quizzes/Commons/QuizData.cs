using ScriptQuizCore.Domain.Quizzes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Quizzes.Commons
{
    public class QuizData
    {
        public QuizData(Quiz quiz) : this(quiz.Id, quiz.Question, quiz.Choices)
        {

        }

        public QuizData(string id, string question, List<string> choices)
        {
            Id = id;
            Question = question;
            Choices = choices;
        }

        public string Id { get; }
        public string Question { get; }
        public List<string> Choices { get; }
    }
}
