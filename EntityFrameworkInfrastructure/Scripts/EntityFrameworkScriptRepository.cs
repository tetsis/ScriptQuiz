using EntityFrameworkInfrastructure.Contexts;
using EntityFrameworkInfrastructure.DataModels;
using ScriptQuizCore.Domain.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkInfrastructure.Scripts
{
    public class EntityFrameworkScriptRepository : IScriptRepository
    {
        private readonly ScriptQuizDbContext context;

        public EntityFrameworkScriptRepository(ScriptQuizDbContext context)
        {
            this.context = context;
        }

        public void Delete(Script script)
        {
            var target = context.Scripts.Find(script.Id);

            if (target == null)
            {
                return;
            }

            context.Scripts.Remove(target);

            context.SaveChanges();
        }

        public Script Find(string id)
        {
            var target = context.Scripts.Find(id);
            if (target == null)
            {
                return null;
            }

            return ToModel(target);
        }

        public List<Script> FindAll()
        {
            return context.Scripts.Select(ToModel).ToList();
        }

        public void Save(Script script)
        {
            var found = context.Scripts.Find(script.Id);

            if (found == null)
            {
                var data = ToDataModel(script);
                context.Scripts.Add(data);
            }
            else
            {
                var data = Transfer(script, found);
                context.Scripts.Update(data);

            }

            context.SaveChanges();
        }

        private Script ToModel(ScriptDataModel from)
        {
            return new Script(
                from.Id,
                from.Content,
                from.Section
            );
        }

        private ScriptDataModel ToDataModel(Script from)
        {
            return new ScriptDataModel
            {
                Id = from.Id,
                Section = from.Section,
                Content = from.Content
            };

        }

        private ScriptDataModel Transfer(Script from, ScriptDataModel model)
        {
            model.Id = from.Id;
            model.Section = from.Section;
            model.Content = from.Content;

            return model;
        }
    }
}
