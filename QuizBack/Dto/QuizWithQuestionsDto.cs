using System.Collections.Generic;
using QuizBack.Entities;

namespace QuizBack.Dto
{
    public class QuizWithQuestionsDto : QuizDto
    {
        public IList<Question> Questions { get; set; } = new List<Question>();
    }
}