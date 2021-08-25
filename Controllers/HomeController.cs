using Microsoft.AspNetCore.Mvc;
using System;
using JWT.Algorithms;
using JWT.Builder;
using dotnet_test.Models;

namespace dotnet_test.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      var PRIVATE_KEY = "YOUR_PRIVATE_KEY";
      var EMBED_ID = "YOUR_EMBED_ID";

      var token = JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(PRIVATE_KEY)
                .AddClaim("embed", EMBED_ID)
                .AddClaim("sub", "maire@flatfile.io")
                .Encode();

      var model = new IndexViewModel()
      {
        Token = token
      };

      return View(model);
    }
  }
}
