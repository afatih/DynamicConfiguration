using AutoMapper;
using DynamicConfiguration.Application.Configurations.Commands;
using DynamicConfiguration.Application.Configurations.Dto;
using DynamicConfiguration.Core.Entities;

namespace DynamicConfiguration.Application.Configurations.MappingProfiles
{
    public class ConfigurationMappingProfile : Profile
    {
        public ConfigurationMappingProfile()
        {
            CreateMap<CreateConfigurationCommand, Configuration>();
            CreateMap<UpdateConfigurationCommand, Configuration>();
            CreateMap<ConfigurationDto, UpdateConfigurationCommand>();
            CreateMap<Configuration, ConfigurationDto>();
        }
    }
}
