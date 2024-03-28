namespace Investor
{
    internal class DominantDrivers
    {
        private double Productivity;
        private double DebtLevel;
        private GlobalTrade GlobalTrade;
        private MonetaryPolicyType MonetaryPolicy;
        public List<DominantDriversType> Drivers;

        public DominantDrivers(double productivityGrowth, double debtLevel, GlobalTrade globalTrade, MonetaryPolicyType monetaryPolicy) 
        { 
            Productivity = productivityGrowth;
            DebtLevel = debtLevel;
            GlobalTrade = globalTrade;
            MonetaryPolicy = monetaryPolicy;
            Drivers = IdentifyDominantDrivers();
        }
        private List<DominantDriversType> IdentifyDominantDrivers()
        {
            const double PRODUCTIVITY_THRESHOLD = 0.5;
            const double DEBT_HIGH_THRESHOLD = 100;
            const double DEBT_LOW_THRESHOLD = 60;

            // Analyze the data to determine the dominant drivers of the economy
            // TOOD: look not only at the current values but also at the trends
            List<DominantDriversType> dominantDrivers = new List<DominantDriversType>();

            if (Productivity >= PRODUCTIVITY_THRESHOLD)
            {
                dominantDrivers.Add(DominantDriversType.ProductivityGrowth);
            }
            if (Productivity < PRODUCTIVITY_THRESHOLD)
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
            return dominantDrivers;
        }
    }
}
