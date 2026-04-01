using irctc.Model.Station;

namespace irctc.Repository.Interface
{
    public interface IStationRepository
    {
        Task<List<Station>> GetAllStations(string query);
    }
}