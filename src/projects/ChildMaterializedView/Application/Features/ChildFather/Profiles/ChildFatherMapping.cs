using AutoMapper;
using Core.Tools.RabbitMQ.Messages.ChildParents.Fathers;
using cf = Domain.Entities;
namespace Application.Features.ChildFather.Profiles
{
    public class ChildFatherMapping:Profile
    {
        public ChildFatherMapping()
        {
            CreateMap<cf.ChildFather, CreateChildFatherMessage>().ReverseMap();
            CreateMap<cf.ChildFather, DeleteChildFatherMessage>().ReverseMap();
            CreateMap<cf.ChildFather, UpdateChildFatherMessage>().ReverseMap();
        }
    }
}
