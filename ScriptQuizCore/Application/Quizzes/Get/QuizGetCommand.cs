using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Quizzes.Get
{
    public class QuizGetCommand
    {
        public QuizGetCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
