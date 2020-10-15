using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptQuizWeb.Config.Dependency
{
    public class DependencySetupFactory
    {
        public IDependencySetup CreateSetup(IConfiguration configuration)
        {
            var setupName = configuration["Dependency:SetupName"];
            switch (setupName)
            {
                case nameof(InMemoryModuleDependencySetup):
                    return new InMemoryModuleDependencySetup();
                case nameof(EntityFrameworkModuleDependencySetup):
                    return new EntityFrameworkModuleDependencySetup(configuration);
                default:
                    throw new NotSupportedException(setupName + "is not registerd.");
            }
        }
    }
}
