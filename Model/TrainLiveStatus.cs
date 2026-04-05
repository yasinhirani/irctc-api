using System.Text.Json.Serialization;

namespace irctc.Model
{
    public class TrainLiveStatusApiResponse
    {
        public bool Success { get; set; }
        public TrainLiveStatus? Data { get; set; }
    }
    public class TrainLiveStatus
    {
        public string? TrainNo { get; set; }
        public string? TrainName { get; set; }
        public string? Date { get; set; }
        public string? StatusNote { get; set; }
        public string? LastUpdate { get; set; }
        public int TotalStations { get; set; }
        public List<TrainLiveStatusStation>? Stations { get; set; }
    }

    public class TrainLiveStatusStation
    {
        public string? StationCode { get; set; }
        public string? StationName { get; set; }
        public string? Platform { get; set; }
        public string? DistanceKm { get; set; }
        public Arrival? Arrival { get; set; }
        public Departure? Departure { get; set; }
        public List<CoachPosition>? CoachPosition { get; set; }
    }

    public class Arrival
    {
        public string? Scheduled { get; set; }
        public string? Actual { get; set; }
        public string? Delay { get; set; }
    }

    public class CoachPosition
    {
        public string? Type { get; set; }
        public string? Number { get; set; }
        public string? Position { get; set; }
    }

    public class Departure
    {
        public string? Scheduled { get; set; }
        public string? Actual { get; set; }
        public string? Delay { get; set; }
    }

    public class TrainLiveStatusResponse
    {
        public string? TrainNo { get; set; }
        public string? TrainName { get; set; }
        public string? Date { get; set; }
        public string? StatusNote { get; set; }
        public string? LastUpdate { get; set; }
        public int TotalStations { get; set; }
        public List<CoachPosition>? CoachPosition { get; set; }
        public List<TrainLiveStatusStationResponse>? Stations { get; set; }
    }

    public class TrainLiveStatusStationResponse
    {
        public string? StationCode { get; set; }
        public string? StationName { get; set; }
        public string? Platform { get; set; }
        public int? DistanceKm { get; set; }
        public Arrival? Arrival { get; set; }
        public Departure? Departure { get; set; }
    }

    public class NonStopStations
    {
        [JsonPropertyName("sta")]
        public string? ScheduleArrival{ get; set; }

        [JsonPropertyName("std")]
        public string? ScheduleDeparture { get; set; }

        [JsonPropertyName("station_code")]
        public string? StationCode { get; set; }
        
        [JsonPropertyName("station_name")]
        public string? StationName { get; set; }

        [JsonPropertyName("distance_from_source")]
        public double? Distance { get; set; }
    }

    public class DaySchedule
    {
        [JsonPropertyName("sta")]
        public string? ScheduleArrival{ get; set; }

        [JsonPropertyName("std")]
        public string? ScheduleDeparture { get; set; }

        [JsonPropertyName("eta")]
        public string? EstimateArrival { get; set; }

        [JsonPropertyName("etd")]
        public string? EstimateDeparture { get; set; }

        [JsonPropertyName("station_code")]
        public string? StationCode { get; set; }
        
        [JsonPropertyName("station_name")]
        public string? StationName { get; set; }

        [JsonPropertyName("platform_number")]
        public double? Platform { get; set; }

        [JsonPropertyName("distance_from_source")]
        public double? Distance { get; set; }

        [JsonPropertyName("arrival_delay")]
        public double? ArrivalDelay { get; set; }

        [JsonPropertyName("a_day")]
        public double? ArrivalDay { get; set; }

        [JsonPropertyName("halt")]
        public double? Halt { get; set; }

        [JsonPropertyName("non_stops")]
        public List<NonStopStations> NonStopStations { get; set; } = [];
    }

    public class LiveTrainRes
    {
        [JsonPropertyName("destination")]
        public string? DestinationStation { get; set; }

        [JsonPropertyName("dest_stn_name")]
        public string? DestinationStationName { get; set; }

        [JsonPropertyName("update_time")]
        public string? UpdatedAt { get; set; }

        [JsonPropertyName("current_station_code")]
        public string? CurrentStation { get; set; }
        
        [JsonPropertyName("current_station_name")]
        public string? CurrentStationName { get; set; }

        [JsonPropertyName("train_name")]
        public string? TrainName { get; set; }

        [JsonPropertyName("train_number")]
        public int? TrainNo { get; set; }

        [JsonPropertyName("source")]
        public string? SourceStation { get; set; }

        [JsonPropertyName("source_stn_name")]
        public string? SourceStationName { get; set; }

        [JsonPropertyName("train_start_date")]
        public string? StartDate { get; set; }
        
        [JsonPropertyName("distance_from_source")]
        public double? DistanceFromSource { get; set; }

        [JsonPropertyName("total_distance")]
        public double? TotalDistance { get; set; }
        
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        
        [JsonPropertyName("new_message")]
        public string? NewMessage { get; set; }

        [JsonPropertyName("disclaimer")]
        public string? Disclaimer { get; set; }

        [JsonPropertyName("upcoming_stations")]
        public List<DaySchedule> UpcomingStations { get; set; } = [];

        [JsonPropertyName("previous_stations")]
        public List<DaySchedule> PreviousStations { get; set; } = [];

        [JsonPropertyName("delay")]
        public double? Delay { get; set; }

        [JsonPropertyName("bubble_message")]
        public BubbleMessage? BubbleMessage { get; set; }
        
        [JsonPropertyName("current_location_info")]
        public List<CurrnetLocationInfo?> CurrentLocationInfo { get; set; } = [];

        [JsonPropertyName("current_stn_sta")]
        public string? CurrentStationScheduleArrival { get; set; }
        
        [JsonPropertyName("current_stn_std")]
        public string? CurrentStationScheduleDeparture { get; set; }
        
        [JsonPropertyName("eta")]
        public string? CurrentStationArrival { get; set; }
        
        [JsonPropertyName("etd")]
        public string? CurrentStationDeparture { get; set; }
        
        [JsonPropertyName("next_stoppage_info")]
        public NextStoppageInfo? NextStoppageInfo { get; set; }
    }

    public class BubbleMessage
    {
        [JsonPropertyName("station_name")]
        public string? StationName { get; set; }

        [JsonPropertyName("message_type")]
        public string? MessageType { get; set; }
        
        [JsonPropertyName("station_time")]
        public string? StationTime { get; set; }
    }

    public class CurrnetLocationInfo
    {
        [JsonPropertyName("type")]
        public double? Type { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; }
        
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }

    public class NextStoppageInfo
    {
        [JsonPropertyName("next_stoppage")]
        public string? StationName { get; set; }
    }
}