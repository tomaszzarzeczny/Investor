namespace Investor
{
    internal class MonetaryPolicy
    {
        private double interestRateNum;
        private string interestRateCh;
        public bool isQE;
        public MonetaryPolicyType type;

        public MonetaryPolicy(double interestRateNum, string interestRateCh, bool isQE) 
        {
            this.interestRateCh = interestRateCh;
            this.interestRateNum = interestRateNum;
            this.isQE = isQE;
            type = DetermineMonetaryPolicy();
        }

        public MonetaryPolicyType DetermineMonetaryPolicy()
        {
            const double IR_THRESHOLD = 2;

            if (interestRateCh == "rising" && interestRateNum < IR_THRESHOLD)
            {
                return MonetaryPolicyType.Hawkish;
            }
            else if (interestRateCh == "falling" && interestRateNum > IR_THRESHOLD)
            {
                return MonetaryPolicyType.Dovish;
            }
            else if (isQE || (interestRateCh == "falling" && interestRateNum < IR_THRESHOLD))
            {
                return MonetaryPolicyType.Accommodative;
            }
            else if (interestRateCh == "rising" && interestRateNum > IR_THRESHOLD && !isQE)
            {
                return MonetaryPolicyType.Tight;
            }
            else
            {
                return MonetaryPolicyType.Unknown;
            }
        }
    }

    public enum MonetaryPolicyType
    {
        Hawkish,
        Dovish,
        Accommodative,
        Tight,
        Unknown
    }
}
