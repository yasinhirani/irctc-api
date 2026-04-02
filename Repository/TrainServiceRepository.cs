using System.Net;
using irctc.Exceptions;
using irctc.Model;
using irctc.Repository.Interface;
using irctc.Utility;
using Microsoft.OpenApi.Any;

namespace irctc.Repository
{
    public class TrainServiceRepository : ITrainServiceRepository
    {
        private readonly HttpClient _client;
        private readonly string _erailBaseUrl = "";
        private readonly string _irctcConnectBaseUrl = "";
        private readonly string _irctcConnectApiKey = "";
        public TrainServiceRepository(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _erailBaseUrl = configuration["ErailBaseUrl"] ?? "";
            _irctcConnectBaseUrl = configuration["IrctcConnectBaseUrl"] ?? "";
            _irctcConnectApiKey = configuration["IrctcConnectApiKey"] ?? "";
        }
        public async Task<PnrModel?> GetPnrDetails(long pnrNumber)
        {
            var uri = $"{_irctcConnectBaseUrl}/checkPNRStatus/{pnrNumber}";

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            request.Headers.Add("x-api-key", _irctcConnectApiKey);

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<PnrResponseModel>();

                return data?.Data;
            }
            return null;
        }
        public async Task<TrainLiveStatusApiResponse?> GetTrainLiveStatusDetails(int trainNo, string date)
        {
            var uri = $"{_irctcConnectBaseUrl}/trackTrain/{trainNo}/{date}";

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            request.Headers.Add("x-api-key", _irctcConnectApiKey);

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<TrainLiveStatusApiResponse>();

                return data;
            }
            return null;
        }
        public async Task<List<LiveStationAt>> GetLiveStationAtDetails(string stnCode)
        {
            // var uri = $"{_easyRailBaseUrl}/at-station";
            var uri = $"{_erailBaseUrl}/station-live/{stnCode}?DataSource=0&Language=0&Cache=true";

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            request.Headers.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 " +
                "(KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");

            request.Headers.Add("Referer", _erailBaseUrl);
            request.Headers.Add("Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var trains = new ParseTrainData().ParseLiveStationAt(data);

                return trains;
            }
            return [];
        }
        public async Task<List<TrainInfo>> GetTrainsBetweenStation(string from, string to)
        {
            var uri = $"{_erailBaseUrl}/rail/getTrains.aspx?Station_From={from}&Station_To={to}&DataSource=0&Language=0&Cache=true";

            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var trains = new ParseTrainData().ParseTrainBetweenStations(data).OrderBy(d => TimeSpan.TryParse(d.FromTime, out var time) ? time : TimeSpan.MaxValue).ToList();
                return trains ?? [];

            }
            return [];
        }
        public async Task<TrainInfo?> GetTrainInfo(int trainNo)
        {
            var uri = $"{_erailBaseUrl}/rail/getTrains.aspx?TrainNo={trainNo}&DataSource=0&Language=0&Cache=true";

            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                try
                {
                    var trainInfo = await new ParseTrainData().ParseTrainInfo(data, _erailBaseUrl, _client);

                    return trainInfo;
                }
                catch (Exception)
                {
                    throw new BaseException((int)HttpStatusCode.InternalServerError, $"There was an issue getting the information for {trainNo}");
                }
            }
            return null;
        }
    }
}