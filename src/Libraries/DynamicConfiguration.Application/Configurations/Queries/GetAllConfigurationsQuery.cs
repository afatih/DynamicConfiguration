using DynamicConfiguration.Application.Configurations.Dto;
using MediatR;
using System.Collections.Generic;

namespace DynamicConfiguration.Application.Configurations.Queries
{
    public class GetAllConfigurationsQuery : IRequest<List<ConfigurationDto>>
    {
    }
}
