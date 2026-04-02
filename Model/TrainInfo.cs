using System.Text.Json.Serialization;

namespace irctc.Model
{
    public class TrainInfo
    {
        public string? TrainNo { get; set; }
        public string? TrainName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TrainId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SourceStnName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SourceStnCode { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DstnStnName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DstnStnCode { get; set; }
        public string? FromStnName { get; set; }
        public string? FromStnCode { get; set; }
        public string? ToStnName { get; set; }
        public string? ToStnCode { get; set; }
        public string? FromTime { get; set; }
        public string? ToTime { get; set; }
        public string? TravelTime { get; set; }
        public string? RunningDays { get; set; }
        public string? TrainType { get; set; }
        public string? Distance { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Halts { get; set; }
        public List<TrainRoute> Route { get; set; } = [];
    }

    public class TrainRoute
    {
        public string? StationName { get; set; }
        public string? StationCode { get; set; }
        public string? Arrival { get; set; }
        public string? Departure { get; set; }
        public string? Distance { get; set; }
        public string? Day { get; set; }
        public string? Platform { get; set; }
    }
}