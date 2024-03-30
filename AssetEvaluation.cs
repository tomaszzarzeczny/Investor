namespace Investor
{
    public class AssetEvaluation
    {
        public static Dictionary<string, AssetScore> EvaluateAssetClasses(EconomicCycleType economicCycle, List<DominantDriversType> dominantDrivers)
        {
            List<string> recommendedAssets = new List<string>();
            Dictionary<string, AssetScore> assetScores = new Dictionary<string, AssetScore>();

            switch (economicCycle)
            {
                case EconomicCycleType.Recovery:
                case EconomicCycleType.Expansion:
                    assetScores["Stocks/ETFs"] = AssessStocksETFs(dominantDrivers);
                    assetScores["Real Estate/REITs"] = AssessRealEstateREITs(dominantDrivers);
                    assetScores["Metals"] = AssessMetals(dominantDrivers);
                    break;
                case EconomicCycleType.Peak:
                    assetScores["Bonds"] = AssessBonds(dominantDrivers);
                    assetScores["Cash"] = AssessCash(dominantDrivers);
                    break;
                case EconomicCycleType.Recession:
                    assetScores["Bonds"] = AssessBonds(dominantDrivers);
                    assetScores["Cash"] = AssessCash(dominantDrivers);
                    assetScores["Metals"] = AssessMetals(dominantDrivers);
                    break;
                case EconomicCycleType.Depression:
                    assetScores["Bonds"] = AssessBonds(dominantDrivers);
                    assetScores["Metals"] = AssessMetals(dominantDrivers);
                    assetScores["Stocks/ETFs"] = AssessStocksETFs(dominantDrivers);
                    break;
                case EconomicCycleType.Trough:
                    assetScores["Stocks/ETFs"] = AssessStocksETFs(dominantDrivers);
                    assetScores["Real Estate/REITs"] = AssessRealEstateREITs(dominantDrivers);
                    break;
                default:
                    // Handle unknown economic cycle phase
                    break;
            }

            assetScores["Cryptocurrencies"] = AssessCryptocurrencies(dominantDrivers);

            var x = assetScores.OrderByDescending(x => x.Value.Score).ToDictionary(x => x.Key, x => x.Value);
            return x;
        }

        private static AssetScore AssessStocksETFs(List<DominantDriversType> dominantDrivers)
        {
            var stocskETFsDrivers = new Dictionary<DominantDriversType, int>
            {
                { DominantDriversType.ProductivityGrowth, 5 },
                { DominantDriversType.GlobalTradeStable, 3 },
                { DominantDriversType.MonetaryPolicyAccommodative, 2 },
                { DominantDriversType.DebtLevelLow, 4 },
                { DominantDriversType.ProductivityDecline, -5 },
                { DominantDriversType.GlobalTradeUnstable, -3 },
                { DominantDriversType.MonetaryPolicyTight, -2 },
                { DominantDriversType.DebtLevelHigh, -4 },
                { DominantDriversType.UnemploymentLow, 3 },
            };

            return CalculateAssetScore(dominantDrivers, stocskETFsDrivers);
        }

        private static AssetScore AssessRealEstateREITs(List<DominantDriversType> dominantDrivers)
        {
            var stocskETFsDrivers = new Dictionary<DominantDriversType, int>
            {
                { DominantDriversType.ProductivityGrowth, 3 },
                { DominantDriversType.GlobalTradeStable, 3 },
                { DominantDriversType.MonetaryPolicyAccommodative, 5 },
                { DominantDriversType.DebtLevelLow, 2 },
                { DominantDriversType.ProductivityDecline, -2 },
                { DominantDriversType.GlobalTradeUnstable, -3 },
                { DominantDriversType.MonetaryPolicyTight, -2 },
                { DominantDriversType.DebtLevelHigh, -2 },
                { DominantDriversType.UnemploymentLow, 4 }
            };
            return CalculateAssetScore(dominantDrivers, stocskETFsDrivers);
        }

        private static AssetScore AssessMetals(List<DominantDriversType> dominantDrivers)
        {
            var stocskETFsDrivers = new Dictionary<DominantDriversType, int>
            {
                { DominantDriversType.MonetaryPolicyAccommodative, 5 },
                { DominantDriversType.GlobalTradeUnstable, 5 },
                { DominantDriversType.MonetaryPolicyTight, -3 },
                { DominantDriversType.DebtLevelHigh, 4 },
                { DominantDriversType.UnemploymentHigh, 2 }
            };
            return CalculateAssetScore(dominantDrivers, stocskETFsDrivers);
        }

        private static AssetScore AssessBonds(List<DominantDriversType> dominantDrivers)
        {
            var stocskETFsDrivers = new Dictionary<DominantDriversType, int>
            {
                { DominantDriversType.ProductivityGrowth, 4 },
                { DominantDriversType.GlobalTradeStable, 3 },
                { DominantDriversType.MonetaryPolicyAccommodative, 4 },
                { DominantDriversType.DebtLevelLow, 4 },
                { DominantDriversType.GlobalTradeUnstable, -3 },
                { DominantDriversType.MonetaryPolicyTight, -4 },
                { DominantDriversType.DebtLevelHigh, -4 }
            };
            return CalculateAssetScore(dominantDrivers, stocskETFsDrivers);
        }

        private static AssetScore AssessCash(List<DominantDriversType> dominantDrivers)
        {
            var stocskETFsDrivers = new Dictionary<DominantDriversType, int>
            {
                { DominantDriversType.ProductivityGrowth, -3 },
                { DominantDriversType.GlobalTradeUnstable, 1 },
                { DominantDriversType.MonetaryPolicyTight, 5 },
                { DominantDriversType.DebtLevelHigh, 2 }
            };
            return CalculateAssetScore(dominantDrivers, stocskETFsDrivers);
        }

        private static AssetScore AssessCryptocurrencies(List<DominantDriversType> dominantDrivers)
        {
            var stocskETFsDrivers = new Dictionary<DominantDriversType, int>
            {
                { DominantDriversType.ProductivityGrowth, 3 },
                { DominantDriversType.GlobalTradeStable, 3 },
                { DominantDriversType.MonetaryPolicyAccommodative, 5 },
                { DominantDriversType.GlobalTradeUnstable, 3 },
                { DominantDriversType.MonetaryPolicyTight, -5 },
                { DominantDriversType.DebtLevelHigh, 4 }
            };
            return CalculateAssetScore(dominantDrivers, stocskETFsDrivers);
        }

        private static AssetScore CalculateAssetScore(List<DominantDriversType> dominantDrivers, Dictionary<DominantDriversType, int> assetDrivers)
        {
            var score = 0;
            double confidenceDenominator = 0;

            foreach (var driver in dominantDrivers)
            {
                if (assetDrivers.ContainsKey(driver))
                {
                    score += assetDrivers[driver];
                    confidenceDenominator = assetDrivers[driver] > 0 ? confidenceDenominator + assetDrivers[driver] : confidenceDenominator;
                }
            }

            var confidence = confidenceDenominator == 0 ? 0 : score / confidenceDenominator;

            return new AssetScore(score, confidence);
        }
    }
}