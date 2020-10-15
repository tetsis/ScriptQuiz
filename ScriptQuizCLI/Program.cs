using EntityFrameworkInfrastructure.Contexts;
using EntityFrameworkInfrastructure.Quizzes;
using EntityFrameworkInfrastructure.Scripts;
using InMemoryInfrastructure.Quizzes;
using InMemoryInfrastructure.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScriptQuizCore.Application.Quizzes;
using ScriptQuizCore.Application.Quizzes.Answer;
using ScriptQuizCore.Application.Quizzes.Get;
using ScriptQuizCore.Application.Scripts;
using ScriptQuizCore.Application.Scripts.Create;
using ScriptQuizCore.Application.Scripts.GetAll;
using ScriptQuizCore.Domain.Quizzes;
using ScriptQuizCore.Domain.Scripts;
using System;
using System.Configuration;

namespace ScriptQuizCLI
{
    class Program
    {
        private static ServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Startup();
            var scriptApplicationService = serviceProvider.GetService<IScriptApplicationService>();
            var quizApplicationService = serviceProvider.GetService<IQuizApplicationService>();
            while (true)
            {
                Console.WriteLine("Select operation (cs: Create script / ls: Display script list / sq: Start quiz");
                Console.Write(">");
                var mode = Console.ReadLine();
                if (mode == "cs")
                {
                    Console.WriteLine("Input section");
                    Console.Write(">");
                    var section = Console.ReadLine();
                    Console.WriteLine("Input content");
                    Console.Write(">");
                    var content = Console.ReadLine();
                    var command = new ScriptCreateCommand(content, section);
                    scriptApplicationService.Create(command);
                    Console.WriteLine("--------");
                    Console.WriteLine("Script created.");
                    Console.WriteLine("--------");
                }
                else if (mode == "ls")
                {
                    var scripts = scriptApplicationService.GetAll();
                    Console.WriteLine("--------");
                    foreach (var script in scripts.Scripts)
                    {
                        Console.WriteLine("ID:" + script.Id + ", Section: " + script.Section + ", Content: " + script.Content);
                    }
                    Console.WriteLine("--------");
                }
                else if (mode == "sq")
                {
                    var quizCreateResult = quizApplicationService.Create();
                    var createdQuizId = quizCreateResult.CreatedQuizId;
                    var quizGetCommand = new QuizGetCommand(createdQuizId);
                    var quizGetResult = quizApplicationService.Get(quizGetCommand);
                    var quiz = quizGetResult.Quiz;
                    Console.WriteLine("--------");
                    Console.WriteLine("Question: " + quiz.Question);
                    Console.WriteLine("Choices: ");

                    int number = 1;
                    foreach (var choice in quiz.Choices)
                    {
                        Console.WriteLine(number.ToString() + ": " + choice);
                        number++;
                    }

                    while (true)
                    {
                        Console.WriteLine("--------");
                        Console.WriteLine("Input answer number");
                        Console.Write(">");
                        var answerNumberOfAnswerer = Console.ReadLine();
                        var quizAnswerCommand = new QuizAnswerCommand(createdQuizId, Int32.Parse(answerNumberOfAnswerer) - 1);
                        var quizAnswerResult = quizApplicationService.Answer(quizAnswerCommand);
                        var isCorrect = quizAnswerResult.IsCorrect;
                        if (isCorrect)
                        {
                            Console.WriteLine("Correct!!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect...");
                        }
                    }
                    Console.WriteLine("--------");
                }

                Console.WriteLine("continue? (y/n)");
                Console.Write(">");
                var yesOrNo = Console.ReadLine();
                if (yesOrNo == "n")
                {
                    break;
                }
            }
        }

        private static void Startup()
        {
            var serviceCollection = new ServiceCollection();

            var infrastructure = ConfigurationManager.AppSettings["Infractructure"];
            if (infrastructure == "InMemory")
            {
                serviceCollection.AddSingleton<IScriptRepository, InMemoryScriptRepository>();
                serviceCollection.AddSingleton<IQuizRepository, InMemoryQuizRepository>();
            }
            else if (infrastructure == "EntityFramework")
            {
                var builder = new DbContextOptionsBuilder<ScriptQuizDbContext>();
                var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                builder.UseSqlServer(connectionString);
                var options = builder.Options;
                var context = new ScriptQuizDbContext(options);

                serviceCollection.AddSingleton<IScriptRepository>(sp => new EntityFrameworkScriptRepository(context));
                serviceCollection.AddSingleton<IQuizRepository>(sp => new EntityFrameworkQuizRepository(context));
            }
            else
            {
                throw new NotSupportedException(infrastructure + " is not registerd.");
            }

            serviceCollection.AddTransient<IScriptApplicationService, ScriptApplicationService>();

            serviceCollection.AddTransient<IQuizApplicationService, QuizApplicationService>();

            serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
