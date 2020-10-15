using ScriptQuizCore.Domain.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptQuizCore.Domain.Quizzes
{
    public class Quiz
    {
        public Quiz(List<Script> scripts)
        {
            if (scripts.Count < 4) throw new ArgumentException("スクリプトは少なくとも4つ必要です。", nameof(scripts));

            // スクリプトからランダムに4つ選ぶ
            var elementNumbers = Enumerable.Range(0, scripts.Count).ToList();
            var fourShuffledElementNumbers = elementNumbers.OrderBy(a => Guid.NewGuid()).Take(4);
            var fourScripts = new List<Script>();
            foreach (var shuffledElementNumber in fourShuffledElementNumbers) {
                fourScripts.Add(scripts[shuffledElementNumber]);
            }
            var choices = fourScripts.Select(s => s.Section).ToList();

            // 正解の問題を決める
            Random r = new System.Random();
            var answerNumber = r.Next(0, 4);
            var question = fourScripts[answerNumber].Content;

            Id = Guid.NewGuid().ToString();
            Question = question;
            Choices = choices;
            AnswerNumber = answerNumber;
        }

        public Quiz(string id, string question, List<string> choices, int answerNumber)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (question == null) throw new ArgumentNullException(nameof(question));
            if (choices == null) throw new ArgumentNullException(nameof(choices));
            if (choices.Count != 4) throw new ArgumentException("選択肢は4つです。", nameof(choices));
            if (answerNumber < 0 || answerNumber > 3) throw new ArgumentException("正解の値は0から3の間の整数です。", nameof(answerNumber));

            Id = id;
            Question = question;
            Choices = choices;
            AnswerNumber = answerNumber;
        }

        public string Id { get; }
        public string Question { get; }
        public List<string> Choices { get; }
        public int AnswerNumber { get; }

        public bool Answer(int answerNumberOfAnswerer)
        {

            return answerNumberOfAnswerer == AnswerNumber;
        }
    }
}
