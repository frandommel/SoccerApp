using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccer.Models.LeagueModel
{
    public class League
    {
        public string league { get; set; }
        public int? teams_no { get; set; }
        public string date { get; set; }
        public string home_team { get; set; }
        public string away_team { get; set; }
        public string result { get; set; }
        public int? h_final { get; set; }
        public int? a_final { get; set; }
        public int? h_half { get; set; }
        public int? a_half { get; set; }
        public int? h1h { get; set; }
        public int? a1h { get; set; }
        public int? h2h { get; set; }
        public int? a2h { get; set; }
        public League(string league,int teams_no, string date, string home_team, string away_team, string result,
                      int h_final, int a_final, int h_half, int a_half, int h1h, int a1h, int h2h, int a2h)
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
            this.h1h = h1h;
            this.a1h = a1h;
            this.h2h = h2h;
            this.a2h = a2h;
        }
        public League()
        {
        }
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