using HtmlAgilityPack;
using irctc.Model;
using todo.Exceptions;

namespace irctc.Utility
{
    public class ParseTrainData
    {
        public List<TrainInfo> ParseTrainBetweenStations(string data)
        {
            var trains = new List<TrainInfo>();

            var rawData = data.Split("~~~~~~~~").Where(d => d.Trim() != "").ToArray();

            if (rawData[0] == "~~~~~From station not found")
            {
                throw new NotFoundException("From station not found");
            }

            if (rawData[0] == "~~~~~To station not found")
            {
                throw new NotFoundException("To station not found");
            }

            if (rawData[0].Contains("~No direct trains found"))
            {
                throw new NotFoundException("No direct trains found");
            }

            for (int i = 0; i < rawData.Length - 1; i++)
            {
                var trainData = rawData[i].Split("~^");
                var otherDetails = (rawData[i + 1] ?? "").Split("~^");

                if (trainData.Length == 2)
                {
                    var trainDetails = trainData[1].Split("~");
                    var trainMiscDetails = otherDetails[0].Split("~").Where(d => d.Trim() != "").ToArray();

                    if (trainDetails.Length >= 14)
                    {
                        trains.Add(new TrainInfo
                        {
                            TrainNo = trainDetails[0],
                            TrainName = trainDetails[1],
                            SourceStnName = trainDetails[2],
                            SourceStnCode = trainDetails[3],
                            DstnStnName = trainDetails[4],
                            DstnStnCode = trainDetails[5],
                            FromStnName = trainDetails[6],
                            FromStnCode = trainDetails[7],
                            ToStnName = trainDetails[8],
                            ToStnCode = trainDetails[9],
                            FromTime = trainDetails[10].Replace(".", ":"),
                            ToTime = trainDetails[11].Replace(".", ":"),
                            TravelTime = trainDetails[12].Replace(".", ":") + " hrs",
                            RunningDays = trainDetails[13],
                            TrainType = trainMiscDetails[11].Replace("_", "/"),
                            Distance = trainMiscDetails.Length > 18 && trainMiscDetails[18] != null ? trainMiscDetails[18] : "N/A",
                            Halts = Convert.ToInt32(trainMiscDetails[7]) - Convert.ToInt32(trainMiscDetails[4]) - 1
                        });
                    }
                }
            }

            return trains;
        }
        public TrainInfo? ParseTrainInfo(string data)
        {
            if (data == "~~~~~Train not found")
            {
                throw new Exception("Train not found");
            }

            var rawData = data.Split("~~~~~~~~").Where(d => d.Trim() != "").ToArray();

            var trainDetails = rawData[0].Split("~^")[1].Split("~");
            var otherDetails = rawData[1].Split("~");

            var trainInfo = new TrainInfo
            {
                TrainNo = trainDetails[0],
                TrainName = trainDetails[1],
                FromStnName = trainDetails[2],
                FromStnCode = trainDetails[3],
                ToStnName = trainDetails[4],
                ToStnCode = trainDetails[5],
                FromTime = trainDetails[10].Replace(".", ":"),
                ToTime = trainDetails[11].Replace(".", ":"),
                TravelTime = trainDetails[12].Replace(".", ":"),
                TrainType = otherDetails[11],
                Distance = otherDetails[18],
                RunningDays = trainDetails[13]
            };

            return trainInfo;
        }
        public List<LiveStationAt> ParseLiveStationAt(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var trains = new List<LiveStationAt>();

            var nodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'name')]");

            if (nodes is not null)
            {
                foreach (var node in nodes)
                {
                    var route = node.SelectNodes("./following-sibling::div[1]")[0].InnerText.Trim().Split("&#8594;");
                    var time = node.ParentNode.SelectNodes("./following-sibling::td[1]")[0].InnerText.Trim();

                    trains.Add(new LiveStationAt
                    {
                        TrainNo = node.InnerText.Trim().Substring(0, 5),
                        TrainName = node.InnerText.Trim().Substring(5).Trim(),
                        Source = route[0].Replace("&nbsp;", "").Trim() ?? "N/A",
                        Dest = route[1].Trim() ?? "N/A",
                        TimeAt = time
                    });
                }
            }

            return trains;
        }
    }
}