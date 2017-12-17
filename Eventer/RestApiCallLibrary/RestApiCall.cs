using Newtonsoft.Json;
using RestApiCallLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestApiCallLibrary
{
    public class RestApiCall
    {
        private HttpClient client;
        private Uri uri;
        private List<Category> CategoryItems;

        public RestApiCall(string uri_) {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            uri = new Uri(string.Format(uri_, string.Empty));
        }

        public List<Models.Category> GetCategoriesAsync()
        {
            CategoryItems = new List<Category>();

            // RestUrl = http://developer.xamarin.com:8081/api/todoitems

            try
            {
                var response = client.GetAsync(uri).GetAwaiter().GetResult();
                var content = response.Content.ReadAsStringAsync();
                CategoryItems = JsonConvert.DeserializeObject<List<Category>>(content.GetAwaiter().GetResult());
                return CategoryItems;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                    }
                    else
                    {
                        // no http status code available
                    }
                }
                else
                {
                    // no http status code available
                }
            }
            catch (Exception ex)
            {
                Debugger.Log(1, "Failed miserable", "complete miserable fail");
                //throw;

            }

            return CategoryItems;
        }

        public async Task<List<Models.Category>> FetchCategoriesAsync()
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "GET";
            CategoryItems = new List<Category>();

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {

                    CategoryItems = JsonConvert.DeserializeObject<List<Category>>(stream.ToString());

                    // Return the JSON document:
                    return CategoryItems;
                }
            }
        }
    }
}
