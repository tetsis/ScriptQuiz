using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Quizzes.Answer
{
    public class QuizAnswerCommand
    {
        public QuizAnswerCommand(string id, int choiceNumber)
        {
            Id = id;
            ChoiceNumber = choiceNumber;
        }

        public string Id { get; }
        public int ChoiceNumber { get; }
    }
}
