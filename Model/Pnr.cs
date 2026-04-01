namespace irctc.Model
{
    public class PnrResponseModel
    {
        public bool Success { get; set; }
        public PnrModel? Data { get; set; }
    }
    public class PnrModel
    {
        public string? Pnr { get; set; }
        public string? Status { get; set; }
        public Train? Train { get; set; }
        public Journey? Journey { get; set; }
        public Chart? Chart { get; set; }
        public List<Passenger>? Passengers { get; set; }
        public string? LastUpdated { get; set; }
    }

    public class Chart
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
    }

    public class From
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Platform { get; set; }
    }

    public class Journey
    {
        public From? From { get; set; }
        public To? To { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public string? Duration { get; set; }
    }

    public class Passenger
    {
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Seat { get; set; }
        public string? BerthType { get; set; }
        public int ConfirmationProbability { get; set; }
    }

    public class To
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Platform { get; set; }
    }

    public class Train
    {
        public string? Number { get; set; }
        public string? Name { get; set; }
        public string? Class { get; set; }
    }
}