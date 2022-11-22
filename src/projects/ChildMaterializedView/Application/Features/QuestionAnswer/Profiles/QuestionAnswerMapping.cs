using AutoMapper;
using Core.Tools.RabbitMQ.Messages.QuestionAnswer;
using QuestionAnswers = Domain.Entities.QuestionAnswer;


namespace Application.Features.QuestionAnswer.Profiles
{
    public class QuestionAnswerMapping:Profile
    {
        public QuestionAnswerMapping()
        {
            CreateMap<QuestionAnswers, CreateQuestionAnswerMessage>().ReverseMap();
            CreateMap<QuestionAnswers, DeleteQuestionAnswerMessage>().ReverseMap();
            CreateMap<QuestionAnswers, UpdateQuestionAnswerMessage>().ReverseMap();
        }
    }
}
