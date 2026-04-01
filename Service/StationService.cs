using irctc.DTOs;
using irctc.Model.Station;
using irctc.Repository.Interface;
using irctc.Service.Interface;

namespace irctc.Service
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _repo;
        public StationService(IStationRepository repo)
        {
            _repo = repo;
        }
        public async Task<ResponseDto<List<Station>>> GetAllStations(string query)
        {
            var data = await _repo.GetAllStations(query);

            return new ResponseDto<List<Station>>
            {
                Data = data,
                Error = ""
            };
        }
    }
}