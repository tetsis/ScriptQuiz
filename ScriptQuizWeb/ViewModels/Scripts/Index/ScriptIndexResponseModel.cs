using ScriptQuizWeb.ViewModels.Scripts.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptQuizWeb.ViewModels.Scripts.Index
{
    public class ScriptIndexResponseModel
    {
        public ScriptIndexResponseModel(List<ScriptResponseModel> scripts)
        {
            Scripts = scripts;
        }

        public List<ScriptResponseModel> Scripts { get; }
    }
}
