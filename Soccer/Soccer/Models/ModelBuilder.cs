using Soccer.Models.LeagueModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Soccer.Models
{
    public class ModelBuilder
    {
        public static List<T> ConvertFromDataTable<T>(DataTable table) where T : League
        {

            List<T> list = new List<T>();
            for(int i=0; i<table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];
                list.Add((T)new League()
                {
                    league = dr["league"].ToString(),
                    teams_no = Int32.Parse(dr["teams_no"].ToString()),
                    date = dr["date"].ToString(),
                    home_team = dr["home_team"].ToString(),
                    away_team = dr["away_team"].ToString(),
                    result = dr["RESULT"].ToString(),
                    h_final = dr["h_final"].ToString(),
                    a_final = dr["a_final"].ToString(),
                    h_half = dr["h_half"].ToString(),
                    a_half = dr["a_half"].ToString(),
                    H1H = dr["H1H"].ToString(),
                    A1H = dr["A1H"].ToString(),
                    H2H = dr["H2H"].ToString(),
                    A2H = dr["A1H"].ToString()
                });
            }
            return list;
        }
    }
  
}
