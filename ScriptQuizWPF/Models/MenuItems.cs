using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizWPF.Models
{
    class MenuItems : List<MenuItem>
    {
        public MenuItems()
        {
            this.Add(new MenuItem { Icon = "BookOpenVariant", Page = "ScriptUserControl", Text = "Script" });
            this.Add(new MenuItem { Icon = "CommentQuestionOutline", Page = "QuizUserControl", Text = "Quiz" });
        }
    }
}
