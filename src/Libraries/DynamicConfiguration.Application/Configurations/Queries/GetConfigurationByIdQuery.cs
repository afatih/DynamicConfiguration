using DynamicConfiguration.Application.Configurations.Dto;
using MediatR;

namespace DynamicConfiguration.Application.Configurations.Queries
{
    public class GetConfigurationByIdQuery : IRequest<ConfigurationDto>
    {
        public int Id { get; set; }
    }
}
