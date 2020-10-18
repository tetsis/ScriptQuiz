using ScriptQuizCore.Application.Scripts.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizWPF.ViewModels.Scripts.Commons
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

        public string Id { get; set; }
        public string Content { get; set; }
        public string Section { get; set; }
    }
}
