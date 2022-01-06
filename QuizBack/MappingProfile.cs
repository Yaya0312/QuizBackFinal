using AutoMapper;
using QuizBack.Dto;
using QuizBack.Entities;

namespace QuizBack
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Quiz, QuizDto>().ReverseMap();
            CreateMap<Quiz, QuizWithQuestionsDto>().ReverseMap();
        }
    }
}