using AutoMapper;
using Microsoft.Extensions.Logging;
using Personal.Common.Domain.Interfaces.Services;

namespace Personal.Common.Services
{
    public abstract class BaseService
    {
        protected readonly ILogger<BaseService> _logger;
        protected readonly IMapper _dataMapper;

        protected readonly ILogService _logService;
        public BaseService(ILogger<BaseService> logger, IMapper dataMapper, ILogService logService): this(logger, dataMapper)
        {
            _logService = logService;
        }

        public BaseService(ILogger<BaseService> logger, IMapper dataMapper) : this(logger)
        {
            _dataMapper = dataMapper;
        }

        public BaseService(ILogger<BaseService> logger)
        {
            _logger = logger;
        }
    }
}
