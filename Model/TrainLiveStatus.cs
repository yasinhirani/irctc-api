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

    public class DaySchedule
    {
        [JsonPropertyName("sch_arrival_date")]
        public string? ArrivalDate { get; set; }

        [JsonPropertyName("sch_arrival_time")]
        public string? ArrivalTime { get; set; }

        [JsonPropertyName("sch_departure_date")]
        public string? DepartureDate { get; set; }

        [JsonPropertyName("sch_departure_time")]
        public string? DepartureTime { get; set; }

        [JsonPropertyName("actual_arrival_date")]
        public string? ActualArrivalDate { get; set; }

        [JsonPropertyName("actual_arrival_time")]
        public string? ActualArrivalTime { get; set; }

        [JsonPropertyName("actual_departure_date")]
        public string? ActualDepartureDate { get; set; }

        [JsonPropertyName("actual_departure_time")]
        public string? ActualDepartureTime { get; set; }

        [JsonPropertyName("station_code")]
        public string? StationCode { get; set; }

        // [JsonPropertyName("delay_in_departure")]
        // public int? DelayInDeparture { get; set; } = null;

        [JsonPropertyName("stops")]
        public bool Stops { get; set; }

        [JsonPropertyName("platform")]
        public string? Platform { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("delay_in_departure")]
        public double? DelayInDeparture { get; set; }

        [JsonPropertyName("departed")]
        public bool Departed { get; set; } = false;

        [JsonPropertyName("station_name")]
        public string? StationName { get; set; }
    }

    public class LiveTrainRes
    {
        [JsonPropertyName("destination_station")]
        public string? DestinationStation { get; set; }

        [JsonPropertyName("destination_station_name")]
        public string? DestinationStationName { get; set; }

        [JsonPropertyName("lastUpdateIsoDate")]
        public DateTime LastUpdateIsoDate { get; set; }

        [JsonPropertyName("curStn")]
        public string? CurStn { get; set; }

        [JsonPropertyName("train_type")]
        public string? TrainType { get; set; }

        [JsonPropertyName("train_name")]
        public string? TrainName { get; set; }

        [JsonPropertyName("train_no")]
        public int? TrainNo { get; set; }

        [JsonPropertyName("source_station")]
        public string? SourceStation { get; set; }

        [JsonPropertyName("source_station_name")]
        public string? SourceStationName { get; set; }

        [JsonPropertyName("start_date")]
        public string? StartDate { get; set; }

        [JsonPropertyName("days_schedule")]
        public List<DaySchedule> Stations { get; set; } = [];
    }


}