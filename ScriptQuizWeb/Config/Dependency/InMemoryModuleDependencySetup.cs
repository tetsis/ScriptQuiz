using InMemoryInfrastructure.Quizzes;
using InMemoryInfrastructure.Scripts;
using Microsoft.Extensions.DependencyInjection;
using ScriptQuizCore.Application.Quizzes;
using ScriptQuizCore.Application.Scripts;
using ScriptQuizCore.Domain.Quizzes;
using ScriptQuizCore.Domain.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptQuizWeb.Config.Dependency
{
    public class InMemoryModuleDependencySetup : IDependencySetup
    {
        public void Run(IServiceCollection services)
        {
            services.AddSingleton<IScriptRepository, InMemoryScriptRepository>();
            services.AddTransient<IScriptApplicationService, ScriptApplicationService>();

            services.AddSingleton<IQuizRepository, InMemoryQuizRepository>();
            services.AddTransient<IQuizApplicationService, QuizApplicationService>();
        }
    }
}
