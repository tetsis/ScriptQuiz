using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptQuizCore.Domain.Quizzes
{
    public interface IQuizRepository
    {
        Quiz Find(string id);
        void Save(Quiz quiz);
    }
}
