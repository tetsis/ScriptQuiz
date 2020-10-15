using EntityFrameworkInfrastructure.Contexts;
using EntityFrameworkInfrastructure.Quizzes;
using EntityFrameworkInfrastructure.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public class EntityFrameworkModuleDependencySetup : IDependencySetup
    {
        private readonly IConfiguration configuration;

        public EntityFrameworkModuleDependencySetup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Run(IServiceCollection services)
        {
            var builder = new DbContextOptionsBuilder<ScriptQuizDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            var options = builder.Options;
            var context = new ScriptQuizDbContext(options);

            services.AddSingleton<IScriptRepository>(sp => new EntityFrameworkScriptRepository(context));
            services.AddTransient<IScriptApplicationService, ScriptApplicationService>();

            services.AddSingleton<IQuizRepository>(sp => new EntityFrameworkQuizRepository(context));
            services.AddTransient<IQuizApplicationService, QuizApplicationService>();
        }
    }
}
