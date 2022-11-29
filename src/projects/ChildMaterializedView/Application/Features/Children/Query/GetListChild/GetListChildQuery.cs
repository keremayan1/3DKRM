using Application.Features.Children.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Children.Query.GetListChild
{
    public class GetListChildQuery:IRequest<ChildModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListChildQueryHandler : IRequestHandler<GetListChildQuery, ChildModel>
        {
            private readonly IChildRepository _childRepository;
            private readonly IMapper _mapper;

            public GetListChildQueryHandler(IChildRepository childRepository, IMapper mapper)
            {
                _childRepository = childRepository;
                _mapper = mapper;
            }

            public async Task<ChildModel> Handle(GetListChildQuery request, CancellationToken cancellationToken)
            {
                var models = await _childRepository.GetListAsync(include: gender => gender.Include(g => g.Gender),
                                                                 index: request.PageRequest.Page,
                                                                 size: request.PageRequest.PageSize);
                //var models = await _childRepository.GetListAsync2();
                var mappedModels = _mapper.Map<ChildModel>(models);
                return mappedModels;
            }
        }
    }
}
