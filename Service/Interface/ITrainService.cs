using irctc.DTOs;
using irctc.Model;

namespace irctc.Service.Interface
{
    public interface ITrainService
    {
        Task<ResponseDto<PnrModel?>> GetPnrDetails(long pnrNumber);
        Task<ResponseDto<LiveTrainRes?>> GetTrainLiveStatusDetails(int trainNo, int startDay);
        Task<ResponseDto<List<LiveStationAt>>> GetLiveStationAtDetails(string stationCode);
        Task<ResponseDto<List<TrainInfo>>> GetTrainsBetweenStation(string from, string to);
        Task<ResponseDto<TrainInfo?>> GetTrainInfo(int trainNo);
    }
}