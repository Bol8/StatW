using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Domain.Models
{
    public class ProgResultList
    {
        protected List<ProgResult> progResults { get; set; }


        #region Constructores

        public ProgResultList()
        {
            progResults = new List<ProgResult>();
        }

        #endregion


        #region públicos

        public void Add(ProgResult progResult)
        {
            progResults.Add(progResult);
        }

        public List<ProgResult> getList()
        {
            return progResults;
        }

        #endregion

    }
}
