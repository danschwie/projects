using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteCarloEngine.Models
{
    public enum TimeHorizonUnit
    {
        Day,
        Week,
        Month,
        Year
    }

    public class ConfigurationModel
    {
        public TimeHorizonUnit TimeHorizonUnit { get; set; }

        public decimal FluxFloor { get; set; }

        public decimal FluxCeiling { get; set; }

        public decimal InitialInvestment { get; set; }

        public int TimeHorizon { get; set; }
    }
}