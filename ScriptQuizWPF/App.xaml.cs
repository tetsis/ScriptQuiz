using InMemoryInfrastructure.Quizzes;
using InMemoryInfrastructure.Scripts;
using Prism.Ioc;
using ScriptQuizCore.Application.Quizzes;
using ScriptQuizCore.Application.Scripts;
using ScriptQuizCore.Domain.Quizzes;
using ScriptQuizCore.Domain.Scripts;
using ScriptQuizWPF.Config.Dependency;
using ScriptQuizWPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ScriptQuizWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Views.MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ScriptUserControl>();
            containerRegistry.RegisterForNavigation<QuizUserControl>();

            var factory = new DependencySetupFactory();
            var setup = factory.CreateSetup();
            setup.Run(containerRegistry);

            containerRegistry.Register<IScriptApplicationService, ScriptApplicationService>();
            containerRegistry.Register<IQuizApplicationService, QuizApplicationService>();
        }
    }
}
