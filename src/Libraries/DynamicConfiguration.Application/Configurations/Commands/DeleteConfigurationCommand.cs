using MediatR;

namespace DynamicConfiguration.Application.Configurations.Commands
{
    public class DeleteConfigurationCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
