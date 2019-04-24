using System;
using System.Net;
using Newtonsoft.Json;

namespace GithubUserDetails.Helpers
{
    public class BaseApiHelper
    {
        public BaseApiHelper(string url)
        {
            this.ApiUrl = url;
        }

        public string ApiUrl { get; set; }

        // Download Content from the provided URL. Then Deserialize the object
        // using the supplied Type (provided from UsersController).
        public T DownloadContentAndSerialize<T>()
        {
            var client = new WebClient();
            client.Headers.Add("User-Agent", "Nothing");
            var content = client.DownloadString(ApiUrl);
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
