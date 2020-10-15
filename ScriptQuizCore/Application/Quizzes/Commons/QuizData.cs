using ScriptQuizCore.Domain.Quizzes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Quizzes.Commons
{
    public class QuizData
    {
        public QuizData(Quiz quiz) : this(quiz.Id, quiz.Question, quiz.Choices, quiz.AnswerNumber)
        {

        }

        public QuizData(string id, string question, List<string> choices, int answerNumber)
        {
            Id = id;
            Question = question;
            Choices = choices;
            AnswerNumber = answerNumber;
        }

        public string Id { get; }
        public string Question { get; }
        public List<string> Choices { get; }
        public int AnswerNumber { get; }
    }
}
