using AutoMapper;
using ChildParents.Application.Features.Fathers.DTOs;
using ChildParents.Application.Services.Repositories;
using ChildParents.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildParents.Application.Features.Fathers.Commands.CreateFathers
{
    public class CreateFathersCommand :IRequest<CreatedFatherDto>
    {
        public bool DoesHaveAFather { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EducationStatusId { get; set; }
        public string Job { get; set; }
        public string TelephoneNumber { get; set; }
        public class CreateFathersCommandHandler : IRequestHandler<CreateFathersCommand, CreatedFatherDto>
        {
            private readonly IFatherRepository _fatherRepository;
            private readonly IMapper _mapper;

            public CreateFathersCommandHandler(IFatherRepository fatherRepository, IMapper mapper)
            {
                _fatherRepository = fatherRepository;
                _mapper = mapper;
            }

            public async Task<CreatedFatherDto> Handle(CreateFathersCommand request, CancellationToken cancellationToken)
            {
                var mappedFather = _mapper.Map<Father>(request);
                if (request.DoesHaveAFather)
                {
                    await _fatherRepository.AddAsync(mappedFather);
                    var result = _mapper.Map<CreatedFatherDto>(mappedFather);
                    return result;
                }
                return null;
              
            }
        }
    }
}
