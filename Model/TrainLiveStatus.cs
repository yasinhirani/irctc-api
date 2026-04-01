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
}