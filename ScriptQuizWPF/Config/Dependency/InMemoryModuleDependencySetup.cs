using InMemoryInfrastructure.Quizzes;
using InMemoryInfrastructure.Scripts;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using ScriptQuizCore.Application.Quizzes;
using ScriptQuizCore.Application.Scripts;
using ScriptQuizCore.Domain.Quizzes;
using ScriptQuizCore.Domain.Scripts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizWPF.Config.Dependency
{
    public class InMemoryModuleDependencySetup : IDependencySetup
    {
        public void Run(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IScriptRepository, InMemoryScriptRepository>();
            containerRegistry.RegisterSingleton<IQuizRepository, InMemoryQuizRepository>();
        }
    }
}
