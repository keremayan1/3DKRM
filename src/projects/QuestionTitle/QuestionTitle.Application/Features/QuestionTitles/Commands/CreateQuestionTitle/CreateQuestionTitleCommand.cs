using AutoMapper;
using MediatR;
using QuestionTitle.Application.Features.QuestionTitles.Dtos;
using QuestionTitle.Application.Services.Repositories;
using qt=QuestionTitle.Domain.Entities;
namespace QuestionTitle.Application.Features.QuestionTitles.Commands.CreateQuestionTitle
{
    public class CreateQuestionTitleCommand:IRequest<CreatedQuestionTitleDto>
    {
        public string QuestionTitleName { get; set; }
        public class CreateQuestionTitleCommandHandler : IRequestHandler<CreateQuestionTitleCommand, CreatedQuestionTitleDto>
        {
            private readonly IQuestionTitleRepository _questionTitleRepository;
            private readonly IMapper _mapper;

            public CreateQuestionTitleCommandHandler(IQuestionTitleRepository questionTitleRepository, IMapper mapper)
            {
                _questionTitleRepository = questionTitleRepository;
                _mapper = mapper;
            }

            public async Task<CreatedQuestionTitleDto> Handle(CreateQuestionTitleCommand request, CancellationToken cancellationToken)
            {
                var mappedQuestionTitle = _mapper.Map<qt.QuestionTitle>(request);
                await _questionTitleRepository.AddAsync(mappedQuestionTitle);

                var result = _mapper.Map<CreatedQuestionTitleDto>(mappedQuestionTitle);
                return result;
            }
        }
    }
}
