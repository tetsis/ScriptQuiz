using ScriptQuizCore.Application.Scripts.Create;
using ScriptQuizCore.Application.Scripts.Delete;
using ScriptQuizCore.Application.Scripts.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Scripts
{
    public interface IScriptApplicationService
    {
        ScriptGetAllResult GetAll();
        ScriptCreateResult Create(ScriptCreateCommand command);
        void Delete(ScriptDeleteCommand command);
    }
}
