using ScriptQuizCore.Application.Scripts.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptQuizWeb.ViewModels.Scripts.Commons
{
    public class ScriptResponseModel
    {
        public ScriptResponseModel(ScriptData source) : this(source.Id, source.Content, source.Section)
        {

        }

        public ScriptResponseModel(string id, string content, string section)
        {
            Id = id;
            Content = content;
            Section = section;
        }

        public string Id { get; }
        public string Content { get; }
        public string Section { get; }
    }
}
