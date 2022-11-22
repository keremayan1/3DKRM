using AutoMapper;
using Core.Tools.RabbitMQ.Messages.QuestionAnswer;
using QuestionTitles = Domain.Entities.QuestionTitle;


namespace Application.Features.QuestionAnswer.Profiles
{
    public class QuestionTitleMapping:Profile
    {
        public QuestionTitleMapping()
        {
            CreateMap<QuestionTitles, CreateQuestionAnswerMessage>().ReverseMap();
            CreateMap<QuestionTitles, DeleteQuestionAnswerMessage>().ReverseMap();
            CreateMap<QuestionTitles, UpdateQuestionAnswerMessage>().ReverseMap();
        }
    }
}
