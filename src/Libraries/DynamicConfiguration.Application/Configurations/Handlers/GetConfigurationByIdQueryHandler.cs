using AutoMapper;
using DynamicConfiguration.Application.Configurations.Dto;
using DynamicConfiguration.Application.Configurations.Queries;
using DynamicConfiguration.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicConfiguration.Application.Configurations.Handlers
{
    public class GetConfigurationByIdQueryHandler : IRequestHandler<GetConfigurationByIdQuery, ConfigurationDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetConfigurationByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ConfigurationDto> Handle(GetConfigurationByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Configurations.Get(request.Id);
            return _mapper.Map<ConfigurationDto>(result);
        }
    }
}