using irctc.DTOs;
using irctc.Model.Station;

namespace irctc.Service.Interface
{
    public interface IStationService
    {
        Task<ResponseDto<List<Station>>> GetAllStations(string query);
    }
}