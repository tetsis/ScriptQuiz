using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizWPF.Models
{
    class MenuItem : BindableBase
    {
        private string _icon = "";
        public string Icon
        {
            get { return _icon; }
            set { SetProperty(ref _icon, value); }
        }

        private string _text = "";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private string _page = "";
        public string Page
        {
            get { return _page; }
            set { SetProperty(ref _page, value); }
        }
    }
}
