using AutoMapper;
using Core.Tools.RabbitMQ.Messages.ChildSiblings;
using childSiblings = Domain.Entities.ChildSiblings;

namespace Application.Features.ChildSiblings.Profiles
{
    public class ChildSiblingsMapping:Profile
    {
        public ChildSiblingsMapping()
        {
            CreateMap<childSiblings, CreateChildSiblingsMessage>().ReverseMap();
            CreateMap<childSiblings, UpdateChildSiblingsMessage>().ReverseMap();
            CreateMap<childSiblings, DeleteChildSiblingsMessage>().ReverseMap();
        }
    }
}
