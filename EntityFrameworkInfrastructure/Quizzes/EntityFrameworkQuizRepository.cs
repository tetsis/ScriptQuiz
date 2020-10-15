using EntityFrameworkInfrastructure.Contexts;
using EntityFrameworkInfrastructure.DataModels;
using ScriptQuizCore.Domain.Quizzes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EntityFrameworkInfrastructure.Quizzes
{
    public class EntityFrameworkQuizRepository : IQuizRepository
    {
        private readonly ScriptQuizDbContext context;

        public EntityFrameworkQuizRepository(ScriptQuizDbContext context)
        {
            this.context = context;
        }

        public Quiz Find(string id)
        {
            var target = context.Quizzes.Find(id);
            if (target == null)
            {
                return null;
            }

            return ToModel(target);
        }

        public void Save(Quiz quiz)
        {
            var data = ToDataModel(quiz);
            context.Quizzes.Add(data);

            context.SaveChanges();
        }

        private Quiz ToModel(QuizDataModel from)
        {
            var choices = new List<string>
            {
                from.Choice1,
                from.Choice2,
                from.Choice3,
                from.Choice4,
            };

            return new Quiz(
                from.Id,
                from.Question,
                choices,
                from.AnswerNumber
            );
        }

        private QuizDataModel ToDataModel(Quiz from)
        {
            return new QuizDataModel
            {
                Id = from.Id,
                Question = from.Question,
                Choice1 = from.Choices[0],
                Choice2 = from.Choices[1],
                Choice3 = from.Choices[2],
                Choice4 = from.Choices[3],
                AnswerNumber = from.AnswerNumber
            };
        }
    }
}
