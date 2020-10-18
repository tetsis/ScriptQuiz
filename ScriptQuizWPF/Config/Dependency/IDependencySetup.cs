using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizWPF.Config.Dependency
{
    public interface IDependencySetup
    {
        void Run(IContainerRegistry containerRegistry);
    }
}
