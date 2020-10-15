using EntityFrameworkInfrastructure.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkInfrastructure.Contexts
{
    public class ScriptQuizDbContext : DbContext
    {
        public ScriptQuizDbContext(DbContextOptions<ScriptQuizDbContext> options) : base(options)
        {

        }

        public DbSet<ScriptDataModel> Scripts { get; set; }
        public DbSet<QuizDataModel> Quizzes { get; set; }
    }
}
