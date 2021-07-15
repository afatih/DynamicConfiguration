using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DynamicConfiguration.Application.Configurations.Commands
{
    public class CreateConfigurationCommand : IRequest<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string ApplicationName { get; set; }
    }
}
