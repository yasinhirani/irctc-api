using irctc.Model;

namespace irctc.Repository.Interface
{
    public interface ITrainServiceRepository
    {
        Task<PnrModel?> GetPnrDetails(long pnrNumber);
        Task<LiveTrainRes?> GetTrainLiveStatusDetails(int trainNo, string date);
        Task<List<LiveStationAt>> GetLiveStationAtDetails(string stationCode);
        Task<List<TrainInfo>> GetTrainsBetweenStation(string from, string to);
        Task<TrainInfo?> GetTrainInfo(int trainNo);
    }
}