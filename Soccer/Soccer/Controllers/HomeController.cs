using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Soccer.Models;
using Soccer.Models.LeagueModel;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Soccer.Models.Paginador;
using System;

namespace Soccer.Controllers
{
    public class HomeController : Controller
    {
        private List<League> listLeague = new List<League>();
        private Paginador<League> paginadorLeague;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string buscar,int pagina = 1)
        {
            int totalRegistros = 0;
            int registroPagina = 60;
            DataList listDataModel = new DataList{ listLeagueData = new List<League>() };
            listDataModel.listLeagueData = getData(listLeague);   //get data from json a build de model into DataList class

            //logica para realizar la paginacion
            totalRegistros = listDataModel.listLeagueData.Count;
            var totalPaginas = (int)Math.Ceiling((double)totalRegistros / registroPagina);
            if (!string.IsNullOrEmpty(buscar))
            {
                    for (int i = 0; i < totalRegistros; i++)
                    {
                    string buscado = listDataModel.listLeagueData[i].home_team.ToLower();
                        if (buscado.Contains(buscar.Trim().ToLower()))
                        {
                            listLeague.Add(listDataModel.listLeagueData[i]);
                        }
                         registroPagina = listLeague.Count;
                    }
            } else {
             
                if (pagina - 1 == 0)
                {
                    for (int i = 0; i < registroPagina; i++)
                    {
                        listLeague.Add(listDataModel.listLeagueData[i]);
                    }
                }
                for (int i = 0; i < (pagina - 1) * registroPagina; i++)
                {
                    listLeague.Add(listDataModel.listLeagueData[i]);
                }
            }
            paginadorLeague = new Paginador<League>()
            {
                RegistroPorPagina = registroPagina,
                TotalRegistros = totalRegistros,
                TotalPaginas = totalPaginas,
                PaginaActual = pagina,
                Resultado = listLeague         
            };

            return View(paginadorLeague);
        }

        public List<League> getData(List<League> listLeague)
        {
            string fileJson = System.IO.File.ReadAllText("Content/data.json");
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

