using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace KaffaTest
{

    class WorldClockRestServer
    {
        class TimeDataDateOnly
        {
            public String currentDateTime { get; set; }
        }

        class TimeData
        {
            public String currentDateTime { get; set; }
            public String utcOffset { get; set; }
            public String isDayLightSavingsTime { get; set; }
            public String dayOfTheWeek { get; set; }
            public String timeZoneName { get; set; }
            public String currentFileTime { get; set; }
            public String ordinalDate { get; set; }
            public String serviceResponse { get; set; }
        }

        private string url = "http://worldclockapi.com/api/json/utc/now";

        public void main()
        {
            //Deserialize the json
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<TimeData>(getTimeData().Result);
            //Create a new json using only the currentDateTime field and show it formatted like a json
            TimeDataDateOnly timeDataDateOnly = new TimeDataDateOnly();
            timeDataDateOnly.currentDateTime = data.currentDateTime;
            var test = Newtonsoft.Json.JsonConvert.SerializeObject(timeDataDateOnly, Formatting.Indented);
            Console.WriteLine(test);
        }

        private async Task<String> getTimeData()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
