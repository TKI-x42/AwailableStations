using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using AwailableStations.Domain.Entities;
using AwailableStations.Domain.Models;
using AvailableStations.Infrastucture.Interfaces;
using AwailableStations.API.Models.ViewModels;
using AwailableStations.API.Models.RequestModels;

namespace AwailableStations.API.Controllers
{
	[Route("api/available-stations")]
	[ApiController]
	public class AvailableStationsController : ControllerBase
	{
		private readonly IStationRepository _stationRepository;
		private readonly IMapper _mapper;

		public AvailableStationsController(IStationRepository stationRepository, IMapper mapper)
		{
			_stationRepository = stationRepository;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetStationAsync([FromRoute]Guid id)
		{
			var station = await _stationRepository.GetStationByIdAsync(id);
			if (station == null)
			{
				return NotFound();
			}

			return Ok(station);
		}

		[HttpGet]
		public async Task<IActionResult> GetStationsInArea([FromQuery]MapArea area, int limit = 100, int offset = 0)
		{
			var stationCount = await _stationRepository.GetStationCountAsync(area);
			var stations = await _stationRepository.GetStationsInAreaAsync(area, limit, offset);

			return Ok(new
			{
				Pagination = new
				{
					Total = stationCount,
					Limit = limit,
					Offset = offset
				},
				Stations = stations
			});
		}

		[HttpGet]
		[Route("points")]
		public async Task<IActionResult> GetStationsPointsInArea([FromQuery] MapArea area, int limit = 100, int offset = 0)
		{
			var stationCount = await _stationRepository.GetStationCountAsync(area);
			var stations = await _stationRepository.GetStationsInAreaAsync(area, limit, offset);
			var stationPoints = _mapper.Map<IEnumerable<Station>, IEnumerable<StationPoints>>(stations);

			return Ok(new
			{
				Pagination = new
				{
					Total = stationCount,
					Limit = limit,
					Offset = offset
				},
				StationPoints = stationPoints
			});
		}

		[HttpPut]
		public async Task<IActionResult> CreateStation(CreateStationRequest createStationRequest)
		{
			if (createStationRequest == null)
			{
				return BadRequest("Null station in request.");
			}

			var createdStation = await _stationRepository.CreateAsync(_mapper.Map<Station>(createStationRequest));

			if (createdStation == null)
			{
				return BadRequest("Station already created");
			}

			return Ok(createdStation);
		}

		[HttpPatch]
		public async Task<IActionResult> UpdateStation(Station station)
		{
			if (station == null)
			{
				return BadRequest("Null station in reauest.");
			}

			var updatedStation = await _stationRepository.UpdateAsync(station);
			return Ok(updatedStation);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteStation(Guid id)
		{
			var result = await _stationRepository.DeleteAsync(id);
			if (!result)
			{
				return NotFound();
			}
			return Ok("Delete success.");
		}
	}
}
