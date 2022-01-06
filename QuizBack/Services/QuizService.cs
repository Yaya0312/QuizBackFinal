using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using QuizBack.Entities;
using QuizBack.Repositories;

namespace QuizBack.Services
{
    public class QuizService : CrudService<Quiz>, IQuizService
    {
        private readonly IQuizRepository _repository;

        public QuizService(IQuizRepository repository) : base(repository)
        {
            _repository = repository;
        }
        
        public bool CanAccess(object id, string password)
        {
            var quiz = _repository.GetById(id);
            return quiz == null || quiz.Password == password;
        }

        public bool IsPublished(object id)
        {
            var quiz = _repository.GetById(id);
            return quiz.IsPublished;
        }
    }
}
