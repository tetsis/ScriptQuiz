using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScriptQuizCore.Application.Scripts;
using ScriptQuizCore.Application.Scripts.Create;
using ScriptQuizCore.Application.Scripts.Delete;
using ScriptQuizWeb.ViewModels.Scripts.Commons;
using ScriptQuizWeb.ViewModels.Scripts.Create;

namespace ScriptQuizWeb.Controllers
{
    public class ScriptController : Controller
    {
        private readonly IScriptApplicationService scriptApplicationService;

        public ScriptController(IScriptApplicationService scriptApplicationService)
        {
            this.scriptApplicationService = scriptApplicationService;
        }

        // GET: ScriptController
        public ActionResult Index()
        {
            var result = scriptApplicationService.GetAll();
            var scripts = result.Scripts.Select(x => new ScriptResponseModel(x.Id, x.Content, x.Section)).ToList();
            return View(scripts);
        }

        // GET: ScriptController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ScriptController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScriptController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, ScriptCreateRequestModel scriptCreateRequestModel)
        {
            try
            {
                var content = scriptCreateRequestModel.Content;
                var section = scriptCreateRequestModel.Section;
                var command = new ScriptCreateCommand(content, section);
                scriptApplicationService.Create(command);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ScriptController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScriptController/Edit/5
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

        // GET: ScriptController/Delete/5
        public ActionResult Delete(string id)
        {
            var command = new ScriptDeleteCommand(id);
            scriptApplicationService.Delete(command);
            return RedirectToAction(nameof(Index));
        }

        // POST: ScriptController/Delete/5
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
