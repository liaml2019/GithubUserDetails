using System;
using System.ComponentModel.DataAnnotations;

namespace GithubUserDetails.Models
{
  public class User
  {
    [Required]
    [StringLength(50)]
    public String UserName { get; set; } 
  }
}
