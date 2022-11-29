using Application.Features.ChildFather.DTOs;
using Application.Features.Children.Dtos;
using Application.Features.Children.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities;
using ChildFathers = Domain.Entities.ChildFather;

namespace Application.Features.Children.Profiles
{
    public class ChildrenProfiles:Profile
    {
        public ChildrenProfiles()
        {
            CreateMap<Child, GetListChildDto>().ForMember(x => x.GenderName, opt => opt.MapFrom(x => x.Gender.GenderName))
                                               .ForMember(x=>x.FatherFirstName,opt=>opt.MapFrom(x=>x.ChildFather.FirstName))
                
                .ReverseMap();
                                              //.ForMember(x => x.ChildFather, opt => opt.MapFrom(src => new ChildFathers {
                                              //    FirstName = src.ChildFather.FirstName,
                                              //    LastName = src.LastName,
                                              //    Job=src.ChildFather.Job,
                                              //    TelephoneNumber=src.ChildFather.TelephoneNumber,
                                              //}))
            //CreateMap<GetListChildDto, GetChildFatherDto>().ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.ChildFather.FirstName)).ReverseMap();

            CreateMap<ChildFathers, GetChildFatherDto>().ForMember(x => x.EducationStatusName, opt => opt.MapFrom(x => x.EducationStatus.EducationStatusName)).ReverseMap();
            CreateMap<IPaginate<Child>, ChildModel>().ReverseMap();
            CreateMap<List<Child>, ChildModel>().ReverseMap();
        }
    }
}
