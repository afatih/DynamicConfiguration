using AutoMapper;
using DynamicConfiguration.Application.Configurations.Dto;
using DynamicConfiguration.Application.Configurations.Queries;
using DynamicConfiguration.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicConfiguration.Application.Configurations.Handlers
{
    public class GetAllConfigurationsQueryHandler : IRequestHandler<GetAllConfigurationsQuery, List<ConfigurationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllConfigurationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ConfigurationDto>> Handle(GetAllConfigurationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Configurations.GetAll();
            return _mapper.Map<List<ConfigurationDto>>(result.ToList());
        }
    }
}
