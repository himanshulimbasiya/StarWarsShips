using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWars
{
    public class ApiProcessor
    {
        public static async Task<IList<Starships>> ApiCall()
        {
            HttpResponseMessage response;
            string responseBody;
            IList<Starships> starShipList = new List<Starships>();
            Console.WriteLine("Getting data from APIs");
            //Getting all starships from APIs
            for (var i = 1; i <= 4; i++)
            {
                using (var client = new HttpClient())
                {
                    response = await client.GetAsync("https://swapi.co/api/starships/?page=" + i);
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        responseBody = await response.Content.ReadAsStringAsync();
                        //getting response as JSON
                        JObject myJObject = JObject.Parse(responseBody);
                        //parsing JSON object to get required array of Starships
                        JArray results = (JArray)myJObject["results"];
                        foreach (var item in results)
                        {
                            try
                            {
                                //Adding Starship to a list of Starships
                                starShipList.Add(item.ToObject<Starships>());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                        }
                    }
                }
            }
            Console.WriteLine("Recieved data from APIs successfully");
            return starShipList;
        }
    }
}
