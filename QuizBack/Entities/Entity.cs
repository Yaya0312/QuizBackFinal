using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizBack.Entities
{
    public abstract class Entity {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
