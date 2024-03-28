namespace Investor
{
    internal class MonetaryPolicy
    {
        private Vector InterestRate;
        public bool IsQE;
        public MonetaryPolicyType Type;

        public MonetaryPolicy(Vector interestRate, bool isQE) 
        {
            InterestRate = interestRate;
            IsQE = isQE;
            Type = DetermineMonetaryPolicy();
        }

        private MonetaryPolicyType DetermineMonetaryPolicy()
        {
            const double IR_THRESHOLD = 2;

            if (InterestRate.Trend == Trend.Rising && InterestRate.Value < IR_THRESHOLD)
            {
                return MonetaryPolicyType.Hawkish;
            }
            else if (InterestRate.Trend == Trend.Falling && InterestRate.Value > IR_THRESHOLD)
            {
                return MonetaryPolicyType.Dovish;
            }
            else if (IsQE || (InterestRate.Trend == Trend.Falling && InterestRate.Value < IR_THRESHOLD))
            {
                return MonetaryPolicyType.Accommodative;
            }
            else if (InterestRate.Trend == Trend.Rising && InterestRate.Value > IR_THRESHOLD && !IsQE)
            {
                return MonetaryPolicyType.Tight;
            }
            else
            {
                return MonetaryPolicyType.Unknown;
            }
        }
    }
}
