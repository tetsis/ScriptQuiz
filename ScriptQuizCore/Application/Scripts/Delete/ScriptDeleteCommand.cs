using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Application.Scripts.Delete
{
    public class ScriptDeleteCommand
    {
        public ScriptDeleteCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
