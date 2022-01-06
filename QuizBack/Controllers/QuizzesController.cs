using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizBack.Dto;
using QuizBack.Entities;
using QuizBack.Services;

namespace QuizBack.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly IMapper _mapper;

        public QuizzesController(IQuizService quizService, IMapper mapper)
        {
            _quizService = quizService;
            _mapper = mapper;
        }

        // GET: api/Quizzes
        [HttpGet]
        public ActionResult<IEnumerable<QuizDto>> GetQuizzes()
        { 
            var quizzes = _quizService.GetAll().ToList();
            return _mapper.Map<List<QuizDto>>(quizzes);
        }

        // GET: api/Quizzes/1445-1145-1235
        [HttpGet("{id}")]
        public ActionResult<QuizWithQuestionsDto> GetQuiz(Guid id, string password)
        {
            if (!_quizService.IsPublished(id) && !_quizService.CanAccess(id, password)) return Unauthorized();
            var quiz = _quizService.GetById(id);
            if (quiz == null)
            { 
                return NotFound();
            }
            return _mapper.Map<QuizWithQuestionsDto>(quiz);
        }

        // PUT: api/Quizzes/5
        [HttpPut("{id}")]
        public ActionResult<QuizWithQuestionsDto> PutQuiz(Guid id, Quiz quiz, string password)
        {
            if (id != quiz.Id)
            {
                return BadRequest();
            }
            if (!_quizService.CanAccess(id, password))
            {
                return Unauthorized();
            }
            _quizService.Update(quiz);
            return _mapper.Map<QuizWithQuestionsDto>(quiz);
        }
        // POST: api/Quizs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<QuizWithQuestionsDto> PostQuiz(Quiz quiz)
        {
            _quizService.Create(quiz);
            var quizDto = _mapper.Map<QuizWithQuestionsDto>(quiz);
            return CreatedAtAction("GetQuiz", new { id = quiz.Id }, quizDto);
        }

        // DELETE: api/Quizs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteQuiz(Guid id, string password)
        {
            var quiz = _quizService.GetById(id);
            if (quiz == null)
            {
                return NotFound();
            }
            if (!_quizService.CanAccess(id, password))
            {
                return Unauthorized();
            }
            _quizService.Delete(id);
            return NoContent();
        }
    }
}
