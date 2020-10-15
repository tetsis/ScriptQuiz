using ScriptQuizCore.Application.Quizzes.Answer;
using ScriptQuizCore.Application.Quizzes.Create;
using ScriptQuizCore.Application.Quizzes.Get;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Quizzes
{
    public interface IQuizApplicationService
    {
        QuizGetResult Get(QuizGetCommand command);
        QuizCreateResult Create();
        QuizAnswerResult Answer(QuizAnswerCommand command);
    }
}
