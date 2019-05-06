using AutoMapper;
using Sample.ToDoList.Models;
using Sample.ToDoList.ViewModels;
using System;

namespace Sample.ToDoList.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfile>();
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDo, ToDoViewModel>()
               .ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id))
               .ForMember(vm => vm.Description, map => map.MapFrom(m => m.Description))
               .ForMember(vm => vm.IsComplete, map => map.MapFrom(m => m.IsComplete))
               .ForMember(vm => vm.DateModified, map =>
                            map.MapFrom(m => m.DateModified != null
                                && m.DateModified > m.DateCreated ? m.DateModified : m.DateCreated));

            CreateMap<ToDoViewModel, ToDo>()
               .ForMember(m => m.Id, map => map.MapFrom(vm => vm.Id))
               .ForMember(m => m.Description, map => map.MapFrom(vm => vm.Description))
               .ForMember(m => m.IsComplete, map => map.MapFrom(vm => vm.IsComplete))
               .ForMember(m => m.DateCreated, map => map.MapFrom(vm => vm.DateModified))
               .ForMember(m => m.DateModified, map => map.MapFrom(vm =>vm.DateModified))
               .ForMember(m => m.CreatedBy, map => map.MapFrom(vm => new User()));
        }
    }
}