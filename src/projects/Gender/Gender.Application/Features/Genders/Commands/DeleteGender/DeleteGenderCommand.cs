using AutoMapper;
using Gender.Application.Features.Genders.Dtos;
using Gender.Application.Features.Genders.Rules;
using Gender.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using genders = Gender.Domain.Entities;
namespace Gender.Application.Features.Genders.Commands.DeleteGender
{
    public class DeleteGenderCommand : IRequest<DeletedGenderDto>
    {
        public string Id { get; set; }
        public class DeleteGenderCommandHandler : IRequestHandler<DeleteGenderCommand, DeletedGenderDto>
        {
            private readonly IGenderRepository _genderRepository;
            private readonly IMapper _mapper;
            private readonly GenderBusinessRules _genderBusinessRules;
            public DeleteGenderCommandHandler(IGenderRepository genderRepository, IMapper mapper, GenderBusinessRules genderBusinessRules)
            {
                _genderRepository = genderRepository;
                _mapper = mapper;
                _genderBusinessRules = genderBusinessRules;
            }

            public async Task<DeletedGenderDto> Handle(DeleteGenderCommand request, CancellationToken cancellationToken)
            {
              var getId  = await _genderRepository.GetByIdAsync(request.Id);
                await _genderRepository.DeleteAsync(getId);
                var result = _mapper.Map<DeletedGenderDto>(getId);
                return result;
            }
        }
    }
}
