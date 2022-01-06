using System;

namespace QuizBack.Dto
{
    public class QuizDto
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public bool IsPublished { get; set; }
        
        public int Rating { get; set; }
    }
}