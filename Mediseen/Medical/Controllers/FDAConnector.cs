using Medical.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Medical.Controllers
{
    public class FDAConnector
    {
        static readonly HttpClient client = new HttpClient();

        static readonly string url = "https://api.fda.gov/drug/event.json?search=patient.reaction.reactionmeddrapt.exact:{0}&count=patient.drug.activesubstance.activesubstancename.exact";

        public static ReactionCount GetReactionCount(string reaction)
        {

            HttpResponseMessage response = client.GetAsync(String.Format(url, reaction)).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<ReactionCount>(responseBody);

            return result;

        }

    }
}