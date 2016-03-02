using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Repository;

namespace Domain.Manage
{
    public class gEquipo : ICrud<Equipos>
    {
        private FootbalEntities db;
        private string Team;

        #region Constructores

        public gEquipo()
        {
            db = new FootbalEntities();

        }

        public gEquipo(string Team)
        {
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



        public bool update(Equipos input)
        {
            throw new NotImplementedException();
        }


        public List<string> getTeams(List<Partido> matchs)
        {
            var teams = matchs.Select(x => x.HomeTeam).Distinct().ToList();

            return teams;
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


        public bool exist(string Team)
        {
            try
            {
                var team = db.Equipos.Find(Team);
                if (team == null) return false;
            }
            catch (Exception)
            {
                return false;

            }

            return true;
        }

    }
}
