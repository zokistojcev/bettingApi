using System;
using System.Collections.Generic;

namespace BettingApi.Models
{
    public partial class CoefficientsFootballs
    {
        public int Id { get; set; }
        public int OddId { get; set; }
        public string CoefficientHost { get; set; }
        public string CoefficientDraw { get; set; }
        public string CoefficientVisitor { get; set; }
        public DateTime DateAndTime { get; set; }

        public virtual Odds Odd { get; set; }
    }
}
