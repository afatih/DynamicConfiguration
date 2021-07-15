using DynamicConfiguration.Application.Configurations.Commands;
using DynamicConfiguration.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicConfiguration.Application.Configurations.Handlers
{
    public class DeleteConfigurationCommandHandler : IRequestHandler<DeleteConfigurationCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteConfigurationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(DeleteConfigurationCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Configurations.Delete(request.Id);
        }
    }
}
