using Microsoft.EntityFrameworkCore;
using QuizBack.Entities;

namespace QuizBack
{
    public class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //Quiz
            modelBuilder.Entity<Quiz>()
                .HasData(
                    new Quiz { Password = "react", Title = "react", IsPublished = false, Questions =
                    {
                        new Question
                        {
                            Title = "Qui à crée React",
                            Answers =
                            {
                                new Answer
                                {
                                    IsValid = true,
                                    Title = "Facebook"
                                },
                                new Answer
                                {
                                    IsValid = false,
                                    Title = "Google"
                                },
                                new Answer
                                {
                                    IsValid = false,
                                    Title = "Apple"
                                },
                                new Answer
                                {
                                    IsValid = false,
                                    Title = "Microsoft"
                                }
                            }
                        }
                    }
                        
                    }
                );
        }
    }
}
