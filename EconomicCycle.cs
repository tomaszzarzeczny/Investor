namespace Investor
{
    internal class EconomicCycle
    {
        private double gdpGrowthRateNum;
        private string gdpGrowthRateCh;
        private string inflationRateCh;
        private MonetaryPolicyType monetaryPolicy;
        private MonetaryPolicy mp;
        public EconomicCycleType type;

        public EconomicCycle(double gdpGrowthRateNum, string gdpGrowthRateCh, string inflationRateCh, MonetaryPolicy monetaryPolicy)
        {
            this.gdpGrowthRateCh = gdpGrowthRateCh;
            this.gdpGrowthRateNum = gdpGrowthRateNum;
            this.inflationRateCh = inflationRateCh;
            this.mp = monetaryPolicy;
            this.monetaryPolicy = monetaryPolicy.type;
            type = DetermineEconomicCycle();

        }
        private EconomicCycleType DetermineEconomicCycle()
        {
            EconomicCycleType economicCycle = EconomicCycleType.Unknown;
            const double GDP_HIGH_THRESHOLD = 1.7;
            const double GDP_LOW_THRESHOLD = 1;


            // Check general conditions to determine economic cycle
            if (gdpGrowthRateCh == "rising" && gdpGrowthRateNum <= GDP_HIGH_THRESHOLD && inflationRateCh == "rising" 
                && (monetaryPolicy == MonetaryPolicyType.Tight || monetaryPolicy == MonetaryPolicyType.Hawkish))
            {
                economicCycle = EconomicCycleType.Expansion;
            }
            else if (gdpGrowthRateCh == "rising" && gdpGrowthRateNum > GDP_HIGH_THRESHOLD && inflationRateCh == "rising" 
                && (monetaryPolicy == MonetaryPolicyType.Dovish || monetaryPolicy == MonetaryPolicyType.Tight))
            {
                economicCycle = EconomicCycleType.Peak;
            }
            else if (gdpGrowthRateCh == "falling" && inflationRateCh == "falling"
                 && (monetaryPolicy == MonetaryPolicyType.Tight || monetaryPolicy == MonetaryPolicyType.Hawkish))
            {
                economicCycle = EconomicCycleType.Recession;
            }
            else if (gdpGrowthRateCh == "falling" && inflationRateCh == "falling"
                && (monetaryPolicy == MonetaryPolicyType.Dovish || monetaryPolicy == MonetaryPolicyType.Accommodative))
            {
                economicCycle = EconomicCycleType.Depression;
                if (mp.isQE || gdpGrowthRateNum < GDP_LOW_THRESHOLD)
                {
                    economicCycle = EconomicCycleType.Trough;
                }
            }
            else if (gdpGrowthRateCh == "rising" && monetaryPolicy == MonetaryPolicyType.Accommodative)
            {
                economicCycle = EconomicCycleType.Recovery;
            }

            // Handle special cases case by case
            if (economicCycle == EconomicCycleType.Unknown)
                {
                    if (gdpGrowthRateNum > GDP_HIGH_THRESHOLD
                    && (monetaryPolicy == MonetaryPolicyType.Dovish || monetaryPolicy == MonetaryPolicyType.Tight))
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

    public enum EconomicCycleType
    {
        Expansion,
        Peak,
        Recession,
        Depression,
        Recovery,
        Trough,
        Unknown
    }
}
