using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizBack.Entities
{
    public class Quiz : Entity
    {
        public string Title { get; set; }
        
        public string Password { get; set; }
        
        [Required]
        [DefaultValue(false)]
        public bool IsPublished { get; set; }
        
        public int Rating { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new Collection<Question>();
    }
}