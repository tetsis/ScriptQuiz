using InMemoryInfrastructure.Commons;
using ScriptQuizCore.Domain.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InMemoryInfrastructure.Scripts
{
    public class InMemoryScriptRepository : InMemoryCrudRepository<string, Script>, IScriptRepository
    {
        protected override string GetKey(Script value)
        {
            return value.Id;
        }

        protected override Script DeepClone(Script value)
        {
            return new Script(
                value.Id,
                value.Content,
                value.Section
            );
        }

        public List<Script> FindAll()
        {
            return Db.Values
                .Select(DeepClone)
                .ToList();
        }
    }
}
