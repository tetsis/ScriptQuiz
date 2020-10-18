using EntityFrameworkInfrastructure.Contexts;
using EntityFrameworkInfrastructure.Quizzes;
using EntityFrameworkInfrastructure.Scripts;
using Microsoft.EntityFrameworkCore;
using Prism.Ioc;
using ScriptQuizCore.Domain.Quizzes;
using ScriptQuizCore.Domain.Scripts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Internal;
using System.Text;
using Unity;

namespace ScriptQuizWPF.Config.Dependency
{
    public class EntityFrameworkModuleDependencySetup : IDependencySetup
    {
        public void Run(IContainerRegistry containerRegistry)
        {
            var builder = new DbContextOptionsBuilder<ScriptQuizDbContext>();
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            builder.UseSqlServer(connectionString);
            var options = builder.Options;
            var context = new ScriptQuizDbContext(options);

            containerRegistry.RegisterInstance<IScriptRepository>(new EntityFrameworkScriptRepository(context));
            containerRegistry.RegisterInstance<IQuizRepository>(new EntityFrameworkQuizRepository(context));
        }
    }
}
