using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScriptQuizCore.Application.Quizzes;
using ScriptQuizCore.Application.Quizzes.Answer;
using ScriptQuizCore.Application.Quizzes.Get;
using ScriptQuizCore.Domain.Quizzes;
using ScriptQuizWeb.ViewModels.Quizzes.Answer;
using ScriptQuizWeb.ViewModels.Quizzes.Commons;

namespace ScriptQuizWeb.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizApplicationService quizApplicationService;

        public QuizController(IQuizApplicationService quizApplicationService)
        {
            this.quizApplicationService = quizApplicationService;
        }

        // GET: QuizController
        public ActionResult Index()
        {
            return View();
        }

        // GET: QuizController/Details/5
        public ActionResult Details(string id)
        {
            var command = new QuizGetCommand(id.ToString());
            var result = quizApplicationService.Get(command);
            var quiz = new QuizResponseModel(result.Quiz);
            return View(Tuple.Create(quiz, new QuizAnswerRequestModel()));
        }

        [HttpPost]
        public ActionResult Details(IFormCollection collection, string id, QuizAnswerRequestModel quizAnswerRequestModel)
        {
            var answerNumberOfAnswerer = quizAnswerRequestModel.AnswerNumberOfAnswerer;
            var command = new QuizAnswerCommand(id, answerNumberOfAnswerer);
            var result = quizApplicationService.Answer(command);
            var isCorrect = result.IsCorrect;
            return View("Answer", isCorrect);
        }

        // GET: QuizController/Create
        public ActionResult Create()
        {
            var result = quizApplicationService.Create();
            var id = result.CreatedQuizId;
            return RedirectToAction(nameof(Details), "Quiz", new {id = id});
        }

        // GET: QuizController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuizController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuizController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuizController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
