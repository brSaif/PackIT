using NSubstitute;
using PackIT.Application.Commands;
using PackIT.Application.Commands.Handlers;
using PackIT.Application.DTO;
using PackIT.Application.Exceptions;
using PackIT.Application.Services;
using PackIT.Domain.Const;
using PackIT.Domain.Entities;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Commands;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PackIT.Tests.Application
{
    public class CreatePackingListWithItemsHandlerTests 
    {


        Task Act(CreatePackingListWithItems command)
            => _commandHandler.HandleAsync(command);

        [Fact]
        public async Task HandleAsync_ThrowsPackingListAlreadyExistsException_WhenAPackingListWithSameNameExist()
        {
            var command = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Male, default);
            _readService.ExistsByNameAsync(command.Name).Returns(true);

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingListAlreadyExistException>();
        }

        [Fact]
        public async Task HandleAsync_ThrowsMissinngLocalizationWeatherException_WhenWeatherIsNotReturnedFromService()
        {
            var command = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Male,
                                                         new LocalizationWriteModel("Tunis", "Tunisia"));

            _readService.ExistsByNameAsync(command.Name).Returns(false);
            _weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(default(WeatherDto));

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingLocalizationWeatherException>();

        }

        [Fact]
        public async Task HandleAsync_CallsRepository_OnSuccess()
        {
            var command = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Male,
                                                         new LocalizationWriteModel("Tunis", "Tunisia"));

            _readService.ExistsByNameAsync(command.Name).Returns(false);
            _weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(new WeatherDto(12));
            _factory.CreateWithDefaultItems(command.Id, command.Name, command.Days, command.Gender,
                                            Arg.Any<Temperature>(), Arg.Any<Localization>()).Returns(default(PackingList));

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldBeNull();
            await _repository.Received(1).AddAsync(Arg.Any<PackingList>());
        }

        #region Arrange

        private readonly ICommandHandler<CreatePackingListWithItems> _commandHandler;
        private readonly IPackingListRepository _repository;
        private readonly IWeatherService _weatherService;
        private readonly IPackingListReadService _readService;
        private readonly IPackingListFactory _factory;

        public CreatePackingListWithItemsHandlerTests()
        {
            _repository = Substitute.For<IPackingListRepository>();
            _weatherService = Substitute.For<IWeatherService>();
            _readService = Substitute.For<IPackingListReadService>();
            _factory = Substitute.For<IPackingListFactory>();

            _commandHandler = new CreatePackingListWithItemsHandler(_readService, _factory, _repository, _weatherService);
        }
        #endregion

    }
}
