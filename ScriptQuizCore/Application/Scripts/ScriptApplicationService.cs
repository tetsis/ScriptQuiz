using ScriptQuizCore.Application.Scripts.Commons;
using ScriptQuizCore.Application.Scripts.Create;
using ScriptQuizCore.Application.Scripts.Delete;
using ScriptQuizCore.Application.Scripts.GetAll;
using ScriptQuizCore.Domain.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ScriptQuizCore.Application.Scripts
{
    public class ScriptApplicationService : IScriptApplicationService
    {
        private readonly IScriptRepository scriptRepository;

        public ScriptApplicationService(IScriptRepository scriptRepository)
        {
            this.scriptRepository = scriptRepository;
        }

        public ScriptGetAllResult GetAll()
        {
            var scripts = scriptRepository.FindAll();
            var scriptModels = scripts.Select(x => new ScriptData(x)).ToList();

            return new ScriptGetAllResult(scriptModels);
        }

        public ScriptCreateResult Create(ScriptCreateCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var content = command.Content;
                var section = command.Section;

                var script = new Script(content, section);

                scriptRepository.Save(script);

                transaction.Complete();

                return new ScriptCreateResult(script.Id);
            }
        }

        public void Delete(ScriptDeleteCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var id = command.Id;
                var script = scriptRepository.Find(id);
                if (script == null) return;

                scriptRepository.Delete(script);

                transaction.Complete();
            }
        }
    }
}
