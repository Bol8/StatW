using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Repository;
using Domain.Models;

namespace Domain.Manage
{
    public class gEquipo
    {
        private FootbalEntities db;
        private string Team;
        private List<Equipos> teamList;

        #region Constructores


        public gEquipo()
        {
            teamList = new List<Equipos>();
            db = new FootbalEntities();

        }

        public gEquipo(string Team)
        {
            teamList = new List<Equipos>();
            this.Team = Team;
            db = new FootbalEntities();
        }


        #endregion




        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }



        public Equipos getElement(long id)
        {
            throw new NotImplementedException();
        }

        public List<Equipos> getElements()
        {
            return db.Equipos.ToList();
        }

        public List<Equipos> getElements(string league)
        {
            return db.Equipos.Where(x => x.Liga.Equals(league)).ToList();
        }



        public bool save(Equipos input)
        {
            try
            {
                db.Equipos.Add(input);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        public bool exist(string Team)
        {
            var team = db.Equipos.Find(Team);

            return (team != null);
        }


        public bool update(Equipos input)
        {
            throw new NotImplementedException();
        }


        public List<Equipos> getTeamsFromMatchs(List<Partido> matchs)
        {
            var MatchsByLeagues = matchs.GroupBy(x => x.Liga).ToList();

            foreach (var leagues in MatchsByLeagues)
            {
                var Key = leagues.Key;

                foreach (var team in leagues.Select(x => x.HomeTeam).Distinct().ToList())
                {
                    Equipos equipo = new Equipos
                    {
                        Nombre = team,
                        Liga = Key
                    };

                    teamList.Add(equipo);
                }
            }

            return teamList;
        }


        public bool exist()
        {
            try
            {
                var team = db.Equipos.Find(Team);
            }
            catch (Exception)
            {
                return false;

            }

            return true;
        }


        //public bool exist(string Team)
        //{
        //    try
        //    {
        //        var team = db.Equipos.Find(Team);
        //        if (team == null) return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;

        //    }

        //    return true;
        //}

    }
}
