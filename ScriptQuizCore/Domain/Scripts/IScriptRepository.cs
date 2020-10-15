using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Domain.Scripts
{
    public interface IScriptRepository
    {
        List<Script> FindAll();
        Script Find(string id);
        void Save(Script script);
        void Delete(Script script);
    }
}
