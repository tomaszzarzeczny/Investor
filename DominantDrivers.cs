namespace Investor
{
    internal class DominantDrivers
    {
        
        private double productivity;
        private double debtLevel;
        private GlobalTrade globalTrade;
        private MonetaryPolicyType monetaryPolicy;
        public List<DominantDriversType> dominantDrivers;

        public DominantDrivers(double productivityGrowth, double debtLevel, GlobalTrade globalTrade, MonetaryPolicyType monetaryPolicy) 
        { 
            this.productivity = productivityGrowth;
            this.debtLevel = debtLevel;
            this.globalTrade = globalTrade;
            this.monetaryPolicy = monetaryPolicy;
            dominantDrivers = IdentifyDominantDrivers();
        }
        public List<DominantDriversType> IdentifyDominantDrivers()
        {
            const double PRODUCTIVITY_THRESHOLD = 0.5;
            const double DEBT_HIGH_THRESHOLD = 100;
            const double DEBT_LOW_THRESHOLD = 60;

            // Analyze the data to determine the dominant drivers of the economy
            // TOOD: look not only at the current values but also at the trends
            List<DominantDriversType> dominantDrivers = new List<DominantDriversType>();

            if (productivity >= PRODUCTIVITY_THRESHOLD)
            {
                dominantDrivers.Add(DominantDriversType.ProductivityGrowth);
            }
            if (productivity < PRODUCTIVITY_THRESHOLD)
            {
                dominantDrivers.Add(DominantDriversType.ProductivityDecline);
            }
            if (debtLevel >= DEBT_HIGH_THRESHOLD)
            {
                dominantDrivers.Add(DominantDriversType.DebtLevelHigh);
            }
            if (debtLevel < DEBT_LOW_THRESHOLD)
            {
                dominantDrivers.Add(DominantDriversType.DebtLevelLow);
            }
            if (globalTrade == GlobalTrade.Stable)
            {
                dominantDrivers.Add(DominantDriversType.GlobalTradeStable);
            }
            if (globalTrade == GlobalTrade.Unstable)
            {
                dominantDrivers.Add(DominantDriversType.GlobalTradeUnstable);
            }
            if (monetaryPolicy == MonetaryPolicyType.Accommodative)
            {
                dominantDrivers.Add(DominantDriversType.MonetaryPolicyAccommodative);
            }
            if (monetaryPolicy == MonetaryPolicyType.Tight)
            {
                dominantDrivers.Add(DominantDriversType.MonetaryPolicyTight);
            }
            return dominantDrivers;
        }
    }

    public enum DebtLevels
    {
        Low,
        High
    }

    public enum GlobalTrade
    {
        Stable,
        Unstable
    }

    public enum DominantDriversType
    {
        ProductivityGrowth,
        ProductivityDecline,
        DebtLevelHigh,
        DebtLevelLow,
        GlobalTradeStable,
        GlobalTradeUnstable,
        MonetaryPolicyAccommodative,
        MonetaryPolicyTight,
    }
}
