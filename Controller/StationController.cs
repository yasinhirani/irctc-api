using irctc.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace irctc.Controller
{
    [ApiController]
    [Route("/api/station")]
    public class StationController : ControllerBase
    {
        private readonly IStationService _service;
        public StationController(IStationService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStations([FromQuery] string? query)
        {
            var stations = await _service.GetAllStations(query ?? "");

            return Ok(stations);
        }
    }
}