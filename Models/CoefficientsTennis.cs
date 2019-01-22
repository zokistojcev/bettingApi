using System;
using System.Collections.Generic;

namespace BettingApi.Models
{
    public partial class CoefficientsTennis
    {
        public int Id { get; set; }
        public int OddId { get; set; }
        public string CoefficientFirst { get; set; }
        public string CoefficientSecond { get; set; }
        public DateTime DateAndTime { get; set; }

        public virtual Odds Odd { get; set; }
    }
}
