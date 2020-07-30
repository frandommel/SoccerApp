using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccer.Models.LeagueModel
{
    public class DataList
    {
        public List<League> listLeagueData { get; set; }
    }
    public class League
    {
        public string league { get; set; }
        public int? teams_no { get; set; }
        public string date { get; set; }
        public string home_team { get; set; }
        public string away_team { get; set; }
        public string result { get; set; }
        public string h_final { get; set; }
        public string a_final { get; set; }
        public string h_half { get; set; }
        public string a_half { get; set; }
        public string H1H { get; set; }
        public string A1H { get; set; }
        public string H2H { get; set; }
        public string A2H { get; set; }
        public League(string league,int teams_no, string date, string home_team, string away_team, string result,
                      string h_final, string a_final, string h_half, string a_half, string H1H, string A1H, string H2H, string A2H)
        {
            this.league = league;
            this.teams_no = teams_no;
            this.date = date;
            this.home_team = home_team;
            this.away_team = away_team;
            this.result = result;
            this.h_final = h_final;
            this.a_final = a_final;
            this.h_half = h_half;
            this.a_half = a_half;
            this.H1H = H1H;
            this.A1H = A1H;
            this.H2H = H2H;
            this.A2H = A2H;
        }
        public League(){}

    }

}
//Los datos son:
//- Columna A: "league", nombre de la liga en la que se jugó el partido
//- Columna B: "teams_no", la cantidad de equipos que participaban de esa liga.
//- Columna C: "date", fecha en la que se jugó el partido, en formato mes/día/año.
//- Columna D: "home_team", nombre del equipo local.
//- Columna E: "away_team", nombre del equipo visitante.
//- Columna F: "RESULT", resultado del partido. "HOME" significa que ganó el equipo local, "AWAY" el visitante, "DRAW" que se empató.
//- Columna G: "h_final", cuántos goles tuvo el equipo local al final del partido.
//- Columna H: "a_final", cuántos goles tuvo el equipo visitante al final del partido.
//- Columna I: "h_half", cuántos goles metió el equipo local en el tiempo extra (si es que hubo).
//- Columna J: "a_half", cuántos goles metió el equipo visitante en el tiempo extra(si es que hubo).
//- Columna K: "H1H", cuántos goles metió el equipo local en la primera mitad.
//- Columan L: "A1H", cuántos goles metió el equipo visitante en la primera mitad.
//- Columna M: "H2H", cuántos goles metió el equipo local en la segunda mitad.
//- Columan N: "A2H", cuántos goles metió el equipo visitante en la segunda mitad.