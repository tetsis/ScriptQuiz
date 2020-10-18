using Prism.Commands;
using Prism.Mvvm;
using ScriptQuizCore.Application.Quizzes;
using ScriptQuizCore.Application.Quizzes.Answer;
using ScriptQuizCore.Application.Quizzes.Get;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using System.Text;
using System.Windows.Data;

namespace ScriptQuizWPF.ViewModels
{
    class QuizUserControlViewModel : BindableBase
    {
        private readonly IQuizApplicationService quizApplicationService;

        public QuizUserControlViewModel(IQuizApplicationService quizApplicationService)
        {
            this.quizApplicationService = quizApplicationService;

            StartQuizCommand = new DelegateCommand(StartQuiz);

            SelectChoiceCommand = new DelegateCommand(SelectChoice);

            AnswerCommand = new DelegateCommand(Answer);
        }

        private string id;

        public DelegateCommand StartQuizCommand { get; }
        private void StartQuiz()
        {
            var quizCreateResult = quizApplicationService.Create();
            id = quizCreateResult.CreatedQuizId;

            var command = new QuizGetCommand(id);
            var quizGetResult = quizApplicationService.Get(command);
            var quiz = quizGetResult.Quiz;

            Question = quiz.Question;
            Choices = quiz.Choices;

            IsChecked0 = false;
            IsChecked1 = false;
            IsChecked2 = false;
            IsChecked3 = false;
            CanAnswer = false;
            Correct = "";
        }

        private string _question;
        public string Question
        {
            get { return _question; }
            set { SetProperty(ref _question, value); }
        }

        private List<string> _choices;
        public List<string> Choices
        {
            get { return _choices; }
            set { SetProperty(ref _choices, value); }
        }

        private int _choiceNumber;
        public int ChoiceNumber
        {
            get { return _choiceNumber; }
            set { SetProperty(ref _choiceNumber, value); }
        }

        private bool _isChecked0;
        public bool IsChecked0
        {
            get { return _isChecked0; }
            set { SetProperty(ref _isChecked0, value); }
        }

        private bool _isChecked1;
        public bool IsChecked1
        {
            get { return _isChecked1; }
            set { SetProperty(ref _isChecked1, value); }
        }

        private bool _isChecked2;
        public bool IsChecked2
        {
            get { return _isChecked2; }
            set { SetProperty(ref _isChecked2, value); }
        }

        private bool _isChecked3;
        public bool IsChecked3
        {
            get { return _isChecked3; }
            set { SetProperty(ref _isChecked3, value); }
        }

        private bool _canAnswer = false;
        public bool CanAnswer
        {
            get { return _canAnswer; }
            set { SetProperty(ref _canAnswer, value); }
        }

        public DelegateCommand SelectChoiceCommand { get; }
        private void SelectChoice()
        {
            CanAnswer = true;
        }

        private string _correct;
        public string Correct
        {
            get { return _correct; }
            set { SetProperty(ref _correct, value); }
        }

        public DelegateCommand AnswerCommand { get; }
        private void Answer()
        {
            int choiceNumber = -1;
            if (IsChecked0) choiceNumber = 0;
            else if (IsChecked1) choiceNumber = 1;
            else if (IsChecked2) choiceNumber = 2;
            else if (IsChecked3) choiceNumber = 3;

            var command = new QuizAnswerCommand(id, choiceNumber);
            var result = quizApplicationService.Answer(command);
            var isCorrect = result.IsCorrect;

            if (isCorrect)
            {
                Correct = "Correct!!";
            }
            else
            {
                Correct = "Incorrect";
            }
        }
    }
}
