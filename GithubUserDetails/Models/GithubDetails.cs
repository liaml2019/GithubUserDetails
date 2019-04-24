using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GithubUserDetails.Models
{
    public class GithubDetails
    {
       [DisplayName("Name: ")]
       public string name { get; set; }

        [DisplayName("Location: ")]
        public string location { get; set; }

        [DisplayName("Avatar URL: ")]
        public string avatar_url { get; set; }

        public List<GithubRepo> GithubRepositories { get; set; }

        public List<GithubRepo> TopFiveByStargazersCount()
        {
            if(GithubRepositories == null) { return new List<GithubRepo>(); }
            return GithubRepositories.OrderByDescending(i => i.stargazers_count).Take(5).ToList();
        }
    }
}
