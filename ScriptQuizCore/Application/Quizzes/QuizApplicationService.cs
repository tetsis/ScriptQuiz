using ScriptQuizCore.Application.Quizzes.Answer;
using ScriptQuizCore.Application.Quizzes.Commons;
using ScriptQuizCore.Application.Quizzes.Create;
using ScriptQuizCore.Application.Quizzes.Get;
using ScriptQuizCore.Domain.Quizzes;
using ScriptQuizCore.Domain.Scripts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace ScriptQuizCore.Application.Quizzes
{
    public class QuizApplicationService : IQuizApplicationService
    {
        private readonly IQuizRepository quizRepository;
        private readonly IScriptRepository scriptRepository;

        public QuizApplicationService(IQuizRepository quizRepository, IScriptRepository scriptRepository)
        {
            this.quizRepository = quizRepository;
            this.scriptRepository = scriptRepository;
        }

        public QuizGetResult Get(QuizGetCommand command)
        {
            var id = command.Id;
            var quiz = quizRepository.Find(id);
            if (quiz == null) {
                throw new QuizNotFoundException(id, "クイズが見つかりませんでした。");
            }

            return new QuizGetResult(new QuizData(quiz));
        }

        public QuizCreateResult Create()
        {
            using (var transaction = new TransactionScope())
            {
                var scripts = scriptRepository.FindAll();

                var quiz = new Quiz(scripts);

                quizRepository.Save(quiz);

                return new QuizCreateResult(quiz.Id);
            }
        }

        public QuizAnswerResult Answer(QuizAnswerCommand command)
        {
            var id = command.Id;
            var choiceNumber = command.ChoiceNumber;

            var quiz = quizRepository.Find(id);

            return new QuizAnswerResult(choiceNumber == quiz.AnswerNumber);
        }
    }
}
