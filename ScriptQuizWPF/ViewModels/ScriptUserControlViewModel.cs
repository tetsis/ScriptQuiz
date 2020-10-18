using MaterialDesignColors.Recommended;
using Microsoft.EntityFrameworkCore.Internal;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Unity;
using ScriptQuizCore.Application.Scripts;
using ScriptQuizCore.Application.Scripts.Create;
using ScriptQuizCore.Application.Scripts.Delete;
using ScriptQuizWPF.ViewModels.Scripts.Commons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ScriptQuizWPF.ViewModels
{
    class ScriptUserControlViewModel : BindableBase
    {
        private readonly IScriptApplicationService scriptApplicationService;

        public ScriptUserControlViewModel(IScriptApplicationService scriptApplicationService)
        {
            this.scriptApplicationService = scriptApplicationService;

            ReloadScripts();

            PlusCommand = new DelegateCommand(Plus);
            ReloadScriptsCommand = new DelegateCommand(ReloadScripts);

            AddScriptCommand = new DelegateCommand(AddScript);
            CancelAddScriptCommand = new DelegateCommand(CancelAddScript);

            SelectRowCommand = new DelegateCommand(SelectRow);

            DeleteScriptCommand = new DelegateCommand(DeleteScript);
            CancelEditScriptCommand = new DelegateCommand(CancelEditScript);
        }

        private ObservableCollection<ScriptResponseModel> _scripts;
        public ObservableCollection<ScriptResponseModel> Scripts
        {
            get { return _scripts; }
            set { SetProperty(ref _scripts, value); }
        }

        private ScriptResponseModel _selectedScript;
        public ScriptResponseModel SelectedScript
        {
            get { return _selectedScript; }
            set { SetProperty(ref _selectedScript, value); }
        }

        private bool _addMode = false;
        public bool AddMode
        {
            get { return _addMode; }
            set {
                if (!value)
                {
                    NewSection = "";
                    NewContent = "";
                }
                SetProperty(ref _addMode, value);
            }
        }

        private bool _editMode = false;
        public bool EditMode
        {
            get { return _editMode; }
            set {
                if (!value)
                {
                    EditSection = "";
                    EditContent = "";
                }
                SetProperty(ref _editMode, value);
            }
        }

        public DelegateCommand PlusCommand { get; }
        private void Plus()
        {
            AddMode = true;
        }

        public DelegateCommand ReloadScriptsCommand { get; }
        private void ReloadScripts()
        {
            AddMode = false;
            EditMode = false;

            var result = scriptApplicationService.GetAll();

            var scripts = new List<ScriptResponseModel>(result.Scripts.Select(x => new ScriptResponseModel(x.Id, x.Content, x.Section)).ToList());
            Scripts = new ObservableCollection<ScriptResponseModel>(scripts);
        }

        private string _newSection;
        public string NewSection
        {
            get { return _newSection; }
            set { SetProperty(ref _newSection, value); }
        }

        private string _newContent;
        public string NewContent
        {
            get { return _newContent; }
            set { SetProperty(ref _newContent, value); }
        }

        private string _editSection;
        public string EditSection
        {
            get { return _editSection; }
            set { SetProperty(ref _editSection, value); }
        }

        private string _editContent;
        public string EditContent
        {
            get { return _editContent; }
            set { SetProperty(ref _editContent, value); }
        }

        public DelegateCommand AddScriptCommand { get; }
        private void AddScript()
        {
            var command = new ScriptCreateCommand(NewContent, NewSection);
            scriptApplicationService.Create(command);
            AddMode = false;
            ReloadScripts();
        }

        public DelegateCommand CancelAddScriptCommand { get; }
        private void CancelAddScript()
        {
            AddMode = false;
        }

        public DelegateCommand SelectRowCommand { get; }
        private void SelectRow()
        {
            if (SelectedScript == null) return;

            EditSection = SelectedScript.Section;
            EditContent = SelectedScript.Content;
            EditMode = true;
        }

        public DelegateCommand DeleteScriptCommand { get; }
        private void DeleteScript()
        {
            var command = new ScriptDeleteCommand(SelectedScript.Id);
            scriptApplicationService.Delete(command);
            EditMode = false;
            ReloadScripts();
        }

        public DelegateCommand CancelEditScriptCommand { get; }
        private void CancelEditScript()
        {
            EditMode = false;
            ReloadScripts();
        }
    }
}
