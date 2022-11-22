using Application.Services.Repositories;
using AutoMapper;
using MassTransit;
using EducationStatuses = Domain.Entities.EducationStatusReadModel;
namespace Application.Features.EducationStatus.Consumers
{
    public class UpdateEducationStatusMessageConsumer : IConsumer<UpdateEducationStatusMessageConsumer>
    {
        private IEducationStatusRepository _educationStatusRepository;
        private IMapper _mapper;

        public UpdateEducationStatusMessageConsumer(IEducationStatusRepository educationStatusRepository, IMapper mapper)
        {
            _educationStatusRepository = educationStatusRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<UpdateEducationStatusMessageConsumer> context)
        {
            var mappedEducationStatus = _mapper.Map<EducationStatuses>(context.Message);
            await _educationStatusRepository.UpdateAsync(mappedEducationStatus);
        }
    }

}
