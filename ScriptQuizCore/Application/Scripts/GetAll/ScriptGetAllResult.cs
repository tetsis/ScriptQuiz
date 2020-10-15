using ScriptQuizCore.Application.Scripts.Commons;
using ScriptQuizCore.Domain.Scripts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Scripts.GetAll
{
    public class ScriptGetAllResult
    {
        public ScriptGetAllResult(List<ScriptData> scripts)
        {
            Scripts = scripts;
        }

        public List<ScriptData> Scripts { get; }
    }
}
