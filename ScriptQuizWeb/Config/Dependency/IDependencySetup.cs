using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptQuizWeb.Config.Dependency
{
    public interface IDependencySetup
    {
        void Run(IServiceCollection services);
    }
}
