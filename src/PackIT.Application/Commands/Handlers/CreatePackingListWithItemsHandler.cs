using PackIT.Application.Exceptions;
using PackIT.Application.Services;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListReadService _readService;
        private readonly IPackingListFactory _factory;
        private readonly IPackingListRepository _repository;
        private readonly IWeatherService _weatherService;

        public CreatePackingListWithItemsHandler(IPackingListReadService readService,
            IPackingListFactory factory, IPackingListRepository repository, IWeatherService weatherService)
        {
            _readService = readService;
            _factory = factory;
            _repository = repository;
            _weatherService = weatherService;
        }

        public async Task HandleAsync(CreatePackingListWithItems command)
        {
            var (id, name, days, gender, localizationWriteModel) = command;

            if (await _readService.ExistsByNameAsync(name)){
                throw new PackingListAlreadyExistException(name);
            }

            var localization = new Localization(localizationWriteModel.City, localizationWriteModel.Country);
            var weather = await _weatherService.GetWeatherAsync(localization);

            if (weather is null)
            {
                throw new MissingLocalizationWeatherException(localization);
            }

            var packingList = _factory
                .CreateWithDefaultItems(id, name, days, 
                    gender, weather.Temperature, localization);

            await _repository.AddAsync(packingList);
        }
    }
}
