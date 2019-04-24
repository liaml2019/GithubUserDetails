using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GithubUserDetails.Helpers;
using GithubUserDetails.Models;
using Newtonsoft.Json;

namespace GithubUserDetails.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Search(User model)
        {
            try {
              if(ModelState.IsValid) {
                var baseApiHelper = new BaseApiHelper(model.UserInformationUrl);
                model.GithubDetails = baseApiHelper.DownloadContentAndSerialize<GithubDetails>();

                baseApiHelper.ApiUrl = model.RepoInformationUrl;
                model.GithubDetails.GithubRepositories = baseApiHelper.DownloadContentAndSerialize<List<GithubRepo>>();
              }
              return View("Index", model);
            } catch {
                return View ("Index", model);
            }
        }
    }
}