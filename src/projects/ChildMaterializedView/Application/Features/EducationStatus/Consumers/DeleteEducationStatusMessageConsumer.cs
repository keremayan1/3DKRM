﻿using Application.Services.Repositories;
using AutoMapper;
using MassTransit;
using EducationStatuses = Domain.Entities.EducationStatusReadModel;
namespace Application.Features.EducationStatus.Consumers
{
    public class DeleteEducationStatusMessageConsumer : IConsumer<DeleteEducationStatusMessageConsumer>
    {
        private IEducationStatusRepository _educationStatusRepository;
        private IMapper _mapper;

        public DeleteEducationStatusMessageConsumer(IEducationStatusRepository educationStatusRepository, IMapper mapper)
        {
            _educationStatusRepository = educationStatusRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<DeleteEducationStatusMessageConsumer> context)
        {
            var mappedEducationStatus = _mapper.Map<EducationStatuses>(context.Message);
            await _educationStatusRepository.DeleteAsync(mappedEducationStatus);
        }
    }

}
