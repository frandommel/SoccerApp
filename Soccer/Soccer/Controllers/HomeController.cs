using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Soccer.Models;
using Soccer.Models.LeagueModel;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.InkML;
using Newtonsoft.Json.Linq;

namespace Soccer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            List<League> listLeague = new List<League>();
            DataList listDataModel = new DataList{ listLeagueData = new List<League>() };

            listDataModel.listLeagueData = getData(listLeague);   //get data from json a build de model into DataList class

            return View(listDataModel);
        }

        public List<League> getData(List<League> listLeague)
        {
            string fileJson = System.IO.File.ReadAllText(@"C:\Users\Francisco\source\repos\SoccerApp\Soccer\Soccer\Content\data.json");
            DataSet ds = (DataSet)JsonConvert.DeserializeObject(fileJson, typeof(DataSet));

            return ModelBuilder.ConvertFromDataTable<League>(ds.Tables[0]);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

