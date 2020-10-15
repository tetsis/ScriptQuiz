using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Scripts.Create
{
    public class ScriptCreateCommand
    {
        public ScriptCreateCommand(string content, string section)
        {
            Content = content;
            Section = section;
        }

        public string Content { get; }
        public string Section { get; }
    }
}
