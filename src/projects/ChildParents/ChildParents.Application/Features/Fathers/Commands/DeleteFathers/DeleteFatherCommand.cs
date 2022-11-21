using AutoMapper;
using ChildParents.Application.Features.Fathers.DTOs;
using ChildParents.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildParents.Application.Features.Fathers.Commands.DeleteFathers
{
    public class DeleteFatherCommand:IRequest<DeletedFathersDto>
    {
        public string Id { get; set; }
        public class DeleteFatherCommandHandler : IRequestHandler<DeleteFatherCommand, DeletedFathersDto>
        {
            private readonly IFatherRepository _fatherRepository;
            private readonly IMapper _mapper;

            public DeleteFatherCommandHandler(IFatherRepository fatherRepository, IMapper mapper)
            {
                _fatherRepository = fatherRepository;
                _mapper = mapper;
            }

            public async Task<DeletedFathersDto> Handle(DeleteFatherCommand request, CancellationToken cancellationToken)
            {
                var getId = await _fatherRepository.GetByIdAsync(request.Id);
                await _fatherRepository.DeleteAsync(getId);
                var result = _mapper.Map<DeletedFathersDto>(getId);
                return result;
            }
        }
    }
}
