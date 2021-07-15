using DynamicConfiguration.Application.Configurations.Dto;
using System.Collections.Generic;

namespace DynamicConfiguration.Web.Models
{
    public class ConfigurationViewModel
    {
        public List<ConfigurationDto> Configurations { get; set; }
    }
}
