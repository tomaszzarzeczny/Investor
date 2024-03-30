namespace Investor
{
    internal class EconomicCycle
    {
        private Vector GdpGrowth;
        private Vector InflationRate;
        private MonetaryPolicyType MonetaryPolicy;
        private MonetaryPolicy MP;
        public EconomicCycleType Type;

        public EconomicCycle(Vector gdpGrowth, Vector inflationRate, MonetaryPolicy monetaryPolicy)
        {
            GdpGrowth = gdpGrowth;
            InflationRate = inflationRate;
            MP = monetaryPolicy;
            MonetaryPolicy = monetaryPolicy.Type;
            Type = DetermineEconomicCycle();
        }
        private EconomicCycleType DetermineEconomicCycle()
        {
            EconomicCycleType economicCycle = EconomicCycleType.Unknown;
            const double GDP_HIGH_THRESHOLD = 1.7;
            const double GDP_LOW_THRESHOLD = 1;

            // Check general conditions to determine economic cycle
            if (GdpGrowth.Trend == Trend.Rising && GdpGrowth.Value <= GDP_HIGH_THRESHOLD && InflationRate.Trend == Trend.Rising 
                && (MonetaryPolicy == MonetaryPolicyType.Tight || MonetaryPolicy == MonetaryPolicyType.Hawkish))
            {
                economicCycle = EconomicCycleType.Expansion;
            }
            else if (GdpGrowth.Trend == Trend.Rising && GdpGrowth.Value > GDP_HIGH_THRESHOLD && InflationRate.Trend == Trend.Rising
                && (MonetaryPolicy == MonetaryPolicyType.Dovish || MonetaryPolicy == MonetaryPolicyType.Tight))
            {
                economicCycle = EconomicCycleType.Peak;
            }
            else if (GdpGrowth.Trend == Trend.Falling && InflationRate.Trend == Trend.Falling
                 && (MonetaryPolicy == MonetaryPolicyType.Tight || MonetaryPolicy == MonetaryPolicyType.Hawkish))
            {
                economicCycle = EconomicCycleType.Recession;
            }
            else if (GdpGrowth.Trend == Trend.Falling && InflationRate.Trend == Trend.Falling
                && (MonetaryPolicy == MonetaryPolicyType.Dovish || MonetaryPolicy == MonetaryPolicyType.Accommodative))
            {
                economicCycle = EconomicCycleType.Depression;
                if (MP.IsQE || GdpGrowth.Value < GDP_LOW_THRESHOLD)
                {
                    economicCycle = EconomicCycleType.Trough;
                }
            }
            else if (GdpGrowth.Trend == Trend.Rising && MonetaryPolicy == MonetaryPolicyType.Accommodative)
            {
                economicCycle = EconomicCycleType.Recovery;
            }

            // Handle special cases case by case
            if (economicCycle == EconomicCycleType.Unknown)
            {
                if (GdpGrowth.Value > GDP_HIGH_THRESHOLD
                && (MonetaryPolicy == MonetaryPolicyType.Dovish || MonetaryPolicy == MonetaryPolicyType.Tight))
                {
                    economicCycle = EconomicCycleType.Peak;
                }
                else
                {
                    economicCycle = EconomicCycleType.Unknown;
                }
            }

            return economicCycle;
        }
    }
}
