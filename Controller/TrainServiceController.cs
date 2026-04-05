using System.ComponentModel.DataAnnotations;
using irctc.Repository.Interface;
using irctc.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace irctc.Controller
{
    [ApiController]
    [Route("/api/train")]
    public class TrainServiceController : ControllerBase
    {
        private readonly ITrainService _service;
        public TrainServiceController(ITrainService service)
        {
            _service = service;
        }
        [HttpGet("pnr/{pnrNumber}")]
        public async Task<IActionResult> GetAllStations(long pnrNumber)
        {
            var pnrDetails = await _service.GetPnrDetails(pnrNumber);

            return Ok(pnrDetails);
        }
        [HttpGet("liveStatus")]
        public async Task<IActionResult> GetTrainLiveStatusDetails([FromQuery] int trainNo, [FromQuery] string startDay)
        {
            var liveStatus = await _service.GetTrainLiveStatusDetails(trainNo, startDay);

            return Ok(liveStatus);
        }
        [HttpGet("liveStationAt/{stationCode}")]
        public async Task<IActionResult> GetLiveStationAtDetails(string stationCode)
        {
            var liveStatus = await _service.GetLiveStationAtDetails(stationCode);

            return Ok(liveStatus);
        }
        [HttpGet("trainsBetweenStations")]
        public async Task<IActionResult> GetTrainsBetweenStation([FromQuery] [Required] string from, [FromQuery] [Required] string to)
        {
            var trains = await _service.GetTrainsBetweenStation(from, to);

            return Ok(trains);
        }
        [HttpGet("{trainNo}/info")]
        public async Task<IActionResult> GetTrainInfo([FromRoute] int trainNo)
        {
            var trainInfo = await _service.GetTrainInfo(trainNo);

            return Ok(trainInfo);
        }
    }
}