using PackIT.Application.Exceptions;
using PackIT.Application.Services;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Commands;

namespace PackIT.Application.Commands.Handlers;

public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
{
	private readonly IPackingListFactory _factory;
	private readonly IPackingListRepository _repositories;
	private readonly IPackingListReadService _readService;
	private readonly IWeatherService _weatherService;

	public CreatePackingListWithItemsHandler(
		IPackingListFactory factory,
		IPackingListRepository repositories,
		IPackingListReadService readService,
		IWeatherService weatherService
	)
	{
		_factory = factory;
		_repositories = repositories;
		_readService = readService;
		_weatherService = weatherService;
	}

	public async Task HandleAsync(CreatePackingListWithItems command)
	{
		var (id, name, days, gender, localizationWriteMode) = command;
		if (await _readService.ExistsByNameAsync(command.Name))
		{
			throw new PackingListAlreadyExistsException(command.Name);
		}
		var localization = new Localization(
			localizationWriteMode.City,
			localizationWriteMode.Country
		);
		var weather =
			await _weatherService.GetWeatherAsync(localization)
			?? throw new MissingLocalizationWeatherException(localization);
		var packingList = _factory.CreateWithDefaultItems(
			id,
			name,
			days,
			gender,
			weather.Temperature,
			localization
		);

		await _repositories.AddAsync(packingList);
	}
}
