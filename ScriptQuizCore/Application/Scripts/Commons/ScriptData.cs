using ScriptQuizCore.Domain.Scripts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Scripts.Commons
{
    public class ScriptData
    {
        public ScriptData(Script script) : this(script.Id, script.Content, script.Section)
        {

        }

        public ScriptData(string id, string content, string section)
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
