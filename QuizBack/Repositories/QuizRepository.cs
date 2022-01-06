using QuizBack.Entities;

namespace QuizBack.Repositories
{
    public class QuizRepository: CrudRepository<Quiz>, IQuizRepository
    {
        public QuizRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}