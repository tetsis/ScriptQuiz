using Prism.Mvvm;
using Prism.Regions;
using ScriptQuizWPF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizWPF.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(Views.ScriptUserControl));
        }

        private string _title = "ScriptQuizWPF";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly IRegionManager _regionManager;

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
        }

        public MenuItems MenuItems { get; } = new MenuItems();

        private MenuItem _selectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                if (!SetProperty(ref _selectedMenuItem, value))
                {
                    return;
                }

                this.Navigate(this.SelectedMenuItem.Page);
            }
        }
    }
}
