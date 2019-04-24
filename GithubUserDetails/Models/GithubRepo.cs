using System;
namespace GithubUserDetails.Models
{
    public class GithubRepo
    {
       public string name { get; set; }
       public string html_url { get; set; }
       public int stargazers_count { get; set; }
    }
}
