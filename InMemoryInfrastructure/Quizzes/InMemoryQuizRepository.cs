using InMemoryInfrastructure.Commons;
using ScriptQuizCore.Domain.Quizzes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InMemoryInfrastructure.Quizzes
{
    public class InMemoryQuizRepository : InMemoryCrudRepository<string, Quiz>, IQuizRepository
    {
        protected override string GetKey(Quiz value)
        {
            return value.Id;
        }

        protected override Quiz DeepClone(Quiz value)
        {
            return new Quiz(
                value.Id,
                value.Question,
                value.Choices,
                value.AnswerNumber
            );
        }
    }
}
