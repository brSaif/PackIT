using Microsoft.Extensions.Logging;
using PackIT.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.Logging
{
    public class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly ILogger<LoggingCommandHandlerDecorator<TCommand>> _logger;

        public LoggingCommandHandlerDecorator(
            ILogger<LoggingCommandHandlerDecorator<TCommand>> logger,
            ICommandHandler<TCommand> commandHandler)
        {
            _logger = logger;
            _commandHandler = commandHandler;
        }

        public async Task HandleAsync(TCommand command)
        {
            var commandType = command.GetType();

            try
            {
                _logger.LogInformation($"Started processing {commandType} command.");
                await _commandHandler.HandleAsync(command);
                _logger.LogInformation($"Finished processing {commandType} command.");
            }
            catch 
            {
                _logger.LogInformation($"Failed to process {commandType} command.");
                throw;
            }
        }
    }
}
