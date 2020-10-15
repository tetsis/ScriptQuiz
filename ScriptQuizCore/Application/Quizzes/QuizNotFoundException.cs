using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Quizzes
{
    public class QuizNotFoundException : Exception
    {
        public QuizNotFoundException(string id)
        {
            Id = id;
        }

        public QuizNotFoundException(string id, string message) : base(message)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
