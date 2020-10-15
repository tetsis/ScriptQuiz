using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Scripts.Create
{
    public class ScriptCreateResult
    {
        public ScriptCreateResult(string createdScriptId)
        {
            CreatedScriptId = createdScriptId;
        }

        public string CreatedScriptId { get; }
    }
}
