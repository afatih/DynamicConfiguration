using AutoMapper;
using DynamicConfiguration.Application.Configurations.Handlers;
using DynamicConfiguration.Application.Configurations.MappingProfiles;
using DynamicConfiguration.Application.Configurations.Queries;
using DynamicConfiguration.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DynamicConfiguration.UnitTest
{

    public class ConfigurationTest
    {
        private readonly GetAllConfigurationsQueryHandler _getAllConfigurationsQueryHandler;
        private readonly Mock<IConfiguration> _configuration;
        private readonly Mock<IConfigurationSection> _configurationSection;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ConfigurationRepository> _configurationRepository;
        private readonly IMapper _mapper;

        public ConfigurationTest()
        {
            _configurationSection = new Mock<IConfigurationSection>();
            _configurationSection.SetupGet(m => m[It.Is<string>(s => s == "DefaultConnection")])
                .Returns("Data Source=.;Initial Catalog=Beymen;Integrated Security=true");

            _configuration = new Mock<IConfiguration>();
            _configuration.Setup(a => a.GetSection(It.Is<string>(s => s == "ConnectionStrings")))
                .Returns(_configurationSection.Object);

            var mapperProfile = new ConfigurationMappingProfile();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(mapperProfile));
            _mapper = new Mapper(mapperConfig);

            _configurationRepository = new Mock<ConfigurationRepository>(_configuration.Object);
            _unitOfWork = new Mock<UnitOfWork>(_configurationRepository.Object);

            _getAllConfigurationsQueryHandler = new GetAllConfigurationsQueryHandler(_unitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task GetAllConfigurations_Success()
        {
            // Arrange
            var getAllConfigurationsQuery = new GetAllConfigurationsQuery();

            // Act
            var result = await _getAllConfigurationsQueryHandler.Handle(getAllConfigurationsQuery, new CancellationToken());

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }
    }
}
