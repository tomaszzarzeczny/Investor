namespace Investor
{
    internal class DominantDrivers
    {
        private Vector Productivity;
        private Vector UnemploymentRate;
        private double DebtLevel;
        private GlobalTrade GlobalTrade;
        private MonetaryPolicyType MonetaryPolicy;
        public List<DominantDriversType> Drivers;

        public DominantDrivers(Vector productivityGrowth, double debtLevel, GlobalTrade globalTrade, MonetaryPolicy monetaryPolicy, Vector unemploymentRate) 
        { 
            Productivity = productivityGrowth;
            UnemploymentRate = unemploymentRate;
            DebtLevel = debtLevel;
            GlobalTrade = globalTrade;
            MonetaryPolicy = monetaryPolicy.Type;
            Drivers = IdentifyDominantDrivers();
        }

        private List<DominantDriversType> IdentifyDominantDrivers()
        {
            const double PRODUCTIVITY_THRESHOLD = 0.5;
            const double DEBT_HIGH_THRESHOLD = 100;
            const double DEBT_LOW_THRESHOLD = 60;
            const double UNEMPLOYMENT_HIGH_THRESHOLD = 6.5;
            const double UNEMPLOYMENT_LOW_THRESHOLD = 5.3;

            List<DominantDriversType> dominantDrivers = new List<DominantDriversType>();

            if (Productivity.Value >= PRODUCTIVITY_THRESHOLD && Productivity.Trend == Trend.Rising)
            {
                dominantDrivers.Add(DominantDriversType.ProductivityGrowth);
            }
            if (Productivity.Value < PRODUCTIVITY_THRESHOLD && Productivity.Trend == Trend.Falling)
            {
                dominantDrivers.Add(DominantDriversType.ProductivityDecline);
            }
            if (DebtLevel >= DEBT_HIGH_THRESHOLD)
            {
                dominantDrivers.Add(DominantDriversType.DebtLevelHigh);
            }
            if (DebtLevel < DEBT_LOW_THRESHOLD)
            {
                dominantDrivers.Add(DominantDriversType.DebtLevelLow);
            }
            if (GlobalTrade == GlobalTrade.Stable)
            {
                dominantDrivers.Add(DominantDriversType.GlobalTradeStable);
            }
            if (GlobalTrade == GlobalTrade.Unstable)
            {
                dominantDrivers.Add(DominantDriversType.GlobalTradeUnstable);
            }
            if (MonetaryPolicy == MonetaryPolicyType.Accommodative)
            {
                dominantDrivers.Add(DominantDriversType.MonetaryPolicyAccommodative);
            }
            if (MonetaryPolicy == MonetaryPolicyType.Tight)
            {
                dominantDrivers.Add(DominantDriversType.MonetaryPolicyTight);
            }
            if (UnemploymentRate.Value >= UNEMPLOYMENT_HIGH_THRESHOLD)
            {
                dominantDrivers.Add(DominantDriversType.UnemploymentHigh);
            }
            if (UnemploymentRate.Value < UNEMPLOYMENT_LOW_THRESHOLD)
            {
                dominantDrivers.Add(DominantDriversType.UnemploymentLow);
            }
            return dominantDrivers;
        }
    }
}
