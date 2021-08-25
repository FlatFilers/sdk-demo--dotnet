using Microsoft.AspNetCore.Mvc;
using JWT.Algorithms;
using JWT.Builder;
using FlatfileDotNet.Models;

namespace FlatfileDotNet.Models
{
    public class IndexViewModel
    {
        public string Token { get; set; }
    }
}

namespace FlatfileDotNet.Controllers
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
