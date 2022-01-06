using QuizBack.Entities;

namespace QuizBack.Services
{
    public interface IQuizService : ICrudService<Quiz>
    {
        /**
         * Returns true if the password is correct
         */
        public bool CanAccess(object id, string password);

        public bool IsPublished(object id);
    }
}