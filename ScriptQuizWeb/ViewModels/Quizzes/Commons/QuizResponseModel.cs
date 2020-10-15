using ScriptQuizCore.Application.Quizzes.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptQuizWeb.ViewModels.Quizzes.Commons
{
    public class QuizResponseModel
    {
        public QuizResponseModel(QuizData source) : this(source.Id, source.Question, source.Choices, source.AnswerNumber)
        {

        }

        public QuizResponseModel(string id, string question, List<string> choices, int answerNumber)
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
