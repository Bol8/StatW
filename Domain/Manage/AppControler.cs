using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Manage;
using Repository;
using Domain.Models;
using Domain.Converters;

namespace Domain.Manage
{
    public class AppControler
    {
        private cEquipo cEquipo;
        private cPartido cPartido;

        #region Constructores

        public AppControler() { }


        #endregion


        public bool addTeams()
        {
            cPartido = new cPartido();
            var teams = cPartido.getTeams();

            cEquipo = new cEquipo();
            var isOk = cEquipo.addTeams(teams);


            return isOk;
        }



        public List<StatisticsTeam> TotalResults()
        {
            cEquipo = new cEquipo();

            var teams = cEquipo.getTeams();

            List<StatisticsTeam> list = new List<StatisticsTeam>();

            foreach (var team in teams)
            {
                cPartido = new cPartido(team.Nombre);
                list.Add(cPartido.getStatistics());
            }

            return list;
        }



        public List<StatisticsTeam> HomeResults()
        {
            cEquipo = new cEquipo();

            var teams = cEquipo.getTeams();

            List<StatisticsTeam> list = new List<StatisticsTeam>();

            foreach (var team in teams)
            {
                cPartido = new cPartido(team.Nombre);
                list.Add(cPartido.HomeTeamStatistics());
            }

            return list;
        }



        public List<StatisticsTeam> AwayResults()
        {
            cEquipo = new cEquipo();

            var teams = cEquipo.getTeams();

            List<StatisticsTeam> list = new List<StatisticsTeam>();

            foreach (var team in teams)
            {
                cPartido = new cPartido(team.Nombre);
                list.Add(cPartido.AwayTeamStatistics());
            }

            return list;
        }



        public List<Match> getMatchs(string Team)
        {
            cPartido = new cPartido(Team);

            return cPartido.getMatchs();
        }


        public Prognostic goPrognostic()
        {
            Prognostic prognostic = new Prognostic();

            return prognostic;
        }


        public ProgResult calculateShare(Prognostic prognostic)
        {
            ProgResult proRes = new ProgResult();

            switch (prognostic.result)
            {
                case "1":
                    cPartido = new cPartido(prognostic.HomeTeam);
                    var HomeStatistic = cPartido.HomeTeamStatistics();

                    cPartido = new cPartido(prognostic.AwayTeam);
                    var AwayStatistics = cPartido.AwayTeamStatistics();

                    proRes = getMatchPercent(HomeStatistic.PercentWins, AwayStatistics.PercentLoses,HomeStatistic.MatchesPlayed);

                    break;

                case "2":
                    cPartido = new cPartido(prognostic.HomeTeam);
                    var a = cPartido.HomeTeamStatistics();

                    cPartido = new cPartido(prognostic.AwayTeam);
                    var b = cPartido.AwayTeamStatistics();

                    proRes = getMatchPercent(a.PercentLoses, b.PercentWins,a.MatchesPlayed);

                    break;

                case "X":
                    cPartido = new cPartido(prognostic.HomeTeam);
                    var c = cPartido.HomeTeamStatistics();

                    cPartido = new cPartido(prognostic.AwayTeam);
                    var d = cPartido.AwayTeamStatistics();

                    proRes = getMatchPercent(c.PercentDraws, d.PercentDraws,c.MatchesPlayed);
                    
                    break;
            }
            
            return proRes;
        }

        public ProgResult calculateShare(Prognostic prognostic,int lastMatchs)
        {
            ProgResult proRes = new ProgResult();

            switch (prognostic.result)
            {
                case "1":
                    cPartido = new cPartido(prognostic.HomeTeam);
                    var HomeStatistic = cPartido.HomeTeamStatistics(lastMatchs);

                    cPartido = new cPartido(prognostic.AwayTeam);
                    var AwayStatistics = cPartido.AwayTeamStatistics(lastMatchs);

                    proRes = getMatchPercent(HomeStatistic.PercentWins, AwayStatistics.PercentLoses, lastMatchs);

                    break;

                case "2":
                    cPartido = new cPartido(prognostic.HomeTeam);
                    var a = cPartido.HomeTeamStatistics(lastMatchs);

                    cPartido = new cPartido(prognostic.AwayTeam);
                    var b = cPartido.AwayTeamStatistics(lastMatchs);

                    proRes = getMatchPercent(a.PercentLoses, b.PercentWins, lastMatchs);

                    break;

                case "X":
                    cPartido = new cPartido(prognostic.HomeTeam);
                    var c = cPartido.HomeTeamStatistics(lastMatchs);

                    cPartido = new cPartido(prognostic.AwayTeam);
                    var d = cPartido.AwayTeamStatistics(lastMatchs);

                    proRes = getMatchPercent(c.PercentDraws, d.PercentDraws, lastMatchs);

                    break;
            }

            return proRes;
        }


        #region métodos privados

        private ProgResult getMatchPercent(decimal homePercent, decimal awayPercent,int matchsPlayed)
        {
            var result = ((homePercent + awayPercent) / 2);
            var p = result / 100;
            var n = 10 / p;
            var share = n / 10;

            ProgResult prog = new ProgResult
            {
                MatchsPlayed = matchsPlayed,
                HomePercent = homePercent,
                AwayPercent = awayPercent,
                TotalPercent = result,
                Share = decimal.Round(share, 1, MidpointRounding.AwayFromZero)
            };

            return prog;
        }

        #endregion

    }
}
