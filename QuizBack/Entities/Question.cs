using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuizBack.Entities
{
    public class Question : Entity
    {
        public string Title { get; set; }

        public virtual ICollection<Answer> Answers { get; set; } = new Collection<Answer>();

        public string Type { get; set; } = "text";
    }
}