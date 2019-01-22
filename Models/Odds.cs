using System;
using System.Collections.Generic;

namespace BettingApi.Models
{
    public partial class Odds
    {
        public Odds()
        {
            CoefficientsFootballs = new HashSet<CoefficientsFootballs>();
            CoefficientsTennis = new HashSet<CoefficientsTennis>();
        }

        public int Id { get; set; }
        public string PairOne { get; set; }
        public string PairTwo { get; set; }
        public DateTime BeginingTime { get; set; }
        public string Tournament { get; set; }
        public string Sport { get; set; }

        public virtual ICollection<CoefficientsFootballs> CoefficientsFootballs { get; set; }
        public virtual ICollection<CoefficientsTennis> CoefficientsTennis { get; set; }
    }
}
