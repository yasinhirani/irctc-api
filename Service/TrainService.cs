using irctc.DTOs;
using irctc.Model;
using irctc.Repository.Interface;
using irctc.Service.Interface;
using irctc.Validations;
using Microsoft.OpenApi.Any;
using todo.Exceptions;

namespace irctc.Service
{
    public class TrainService : ITrainService
    {
        private readonly ITrainServiceRepository _repo;
        public TrainService(ITrainServiceRepository repo)
        {
            _repo = repo;
        }
        public async Task<ResponseDto<PnrModel?>> GetPnrDetails(long pnrNumber)
        {
            var result = await new PnrValidations().ValidateAsync(pnrNumber.ToString());

            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors[0].ErrorMessage);
            }

            var data = await _repo.GetPnrDetails(pnrNumber);

            return new ResponseDto<PnrModel?>
            {
                Data = data,
                Error = ""
            };
        }
        public async Task<ResponseDto<TrainLiveStatusResponse?>> GetTrainLiveStatusDetails(int trainNo, string date)
        {
            var result = await new LiveStatusValidations().ValidateAsync(new LiveStatusRequestDto { TrainNo = trainNo.ToString(), Date = date });

            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors[0].ErrorMessage);
            }

            var data = await _repo.GetTrainLiveStatusDetails(trainNo, date);

            if (data is not null)
            {
                var liveDetails = new TrainLiveStatusResponse()
                {
                    TrainNo = data.Data?.TrainNo,
                    TrainName = data.Data?.TrainName,
                    Date = data.Data?.Date,
                    StatusNote = data.Data?.StatusNote,
                    LastUpdate = data.Data?.LastUpdate,
                    TotalStations = data.Data?.TotalStations ?? 0,
                    Stations = data.Data?.Stations?.Select(s => new TrainLiveStatusStationResponse
                    {
                        StationName = s.StationName,
                        StationCode = s.StationCode,
                        Platform = s.Platform,
                        DistanceKm = int.TryParse(s.DistanceKm, out var result) ? result : null,
                        Arrival = s.Arrival,
                        Departure = s.Departure
                    }).ToList(),
                    CoachPosition = data.Data?.Stations?.FirstOrDefault()?.CoachPosition ?? null
                };
                return new ResponseDto<TrainLiveStatusResponse?>
                {
                    Data = liveDetails,
                    Error = ""
                };
            }
            return new ResponseDto<TrainLiveStatusResponse?>
            {
                Data = null,
                Error = "No live details found"
            };
        }
        public async Task<ResponseDto<List<LiveStationAt>>> GetLiveStationAtDetails(string stationCode)
        {
            var result = await new LiveStationAtValidations().ValidateAsync(stationCode);

            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors[0].ErrorMessage);
            }

            var data = await _repo.GetLiveStationAtDetails(stationCode);

            return new ResponseDto<List<LiveStationAt>>
            {
                Data = data,
                Error = ""
            };
        }
        public async Task<ResponseDto<List<TrainInfo>>> GetTrainsBetweenStation(string from, string to)
        {
            var result = await new TrainsBetweenStationsValidations().ValidateAsync(new TrainsBetweenStationRequestDto { From = from, To = to });

            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors[0].ErrorMessage);
            }

            var data = await _repo.GetTrainsBetweenStation(from, to);

            return new ResponseDto<List<TrainInfo>>
            {
                Data = data,
                Error = ""
            };
        }
        public async Task<ResponseDto<TrainInfo?>> GetTrainInfo(int trainNo)
        {
            var result = await new TrainInfoValidations().ValidateAsync(trainNo.ToString());

            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors[0].ErrorMessage);
            }

            var data = await _repo.GetTrainInfo(trainNo);

            return new ResponseDto<TrainInfo?>
            {
                Data = data,
                Error = ""
            };
        }
    }
}