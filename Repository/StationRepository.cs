using System.Text.Json;
using irctc.Model.Station;
using irctc.Repository.Interface;

namespace irctc.Repository
{
    public class StationRepository : IStationRepository
    {
        public StationRepository() { }
        public async Task<List<Station>> GetAllStations(string query)
        {
            var filePath = "./Misc/Stations.json";

            var json = await File.ReadAllTextAsync(filePath);

            var data = JsonSerializer.Deserialize<List<Station>>(json)?.Where(s => s.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase) || s.Code.Contains(query, StringComparison.CurrentCultureIgnoreCase)).ToList();

            return data ?? [];
        }
    }
}