using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GithubUserDetails.Models
{
  public class User
  {
    [Required]
    [DisplayName("Username")]
    [StringLength(50)]
    public String UserName { get; set; }

    public GithubDetails GithubDetails { get; set; }

    public string UserInformationUrl
    {
        get { return "https://api.github.com/users/" + UserName; }
    }

    public string RepoInformationUrl
    {
        get {  return "https://api.github.com/users/" + UserName + "/repos"; }
    }
  }
}
