using EntityFrameworkInfrastructure.Contexts;
using EntityFrameworkInfrastructure.Quizzes;
using EntityFrameworkInfrastructure.Scripts;
using InMemoryInfrastructure.Quizzes;
using InMemoryInfrastructure.Scripts;
using Microsoft.EntityFrameworkCore;
using Prism.Ioc;
using ScriptQuizCore.Domain.Quizzes;
using ScriptQuizCore.Domain.Scripts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ScriptQuizWPF.Config.Dependency
{
    public class DependencySetupFactory
    {
        public IDependencySetup CreateSetup()
        {
            var infrastructure = ConfigurationManager.AppSettings["Infractructure"];
            if (infrastructure == "InMemory")
            {
                return new InMemoryModuleDependencySetup();
            }
            else if (infrastructure == "EntityFramework")
            {
                return new EntityFrameworkModuleDependencySetup();
            }
            else
            {
                throw new NotSupportedException(infrastructure + " is not registerd.");
            }

        }
    }
}
