using AutoMapper;
using Child.Application.Features.Children.Dtos;
using Child.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Child.Application.Features.Children.Commands.DeleteChild
{
    public class DeleteChildCommand:IRequest<DeletedChildDto>
    {
        public string Id { get; set; }
        public class DeleteChildCommandHandler : IRequestHandler<DeleteChildCommand, DeletedChildDto>
        {
            private readonly IChildRepository _childRepository;
            private readonly IMapper _mapper;

            public DeleteChildCommandHandler(IChildRepository childRepository, IMapper mapper)
            {
                _childRepository = childRepository;
                _mapper = mapper;
            }

            public async Task<DeletedChildDto> Handle(DeleteChildCommand request, CancellationToken cancellationToken)
            {
                var getId = await _childRepository.GetByIdAsync(request.Id);
                await _childRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedChildDto>(request);
                return result;
            }
        }
    }
}
