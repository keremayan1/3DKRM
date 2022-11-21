using AutoMapper;
using ChildParents.Application.Features.Fathers.DTOs;
using ChildParents.Application.Features.Mothers.DTOs;
using ChildParents.Application.Services.Repositories;
using ChildParents.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildParents.Application.Features.Fathers.Commands.UpdateFathers
{
    public class UpdateFathersCommand : IRequest<UpdatedFatherDto>
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EducationStatusId { get; set; }
        public string Job { get; set; }
        public string TelephoneNumber { get; set; }
        public class UpdateFathersCommandHandler : IRequestHandler<UpdateFathersCommand, UpdatedFatherDto>
        {
            private readonly IFatherRepository _fatherRepository;
            private readonly IMapper _mapper;

            public UpdateFathersCommandHandler(IFatherRepository fatherRepository, IMapper mapper)
            {
                _fatherRepository = fatherRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedFatherDto> Handle(UpdateFathersCommand request, CancellationToken cancellationToken)
            {
                var mappedFather = _mapper.Map<Father>(request);
                await _fatherRepository.UpdateAsync(mappedFather.Id, mappedFather);
                var result = _mapper.Map<UpdatedFatherDto>(mappedFather);
                return result;
            }
        }
    }
}
