using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace KaffaTest
{

    class WorldClockRestClient
    {
        class TimeData
        {
            [JsonProperty("currentDateTime")]
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
            //Deserialize the json and get the date and time formatted
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<TimeData>(getTimeData().Result);
            string dateFormatted = String.Format("Date: {0}/{1}/{2}\nTime: {3}",
                data.currentDateTime.Substring(8, 2),
                data.currentDateTime.Substring(5, 2),
                data.currentDateTime.Substring(0, 4),
                data.currentDateTime.Substring(11, 5));
            string utc = data.utcOffset;
            Console.WriteLine(dateFormatted + "\nUTC offset: " + utc);
        }

        private async Task<String> getTimeData()
        {
            //Access the url and get the result as a string
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
