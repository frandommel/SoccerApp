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
            bool encontrado = false;
            DataList listDataModel = new DataList{ listLeagueData = new List<League>() };
            listDataModel.listLeagueData = getData(listLeague);   //Metodo que me devuelve una lista a partir de un dataTable

            //logica para realizar la paginacion

            totalRegistros = listDataModel.listLeagueData.Count;
            var totalPaginas = (int)Math.Ceiling((double)totalRegistros / registroPagina);
            if (!string.IsNullOrEmpty(buscar))
            {
                    for (int i = 0; i < totalRegistros; i++)
                    {
                        string buscadoHome = listDataModel.listLeagueData[i].home_team.ToLower();
                        string buscadoAway = listDataModel.listLeagueData[i].away_team.ToLower();
                        if (buscadoHome.Contains(buscar.Trim().ToLower()))
                            {
                                listLeague.Add(listDataModel.listLeagueData[i]);
                            }
                        if (buscadoAway.Contains(buscar.Trim().ToLower()))
                        {
                            listLeague.Add(listDataModel.listLeagueData[i]);
                        }
                    }
                encontrado = true;
                totalRegistros = listLeague.Count;
                registroPagina = totalRegistros;
            } else {
              
                if (pagina - 1 == 0)
                {
                    for (int i = 0; i < registroPagina; i++)
                    {
                        listLeague.Add(listDataModel.listLeagueData[i]);
                    }
                }else
                {
                    for (int i = ((pagina) *registroPagina)-(registroPagina); i < (pagina) * registroPagina; i++)
                    {
                        listLeague.Add(listDataModel.listLeagueData[i]);
                    }
                }

            }
            //Clase Paginador, para enviar informacion a la vista.
            paginadorLeague = new Paginador<League>()
            {
                RegistroPorPagina = registroPagina,
                TotalRegistros = totalRegistros,
                TotalPaginas = totalPaginas,
                PaginaActual = pagina,
                Resultado = listLeague, 
                Buscado = encontrado, 
                BusquedaActual = buscar  //dato que me sirve en la vista para agregarle estilos a la tabla
            };

            return View(paginadorLeague);
        }
        //paso el contenido de un json a una dataSet para armar la lista
        public List<League> getData(List<League> listLeague)
        {
            string fileJson = System.IO.File.ReadAllText("Content/data.json");
            DataSet ds = (DataSet)JsonConvert.DeserializeObject(fileJson, typeof(DataSet));
            return ModelBuilder.ConvertFromDataTable<League>(ds.Tables[0]);  //Metodo statico que construye una list a partir de una tabla
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

