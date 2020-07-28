using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Soccer.Models.LeagueModel;

namespace Soccer.Controllers.LeagueController
{
    public class LeaguesController : Controller
    {
        public IActionResult Index()
        {
            var league = new League();
            return View();
        }
    }
}
