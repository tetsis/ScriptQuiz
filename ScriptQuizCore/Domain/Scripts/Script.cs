using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ScriptQuizCore.Domain.Scripts
{
    public class Script
    {
        public Script(string content, string section)
        {
            if (content == null) throw new ArgumentNullException(nameof(content));
            if (section == null) throw new ArgumentNullException(nameof(section));

            Id = Guid.NewGuid().ToString();
            Content = content;
            Section = section;
        }

        public Script(string id, string content, string section)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (content == null) throw new ArgumentNullException(nameof(content));
            if (section == null) throw new ArgumentNullException(nameof(section));

            Id = id;
            Content = content;
            Section = section;
        }

        public string Id { get; }
        public string Content { get; }
        public string Section { get; }
    }
}
