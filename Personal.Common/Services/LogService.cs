using Microsoft.Extensions.Logging;
using Personal.Common.Domain;
using Personal.Common.Domain.Interfaces;
using Personal.Common.Domain.Interfaces.Services;
using System.Text.Json;
using static Personal.Common.Domain.Log;

namespace Personal.Common.Services
{
    public class LogService: BaseService, ILogService
    {
        
        private readonly ILogRepository _logRepository;
        public LogService(ILogger<LogService> logger, ILogRepository logRepository): base(logger)
        {
            _logRepository = logRepository;
        }

        public async Task LogList<T>(T entity, string methodName)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, "entity");

                Log log = new Log(ACTION.LIST, entity.GetType(), methodName);

                await _logRepository.Register(log);

                _logger.LogInformation($"Log inserido com sucesso: {log} ");
            }
            catch (Exception e)
            {
                _logger.LogError($"Log com erro: {e.Message} ");
            }
        }

        public async Task LogView<T>(T entity, string methodName)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, "entity");

                var data = JsonSerializer.Serialize(entity);
                Log log = new Log(ACTION.VIEW, entity.GetType(), methodName, data);

                await _logRepository.Register(log);
                _logger.LogInformation($"Log inserido com sucesso: {log} ");

            }
            catch (Exception e)
            {
                _logger.LogError($"Log com erro: {e.Message} ");
            }
        }

        public async Task LogUpdate<T>(T entity, string methodName)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, "entity");

                var data = JsonSerializer.Serialize(entity);

                Log log = new Log(ACTION.UPDATE, entity.GetType(), methodName, data);


                await _logRepository.Register(log);
                _logger.LogInformation($"Log inserido com sucesso: {log} ");

            }
            catch (Exception e)
            {
                _logger.LogError($"Log com erro: {e.Message} ");
            }
        }

        public async Task LogInsert<T>(T entity, string methodName)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, "entity");

                var data = JsonSerializer.Serialize(entity);

                Log log = new Log(ACTION.INSERT, entity.GetType(), methodName, data);


                await _logRepository.Register(log);
                _logger.LogInformation($"Log inserido com sucesso: {log} ");

            }
            catch (Exception e)
            {
                _logger.LogError($"Log com erro: {e.Message} ");
            }
        }

        public async Task LogDelete<T>(T entity, string methodName)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, "entity");

                var data = JsonSerializer.Serialize(entity);

                Log log = new Log(ACTION.DELETE, entity.GetType(), methodName, data);


                await _logRepository.Register(log);
                _logger.LogInformation($"Log inserido com sucesso: {log} ");

            }
            catch (Exception e)
            {
                _logger.LogError($"Log com erro: {e.Message} ");
            }
        }
    }
}
