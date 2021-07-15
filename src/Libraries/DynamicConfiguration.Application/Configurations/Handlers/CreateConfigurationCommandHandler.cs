using AutoMapper;
using DynamicConfiguration.Application.Configurations.Commands;
using DynamicConfiguration.Application.Interfaces;
using DynamicConfiguration.Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicConfiguration.Application.Configurations.Handlers
{
    public class CreateConfigurationCommandHandler : IRequestHandler<CreateConfigurationCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateConfigurationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateConfigurationCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Configurations.Add(_mapper.Map<Configuration>(request));
        }
    }
}
