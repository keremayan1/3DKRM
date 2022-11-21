using AutoMapper;
using ChildParents.Application.Features.Mothers.DTOs;
using ChildParents.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildParents.Application.Features.Mothers.Commands.DeletedMothers
{
    public class DeleteMothersCommand:IRequest<DeletedMotherDto>
    {
        public string Id { get; set; }
        public class DeleteMothersCommandHandler : IRequestHandler<DeleteMothersCommand, DeletedMotherDto>
        {
            private IMotherRepository _motherRepository;
            private IMapper _mapper;

            public DeleteMothersCommandHandler(IMotherRepository motherRepository, IMapper mapper)
            {
                _motherRepository = motherRepository;
                _mapper = mapper;
            }

            public async Task<DeletedMotherDto> Handle(DeleteMothersCommand request, CancellationToken cancellationToken)
            {
                var getId = await _motherRepository.GetByIdAsync(request.Id);
                await _motherRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedMotherDto>(getId);
                return result;
            }
        }
    }
}
