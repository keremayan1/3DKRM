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
namespace Gender.Application.Features.Genders.Commands.CreateGender
{
    public class CreateGenderCommand : IRequest<CreatedGenderDto>
    {
        public string GenderName { get; set; }
        public class CreateGenderCommandHandler : IRequestHandler<CreateGenderCommand, CreatedGenderDto>
        {
            private readonly IGenderRepository _genderRepository;
            private readonly IMapper _mapper;
            private readonly GenderBusinessRules _genderBusinessRules;
            public CreateGenderCommandHandler(IGenderRepository genderRepository, IMapper mapper, GenderBusinessRules genderBusinessRules)
            {
                _genderRepository = genderRepository;
                _mapper = mapper;
                _genderBusinessRules = genderBusinessRules;
            }

            public async Task<CreatedGenderDto> Handle(CreateGenderCommand request, CancellationToken cancellationToken)
            {
                var mappedGender = _mapper.Map<genders.Gender>(request);
                
                await _genderBusinessRules.GenderCannotNull(mappedGender);
                await _genderBusinessRules.GenderNameCannotBeDuplicatedWhenInserted(mappedGender.GenderName);

                await _genderRepository.AddAsync(mappedGender);

                var result = _mapper.Map<CreatedGenderDto>(mappedGender);
                return result;
            }
        }
    }
}
