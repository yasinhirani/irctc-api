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

            var data = JsonSerializer.Deserialize<List<Station>>(json)
            ?.Select(station => new
            {
                Station = station,
                Score =
                    station.Code.Equals(query, StringComparison.OrdinalIgnoreCase) ? 1 :
                    station.Name.Equals(query, StringComparison.OrdinalIgnoreCase) ? 1 :

                    station.Code.StartsWith(query, StringComparison.OrdinalIgnoreCase) ? 2 :
                    station.Name.StartsWith(query, StringComparison.OrdinalIgnoreCase) ? 2 :

                    station.Code.Contains(query, StringComparison.OrdinalIgnoreCase) ? 3 :
                    station.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ? 3 :

                    4
            })
            .Where(s => s.Score < 4)
            .OrderBy(s => s.Score)
            .ThenBy(x => x.Station.Name)
            .Select(s => s.Station)
            .Take(20)
            .ToList();

            return data ?? [];
        }
    }
}